Imports APCD.Emissions

Public Class ProcessUserControl

    'counters
    Private m_changedValueCount As Int32 = 0

    'events
    Public Event SaveButton_Pressed(ByVal state As GlobalVariables.InventoryStatus)
    Public Event CancelButton_Pressed()

    'object variables
    Private m_plant As EmissionsInventory.EmissionsDataSet.PlantRow
    Private m_emissionYear As EmissionsDataSet.EmissionYearRow
    Private m_process As EmissionsDataSet.ProcessRow
    Private m_processYear As EmissionsDataSet.ProcessYearRow

    'status variables
    Private m_inventoryStatus As GlobalVariables.InventoryStatus

    'changed flags
    Private m_isExcluded_Changed As Boolean = False
    'Private m_isThroughputChanged As Boolean = False

#Region "----- Properties -----"

    Private m_controlIsLoaded As Boolean

    Public Property controlIsLoaded() As Boolean
        Get
            Return m_controlIsLoaded
        End Get
        Set(ByVal value As Boolean)
            m_controlIsLoaded = value
        End Set
    End Property

#End Region '----- Properties -----

    Private Sub ProcessUserControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.controlIsLoaded = False

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////
        'note PROCESSDATASET
        Me.PollutantTableAdapter.Fill(Me.ProcessDataSet.Pollutant)
        Me.EmissionPeriodTypeTableAdapter.Fill(Me.ProcessDataSet.EmissionPeriodType)
        Me.UnitOfMeasurement_ProcessEmissionTableAdapter.Fill(Me.ProcessDataSet.UnitOfMeasurement_ProcessEmission)
        '//////////////////////////////////////////////////////////////////////////////////////////////////////////

        Tools.WindowsForms.LoadComboBox(GlobalVariables.LookupTable.ThroughputType, Me.ThroughputTypeComboBox)
        Me.controlIsLoaded = True

    End Sub

    Friend Sub LoadObjectVariables(ByVal plant As EmissionsInventory.EmissionsDataSet.PlantRow, ByVal emissionYear As EmissionsDataSet.EmissionYearRow, ByVal process As EmissionsDataSet.ProcessRow, ByVal processYear As EmissionsDataSet.ProcessYearRow)

        Me.m_plant = plant

        Me.m_emissionYear = emissionYear
        Me.m_process = process
        Me.m_processYear = processYear

        Call Me.LoadHistoryRecord_Process()

        If MainForm.EmissionsDataSet.ProcessSeasonalActivity.Rows.Count = 1 Then
            Me.m_processSeasonalActivity = CType(MainForm.EmissionsDataSet.ProcessSeasonalActivity.Rows(0), EmissionsInventory.EmissionsDataSet.ProcessSeasonalActivityRow)
            Call ProcessHelper.LoadHistoryRecord_ProcessSeasonalActivity(Me.m_processSeasonalActivity)
        Else
            Call Me.CreateSeasonalActivityRow()
        End If

        Call Me.RefreshReleasePointPercentTotal()

        Me.m_changedValueCount = 0

    End Sub

    Friend Sub LoadControls()

        'set shut down label
        If (Me.m_process.IsEndDateNull) Then
            Me.ShutdownMessageLabel.Text = String.Empty
        Else
            Me.ShutdownMessageLabel.Text = "Shut down in " & Me.m_process.EndDate.Year
        End If

        Me.IsExcludedCheckBox.Checked = Me.m_processYear.IsExcluded

        'general
        With Me.m_process
            Me.lblSCCNumber.Text = .ProcessClassID
            Dim objProcessClass As Business.ProcessClass = Utility.ProcessClassUtility.GetByPrimaryKey(.ProcessClassID)
            Me.lblSCCName.Text = objProcessClass.ProcessClassName

            Me.ThroughputTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ThroughputTypeComboBox, .ThroughputTypeID)
            Me.ProcessAPCDIDTextBox.Text = .ProcessAPCDID
            Me.ProcessDescriptionTextBox.Text = .ProcessDescription
            Me.CommentPublicTextBox.Text = .CommentPublic
            Me.CommentInternalTextBox.Text = .CommentInternal
            Me.ControlApproachDescriptionTextBox.Text = .ControlApproachDescription
        End With

        'release point
        Me.Process_ReleasePointTabDataGridView.DataSource = MainForm.EmissionsDataSet.Process_ReleasePointTab

        'control measure
        Me.Process_ControlMeasureTabDataGridView.DataSource = MainForm.EmissionsDataSet.Process_ControlMeasureTab

        'throughput
        Me.Process_ThroughputTabDataGridView.DataSource = MainForm.EmissionsDataSet.Process_ThroughputTab
        Call Me.LoadSeasonalTextBoxes()
        Call Me.RefreshSeasonalTotal()

        'emissions
        Me.Process_EmissionsTabDataGridView.DataSource = MainForm.EmissionsDataSet.Process_EmissionsTab

        Me.TabControl1.SelectedTab = Me.TabControl1.TabPages(0)

    End Sub

#Region "----- status -----"

    Friend Sub SetInventoryStatus()

        If (GlobalVariables.UserRole = GlobalVariables.Role.Guest) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.None

        ElseIf (Not Me.m_emissionYear.IsEmissionsInEISDateNull) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.EmissionYearClosed

        ElseIf (Not Me.m_processYear.IsApprovalDateNull) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.Approved

        ElseIf (Not Me.m_process.IsEndDateNull) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.Shutdown

        Else
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.UnApproved
        End If

    End Sub

    Friend Sub SetControlStatus()

        Select Case Me.m_inventoryStatus
            Case GlobalVariables.InventoryStatus.None
                Call Me.DisableEditing()

            Case GlobalVariables.InventoryStatus.EmissionYearClosed
                Call Me.DisableEditing()

            Case GlobalVariables.InventoryStatus.Approved
                Call Me.DisableEditing()
                Me.ButtonPanel.Visible = True
                Call Me.ToggleButtonStatus(GlobalVariables.InventoryStatus.Approved)

            Case GlobalVariables.InventoryStatus.Shutdown
                Call Me.DisableEditing()
                Me.ButtonPanel.Visible = True
                Call Me.ToggleButtonStatus(GlobalVariables.InventoryStatus.Shutdown)

            Case GlobalVariables.InventoryStatus.UnApproved
                Call Me.EnableEditing()
                Call Me.ToggleButtonStatus(GlobalVariables.InventoryStatus.UnApproved)
        End Select

    End Sub

    Private Sub ToggleButtonStatus(ByVal status As GlobalVariables.InventoryStatus)

        '----- defaults -----
        'approve  text and enabled
        Me.btnApprove.Text = GlobalVariables.Words.Approve
        Call GlobalMethods.ToggleApprovalButtonEnabled(Me.btnApprove)

        'shutdown text and enabled
        Call Me.ToggleShutDownButtonText()
        Me.btnShutdown.Enabled = False

        'save enabled
        Me.btnSave.Enabled = False

        '----- change per status -----
        Select Case status
            Case GlobalVariables.InventoryStatus.Approved
                Me.btnApprove.Text = GlobalVariables.Words.Unapprove

            Case GlobalVariables.InventoryStatus.UnApproved
                Me.btnShutdown.Enabled = True
        End Select

    End Sub

    Private Sub ToggleButtonStatus_FieldChanged()

        If (Me.controlIsLoaded) Then
            Me.m_changedValueCount += 1
            Me.btnShutdown.Enabled = False
            Me.btnApprove.Enabled = False
            Me.btnSave.Enabled = True
        End If

    End Sub

    Private Sub ToggleShutDownButtonText()

        If (Me.m_process.AddDate.Year = Date.Now.Year) Then
            Me.btnShutdown.Text = GlobalVariables.Words.Delete
        Else
            Me.btnShutdown.Text = GlobalVariables.Words.Shutdown
        End If

    End Sub

    Private Sub DisableEditing()

        Me.IsExcludedCheckBox.Enabled = False
        Me.ButtonPanel.Visible = False

        'general
        Me.btnChangeProcessClass.Enabled = False
        Me.ThroughputTypeComboBox.Enabled = False
        Me.ProcessAPCDIDTextBox.ReadOnly = True
        Me.ProcessDescriptionTextBox.ReadOnly = True
        Me.CommentPublicTextBox.ReadOnly = True
        Me.CommentInternalTextBox.ReadOnly = True
        Me.ControlApproachDescriptionTextBox.ReadOnly = True

        'release point
        Me.btnAddReleasePoint.Enabled = False
        Me.Process_ReleasePointTabDataGridView.ReadOnly = True

        'control measure
        Me.btnAddControlMeasure.Enabled = False
        Me.Process_ControlMeasureTabDataGridView.ReadOnly = True

        'throughput
        Me.btnAddThroughput.Visible = False
        Me.btnLoadThroughputDefaults.Visible = False
        Me.WinterTextBox.ReadOnly = True
        Me.SpringTextBox.ReadOnly = True
        Me.SummerTextBox.ReadOnly = True
        Me.FallTextBox.ReadOnly = True
        Me.Process_ThroughputTabDataGridView.ReadOnly = True
        Me.btnLoadSeasonalDefaults.Visible = False

        'emissions
        Me.btnAddEmissions.Enabled = False
        Me.btnRecalculateFromThroughput.Enabled = False
        Me.btnCopyToProcess.Enabled = False
        Me.Process_EmissionsTabDataGridView.ReadOnly = True

    End Sub

    Private Sub EnableEditing()

        Me.IsExcludedCheckBox.Enabled = True
        Me.ButtonPanel.Visible = True

        'general
        Me.btnChangeProcessClass.Enabled = True
        Me.ThroughputTypeComboBox.Enabled = True

        Me.ProcessAPCDIDTextBox.ReadOnly = False
        Me.ProcessDescriptionTextBox.ReadOnly = False
        Me.CommentPublicTextBox.ReadOnly = False
        Me.CommentInternalTextBox.ReadOnly = False
        Me.ControlApproachDescriptionTextBox.ReadOnly = False

        'release point
        Me.btnAddReleasePoint.Enabled = True
        Me.Process_ReleasePointTabDataGridView.ReadOnly = False

        'control measure
        Me.btnAddControlMeasure.Enabled = True
        Me.Process_ControlMeasureTabDataGridView.ReadOnly = False

        'throughput
        Me.btnAddThroughput.Visible = True

        If (MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows.Count = 0) Then
            Me.btnLoadThroughputDefaults.Visible = True
        Else
            Me.btnLoadThroughputDefaults.Visible = False
        End If

        'seasonal
        Me.WinterTextBox.ReadOnly = False
        Me.SpringTextBox.ReadOnly = False
        Me.SummerTextBox.ReadOnly = False
        Me.FallTextBox.ReadOnly = False

        Me.Process_ThroughputTabDataGridView.ReadOnly = False

        'emissions
        Me.btnAddEmissions.Enabled = True
        Me.btnRecalculateFromThroughput.Enabled = True
        Me.btnCopyToProcess.Enabled = True
        Me.Process_EmissionsTabDataGridView.ReadOnly = False

    End Sub

#End Region '----- status -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        If (Not Me.IsValidProcessClass) Then
            IsValidForm = False

        ElseIf (Not Me.IsValidThroughputType) Then
            IsValidForm = False

        ElseIf (Not Me.IsValidAPCDID) Then
            IsValidForm = False
        Else
            IsValidForm = True
        End If

    End Function

    Private Function IsValidProcessClass() As Boolean

        Dim dataIsValid As Boolean

        If (Me.lblSCCNumber.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.lblSCCNumber, "A source classification code (SCC) is required.")
            Me.ErrorProvider1.SetIconAlignment(Me.lblSCCNumber, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.lblSCCNumber, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidThroughputType() As Boolean

        Dim dataIsValid As Boolean

        If (ThroughputTypeComboBox.SelectedIndex = -1) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.ThroughputTypeComboBox, "Please select a throughput type.")
            Me.ErrorProvider1.SetIconAlignment(Me.ThroughputTypeComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ThroughputTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidAPCDID() As Boolean

        Dim dataIsValid As Boolean

        If (ProcessAPCDIDTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(ProcessAPCDIDTextBox, "Please enter the APCD ID.")
            Me.ErrorProvider1.SetIconAlignment(ProcessAPCDIDTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ProcessAPCDIDTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

#End Region '----- Validation -----

#Region "----- General -----"

    Private Sub btnLookupProcessClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeProcessClass.Click

        Dim list As New ArrayList
        Dim frm As New SCCCodeSelectorForm(list)
        frm.ShowDialog()
        If (list.Count = 2) Then
            Me.lblSCCNumber.Text = CStr(list(0))
            Me.lblSCCName.Text = CStr(list(1))
            Me.m_process.ProcessClassID = Me.lblSCCNumber.Text
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

#Region "----- General - changed events -----"

    Private Sub IsExcludedCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsExcludedCheckBox.CheckedChanged
        If (controlIsLoaded) Then
            If (Me.m_processYear.RowState = DataRowState.Unchanged) Then
                Call Me.LoadHistoryRecord_ProcessYear()
            End If
            Me.m_processYear.IsExcluded = Me.IsExcludedCheckBox.Checked
            Call Me.ToggleButtonStatus_FieldChanged()
            Me.m_isExcluded_Changed = True
        End If
    End Sub

    Private Sub lblSCCNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSCCNumber.TextChanged

        If (Me.controlIsLoaded) Then
            Me.m_process.ProcessClassID = Me.lblSCCNumber.Text.Trim
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub ThroughputTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThroughputTypeComboBox.SelectedIndexChanged

        If (Me.controlIsLoaded) Then
            Me.m_process.ThroughputTypeID = CInt(Me.ThroughputTypeComboBox.SelectedValue)
            Call Me.DeleteAnnualAndOzoneSeasonDaily()
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub DeleteAnnualAndOzoneSeasonDaily()

        Dim deleted As Boolean = False

        For Each row As EmissionsDataSet.ProcessDetailPeriodRow In MainForm.EmissionsDataSet.ProcessDetailPeriod
            If ((row.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.AnnualThroughput) _
                OrElse (row.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.OzoneSeasonDailyThroughput)) Then
                row.Delete()
                deleted = True
            End If
        Next

        If (deleted) Then
            MainForm.ProcessDetailPeriodTableAdapter.Update(MainForm.EmissionsDataSet.ProcessDetailPeriod)
            MainForm.ProcessDetailPeriodTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.ProcessDetailPeriod, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
            MainForm.Process_ThroughputTabTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.Process_ThroughputTab, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
            Me.Process_ThroughputTabDataGridView.DataSource = MainForm.EmissionsDataSet.Process_ThroughputTab
        End If

    End Sub

    Private Sub ProcessAPCDIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessAPCDIDTextBox.TextChanged

        If (Me.controlIsLoaded) Then
            Me.m_process.ProcessAPCDID = Me.ProcessAPCDIDTextBox.Text.Trim
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub ProcessDescriptionTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessDescriptionTextBox.TextChanged

        If (Me.controlIsLoaded) Then
            If (Me.ProcessDescriptionTextBox.Text.Trim.Length = 0) Then
                Me.m_process.SetProcessDescriptionNull()
            Else
                Me.m_process.ProcessDescription = Me.ProcessDescriptionTextBox.Text.Trim
            End If
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub CommentPublicTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentPublicTextBox.TextChanged

        If (Me.controlIsLoaded) Then
            If (Me.CommentPublicTextBox.Text.Trim.Length = 0) Then
                Me.m_process.SetCommentPublicNull()
            Else
                Me.m_process.CommentPublic = Me.CommentPublicTextBox.Text.Trim
            End If
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub CommentInternalTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentInternalTextBox.TextChanged

        If (Me.controlIsLoaded) Then
            If (Me.CommentInternalTextBox.Text.Trim.Length = 0) Then
                Me.m_process.SetCommentInternalNull()
            Else
                Me.m_process.CommentInternal = Me.CommentInternalTextBox.Text.Trim
            End If
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub ControlApproachDescriptionTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlApproachDescriptionTextBox.TextChanged

        If (Me.controlIsLoaded) Then
            If (Me.ControlApproachDescriptionTextBox.Text.Trim.Length = 0) Then
                Me.m_process.SetControlApproachDescriptionNull()
            Else
                Me.m_process.ControlApproachDescription = Me.ControlApproachDescriptionTextBox.Text.Trim
            End If
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

#End Region '----- General - changed events -----

    Private Sub LoadHistoryRecord_Process()

        Dim row As EmissionsDataSet.ProcessHistoryRow = MainForm.EmissionsDataSet.ProcessHistory.NewProcessHistoryRow
        With row
            .ProcessID = Me.m_process.ProcessID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ProcessName = Me.m_process.ProcessName
            .ProcessDescription = Me.m_process.ProcessDescription
            .PlantEmissionUnitID = Me.m_process.PlantEmissionUnitID
            .ProcessClassID = Me.m_process.ProcessClassID
            .ProcessAPCDID = Me.m_process.ProcessAPCDID
            .ProcessEISID = Me.m_process.ProcessEISID
            .ThroughputTypeID = Me.m_process.ThroughputTypeID
            .BeginDate = Me.m_process.BeginDate

            If (Me.m_process.IsEndDateNull) Then
                .SetEndDateNull()
            Else
                .EndDate = Me.m_process.EndDate
            End If

            If (Me.m_process.IsCommentPublicNull) Then
                .SetCommentPublicNull()
            Else
                .CommentPublic = Me.m_process.CommentPublic
            End If

            If (Me.m_process.IsCommentInternalNull) Then
                .SetCommentInternalNull()
            Else
                .CommentInternal = Me.m_process.CommentInternal
            End If

            If (Me.m_process.IsControlApproachDescriptionNull) Then
                .SetControlApproachDescriptionNull()
            Else
                .ControlApproachDescription = Me.m_process.ControlApproachDescription
            End If
        End With
        MainForm.EmissionsDataSet.ProcessHistory.Rows.Add(row)

    End Sub

#End Region '----- General -----

#Region "----- Release Points -----"

    Private m_intProcessReleasePointPercentTotal As Int32

    Private Sub RefreshReleasePointPercentTotal()

        Dim expression As String = "Sum(EmissionsPercent)"
        Dim filter As String = EmissionsDataSet.ProcessReleasePoint.ProcessIDColumn.ColumnName _
                               & Tools.Constants.Character.EqualSign _
                               & Me.m_process.ProcessID
        Dim obj As Object = MainForm.EmissionsDataSet.Process_ReleasePointTab.Compute(expression, filter)

        If (IsNumeric(obj)) Then
            Me.m_intProcessReleasePointPercentTotal = CInt(obj)
        Else
            Me.m_intProcessReleasePointPercentTotal = 0
        End If

        'update the label
        Me.lblReleasePointPercentTotal.Text = "Total: " & CStr(Me.m_intProcessReleasePointPercentTotal)

    End Sub

    Private Sub btnAddReleasePoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddReleasePoint.Click

        Dim row As EmissionsDataSet.ProcessReleasePointRow = MainForm.EmissionsDataSet.ProcessReleasePoint.NewProcessReleasePointRow
        With row
            .ProcessID = Me.m_process.ProcessID
            .EmissionYear = Me.m_emissionYear.EmissionYear
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With

        Dim frm As New ProcessReleasePointAddEditForm(Me.m_plant.PlantID, row, MainForm.EmissionsDataSet.ProcessReleasePoint)
        If (frm.ShowDialog = DialogResult.OK) Then
            MainForm.EmissionsDataSet.ProcessReleasePoint.Rows.Add(row)
            Call Me.RefreshReleasePointPercentTotal()
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub Process_ReleasePointTabDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Process_ReleasePointTabDataGridView.DataError
        Select Case e.ColumnIndex
            Case 3
                MessageBox.Show("The percentage must be a positive whole number.", "Invalid Emissions Stream Percentage")
            Case Else
                Throw New ApplicationException("A data error occured while editing in the process release point grid.")
        End Select

    End Sub

    Private Sub Process_ReleasePointTabDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Process_ReleasePointTabDataGridView.DoubleClick

        Dim selectedRow As DataGridViewRow = Me.Process_ReleasePointTabDataGridView.Rows(Me.Process_ReleasePointTabDataGridView.CurrentRow.Index)
        Dim processReleasePointID As Int32 = CInt(selectedRow.Cells(4).Value)
        Dim row As EmissionsDataSet.ProcessReleasePointRow = MainForm.EmissionsDataSet.ProcessReleasePoint.FindByProcessReleasePointID(processReleasePointID)
        Dim frm As New ProcessReleasePointAddEditForm(Me.m_plant.PlantID, row)
        If (frm.ShowDialog = DialogResult.OK) Then
            Call Me.RefreshReleasePointPercentTotal()
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub Process_ReleasePointTabDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Process_ReleasePointTabDataGridView.CellValueChanged
        If (Me.m_controlIsLoaded = True) Then

            Call Me.RefreshReleasePointPercentTotal()
            Call Me.ToggleButtonStatus_FieldChanged()

        End If
    End Sub

    Private Sub Process_ReleasePointTabDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Process_ReleasePointTabDataGridView.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            Call Me.RefreshReleasePointPercentTotal()
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

#End Region '----- Release Points -----

#Region "----- Control Measures -----"

    Private m_sngControlMeasurePercentTotal As Single

    Private Sub btnAddControlMeasure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddControlMeasure.Click

        Dim row As EmissionsDataSet.ProcessControlMeasureRow = MainForm.EmissionsDataSet.ProcessControlMeasure.NewProcessControlMeasureRow
        With row
            .ProcessID = Me.m_process.ProcessID
            .EmissionYear = Me.m_emissionYear.EmissionYear
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With

        Dim frm As New ProcessControlMeasureAddEditForm(Me.m_plant.PlantID, row, GlobalVariables.DMLMode.Insert)
        If (frm.ShowDialog = DialogResult.OK) Then
            MainForm.EmissionsDataSet.ProcessControlMeasure.Rows.Add(row)
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub Process_ControlMeasureTabDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Process_ControlMeasureTabDataGridView.DoubleClick

        Dim selectedRow As DataGridViewRow = Me.Process_ControlMeasureTabDataGridView.Rows(Me.Process_ControlMeasureTabDataGridView.CurrentRow.Index)
        Dim processControlMeasureID As Int32 = CInt(selectedRow.Cells(4).Value)
        Dim row As EmissionsDataSet.ProcessControlMeasureRow = MainForm.EmissionsDataSet.ProcessControlMeasure.FindByProcessControlMeasureID(processControlMeasureID)
        Dim frm As New ProcessControlMeasureAddEditForm(Me.m_plant.PlantID, row, GlobalVariables.DMLMode.Update)
        If (frm.ShowDialog = DialogResult.OK) Then
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub Process_ControlMeasureTabDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Process_ControlMeasureTabDataGridView.CellValueChanged
        If (Me.m_controlIsLoaded = True) Then
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub Process_ControlMeasureTabDataGridView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Process_ControlMeasureTabDataGridView.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

#End Region '----- Control Measures -----

#Region "----- Throughput -----"

    Private m_seasonalTotal As Int16
    Private m_processSeasonalActivity As EmissionsDataSet.ProcessSeasonalActivityRow
    Private m_processSeasonalActivityHistory As EmissionsDataSet.ProcessSeasonalActivityHistoryRow

#Region "----- Throughput - grid -----"

    Private Sub btnLoadThroughputDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadThroughputDefaults.Click

        Call Me.LoadThroughputDefaults()

    End Sub

    Private Sub LoadThroughputDefaults()

        'if we can't get at least 1 UOM to use for Annual then we can't load defaults; the user needs to reconcile the throughput type
        Dim dtb As DataTable = Utility.ProcessDetailPeriodUtility.GetLookupTableByThroughputTypeID(Me.m_process.ThroughputTypeID)
        If (dtb.Rows.Count = 0) Then
            MessageBox.Show("No valid unit of measurement exists for the annual throughput of this process.", "Unknown Unit of Measurement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            For defaultCount = 1 To 5
                Dim row As EmissionsDataSet.ProcessDetailPeriodRow = MainForm.EmissionsDataSet.ProcessDetailPeriod.NewProcessDetailPeriodRow
                row.ProcessID = Me.m_process.ProcessID
                row.EmissionYear = Me.m_processYear.EmissionYear
                row.EmissionPeriodTypeID = "A"
                row.DataOriginID = 1
                row.DataYear = Me.m_processYear.EmissionYear
                row.SetDataSourceNull()
                row.AddDate = Date.Now
                row.AddedBy = GlobalVariables.Employee.EmployeeID

                Select Case defaultCount
                    Case 1
                        row.ProcessParameterValue = 0
                        row.ProcessParameterTypeID = 1
                        row.UnitOfMeasurementID = CInt(dtb.Rows(0)(0))

                    Case 2
                        row.ProcessParameterValue = 24
                        row.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.HoursPerDay
                        row.UnitOfMeasurementID = GlobalVariables.UnitOfMeasurementEnum.hours

                    Case 3
                        row.ProcessParameterValue = 7
                        row.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.DaysPerWeek
                        row.UnitOfMeasurementID = GlobalVariables.UnitOfMeasurementEnum.days

                    Case 4
                        row.ProcessParameterValue = 52
                        row.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.WeeksPerYear
                        row.UnitOfMeasurementID = GlobalVariables.UnitOfMeasurementEnum.weeks

                    Case 5
                        row.ProcessParameterValue = 8760
                        row.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.HoursPerYear
                        row.UnitOfMeasurementID = GlobalVariables.UnitOfMeasurementEnum.hours
                End Select

                MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows.Add(row)
            Next

            MainForm.ProcessDetailPeriodTableAdapter.Update(MainForm.EmissionsDataSet.ProcessDetailPeriod)
            MainForm.ProcessDetailPeriodTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.ProcessDetailPeriod, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)

            MainForm.Process_ThroughputTabTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.Process_ThroughputTab, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
            Me.Process_ThroughputTabDataGridView.DataSource = MainForm.EmissionsDataSet.Process_ThroughputTab
            Me.btnLoadThroughputDefaults.Visible = False

            Me.WinterTextBox.ReadOnly = False
            Me.SpringTextBox.ReadOnly = False
            Me.SummerTextBox.ReadOnly = False
            Me.FallTextBox.ReadOnly = False
        End If

    End Sub


    Private Sub btnAddThroughput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddThroughput.Click

        Dim row As EmissionsDataSet.ProcessDetailPeriodRow = MainForm.EmissionsDataSet.ProcessDetailPeriod.NewProcessDetailPeriodRow
        With row
            .ProcessID = Me.m_process.ProcessID
            .EmissionYear = Me.m_emissionYear.EmissionYear
            .EmissionPeriodTypeID = "A" 'meaningless as of 11/17/2011
            .DataOriginID = 1
            .DataYear = .EmissionYear
            .SetDataSourceNull()
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With

        Dim frm As New ProcessThroughputAddEditForm(Me.m_process, row, GlobalVariables.DMLMode.Insert)
        If (frm.ShowDialog = DialogResult.OK) Then
            MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows.Add(row)
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub Process_ThroughputTabDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Process_ThroughputTabDataGridView.DoubleClick

        Dim selectedRow As DataGridViewRow = Me.Process_ThroughputTabDataGridView.Rows(Me.Process_ThroughputTabDataGridView.CurrentRow.Index)
        Dim processDetailPeriodID As Int32 = CInt(selectedRow.Cells(5).Value)
        Dim row As EmissionsDataSet.ProcessDetailPeriodRow = MainForm.EmissionsDataSet.ProcessDetailPeriod.FindByProcessDetailPeriodID(processDetailPeriodID)
        Dim frm As New ProcessThroughputAddEditForm(Me.m_process, row, GlobalVariables.DMLMode.Update)
        If (frm.ShowDialog = DialogResult.OK) Then
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub Process_ThroughputTabDataGridView_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Process_ThroughputTabDataGridView.CellValueChanged
        If (Me.m_controlIsLoaded = True) Then
            Call Me.ToggleButtonStatus_FieldChanged()

        End If
    End Sub

    Private Sub Process_ThroughputTabDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Process_ThroughputTabDataGridView.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

#End Region '----- Throughput - grid -----

#Region "----- Throughput - validation -----"

    Private Function IsValidThroughputAndSeasonalValues() As Boolean

        Dim dataIsValid As Boolean
        Dim throughputFilter As String = "ProcessParameterTypeID = 1" 'Annual
        Dim throughputRows As EmissionsDataSet.ProcessDetailPeriod_GetThroughputViewRow() = CType(Me.EmissionsDataSet.ProcessDetailPeriod_GetThroughputView.Select(throughputFilter), EmissionsInventory.EmissionsDataSet.ProcessDetailPeriod_GetThroughputViewRow())

        If (throughputRows.Count = 0) Then
            dataIsValid = False
        Else
            Dim annualThroughput As Double = throughputRows(0).ProcessParameterValue
            If ((annualThroughput = 0) AndAlso (Me.m_seasonalTotal = 0)) Then
                dataIsValid = True
            ElseIf ((annualThroughput > 0) AndAlso (Me.m_seasonalTotal = 100)) Then
                dataIsValid = True
            Else
                dataIsValid = False
            End If
        End If

        Return dataIsValid

    End Function


#End Region '----- Throughput - validation -----

#Region "----- Throughput - seasonal -----"


    Private Sub LoadSeasonalTextBoxes()

        With Me.m_processSeasonalActivity
            Me.WinterTextBox.Text = CStr(.Winter)
            Me.SpringTextBox.Text = CStr(.Spring)
            Me.SummerTextBox.Text = CStr(.Summer)
            Me.FallTextBox.Text = CStr(.Fall)
        End With

    End Sub

    Private Sub RefreshSeasonalTotal()

        With Me.m_processSeasonalActivity
            Me.m_seasonalTotal = .Winter + .Spring + .Summer + .Fall
        End With
        Me.lblSeasonalTotal.Text = CStr(Me.m_seasonalTotal)

    End Sub

    Private Sub btnLoadSeasonalDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadSeasonalDefaults.Click

        With Me.m_processSeasonalActivity
            .Winter = 25
            .Spring = 25
            .Summer = 25
            .Fall = 25
        End With

        Call Me.LoadSeasonalTextBoxes()
        Call Me.RefreshSeasonalTotal()

    End Sub

    Private Sub CreateSeasonalActivityRow()

        Me.m_processSeasonalActivity = MainForm.EmissionsDataSet.ProcessSeasonalActivity.NewProcessSeasonalActivityRow
        With Me.m_processSeasonalActivity
            .ProcessID = Me.m_process.ProcessID
            .EmissionYear = Me.m_emissionYear.EmissionYear
            .DataOriginID = 1
            .Winter = 0
            .Spring = 0
            .Summer = 0
            .Fall = 0
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With
        MainForm.EmissionsDataSet.ProcessSeasonalActivity.Rows.Add(Me.m_processSeasonalActivity)

    End Sub

    Private Sub ProcessSeasonal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles WinterTextBox.KeyPress, SpringTextBox.KeyPress, SummerTextBox.KeyPress, FallTextBox.KeyPress
        Call Me.AllowWholeNumbersOnly(sender, e)
    End Sub

    Private Sub AllowWholeNumbersOnly(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) = 8) Then 'allow backspace 
            '
        ElseIf (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ProcessSeasonal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WinterTextBox.Validating, SpringTextBox.Validating, SummerTextBox.Validating, FallTextBox.Validating

        If (Me.m_controlIsLoaded = True) Then
            Call Me.RefreshSeasonalTotal()
        End If

    End Sub

    Private Sub WinterTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WinterTextBox.TextChanged
        If (Me.controlIsLoaded = True) Then

            Dim text As String = Me.WinterTextBox.Text.Trim
            If ((text.Length = 0) OrElse (Not IsNumeric(text)) OrElse (CInt(text) < 0)) Then
                text = "0"
            End If
            Me.m_processSeasonalActivity.Winter = CShort(text)
            Call Me.ToggleButtonStatus_FieldChanged()

        End If
    End Sub

    Private Sub SpringTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpringTextBox.TextChanged
        If (Me.controlIsLoaded = True) Then

            Dim text As String = Me.SpringTextBox.Text.Trim
            If ((text.Length = 0) OrElse (Not IsNumeric(text)) OrElse (CInt(text) < 0)) Then
                text = "0"
            End If
            Me.m_processSeasonalActivity.Spring = CShort(text)
            Call Me.ToggleButtonStatus_FieldChanged()

        End If
    End Sub

    Private Sub SummerTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummerTextBox.TextChanged
        If (Me.controlIsLoaded = True) Then

            Dim text As String = Me.SummerTextBox.Text.Trim
            If ((text.Length = 0) OrElse (Not IsNumeric(text)) OrElse (CInt(text) < 0)) Then
                text = "0"
            End If
            Me.m_processSeasonalActivity.Summer = CShort(text)
            Call Me.ToggleButtonStatus_FieldChanged()

        End If
    End Sub

    Private Sub FallTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FallTextBox.TextChanged
        If (Me.controlIsLoaded = True) Then

            Dim text As String = Me.FallTextBox.Text.Trim
            If ((text.Length = 0) OrElse (Not IsNumeric(text)) OrElse (CInt(text) < 0)) Then
                text = "0"
            End If
            Me.m_processSeasonalActivity.Fall = CShort(text)
            Call Me.ToggleButtonStatus_FieldChanged()

        End If
    End Sub

#Region "----- validation - seasonal  -----"

    Private Function IsValidSeasonalTotal() As Boolean

        If (Not Me.IsValidWinter) Then
            IsValidSeasonalTotal = False

        ElseIf (Not Me.IsValidSpring) Then
            IsValidSeasonalTotal = False

        ElseIf (Not Me.IsValidSummer) Then
            IsValidSeasonalTotal = False

        ElseIf (Not Me.IsValidFall) Then
            IsValidSeasonalTotal = False

        ElseIf (Not Me.IsValidTotal) Then
            IsValidSeasonalTotal = False

        Else
            IsValidSeasonalTotal = True
        End If

    End Function

    Private Function IsValidWinter() As Boolean

        If (Me.WinterTextBox.Text.Trim.Length = 0) Then
            IsValidWinter = False
            Me.ErrorProvider1.SetError(Me.WinterTextBox, "Value must be from 0 to 100")
            Me.ErrorProvider1.SetIconAlignment(Me.WinterTextBox, ErrorIconAlignment.MiddleRight)
        Else
            IsValidWinter = True
            Me.ErrorProvider1.SetError(Me.WinterTextBox, String.Empty)
        End If

    End Function

    Private Function IsValidSpring() As Boolean
        If (Me.SpringTextBox.Text.Trim.Length = 0) Then
            IsValidSpring = False
            Me.ErrorProvider1.SetError(Me.SpringTextBox, "Value must be from 0 to 100")
            Me.ErrorProvider1.SetIconAlignment(Me.SpringTextBox, ErrorIconAlignment.MiddleRight)
        Else
            IsValidSpring = True
            Me.ErrorProvider1.SetError(Me.SpringTextBox, String.Empty)
        End If
    End Function

    Private Function IsValidSummer() As Boolean
        If (Me.SummerTextBox.Text.Trim.Length = 0) Then
            IsValidSummer = False
            Me.ErrorProvider1.SetError(Me.SummerTextBox, "Value must be from 0 to 100")
            Me.ErrorProvider1.SetIconAlignment(Me.SummerTextBox, ErrorIconAlignment.MiddleRight)
        Else
            IsValidSummer = True
            Me.ErrorProvider1.SetError(Me.SummerTextBox, String.Empty)
        End If

    End Function

    Private Function IsValidFall() As Boolean
        If (Me.FallTextBox.Text.Trim.Length = 0) Then
            IsValidFall = False
            Me.ErrorProvider1.SetError(Me.FallTextBox, "Value must be from 0 to 100")
            Me.ErrorProvider1.SetIconAlignment(Me.FallTextBox, ErrorIconAlignment.MiddleRight)
        Else
            IsValidFall = True
            Me.ErrorProvider1.SetError(Me.FallTextBox, String.Empty)
        End If
    End Function

    Private Function IsValidTotal() As Boolean
        If ((Me.m_seasonalTotal = 0) OrElse (Me.m_seasonalTotal = 100)) Then
            IsValidTotal = True
            Me.ErrorProvider1.SetError(Me.lblSeasonalTotal, String.Empty)
        Else
            IsValidTotal = False
            Me.ErrorProvider1.SetError(Me.lblSeasonalTotal, "Seasonal total must equal 0 if annual throughput is 0, otherwise must equal 100.")
            Me.ErrorProvider1.SetIconAlignment(Me.lblSeasonalTotal, ErrorIconAlignment.MiddleRight)
        End If
    End Function

#End Region '----- validation - seasonal  -----

#End Region '----- Throughput - seasonal -----

#End Region '----- Throughput -----

#Region "----- Emissions -----"

    Private Sub btnAddEmissions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddEmissions.Click

        Dim row As EmissionsDataSet.ProcessEmissionRow = MainForm.EmissionsDataSet.ProcessEmission.NewProcessEmissionRow

        With row
            .ProcessID = Me.m_process.ProcessID
            .EmissionYear = Me.m_emissionYear.EmissionYear
            .DataOriginID = 1
            .ProcessEmissionTypeID = "R"
            .SetEmissionFactorReferenceNull()
            .EmissionPeriodTypeID = "A"             ' by default
            .EmissionValue = 0.0
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With

        Dim frm As New ProcessEmissionsAddEditForm(row, GlobalVariables.DMLMode.Insert)
        If (frm.ShowDialog = DialogResult.OK) Then
            MainForm.EmissionsDataSet.ProcessEmission.Rows.Add(row)
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub Process_EmissionsTabDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Process_EmissionsTabDataGridView.DoubleClick

        Dim selectedRow As DataGridViewRow = Me.Process_EmissionsTabDataGridView.Rows(Me.Process_EmissionsTabDataGridView.CurrentRow.Index)
        Dim processEmissionID As Int32 = CInt(selectedRow.Cells(6).Value)
        Dim row As EmissionsDataSet.ProcessEmissionRow = MainForm.EmissionsDataSet.ProcessEmission.FindByProcessEmissionID(processEmissionID)

        If Me.m_inventoryStatus = GlobalVariables.InventoryStatus.UnApproved Then
            Dim frm As New ProcessEmissionsAddEditForm(row, GlobalVariables.DMLMode.Update)
            If (frm.ShowDialog = DialogResult.OK) Then
                Call Me.ToggleButtonStatus_FieldChanged()
            End If
        Else
            ' Process is approved.  Editing emissions is not allowed.
            Dim frm As New ProcessEmissionsAddEditForm(row, GlobalVariables.DMLMode.View)
            'If (frm.ShowDialog = DialogResult.OK) Then
            '    Call Me.ToggleButtonStatus_FieldChanged()
            'End If
        End If

    End Sub

    Private Sub Process_EmissionsTabDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Process_EmissionsTabDataGridView.CellValueChanged

        If (Me.m_controlIsLoaded = True) Then
            If Me.m_inventoryStatus = GlobalVariables.InventoryStatus.UnApproved Then
                Call Me.ToggleButtonStatus_FieldChanged()
            Else
                ' Process is approved.  Editing emissions is not allowed.
            End If
        End If

    End Sub

    Private Sub Process_EmissionsTabDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Process_EmissionsTabDataGridView.KeyDown

        If Me.m_inventoryStatus = GlobalVariables.InventoryStatus.UnApproved Then
            If (e.KeyCode = Keys.Delete) Then
                Call Me.ToggleButtonStatus_FieldChanged()
            End If
        Else
            ' Process is approved.  Deleting emissions is not allowed.
        End If

    End Sub

    Private Sub btnCopyToProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyToProcess.Click

        If (MainForm.EmissionsDataSet.ProcessEmission.Rows.Count = 0) Then
            MessageBox.Show("There's nothing to copy!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New CopyPollutantsToAnotherProcessForm(Me.m_process)
            frm.ShowDialog()
            frm = Nothing
        End If

    End Sub

#End Region '----- Emissions -----

#Region "----- shutdown/delete -----"

    Private Sub btnShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShutdown.Click

        Dim response As DialogResult

        If (Me.btnShutdown.Text = GlobalVariables.Words.Shutdown) Then
            response = MessageBox.Show("Are you sure you want to shut down this process?", "Shut down " & Me.m_process.ProcessAPCDID, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                Call Me.Shutdown()
            End If

        ElseIf (Me.btnShutdown.Text = GlobalVariables.Words.Delete) Then
            response = MessageBox.Show("This action cannot be undone. Are you sure?", "Delete " & Me.m_process.ProcessAPCDID, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                Me.m_process.Delete()
                MainForm.ProcessTableAdapter.Update(MainForm.EmissionsDataSet.Process)
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Deleted)
            End If
        End If

    End Sub

    Private Sub Shutdown()

        Me.m_process.EndDate = New Date(Me.m_processYear.EmissionYear - 1, 12, 31)

        For Each row As DataRow In MainForm.EmissionsDataSet.Process_EmissionsTab
            row.Delete()
        Next

        For Each row As DataRow In MainForm.EmissionsDataSet.Process_ThroughputTab
            row.Delete()
        Next

        For Each row As EmissionsDataSet.ProcessSeasonalActivityRow In MainForm.EmissionsDataSet.ProcessSeasonalActivity
            If (row.RowState <> DataRowState.Added) Then
                row.Delete()
            End If
        Next

        Call Me.SaveProcess()
        RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Shutdown)

        Call Me.SaveProcessEmission()
        Call Me.SaveProcessThroughput()
        Call Me.SaveProcessSeasonalActivity()

        Call Me.SetInventoryStatus()
        Call Me.SetControlStatus()

        Call Me.LoadHistoryRecord_Process()

    End Sub

#End Region '----- shutdown/delete -----

#Region "----- approve/un-approve -----"

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

        If (Me.btnApprove.Text = GlobalVariables.Words.Approve) Then
            If (Me.IsOkToApprove) Then
                Call Me.Approve()
            End If
        ElseIf (Me.btnApprove.Text = GlobalVariables.Words.Unapprove) Then
            Call Me.UnApprove()
        End If

    End Sub

    Private Sub Approve()

        Dim frm As New ApproveForm(Me.m_processYear, "Approve Process")
        Dim response As DialogResult = frm.ShowDialog
        If (response = DialogResult.OK) Then
            Call Me.LoadHistoryRecord_ProcessYear()

            With Me.m_processYear
                .ApprovalEmployeeID = GlobalVariables.Employee.EmployeeID
                .ApprovalDate = Date.Now
            End With

            If (Me.SaveProcessYear) Then
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Approved)
                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()
                MainForm.EmissionsDataSet.ProcessYearHistory.Clear()
            End If
        End If

    End Sub

    Private Sub UnApprove()

        Dim frm As New ApproveForm(Me.m_processYear, "Un-approve Process")
        Dim response As DialogResult = frm.ShowDialog
        If (response = DialogResult.OK) Then
            Call Me.LoadHistoryRecord_ProcessYear()

            With Me.m_processYear
                .SetApprovalEmployeeIDNull()
                .SetApprovalDateNull()
            End With

            If (Me.SaveProcessYear) Then
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.UnApproved)
                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()
                MainForm.EmissionsDataSet.ProcessYearHistory.Clear()
            End If
        End If

    End Sub

    Private Function IsOkToApprove() As Boolean

        Dim ok As Boolean

        If (Not Me.AllRPsAreApproved) Then
            ok = False
        ElseIf (Not Me.AllCMsAreApproved) Then
            ok = False
        ElseIf (Not Me.OkToApprove_PRPs) Then
            ok = False
        ElseIf (Not Me.OkToApprove_PCMs) Then
            ok = False
        ElseIf (Not Me.OkToApprove_ThroughputAndEmissions) Then
            ok = False
        Else
            ok = True
        End If

        Return ok

    End Function

    Private Function AllRPsAreApproved() As Boolean

        Dim ok As Boolean

        If Me.m_process.IsEndDateNull Then
            Dim filter As String = EmissionsDataSet.Plant.PlantIDColumn.ColumnName _
                                   & Tools.Constants.Character.EqualSign _
                                   & CStr(Me.m_plant.PlantID) _
                                   & " AND ApprovalDate IS NULL AND IsExcluded = 'False'"

            Dim filteredView As DataView = MainForm.NavigationTable.ReleasePoint.DefaultView
            filteredView.RowFilter = filter
            If (filteredView.Count = 0) Then
                ok = True
            Else
                MessageBox.Show("All release points for this plant need to be approved before you may approve this process.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ok = False
            End If
        Else
            ok = True
        End If

        Return ok

    End Function

    Private Function AllCMsAreApproved() As Boolean

        Dim ok As Boolean

        If Me.m_process.IsEndDateNull Then
            Dim filter As String = EmissionsDataSet.Plant.PlantIDColumn.ColumnName _
                                          & Tools.Constants.Character.EqualSign _
                                          & CStr(Me.m_plant.PlantID) _
                                          & " AND ApprovalDate IS NULL AND IsExcluded = 'False'"

            Dim filteredView As DataView = MainForm.NavigationTable.ControlMeasure.DefaultView
            filteredView.RowFilter = filter
            If (filteredView.Count = 0) Then
                ok = True
            Else
                MessageBox.Show("All control measures for this plant need to be approved before you may approve this process.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ok = False
            End If
        Else
            ok = True
        End If

        Return ok

    End Function

    Private Function OkToApprove_PRPs() As Boolean

        Dim ok As Boolean

        If Me.m_process.IsEndDateNull Then
            If (Me.m_intProcessReleasePointPercentTotal = 100) Then
                ok = True
            Else
                MessageBox.Show("Release point emissions percent must total exactly 100 before you may approve this process.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ok = False
            End If
        Else
            ok = True
        End If

        Return ok

    End Function

    Private Function OkToApprove_PCMs() As Boolean

        Dim ok As Boolean

        If Me.m_process.IsEndDateNull Then
            If (MainForm.EmissionsDataSet.Process_ControlMeasureTab.Rows.Count = 0) Then
                ok = True
            Else
                'the sum of cap % for seq 1 must be > 0 and <= 100
                'uptime % for each row must be > 0 and <= 100

                Dim s1Amount As Single = 0
                Dim uptimeIsOk As Boolean = True

                For Each row As EmissionsDataSet.Process_ControlMeasureTabRow In MainForm.EmissionsDataSet.Process_ControlMeasureTab
                    If (row.UptimePercent <= 0 OrElse row.UptimePercent > 100) Then
                        uptimeIsOk = False
                        Exit For
                    End If
                    If (row.Sequence = 1) Then
                        s1Amount += row.CapturePercent
                    End If
                Next

                If ((uptimeIsOk = False) OrElse ((s1Amount < 0) OrElse (s1Amount > 100))) Then
                    Dim errorMessage As New System.Text.StringBuilder
                    With errorMessage
                        .AppendLine("Control measures are not valid.")
                        .AppendLine("The sum of the capture % for sequence 1 must be > 0 and <= 100.")
                        .AppendLine("The uptime % for each row must be > 0 and <=100.")
                    End With
                    MessageBox.Show(errorMessage.ToString(), "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ok = False
                Else
                    ok = True
                End If

            End If
        Else
            ok = True
        End If

        Return ok

    End Function

    Private Function OkToApprove_ThroughputAndEmissions() As Boolean

        Dim ok As Boolean = True

        If Me.m_process.IsEndDateNull Then
            Dim negativeThroughputExist As Boolean = ProcessHelper.NegativeValuesExist(MainForm.EmissionsDataSet.ProcessDetailPeriod)
            Dim negativeEmissionsExist As Boolean = ProcessHelper.NegativeValuesExist(MainForm.EmissionsDataSet.ProcessEmission)
            Dim sumOfEmissions_nonO3D As Double = ProcessHelper.SumOfEmissions_NonO3D(MainForm.EmissionsDataSet.ProcessEmission, Me.m_process)
            Dim sumOfEmissions_O3DPollutant_O3D As Double = ProcessHelper.SumOfEmissions_O3DPollutant_O3D(MainForm.EmissionsDataSet.ProcessEmission, Me.m_process)
            Dim o3dPollutants As O3DPollutants = ProcessHelper.GetO3DPollutants(MainForm.EmissionsDataSet.ProcessEmission, Me.m_process)

            If (negativeEmissionsExist) Then
                MessageBox.Show("1 or more emissions have negative values. Value must be >= 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ok = False
            ElseIf (negativeThroughputExist) Then
                MessageBox.Show("1 or more throughput have negative values. Value must be >= 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ok = False
            ElseIf (sumOfEmissions_nonO3D = -1) Then
                MessageBox.Show("No pollutants exist for this process.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ok = False
            Else

                If (MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows.Count = 0) Then
                    'if 0 rows:
                    '   1 or more emissions; each >= 0
                    '--------------------------------------------------------------------------------------------
                    If (MainForm.EmissionsDataSet.ProcessEmission.Rows.Count = 0) Then
                        MessageBox.Show("Emissions must exist to approve this process.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        ok = False
                    Else
                        With o3dPollutants
                            If (.COO3D > 0 AndAlso .COAnnual = 0) OrElse (.NOXO3D > 0 AndAlso .NOXAnnual = 0) OrElse (.VOCO3D > 0 AndAlso .VOCAnnual = 0) Then
                                MessageBox.Show("Ozone season pollutants with ozone season daily value > 0 must also have an Annual value that is > 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                ok = False
                            End If
                        End With
                    End If


                ElseIf (MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows.Count > 0) Then
                    Dim annualRow As EmissionsDataSet.ProcessDetailPeriodRow = Nothing
                    Dim ozoneRow As EmissionsDataSet.ProcessDetailPeriodRow = Nothing
                    For Each row As EmissionsDataSet.ProcessDetailPeriodRow In MainForm.EmissionsDataSet.ProcessDetailPeriod
                        If row.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.AnnualThroughput Then
                            annualRow = row
                        ElseIf row.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.OzoneSeasonDailyThroughput Then
                            ozoneRow = row
                        End If
                    Next

                    If ((annualRow IsNot Nothing) AndAlso (ozoneRow Is Nothing)) Then
                        'if annual only...
                        '... if value = 0 ; 1 or more emissions with 0 value each
                        '... if value > 0 ; 1 or more emissions totaling > 0
                        '--------------------------------------------------------------------------------------------
                        If (annualRow.ProcessParameterValue = 0) Then
                            If (sumOfEmissions_nonO3D > 0) Then
                                MessageBox.Show("Annual throughput is 0 so emission values must also be 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                ok = False
                            End If

                        ElseIf (annualRow.ProcessParameterValue > 0) Then
                            If (sumOfEmissions_nonO3D = 0) Then
                                MessageBox.Show("Annual throughput is > 0 so emission values must also total > 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                ok = False
                            End If

                        Else
                            MessageBox.Show("Annual throughput must be >= 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            ok = False
                        End If


                    ElseIf ((annualRow IsNot Nothing) AndAlso (ozoneRow IsNot Nothing)) Then
                        'if annual and o3d
                        '   if annual = 0 then o3d must = 0; 1 or more emissions with 0 value each
                        '   if annual > 0 then o3d may be >= 0; 1 or more emissions totaling > 0; 1 of which must be an o3d pollutant 
                        '--------------------------------------------------------------------------------------------
                        If (annualRow.ProcessParameterValue = 0) Then
                            If (ozoneRow.ProcessParameterValue > 0) Then
                                MessageBox.Show("Annual throughput is 0 so ozone season daily must also be 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                ok = False
                            Else
                                If (sumOfEmissions_nonO3D > 0) Then
                                    MessageBox.Show("Annual throughput is 0 so emission values must also be 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    ok = False
                                End If
                            End If

                        Else

                            If (sumOfEmissions_nonO3D <= 0) Then
                                MessageBox.Show("Annual throughput is > 0 so emission values must also total > 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                ok = False
                            Else
                                'if o3d = 0 then o3d pollutants must all be 0
                                If (ozoneRow.ProcessParameterValue = 0) Then
                                    If (sumOfEmissions_O3DPollutant_O3D > 0) Then
                                        MessageBox.Show("Ozone season throughput is 0 so ozone season pollutants must also be 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        ok = False
                                    End If
                                Else
                                    'if o3d > 0 then at least 1 o3d pollutant must be > 0
                                    If (sumOfEmissions_O3DPollutant_O3D <= 0) Then
                                        MessageBox.Show("Ozone season throughput is > 0 so ozone season pollutants must also be > 0.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        ok = False
                                    End If
                                End If

                            End If

                        End If

                    Else
                        MessageBox.Show("Annual throughput is missing.", "Action Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        ok = False
                    End If

                End If

            End If
        Else
            ok = True
        End If

        Return ok

    End Function

    Private Sub LoadHistoryRecord_ProcessYear()

        Dim row As EmissionsDataSet.ProcessYearHistoryRow = MainForm.EmissionsDataSet.ProcessYearHistory.NewProcessYearHistoryRow
        With row
            .ProcessYearID = Me.m_processYear.ProcessYearID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID

            .ProcessID = Me.m_processYear.ProcessID
            .EmissionYear = Me.m_processYear.EmissionYear

            .IsExcluded = Me.m_processYear.IsExcluded

            If (Me.m_processYear.IsDoneDateNull) Then
                .SetDoneDateNull()
            Else
                .DoneDate = Me.m_processYear.DoneDate
            End If

            If (Me.m_processYear.IsDoneByNull) Then
                .SetDoneByNull()
            Else
                .DoneBy = Me.m_processYear.DoneBy
            End If

            If (Me.m_processYear.IsApprovalEmployeeIDNull) Then
                .SetApprovalEmployeeIDNull()
            Else
                .ApprovalEmployeeID = Me.m_processYear.ApprovalEmployeeID
            End If

            If (Me.m_processYear.IsApprovalDateNull) Then
                .SetApprovalDateNull()
            Else
                .ApprovalDate = Me.m_processYear.ApprovalDate
            End If

            .ApprovalComment = Me.m_processYear.ApprovalComment

        End With
        MainForm.EmissionsDataSet.ProcessYearHistory.Rows.Add(row)

    End Sub

#End Region '----- approve/un-approve -----

#Region "----- saves  -----"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (Me.IsValidForm) Then

            Call Me.SaveProcess()

            RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Modified)
            MainForm.EmissionsDataSet.ProcessHistory.Clear()
            Call Me.LoadHistoryRecord_Process()

            Call Me.SaveProcessReleasePoint()
            Call Me.SaveProcessControlMeasure()
            Call Me.SaveProcessThroughput()
            Call Me.SaveProcessSeasonalActivity()
            Call Me.SaveProcessEmission()
            Call Me.SaveProcessYear()

            Call Me.ToggleButtonStatus(GlobalVariables.InventoryStatus.Modified)

            Me.m_changedValueCount = 0

        End If

    End Sub

    Private Function SaveProcess() As Boolean

        Dim saved As Boolean

        MainForm.ProcessBindingSource.EndEdit()
        MainForm.ProcessHistoryBindingSource.EndEdit()

        Try
            MainForm.ProcessTableAdapter.Update(MainForm.EmissionsDataSet.Process)
            MainForm.ProcessHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ProcessHistory)
            saved = True
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saved = False
        End Try

        Return saved

    End Function

    ''' <summary>
    ''' Save the release point(s) for the process.
    ''' </summary>
    ''' <returns>True if successful</returns>
    ''' <remarks>
    ''' 2013-10-25 BJF:  Added outer Try block.
    ''' </remarks>
    Private Function SaveProcessReleasePoint() As Boolean

        Dim saved As Boolean = False

        Try
            Dim changes As EmissionsDataSet.Process_ReleasePointTabDataTable = CType(MainForm.EmissionsDataSet.Process_ReleasePointTab.GetChanges, EmissionsInventory.EmissionsDataSet.Process_ReleasePointTabDataTable)
            If (changes IsNot Nothing) Then

                For Each changedRow As EmissionsDataSet.Process_ReleasePointTabRow In changes
                    If (changedRow.RowState = DataRowState.Added) Then
                        Dim row As EmissionsDataSet.ProcessReleasePointRow = MainForm.EmissionsDataSet.ProcessReleasePoint.FindByProcessReleasePointID(changedRow.ProcessReleasePointID)
                        If (row IsNot Nothing) Then
                            row.EmissionsPercent = changedRow.EmissionsPercent
                        End If

                    ElseIf (changedRow.RowState = DataRowState.Modified) Then
                        Dim row As EmissionsDataSet.ProcessReleasePointRow = MainForm.EmissionsDataSet.ProcessReleasePoint.FindByProcessReleasePointID(changedRow.ProcessReleasePointID)
                        If (row IsNot Nothing) Then
                            Call ProcessHelper.LoadHistoryRecord_ProcessReleasePoint(row)
                            row.EmissionsPercent = changedRow.EmissionsPercent
                        End If

                    ElseIf (changedRow.RowState = DataRowState.Deleted) Then
                        Dim row As EmissionsDataSet.ProcessReleasePointRow = MainForm.EmissionsDataSet.ProcessReleasePoint.FindByProcessReleasePointID(CInt(changedRow("ProcessReleasePointID", DataRowVersion.Original)))
                        row.Delete()
                    End If
                Next

                Try
                    MainForm.ProcessReleasePointTableAdapter.Update(MainForm.EmissionsDataSet.ProcessReleasePoint)
                    MainForm.ProcessReleasePointHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ProcessReleasePointHistory)


                    MainForm.ProcessReleasePointTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.ProcessReleasePoint, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
                    MainForm.Process_ReleasePointTabTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.Process_ReleasePointTab, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
                    Call Me.RefreshReleasePointPercentTotal()
                    saved = True
                Catch ex As Exception
                    GlobalMethods.HandleError(ex)
                    MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    saved = False
                End Try

                MainForm.EmissionsDataSet.ProcessReleasePointHistory.Clear()

            Else
                saved = True
            End If

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saved = False
        End Try

        Return saved

    End Function

    ''' <summary>
    ''' Save the control measure(s) for the process.
    ''' </summary>
    ''' <returns>True if successful</returns>
    ''' <remarks>
    ''' 2013-10-25 BJF:  Added outer Try block.
    ''' </remarks>
    Private Function SaveProcessControlMeasure() As Boolean

        Dim saved As Boolean = False

        Try
            Dim changes As EmissionsDataSet.Process_ControlMeasureTabDataTable = CType(MainForm.EmissionsDataSet.Process_ControlMeasureTab.GetChanges, EmissionsInventory.EmissionsDataSet.Process_ControlMeasureTabDataTable)
            If (changes IsNot Nothing) Then

                For Each changedRow As EmissionsDataSet.Process_ControlMeasureTabRow In changes
                    If (changedRow.RowState = DataRowState.Added) Then
                        Dim row As EmissionsDataSet.ProcessControlMeasureRow = MainForm.EmissionsDataSet.ProcessControlMeasure.FindByProcessControlMeasureID(changedRow.ProcessControlMeasureID)
                        If (row IsNot Nothing) Then
                            row.CapturePercent = changedRow.CapturePercent
                            row.UptimePercent = changedRow.UptimePercent
                            row.Sequence = changedRow.Sequence
                        End If

                    ElseIf (changedRow.RowState = DataRowState.Modified) Then
                        Dim row As EmissionsDataSet.ProcessControlMeasureRow = MainForm.EmissionsDataSet.ProcessControlMeasure.FindByProcessControlMeasureID(changedRow.ProcessControlMeasureID)
                        If (row IsNot Nothing) Then
                            Call ProcessHelper.LoadHistoryRecord_ProcessControlMeasure(row)
                            row.CapturePercent = changedRow.CapturePercent
                            row.UptimePercent = changedRow.UptimePercent
                            row.Sequence = changedRow.Sequence
                        End If

                    ElseIf (changedRow.RowState = DataRowState.Deleted) Then
                        Dim row As EmissionsDataSet.ProcessControlMeasureRow = MainForm.EmissionsDataSet.ProcessControlMeasure.FindByProcessControlMeasureID(CInt(changedRow("ProcessControlMeasureID", DataRowVersion.Original)))
                        row.Delete()
                    End If
                Next

                Try
                    MainForm.ProcessControlMeasureTableAdapter.Update(MainForm.EmissionsDataSet.ProcessControlMeasure)
                    MainForm.ProcessControlMeasureHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ProcessControlMeasureHistory)

                    MainForm.ProcessControlMeasureTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.ProcessControlMeasure, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
                    MainForm.Process_ControlMeasureTabTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.Process_ControlMeasureTab, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)

                    saved = True
                Catch ex As Exception
                    GlobalMethods.HandleError(ex)
                    MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    saved = False
                End Try

                MainForm.EmissionsDataSet.ProcessControlMeasureHistory.Clear()

            Else
                saved = True
            End If

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saved = False
        End Try

        Return saved

    End Function

    ''' <summary>
    ''' Save the throughput data for the process.
    ''' </summary>
    ''' <returns>True if successful</returns>
    ''' <remarks>
    ''' 2013-10-25 BJF:  Added outer Try block.
    ''' </remarks>
    Private Function SaveProcessThroughput() As Boolean

        Dim saved As Boolean = False

        Try
            Dim changes As EmissionsDataSet.Process_ThroughputTabDataTable = CType(MainForm.EmissionsDataSet.Process_ThroughputTab.GetChanges, EmissionsInventory.EmissionsDataSet.Process_ThroughputTabDataTable)
            If (changes IsNot Nothing) Then

                For Each changedRow As EmissionsDataSet.Process_ThroughputTabRow In changes
                    If (changedRow.RowState = DataRowState.Added) Then
                        Dim row As EmissionsDataSet.ProcessDetailPeriodRow = MainForm.EmissionsDataSet.ProcessDetailPeriod.FindByProcessDetailPeriodID(changedRow.ProcessDetailPeriodID)
                        If (row IsNot Nothing) Then
                            row.ProcessParameterValue = changedRow.ProcessParameterValue
                        End If

                    ElseIf (changedRow.RowState = DataRowState.Modified) Then
                        Dim row As EmissionsDataSet.ProcessDetailPeriodRow = MainForm.EmissionsDataSet.ProcessDetailPeriod.FindByProcessDetailPeriodID(changedRow.ProcessDetailPeriodID)
                        If (row IsNot Nothing) Then
                            Call ProcessHelper.LoadHistoryRecord_ProcessDetailPeriod(row)
                            row.ProcessParameterValue = changedRow.ProcessParameterValue
                        End If

                    ElseIf (changedRow.RowState = DataRowState.Deleted) Then
                        Dim row As EmissionsDataSet.ProcessDetailPeriodRow = MainForm.EmissionsDataSet.ProcessDetailPeriod.FindByProcessDetailPeriodID(CInt(changedRow("ProcessDetailPeriodID", DataRowVersion.Original)))
                        row.Delete()
                    End If
                Next

                Try
                    MainForm.ProcessDetailPeriodTableAdapter.Update(MainForm.EmissionsDataSet.ProcessDetailPeriod)
                    MainForm.ProcessDetailPeriodHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ProcessDetailPeriodHistory)

                    MainForm.ProcessDetailPeriodTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.ProcessDetailPeriod, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
                    MainForm.Process_ThroughputTabTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.Process_ThroughputTab, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)

                    saved = True
                Catch ex As Exception
                    GlobalMethods.HandleError(ex)
                    MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    saved = False
                End Try

                MainForm.EmissionsDataSet.ProcessDetailPeriodHistory.Clear()

            Else
                saved = True
            End If

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saved = False
        End Try

        Return saved

    End Function

    ''' <summary>
    ''' Save the four seasonal percent throughput values.
    ''' </summary>
    ''' <returns>True if successful</returns>
    ''' <remarks>
    ''' 2013-10-25 BJF:  Aded outer Try block.
    ''' </remarks>
    Private Function SaveProcessSeasonalActivity() As Boolean

        Dim saved As Boolean = False

        Try
            Dim changes As EmissionsDataSet.ProcessSeasonalActivityDataTable = CType(MainForm.EmissionsDataSet.ProcessSeasonalActivity.GetChanges, EmissionsInventory.EmissionsDataSet.ProcessSeasonalActivityDataTable)
            If (changes IsNot Nothing) Then
                Dim changedRow As EmissionsDataSet.ProcessSeasonalActivityRow = CType(changes.Rows(0), EmissionsInventory.EmissionsDataSet.ProcessSeasonalActivityRow)

                If (changedRow.RowState = DataRowState.Added AndAlso Me.m_seasonalTotal > 0) Then

                    Try
                        MainForm.ProcessSeasonalActivityTableAdapter.Update(MainForm.EmissionsDataSet.ProcessSeasonalActivity)
                        MainForm.ProcessSeasonalActivityTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.ProcessSeasonalActivity, Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
                        Me.m_processSeasonalActivity = CType(MainForm.EmissionsDataSet.ProcessSeasonalActivity.Rows(0), EmissionsInventory.EmissionsDataSet.ProcessSeasonalActivityRow)
                        saved = True
                    Catch ex As Exception
                        GlobalMethods.HandleError(ex)
                        MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        saved = False
                    End Try
                    Call ProcessHelper.LoadHistoryRecord_ProcessSeasonalActivity(Me.m_processSeasonalActivity)

                ElseIf (changedRow.RowState = DataRowState.Modified) Then

                    Try
                        MainForm.ProcessSeasonalActivityTableAdapter.Update(MainForm.EmissionsDataSet.ProcessSeasonalActivity)
                        MainForm.ProcessSeasonalActivityHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ProcessSeasonalActivityHistory)
                        saved = True
                    Catch ex As Exception
                        GlobalMethods.HandleError(ex)
                        MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        saved = False
                    End Try
                    MainForm.EmissionsDataSet.ProcessSeasonalActivityHistory.Clear()
                    Call ProcessHelper.LoadHistoryRecord_ProcessSeasonalActivity(Me.m_processSeasonalActivity)

                End If

            End If

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saved = False
        End Try

        Return saved

    End Function

    ''' <summary>
    ''' Save the new or modified Process Emission row.
    ''' </summary>
    ''' <returns>True if successful</returns>
    ''' <remarks>
    ''' 2013-10-25 BJF:  Added outer Try block and put in temporary code to get emission period type ID, to avoid problem with library.
    ''' </remarks>
    Private Function SaveProcessEmission() As Boolean

        Dim saved As Boolean = False

        Try
            Dim changes As EmissionsDataSet.Process_EmissionsTabDataTable = CType(MainForm.EmissionsDataSet.Process_EmissionsTab.GetChanges,  _
                EmissionsInventory.EmissionsDataSet.Process_EmissionsTabDataTable)
            If (changes IsNot Nothing) Then

                For Each changedRow As EmissionsDataSet.Process_EmissionsTabRow In changes
                    If (changedRow.RowState = DataRowState.Added) Then
                        Dim row As EmissionsDataSet.ProcessEmissionRow _
                            = MainForm.EmissionsDataSet.ProcessEmission.FindByProcessEmissionID(changedRow.ProcessEmissionID)
                        If (row IsNot Nothing) Then
                            'row.EmissionPeriodTypeID _
                            '    = Emissions.Utility.EmissionPeriodTypeUtility.GetByLookupName(changedRow.EmissionPeriodTypeName).EmissionPeriodTypeID
                            If changedRow.EmissionPeriodTypeName = "Ozone Season Daily" Then
                                row.EmissionPeriodTypeID = "O3D"
                            Else
                                row.EmissionPeriodTypeID = "A"
                            End If
                            row.EmissionValue = changedRow.EmissionValue
                        End If

                    ElseIf (changedRow.RowState = DataRowState.Modified) Then
                        Dim row As EmissionsDataSet.ProcessEmissionRow = MainForm.EmissionsDataSet.ProcessEmission.FindByProcessEmissionID(changedRow.ProcessEmissionID)
                        If (row IsNot Nothing) Then
                            Call ProcessHelper.LoadHistoryRecord_ProcessEmission(row)
                            If (row.EmissionPeriodTypeID.ToString() <> "A" _
                                AndAlso row.EmissionPeriodTypeID.ToString() <> "O3D") Then
                                If changedRow.EmissionPeriodTypeName = "Ozone Season Daily" Then
                                    row.EmissionPeriodTypeID = "O3D"
                                Else
                                    row.EmissionPeriodTypeID = "A"
                                End If
                            End If
                            row.EmissionValue = changedRow.EmissionValue
                        End If

                    ElseIf (changedRow.RowState = DataRowState.Deleted) Then
                        Try
                            Dim row As EmissionsDataSet.ProcessEmissionRow = _
                                MainForm.EmissionsDataSet.ProcessEmission.FindByProcessEmissionID(CInt(changedRow("ProcessEmissionID", DataRowVersion.Original)))
                            row.Delete()
                        Catch ex As Exception
                            GlobalMethods.HandleError(ex)
                            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.DeletingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Next

                Try
                    MainForm.ProcessEmissionTableAdapter.Update(MainForm.EmissionsDataSet.ProcessEmission)
                    MainForm.ProcessEmissionHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ProcessEmissionHistory)

                    MainForm.ProcessEmissionTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.ProcessEmission, _
                                                                                      Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)
                    MainForm.Process_EmissionsTabTableAdapter.FillByProcessID_EmissionYear(MainForm.EmissionsDataSet.Process_EmissionsTab, _
                                                                                           Me.m_process.ProcessID, Me.m_emissionYear.EmissionYear)

                    saved = True
                Catch ex As Exception
                    GlobalMethods.HandleError(ex)
                    MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    saved = False
                End Try

                MainForm.EmissionsDataSet.ProcessEmissionHistory.Clear()

            Else
                saved = True
            End If

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saved = False
        End Try

        Return saved

    End Function

    Private Function SaveProcessYear() As Boolean

        Dim saved As Boolean = False

        Try
            MainForm.ProcessYearTableAdapter.Update(MainForm.EmissionsDataSet.ProcessYear)
            MainForm.ProcessYearHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ProcessYearHistory)
            saved = True
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saved = False
        End Try

        MainForm.EmissionsDataSet.ProcessYearHistory.Clear()

        Return saved

    End Function

#End Region '----- saves  -----

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If ((Not Me.m_process.RowState = DataRowState.Unchanged) OrElse (Me.m_changedValueCount > 0)) Then
            If (MessageBox.Show("You have unsaved changes. Do you wish to save them?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Call Me.SaveProcess()
            End If
        End If

        For Each ctl As Control In Me.Controls
            Me.ErrorProvider1.SetError(ctl, String.Empty)
        Next

        RaiseEvent CancelButton_Pressed()

    End Sub

    ''' <summary>
    ''' With user confirmation, call routine to recalculate emissions that use an emission factor from the appropriate throughput.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>2015-08-04 BJF: Added</remarks>
    Private Sub RecalculateButton_Click(sender As Object, e As EventArgs) Handles btnRecalculateFromThroughput.Click
        Dim msg As String = "This will use the current year's (saved) throughput to recalculate emissions where the calculation method is an emission factor.  Currently, it only does this if the emission factor does NOT take control efficiency into account.  Existing emissions values will be overwritten."
        If MessageBox.Show(msg, "Recalculate from Throughput", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            Call Me.EmissionsRecalculateFromThroughput()
            Cursor = Cursors.Default
        End If
    End Sub

    ''' <summary>
    ''' Recalculate emissions that use an emission factor from the appropriate throughput.
    ''' </summary>
    ''' <remarks>2015-08-04 BJF: Added</remarks>
    Private Sub EmissionsRecalculateFromThroughput()

        Dim annualThruput As Double = 0.0#
        Dim ozoneSeasonThruput As Double = 0.0#
        Dim emissions As Double = 0.0#
        Dim factor As Double = 0.0#
        'Dim efficiency As Double = 0.0#

        For Each row As APCD.EmissionsInventory.EmissionsDataSet.ProcessDetailPeriodRow In Me.m_process.GetProcessDetailPeriodRows
            If row.ProcessParameterTypeID = 1 Then
                annualThruput = row.ProcessParameterValue
            End If
            If row.ProcessParameterTypeID = 13 Then
                ozoneSeasonThruput = row.ProcessParameterValue
            End If
        Next

        If annualThruput > 0.0# Then
            For Each ro As DataGridViewRow In Me.Process_EmissionsTabDataGridView.Rows
                If ro.Cells("EmissionPeriodTypeName").Value.ToString = "Annual" Then
                    If ro.Cells("EmissionCalculationMethodName").Value.ToString.Contains("(no control") Then
                        ' emission factor NOT using control efficiency
                        factor = CDbl(ro.Cells("EmissionFactorValue").Value)
                        emissions = factor * annualThruput
                        ro.Cells("EmissionValue").Value = emissions
                        Me.m_changedValueCount += 1
                        'ElseIf ro.Cells("EmissionCalculationMethodName").Value.ToString.Contains("(pre-control)") Then
                        '    ' emission factor USING control efficiency
                        '    'TODO 2015-08-04 : Determine effective control efficiency for this pollutant.
                        '    factor = CDbl(ro.Cells("EFValue").Value)
                        '    emissions = factor * annual * (1 - efficiency)
                        '    ro.Cells("EmissionValue").Value = emissions
                        '    Me.m_changedValueCount += 1
                    End If
                ElseIf ro.Cells("EmissionPeriodTypeName").Value.ToString = "Ozone Season Daily" AndAlso ozoneSeasonThruput > 0.0# Then
                    If ro.Cells("EmissionCalculationMethodName").Value.ToString.Contains("(no control") Then
                        ' emission factor NOT using control efficiency
                        factor = CDbl(ro.Cells("EmissionFactorValue").Value)
                        emissions = factor * ozoneSeasonThruput
                        ro.Cells("EmissionValue").Value = emissions
                        Me.m_changedValueCount += 1
                        'ElseIf ro.Cells("EmissionCalculationMethodName").Value.ToString.Contains("(pre-control)") Then
                        '    ' emission factor USING control efficiency
                        '    'TODO 2015-08-04 : Determine effective control efficiency for this pollutant.
                        '    factor = CDbl(ro.Cells("EFValue").Value)
                        '    emissions = factor * annual * (1 - efficiency)
                        '    ro.Cells("EmissionValue").Value = emissions
                        '    Me.m_changedValueCount += 1
                    End If
                End If
            Next
        Else
            MessageBox.Show("Annual throughput is missing or zero!  No emissions changed.", "Recalculate from Throughput", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Call Me.ToggleButtonStatus_FieldChanged()
        Me.Process_EmissionsTabDataGridView.Refresh()

    End Sub

    Private Sub OzoneSeasonCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles OzoneSeasonCheckBox.CheckedChanged

        If Me.OzoneSeasonCheckBox.Checked Then
            CType(Me.Process_EmissionsTabDataGridView.DataSource, System.Data.DataTable).DefaultView.RowFilter = "EmissionPeriodTypeName = 'Ozone Season Daily'"
            Me.TonsCheckBox.Enabled = False
        Else
            CType(Me.Process_EmissionsTabDataGridView.DataSource, System.Data.DataTable).DefaultView.RowFilter = String.Empty
            Me.TonsCheckBox.Enabled = True
        End If
        Me.Process_EmissionsTabDataGridView.Refresh()

    End Sub

    Private Sub TonsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TonsCheckBox.CheckedChanged

        If Me.TonsCheckBox.Checked Then
            CType(Me.Process_EmissionsTabDataGridView.DataSource, System.Data.DataTable).DefaultView.RowFilter = "UnitOfMeasurementName = 'tons'" ' <> 'pounds'
            Me.OzoneSeasonCheckBox.Enabled = False
        Else
            CType(Me.Process_EmissionsTabDataGridView.DataSource, System.Data.DataTable).DefaultView.RowFilter = String.Empty
            Me.OzoneSeasonCheckBox.Enabled = True
        End If
        Me.Process_EmissionsTabDataGridView.Refresh()

    End Sub

    ''' <summary>
    ''' If the emission factor value is -1, make the text of that cell white so the user doesn't see it.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Process_EmissionsTabDataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Process_EmissionsTabDataGridView.CellFormatting
        If (Me.Process_EmissionsTabDataGridView.Columns(e.ColumnIndex).HeaderText = "Emission Factor") Then
            Dim value As Object = e.Value
            If (IsNumeric(value)) Then
                If (CDbl(value) = -1) Then
                    Me.Process_EmissionsTabDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.White
                End If
            End If
        End If

    End Sub
End Class
