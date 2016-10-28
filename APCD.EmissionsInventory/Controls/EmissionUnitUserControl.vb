Imports System.Text

Public Class EmissionUnitUserControl

    'counters
    Private m_changedValueCount As Int32

    'events
    Public Event SaveButton_Pressed(ByVal state As GlobalVariables.InventoryStatus)
    Public Event CancelButton_Pressed()

    'object variables
    Private m_emissionYear As EmissionsDataSet.EmissionYearRow
    Private m_emissionUnit As EmissionsDataSet.PlantEmissionUnitRow
    Private m_emissionUnitYear As EmissionsDataSet.PlantEmissionUnitYearRow

    'status variables
    Private m_inventoryStatus As GlobalVariables.InventoryStatus
    Private m_okToApprove As Boolean = False
    Private m_okToShutdown As Boolean = False

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

    Private Sub EmissionUnitUserControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.controlIsLoaded = False
        Call Me.LoadComboBox()
        Me.controlIsLoaded = True

    End Sub

    Private Sub LoadComboBox()

        Tools.WindowsForms.LoadComboBox(GlobalVariables.LookupTable.EmissionUnitType, Me.EmissionUnitTypeComboBox)

    End Sub

    Friend Sub LoadObjectVariables(ByVal emissionYear As EmissionsDataSet.EmissionYearRow, ByVal emissionUnit As EmissionsDataSet.PlantEmissionUnitRow, ByVal emissionUnitYear As EmissionsDataSet.PlantEmissionUnitYearRow, ByVal okToApprove As Boolean, ByVal okToShutdown As Boolean)

        Me.m_emissionYear = emissionYear
        Me.m_emissionUnit = emissionUnit
        Me.m_emissionUnitYear = emissionUnitYear

        Me.m_okToApprove = okToApprove
        Me.m_okToShutdown = okToShutdown

        Call Me.LoadHistoryRecord_PlantEmissionUnit()
        Call Me.LoadHistoryRecord_PlantEmissionUnitYear()

        Me.m_changedValueCount = 0

    End Sub

    Friend Sub LoadControls()

        With Me.m_emissionUnit
            'set shut down label
            If (.IsEndDateNull) Then
                Me.ShutdownMessageLabel.Text = String.Empty
            Else
                Me.ShutdownMessageLabel.Text = "Shut down in " & .EndDate.Year
            End If

            Me.IsExcludedCheckBox.Checked = Me.m_emissionUnitYear.IsExcluded

            Me.EmissionUnitAPCDIDTextBox.Text = .EmissionUnitAPCDID
            Me.EmissionUnitTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.EmissionUnitTypeComboBox, .EmissionUnitTypeID)
            Me.CompanyDescriptionTextBox.Text = .EmissionUnitDescription
            Me.CompanyCommentTextBox.Text = .CommentPublic
            Me.APCDCommentTextBox.Text = .CommentInternal
        End With

    End Sub

    Friend Sub SetInventoryStatus()

        If (GlobalVariables.UserRole = GlobalVariables.Role.Guest) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.None

        ElseIf (Not Me.m_emissionYear.IsEmissionsInEISDateNull) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.EmissionYearClosed

        ElseIf (Not Me.m_emissionUnitYear.IsApprovalDateNull) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.Approved

        ElseIf (Not Me.m_emissionUnit.IsEndDateNull) Then
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

    Private Sub ToggleShutdownButtonText()

        If (Me.m_emissionUnit.EmissionUnitEISID < 0) Then
            Me.btnShutdown.Text = GlobalVariables.Words.Delete
        Else
            Me.btnShutdown.Text = GlobalVariables.Words.Shutdown
        End If

    End Sub


    Private Sub DisableEditing()

        Me.IsExcludedCheckBox.Enabled = False
        Me.ButtonPanel.Visible = False

        Me.EmissionUnitAPCDIDTextBox.ReadOnly = True
        Me.EmissionUnitTypeComboBox.Enabled = False
        Me.CompanyDescriptionTextBox.ReadOnly = True
        Me.CompanyCommentTextBox.ReadOnly = True
        Me.APCDCommentTextBox.ReadOnly = True

    End Sub

    Private Sub EnableEditing()

        Me.IsExcludedCheckBox.Enabled = True
        Me.ButtonPanel.Visible = True

        Me.EmissionUnitAPCDIDTextBox.ReadOnly = False
        Me.EmissionUnitTypeComboBox.Enabled = False
        Me.CompanyDescriptionTextBox.ReadOnly = False
        Me.CompanyCommentTextBox.ReadOnly = False
        Me.APCDCommentTextBox.ReadOnly = False

    End Sub

#Region "----- changed events -----"

    Private Sub EmissionUnitTypeIDComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionUnitTypeComboBox.SelectedIndexChanged
        If (controlIsLoaded) Then
            Me.m_emissionUnit.EmissionUnitTypeID = CInt(Me.EmissionUnitTypeComboBox.SelectedValue)
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub EmissionUnitAPCDIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionUnitAPCDIDTextBox.TextChanged
        If (controlIsLoaded) Then
            Dim text As String = Me.EmissionUnitAPCDIDTextBox.Text.Trim
            If (text.Length > 0) Then
                Me.m_emissionUnit.EmissionUnitAPCDID = text
                Call Me.ToggleButtonStatus_FieldChanged()
                'Call Me.SetWhereAmIText()
            End If
        End If
    End Sub

    Private Sub CompanyDescriptionTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyDescriptionTextBox.TextChanged
        If (controlIsLoaded) Then
            Dim text As String = Me.CompanyDescriptionTextBox.Text.Trim
            If (text.Length = 0) Then
                Me.m_emissionUnit.SetEmissionUnitDescriptionNull()
            Else
                Me.m_emissionUnit.EmissionUnitDescription = text
            End If
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub CompanyCommentTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyCommentTextBox.TextChanged
        If (controlIsLoaded) Then
            Dim text As String = Me.CompanyCommentTextBox.Text.Trim
            If (text.Length = 0) Then
                Me.m_emissionUnit.SetCommentPublicNull()
            Else
                Me.m_emissionUnit.CommentPublic = text
            End If
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub APCDCommentTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles APCDCommentTextBox.TextChanged
        If (controlIsLoaded) Then
            Dim text As String = Me.APCDCommentTextBox.Text.Trim
            If (text.Length = 0) Then
                Me.m_emissionUnit.SetCommentInternalNull()
            Else
                Me.m_emissionUnit.CommentInternal = text
            End If
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub IsExcludedCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsExcludedCheckBox.CheckedChanged
        If (controlIsLoaded) Then
            Me.m_emissionUnitYear.IsExcluded = Me.IsExcludedCheckBox.Checked
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
        Call Me.ToggleShutdownButtonText()
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

        If ((Not Me.m_emissionUnit.RowState = DataRowState.Unchanged) OrElse (Me.m_changedValueCount > 0)) Then
            If (MessageBox.Show("You have unsaved changes. Do you wish to save them?", "Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Call Me.SaveEmissionUnit()
            End If
        End If

        For Each ctl As Control In Me.Controls
            Me.ErrorProvider1.SetError(ctl, String.Empty)
        Next

        RaiseEvent CancelButton_Pressed()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (Me.IsValidForm) Then

            If (Me.SaveEmissionUnit()) Then

                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Modified)

                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()

                MainForm.EmissionsDataSet.PlantEmissionUnitHistory.Clear()
                Call Me.LoadHistoryRecord_PlantEmissionUnit()

                Me.m_changedValueCount = 0
            End If

            If (Me.m_isExcluded_Changed = True) Then
                Call Me.SaveEmissionUnitYear()
                MainForm.EmissionsDataSet.PlantEmissionUnitYearHistory.Clear()
                Call Me.LoadHistoryRecord_PlantEmissionUnitYear()
                Me.m_isExcluded_Changed = False
            End If

        End If

    End Sub

#End Region '----- save the data -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim blnIsFormValid As Boolean

        If (Not Me.IsValidEmissionUnitType) Then
            blnIsFormValid = False
        ElseIf (Not Me.IsValidAPCDID) Then
            blnIsFormValid = False
        Else
            blnIsFormValid = True
        End If

        Return blnIsFormValid

    End Function


    Private Function IsValidEmissionUnitType() As Boolean

        Dim dataIsValid As Boolean

        If (Me.EmissionUnitTypeComboBox.SelectedIndex = -1) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.EmissionUnitTypeComboBox, "Please select an Emission Unit Type")
            Me.ErrorProvider1.SetIconAlignment(Me.EmissionUnitTypeComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.EmissionUnitTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidAPCDID() As Boolean

        Dim dataIsValid As Boolean

        If (EmissionUnitAPCDIDTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(EmissionUnitAPCDIDTextBox, "Please enter the APCD ID.")
            Me.ErrorProvider1.SetIconAlignment(EmissionUnitAPCDIDTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(EmissionUnitAPCDIDTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

#End Region '----- Validation -----

    Private Sub btnShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShutdown.Click

        Dim response As DialogResult

        If (Me.btnShutdown.Text = GlobalVariables.Words.Shutdown) Then
            If (Me.m_okToShutdown) Then
                response = MessageBox.Show("Are you sure you want to shut down this emission unit?", "Shut down " & Me.m_emissionUnit.PlantEmissionUnitName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (response = Windows.Forms.DialogResult.Yes) Then
                    Call Me.Shutdown()
                End If
            Else
                MessageBox.Show("1 or more processes still need to be shut down for this EU.", "Action Canceled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        ElseIf (Me.btnShutdown.Text = GlobalVariables.Words.Delete) Then
            response = MessageBox.Show("This action cannot be undone. Are you sure?", "Delete " & Me.m_emissionUnit.EmissionUnitAPCDID, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                Me.m_emissionUnit.Delete()
                Call Me.SaveEmissionUnit()
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Deleted)
            End If
        End If

    End Sub

    Private Sub Shutdown()

        'to shutdown set the end date in EmissionUnit...
        Me.m_emissionUnit.EndDate = New Date(Me.m_emissionUnitYear.EmissionYear - 1, 12, 31)

        '... and operating status to PS in EmissionUnitYear (load a history rec first)
        Call Me.LoadHistoryRecord_PlantEmissionUnitYear()
        Me.m_emissionUnitYear.OperatingStatusTypeEISID = GlobalVariables.OperatingStatus.Shutdown

        'now save both
        If ((Me.SaveEmissionUnit()) AndAlso (Me.SaveEmissionUnitYear())) Then
            RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Shutdown)

            Call Me.SetInventoryStatus()
            Call Me.SetControlStatus()

            Call Me.LoadHistoryRecord_PlantEmissionUnit()
            MainForm.EmissionsDataSet.PlantEmissionUnitYearHistory.Clear()
        End If

    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

        If (Me.btnApprove.Text = GlobalVariables.Words.Approve) Then
            If (Me.m_okToApprove) Then
                Call Me.Approve()
            Else
                MessageBox.Show("1 or more processes still need to be approved.", "Action Canceled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf (Me.btnApprove.Text = GlobalVariables.Words.Unapprove) Then
            Call Me.UnApprove()
        End If

    End Sub

    Private Sub Approve()

        Dim frm As New ApproveForm(Me.m_emissionUnitYear, "Approve Emission Unit")
        Dim response As DialogResult = frm.ShowDialog
        If (response = DialogResult.OK) Then
            Call Me.LoadHistoryRecord_PlantEmissionUnitYear()

            With Me.m_emissionUnitYear
                .ApprovalEmployeeID = GlobalVariables.Employee.EmployeeID
                .ApprovalDate = Date.Now
            End With

            If (Me.SaveEmissionUnitYear) Then
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Approved)

                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()

                MainForm.EmissionsDataSet.PlantEmissionUnitYearHistory.Clear()
            End If

        End If

    End Sub

    Private Sub UnApprove()

        Dim frm As New ApproveForm(Me.m_emissionUnitYear, "Un-approve Emission Unit")
        Dim response As DialogResult = frm.ShowDialog
        If (response = DialogResult.OK) Then
            Call Me.LoadHistoryRecord_PlantEmissionUnitYear()

            With Me.m_emissionUnitYear
                .SetApprovalEmployeeIDNull()
                .SetApprovalDateNull()
            End With

            If (Me.SaveEmissionUnitYear) Then
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.UnApproved)

                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()

                MainForm.EmissionsDataSet.PlantEmissionUnitYearHistory.Clear()
            End If

        End If

    End Sub

    Private Sub LoadHistoryRecord_PlantEmissionUnit()

        Dim row As EmissionsDataSet.PlantEmissionUnitHistoryRow = MainForm.EmissionsDataSet.PlantEmissionUnitHistory.NewPlantEmissionUnitHistoryRow
        With row
            .PlantEmissionUnitID = Me.m_emissionUnit.PlantEmissionUnitID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .PlantEmissionUnitName = Me.m_emissionUnit.PlantEmissionUnitName
            .PlantID = Me.m_emissionUnit.PlantID
            .EmissionUnitTypeID = Me.m_emissionUnit.EmissionUnitTypeID
            .EmissionUnitAPCDID = Me.m_emissionUnit.EmissionUnitAPCDID
            .EmissionUnitEISID = Me.m_emissionUnit.EmissionUnitEISID
            .EmissionUnitDescription = Me.m_emissionUnit.EmissionUnitDescription
            .CommentPublic = Me.m_emissionUnit.CommentPublic
            .CommentInternal = Me.m_emissionUnit.CommentInternal
            .BeginDate = Me.m_emissionUnit.BeginDate
            If (Me.m_emissionUnit.IsEndDateNull) Then
                .SetEndDateNull()
            Else
                .EndDate = Me.m_emissionUnit.EndDate
            End If
        End With
        MainForm.EmissionsDataSet.PlantEmissionUnitHistory.Rows.Add(row)

    End Sub

    Private Sub LoadHistoryRecord_PlantEmissionUnitYear()

        Dim row As EmissionsDataSet.PlantEmissionUnitYearHistoryRow = MainForm.EmissionsDataSet.PlantEmissionUnitYearHistory.NewPlantEmissionUnitYearHistoryRow

        With row
            .PlantEmissionUnitYearID = Me.m_emissionUnitYear.PlantEmissionUnitYearID
            .PlantEmissionUnitID = Me.m_emissionUnitYear.PlantEmissionUnitID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .EmissionYear = Me.m_emissionUnitYear.EmissionYear
            .OperatingStatusTypeEISID = Me.m_emissionUnitYear.OperatingStatusTypeEISID
            .IsExcluded = Me.m_emissionUnitYear.IsExcluded

            If (Me.m_emissionUnitYear.IsDoneDateNull) Then
                .SetDoneDateNull()
            Else
                .DoneDate = Me.m_emissionUnitYear.DoneDate
            End If

            If (Me.m_emissionUnitYear.IsDoneByNull) Then
                .SetDoneByNull()
            Else
                .DoneBy = Me.m_emissionUnitYear.DoneBy
            End If

            If (Me.m_emissionUnitYear.IsApprovalEmployeeIDNull) Then
                .SetApprovalEmployeeIDNull()
            Else
                .ApprovalEmployeeID = Me.m_emissionUnitYear.ApprovalEmployeeID
            End If

            If (Me.m_emissionUnitYear.IsApprovalDateNull) Then
                .SetApprovalDateNull()
            Else
                .ApprovalDate = Me.m_emissionUnitYear.ApprovalDate
            End If

            .ApprovalComment = Me.m_emissionUnitYear.ApprovalComment

        End With
        MainForm.EmissionsDataSet.PlantEmissionUnitYearHistory.Rows.Add(row)

    End Sub

    Private Function SaveEmissionUnit() As Boolean

        Try
            MainForm.PlantEmissionUnitTableAdapter.Update(MainForm.EmissionsDataSet.PlantEmissionUnit)
            MainForm.PlantEmissionUnitHistoryTableAdapter.Update(MainForm.EmissionsDataSet.PlantEmissionUnitHistory)

            SaveEmissionUnit = True
        Catch ex As DataException
            If (ex.Message.Contains("duplicate values")) Then
                MessageBox.Show(GlobalVariables.ErrorPrompt.Database.DuplicateKey, "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                GlobalMethods.HandleError(ex)
                MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SaveEmissionUnit = False
        End Try
        Return SaveEmissionUnit

    End Function

    Private Function SaveEmissionUnitYear() As Boolean

        Dim saved As Boolean

        Try
            MainForm.PlantEmissionUnitYearTableAdapter.Update(MainForm.EmissionsDataSet.PlantEmissionUnitYear)
            MainForm.PlantEmissionUnitYearHistoryTableAdapter.Update(MainForm.EmissionsDataSet.PlantEmissionUnitYearHistory)
            saved = True
        Catch ex As DataException
            If (ex.Message.Contains("duplicate values")) Then
                MessageBox.Show(GlobalVariables.ErrorPrompt.Database.DuplicateKey, "Duplication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                GlobalMethods.HandleError(ex)
                MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saved = False
        End Try

        Return saved

    End Function

End Class
