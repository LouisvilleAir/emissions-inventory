Imports APCD.Emissions
Imports System.Text

Public Class PlantEmissionUnitEditForm

    Sub New()
        InitializeComponent()
    End Sub


    'control states
    Private m_blnPlantEmissionUnitName_Changed As Boolean 'set from constructor
    Private m_blnEmissionUnitTypeID_Changed As Boolean = False
    Private m_blnEmissionUnitAPCDID_Changed As Boolean = False
    Private m_blnEmissionUnitDescription_Changed As Boolean = False
    Private m_blnCommentPublic_Changed As Boolean = False
    Private m_blnCommentInternal_Changed As Boolean = False
    Private m_blnBeginDate_Changed As Boolean = False

    Private m_blnFormIsLoaded As Boolean = False

    Private Property EmissionUnitTypeTableAdapter As Object

    Private Sub PlantEmissionUnitEditForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Me.LoadComboBoxes()
        Call Me.LoadControls()

        Me.m_blnFormIsLoaded = True

    End Sub

    Private Sub LoadComboBoxes()

        Dim dtbEmissionUnitType As DataTable = Utility.EmissionUnitTypeUtility.GetLookupTable
        Tools.WindowsForms.LoadComboBox(dtbEmissionUnitType, Me.EmissionUnitTypeComboBox, True)

    End Sub

    Private Sub LoadControls()

        Call Me.AssignControlValues()
        Call Me.ToggleControlStatus()

    End Sub

    Private Sub AssignControlValues()

        With GlobalVariables.PlantEmissionUnitObject

            Me.PlantEmissionUnitNameTextBox.Text = .PlantEmissionUnitName

            Dim unitTypeSelectedIndex As Int32 = Tools.WindowsForms.GetIndexForValueMember(Me.EmissionUnitTypeComboBox, .EmissionUnitTypeID)
            Me.EmissionUnitTypeComboBox.SelectedIndex = unitTypeSelectedIndex

            Me.EmissionUnitAPCDIDTextBox.Text = .EmissionUnitAPCDID
            Me.EmissionUnitDescriptionTextBox.Text = .EmissionUnitDescription
            Me.CommentPublicTextBox.Text = .CommentPublic
            Me.CommentInternalTextBox.Text = .CommentInternal

            Try
                Me.BeginDateDateTimePicker.Value = .BeginDate
                Me.BeginDateTextBox.Text = Format(.BeginDate, GlobalVariables.DateFormat._Short)
            Catch ex As Exception
                Me.BeginDateTextBox.Text = String.Empty
            End Try

        End With

    End Sub

    Private Sub ToggleControlStatus()

        With GlobalVariables.PlantEmissionUnitObject

            If (.EmissionUnitEISID < 0) Then
                Me.EmissionUnitTypeComboBox.Enabled = False
                Me.EmissionUnitAPCDIDTextBox.Enabled = True
                Me.ShutdownButton.Text = GlobalVariables.Words.Delete
            Else
                Me.EmissionUnitTypeComboBox.Enabled = False
                Me.EmissionUnitAPCDIDTextBox.Enabled = False

                If (.EndDate = Nothing) Then
                    Me.ShutdownButton.Text = GlobalVariables.Words.Shutdown
                    Me.Label2.Visible = False
                Else
                    Me.Label2.Text = "This EU was shut down on " & .EndDate.ToShortDateString
                    Me.Label2.Visible = True
                    Me.ShutdownButton.Text = GlobalVariables.Words.Startup
                End If
            End If

        End With

        'if there is a plantemissionUnitYear record for the EU it's approved; otherwise, it's not approved
        If (GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitYear Is Nothing) Then
            Me.btnApprove.Text = GlobalVariables.Words.Approve
        Else
            Me.btnApprove.Text = GlobalVariables.Words.Unapprove
        End If

        'if approved or shut down, disable controls 
        If ((Not GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitYear Is Nothing) OrElse (Not GlobalVariables.PlantEmissionUnitObject.EndDate = Nothing)) Then
            For Each ctl As Control In Me.Controls
                ctl.Enabled = False
            Next
        End If

        'toggle visibility of the Approve button
        If ((GlobalVariables.UserRole = GlobalVariables.Role.Programmer) _
             OrElse (GlobalVariables.UserRole = GlobalVariables.Role.Approver)) Then
            Me.btnApprove.Visible = True
        Else
            Me.btnApprove.Visible = False
        End If

        'status of the shutdown button
        If (GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitYear Is Nothing) Then
            Me.ShutdownButton.Enabled = True
        Else
            Me.ShutdownButton.Enabled = False
        End If

        'Cancel and Approve are always enabled
        Me.btnCancel.Enabled = True
        Me.btnApprove.Enabled = True

    End Sub


    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        If (Me.IsValidForm) Then
            Save()
            Me.Close()
        End If

    End Sub

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim blnIsFormValid As Boolean

        If (Not Me.IsValidPlantEmissionUnitName) Then
            blnIsFormValid = False
        ElseIf (Not Me.IsValidEmissionUnitType) Then
            blnIsFormValid = False
        ElseIf (Not Me.IsValidAPCDID) Then
            blnIsFormValid = False
        ElseIf (Not Me.IsValidEmissionUnitDescription) Then
            blnIsFormValid = False
        ElseIf (Not Me.IsValidBeginDate) Then
            blnIsFormValid = False
        Else
            blnIsFormValid = True
        End If

        Return blnIsFormValid

    End Function

    'plantEmissionUnit
    Private Function IsValidPlantEmissionUnitName() As Boolean

        Dim dataIsValid As Boolean

        If (Me.PlantEmissionUnitNameTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(PlantEmissionUnitNameTextBox, "Please enter an Emission Unit Name")
            Me.ErrorProvider1.SetIconAlignment(PlantEmissionUnitNameTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(PlantEmissionUnitNameTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    'emissionunitType
    Private Function IsValidEmissionUnitType() As Boolean

        Dim dataIsValid As Boolean

        If (EmissionUnitTypeComboBox.SelectedIndex < 1) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(EmissionUnitTypeComboBox, "Please select an Emission Unit Type")
            Me.ErrorProvider1.SetIconAlignment(EmissionUnitTypeComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(EmissionUnitTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    'APCD ID
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

    'todo 20111109: this is exactly the same as every form with a begin date; move to business rule class and reuse the code.
    Private Function IsValidBeginDate() As Boolean

        Dim dataIsValid As Boolean

        If (Me.BeginDateTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.BeginDateTextBox, "Begin date is required.")
            Me.ErrorProvider1.SetIconAlignment(Me.BeginDateTextBox, ErrorIconAlignment.MiddleLeft)

        ElseIf (Not IsDate(Me.BeginDateTextBox.Text.Trim)) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.BeginDateTextBox, "Invalid date.")
            Me.ErrorProvider1.SetIconAlignment(Me.BeginDateTextBox, ErrorIconAlignment.MiddleLeft)

        ElseIf (CDate(Me.BeginDateTextBox.Text.Trim).Year > CInt(My.Settings.CurrentEmissionYear)) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.BeginDateTextBox, "Begin date year cannot be after the current emission year.")
            Me.ErrorProvider1.SetIconAlignment(Me.BeginDateTextBox, ErrorIconAlignment.MiddleLeft)

        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.BeginDateTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    'description
    Private Function IsValidEmissionUnitDescription() As Boolean

        Dim dataIsValid As Boolean

        If (EmissionUnitDescriptionTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(EmissionUnitDescriptionTextBox, "Please enter an emission unit description.")
            Me.ErrorProvider1.SetIconAlignment(EmissionUnitDescriptionTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(EmissionUnitDescriptionTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function


#End Region '----- Validation -----

#Region "----- save the data -----"

    Private Function Save() As Boolean

        Dim savedStatus As Boolean

        Call Me.CreateHistoryOjbect()
        Call Me.AssignObjectVariables()
        Try
            GlobalVariables.PlantEmissionUnitObject.Update()
            savedStatus = True
        Catch ex As Exception
            GlobalVariables.ApplicationLog.AppendLine(ex.Message)
            GlobalVariables.ApplicationLog.AppendLine(GlobalVariables.PlantEmissionUnitObject.ToString)
            If (ex.Message = GlobalVariables.ErrorMessage.Database.DuplicateRecord) Then
                MessageBox.Show(GlobalVariables.ErrorPrompt.Database.APCDIDAlreadyExists, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            GlobalVariables.PlantEmissionUnitObject = Nothing
            savedStatus = False
        End Try

        Return savedStatus

    End Function

    Private Sub CreateHistoryOjbect()

        Dim changeNotes As StringBuilder = New StringBuilder

        If (GlobalVariables.PlantEmissionUnitObject.EndDate = Nothing) Then

            If (Me.m_blnPlantEmissionUnitName_Changed = True) Then
                changeNotes.Append(Constants.PlantEmissionUnitConstants.FieldName.PlantEmissionUnitName)
            End If

            If (Me.m_blnEmissionUnitTypeID_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.PlantEmissionUnitConstants.FieldName.EmissionUnitTypeID)
            End If

            If (Me.m_blnEmissionUnitAPCDID_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.PlantEmissionUnitConstants.FieldName.EmissionUnitAPCDID)
            End If

            If (Me.m_blnEmissionUnitDescription_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.PlantEmissionUnitConstants.FieldName.EmissionUnitDescription)
            End If

            If (Me.m_blnCommentPublic_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.PlantEmissionUnitConstants.FieldName.CommentPublic)
            End If

            If (Me.m_blnCommentInternal_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.PlantEmissionUnitConstants.FieldName.CommentInternal)
            End If

            If (Me.m_blnBeginDate_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.PlantEmissionUnitConstants.FieldName.BeginDate)
            End If

        Else
            changeNotes.Append(Constants.PlantEmissionUnitConstants.FieldName.EndDate)
        End If

        'instantiate the object and set the current state of the PlantEmissionUnit
        GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitHistory = New Business.PlantEmissionUnitHistory
        With GlobalVariables.PlantEmissionUnitObject
            .PlantEmissionUnitHistory.BeginDate = .BeginDate
            .PlantEmissionUnitHistory.CommentInternal = .CommentInternal
            .PlantEmissionUnitHistory.CommentPublic = .CommentPublic
            .PlantEmissionUnitHistory.EmissionUnitAPCDID = .EmissionUnitAPCDID
            .PlantEmissionUnitHistory.EmissionUnitDescription = .EmissionUnitDescription
            .PlantEmissionUnitHistory.EmissionUnitEISID = .EmissionUnitEISID
            .PlantEmissionUnitHistory.EmissionUnitTypeID = .EmissionUnitTypeID
            .PlantEmissionUnitHistory.EndDate = .EndDate
            .PlantEmissionUnitHistory.PlantEmissionUnitID = .PlantEmissionUnitID
            .PlantEmissionUnitHistory.PlantEmissionUnitName = .PlantEmissionUnitName
            .PlantEmissionUnitHistory.PlantID = .PlantID
            .PlantEmissionUnitHistory.UpdateDate = Date.Now
            .PlantEmissionUnitHistory.UpdatedBy = GlobalVariables.Employee.EmployeeID
            .PlantEmissionUnitHistory.UpdateComment = changeNotes.ToString()
        End With

    End Sub

    Private Sub AssignObjectVariables()

        With GlobalVariables.PlantEmissionUnitObject
            .PlantEmissionUnitName = Me.PlantEmissionUnitNameTextBox.Text.Trim & String.Empty
            .EmissionUnitTypeID = CInt(Me.EmissionUnitTypeComboBox.SelectedValue)
            .EmissionUnitAPCDID = Me.EmissionUnitAPCDIDTextBox.Text.Trim
            'EISID remains the same
            .EmissionUnitDescription = Me.EmissionUnitDescriptionTextBox.Text.Trim
            .CommentPublic = Me.CommentPublicTextBox.Text.Trim
            .CommentInternal = Me.CommentInternalTextBox.Text.Trim
            If (BeginDateTextBox.Text = String.Empty) Then
                .BeginDate = Nothing
            Else
                .BeginDate = CDate(BeginDateTextBox.Text)
            End If
        End With

    End Sub

#End Region '----- save the data -----

    Private Sub ShutdownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownButton.Click

        Dim message As New StringBuilder
        Dim objProcesses As New Collections.Processs
        Dim response As DialogResult
        Dim blnCloseForm As Boolean = False
        Dim activeProcessList As String = Me.GetActiveProcessList

        If (Me.ShutdownButton.Text = GlobalVariables.Words.Shutdown) Then
            If (activeProcessList.Length > 0) Then
                message.Append("This emission unit has the following active process(s): ")
                message.Append(activeProcessList)
                message.AppendLine(" You must shut down each process before shutting down the emission unit.")
                MessageBox.Show(message.ToString, GlobalVariables.ErrorPrompt.Misc.ActionCancelled, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                message.AppendLine("Are you sure you want to shut down this emission unit?")
                response = MessageBox.Show(message.ToString, "Shutdown " & GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (response = Windows.Forms.DialogResult.Yes) Then
                    Dim strEndDate As String = InputBox("Enter shutdown date (MM/DD/YYYY)", Application.ProductName)
                    If (IsDate(strEndDate)) Then
                        'set the end date and update the db
                        GlobalVariables.PlantEmissionUnitObject.EndDate = CDate(strEndDate)
                        Call Me.CreateHistoryOjbect()
                        GlobalVariables.PlantEmissionUnitObject.Update()
                        blnCloseForm = True
                    Else
                        MessageBox.Show("Invalid date entered. Shut down cancelled.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            End If

        ElseIf (Me.ShutdownButton.Text = GlobalVariables.Words.Startup) Then
            message.AppendLine("Are you sure you want to start up this emission unit?")
            response = MessageBox.Show(message.ToString, "Shutdown " & GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                Dim strBeginDate As String = Trim(InputBox("Enter start up date (MM/DD/YYYY)", Application.ProductName))
                If (IsDate(strBeginDate)) Then
                    If (GlobalVariables.PlantEmissionUnitObject.EndDate < CDate(strBeginDate)) Then
                        'set the end date and update the db
                        Me.BeginDateTextBox.Text = strBeginDate
                        GlobalVariables.PlantEmissionUnitObject.BeginDate = CDate(strBeginDate)
                        GlobalVariables.PlantEmissionUnitObject.EndDate = Nothing
                        Call Me.CreateHistoryOjbect()
                        GlobalVariables.PlantEmissionUnitObject.Update()
                        blnCloseForm = True
                    Else
                        MessageBox.Show("Start up date cannot be before the shut down date. Start up cancelled.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("Invalid date entered. Start up cancelled.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

        ElseIf (Me.ShutdownButton.Text = GlobalVariables.Words.Delete) Then

            If (activeProcessList.Length > 0) Then
                message.AppendLine("This emission unit has the following active process(s): ")
                message.AppendLine(activeProcessList)
                message.AppendLine()
            End If
            message.AppendLine("This action cannot be undone. Are you sure?")
            response = MessageBox.Show(message.ToString, "Delete " & GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                GlobalVariables.PlantEmissionUnitObject.Delete()
                GlobalVariables.PlantEmissionUnitObject = Nothing
                blnCloseForm = True
            End If

        End If

        If (blnCloseForm = True) Then
            Me.Close()
        End If

    End Sub

    Private Function GetActiveProcessList() As String

        Dim activeCount As Int32
        Dim processIDs As New StringBuilder

        'get the active process count 
        For Each objProcess As Business.Process In GlobalVariables.PlantEmissionUnitObject.Processes
            If (objProcess.EndDate = Nothing) Then
                If (activeCount > 0) Then
                    processIDs.Insert(0, ", ")
                End If
                processIDs.Insert(0, objProcess.ProcessAPCDID)
                activeCount += 1
            End If
        Next

        Return processIDs.ToString

    End Function

    Private Function AllProcessesAreApproved() As Boolean

        Dim result As Boolean = True

        For Each objProcess As Business.Process In GlobalVariables.PlantEmissionUnitObject.Processes
            If (objProcess.ProcessYear Is Nothing) Then
                result = False
                Exit For
            End If
        Next

        Return result

    End Function

#Region "----- state changes -----"

    Private Sub PlantEmissionUnitNameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlantEmissionUnitNameTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_blnPlantEmissionUnitName_Changed = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.OKButton.Enabled = True

        End If
    End Sub

    Private Sub PlantEmissionUnitNameTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PlantEmissionUnitNameTextBox.Validating
        If (Me.m_blnFormIsLoaded = True) Then
            Call Me.IsValidPlantEmissionUnitName()
        End If
    End Sub

    ''Private Sub EmissionUnitTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionUnitTypeComboBox.SelectedIndexChanged
    ''    If (Me.m_blnFormIsLoaded = True) Then
    ''        Me.m_blnEmissionUnitTypeID_Changed = True
    ''        Me.btnApprove.Enabled = False
    ''        Me.ShutdownButton.Enabled = False
    ''        Me.OKButton.Enabled = True
    ''    End If
    ''End Sub

    ''Private Sub EmissionUnitTypeComboBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EmissionUnitTypeComboBox.Validating
    ''    If (Me.m_blnFormIsLoaded = True) Then
    ''        Call Me.IsValidEmissionUnitType()
    ''    End If
    ''End Sub

    Private Sub EmissionUnitDescriptionTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionUnitDescriptionTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_blnEmissionUnitDescription_Changed = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.OKButton.Enabled = True
        End If
    End Sub

    Private Sub EmissionUnitDescriptionTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EmissionUnitDescriptionTextBox.Validating
        If (Me.m_blnFormIsLoaded = True) Then
            Call Me.IsValidEmissionUnitDescription()
        End If
    End Sub

    Private Sub EmissionUnitAPCDIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionUnitAPCDIDTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_blnEmissionUnitAPCDID_Changed = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.OKButton.Enabled = True
        End If
    End Sub

    Private Sub CommentPublicTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CommentPublicTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_blnCommentPublic_Changed = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.OKButton.Enabled = True
        End If
    End Sub

    Private Sub CommentInternalTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CommentInternalTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_blnCommentInternal_Changed = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.OKButton.Enabled = True
        End If
    End Sub

    Private Sub BeginDateDateTimePicker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeginDateDateTimePicker.ValueChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.BeginDateTextBox.Text = Format(Me.BeginDateDateTimePicker.Value, GlobalVariables.DateFormat._Short)
        End If
    End Sub

    Private Sub BeginDateTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeginDateTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_blnBeginDate_Changed = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.OKButton.Enabled = True
        End If
    End Sub
#End Region '----- state changes -----



    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

        Dim message As New StringBuilder
        Dim response As DialogResult
        Dim closeTheForm As Boolean = False

        If (Me.btnApprove.Text = GlobalVariables.Words.Approve) Then
            If (Me.AllProcessesAreApproved) Then
                Dim activeProcessLIst As String = Me.GetActiveProcessList
                If (activeProcessLIst.Length > 0) Then
                    message.AppendLine("Approve this emission unit. Are you sure?")
                    response = MessageBox.Show(message.ToString, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (response = Windows.Forms.DialogResult.Yes) Then
                        Call Me.Approve()
                        closeTheForm = True
                    End If '(response = Windows.Forms.DialogResult.Yes)
                Else
                    'there are no active processes; is the emission unit shut down?
                    If (GlobalVariables.PlantEmissionUnitObject.EndDate = Nothing) Then
                        message.AppendLine("This emission unit has no active processes. It must either have 1 active process or be shut down in order to be approved.")
                        MessageBox.Show(message.ToString, GlobalVariables.ErrorPrompt.Misc.ActionCancelled, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Call Me.Approve()
                        closeTheForm = True
                    End If
                End If '(activeProcessLIst.Length > 0)
            Else '(Me.AllProcessesAreApproved)
                message.AppendLine("All processes for this EU have to be approved before the EU can be approved.")
                MessageBox.Show(message.ToString, GlobalVariables.ErrorPrompt.Misc.ActionCancelled, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        ElseIf (Me.btnApprove.Text = GlobalVariables.Words.Unapprove) Then
            message.AppendLine("Un-approve this EU. Are you sure?")
            response = MessageBox.Show(message.ToString, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                Call Me.UnApprove()
                closeTheForm = True
            End If
        End If

        If (closeTheForm = True) Then
            Me.Close()
        End If

    End Sub

    Private Sub Approve()
        'create a new EUYear object
        GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitYear = New Business.PlantEmissionUnitYear

        'get the operating status type and comment
        Dim frm As New PlantEmissionUnitApproveForm
        frm.ShowDialog()

        'If the form was canceled the plantEmissionUnitYear will be nothing.
        'if not, fill in the remaining fields and save the record.
        If (Not GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitYear Is Nothing) Then
            With GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitYear
                .PlantEmissionUnitID = GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitID
                .EmissionYear = CShort(My.Settings.CurrentEmissionYear)
                .ApprovalEmployeeID = GlobalVariables.Employee.EmployeeID
                .ApprovalDate = Date.Now
                Try
                    .Insert()
                    '---------------------------------------------------------------------------
                    'check to approve the plant
                    Dim dtbUnapprovedReleasePoints As DataTable = Emissions.Utility.ReleasePointUtility.GetUnapprovedByPlantID(GlobalVariables.PlantEmissionUnitObject.PlantID)
                    Dim dtbUnapprovedEmissionUnits As DataTable = Emissions.Utility.PlantEmissionUnitUtility.GetUnapprovedByPlantID(GlobalVariables.PlantEmissionUnitObject.PlantID)
                    If ((dtbUnapprovedEmissionUnits.Rows.Count = 0) AndAlso (dtbUnapprovedReleasePoints.Rows.Count = 0)) Then
                        'this procedure will be made cleaner next year
                        Dim obj As New Emissions.Business.PlantYear
                        With obj
                            .ApprovalComment = "SYSTEM APPROVED"
                            .ApprovalDate = Date.Now
                            .ApprovalEmployeeID = GlobalVariables.Employee.EmployeeID
                            .EmissionYear = CShort(My.Settings.CurrentEmissionYear)
                            .PlantID = GlobalVariables.PlantEmissionUnitObject.PlantID
                            .Update()
                        End With
                    End If
                    '---------------------------------------------------------------------------
                Catch ex As Exception
                    GlobalVariables.ApplicationLog.AppendLine(ex.Message)
                    GlobalVariables.ApplicationLog.AppendLine(GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitYear.ToString)
                    MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End With
        End If
    End Sub

    Private Sub UnApprove()
        'delete the record and set the object to nothing
        Try
            GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitYear.Delete()
            GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitYear = Nothing

            '---------------------------------------------------------------------------
            'unapprove the plant (set everything to nothing); this procedure will be made cleaner next year
            Dim obj As New Emissions.Business.PlantYear
            With obj
                .ApprovalComment = String.Empty
                .ApprovalDate = Nothing
                .ApprovalEmployeeID = Nothing
                .EmissionYear = CShort(My.Settings.CurrentEmissionYear)
                .PlantID = GlobalVariables.PlantEmissionUnitObject.PlantID
                .Update()
            End With
            '---------------------------------------------------------------------------

        Catch ex As Exception
            GlobalVariables.ApplicationLog.AppendLine(ex.Message)
            GlobalVariables.ApplicationLog.AppendLine(GlobalVariables.PlantEmissionUnitObject.PlantEmissionUnitYear.ToString)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmissionUnitAPCDIDTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EmissionUnitAPCDIDTextBox.KeyPress
        If ((Asc(e.KeyChar) = 8) OrElse (Asc(e.KeyChar) = 45)) Then 'allow backspace and hyphen
            '
        ElseIf (Not Char.IsLetterOrDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

   
End Class