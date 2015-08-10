Imports APCD
Imports APCD.Emissions
Imports System.Text
Imports System.Data.OleDb

Public Class ReleasePointAddForm

    Private Enum DMLMode As Integer
        Insert
        Update
        Delete
    End Enum

    Private m_blnFormIsLoaded As Boolean = False

    Private m_objPoint As New Geography.Business.Point

    '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    'todo 20111003: WHY DOESN'T PASSING IN THE OJBECT WORK CORRECTLY ?! IT WILL BE BETTER THAN USING A GLOBAL !!!!!
    '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    Private m_blnReleasePointName_Changed As Boolean = False
    Private m_blnReleasePointDescription_Changed As Boolean = False
    Private m_blnXCoordinate_Changed As Boolean = False
    Private m_blnYCoordinate_Changed As Boolean = False
    Private m_blnReleaseTypeID_Changed As Boolean = False
    Private m_blnReleasePointTypeID_Changed As Boolean = False
    Private m_blnReleasePointAPCDID_Changed As Boolean = False
    Private m_blnBeginDate_Changed As Boolean = False
    Private m_blnEndDate_Changed As Boolean = False


    Private m_blnCommentPublic_Changed As Boolean = False
    Private m_blnCommentInternal_Changed As Boolean = False

    Private m_blnDetailsChanged As Boolean = False

#Region "----- startup -----"

    Private Sub ReleasePointAddForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Me.SetDefaults()
        Me.m_blnFormIsLoaded = True

        If (GlobalVariables.ReleasePointObject.ReleasePointID > 0) Then
            Call Me.AssignControlValues()
            Call Me.ToggleControlStatus()
        End If

        Call Me.ResetChangedFlags()

    End Sub

    Private Sub SetDefaults()

        Call Me.LoadDataTables()
        Call Me.LoadComboBoxes()

        If (GlobalVariables.ReleasePointObject.ReleasePointID = 0) Then
            Me.Text = "Add Release Point"
        Else
            Me.Text = "Edit Release Point"
        End If

    End Sub

    Private Sub LoadDataTables()

        Me.m_dtbReleasePointAddForm_WORKING = Utility.ReleasePointUtility.ReleasePointAddForm_GetByReleasePointID(GlobalVariables.ReleasePointObject.ReleasePointID)
        Me.m_dtbReleasePointAddForm_ORIGINAL = Me.m_dtbReleasePointAddForm_WORKING.Copy

    End Sub

    Private Sub LoadComboBoxes()

        Call Tools.WindowsForms.LoadComboBox(GlobalVariables.ReleaseTypeLookupTable, Me.ReleaseTypeComboBox)

    End Sub

    Private Sub AssignControlValues()

        With GlobalVariables.ReleasePointObject

            Me.XCoordinateTextBox.Text = .XCoordinate.ToString
            Me.YCoordinateTextBox.Text = .YCoordinate.ToString

            Me.ReleasePointNameTextBox.Text = .ReleasePointName
            Me.ReleasePointDescriptionTextBox.Text = .ReleasePointDescription
            Me.ReleasePointAPCDIDTextBox.Text = .ReleasePointAPCDID

            Try
                Me.BeginDateDateTimePicker.Value = .BeginDate
                Me.BeginDateTextBox.Text = Format(.BeginDate, GlobalVariables.DateFormat._Short)
            Catch ex As Exception
                Me.BeginDateTextBox.Text = String.Empty
            End Try

            Me.CommentPublicTextBox.Text = .CommentPublic
            Me.CommentInternalTextBox.Text = .CommentInternal

            Dim objReleasePointType As Business.ReleasePointType = Utility.ReleasePointTypeUtility.GetByPrimaryKey(GlobalVariables.ReleasePointObject.ReleasePointTypeID)
            Me.ReleaseTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ReleaseTypeComboBox, objReleasePointType.ReleaseTypeID)
            Me.ReleasePointTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ReleasePointTypeComboBox, GlobalVariables.ReleasePointObject.ReleasePointTypeID)

            Call Me.LoadDetailGrid()

            'When the EIS ID is negative it's a new RP; it will be assigned a real EIS ID once the facility submittal is approved by EPA
            If (.ReleasePointEISID < 0) Then
                Me.ShutdownButton.Text = GlobalVariables.Words.Delete
            Else
                If (.EndDate = Nothing) Then
                    Me.ShutdownButton.Text = GlobalVariables.Words.Shutdown
                Else
                    Me.lblShutdownPrompt.Text = "This release point was shut down on " & Format(.EndDate, GlobalVariables.DateFormat._Short)
                    Me.lblShutdownPrompt.Visible = True
                    Me.ShutdownButton.Text = GlobalVariables.Words.Startup
                End If
            End If

        End With

    End Sub

    'Only call when in edit mode.
    Private Sub ToggleControlStatus()

        With GlobalVariables.ReleasePointObject

            If (.ReleasePointEISID > 0) Then
                If (.EndDate = Nothing) Then
                    Me.lblShutdownPrompt.Visible = False 'active, don't show the prompt
                Else
                    Me.lblShutdownPrompt.Visible = True 'shut down, show the prompt
                End If

            End If

            'toggle the approve button text
            If (.ReleasePointYear Is Nothing) Then
                Me.btnApprove.Text = GlobalVariables.Words.Approve
            Else
                'if the rec is approved disable everything; approve and cancel buttons will be re-enabled below
                Me.btnApprove.Text = GlobalVariables.Words.Unapprove
                For Each ctl As Control In Me.Controls
                    ctl.Enabled = False
                Next
            End If

            'toggle shut down button 
            If (.ReleasePointYear Is Nothing) Then
                Me.ShutdownButton.Enabled = True
            Else
                Me.ShutdownButton.Enabled = False
            End If

            'the APCD ID and ReleaseType are always disabled in edit mode
            If (.ReleasePointEISID > 0) Then
                Me.ReleasePointAPCDIDTextBox.Enabled = False
                Me.ReleaseTypeComboBox.Enabled = False
            End If

        End With


        'if the user is an admin or an approver show the Approve button
        If ((GlobalVariables.UserRole = GlobalVariables.Role.Programmer) _
             OrElse (GlobalVariables.UserRole = GlobalVariables.Role.Approver)) Then
            Me.btnApprove.Visible = True
        Else
            Me.btnApprove.Visible = False
        End If

        'the approve and cancel button are always enabled
        Me.btnApprove.Enabled = True
        Me.btnCancel.Enabled = True
        Me.OKButton.Enabled = False 'start up


    End Sub

#End Region '----- startup -----

#Region "----- buttons -----"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If (Me.IsValidForm) Then
            If (GlobalVariables.ReleasePointObject.ReleasePointID = 0) Then
                Call Me.Save(DMLMode.Insert)
            Else
                Call Me.Save(DMLMode.Update)
            End If
            Me.Close()
        End If
    End Sub

#End Region '----- buttons -----

#Region "----- changed events -----"

    Private Sub ResetChangedFlags()

        Me.m_blnReleasePointName_Changed = False
        Me.m_blnReleasePointDescription_Changed = False
        Me.m_blnXCoordinate_Changed = False
        Me.m_blnYCoordinate_Changed = False
        Me.m_blnReleaseTypeID_Changed = False
        Me.m_blnReleasePointTypeID_Changed = False
        Me.m_blnReleasePointAPCDID_Changed = False
        Me.m_blnBeginDate_Changed = False
        Me.m_blnEndDate_Changed = False
        Me.m_blnCommentPublic_Changed = False
        Me.m_blnCommentInternal_Changed = False

    End Sub

    Private Function Header_Changed() As Boolean

        Dim changed As Boolean

        If ((Me.m_blnReleasePointName_Changed = True) _
            OrElse (Me.m_blnReleasePointDescription_Changed = True) _
            OrElse (Me.m_blnXCoordinate_Changed = True) _
            OrElse (Me.m_blnYCoordinate_Changed = True) _
            OrElse (Me.m_blnReleaseTypeID_Changed = True) _
            OrElse (Me.m_blnReleasePointTypeID_Changed = True) _
            OrElse (Me.m_blnReleasePointAPCDID_Changed = True) _
            OrElse (Me.m_blnBeginDate_Changed = True) _
            OrElse (Me.m_blnEndDate_Changed = True) _
            OrElse (Me.m_blnCommentPublic_Changed = True) _
            OrElse (Me.m_blnCommentInternal_Changed = True)) Then
            changed = True
        Else
            changed = False
        End If

        Return changed

    End Function

    Private Sub ReleaseTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleaseTypeComboBox.SelectedIndexChanged

        If (Me.m_blnFormIsLoaded = True) Then
            If (Me.ReleaseTypeComboBox.SelectedIndex <= 0) Then
                Me.ReleasePointTypeComboBox.DataSource = Nothing
            Else
                Dim viewReleasePointTypeFilter As DataView
                Dim filter As String

                'first get all of the possible values for the given release type
                viewReleasePointTypeFilter = GlobalVariables.ReleasePointTypeALL.DefaultView

                'filter based on the ReleaseTypeID; include the blank row at top
                filter = Constants.ReleasePointTypeConstants.FieldName.ReleaseTypeID _
                       & Tools.Constants.Character.Space _
                       & GlobalVariables.Words._In _
                       & Tools.Constants.Character.Space _
                       & Tools.Constants.Character.LeftParenthesis _
                       & CStr(Me.ReleaseTypeComboBox.SelectedValue) _
                       & Tools.Constants.Character.RightParenthesis _
                       & Tools.Constants.Character.Space _
                       & GlobalVariables.Words._And _
                       & Tools.Constants.Character.Space _
                       & Constants.ReleasePointTypeConstants.FieldName.EndDate _
                       & Tools.Constants.Character.Space _
                       & GlobalVariables.Words._Is _
                       & Tools.Constants.Character.Space _
                       & GlobalVariables.Words._Null _
                       & Tools.Constants.Character.Space _
                       & GlobalVariables.Words._Or _
                       & Tools.Constants.Character.Space _
                       & Tools.Constants.Character.LeftParenthesis _
                       & Emissions.Constants.ReleasePointTypeConstants.FieldName.ReleasePointTypeID _
                       & Tools.Constants.Character.EqualSign _
                       & "0" _
                       & Tools.Constants.Character.RightParenthesis


                viewReleasePointTypeFilter.RowFilter = filter
                Tools.WindowsForms.LoadComboBox(viewReleasePointTypeFilter, Me.ReleasePointTypeComboBox)
                Me.ReleasePointTypeComboBox.SelectedIndex = -1
            End If
            Me.m_blnReleaseTypeID_Changed = True
        End If

    End Sub

    Private Sub ReleasePointTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleasePointTypeComboBox.SelectedIndexChanged

        If (Me.m_blnFormIsLoaded = True) Then
            If (Me.ReleasePointTypeComboBox.SelectedIndex <= 0) Then
                Me.QryReleasePointAddFormDataGridView.DataSource = Nothing
            Else
                'if this is a new RP then reset the detail rows, if not, do nothing (preserves current values)
                If (GlobalVariables.ReleasePointObject.ReleasePointID = 0) Then
                    Me.CreateReleasePointDetailRows()
                End If
            End If
            Me.OKButton.Enabled = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.m_blnReleasePointTypeID_Changed = True
        End If

    End Sub

    Private Sub BeginDateDateTimePicker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeginDateDateTimePicker.ValueChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.BeginDateTextBox.Text = Format(Me.BeginDateDateTimePicker.Value, GlobalVariables.DateFormat._Short)
        End If
    End Sub

    Private Sub BeginDateTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeginDateTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.OKButton.Enabled = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.m_blnBeginDate_Changed = True
        End If
    End Sub

    Private Sub YCoordinateTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YCoordinateTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.OKButton.Enabled = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.m_blnYCoordinate_Changed = True
        End If
    End Sub

    Private Sub XCoordinateTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XCoordinateTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.OKButton.Enabled = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.m_blnXCoordinate_Changed = True
        End If
    End Sub

    Private Sub ReleasePointNameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleasePointNameTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.OKButton.Enabled = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.m_blnReleasePointName_Changed = True
        End If
    End Sub

    Private Sub ReleasePointDescriptionTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleasePointDescriptionTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.OKButton.Enabled = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.m_blnReleasePointDescription_Changed = True
        End If
    End Sub

    Private Sub ReleasePointAPCDIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleasePointAPCDIDTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_blnReleasePointAPCDID_Changed = True
            Me.OKButton.Enabled = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
        End If
    End Sub

    Private Sub CommentPublicTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentPublicTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.OKButton.Enabled = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.m_blnCommentPublic_Changed = True
        End If
    End Sub

    Private Sub CommentInternalTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentInternalTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.OKButton.Enabled = True
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.m_blnCommentInternal_Changed = True
        End If
    End Sub

#End Region '----- changed events -----

#Region "----- detail row create/generate rows -----"

    Private Sub CreateReleasePointDetailRows()

        'get all of the ReleaseTypeDetailType (the filter table) rows given the ReleaseType selected
        Dim ReleaseTypeDetailTypeFilteredView As DataView = Me.GetReleaseTypeDetailTypeFilteredView
        If (ReleaseTypeDetailTypeFilteredView.Count > 0) Then

            'now get all of the actual rows from the ReleasePointDetailType lookup table
            'to use to populate the grid
            Dim ReleasePointDetailTypeFilteredView As DataView = Me.GetReleasePointDetailTypeFilteredView(ReleaseTypeDetailTypeFilteredView)
            If (ReleasePointDetailTypeFilteredView.Count > 0) Then
                'create the rows for the grid
                Call Me.GenerateReleasePointDetailRows(ReleasePointDetailTypeFilteredView)
            End If
        End If

    End Sub

    ''' <summary>
    ''' Gets all of the ReleaseTypeDetailType rows for the selected ReleaseType
    ''' </summary>
    ''' <returns>Returns a DataView of ReleaseTypeDetailType rows.</returns>
    ''' <remarks></remarks>
    Private Function GetReleaseTypeDetailTypeFilteredView() As DataView

        Dim view As DataView
        Dim filter As String

        view = GlobalVariables.ReleaseTypeDetailTypeFilterTable.DefaultView
        filter = Constants.ReleaseTypeDetailTypeConstants.FieldName.ReleaseTypeID _
               & Tools.Constants.Character.EqualSign _
               & Tools.Constants.Character.Space _
               & CStr(Me.ReleaseTypeComboBox.SelectedValue)
        view.RowFilter = filter

        Return view

    End Function

    ''' <summary>
    ''' Gets a row from ReleasePointDetailType for each row in the ReleaseTypeDetailType view.
    ''' </summary>
    ''' <param name="view">DataView containing ReleaseTypeDetailType rows.</param>
    ''' <returns>Returns a DataView of ReleasePointDetailType rows.</returns>
    ''' <remarks></remarks>
    Private Function GetReleasePointDetailTypeFilteredView(ByVal view As DataView) As DataView

        Dim filteredView As DataView
        Dim filter As New StringBuilder

        filteredView = GlobalVariables.ReleasePointDetailTypeLookupTable.DefaultView
        With filter
            .Append(Constants.ReleasePointDetailTypeConstants.FieldName.ReleasePointDetailTypeID)
            .Append(Tools.Constants.Character.Space)
            .Append(GlobalVariables.Words._In)
            .Append(Tools.Constants.Character.Space)
            .Append(Tools.Constants.Character.LeftParenthesis)
            For rowCount As Int32 = 0 To view.Count - 1
                If (rowCount > 0) Then
                    .Append(Tools.Constants.Character.Comma)
                End If
                .Append(CStr(view(rowCount).Item(1)))
            Next
            .Append(Tools.Constants.Character.RightParenthesis)
        End With
        filteredView.RowFilter = filter.ToString

        Return filteredView

    End Function

    Private Sub GenerateReleasePointDetailRows(ByVal view As DataView)

        'create the rows in the ReleasePointDetail table
        Me.m_dtbReleasePointAddForm_WORKING = New ReleasePointDataSet.qryReleasePointAddFormDataTable
        For rowCount As Int32 = 0 To view.Count - 1
            Dim row As ReleasePointDataSet.qryReleasePointAddFormRow = CType(Me.m_dtbReleasePointAddForm_WORKING.NewRow, EmissionsInventory.ReleasePointDataSet.qryReleasePointAddFormRow)
            row.ReleasePointDetailTypeID = CInt(view(rowCount).Item(0))
            row.ReleasePointDetailTypeName = CStr(view(rowCount).Item(1))
            row.DetailValue = -1

            'todo 20111108: as of this date these are set values and can't be changed; clean this up to be table driven.
            Select Case row.ReleasePointDetailTypeName
                Case "Height", "Diameter"
                    row.UnitOfMeasurementID = 515
                Case "Exit Gas Flow Rate"
                    row.UnitOfMeasurementID = 659
                Case "Exit Gas Temperature"
                    row.UnitOfMeasurementID = 15
            End Select

            'todo 20111109: is this line necessary?
            row.UnitOfMeasurementName = String.Empty

            Me.m_dtbReleasePointAddForm_WORKING.Rows.Add(row)
            Me.QryReleasePointAddFormDataGridView.DataSource = Me.m_dtbReleasePointAddForm_WORKING
        Next

    End Sub

#End Region '----- detail row create/generate rows -----

#Region "----- save the data -----"

    Private Function Save(ByVal dmlMode As DMLMode) As Boolean

        Dim savedStatus As Boolean

        Using cn As New OleDbConnection(APCD.Emissions.Globals.GlobalVariables.ConnectionString)

            Dim cmd As New OleDbCommand
            Dim trn As OleDbTransaction
            cmd.Connection = cn

            Try
                cn.Open()

                'start transaction
                trn = cn.BeginTransaction
                cmd.Connection = cn
                cmd.Transaction = trn

                Select Case dmlMode
                    Case ReleasePointAddForm.DMLMode.Insert
                        'now the release point
                        Call Me.AssignValuesToObject()
                        GlobalVariables.ReleasePointObject.Insert(cmd)

                        'the details
                        For Each row As DataRow In Me.m_dtbReleasePointAddForm_WORKING.Rows
                            If ((row.RowState = DataRowState.Added) OrElse (row.RowState = DataRowState.Modified)) Then
                                Call Me.Save_ReleasePointDetails(row, cmd)
                            End If
                        Next

                    Case ReleasePointAddForm.DMLMode.Update
                        'header data
                        If (Me.Header_Changed = True) Then
                            'create the release point history object and save it
                            Call Me.CreateHistoryObject()
                            GlobalVariables.ReleasePointObject.ReleasePointHistory.Insert(cmd)

                            'now the main object
                            Call Me.AssignValuesToObject()
                            GlobalVariables.ReleasePointObject.Update(cmd)
                        End If

                        'details
                        If (Me.m_blnDetailsChanged = True) Then
                            For Each row As DataRow In Me.m_dtbReleasePointAddForm_WORKING.Rows
                                If ((row.RowState = DataRowState.Added) OrElse (row.RowState = DataRowState.Modified)) Then
                                    Call Me.Save_ReleasePointDetails(row, cmd)
                                End If
                            Next
                        End If

                    Case ReleasePointAddForm.DMLMode.Delete
                        GlobalVariables.ReleasePointObject.Delete(cmd)
                End Select

                trn.Commit()
                savedStatus = True
            Catch ex As Exception
                GlobalVariables.ApplicationLog.AppendLine(ex.Message)
                'todo 20111121: expand to cover the diff sections
                MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Try
                    trn.Rollback()
                Catch e As Exception
                    'Either the transaction has already been committed or rolled back; or the connection is broken. Make a note in the log.
                    GlobalVariables.ApplicationLog.AppendLine(e.Message)
                End Try
                savedStatus = False
            End Try

        End Using

        Return savedStatus

    End Function

    Private Sub Save_ReleasePointDetails(ByVal row As DataRow, ByVal cmd As OleDbCommand)

        'Dim obj As Business.ReleasePointDetail = Emissions.Utility.ReleasePointDetailUtility.GetByPrimaryKey(GlobalVariables.ReleasePointObject.ReleasePointID, CInt(row(Constants.ReleasePointDetailConstants.FieldName.ReleasePointDetailTypeID)))

        'If (obj Is Nothing) Then

        'End If

        '////////////////////////////////////////////////////////////////////

        If (row.RowState = DataRowState.Unchanged) Then
            'do nothing
        Else
            Dim obj As New Business.ReleasePointDetail
            With obj
                .ReleasePointID = GlobalVariables.ReleasePointObject.ReleasePointID
                .ReleasePointDetailTypeID = CInt(row(Constants.ReleasePointDetailConstants.FieldName.ReleasePointDetailTypeID))
                .DetailValue = CDbl(row(Constants.ReleasePointDetailConstants.FieldName.DetailValue))
                .UnitOfMeasurementID = CInt(row(Constants.ReleasePointDetailConstants.FieldName.UnitOfMeasurementID))
                If (row.RowState = DataRowState.Added) Then
                    .Insert(cmd)
                ElseIf (row.RowState = DataRowState.Modified) Then
                    .ReleasePointDetailID = CInt(row(Constants.ReleasePointDetailConstants.FieldName.ReleasePointDetailID))
                    Call Me.Save_ReleasePointDetails_CreateHistoryOjbect(row, cmd, obj)
                    .Update(cmd)
                End If
            End With
        End If

    End Sub

    Private Sub Save_ReleasePointDetails_CreateHistoryOjbect(ByVal row As DataRow, ByVal cmd As OleDbCommand, ByVal changedReleasePointDetail As Business.ReleasePointDetail)

        Dim changeNotes As StringBuilder = New StringBuilder
        Dim originalRow As DataRow
        Dim originalDetailValue As Double
        Dim originalUnitOfMeasurementID As Int32
        Dim releasePointID, releasePointDetailTypeID As Int32

        'find the row in the ORIGINAL to get the original state of the record
        For Each originalRow In Me.m_dtbReleasePointAddForm_ORIGINAL.Rows
            releasePointID = CInt(originalRow(Emissions.Constants.ReleasePointDetailConstants.FieldName.ReleasePointID))
            releasePointDetailTypeID = CInt(originalRow(Emissions.Constants.ReleasePointDetailConstants.FieldName.ReleasePointDetailTypeID))
            If ((releasePointID = changedReleasePointDetail.ReleasePointID) AndAlso (releasePointDetailTypeID = changedReleasePointDetail.ReleasePointDetailTypeID)) Then
                originalDetailValue = CDbl(originalRow(Constants.ReleasePointDetailConstants.FieldName.DetailValue))
                originalUnitOfMeasurementID = CInt(originalRow(Constants.ReleasePointDetailConstants.FieldName.UnitOfMeasurementID))
                Exit For
            End If
        Next

        If (originalDetailValue <> changedReleasePointDetail.DetailValue) Then
            changeNotes.Append(Constants.ReleasePointDetailConstants.FieldName.DetailValue)
        End If

        'todo 20111109: remove this since UOMs can't change as of 11/8/2011?
        If (originalUnitOfMeasurementID <> changedReleasePointDetail.UnitOfMeasurementID) Then
            If (changeNotes.Length > 0) Then
                changeNotes.Append(Tools.Constants.Character.Comma)
            End If
            changeNotes.Append(Constants.ReleasePointDetailConstants.FieldName.UnitOfMeasurementID)
        End If

        'create the history object and save it
        Dim obj As New Business.ReleasePointDetailHistory
        With obj
            .ReleasePointDetailID = changedReleasePointDetail.ReleasePointDetailID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .UpdateComment = changeNotes.ToString
            .ReleasePointID = changedReleasePointDetail.ReleasePointID
            .ReleasePointDetailTypeID = changedReleasePointDetail.ReleasePointDetailTypeID
            .DetailValue = originalDetailValue
            .UnitOfMeasurementID = originalUnitOfMeasurementID
            .Insert(cmd)
        End With

    End Sub

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim blnIsValidForm As Boolean

        If (Not Me.IsValidReleasePointName) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidReleasePointDescription) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidAPCDID) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidBeginDate) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidYCoordinate) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidXCoordinate) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidReleaseType) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidReleasePointType) Then
            blnIsValidForm = False
        ElseIf (Not IsValidDetailGrid()) Then
            blnIsValidForm = False
        Else
            blnIsValidForm = True
        End If

        Return blnIsValidForm

    End Function

    'done
    Private Function IsValidXCoordinate() As Boolean
        'min -85.4135
        'max -85.9586

        Dim dataIsValid As Boolean

        If (Me.XCoordinateTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, "Value must be >= -85.9586 and <= -85.4135")
            Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)

        ElseIf (Not IsNumeric(Me.XCoordinateTextBox.Text.Trim.Length)) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, "Value must be >= -85.9586 and <= -85.4135")
            Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)

        Else
            Try
                Dim decValue = CDec(Me.XCoordinateTextBox.Text.Trim)
                If (decValue < -85.9586) OrElse (decValue > -85.4135) Then
                    dataIsValid = False
                    Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, "Value must be >= -85.9586 and <= -85.4135")
                    Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
                Else
                    dataIsValid = True
                    Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, String.Empty)
                End If
            Catch ex As Exception
                dataIsValid = False
                Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, "Value must be >= -85.9586 and <= -85.4135")
                Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
            End Try

        End If

        Return dataIsValid

    End Function

    'done
    Private Function IsValidYCoordinate() As Boolean
        'min 37.9963
        'max 38.3837
        Dim dataIsValid As Boolean

        If (Me.YCoordinateTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, "Value must be >= 37.9963 and <= 38.3837")
            Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)

        ElseIf (Not IsNumeric(Me.YCoordinateTextBox.Text.Trim.Length)) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, "Value must be >= 37.9963 and <= 38.3837")
            Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)

        Else
            Try
                Dim decValue = CDec(Me.YCoordinateTextBox.Text.Trim)
                If (decValue < 37.9963) OrElse (decValue > 38.3837) Then
                    dataIsValid = False
                    Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, "Value must be >= 37.9963 and <= 38.3837")
                    Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
                Else
                    dataIsValid = True
                    Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, String.Empty)
                End If
            Catch ex As Exception
                dataIsValid = False
                Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, "Value must be >= 37.9963 and <= 38.3837")
                Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
            End Try

        End If

        Return dataIsValid

    End Function

    ''Private Function IsValidPointID() As Boolean

    ''    Dim dataIsValid As Boolean

    ''    If (GlobalVariables.ReleasePointObject.PointID <= 0) Then
    ''        dataIsValid = False
    ''        Me.ErrorProvider1.SetError(Me.btnChangeLocation, "Coordinates are required.")
    ''        Me.ErrorProvider1.SetIconAlignment(Me.btnChangeLocation, ErrorIconAlignment.MiddleRight)
    ''    Else
    ''        dataIsValid = True
    ''        Me.ErrorProvider1.SetError(Me.btnChangeLocation, String.Empty)
    ''    End If

    ''    Return dataIsValid

    ''End Function

    Private Function IsValidReleasePointName() As Boolean

        Dim dataIsValid As Boolean

        If (Me.ReleasePointNameTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(ReleasePointNameTextBox, "Please enter a name")
            Me.ErrorProvider1.SetIconAlignment(ReleasePointNameTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ReleasePointNameTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidReleasePointDescription() As Boolean

        Dim dataIsValid As Boolean

        If (ReleasePointDescriptionTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(ReleasePointDescriptionTextBox, "Please enter a description.")
            Me.ErrorProvider1.SetIconAlignment(ReleasePointDescriptionTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ReleasePointDescriptionTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidAPCDID() As Boolean

        Dim dataIsValid As Boolean

        If (ReleasePointAPCDIDTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(ReleasePointAPCDIDTextBox, "Please enter the APCD ID.")
            Me.ErrorProvider1.SetIconAlignment(ReleasePointAPCDIDTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ReleasePointAPCDIDTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    'begin date
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

    Private Function IsValidReleaseType() As Boolean

        Dim dataIsValid As Boolean

        If (ReleaseTypeComboBox.SelectedIndex <= 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(ReleaseTypeComboBox, "Please select an Release Point")
            Me.ErrorProvider1.SetIconAlignment(Me.ReleaseTypeComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ReleaseTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidReleasePointType() As Boolean

        Dim dataIsValid As Boolean

        If (ReleasePointTypeComboBox.SelectedIndex <= 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(ReleasePointTypeComboBox, "Please select an Release Point Type")
            Me.ErrorProvider1.SetIconAlignment(Me.ReleasePointTypeComboBox, ErrorIconAlignment.MiddleRight)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ReleasePointTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidDetailGrid() As Boolean

        Dim blnIsValidDetailGrid As Boolean = True
        Dim row As DataRow

        Me.ErrorProvider1.SetError(Me.QryReleasePointAddFormDataGridView, String.Empty)


        'first, make sure we have real values 
        For Each row In Me.m_dtbReleasePointAddForm_WORKING.Rows
            Dim dblDetailValue As Double = CDbl(row(Constants.ReleasePointDetailConstants.FieldName.DetailValue))

            If (dblDetailValue < 0) Then
                blnIsValidDetailGrid = False
                Me.ErrorProvider1.SetError(Me.QryReleasePointAddFormDataGridView, GlobalVariables.ErrorPrompt.Misc.AllValuesMustBeGreaterThanOrEqualToZero)
                Me.ErrorProvider1.SetIconAlignment(Me.QryReleasePointAddFormDataGridView, ErrorIconAlignment.MiddleRight)
                Exit For
            End If
        Next

        Return blnIsValidDetailGrid

    End Function

#End Region '----- Validation -----

    Private Sub CreateHistoryObject()

        Dim changeNotes As StringBuilder = New StringBuilder

        If (GlobalVariables.ReleasePointObject.EndDate = Nothing) Then

            'note all of the fields that have changed
            If (Me.m_blnReleasePointName_Changed = True) Then
                changeNotes.Append(Constants.ReleasePointConstants.FieldName.ReleasePointName)
            End If

            If (Me.m_blnReleasePointDescription_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.ReleasePointConstants.FieldName.ReleasePointDescription)
            End If

            If (Me.m_blnXCoordinate_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.ReleasePointConstants.FieldName.XCoordinate)
            End If

            If (Me.m_blnYCoordinate_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.ReleasePointConstants.FieldName.YCoordinate)
            End If


            If (Me.m_blnReleaseTypeID_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.ReleaseTypeConstants.FieldName.ReleaseTypeID)
            End If

            If (Me.m_blnReleasePointTypeID_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.ReleasePointConstants.FieldName.ReleasePointTypeID)

            End If

            If (Me.m_blnReleasePointAPCDID_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.ReleasePointConstants.FieldName.ReleasePointAPCDID)

            End If

            If (Me.m_blnCommentPublic_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.ReleasePointConstants.FieldName.CommentPublic)

            End If

            If (Me.m_blnCommentInternal_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.ReleasePointConstants.FieldName.CommentInternal)

            End If

            If (Me.m_blnBeginDate_Changed = True) Then
                If (changeNotes.Length > 0) Then
                    changeNotes.Append(Tools.Constants.Character.Comma)
                End If
                changeNotes.Append(Constants.ReleasePointConstants.FieldName.BeginDate)

            End If
        Else
            changeNotes.Append(Constants.ReleasePointConstants.FieldName.EndDate)
        End If

        'instantiate the object and set the current state of the ReleasePoint
        GlobalVariables.ReleasePointObject.ReleasePointHistory = New Business.ReleasePointHistory
        With GlobalVariables.ReleasePointObject
            .ReleasePointHistory.ReleasePointID = .ReleasePointID
            .ReleasePointHistory.UpdateDate = Date.Now
            .ReleasePointHistory.UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ReleasePointHistory.UpdateComment = changeNotes.ToString()
            .ReleasePointHistory.ReleasePointName = .ReleasePointName
            .ReleasePointHistory.PlantID = .PlantID
            .ReleasePointHistory.ReleasePointDescription = .ReleasePointDescription
            .ReleasePointHistory.XCoordinate = .XCoordinate
            .ReleasePointHistory.YCoordinate = .YCoordinate
            .ReleasePointHistory.ReleasePointTypeID = .ReleasePointTypeID
            .ReleasePointHistory.ReleasePointAPCDID = .ReleasePointAPCDID
            .ReleasePointHistory.ReleasePointEISID = .ReleasePointEISID
            .ReleasePointHistory.BeginDate = .BeginDate
            .ReleasePointHistory.EndDate = .EndDate
            .ReleasePointHistory.CommentPublic = .CommentPublic
            .ReleasePointHistory.CommentInternal = .CommentInternal
        End With

    End Sub

    Private Sub AssignValuesToObject_Point()

        With Me.m_objPoint
            .XCoordinate = CDec(Me.XCoordinateTextBox.Text.Trim)
            .YCoordinate = CDec(Me.YCoordinateTextBox.Text.Trim)

            '20111111: as of this date everything below is non-user entered; rule may change later
            .GeographicCoordinateTypeID = 1
            .CoordinateZone = 0
            .GeometricTypeID = 0
            .HorizontalCollectionMethodID = 27
            .HorizontalReferenceDatumID = 2
            .SourceMapScaleNumber = -1

            .CoordinateVerificationMethodID = -1
            .CoordinateDataSourceID = 21
            .HorizontalCollectionDate = CDate("1/1/2000")
            .Elevation = -999
            .UnitOfMeasurementID = 515
            .VerticalCollectionMethodID = 27
            .VerticalReferenceDatumID = 1
            .VerticalCollectionDate = Nothing
            .GeographicPointComment = String.Empty
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With

    End Sub

    ''Private Sub AssignValuesToObject()

    ''    With GlobalVariables.ReleasePointObject

    ''        .ReleasePointName = Me.ReleasePointNameTextBox.Text.Trim & String.Empty
    ''        .ReleasePointDescription = Me.ReleasePointDescriptionTextBox.Text.Trim
    ''        .ReleasePointTypeID = CInt(Me.ReleasePointTypeComboBox.SelectedValue)
    ''        .ReleasePointAPCDID = Me.ReleasePointAPCDIDTextBox.Text.Trim

    ''        .CommentPublic = Me.CommentPublicTextBox.Text.Trim
    ''        .CommentInternal = Me.CommentInternalTextBox.Text.Trim
    ''        .BeginDate = CDate(BeginDateTextBox.Text)

    ''        If (GlobalVariables.ReleasePointObject.ReleasePointID = 0) Then
    ''            .PointID = Me.m_objPoint.PointID

    ''            .ReleasePointEISID = Globals.GlobalMethods.GenerateTempEISID
    ''            .AddDate = Date.Now
    ''            .AddedBy = GlobalVariables.Employee.EmployeeID

    ''            .ReleasePointDetails = New Collections.ReleasePointDetails
    ''            For Each row As ReleasePointDataSet.qryReleasePointAddFormRow In Me.m_dtbReleasePointAddForm_WORKING.Rows
    ''                Dim objReleasePointDetail As New Business.ReleasePointDetail
    ''                With objReleasePointDetail
    ''                    .ReleasePointDetailTypeID = row.ReleasePointDetailTypeID
    ''                    .DetailValue = row.DetailValue
    ''                    .UnitOfMeasurementID = row.UnitOfMeasurementID
    ''                End With
    ''                .ReleasePointDetails.Add(objReleasePointDetail)
    ''            Next

    ''        Else
    ''            Dim obj As Business.ReleasePointDetail = New Business.ReleasePointDetail
    ''            Dim blnFoundRow As Boolean = False
    ''            For Each releasePointDetailRow As ReleasePointDataSet.qryReleasePointAddFormRow In Me.m_dtbReleasePointAddForm_WORKING.Rows
    ''                For Each obj In .ReleasePointDetails
    ''                    If (releasePointDetailRow.ReleasePointDetailTypeID = obj.ReleasePointDetailTypeID) Then
    ''                        obj.DetailValue = releasePointDetailRow.DetailValue
    ''                        obj.UnitOfMeasurementID = releasePointDetailRow.UnitOfMeasurementID
    ''                        blnFoundRow = True
    ''                        Exit For
    ''                    End If
    ''                Next
    ''                If (blnFoundRow = True) Then
    ''                    blnFoundRow = False
    ''                Else
    ''                    Dim detailToAdd As New Business.ReleasePointDetail
    ''                    With detailToAdd
    ''                        .ReleasePointID = GlobalVariables.ReleasePointObject.ReleasePointID
    ''                        .ReleasePointDetailTypeID = releasePointDetailRow.ReleasePointDetailTypeID
    ''                        .DetailValue = releasePointDetailRow.DetailValue
    ''                        .UnitOfMeasurementID = releasePointDetailRow.UnitOfMeasurementID
    ''                    End With
    ''                    .ReleasePointDetails.Add(detailToAdd)
    ''                End If
    ''            Next

    ''        End If

    ''    End With

    ''End Sub

    Private Sub AssignValuesToObject()

        With GlobalVariables.ReleasePointObject
            .ReleasePointName = Me.ReleasePointNameTextBox.Text.Trim & String.Empty
            .ReleasePointDescription = Me.ReleasePointDescriptionTextBox.Text.Trim
            .XCoordinate = CDec(Me.XCoordinateTextBox.Text.Trim)
            .YCoordinate = CDec(Me.YCoordinateTextBox.Text.Trim)



            .ReleasePointTypeID = CInt(Me.ReleasePointTypeComboBox.SelectedValue)
            .ReleasePointAPCDID = Me.ReleasePointAPCDIDTextBox.Text.Trim
            .BeginDate = CDate(BeginDateTextBox.Text)
            .CommentPublic = Me.CommentPublicTextBox.Text.Trim
            .CommentInternal = Me.CommentInternalTextBox.Text.Trim

            If (GlobalVariables.ReleasePointObject.ReleasePointID = 0) Then
                .ReleasePointEISID = Globals.GlobalMethods.GenerateTempEISID

                .AddDate = Date.Now
                .AddedBy = GlobalVariables.Employee.EmployeeID
            Else
                '
            End If

        End With

    End Sub

#End Region '----- save the data -----

#Region "----- buttons -----"

    Private Sub ShutdownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownButton.Click

        Dim message As New StringBuilder
        Dim response As DialogResult
        Dim blnCloseForm As Boolean = False

        Dim activeProcessList As String = Me.GetActiveProcessList

        If (Me.ShutdownButton.Text = GlobalVariables.Words.Shutdown) Then
            If (activeProcessList.Length > 0) Then
                message.Append("This release point has the following active process(s): ")
                message.Append(activeProcessList)
                message.AppendLine(" You must shut down each process before shutting down the release point.")
                MessageBox.Show(message.ToString, GlobalVariables.ErrorPrompt.Misc.ActionCancelled, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                message.AppendLine("Are you sure you want to shut down this release point?")
                response = MessageBox.Show(message.ToString, "Shut down " & GlobalVariables.ReleasePointObject.ReleasePointName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If (response = Windows.Forms.DialogResult.Yes) Then
                    Dim strEndDate As String = InputBox("Enter shut down date (MM/DD/YYYY)", Application.ProductName)
                    If (IsDate(strEndDate)) Then
                        'set the end date and update the db
                        GlobalVariables.ReleasePointObject.EndDate = CDate(strEndDate)
                        Me.m_blnEndDate_Changed = True
                        Me.Save(DMLMode.Update)
                        Me.Close()
                    Else
                        MessageBox.Show("Invalid date entered. Shut down cancelled.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            End If

        ElseIf (Me.ShutdownButton.Text = GlobalVariables.Words.Startup) Then

            message.AppendLine("Are you sure you want to start up this release point?")
            response = MessageBox.Show(message.ToString, "Start up " & GlobalVariables.ReleasePointObject.ReleasePointName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                Dim strBeginDate As String = Trim(InputBox("Enter start up date (MM/DD/YYYY)", Application.ProductName))
                If (IsDate(strBeginDate)) Then
                    If (GlobalVariables.ReleasePointObject.EndDate < CDate(strBeginDate)) Then

                        'set the end date and update the db
                        Me.BeginDateTextBox.Text = strBeginDate
                        GlobalVariables.ReleasePointObject.BeginDate = CDate(strBeginDate)
                        GlobalVariables.ReleasePointObject.EndDate = Nothing
                        Me.m_blnEndDate_Changed = True
                        Call Me.Save(DMLMode.Update)
                        Me.Close()
                    Else
                        MessageBox.Show("Start up date cannot be before the shut down date. Start up cancelled.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("Invalid date entered. Start up cancelled.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

        ElseIf (Me.ShutdownButton.Text = GlobalVariables.Words.Delete) Then
            If (activeProcessList.Length > 0) Then
                message.Append("This release point has the following active process(s): ")
                message.Append(activeProcessList)
                message.AppendLine(". You must remove the release point from each process (set emissions to 0) before it can be deleted.")
                MessageBox.Show(message.ToString, GlobalVariables.ErrorPrompt.Misc.ActionCancelled, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                message.AppendLine("Delete the release point. Are you sure?")
                response = MessageBox.Show(message.ToString, "Delete " & GlobalVariables.ReleasePointObject.ReleasePointName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (response = Windows.Forms.DialogResult.Yes) Then
                    Call Me.Save(DMLMode.Delete)
                    GlobalVariables.ReleasePointObject = Nothing
                    Me.Close()
                End If
            End If
        End If

    End Sub

    Private Function GetActiveProcessList() As String

        Dim objProcessReleasePoints As New Collections.ProcessReleasePoints
        Dim objProcessReleasePoint As Business.ProcessReleasePoint
        Dim activeCount As Int32
        Dim processIDs As New StringBuilder

        objProcessReleasePoints = Utility.ProcessReleasePointUtility.GetByReleasePointID_Collection(GlobalVariables.ReleasePointObject.ReleasePointID)
        For Each objProcessReleasePoint In objProcessReleasePoints
            Dim objProcess As Business.Process = Utility.ProcessUtility.GetByPrimaryKey(objProcessReleasePoint.ProcessID)
            Dim objEmissionUnit As Business.PlantEmissionUnit = Utility.PlantEmissionUnitUtility.GetByPrimaryKey(objProcess.PlantEmissionUnitID)
            If ((objProcess.EndDate = Nothing) AndAlso (objProcessReleasePoint.EmissionsPercent > 0)) Then
                If (activeCount > 0) Then
                    processIDs.Insert(0, ", ")
                End If
                processIDs.Insert(0, objProcess.ProcessAPCDID & "(EU " & objEmissionUnit.EmissionUnitAPCDID & ")")
                activeCount += 1
            End If
        Next

        Return processIDs.ToString

    End Function

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

        Dim message As New StringBuilder
        Dim response As DialogResult

        If (Me.IsValidForm) Then

            If (Me.btnApprove.Text = GlobalVariables.Words.Approve) Then
                '/////////////////////////////////////////////////////////////////////////////////
                Dim activeProcessLIst As String = Me.GetActiveProcessList
                If (activeProcessLIst.Length > 0) Then
                    message.AppendLine("Approve this release point. Are you sure?")
                    response = MessageBox.Show(message.ToString, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (response = Windows.Forms.DialogResult.Yes) Then
                        Call Me.Approve()
                    End If '(response = Windows.Forms.DialogResult.Yes)

                Else
                    'there are no active processes; is the release point shut down?
                    If (GlobalVariables.ReleasePointObject.EndDate = Nothing) Then
                        message.AppendLine("This release point has no active processes. It must either have 1 active process or be shut down in order to be approved.")
                        MessageBox.Show(message.ToString, GlobalVariables.ErrorPrompt.Misc.ActionCancelled, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Call Me.Approve()
                    End If
                End If '(activeProcessLIst.Length > 0)
                '/////////////////////////////////////////////////////////////////////////////////

            ElseIf (Me.btnApprove.Text = GlobalVariables.Words.Unapprove) Then
                message.AppendLine("Un-approve this release point. Are you sure?")
                response = MessageBox.Show(message.ToString, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (response = Windows.Forms.DialogResult.Yes) Then
                    Call Me.UnApprove()
                End If

            End If ' (Me.btnApprove.Text = GlobalVariables.Words.Approve)

        End If '(Me.IsValidForm) 


    End Sub

    Private Sub Approve()

        Dim frm As New ReleasePointApproveForm
        frm.ShowDialog()

        'If the form was canceled the ReleasePointYear will be nothing.
        'if not, fill in the remaining fields and save the record.
        If (Not GlobalVariables.ReleasePointObject.ReleasePointYear Is Nothing) Then
            With GlobalVariables.ReleasePointObject.ReleasePointYear
                .ReleasePointID = GlobalVariables.ReleasePointObject.ReleasePointID
                .EmissionsYear = CShort(My.Settings.CurrentEmissionYear)
                .ApprovalEmployeeID = GlobalVariables.Employee.EmployeeID
                .ApprovalDate = Date.Now

                'approve the record
                Try
                    .Insert()

                    '---------------------------------------------------------------------------
                    'check to approve the plant
                    Dim dtbUnapprovedReleasePoints As DataTable = Emissions.Utility.ReleasePointUtility.GetUnapprovedByPlantID(GlobalVariables.ReleasePointObject.PlantID)
                    Dim dtbUnapprovedEmissionUnits As DataTable = Emissions.Utility.PlantEmissionUnitUtility.GetUnapprovedByPlantID(GlobalVariables.ReleasePointObject.PlantID)
                    If ((dtbUnapprovedEmissionUnits.Rows.Count = 0) AndAlso (dtbUnapprovedReleasePoints.Rows.Count = 0)) Then
                        'this procedure will be made cleaner next year
                        Dim obj As New Emissions.Business.PlantYear
                        With obj
                            .ApprovalComment = "SYSTEM APPROVED"
                            .ApprovalDate = Date.Now
                            .ApprovalEmployeeID = GlobalVariables.Employee.EmployeeID
                            .EmissionYear = CShort(My.Settings.CurrentEmissionYear)
                            .PlantID = GlobalVariables.ReleasePointObject.PlantID
                            .Update()
                        End With
                    End If
                    '---------------------------------------------------------------------------

                    Me.Close()
                Catch ex As Exception
                    GlobalVariables.ApplicationLog.AppendLine(ex.Message)
                    GlobalVariables.ApplicationLog.AppendLine(GlobalVariables.ReleasePointObject.ReleasePointYear.ToString)
                    MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End With
        End If

    End Sub

    Private Sub UnApprove()
        Try
            GlobalVariables.ReleasePointObject.ReleasePointYear.Delete()
            GlobalVariables.ReleasePointObject.ReleasePointYear = Nothing

            '---------------------------------------------------------------------------
            'unapprove the plant (set everything to nothing); this procedure will be made cleaner next year
            Dim obj As New Emissions.Business.PlantYear
            With obj
                .ApprovalComment = String.Empty
                .ApprovalDate = Nothing
                .ApprovalEmployeeID = Nothing
                .EmissionYear = CShort(My.Settings.CurrentEmissionYear)
                .PlantID = GlobalVariables.ReleasePointObject.PlantID
                .Update()
            End With
            '---------------------------------------------------------------------------

            Me.Close()
        Catch ex As Exception
            GlobalVariables.ApplicationLog.AppendLine(ex.Message)
            GlobalVariables.ApplicationLog.AppendLine(GlobalVariables.ReleasePointObject.ReleasePointYear.ToString)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReleasePointAPCDIDTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ReleasePointAPCDIDTextBox.KeyPress
        If ((Asc(e.KeyChar) = 8) OrElse (Asc(e.KeyChar) = 45)) Then 'allow backspace and hyphen
            '
        ElseIf (Not Char.IsLetterOrDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

#End Region '----- buttons -----

#Region "----- Release Point Details -----"

    Private m_dtbReleasePointAddForm_WORKING As DataTable
    Private m_dtbReleasePointAddForm_ORIGINAL As DataTable
    Private m_sngControlMeasurePercentTotal As Single

    Private Sub LoadDetailGrid()
        Me.QryReleasePointAddFormDataGridView.DataSource = Me.m_dtbReleasePointAddForm_WORKING
    End Sub

    ''Private Sub btnAddControlMeasure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddControlMeasure.Click

    ''    Dim row As DataRow = Me.m_dtbProcessControlMeasureForm_WORKING.NewRow
    ''    row(Constants.ProcessControlMeasureConstants.FieldName.ProcessControlMeasureID) = GlobalMethods.GetTempID
    ''    row(Constants.ProcessControlMeasureConstants.FieldName.ControlMeasureID) = -1

    ''    Dim frm As New ProcessControlMeasureAddEditForm(Me.m_intPlantID, row, Me.m_dtbProcessControlMeasureForm_WORKING)
    ''    frm.ShowDialog()

    ''    If (CInt(row(Constants.ProcessControlMeasureConstants.FieldName.ControlMeasureID)) > 0) Then
    ''        'add the row to the table then refresh the total percent
    ''        Me.m_dtbProcessControlMeasureForm_WORKING.Rows.Add(row)

    ''        Me.btnApprove.Enabled = False
    ''        Me.ShutdownButton.Enabled = False
    ''        Me.OKButton.Enabled = True
    ''        Me.QryProcessControlMeasureFormDataGridView.DataSource = Me.m_dtbProcessControlMeasureForm_WORKING
    ''        Me.m_blnProccessControlMeasures_Changed = True
    ''    End If

    ''End Sub

    Private Sub QryReleasePointAddFormDataGridView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QryReleasePointAddFormDataGridView.DoubleClick
        Call Me.EditReleasePointDetail()
    End Sub

    Private Sub QryReleasePointAddFormDataGridView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles QryReleasePointAddFormDataGridView.KeyPress
        'Call Me.EditReleasePointDetail()
    End Sub

    Private Sub EditReleasePointDetail()
        Dim selectedRow As DataGridViewRow = Me.QryReleasePointAddFormDataGridView.Rows(Me.QryReleasePointAddFormDataGridView.CurrentRow.Index)
        Dim intReleasePointDetailTypeID As Int32 = CInt(selectedRow.Cells(0).Value)
        Dim rows() As DataRow = Me.m_dtbReleasePointAddForm_WORKING.Select("ReleasePointDetailTypeID = " & intReleasePointDetailTypeID.ToString)

        Dim frm As New ReleasePointDetailAddEditForm(rows(0))
        frm.ShowDialog()

        If ((rows(0).RowState = DataRowState.Added) OrElse (rows(0).RowState = DataRowState.Modified)) Then
            Me.btnApprove.Enabled = False
            Me.ShutdownButton.Enabled = False
            Me.OKButton.Enabled = True
            Me.m_blnDetailsChanged = True
        End If
    End Sub

#End Region '----- Release Point Details -----

    Private Sub YCoordinateTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles YCoordinateTextBox.KeyPress
        If ((Asc(e.KeyChar) = 8) OrElse (Asc(e.KeyChar) = 46)) Then 'allow backspace and period
            '
        ElseIf (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub XCoordinateTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles XCoordinateTextBox.KeyPress
        If ((Asc(e.KeyChar) = 8) OrElse (Asc(e.KeyChar) = 45) OrElse (Asc(e.KeyChar) = 46)) Then 'allow backspace, minus, and period
            '
        ElseIf (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub


End Class