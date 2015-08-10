Imports System.Data.OleDb

Public Class ControlMeasureUserControl

    'counters
    Private m_changedValueCount As Int32

    'events 
    Public Event SaveButton_Pressed(ByVal state As GlobalVariables.InventoryStatus)
    Public Event CancelButton_Pressed()

    'object variables
    Private m_emissionYear As EmissionsDataSet.EmissionYearRow
    Private m_controlMeasure As EmissionsDataSet.ControlMeasureRow
    Private m_controlMeasureYear As EmissionsDataSet.ControlMeasureYearRow
    Private m_controlMeasurePollutants_ORIGINAL As EmissionsDataSet.ControlMeasurePollutantDataTable

    'status variables
    Private m_inventoryStatus As GlobalVariables.InventoryStatus

    'changed flags
    Private m_isExcluded_Changed As Boolean = False

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

    Private Sub ControlMeasureUserControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Me.LoadComboBoxes()

        Me.PollutantTableAdapter.Fill(Me.EmissionsDataSet.Pollutant) ' how to make this cleaner?; it's part of the grid


    End Sub

    Private Sub LoadComboBoxes()

        'control measure type
        Tools.WindowsForms.LoadComboBox(GlobalVariables.LookupTable.ControlMeasureType, Me.ControlMeasureTypeIDComboBox, False)

        'pollutant
        Dim pollutantView As DataView = GlobalVariables.LookupTable.Pollutant.DefaultView
        pollutantView.RowFilter = "LastInventoryYear IS NULL"
        Tools.WindowsForms.LoadComboBox(pollutantView, Me.PollutantComboBox)

    End Sub

    Friend Sub LoadObjectVariables(ByVal emissionYear As EmissionsDataSet.EmissionYearRow, ByVal controlMeasure As EmissionsDataSet.ControlMeasureRow, ByVal controlMeasureYear As EmissionsDataSet.ControlMeasureYearRow)

        Me.m_emissionYear = emissionYear
        Me.m_controlMeasure = controlMeasure
        Me.m_controlMeasureYear = controlMeasureYear

        Call Me.LoadHistoryRecord_ControlMeasure()
        Call Me.LoadHistoryRecord_ControlMeasureYear()

        Me.m_controlMeasurePollutants_ORIGINAL = CType(MainForm.EmissionsDataSet.ControlMeasurePollutant.Copy, EmissionsInventory.EmissionsDataSet.ControlMeasurePollutantDataTable)

        Me.ControlMeasure_GetProcessesTableAdapter.FillByControlMeasureID_EmissionYear(Me.EmissionsDataSet.ControlMeasure_GetProcesses, Me.m_controlMeasure.ControlMeasureID, Me.m_emissionYear.EmissionYear)

        Me.m_changedValueCount = 0

    End Sub

    Friend Sub LoadControls()

        'set shut down label
        If (Me.m_controlMeasure.IsEndDateNull) Then
            Me.ShutdownMessageLabel.Text = String.Empty
        Else
            Me.ShutdownMessageLabel.Text = "Shut down in " & Me.m_controlMeasure.EndDate.Year
        End If

        Me.IsExcludedCheckBox.Checked = Me.m_controlMeasureYear.IsExcluded

        With Me.m_controlMeasure
            Me.ControlMeasureAPCDIDTextBox.Text = .ControlMeasureAPCDID
            Me.ControlMeasureTypeIDComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ControlMeasureTypeIDComboBox, .ControlMeasureTypeID)
            Me.ControlMeasureDescriptionTextBox.Text = .ControlMeasureDescription
            Me.CompanyCommentTextBox.Text = .CompanyComment
            Me.APCDCommentTextBox.Text = .APCDComment
        End With

        Me.ControlMeasurePollutantDataGridView.AutoGenerateColumns = False
        Me.ControlMeasurePollutantDataGridView.DataSource = MainForm.EmissionsDataSet.ControlMeasurePollutant

        Me.PollutantComboBox.SelectedIndex = -1

        'set the approval status level on the main form
        If (Not Me.m_controlMeasureYear.IsApprovalDateNull) Then
            Dim objEmployee As PeopleLibrary.Business.Employee = PeopleLibrary.Utility.EmployeeUtility.GetByPrimaryKey(Me.m_controlMeasureYear.ApprovalEmployeeID)
            MainForm.statusLevel.Text = "Approved on " & Me.m_controlMeasureYear.ApprovalDate.ToShortDateString & " by " & objEmployee.NickName & " " & objEmployee.LastName
        Else
            MainForm.statusLevel.Text = String.Empty
        End If

    End Sub

    Private Sub LoadHistoryRecord_ControlMeasure()

        Dim row As EmissionsDataSet.ControlMeasureHistoryRow = MainForm.EmissionsDataSet.ControlMeasureHistory.NewControlMeasureHistoryRow
        With row
            .ControlMeasureID = Me.m_controlMeasure.ControlMeasureID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ControlMeasureDescription = Me.m_controlMeasure.ControlMeasureDescription
            .PlantID = Me.m_controlMeasure.PlantID
            .ControlMeasureTypeID = CInt(Me.ControlMeasureTypeIDComboBox.SelectedValue)
            .ControlMeasureAPCDID = Me.m_controlMeasure.ControlMeasureAPCDID
            .BeginDate = Me.m_controlMeasure.BeginDate
            If (Me.m_controlMeasure.IsEndDateNull) Then
                .SetEndDateNull()
            Else
                .EndDate = Me.m_controlMeasure.EndDate
            End If
            .CompanyComment = Me.m_controlMeasure.CompanyComment
            .APCDComment = Me.m_controlMeasure.APCDComment

        End With
        MainForm.EmissionsDataSet.ControlMeasureHistory.Rows.Add(row)

    End Sub

    Friend Sub SetInventoryStatus()

        If (GlobalVariables.UserRole = GlobalVariables.Role.Guest) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.None

        ElseIf (Not Me.m_emissionYear.IsEmissionsInEISDateNull) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.EmissionYearClosed

        ElseIf (Not Me.m_controlMeasureYear.IsApprovalDateNull) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.Approved

        ElseIf (Not Me.m_controlMeasure.IsEndDateNull) Then
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

    Private Sub SetDefaultControlStatus()

        Me.ShutdownMessageLabel.Text = String.Empty

        Me.ButtonPanel.Visible = True
        Me.AddPollutantPanel.Visible = True

        Me.IsExcludedCheckBox.Enabled = True
        Me.ControlMeasureTypeIDComboBox.Enabled = True
        Me.ControlMeasurePollutantDataGridView.ReadOnly = False
        Me.ControlMeasureAPCDIDTextBox.ReadOnly = False
        Me.ControlMeasureDescriptionTextBox.ReadOnly = False
        Me.CompanyCommentTextBox.ReadOnly = False
        Me.APCDCommentTextBox.ReadOnly = False
    End Sub

    Private Sub DisableEditing()

        Me.IsExcludedCheckBox.Enabled = False

        Me.ControlMeasureAPCDIDTextBox.ReadOnly = True
        Me.ControlMeasureTypeIDComboBox.Enabled = False
        Me.ControlMeasureDescriptionTextBox.ReadOnly = True
        Me.CompanyCommentTextBox.ReadOnly = True
        Me.APCDCommentTextBox.ReadOnly = True

        Me.AddPollutantPanel.Visible = False
        Me.ControlMeasurePollutantDataGridView.ReadOnly = True

        Me.ButtonPanel.Visible = False

    End Sub

    Private Sub EnableEditing()

        Me.IsExcludedCheckBox.Enabled = True

        Me.ControlMeasureAPCDIDTextBox.ReadOnly = False
        Me.ControlMeasureTypeIDComboBox.Enabled = False
        Me.ControlMeasureDescriptionTextBox.ReadOnly = False
        Me.CompanyCommentTextBox.ReadOnly = False
        Me.APCDCommentTextBox.ReadOnly = False

        Me.AddPollutantPanel.Visible = True
        Me.ControlMeasurePollutantDataGridView.ReadOnly = False

        Me.ButtonPanel.Visible = True

    End Sub

    Private Sub ToggleShutDownButtonText()

        If (Me.m_controlMeasure.AddDate.Year = Date.Now.Year) Then
            Me.btnShutdown.Text = GlobalVariables.Words.Delete
        Else
            Me.btnShutdown.Text = GlobalVariables.Words.Shutdown
        End If

    End Sub

#Region "----- changed events -----"

    Private Sub ControlMeasureAPCDIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlMeasureAPCDIDTextBox.TextChanged
        If (Me.controlIsLoaded) Then
            Dim text As String = Me.ControlMeasureAPCDIDTextBox.Text.Trim
            If (text.Length > 0) Then
                Me.m_controlMeasure.ControlMeasureAPCDID = text
                Call Me.ToggleButtonStatus_FieldChanged()
                'Call Me.SetWhereAmIText()
            End If
        End If
    End Sub

    Private Sub ControlMeasureTypeIDComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlMeasureTypeIDComboBox.SelectedIndexChanged
        If (Me.controlIsLoaded) Then
            Me.m_controlMeasure.ControlMeasureTypeID = CInt(Me.ControlMeasureTypeIDComboBox.SelectedValue)
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub ControlMeasureDescriptionTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlMeasureDescriptionTextBox.TextChanged
        If (Me.controlIsLoaded) Then
            Dim text As String = Me.ControlMeasureDescriptionTextBox.Text.Trim
            If (text.Length = 0) Then
                Me.m_controlMeasure.SetControlMeasureDescriptionNull()
            Else
                Me.m_controlMeasure.ControlMeasureDescription = text
            End If
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub CompanyCommentTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyCommentTextBox.TextChanged
        If (Me.controlIsLoaded) Then
            Dim text As String = Me.CompanyCommentTextBox.Text.Trim
            Select Case text
                Case String.Empty
                    Me.m_controlMeasure.SetCompanyCommentNull()
                Case Else
                    Me.m_controlMeasure.CompanyComment = text
            End Select

            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub APCDCommentTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles APCDCommentTextBox.TextChanged
        If (Me.controlIsLoaded) Then
            Dim text As String = Me.APCDCommentTextBox.Text.Trim
            Select Case text
                Case String.Empty
                    Me.m_controlMeasure.SetAPCDCommentNull()
                Case Else
                    Me.m_controlMeasure.APCDComment = text
            End Select
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub IsExcludedCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsExcludedCheckBox.CheckedChanged
        If (Me.controlIsLoaded) Then
            Me.m_controlMeasureYear.IsExcluded = Me.IsExcludedCheckBox.Checked
            Call Me.ToggleButtonStatus_FieldChanged()
            Me.m_isExcluded_Changed = True
        End If
    End Sub

    Private Sub ToggleButtonStatus_FieldChanged()

        If (Me.controlIsLoaded) Then
            Me.m_changedValueCount += 1
            Me.btnShutdown.Enabled = False
            Me.btnApprove.Enabled = False
            Me.btnSave.Enabled = True
        End If

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

#End Region '----- changed events -----

#Region "----- cancel and save events and methods -----"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If ((Not Me.m_controlMeasure.RowState = DataRowState.Unchanged) OrElse (Me.m_changedValueCount > 0)) Then
            If (MessageBox.Show("You have unsaved changes. Do you wish to save them?", "Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Call Me.SaveControlMeasure()
            End If
        End If

        For Each ctl As Control In Me.Controls
            Me.ErrorProvider1.SetError(ctl, String.Empty)
        Next

        RaiseEvent CancelButton_Pressed()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (Me.IsValidForm) Then

            If (Me.SaveControlMeasure) Then
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Modified)

                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()

                'load a new control measure history
                MainForm.EmissionsDataSet.ControlMeasureHistory.Clear()
                Call Me.LoadHistoryRecord_ControlMeasure()

                'copy the current list of pollutants into the Original table
                Me.m_controlMeasurePollutants_ORIGINAL = CType(MainForm.EmissionsDataSet.ControlMeasurePollutant.Copy, EmissionsInventory.EmissionsDataSet.ControlMeasurePollutantDataTable)

                'clear the changed count
                Me.m_changedValueCount = 0
            End If

            If (Me.m_isExcluded_Changed = True) Then
                Call Me.SaveControlMeasureYear()
                MainForm.EmissionsDataSet.ControlMeasureYearHistory.Clear()
                Call Me.LoadHistoryRecord_ControlMeasureYear()
                Me.m_isExcluded_Changed = False
            End If

        End If

    End Sub

    Private Sub CreateControlMeasurePollutantHistoryRows(ByVal changes As EmissionsDataSet.ControlMeasurePollutantDataTable)
        'for each row in the changed table that is MODIFIED get the original row from the ORIGINAL table to create the history row
        For Each row As EmissionsDataSet.ControlMeasurePollutantRow In changes.Rows
            If (row.RowState = DataRowState.Modified) Then
                Dim selectString As String = EmissionsDataSet.ControlMeasurePollutant.ControlMeasurePollutantIDColumn.ColumnName _
                                           & Tools.Constants.Character.EqualSign _
                                           & row.ControlMeasurePollutantID
                Dim originalRow() As EmissionsDataSet.ControlMeasurePollutantRow = CType(Me.m_controlMeasurePollutants_ORIGINAL.Select(selectString), EmissionsInventory.EmissionsDataSet.ControlMeasurePollutantRow())
                Call Me.LoadHistoryRecord_ControlMeasurePollutant(originalRow(0))
            End If
        Next
    End Sub

    Private Sub LoadHistoryRecord_ControlMeasurePollutant(ByVal row As EmissionsDataSet.ControlMeasurePollutantRow)

        Dim rowControlMeasurePollutantHistory As EmissionsDataSet.ControlMeasurePollutantHistoryRow = MainForm.EmissionsDataSet.ControlMeasurePollutantHistory.NewControlMeasurePollutantHistoryRow
        With rowControlMeasurePollutantHistory
            .ControlMeasurePollutantID = row.ControlMeasurePollutantID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ReductionEfficiency = row.ReductionEfficiency
        End With
        MainForm.EmissionsDataSet.ControlMeasurePollutantHistory.Rows.Add(rowControlMeasurePollutantHistory)

    End Sub

#End Region '----- cancel and save events and methods -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim blnIsValidForm As Boolean

        If (Not Me.IsValidAPCDID) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidControlMeasureType) Then
            blnIsValidForm = False
        Else
            blnIsValidForm = True
        End If

        Return blnIsValidForm

    End Function

    Private Function IsValidAPCDID() As Boolean

        Dim dataIsValid As Boolean

        If (Me.ControlMeasureAPCDIDTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.ControlMeasureAPCDIDTextBox, "Please enter the APCD ID.")
            Me.ErrorProvider1.SetIconAlignment(Me.ControlMeasureAPCDIDTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.ControlMeasureAPCDIDTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidControlMeasureType() As Boolean

        Dim dataIsValid As Boolean

        If (Me.ControlMeasureTypeIDComboBox.SelectedIndex = -1) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.ControlMeasureTypeIDComboBox, "Please select a type.")
            Me.ErrorProvider1.SetIconAlignment(Me.ControlMeasureTypeIDComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ControlMeasureTypeIDComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    ''' <summary>
    ''' Checks whether the list of pollutants controlled by the control measure make sense.
    ''' </summary>
    ''' <returns>True if valid</returns>
    ''' <remarks>
    ''' 2013-10-15 BJF: Added check for shutdown status, so pollutants are not required if CM is shut down.
    ''' </remarks>
    Private Function IsValidPollutants() As Boolean

        Dim dataIsValid As Boolean

        If Me.m_inventoryStatus = GlobalVariables.InventoryStatus.Shutdown Then
            ' There don't need to be any pollutants.
            dataIsValid = True
        Else
            If (MainForm.EmissionsDataSet.ControlMeasurePollutant.Rows.Count = 0) Then
                MessageBox.Show("Please add a pollutant.", My.Application.Info.ProductName, _
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                For rowCount As Int32 = 0 To MainForm.EmissionsDataSet.ControlMeasurePollutant.Rows.Count - 1
                    Dim row As EmissionsDataSet.ControlMeasurePollutantRow = CType(MainForm.EmissionsDataSet.ControlMeasurePollutant.Rows(rowCount), EmissionsInventory.EmissionsDataSet.ControlMeasurePollutantRow)
                    If (Not row.RowState = DataRowState.Deleted) Then
                        If (row.ReductionEfficiency <= 0) Then
                            Me.ControlMeasurePollutantDataGridView.Rows(rowCount).ErrorText = GlobalVariables.ErrorPrompt.Misc.ValueMustBeGreaterThan0AndLessThanOrEqualTo100
                            dataIsValid = False
                            Exit For
                        Else
                            Me.ControlMeasurePollutantDataGridView.Rows(rowCount).ErrorText = String.Empty
                            dataIsValid = True
                        End If
                    End If
                Next

            End If
        End If

        Return dataIsValid

    End Function

#End Region '----- Validation -----

#Region "----- buttons -----"

    Private Sub btnShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShutdown.Click

        Dim response As DialogResult

        If (Me.btnShutdown.Text = GlobalVariables.Words.Shutdown) Then
            response = MessageBox.Show("Are you sure you want to shut down this control measure?", "Shut down " & Me.m_controlMeasure.ControlMeasureAPCDID, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                Call Me.Shutdown()
            End If

        ElseIf (Me.btnShutdown.Text = GlobalVariables.Words.Delete) Then
            response = MessageBox.Show("This action cannot be undone. Are you sure?", "Delete " & Me.m_controlMeasure.ControlMeasureAPCDID, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                Me.m_controlMeasure.Delete()
                MainForm.ControlMeasureTableAdapter.Update(MainForm.EmissionsDataSet.ControlMeasure)
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Deleted)
            End If
        End If

    End Sub

    Private Sub Shutdown()

        Me.m_controlMeasure.EndDate = New Date(Me.m_controlMeasureYear.EmissionYear - 1, 12, 31)

        If (Me.SaveControlMeasure) Then
            RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Shutdown)

            Call Me.SetInventoryStatus()
            Call Me.SetControlStatus()

            Call Me.LoadHistoryRecord_ControlMeasure()
        End If

    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

        If (Me.btnApprove.Text = GlobalVariables.Words.Approve) Then
            If ((Me.m_controlMeasureYear.IsExcluded) OrElse (Me.IsValidPollutants)) Then
                Call Me.Approve()
            End If
        ElseIf (Me.btnApprove.Text = GlobalVariables.Words.Unapprove) Then
            Call Me.UnApprove()
        End If

    End Sub

    Private Sub Approve()

        Dim frm As New ApproveForm(Me.m_controlMeasureYear, "Approve Control Measure")
        Dim response As DialogResult = frm.ShowDialog
        If (response = DialogResult.OK) Then
            Call Me.LoadHistoryRecord_ControlMeasureYear()

            With Me.m_controlMeasureYear
                .ApprovalEmployeeID = GlobalVariables.Employee.EmployeeID
                .ApprovalDate = Date.Now
            End With

            If (Me.SaveControlMeasureYear) Then
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Approved)

                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()

                MainForm.EmissionsDataSet.ControlMeasureYearHistory.Clear()
            End If
        End If

    End Sub

    Private Sub UnApprove()

        Dim frm As New ApproveForm(Me.m_controlMeasureYear, "Un-approve Control Measure")
        Dim response As DialogResult = frm.ShowDialog
        If (response = DialogResult.OK) Then
            Call Me.LoadHistoryRecord_ControlMeasureYear()

            With Me.m_controlMeasureYear
                .SetApprovalEmployeeIDNull()
                .SetApprovalDateNull()
            End With

            If (Me.SaveControlMeasureYear) Then
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.UnApproved)

                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()

                MainForm.EmissionsDataSet.ControlMeasureYearHistory.Clear()
            End If
        End If

    End Sub

#End Region '----- buttons -----

    Private Sub LoadHistoryRecord_ControlMeasureYear()

        Dim row As EmissionsDataSet.ControlMeasureYearHistoryRow = MainForm.EmissionsDataSet.ControlMeasureYearHistory.NewControlMeasureYearHistoryRow
        With row
            .ControlMeasureYearID = Me.m_controlMeasureYear.ControlMeasureYearID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ControlMeasureID = Me.m_controlMeasureYear.ControlMeasureID
            .EmissionYear = Me.m_controlMeasureYear.EmissionYear
            .IsExcluded = Me.m_controlMeasureYear.IsExcluded

            If (Me.m_controlMeasureYear.IsDoneDateNull) Then
                .SetDoneDateNull()
            Else
                .DoneDate = Me.m_controlMeasureYear.DoneDate
            End If

            If (Me.m_controlMeasureYear.IsDoneByNull) Then
                .SetDoneByNull()
            Else
                .DoneBy = Me.m_controlMeasureYear.DoneBy
            End If

            If (Me.m_controlMeasureYear.IsApprovalEmployeeIDNull) Then
                .SetApprovalEmployeeIDNull()
            Else
                .ApprovalEmployeeID = Me.m_controlMeasureYear.ApprovalEmployeeID
            End If

            If (Me.m_controlMeasureYear.IsApprovalDateNull) Then
                .SetApprovalDateNull()
            Else
                .ApprovalDate = Me.m_controlMeasureYear.ApprovalDate
            End If

            .ApprovalComment = Me.m_controlMeasureYear.ApprovalComment

        End With
        MainForm.EmissionsDataSet.ControlMeasureYearHistory.Rows.Add(row)

    End Sub

#Region "----- gridview -----"

    Private Sub ControlMeasurePollutantDataGridView_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ControlMeasurePollutantDataGridView.CellValueChanged

        If (Me.m_controlIsLoaded = True) Then
            Call Me.ToggleButtonStatus_FieldChanged()
        End If

    End Sub

    Private Sub ControlMeasurePollutantDataGridView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ControlMeasurePollutantDataGridView.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

#End Region '----- gridview -----

    Private Function SaveControlMeasure() As Boolean

        Dim saved As Boolean

        Dim pollutantChanges As EmissionsDataSet.ControlMeasurePollutantDataTable = CType(MainForm.EmissionsDataSet.ControlMeasurePollutant.GetChanges, EmissionsInventory.EmissionsDataSet.ControlMeasurePollutantDataTable)
        If (Not pollutantChanges Is Nothing) Then
            Call Me.CreateControlMeasurePollutantHistoryRows(pollutantChanges)
            For Each row As EmissionsDataSet.ControlMeasurePollutantRow In pollutantChanges.Rows
                If (row.RowState = DataRowState.Added) Then
                    row.ControlMeasureID = Me.m_controlMeasure.ControlMeasureID
                End If
            Next
        End If


        Try
            MainForm.ControlMeasureTableAdapter.Update(MainForm.EmissionsDataSet.ControlMeasure)
            MainForm.ControlMeasureHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ControlMeasureHistory)

            MainForm.ControlMeasurePollutantTableAdapter.Update(MainForm.EmissionsDataSet.ControlMeasurePollutant)
            MainForm.ControlMeasurePollutantHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ControlMeasurePollutantHistory)

            saved = True
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            If (ex.Message.IndexOf("ReductionEfficiency") > 0) Then
                '
            Else
                MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            saved = False
        End Try

        Return saved

    End Function

    Private Function SaveControlMeasureYear() As Boolean

        Dim saved As Boolean

        Try
            MainForm.ControlMeasureYearTableAdapter.Update(MainForm.EmissionsDataSet.ControlMeasureYear)
            MainForm.ControlMeasureYearHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ControlMeasureYearHistory)
            saved = True
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saved = False
        End Try

        Return saved

    End Function

#Region "----- add pollutants to CM -----"

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim text As String = Me.reductionEfficiencyTextBox.Text.Trim

        If ((Me.PollutantComboBox.SelectedIndex = -1) OrElse (text.Length = 0)) Then
            MessageBox.Show("Pick a pollutant and enter a reduction efficiency to add it to the grid.")
        Else
            If (IsNumeric(text)) Then
                Dim reductionEfficiency As Decimal = CDec(text)
                If ((reductionEfficiency < 1) OrElse (reductionEfficiency >= 100)) Then
                    MessageBox.Show("Reduction efficiency must be at least 1 and less than 100.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Call Me.AddPollutant(CInt(Me.PollutantComboBox.SelectedValue), reductionEfficiency)
                    Me.PollutantComboBox.SelectedIndex = -1
                    Me.reductionEfficiencyTextBox.Text = String.Empty
                End If
            End If
        End If

    End Sub

    Private Sub AddPollutant(ByVal pollutantID As Int32, ByVal reductionEfficiency As Decimal)

        Dim row As EmissionsDataSet.ControlMeasurePollutantRow = MainForm.EmissionsDataSet.ControlMeasurePollutant.NewControlMeasurePollutantRow
        With row
            .ControlMeasureID = Me.m_controlMeasure.ControlMeasureID
            .PollutantID = pollutantID
            .EmissionYear = Me.m_emissionYear.EmissionYear
            .ReductionEfficiency = reductionEfficiency
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With
        MainForm.EmissionsDataSet.ControlMeasurePollutant.Rows.Add(row)
        Try
            MainForm.ControlMeasurePollutantTableAdapter.Update(row)
        Catch ex As Exception
            MessageBox.Show("Selected pollutant already exists.", "Duplicate Pollutant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            row.Delete()
        End Try

    End Sub

#End Region '----- add pollutants to CM -----

End Class
