Imports APCD.Emissions
Imports APCD
Imports System.Text
Imports System.Data.OleDb
Imports APCD.Common
Imports System.IO

'----------------------------------------------------------------------
'Start an EY
'   show list of plants from last year that are not shut down.
'   allow adding other plants
'   populate plantyear per above
'   get Hansen ENV contacts per plantyear
'   be sure plantclassid is up to date
'----------------------------------------------------------------------

Public Class MainForm

#Region "----- properties -----"

    Public WriteOnly Property WhereAmI() As String
        Set(ByVal value As String)
            Me.lblWhereAmI.Text = value
        End Set
    End Property

    Public WriteOnly Property MainStatusText() As String
        Set(ByVal value As String)
            Me.statusLevel.Text = value
        End Set
    End Property

#End Region '----- properties -----

    '6/28/12 because as of today for some reason the selectedIndexChanged event fires when the form closes
    Private m_formIsClosing As Boolean = False

    'navigation
    Friend Structure NavigationTable
        Public Shared ControlMeasure As DataTable
        Public Shared Plant As DataTable
        Public Shared EmissionUnit As DataTable
        Public Shared Process As DataTable
        Public Shared ReleasePoint As DataTable
    End Structure


    Private m_emissionYear As EmissionsDataSet.EmissionYearRow
    Private m_plant As EmissionsInventory.EmissionsDataSet.PlantRow
    Private m_plantYear As EmissionsDataSet.PlantYearRow

    Private m_latestEmissionYear As Int16

    Private m_blnFormIsLoaded As Boolean = False
    Private m_enumButtonMode As GlobalVariables.ButtonMode = Nothing

    Private m_selectedNode As TreeNode

    Private m_DynamicMenu As ToolStripMenuItem
    Private m_intCurrentNodeLevel As Int32 = -1 'default to -1 because 0 is a valid node
    Private m_intLastNodeLevel As Int32 = -1 'default to -1 because 0 is a valid node

    'to help manage dynamic menu
    Const MAIN_MENU_ITEM_COUNT As Int32 = 5

    Private Structure TitleText
        Const ControlMeasures As String = "Control Measures"
        Const EmissionUnitsAndProcesses As String = "Emission Units and Processes"
        Const ReleasePoints As String = "Release Points"
    End Structure

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.lblWhereAmI.Visible = False

        Me.Visible = False
        Dim frm As splashScreenForm = New splashScreenForm
        frm.ShowDialog()
        Me.Visible = True

        Me.EmissionYear_GetLookupTableTableAdapter.Fill(Me.EmissionsDataSet.EmissionYear_GetLookupTable)

        Call Me.LoadLookupTables()

#If DEBUG Then
        Me.StatusStrip1.BackColor = GlobalVariables.ConnectionStatusColor
        Me.MenuStrip1.BackColor = GlobalVariables.ConnectionStatusColor
#End If

        Call Me.LoadUserControlsIntoPanel2()
        Call Me.ChangeEmissionYearView()

        Me.m_latestEmissionYear = CShort(Me.EmissionYearComboBox.SelectedValue)

        Me.m_blnFormIsLoaded = True

        If (GlobalVariables.UserRole = GlobalVariables.Role.Programmer) Then
            ProgrammerToolStripMenuItem.Visible = True
        Else
            ProgrammerToolStripMenuItem.Visible = False
        End If

#If DEBUG Then
        If (GlobalVariables.UserRole = GlobalVariables.Role.Programmer) Then
            Me.AdminToolStripMenuItem.Visible = True
        Else
            If ((GlobalVariables.UserRole = GlobalVariables.Role.Administrator) Or _
                (GlobalVariables.UserRole = GlobalVariables.Role.Programmer)) Then
                Me.AdminToolStripMenuItem.Visible = True
            Else
                Me.AdminToolStripMenuItem.Visible = False
            End If
        End If
        Me.ToolsToolStripMenuItem.Visible = True
#Else
        Me.AdminToolStripMenuItem.Visible = False
        Me.ToolsToolStripMenuItem.Visible = True

        'If ((GlobalVariables.Employee.UserName = "kthorne") OrElse (GlobalVariables.Employee.UserName = "Sraj")) Then
        'End If

        If ((GlobalVariables.UserRole = GlobalVariables.Role.Administrator) Or _
            (GlobalVariables.UserRole = GlobalVariables.Role.Programmer)) Then
            Me.AdminToolStripMenuItem.Visible = True
        Else
            Me.AdminToolStripMenuItem.Visible = False
        End If
#End If

        Me.TreeViewMain.SelectedNode = Me.TreeViewMain.Nodes(0)
        Me.m_selectedNode = Me.TreeViewMain.SelectedNode
        Me.TreeViewMain.Focus()

        Me.WhereAmI = String.Empty

    End Sub

    Private Sub LoadLookupTables()
        Me.ControlMeasureTypeTableAdapter.Fill(GlobalVariables.LookupTable.ControlMeasureType)
        Me.EmissionUnitTypeTableAdapter.Fill(GlobalVariables.LookupTable.EmissionUnitType)
        Me.EmissionUnitTypeTableAdapter.GetReal(GlobalVariables.LookupTable.EmissionUnitType_Real)

        Me.PlantTableAdapter.FillLookupTableByEmissionYear(GlobalVariables.LookupTable.Plant, CShort(Me.EmissionYearComboBox.SelectedValue))
        Me.PollutantTableAdapter.Fill(GlobalVariables.LookupTable.Pollutant)

        Me.ThroughputTypeTableAdapter.Fill(GlobalVariables.LookupTable.ThroughputType)
        Me.ThroughputTypeTableAdapter.GetReal(GlobalVariables.LookupTable.ThroughputType_Real)
        Me.UnitOfMeasurementTableAdapter.Fill(GlobalVariables.LookupTable.UnitOfMeasurement)
    End Sub

    Private Sub LoadUserControlsIntoPanel2()

        Me.SplitContainerMain.Panel2.Controls.Add(Me.m_plantUserControl)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.m_emissionUnitUserControl)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.m_controlMeasureUserControl)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.m_releasePointUserControl)
        Me.SplitContainerMain.Panel2.Controls.Add(Me.m_processUserControl)
        For Each ctrl As Control In Me.SplitContainerMain.Panel2.Controls
            ctrl.Dock = DockStyle.Fill
        Next

    End Sub

    Private Sub EmissionYearComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionYearComboBox.SelectedIndexChanged
        If (Not Me.m_formIsClosing) Then
            Call Me.ChangeEmissionYearView()
            Call Me.ToggleMenuItems()
        End If
    End Sub

    Private Sub ChangeEmissionYearView()
        Try
            If (Me.m_blnFormIsLoaded = True) Then
                Call Me.ClearMainObjects()
                Call Me.ClearNavigationTables()
            End If

            Dim emissionYear As Int16 = CShort(Me.EmissionYearComboBox.SelectedValue)
            Me.EmissionYearTableAdapter.FillByEmissionYear(Me.EmissionsDataSet.EmissionYear, emissionYear)
            Me.m_emissionYear = CType(Me.EmissionsDataSet.EmissionYear.Rows(0), EmissionsInventory.EmissionsDataSet.EmissionYearRow)

            Call Me.LoadNavigationTables(emissionYear)
            Me.m_enumButtonMode = Nothing
            Call Me.btnPlantsAndProcesses_Click(Nothing, Nothing)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ClearNavigationTables()

        NavigationTable.Plant.Clear()
        NavigationTable.ControlMeasure.Clear()
        NavigationTable.EmissionUnit.Clear()
        NavigationTable.Process.Clear()
        NavigationTable.ReleasePoint.Clear()

    End Sub

    Private Sub LoadNavigationTables(ByVal emissionsYear As Int16)

        NavigationTable.Plant = Helper.FacilitiesHelper.GetPlantNavigationView(emissionsYear)
        NavigationTable.ControlMeasure = Utility.ControlMeasureUtility.GetNavigationView(emissionsYear)
        NavigationTable.EmissionUnit = Utility.PlantEmissionUnitUtility.GetNavigationView(emissionsYear)
        NavigationTable.Process = Utility.ProcessUtility.GetNavigationView(emissionsYear)
        NavigationTable.ReleasePoint = Utility.ReleasePointUtility.GetNavigationView(emissionsYear)

    End Sub

    Private Sub ClearMainObjects()

        Call Me.ClearPlantObjects()
        Call Me.ClearControlMeasureObjects()
        Call Me.ClearEmissionUnitObjects()
        Call Me.ClearProcessObjects()
        Call Me.ClearReleasePointObjects()

    End Sub

    Private Sub ToggleMenuItems()

        If ((Me.m_latestEmissionYear = Me.m_emissionYear.EmissionYear) AndAlso _
            (Me.m_emissionYear.IsFacilityInEISDateNull)) Then
            Me.Import91TFormToolStripMenuItem.Enabled = True
            Me.Import92TFormToolStripMenuItem.Enabled = True
        Else
            Me.Import91TFormToolStripMenuItem.Enabled = False
            Me.Import92TFormToolStripMenuItem.Enabled = False
        End If

    End Sub

    Private Sub btnPlantsAndProcesses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantsAndProcesses.Click

        If (Me.m_enumButtonMode <> GlobalVariables.ButtonMode.Processes) Then
            Me.m_enumButtonMode = GlobalVariables.ButtonMode.Processes
            Me.Text = TitleText.EmissionUnitsAndProcesses & " - " & Application.ProductName

            'toggle the button colors
            Me.btnControlMeasures.BackColor = Color.LightGray
            Me.btnPlantsAndProcesses.BackColor = Color.DodgerBlue
            Me.btnPlantsAndReleasePoints.BackColor = Color.LightGray

            Call Me.ChangeModeHelper()
        End If

    End Sub

    Private Sub btnPlantsAndReleasePoints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlantsAndReleasePoints.Click

        If (Me.m_enumButtonMode <> GlobalVariables.ButtonMode.ReleasePoints) Then
            Me.m_enumButtonMode = GlobalVariables.ButtonMode.ReleasePoints
            Me.Text = TitleText.ReleasePoints & " - " & Application.ProductName

            'toggle the button colors
            Me.btnControlMeasures.BackColor = Color.LightGray
            Me.btnPlantsAndProcesses.BackColor = Color.LightGray
            Me.btnPlantsAndReleasePoints.BackColor = Color.DodgerBlue

            Call Me.ChangeModeHelper()
        End If

    End Sub

    Private Sub btnControlMeasures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnControlMeasures.Click

        Call Me.SwitchToControlMeasureTreeView()

    End Sub

    Private Sub SwitchToControlMeasureTreeView()
        If (Me.m_enumButtonMode <> GlobalVariables.ButtonMode.ControlMeasures) Then
            Me.m_enumButtonMode = GlobalVariables.ButtonMode.ControlMeasures
            Me.Text = TitleText.ControlMeasures & " - " & Application.ProductName

            'toggle the button colors
            Me.btnControlMeasures.BackColor = Color.DodgerBlue
            Me.btnPlantsAndProcesses.BackColor = Color.LightGray
            Me.btnPlantsAndReleasePoints.BackColor = Color.LightGray

            Call Me.ChangeModeHelper()
        End If
    End Sub

    Private Sub ChangeModeHelper()
        Me.m_intLastNodeLevel = -1
        Call Me.ToggleUserControlVisibility(String.Empty)

        'remove the dynamic menu item
        If (Me.MenuStrip1.Items.Count > MAIN_MENU_ITEM_COUNT) Then
            Me.MenuStrip1.Items.RemoveAt(1)
        End If

        Call Me.LoadTreeView()

        Me.TreeViewMain.SelectedNode = Me.TreeViewMain.Nodes(0)
        Me.TreeViewMain.Focus()

        Me.WhereAmI = String.Empty

    End Sub

#Region "----- treeview events -----"

    Private Sub LoadTreeView()

        'Anytime we load, clear out what's here
        Me.TreeViewMain.Nodes.Clear()

        Select Case Me.m_enumButtonMode
            Case GlobalVariables.ButtonMode.ControlMeasures
                Call Me.LoadTreeView_ControlMeasures()

            Case GlobalVariables.ButtonMode.Processes
                Call Me.LoadTreeView_EmissionUnitsAndProcesses()

            Case GlobalVariables.ButtonMode.ReleasePoints
                Call Me.LoadTreeView_ReleasePoints()
        End Select

    End Sub

    Private Sub LoadTreeView_ControlMeasures()

        For Each plantRow As DataRow In NavigationTable.Plant.Rows
            Dim plantNode As TreeNode = New TreeNode
            With plantNode
                .Name = plantRow(Facilities.Constants.PlantConstants.FieldName.PlantID).ToString
                .Text = plantRow(Facilities.Constants.PlantConstants.FieldName.PlantName).ToString
                'toggle color based on approved status
                If (IsDBNull(plantRow(EmissionsDataSet.ControlMeasureYear.ApprovalDateColumn.ColumnName))) Then
                    .ForeColor = Color.Red
                Else
                    .ForeColor = Color.Black
                End If
            End With
            Me.TreeViewMain.Nodes.Add(plantNode)

            'Add the control measures for this plant.
            Dim controlMeasureViewFilter As StringBuilder = New StringBuilder
            With controlMeasureViewFilter
                .Append("PlantID = ")
                .Append(plantRow(Facilities.Constants.PlantConstants.FieldName.PlantID).ToString)
            End With

            Dim controlMeasures As DataRow() = NavigationTable.ControlMeasure.Select(controlMeasureViewFilter.ToString)
            For Each controlMeasureRow As DataRow In controlMeasures
                Dim controlMeasureNode As TreeNode = New TreeNode
                With controlMeasureNode
                    .Name = CStr(controlMeasureRow(Constants.ControlMeasureConstants.FieldName.ControlMeasureID))
                    .Text = CStr(controlMeasureRow(Constants.ControlMeasureConstants.FieldName.ControlMeasureAPCDID))
                    If (Not Me.m_emissionYear.IsStartDateNull) Then
                        'toggle color based on approved status
                        If (IsDBNull(controlMeasureRow(EmissionsDataSet.ReleasePointYear.ApprovalDateColumn.ColumnName))) Then
                            .ForeColor = Color.Red
                        Else
                            .ForeColor = Color.Black
                        End If

                        'toggle color based on shut down status
                        If (Not IsDBNull(controlMeasureRow(EmissionsDataSet.ControlMeasure.EndDateColumn.ColumnName))) Then
                            .BackColor = Color.LightGray
                        End If
                    End If
                End With
                plantNode.Nodes.Add(controlMeasureNode)
            Next 'control measure

        Next 'plant

    End Sub

    Private Sub LoadTreeView_EmissionUnitsAndProcesses()

        For Each plantRow As DataRow In NavigationTable.Plant.Rows
            Dim plantNode As TreeNode = New TreeNode
            With plantNode
                .Name = plantRow(Facilities.Constants.PlantConstants.FieldName.PlantID).ToString
                .Text = plantRow(Facilities.Constants.PlantConstants.FieldName.PlantName).ToString
                If (Not Me.m_emissionYear.IsStartDateNull) Then
                    'toggle color based on approved status
                    If (IsDBNull(plantRow(Constants.PlantYearConstants.FieldName.ApprovalDate))) Then
                        .ForeColor = Color.Red
                    Else
                        .ForeColor = Color.Black
                    End If
                End If
            End With
            Me.TreeViewMain.Nodes.Add(plantNode)

            'Add the EUs for this plant.
            Dim emissionUnitViewFilter As StringBuilder = New StringBuilder
            With emissionUnitViewFilter
                .Append("PlantID = ")
                .Append(plantRow(Facilities.Constants.PlantConstants.FieldName.PlantID).ToString)
            End With
            Dim emissionUnits As DataRow() = NavigationTable.EmissionUnit.Select(emissionUnitViewFilter.ToString)
            For Each emissionUnitRow As DataRow In emissionUnits
                Dim emissionUnitNode As TreeNode = New TreeNode
                With emissionUnitNode
                    .Name = CStr(emissionUnitRow(Constants.PlantEmissionUnitConstants.FieldName.PlantEmissionUnitID))
                    .Text = CStr(emissionUnitRow(Constants.PlantEmissionUnitConstants.FieldName.EmissionUnitAPCDID))
                    If (Not Me.m_emissionYear.IsStartDateNull) Then
                        'toggle color based on approved status
                        If (IsDBNull(emissionUnitRow(Constants.ProcessYearConstants.FieldName.ApprovalDate))) Then
                            .ForeColor = Color.Red
                        Else
                            .ForeColor = Color.Black
                        End If

                        'toggle color based on shut down status
                        If (Not IsDBNull(emissionUnitRow(Constants.PlantEmissionUnitConstants.FieldName.EndDate))) Then
                            .BackColor = Color.LightGray
                        End If
                    End If

                End With

                plantNode.Nodes.Add(emissionUnitNode)

                'Add Processes to the emission units
                Dim processViewFilter As StringBuilder = New StringBuilder
                With processViewFilter
                    .Append("PlantID = ")
                    .Append(plantRow(Facilities.Constants.PlantConstants.FieldName.PlantID).ToString)
                    .Append(" AND PlantEmissionUnitID = ")
                    .Append(CStr(emissionUnitRow(Constants.PlantEmissionUnitConstants.FieldName.PlantEmissionUnitID)))
                End With

                Dim emissionProcesses As DataRow() = NavigationTable.Process.Select(processViewFilter.ToString)
                For Each emissionProcessRow As DataRow In emissionProcesses
                    Dim processNode As TreeNode = New TreeNode
                    With processNode
                        .Name = CStr(emissionProcessRow(Constants.ProcessConstants.FieldName.ProcessID))
                        .Text = emissionProcessRow(Constants.ProcessConstants.FieldName.ProcessAPCDID).ToString

                        If (Not Me.m_emissionYear.IsStartDateNull) Then
                            'toggle color based on approved status
                            If (IsDBNull(emissionProcessRow(Constants.ProcessYearConstants.FieldName.ApprovalDate))) Then
                                .ForeColor = Color.Red
                            Else
                                .ForeColor = Color.Black
                            End If

                            'toggle color based on shut down status
                            If (Not IsDBNull(emissionProcessRow(Constants.ProcessConstants.FieldName.EndDate))) Then
                                .BackColor = Color.LightGray
                            End If
                        End If

                    End With
                    emissionUnitNode.Nodes.Add(processNode)
                Next 'process

            Next 'emission unit

        Next 'plant

    End Sub

    Private Sub LoadTreeView_ReleasePoints()

        For Each plantRow As DataRow In NavigationTable.Plant.Rows
            Dim plantNode As TreeNode = New TreeNode
            With plantNode
                .Name = plantRow(Facilities.Constants.PlantConstants.FieldName.PlantID).ToString
                .Text = plantRow(Facilities.Constants.PlantConstants.FieldName.PlantName).ToString
                If (Not Me.m_emissionYear.IsStartDateNull) Then
                    'toggle color based on approved status
                    If (IsDBNull(plantRow(Constants.ProcessYearConstants.FieldName.ApprovalDate))) Then
                        .ForeColor = Color.Red
                    Else
                        .ForeColor = Color.Black
                    End If
                End If

            End With
            Me.TreeViewMain.Nodes.Add(plantNode)

            'Add the release points for this plant.
            Dim releasePointViewFilter As StringBuilder = New StringBuilder
            With releasePointViewFilter
                .Append("PlantID = ")
                .Append(plantRow(Facilities.Constants.PlantConstants.FieldName.PlantID).ToString)
            End With

            Dim releasePoints As DataRow() = NavigationTable.ReleasePoint.Select(releasePointViewFilter.ToString)

            For Each releasePointRow As DataRow In releasePoints
                Dim releasePointNode As TreeNode = New TreeNode
                With releasePointNode
                    .Name = CStr(releasePointRow(Constants.ReleasePointConstants.FieldName.ReleasePointID))
                    .Text = CStr(releasePointRow(Constants.ReleasePointConstants.FieldName.ReleasePointAPCDID))
                    If (Not Me.m_emissionYear.IsStartDateNull) Then
                        'toggle color based on approved status
                        If (IsDBNull(releasePointRow(EmissionsDataSet.ReleasePointYear.ApprovalDateColumn.ColumnName))) Then
                            .ForeColor = Color.Red
                        Else
                            .ForeColor = Color.Black
                        End If

                        'toggle color based on shut down status
                        If (Not IsDBNull(releasePointRow(Constants.ReleasePointConstants.FieldName.EndDate))) Then
                            .BackColor = Color.LightGray
                        End If
                    End If

                End With
                plantNode.Nodes.Add(releasePointNode)

            Next 'releasePointRow As DataRow In releasePoints

        Next 'plantRow As DataRow In NavigationTable.Plant.Rows

    End Sub

    Private Sub TreeViewMain_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewMain.AfterSelect

        If (Me.TreeViewMain.SelectedNode.Level = Me.m_intLastNodeLevel) Then

            'if the node changed, set the module variable and refresh the screen
            If (Me.m_selectedNode.Name <> Me.TreeViewMain.SelectedNode.Name) Then
                Call Me.TreeViewMain_AfterSelect_ToggleNodeBackColor()
                Call Me.TreeViewMain_AfterSelect_ClearObjectsFromPreviousNode()
                Me.m_selectedNode = Me.TreeViewMain.SelectedNode
                Me.LoadUserControl()
            End If

        Else

            'the node level changed; set the module variable and the last level and refresh the screen
            Call Me.TreeViewMain_AfterSelect_ToggleNodeBackColor()
            Call Me.TreeViewMain_AfterSelect_ClearObjectsFromPreviousNode()

            Me.m_selectedNode = Me.TreeViewMain.SelectedNode

            Call Me.CreateDynamicMenu()
            Me.m_intLastNodeLevel = Me.TreeViewMain.SelectedNode.Level
            Me.LoadUserControl()
        End If

        If (Me.m_selectedNode.Level = 0) Then
            Me.WhereAmI = CType(GlobalVariables.LookupTable.Plant.FindByPlantID(CInt(Me.m_selectedNode.Name)), EmissionsDataSet.PlantRow).PlantName
        End If

        Me.TreeViewMain.SelectedNode.BackColor = Color.SkyBlue

    End Sub

    Private Sub TreeViewMain_AfterSelect_ToggleNodeBackColor()

        If (Not Me.m_selectedNode Is Nothing) Then

            Me.m_selectedNode.BackColor = Color.Empty

            Select Case Me.m_enumButtonMode

                Case GlobalVariables.ButtonMode.ControlMeasures
                    Select Case Me.m_intLastNodeLevel
                        Case 0 'plant
                            '
                        Case 1 'control measure
                            Try
                                If (Not Me.m_controlMeasure.IsEndDateNull) Then
                                    Me.m_selectedNode.BackColor = Color.LightGray
                                End If
                            Catch ex As Exception
                                'exception will be thrown when the object is deleted
                            End Try

                    End Select

                Case GlobalVariables.ButtonMode.Processes
                    Select Case Me.m_intLastNodeLevel
                        Case 0 'plant
                            '
                        Case 1 'EU
                            Try
                                If (Not Me.m_emissionUnit.IsEndDateNull) Then
                                    Me.m_selectedNode.BackColor = Color.LightGray
                                End If
                            Catch ex As Exception
                                'exception will be thrown when the object is deleted
                            End Try

                        Case 2 'process
                            Try
                                If (Not Me.m_process.IsEndDateNull) Then
                                    Me.m_selectedNode.BackColor = Color.LightGray
                                End If
                            Catch ex As Exception
                                'exception will be thrown when the object is deleted
                            End Try
                    End Select

                Case GlobalVariables.ButtonMode.ReleasePoints
                    Select Case Me.m_intLastNodeLevel
                        Case 0 'plant
                            '
                        Case 1 'release point
                            Try
                                If (Not Me.m_releasePoint.IsEndDateNull) Then
                                    Me.m_selectedNode.BackColor = Color.LightGray
                                End If
                            Catch ex As Exception
                                'exception will be thrown when the object is deleted
                            End Try
                    End Select

            End Select

        End If

    End Sub

    Private Sub TreeViewMain_AfterSelect_ClearObjectsFromPreviousNode()

        With Me.EmissionsDataSet

            Select Case Me.m_enumButtonMode

                Case GlobalVariables.ButtonMode.ControlMeasures
                    Select Case Me.m_intLastNodeLevel
                        Case 0 'plant
                            Call Me.ClearPlantObjects()

                        Case 1 'control measure
                            Call Me.ClearControlMeasureObjects()
                    End Select

                Case GlobalVariables.ButtonMode.Processes
                    Select Case Me.m_intLastNodeLevel
                        Case 0 'plant
                            Call Me.ClearPlantObjects()

                        Case 1 'EU
                            Call Me.ClearEmissionUnitObjects()

                        Case 2 'process
                            Call Me.ClearProcessObjects()

                    End Select

                Case GlobalVariables.ButtonMode.ReleasePoints
                    Select Case Me.m_intLastNodeLevel
                        Case 0 'plant
                            Call Me.ClearPlantObjects()

                        Case 1 'release point
                            Call Me.ClearReleasePointObjects()
                    End Select

            End Select

        End With

    End Sub

    'only gets called if the user selected a different node
    Private Sub LoadUserControl()

        Me.statusLevel.Text = String.Empty

        Select Case Me.m_enumButtonMode
            Case GlobalVariables.ButtonMode.ControlMeasures
                Select Case Me.TreeViewMain.SelectedNode.Level
                    Case 0 'plant
                        Call Me.LoadPlantUserControl()

                    Case 1 'control measure
                        Call Me.LoadControlMeasureUserControl()
                End Select

            Case GlobalVariables.ButtonMode.Processes
                Select Case Me.TreeViewMain.SelectedNode.Level
                    Case 0 'plant
                        Call Me.LoadPlantUserControl()

                    Case 1 'EU
                        Call Me.LoadEmissionUnitUserControl()

                    Case 2 'process
                        Call Me.LoadProcessUserControl()
                End Select

            Case GlobalVariables.ButtonMode.ReleasePoints
                Select Case Me.TreeViewMain.SelectedNode.Level
                    Case 0 'plant
                        Call Me.LoadPlantUserControl()

                    Case 1 'release point
                        Call Me.LoadReleasePointUserControl()
                End Select

        End Select

    End Sub

    Private Sub ToggleUserControlVisibility(ByVal controlName As String)

        For Each ctl As Control In Me.SplitContainerMain.Panel2.Controls
            If (ctl.Name = controlName) Then
                ctl.Visible = True
            Else
                ctl.Visible = False
            End If
        Next

    End Sub

#End Region '----- treeview events -----

#Region "----- dynamic menus and events -----"

    Private Sub CreateDynamicMenu()

        Dim blnOkToAddItem As Boolean = False

        'remove the current dynamic menu item
        If (Me.MenuStrip1.Items.Count > MAIN_MENU_ITEM_COUNT) Then
            Me.MenuStrip1.Items.RemoveAt(1)
        End If

        Select Case Me.m_enumButtonMode
            Case GlobalVariables.ButtonMode.ControlMeasures
                Select Case Me.m_selectedNode.Level
                    Case 0
                        Me.m_DynamicMenu = New ToolStripMenuItem("&Plant")
                        Me.m_DynamicMenu.DropDownItems.Add(New ToolStripMenuItem("&Create New Control Measure", Nothing, New EventHandler(AddressOf Me.Plant_AddControlMeasure_Click)))
                        blnOkToAddItem = True

                End Select

            Case GlobalVariables.ButtonMode.Processes
                Select Case Me.m_selectedNode.Level
                    Case 0
                        Me.m_DynamicMenu = New ToolStripMenuItem("&Plant")
                        Me.m_DynamicMenu.DropDownItems.Add(New ToolStripMenuItem("&Create New Emission Unit", Nothing, New EventHandler(AddressOf Me.Plant_AddEmissionUnit_Click)))
                        blnOkToAddItem = True

                    Case 1
                        Me.m_DynamicMenu = New ToolStripMenuItem("&Emission Unit")
                        Me.m_DynamicMenu.DropDownItems.Add(New ToolStripMenuItem("&Add a New Process", Nothing, New EventHandler(AddressOf Me.EU_AddProcess_Click)))
                        'Workaround 20111013: set flag below to false to hide this item while it is being developed
                        blnOkToAddItem = True

                    Case 2
                        'Me.m_DynamicMenu = New ToolStripMenuItem("&Process")
                        blnOkToAddItem = False

                End Select

            Case GlobalVariables.ButtonMode.ReleasePoints
                Select Case Me.m_selectedNode.Level
                    Case 0
                        Me.m_DynamicMenu = New ToolStripMenuItem("&Plant")
                        Me.m_DynamicMenu.DropDownItems.Add(New ToolStripMenuItem("&Create New Release Point", Nothing, New EventHandler(AddressOf Me.Plant_AddReleasePoint_Click)))
                        If GlobalVariables.UserRole = GlobalVariables.Role.Approver Then

                        End If
                        blnOkToAddItem = True

                    Case 1
                        blnOkToAddItem = False
                End Select

        End Select

        If (blnOkToAddItem) Then
            Me.MenuStrip1.Items.Insert(1, Me.m_DynamicMenu)
        End If

    End Sub

    '----- Plant menu events -----
    Private Sub Plant_AddEmissionUnit_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (Me.m_selectedNode.BackColor = Color.LightGray) Then
            MessageBox.Show("Adding an EU to a plant that is shut down is not allowed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Call Me.AddEmissionUnit_Step1(CShort(Me.EmissionYearComboBox.SelectedValue), CInt(Me.TreeViewMain.SelectedNode.Name))
        End If

    End Sub

    '----- Emission Unit menu events -----
    Private Sub EU_AddProcess_Click(ByVal sender As Object, ByVal e As EventArgs)

        If (Me.m_selectedNode.BackColor = Color.LightGray) Then
            MessageBox.Show("Adding a process to an EU that is shut down is not allowed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Call Me.AddProcess_Step1(CShort(Me.EmissionYearComboBox.SelectedValue), CInt(Me.TreeViewMain.SelectedNode.Name))
        End If

    End Sub

#Region "----- Add EmissionUnit - wizard events -----"

    Private Sub AddEmissionUnit_Step1(ByVal emissionYear As Int16, ByVal plantID As Int32)

        Dim frm As New AddEmissionUnit(emissionYear, plantID)
        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            NavigationTable.EmissionUnit.Clear()
            NavigationTable.EmissionUnit = Utility.PlantEmissionUnitUtility.GetNavigationView(CShort(Me.EmissionYearComboBox.SelectedValue))
            Call Me.LoadTreeView()
            For Each parentNode As TreeNode In Me.TreeViewMain.Nodes
                If (parentNode.Name = Me.m_selectedNode.Name) Then
                    Me.TreeViewMain.SelectedNode = parentNode
                    Me.TreeViewMain.SelectedNode.Expand()
                    Exit For
                End If
            Next
        End If

    End Sub

#End Region '----- Add EmissionUnit - wizard events -----

#Region "----- Add Process - wizard events -----"

    Private Sub AddProcess_Step1(ByVal emissionYear As Int16, ByVal plantID As Int32)

        Dim frm As New AddProcessStep1(emissionYear, plantID)
        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            NavigationTable.Process.Clear()
            NavigationTable.Process = Utility.ProcessUtility.GetNavigationView(CShort(Me.EmissionYearComboBox.SelectedValue))
            Call Me.LoadTreeView()

            For Each parentNode As TreeNode In Me.TreeViewMain.Nodes
                If (parentNode.Name = Me.m_selectedNode.Parent.Name) Then
                    For Each childNode As TreeNode In parentNode.Nodes
                        If (childNode.Name = Me.m_selectedNode.Name) Then
                            ' ''/////////////////////////////////////
                            'Implement this somehow later?
                            'For Each grandChildNode As TreeNode In childNode.Nodes
                            '    If (grandChildNode.Name = "the ID of the new node") Then
                            '        Me.m_selectedNode = grandChildNode
                            '        Me.TreeViewMain.SelectedNode = grandChildNode
                            '        Me.TreeViewMain.SelectedNode.Expand()
                            '        Exit For
                            '    End If
                            'Next
                            'Exit For
                            ''/////////////////////////////////////

                            Me.TreeViewMain.SelectedNode = childNode
                            Me.TreeViewMain.SelectedNode.Expand()
                            Exit For
                        End If
                    Next
                End If
            Next
        End If

        'Select Case GlobalVariables.AddProcessStep
        '    Case GlobalVariables.WizardStep._Next
        '        NavigationTable.Process.Clear()
        '        NavigationTable.Process = Utility.ProcessUtility.GetNavigationView(CShort(Me.EmissionYearComboBox.SelectedValue))
        '        Call Me.LoadTreeView()
        'End Select

    End Sub

    'Private Sub AddProcess_Step2(ByVal ds As EmissionsDataSet)

    '    Dim frm As New AddProcessStep2()
    '    frm.ShowDialog()
    '    Select Case GlobalVariables.AddProcessStep
    '        Case GlobalVariables.WizardStep._Next
    '            Call Me.AddProcess_Step3(ds)
    '    End Select

    'End Sub

    'Private Sub AddProcess_Step3(ByVal ds As EmissionsDataSet)
    '    Dim frm As New AddProcessStep3()
    '    frm.ShowDialog()
    '    Select Case GlobalVariables.AddProcessStep
    '        Case GlobalVariables.WizardStep._Back
    '            Call Me.AddProcess_Step2(ds)
    '        Case GlobalVariables.WizardStep._Save
    '            NavigationTable.ReleasePoint.Clear()
    '            NavigationTable.ReleasePoint = Utility.ReleasePointUtility.GetNavigationView(CShort(Me.EmissionYearComboBox.SelectedValue))
    '            Call Me.LoadTreeView()
    '    End Select
    'End Sub


#End Region '----- Add Process - wizard events -----

#Region "----- Release Point menu events -----"

    Private Sub Plant_AddReleasePoint_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (Me.m_selectedNode.BackColor = Color.LightGray) Then
            MessageBox.Show("Adding an release point to a plant that is shut down is not allowed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Dim ds As New EmissionsDataSet
            Call Me.AddReleasePoint_Step1(ds, CShort(Me.EmissionYearComboBox.SelectedValue), CInt(Me.TreeViewMain.SelectedNode.Name))
        End If
    End Sub

    Private Sub AddReleasePoint_Step1(ByVal ds As EmissionsDataSet, ByVal emissionYear As Int16, ByVal plantID As Int32)
        Dim frm As New AddReleasePointStep1(ds, emissionYear, plantID)
        frm.ShowDialog()
        Select Case GlobalVariables.AddReleasePointStep
            Case GlobalVariables.WizardStep._Next
                Call Me.AddReleasePoint_Step2(ds)
        End Select
    End Sub

    Private Sub AddReleasePoint_Step1(ByVal ds As EmissionsDataSet)
        Dim frm As New AddReleasePointStep1(ds, CShort(Me.EmissionYearComboBox.SelectedValue), CInt(Me.TreeViewMain.SelectedNode.Name))
        frm.ShowDialog()
        Select Case GlobalVariables.AddReleasePointStep
            Case GlobalVariables.WizardStep._Next
                Call Me.AddReleasePoint_Step2(ds)
        End Select
    End Sub

    Private Sub AddReleasePoint_Step2(ByVal ds As EmissionsDataSet)

        Dim frm As New AddReleasePointStep2(ds)
        frm.ShowDialog()
        Select Case GlobalVariables.AddReleasePointStep
            Case GlobalVariables.WizardStep._Back
                Call Me.AddReleasePoint_Step1(ds)
            Case GlobalVariables.WizardStep._Next
                Call Me.AddReleasePoint_Step3(ds)
        End Select

    End Sub

    Private Sub AddReleasePoint_Step3(ByVal ds As EmissionsDataSet)
        Dim frm As New AddReleasePointStep3(ds)
        frm.ShowDialog()
        Select Case GlobalVariables.AddReleasePointStep
            Case GlobalVariables.WizardStep._Back
                Call Me.AddReleasePoint_Step2(ds)
            Case GlobalVariables.WizardStep._Next
                Call Me.AddReleasePoint_Step4(ds)
        End Select
    End Sub

    Private Sub AddReleasePoint_Step4(ByVal ds As EmissionsDataSet)
        Dim frm As New AddReleasePointStep4(ds)
        frm.ShowDialog()
        Select Case GlobalVariables.AddReleasePointStep
            Case GlobalVariables.WizardStep._Back
                Call Me.AddReleasePoint_Step3(ds)
            Case GlobalVariables.WizardStep._Save
                NavigationTable.ReleasePoint.Clear()
                NavigationTable.ReleasePoint = Utility.ReleasePointUtility.GetNavigationView(CShort(Me.EmissionYearComboBox.SelectedValue))
                Call Me.LoadTreeView()

                For Each node As TreeNode In Me.TreeViewMain.Nodes
                    If (node.Name = Me.m_selectedNode.Name) Then
                        Me.TreeViewMain.SelectedNode = node
                        Me.TreeViewMain.SelectedNode.Expand()
                        Exit For
                    End If
                Next

        End Select
    End Sub

#End Region '----- Release Point menu events -----

#Region "----- Control Measure menu events -----"

    Private Sub Plant_AddControlMeasure_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (Me.m_selectedNode.BackColor = Color.LightGray) Then
            MessageBox.Show("Adding an control measure to a plant that is shut down is not allowed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            Call Me.AddControlMeasure_Step1(CShort(Me.EmissionYearComboBox.SelectedValue), CInt(Me.TreeViewMain.SelectedNode.Name), New ArrayList)
        End If
    End Sub

    Private Sub AddControlMeasure_Step1(ByVal emissionYear As Int16, ByVal plantID As Int32, ByVal controlMeasureID As ArrayList)
        Dim frm As New AddControlMeasureStep1(emissionYear, plantID, controlMeasureID)
        frm.ShowDialog()
        Select Case GlobalVariables.AddControlMeasureStep
            Case GlobalVariables.WizardStep._Next
                NavigationTable.ControlMeasure.Clear()
                NavigationTable.ControlMeasure = Utility.ControlMeasureUtility.GetNavigationView(CShort(Me.EmissionYearComboBox.SelectedValue))
                Call Me.LoadTreeView()

                For Each node As TreeNode In Me.TreeViewMain.Nodes
                    If (node.Name = Me.m_selectedNode.Name) Then
                        Me.TreeViewMain.SelectedNode = node
                        Me.TreeViewMain.SelectedNode.Expand()
                        Exit For
                    End If
                Next
                Call Me.AddControlMeasure_Step2(controlMeasureID)
        End Select
    End Sub

    Private Sub AddControlMeasure_Step2(ByVal controlMeasureID As ArrayList)

        Dim frm As New AddControlMeasureStep2()
        frm.ShowDialog()
        Select Case GlobalVariables.AddControlMeasureStep
            Case GlobalVariables.WizardStep._Next
                Call Me.AddControlMeasure_Step3(controlMeasureID)
        End Select

    End Sub

    Private Sub AddControlMeasure_Step3(ByVal controlMeasureID As ArrayList)
        Dim frm As New AddControlMeasureStep3(controlMeasureID, Me.m_emissionYear)
        frm.ShowDialog()
    End Sub

#End Region '----- Control Measure menu events -----


#End Region '----- dynamic menus and events -----

#Region "----- close -----"

    Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing


        If ((e.CloseReason = CloseReason.WindowsShutDown) OrElse (e.CloseReason = CloseReason.TaskManagerClosing)) Then

            GlobalVariables.ApplicationLog.AppendLine()

            'write the mode
            Select Case e.CloseReason
                Case CloseReason.WindowsShutDown
                    GlobalVariables.ApplicationLog.AppendLine("WindowsShutDown.")
                Case CloseReason.TaskManagerClosing
                    GlobalVariables.ApplicationLog.AppendLine("TaskManagerClosing.")
            End Select

        End If

        If (GlobalVariables.ApplicationLog.ToString.Length > 0) Then
            GlobalVariables.ApplicationLog.Insert(0, Me.GetLogHeader)
            Call Me.WriteApplicationLogToFile()
        End If

        'workaround because EmissionUnitTypeIDComboBox_SelectedIndexChanged() throws ex when closing if a user never selects an EU during a session ???
        Me.m_emissionUnitUserControl.controlIsLoaded = False

        Applications.Utility.EmployeeApplicationUtility.Logoff(GlobalVariables.EmployeeApplication.EmployeeApplicationID)

        Me.m_formIsClosing = True

    End Sub

    Private Function GetLogHeader() As String

        Dim strb As StringBuilder = New StringBuilder

        strb.AppendLine("---------------------------------------------------------------------------------------------------")
        strb.Append(Now.ToLongTimeString)
        strb.Append(" Log started for user ")
        strb.AppendLine(GlobalVariables.Employee.UserName)
        strb.AppendLine()

        Return strb.ToString

    End Function

    Private Sub WriteApplicationLogToFile()

        GlobalVariables.ApplicationLog.AppendLine("---------------------------------------------------------------------------------------------------")
        Dim swApplicationLog As StreamWriter = New StreamWriter(GlobalVariables.LogFullName, True)
        swApplicationLog.WriteLine(GlobalVariables.ApplicationLog.ToString())
        swApplicationLog.Close()

    End Sub

#End Region '----- close -----

#Region "----- reports -----"
    '

#End Region '----- reports -----

#Region "----- Programmer -----"

    Private Sub WhosLoggedOnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhosLoggedOnToolStripMenuItem.Click
        Dim frm As New WhoIsLoggedInForm
        frm.ShowDialog()
    End Sub

    Private Sub ExportFacilityDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportFacilityDataToolStripMenuItem.Click
        'MessageBox.Show("/// UNDER CONSTRUCTION \\\", "Export Facility Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Dim frm As New ExportFacilityDataForm
        frm.ShowDialog()
    End Sub

    Private Sub ExportPointDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportPointDataToolStripMenuItem.Click
        'MessageBox.Show("/// UNDER CONSTRUCTION \\\", "Export Point Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Dim frm As New ExportPointDataForm(CShort(Me.EmissionYearComboBox.SelectedValue))
        frm.ShowDialog()
    End Sub

#End Region '----- Programmer -----

#Region "----- Plant user control and event variables -----"

    Private WithEvents m_plantUserControl As New PlantUserControl

    Private Sub ClearPlantObjects()

        With Me.EmissionsDataSet
            .Plant.Clear()

            .PlantYear.Clear()
            .PlantYearHistory.Clear()
        End With

        If (Not Me.m_plantUserControl.EmissionsDataSet.rptPlantEmissions Is Nothing) Then
            Me.m_plantUserControl.EmissionsDataSet.rptPlantEmissions.Clear()
        End If

        If (Not Me.m_plantUserControl.EmissionsDataSet.rptPlantEmissionsSummaryV2 Is Nothing) Then
            Me.m_plantUserControl.EmissionsDataSet.rptPlantEmissionsSummaryV2.Clear()
        End If

        Me.m_emissionUnit = Nothing
        Me.m_emissionUnitYear = Nothing

    End Sub

    Private Sub LoadPlantUserControl()

        If (Me.TreeViewMain.SelectedNode.Level = 0) Then
            Call Me.LoadPlantObject(CInt(Me.TreeViewMain.SelectedNode.Name))
        ElseIf (Me.TreeViewMain.SelectedNode.Level = 1) Then
            Call Me.LoadPlantObject(CInt(Me.TreeViewMain.SelectedNode.Parent.Name))
        ElseIf (Me.TreeViewMain.SelectedNode.Level = 2) Then
            Call Me.LoadPlantObject(CInt(Me.TreeViewMain.SelectedNode.Parent.Parent.Name))
        End If

        Call Me.LoadPlantYearObject()

        With Me.m_plantUserControl
            .ControlIsLoaded = False
            .LoadObjectVariables(Me.m_emissionYear, Me.m_plant, Me.m_plantYear, Me.m_enumButtonMode)
            .LoadControls()
            .ControlIsLoaded = True
        End With
        Call Me.ToggleUserControlVisibility("PlantUserControl")

        My.Application.DoEvents()

    End Sub

#End Region '----- Plant user control and event variables -----

#Region "----- Emission unit user control and event variables -----"

    Private WithEvents m_emissionUnitUserControl As New EmissionUnitUserControl()

    Private m_emissionUnit As EmissionsDataSet.PlantEmissionUnitRow
    Private m_emissionUnitYear As EmissionsDataSet.PlantEmissionUnitYearRow

    Private Sub ClearEmissionUnitObjects()

        With Me.EmissionsDataSet
            .PlantEmissionUnit.Clear()
            .PlantEmissionUnitHistory.Clear()

            .PlantEmissionUnitYear.Clear()
            .PlantEmissionUnitYearHistory.Clear()
        End With

        Me.m_emissionUnit = Nothing
        Me.m_emissionUnitYear = Nothing

    End Sub

    Private Sub LoadEmissionUnitUserControl()

        Call Me.LoadPlantObject(CInt(Me.TreeViewMain.SelectedNode.Parent.Name))

        'set the EU object
        Me.PlantEmissionUnitTableAdapter.FillByPlantEmissionUnitID(Me.EmissionsDataSet.PlantEmissionUnit, CInt(Me.TreeViewMain.SelectedNode.Name))
        Me.m_emissionUnit = CType(Me.EmissionsDataSet.PlantEmissionUnit.Rows(0), EmissionsInventory.EmissionsDataSet.PlantEmissionUnitRow)

        'set the EU year object
        Me.PlantEmissionUnitYearTableAdapter.FillByPlantEmissionUnitID_EmissionYear(Me.EmissionsDataSet.PlantEmissionUnitYear, Me.m_emissionUnit.PlantEmissionUnitID, Me.m_emissionYear.EmissionYear)
        Me.m_emissionUnitYear = CType(Me.EmissionsDataSet.PlantEmissionUnitYear.Rows(0), EmissionsInventory.EmissionsDataSet.PlantEmissionUnitYearRow)

        'if all the processes for this is approved then it's ok to approve, otherwise not
        Dim okToApprove As Boolean
        If (Me.IsOkToApprove(Me.m_emissionUnit)) Then
            okToApprove = True
        Else
            okToApprove = False
        End If

        'if all the processes are shut down, then ok to shut down, otherwise not
        Dim okToShutdown As Boolean = Me.IsOkToShutdown(Me.m_emissionUnit)

        With Me.m_emissionUnitUserControl
            .controlIsLoaded = False
            Call .LoadObjectVariables(Me.m_emissionYear, Me.m_emissionUnit, Me.m_emissionUnitYear, okToApprove, okToShutdown)
            Call .LoadControls()
            Call .SetInventoryStatus()
            Call .SetControlStatus()
            .controlIsLoaded = True
        End With

        Call Me.LoadPlantYearObject()

        Call ToggleUserControlVisibility("EmissionUnitUserControl")

    End Sub

    Private Function IsOkToApprove(ByVal emissionUnit As EmissionsDataSet.PlantEmissionUnitRow) As Boolean

        Dim ok As Boolean = True

        Dim filter As String = EmissionsDataSet.Process.PlantEmissionUnitIDColumn.ColumnName _
                               & Tools.Constants.Character.EqualSign _
                               & CStr(emissionUnit.PlantEmissionUnitID)

        Dim processesForThisEU() As DataRow = MainForm.NavigationTable.Process.Select(filter)
        For Each row As DataRow In processesForThisEU
            Try
                Dim aDate As Date = CDate(row(EmissionsDataSet.ProcessYear.ApprovalDateColumn.ColumnName))
            Catch ex As Exception
                ok = False
                Exit For
            End Try
        Next

        Return ok

    End Function

    Private Function IsOkToShutdown(ByVal emissionUnit As EmissionsDataSet.PlantEmissionUnitRow) As Boolean

        Dim ok As Boolean = True

        Dim filteredView As DataView = MainForm.NavigationTable.Process.DefaultView
        Dim filter As String = EmissionsDataSet.Process.PlantEmissionUnitIDColumn.ColumnName _
                               & Tools.Constants.Character.EqualSign _
                               & CStr(emissionUnit.PlantEmissionUnitID) _
                               & " AND EndDate IS NULL"

        filteredView.RowFilter = filter
        If (filteredView.Count = 0) Then
            ok = True
        Else
            ok = False
        End If

        Return ok

    End Function

    Private Sub PlantEmissionUnit_Save(ByVal state As GlobalVariables.InventoryStatus) Handles m_emissionUnitUserControl.SaveButton_Pressed

        Select Case state
            Case GlobalVariables.InventoryStatus.Modified
                If (Me.m_emissionUnit.EmissionUnitAPCDID <> CType(Me.EmissionsDataSet.PlantEmissionUnitHistory.Rows(0), EmissionsDataSet.PlantEmissionUnitHistoryRow).EmissionUnitAPCDID) Then
                    Dim rows() As DataRow = NavigationTable.EmissionUnit.Select("PlantEmissionUnitID=" & Me.m_emissionUnit.PlantEmissionUnitID)
                    rows(0)(Me.EmissionsDataSet.PlantEmissionUnit.EmissionUnitAPCDIDColumn.ColumnName) = Me.m_emissionUnit.EmissionUnitAPCDID
                    Me.TreeViewMain.SelectedNode.Text = Me.m_emissionUnit.EmissionUnitAPCDID
                    Me.TreeViewMain.Sort()
                    Me.TreeViewMain.SelectedNode = Me.m_selectedNode
                End If

            Case GlobalVariables.InventoryStatus.Deleted
                Dim rows() As DataRow = NavigationTable.EmissionUnit.Select("PlantEmissionUnitID=" & Me.m_selectedNode.Name)
                rows(0).Delete()
                Me.TreeViewMain.SelectedNode.Remove()
                Me.TreeViewMain.SelectedNode = Me.m_selectedNode.Parent
                Me.m_selectedNode = Me.TreeViewMain.SelectedNode

            Case GlobalVariables.InventoryStatus.Shutdown
                Dim rows() As DataRow = NavigationTable.EmissionUnit.Select("PlantEmissionUnitID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.PlantEmissionUnit.EndDateColumn.ColumnName) = Me.m_emissionUnit.EndDate
                Me.TreeViewMain.SelectedNode.BackColor = Color.LightGray

            Case GlobalVariables.InventoryStatus.Approved
                Dim rows() As DataRow = NavigationTable.EmissionUnit.Select("PlantEmissionUnitID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.PlantEmissionUnitYear.ApprovalDateColumn.ColumnName) = Me.m_emissionUnitYear.ApprovalDate
                rows(0)(Me.EmissionsDataSet.PlantEmissionUnitYear.ApprovalEmployeeIDColumn.ColumnName) = Me.m_emissionUnitYear.ApprovalEmployeeID
                Me.TreeViewMain.SelectedNode.ForeColor = Nothing
                Call Me.ApprovePlant(Me.m_selectedNode.Parent.Name)

            Case GlobalVariables.InventoryStatus.UnApproved
                Dim rows() As DataRow = NavigationTable.EmissionUnit.Select("PlantEmissionUnitID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.PlantEmissionUnitYear.ApprovalDateColumn.ColumnName) = DBNull.Value
                rows(0)(Me.EmissionsDataSet.PlantEmissionUnitYear.ApprovalEmployeeIDColumn.ColumnName) = DBNull.Value
                Me.TreeViewMain.SelectedNode.ForeColor = Color.Red
                Call Me.UnApprovePlant(Me.m_selectedNode.Parent.Name)
        End Select

    End Sub

    Private Sub PlantEmissionUnit_Canceled() Handles m_emissionUnitUserControl.CancelButton_Pressed

        Call Me.ToggleUserControlVisibility(String.Empty)
        Call Me.SelectMainParentNode()

    End Sub

    Private Sub SelectMainParentNode()

        Select Case Me.m_selectedNode.Level
            Case 1
                Me.TreeViewMain.SelectedNode = Me.TreeViewMain.Nodes(Me.m_selectedNode.Parent.Name)
            Case 2
                Me.TreeViewMain.SelectedNode = Me.TreeViewMain.Nodes(Me.m_selectedNode.Parent.Parent.Name)
        End Select
        Me.m_selectedNode = Me.TreeViewMain.SelectedNode

    End Sub

#End Region '----- Emission unit user control and event variables -----

#Region "----- process user control and event variables -----"

    Private WithEvents m_processUserControl As New ProcessUserControl()

    Private m_process As EmissionsDataSet.ProcessRow
    Private m_processYear As EmissionsDataSet.ProcessYearRow


    Private Sub ClearProcessObjects()

        With Me.EmissionsDataSet
            .Process.Clear()
            .ProcessHistory.Clear()

            .ProcessYear.Clear()
            .ProcessYearHistory.Clear()

            .ProcessControlMeasure.Clear()
            .ProcessControlMeasureHistory.Clear()
        End With

        Me.m_process = Nothing
        Me.m_processYear = Nothing

    End Sub

    Private Sub LoadProcessUserControl()

        Call Me.LoadPlantObject(CInt(Me.TreeViewMain.SelectedNode.Parent.Parent.Name))

        'set the ProcessID then the Process object
        Dim processID As Int32 = CInt(Me.TreeViewMain.SelectedNode.Name)
        Me.ProcessTableAdapter.FillByProcessID(Me.EmissionsDataSet.Process, processID)
        Me.m_process = CType(Me.EmissionsDataSet.Process.Rows(0), EmissionsInventory.EmissionsDataSet.ProcessRow)

        'set the Process year object
        Me.ProcessYearTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.ProcessYear, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
        Me.m_processYear = CType(Me.EmissionsDataSet.ProcessYear.Rows(0), EmissionsInventory.EmissionsDataSet.ProcessYearRow)

        'get the process release points
        Me.ProcessReleasePointTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.ProcessReleasePoint, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
        Me.Process_ReleasePointTabTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.Process_ReleasePointTab, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)

        'get the process control measures 
        Me.ProcessControlMeasureTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.ProcessControlMeasure, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
        Me.Process_ControlMeasureTabTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.Process_ControlMeasureTab, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)

        'get the process emissions
        Me.ProcessEmissionTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.ProcessEmission, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
        Me.Process_EmissionsTabTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.Process_EmissionsTab, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)

        'get the process throughput and seasonal
        Me.Process_ThroughputTabTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.Process_ThroughputTab, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
        Me.ProcessDetailPeriodTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.ProcessDetailPeriod, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
        Me.ProcessSeasonalActivityTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.ProcessSeasonalActivity, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)

        With Me.m_processUserControl
            .controlIsLoaded = False
            Call .LoadObjectVariables(Me.m_plant, Me.m_emissionYear, Me.m_process, Me.m_processYear)
            Call .LoadControls()
            Call .SetInventoryStatus()
            Call .SetControlStatus()
            .controlIsLoaded = True
        End With

        Call ToggleUserControlVisibility("ProcessUserControl")

    End Sub

    Private Sub Process_Save(ByVal state As GlobalVariables.InventoryStatus) Handles m_processUserControl.SaveButton_Pressed

        Select Case state
            Case GlobalVariables.InventoryStatus.Modified
                If (Me.m_process.ProcessAPCDID <> CType(Me.EmissionsDataSet.ProcessHistory.Rows(0), EmissionsDataSet.ProcessHistoryRow).ProcessAPCDID) Then
                    Dim rows() As DataRow = NavigationTable.Process.Select("ProcessID=" & Me.m_process.ProcessID)
                    rows(0)(Me.EmissionsDataSet.Process.ProcessAPCDIDColumn.ColumnName) = Me.m_process.ProcessAPCDID
                    Me.TreeViewMain.SelectedNode.Text = Me.m_process.ProcessAPCDID
                    Me.TreeViewMain.Sort()
                    Me.TreeViewMain.SelectedNode = Me.m_selectedNode
                End If

            Case GlobalVariables.InventoryStatus.Deleted
                Dim rows() As DataRow = NavigationTable.Process.Select("ProcessID=" & Me.m_selectedNode.Name)
                rows(0).Delete()
                Me.TreeViewMain.SelectedNode.Remove()

            Case GlobalVariables.InventoryStatus.Shutdown
                Dim rows() As DataRow = NavigationTable.Process.Select("ProcessID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.Process.EndDateColumn.ColumnName) = Me.m_process.EndDate
                Me.TreeViewMain.SelectedNode.BackColor = Color.LightGray

            Case GlobalVariables.InventoryStatus.Approved
                Dim rows() As DataRow = NavigationTable.Process.Select("ProcessID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.ProcessYear.ApprovalDateColumn.ColumnName) = Me.m_processYear.ApprovalDate
                rows(0)(Me.EmissionsDataSet.ProcessYear.ApprovalEmployeeIDColumn.ColumnName) = Me.m_processYear.ApprovalEmployeeID
                Me.TreeViewMain.SelectedNode.ForeColor = Nothing

            Case GlobalVariables.InventoryStatus.UnApproved
                Dim rows() As DataRow = NavigationTable.Process.Select("ProcessID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.ProcessYear.ApprovalDateColumn.ColumnName) = DBNull.Value
                rows(0)(Me.EmissionsDataSet.ProcessYear.ApprovalEmployeeIDColumn.ColumnName) = DBNull.Value
                Me.TreeViewMain.SelectedNode.ForeColor = Color.Red
        End Select

    End Sub

    Private Sub Process_Canceled() Handles m_processUserControl.CancelButton_Pressed

        Call Me.ToggleUserControlVisibility(String.Empty)
        Call Me.SelectMainParentNode()

    End Sub

#End Region '----- process user control and event variables -----

#Region "----- control measure user control and event variables -----"

    Private WithEvents m_controlMeasureUserControl As New ControlMeasureUserControl()

    Private m_controlMeasure As EmissionsDataSet.ControlMeasureRow
    Private m_controlMeasureYear As EmissionsDataSet.ControlMeasureYearRow

    Private Sub ClearControlMeasureObjects()

        With Me.EmissionsDataSet
            .ControlMeasure.Clear()
            .ControlMeasureHistory.Clear()

            .ControlMeasureYear.Clear()
            .ControlMeasureYearHistory.Clear()

            .ControlMeasurePollutant.Clear()
            .ControlMeasurePollutantHistory.Clear()
        End With

        Me.m_controlMeasure = Nothing
        Me.m_controlMeasureYear = Nothing

    End Sub

    Private Sub LoadControlMeasureUserControl()

        Call Me.LoadPlantObject(CInt(Me.TreeViewMain.SelectedNode.Parent.Name))

        'set the ID then the object
        Dim controlMeasureID As Int32 = CInt(Me.TreeViewMain.SelectedNode.Name)
        Me.ControlMeasureTableAdapter.FillByControlMeasureID(Me.EmissionsDataSet.ControlMeasure, controlMeasureID)
        Me.m_controlMeasure = CType(Me.EmissionsDataSet.ControlMeasure.Rows(0), EmissionsInventory.EmissionsDataSet.ControlMeasureRow)

        'set the year object
        Me.ControlMeasureYearTableAdapter.FillByControlMeasureID_EmissionYear(Me.EmissionsDataSet.ControlMeasureYear, Me.m_controlMeasure.ControlMeasureID, Me.m_emissionYear.EmissionYear)
        Me.m_controlMeasureYear = CType(Me.EmissionsDataSet.ControlMeasureYear.Rows(0), EmissionsInventory.EmissionsDataSet.ControlMeasureYearRow)

        'set the pollutants
        Me.ControlMeasurePollutantTableAdapter.FillByControlMeasureID_EmissionYear(Me.EmissionsDataSet.ControlMeasurePollutant, Me.m_controlMeasure.ControlMeasureID, Me.m_emissionYear.EmissionYear)

        With Me.m_controlMeasureUserControl
            .controlIsLoaded = False
            Call .LoadObjectVariables(Me.m_emissionYear, Me.m_controlMeasure, Me.m_controlMeasureYear)
            Call .LoadControls()
            Call .SetInventoryStatus()
            Call .SetControlStatus()
            .controlIsLoaded = True
        End With
        Call Me.LoadPlantYearObject()

        Call ToggleUserControlVisibility("ControlMeasureUserControl")

    End Sub

    Private Sub ControlMeasure_Save(ByVal state As GlobalVariables.InventoryStatus) Handles m_controlMeasureUserControl.SaveButton_Pressed

        Select Case state
            Case GlobalVariables.InventoryStatus.Modified
                Dim rows() As DataRow = NavigationTable.ControlMeasure.Select("ControlMeasureID=" & Me.m_controlMeasure.ControlMeasureID)
                rows(0)(Me.EmissionsDataSet.ControlMeasureYear.IsExcludedColumn.ColumnName) = Me.m_controlMeasureYear.IsExcluded
                If (Me.m_controlMeasure.ControlMeasureAPCDID <> CType(Me.EmissionsDataSet.ControlMeasureHistory.Rows(0), EmissionsDataSet.ControlMeasureHistoryRow).ControlMeasureAPCDID) Then
                    rows(0)(Me.EmissionsDataSet.ControlMeasure.ControlMeasureAPCDIDColumn.ColumnName) = Me.m_controlMeasure.ControlMeasureAPCDID
                    Me.TreeViewMain.SelectedNode.Text = Me.m_controlMeasure.ControlMeasureAPCDID
                    Me.TreeViewMain.Sort()
                    Me.TreeViewMain.SelectedNode = Me.m_selectedNode
                End If

            Case GlobalVariables.InventoryStatus.Deleted
                Dim rows() As DataRow = NavigationTable.ControlMeasure.Select("ControlMeasureID=" & Me.m_selectedNode.Name)
                rows(0).Delete()
                Me.TreeViewMain.SelectedNode.Remove()
                Me.TreeViewMain.SelectedNode = Me.m_selectedNode.Parent
                Me.m_selectedNode = Me.TreeViewMain.SelectedNode

            Case GlobalVariables.InventoryStatus.Shutdown
                Dim rows() As DataRow = NavigationTable.ControlMeasure.Select("ControlMeasureID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.ControlMeasure.EndDateColumn.ColumnName) = Me.m_controlMeasure.EndDate
                Me.TreeViewMain.SelectedNode.BackColor = Color.LightGray

            Case GlobalVariables.InventoryStatus.Approved
                Dim rows() As DataRow = NavigationTable.ControlMeasure.Select("ControlMeasureID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.ControlMeasureYear.ApprovalDateColumn.ColumnName) = Me.m_controlMeasureYear.ApprovalDate
                rows(0)(Me.EmissionsDataSet.ControlMeasureYear.ApprovalEmployeeIDColumn.ColumnName) = Me.m_controlMeasureYear.ApprovalEmployeeID
                Me.TreeViewMain.SelectedNode.ForeColor = Nothing


            Case GlobalVariables.InventoryStatus.UnApproved
                Dim rows() As DataRow = NavigationTable.ControlMeasure.Select("ControlMeasureID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.ControlMeasureYear.ApprovalDateColumn.ColumnName) = DBNull.Value
                rows(0)(Me.EmissionsDataSet.ControlMeasureYear.ApprovalEmployeeIDColumn.ColumnName) = DBNull.Value
                Me.TreeViewMain.SelectedNode.ForeColor = Color.Red
        End Select

    End Sub

    Private Sub ControlMeasure_Canceled() Handles m_controlMeasureUserControl.CancelButton_Pressed

        Call Me.ToggleUserControlVisibility(String.Empty)
        Call Me.SelectMainParentNode()

    End Sub

#End Region '----- control measure user control and event variables -----

#Region "----- release point user control and event variables -----"

    Private WithEvents m_releasePointUserControl As New ReleasePointUserControl()

    Private m_releasePoint As EmissionsDataSet.ReleasePointRow
    Private m_releasePointYear As EmissionsDataSet.ReleasePointYearRow

    Private Sub ClearReleasePointObjects()

        With Me.EmissionsDataSet
            .ReleasePoint.Clear()
            .ReleasePointHistory.Clear()

            .ReleasePointYear.Clear()
            .ReleasePointYearHistory.Clear()

            .ReleasePointDetail.Clear()
            .ReleasePointDetailHistory.Clear()
        End With

        Me.m_releasePoint = Nothing
        Me.m_releasePointYear = Nothing

    End Sub

    Private Sub LoadReleasePointUserControl()

        Call Me.LoadPlantObject(CInt(Me.TreeViewMain.SelectedNode.Parent.Name))

        'set the ID then the object
        Dim releasePointID As Int32 = CInt(Me.TreeViewMain.SelectedNode.Name)
        Me.ReleasePointTableAdapter.FillByReleasePointID(Me.EmissionsDataSet.ReleasePoint, releasePointID)
        Me.m_releasePoint = CType(Me.EmissionsDataSet.ReleasePoint.Rows(0), EmissionsInventory.EmissionsDataSet.ReleasePointRow)

        'set the year object
        Me.ReleasePointYearTableAdapter.FillByReleasePointID_EmissionYear(Me.EmissionsDataSet.ReleasePointYear, Me.m_releasePoint.ReleasePointID, Me.m_emissionYear.EmissionYear)
        Me.m_releasePointYear = CType(Me.EmissionsDataSet.ReleasePointYear.Rows(0), EmissionsInventory.EmissionsDataSet.ReleasePointYearRow)

        'set the measurements
        Me.ReleasePointDetailTableAdapter.FillByReleasePointID(Me.EmissionsDataSet.ReleasePointDetail, Me.m_releasePoint.ReleasePointID)

        With Me.m_releasePointUserControl
            .controlIsLoaded = False
            Call .LoadObjectVariables(Me.m_emissionYear, Me.m_releasePoint, Me.m_releasePointYear)
            Call .LoadControls()
            Call .SetInventoryStatus()
            Call .SetControlStatus()
            .controlIsLoaded = True
        End With

        Call Me.LoadPlantYearObject()

        Call ToggleUserControlVisibility("ReleasePointUserControl")

    End Sub

    Private Sub ReleasePoint_Save(ByVal state As GlobalVariables.InventoryStatus) Handles m_releasePointUserControl.SaveButton_Pressed

        Select Case state
            Case GlobalVariables.InventoryStatus.Modified
                Dim rows() As DataRow = NavigationTable.ReleasePoint.Select("ReleasePointID=" & Me.m_releasePoint.ReleasePointID)
                rows(0)(Me.EmissionsDataSet.ReleasePointYear.IsExcludedColumn.ColumnName) = Me.m_releasePointYear.IsExcluded
                If (Me.m_releasePoint.ReleasePointAPCDID <> CType(Me.EmissionsDataSet.ReleasePointHistory.Rows(0), EmissionsDataSet.ReleasePointHistoryRow).ReleasePointAPCDID) Then
                    rows(0)(Me.EmissionsDataSet.ReleasePoint.ReleasePointAPCDIDColumn.ColumnName) = Me.m_releasePoint.ReleasePointAPCDID
                    Me.TreeViewMain.SelectedNode.Text = Me.m_releasePoint.ReleasePointAPCDID
                    Me.TreeViewMain.Sort()
                    Me.TreeViewMain.SelectedNode = Me.m_selectedNode
                End If

            Case GlobalVariables.InventoryStatus.Deleted
                Dim rows() As DataRow = NavigationTable.ReleasePoint.Select("ReleasePointID=" & Me.m_selectedNode.Name)
                rows(0).Delete()
                Me.TreeViewMain.SelectedNode.Remove()
                Me.TreeViewMain.SelectedNode = Me.m_selectedNode.Parent
                Me.m_selectedNode = Me.TreeViewMain.SelectedNode

            Case GlobalVariables.InventoryStatus.Shutdown
                Dim rows() As DataRow = NavigationTable.ReleasePoint.Select("ReleasePointID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.ReleasePoint.EndDateColumn.ColumnName) = Me.m_releasePoint.EndDate
                Me.TreeViewMain.SelectedNode.BackColor = Color.LightGray

            Case GlobalVariables.InventoryStatus.Approved
                Dim rows() As DataRow = NavigationTable.ReleasePoint.Select("ReleasePointID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.ReleasePointYear.ApprovalDateColumn.ColumnName) = Me.m_releasePointYear.ApprovalDate
                rows(0)(Me.EmissionsDataSet.ReleasePointYear.ApprovalEmployeeIDColumn.ColumnName) = Me.m_releasePointYear.ApprovalEmployeeID
                Me.TreeViewMain.SelectedNode.ForeColor = Nothing

            Case GlobalVariables.InventoryStatus.UnApproved
                Dim rows() As DataRow = NavigationTable.ReleasePoint.Select("ReleasePointID=" & Me.m_selectedNode.Name)
                rows(0)(Me.EmissionsDataSet.ReleasePointYear.ApprovalDateColumn.ColumnName) = DBNull.Value
                rows(0)(Me.EmissionsDataSet.ReleasePointYear.ApprovalEmployeeIDColumn.ColumnName) = DBNull.Value
                Me.TreeViewMain.SelectedNode.ForeColor = Color.Red

        End Select

    End Sub

    Private Sub ReleasePoint_Canceled() Handles m_releasePointUserControl.CancelButton_Pressed

        Call Me.ToggleUserControlVisibility(String.Empty)
        Call Me.SelectMainParentNode()

    End Sub

#End Region '----- release point user control and event variables -----

    Private Sub SelectNewlyAddedNode(ByVal nodeName As String, ByVal nodeColor As Color)
        For Each node As TreeNode In Me.TreeViewMain.Nodes(Me.m_selectedNode.Name).Nodes
            If (node.Name = nodeName) Then
                node.ForeColor = nodeColor
                Me.TreeViewMain.SelectedNode = node
                Me.TreeViewMain.SelectedNode.Expand()
                Exit For
            End If
        Next
        Me.m_selectedNode = Me.TreeViewMain.SelectedNode
        Call Me.CreateDynamicMenu()
        Me.m_intLastNodeLevel = Me.TreeViewMain.SelectedNode.Level
        Me.TreeViewMain.Focus()

    End Sub

    Private Sub LoadPlantObject(ByVal plantID As Int32)
        Me.PlantTableAdapter.FillByPlantID(Me.EmissionsDataSet.Plant, plantID)
        Me.m_plant = CType(Me.EmissionsDataSet.Plant.Rows(0), EmissionsInventory.EmissionsDataSet.PlantRow)
    End Sub

    Private Sub LoadPlantYearObject()
        Me.PlantYearTableAdapter.FillByPlantID_EmissionYear(Me.EmissionsDataSet.PlantYear, Me.m_plant.PlantID, Me.m_emissionYear.EmissionYear)
        Me.m_plantYear = CType(Me.EmissionsDataSet.PlantYear.Rows(0), EmissionsInventory.EmissionsDataSet.PlantYearRow)
    End Sub

#Region "----- Plant approve/unapprove -----"

    Private Sub ApprovePlant(ByVal plantID As String)

        If ((Me.AllEmissionUnitsAreApproved(plantID)) AndAlso (Me.AllReleasePointsAreApproved(plantID)) AndAlso (Me.AllControlMeasuresAreApproved(plantID))) Then
            Call Me.LoadHistoryRecord_PlantYear()

            With Me.m_plantYear
                .ApprovalEmployeeID = GlobalVariables.Employee.EmployeeID
                .ApprovalDate = Date.Now
                .ApprovalComment = GlobalVariables.Words.SystemApproved
            End With
            If (Me.Save) Then
                Call Me.TogglePlantTreeColor(plantID, GlobalVariables.InventoryStatus.Approved)
            End If
        End If

    End Sub

    Private Sub UnApprovePlant(ByVal plantID As String)

        If (Not Me.m_plantYear.IsApprovalDateNull) Then
            Call Me.LoadHistoryRecord_PlantYear()
            With Me.m_plantYear
                .SetApprovalEmployeeIDNull()
                .SetApprovalDateNull()
                .SetApprovalCommentNull()
            End With
            If (Me.Save) Then
                Call Me.TogglePlantTreeColor(plantID, GlobalVariables.InventoryStatus.UnApproved)
            End If
        End If

    End Sub

    Private Function AllEmissionUnitsAreApproved(ByVal plantID As String) As Boolean

        Dim selectString As String = "PlantID=" & plantID.ToString & "AND ApprovalDate IS NULL"
        Dim rows() As DataRow = MainForm.NavigationTable.EmissionUnit.Select(selectString)
        Return Not CBool(rows.Length)

    End Function

    Private Function AllReleasePointsAreApproved(ByVal plantID As String) As Boolean

        Dim selectString As String = "PlantID=" & plantID.ToString & "AND ApprovalDate IS NULL"
        Dim rows() As DataRow = MainForm.NavigationTable.ReleasePoint.Select(selectString)
        Return Not CBool(rows.Length)

    End Function

    Private Function AllControlMeasuresAreApproved(ByVal plantID As String) As Boolean

        Dim selectString As String = "PlantID=" & plantID.ToString & "AND ApprovalDate IS NULL"
        Dim rows() As DataRow = MainForm.NavigationTable.ControlMeasure.Select(selectString)
        Return Not CBool(rows.Length)

    End Function

    Private Sub LoadHistoryRecord_PlantYear()

        Dim row As EmissionsDataSet.PlantYearHistoryRow = Me.EmissionsDataSet.PlantYearHistory.NewPlantYearHistoryRow
        With row
            .PlantYearID = Me.m_plantYear.PlantYearID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .PlantID = Me.m_plantYear.PlantID
            .EmissionYear = Me.m_plantYear.EmissionYear

            .FacilityCategoryEISID = Me.m_plantYear.FacilityCategoryEISID
            .FacilitySiteStatusTypeEISID = Me.m_plantYear.FacilitySiteStatusTypeEISID
            .AffiliationTypeEISID = Me.m_plantYear.AffiliationTypeEISID

            .IsExcluded = Me.m_plantYear.IsExcluded

            If (Me.m_plantYear.IsDoneDateNull) Then
                .SetDoneDateNull()
            Else
                .DoneDate = Me.m_plantYear.DoneDate
            End If

            If (Me.m_plantYear.IsDoneByNull) Then
                .SetDoneByNull()
            Else
                .DoneBy = Me.m_plantYear.DoneBy
            End If

            If (Me.m_plantYear.IsApprovalEmployeeIDNull) Then
                .SetApprovalEmployeeIDNull()
            Else
                .ApprovalEmployeeID = Me.m_plantYear.ApprovalEmployeeID
            End If

            If (Me.m_plantYear.IsApprovalDateNull) Then
                .SetApprovalDateNull()
            Else
                .ApprovalDate = Me.m_plantYear.ApprovalDate
            End If

            .ApprovalComment = Me.m_plantYear.ApprovalComment


        End With
        Me.EmissionsDataSet.PlantYearHistory.Rows.Add(row)

    End Sub

    Private Sub TogglePlantTreeColor(ByVal plantID As String, ByVal status As GlobalVariables.InventoryStatus)

        Dim rows() As DataRow = NavigationTable.Plant.Select("PlantID=" & plantID)
        Select Case status
            Case GlobalVariables.InventoryStatus.Approved
                rows(0)(Me.EmissionsDataSet.PlantYear.ApprovalDateColumn.ColumnName) = Me.m_plantYear.ApprovalDate
                rows(0)(Me.EmissionsDataSet.ReleasePointYear.ApprovalEmployeeIDColumn.ColumnName) = Me.m_plantYear.ApprovalEmployeeID
                Me.TreeViewMain.SelectedNode.Parent.ForeColor = Nothing
            Case GlobalVariables.InventoryStatus.UnApproved
                rows(0)(Me.EmissionsDataSet.PlantYear.ApprovalDateColumn.ColumnName) = DBNull.Value
                rows(0)(Me.EmissionsDataSet.ReleasePointYear.ApprovalEmployeeIDColumn.ColumnName) = DBNull.Value
                Me.TreeViewMain.SelectedNode.Parent.ForeColor = Color.Red
        End Select

    End Sub

#End Region '----- Plant approve/unapprove -----

    Private Function Save() As Boolean

        Me.Validate()
        Me.PlantYearBindingSource.EndEdit()
        Me.PlantYearHistoryBindingSource.EndEdit()

        Try
            ''Me.TableAdapterManager.UpdateAll(Me.EmissionsDataSet)
            Me.PlantYearTableAdapter.Update(Me.EmissionsDataSet.PlantYear)
            Save = True
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Save = False
        End Try

    End Function

#Region "----- toolstrip menu events -----"

    Private Sub CheckPollutantUOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckPollutantUOMToolStripMenuItem.Click
        MessageBox.Show("UNDER CONSTRUCTION")
        'Dim frm As New PollutantUOMCheck(NavigationTable.Process)
        'frm.ShowDialog()
    End Sub

    Private Sub Import91TFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Import91TFormToolStripMenuItem.Click
        Dim frm As New ImportE91T(CShort(Me.EmissionYearComboBox.SelectedValue))
        Dim result As DialogResult = frm.ShowDialog()
        If (result = Windows.Forms.DialogResult.OK) Then
            NavigationTable.ReleasePoint = Utility.ReleasePointUtility.GetNavigationView(CShort(Me.EmissionYearComboBox.SelectedValue))
            If (Me.m_enumButtonMode = GlobalVariables.ButtonMode.ReleasePoints) Then
                Call Me.LoadTreeView()
                Me.WhereAmI = String.Empty
            End If
        End If
    End Sub

    Private Sub Import92TFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Import92TFormToolStripMenuItem.Click
        Dim frm As New ImportE92T(CShort(Me.EmissionYearComboBox.SelectedValue))
        Dim result As DialogResult = frm.ShowDialog()
        If (result = Windows.Forms.DialogResult.OK) Then
            NavigationTable.ControlMeasure = Utility.ControlMeasureUtility.GetNavigationView(CShort(Me.EmissionYearComboBox.SelectedValue))
            If (Me.m_enumButtonMode = GlobalVariables.ButtonMode.ControlMeasures) Then
                Call Me.LoadTreeView()
                Me.WhereAmI = String.Empty
            End If
        End If
    End Sub

    Private Sub GenerateInvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateInvoicesToolStripMenuItem.Click
        'MessageBox.Show("UNDER CONSTRUCTION")

        Dim frm As New GenerateBills(CShort(Me.EmissionYearComboBox.SelectedValue))
        frm.ShowDialog()

    End Sub

    Private Sub GenerateAnnaulNotificationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateAnnaulNotificationsToolStripMenuItem.Click
        'MessageBox.Show("UNDER CONSTRUCTION")

        Dim frm As New AnnualNotification(CShort(Me.EmissionYearComboBox.SelectedValue))
        frm.ShowDialog()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click

        Dim frm As New AboutForm
        frm.ShowDialog()

    End Sub

#Region "----- toolstrip menu events - Help -----"

    Private Sub SupportWebsiteMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupportWebsiteMenuItem.Click
        Dim frm As New SupportWebsite
        frm.Show()
    End Sub

#End Region '----- toolstrip menu events - Help -----

#End Region '----- toolstrip menu events -----

End Class