Imports System.Text

Public Class ReleasePointUserControl

    'counters
    Private m_changedValueCount As Int32

    'events 
    Public Event SaveButton_Pressed(ByVal state As GlobalVariables.InventoryStatus)
    Public Event CancelButton_Pressed()

    'object variables
    Private m_emissionYear As EmissionsDataSet.EmissionYearRow
    Private m_releasePoint As EmissionsDataSet.ReleasePointRow
    Private m_releasePointYear As EmissionsDataSet.ReleasePointYearRow
    Private m_releasePointDetails_ORIGINAL As EmissionsDataSet.ReleasePointDetailDataTable

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

    Private Sub ReleasePointUserControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.MeasurementTableAdapter.Fill(Me.EmissionsDataSet.Measurement)
        Me.UnitOfMeasurementTableAdapter.Fill(Me.EmissionsDataSet.UnitOfMeasurement)
        Me.ReleaseTypeMeasurementTableAdapter.Fill(Me.EmissionsDataSet.ReleaseTypeMeasurement)

    End Sub

    Friend Sub LoadObjectVariables(ByVal emissionYear As EmissionsDataSet.EmissionYearRow, ByVal releasePoint As EmissionsDataSet.ReleasePointRow, ByVal releasePointYear As EmissionsDataSet.ReleasePointYearRow)

        Me.m_emissionYear = emissionYear
        Me.m_releasePoint = releasePoint
        Me.m_releasePointYear = releasePointYear

        Call Me.LoadHistoryRecord_ReleasePoint()
        Call Me.LoadHistoryRecord_ReleasePointYear()

        Me.m_releasePointDetails_ORIGINAL = CType(MainForm.EmissionsDataSet.ReleasePointDetail.Copy, EmissionsInventory.EmissionsDataSet.ReleasePointDetailDataTable)

        Me.ReleasePoint_GetProcessesTableAdapter.FillByReleasePointID_EmissionYear(Me.EmissionsDataSet.ReleasePoint_GetProcesses, Me.m_releasePoint.ReleasePointID, Me.m_emissionYear.EmissionYear)

        Me.m_changedValueCount = 0

    End Sub

    Friend Sub LoadControls()

        Me.ErrorProvider1.SetError(Me.ReleasePointAPCDIDTextBox, String.Empty)
        Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, String.Empty)
        Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, String.Empty)
        Me.ErrorProvider1.SetError(Me.ReleasePointDetailDataGridView, String.Empty)

        'set shut down label
        If (Me.m_releasePoint.IsEndDateNull) Then
            Me.ShutdownMessageLabel.Text = String.Empty
        Else
            Me.ShutdownMessageLabel.Text = "Shut down in " & Me.m_releasePoint.EndDate.Year
        End If

        Me.IsExcludedCheckBox.Checked = Me.m_releasePointYear.IsExcluded

        Call Me.LoadComboBoxes()

        With Me.m_releasePoint
            Me.ReleasePointAPCDIDTextBox.Text = .ReleasePointAPCDID
            Me.ReleasePointDescriptionTextBox.Text = .ReleasePointDescription
            Me.CompanyCommentTextBox.Text = .CompanyComment
            Me.APCDCommentTextBox.Text = .APCDComment

            Me.YCoordinateTextBox.Text = CStr(.YCoordinate)
            Me.XCoordinateTextBox.Text = CStr(.XCoordinate)

            Me.ReleasePointTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ReleasePointTypeComboBox, .ReleasePointTypeID)
            Me.ReleaseTypeSubTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ReleaseTypeSubTypeComboBox, Me.m_releasePoint.ReleaseTypeSubTypeID)
        End With

        Me.ReleasePointDetailDataGridView.DataSource = MainForm.EmissionsDataSet.ReleasePointDetail


        'set the approval status level on the main form
        If (Not Me.m_releasePointYear.IsApprovalDateNull) Then
            Dim objEmployee As PeopleLibrary.Business.Employee = PeopleLibrary.Utility.EmployeeUtility.GetByPrimaryKey(Me.m_releasePointYear.ApprovalEmployeeID)
            MainForm.statusLevel.Text = "Approved on " & Me.m_releasePointYear.ApprovalDate.ToShortDateString & " by " & objEmployee.NickName & " " & objEmployee.LastName
        Else
            MainForm.statusLevel.Text = String.Empty
        End If

    End Sub

    Friend Sub SetInventoryStatus()

        If (GlobalVariables.UserRole = GlobalVariables.Role.Guest) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.None

        ElseIf (Not Me.m_emissionYear.IsEmissionsInEISDateNull) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.EmissionYearClosed

        ElseIf (Not Me.m_releasePointYear.IsApprovalDateNull) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.Approved

        ElseIf (Not Me.m_releasePoint.IsEndDateNull) Then
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.Shutdown

        Else
            Me.m_inventoryStatus = GlobalVariables.InventoryStatus.UnApproved
        End If

    End Sub

    Private Sub LoadComboBoxes()

        Dim releasePointType As Emissions.Business.ReleasePointType = Emissions.Utility.ReleasePointTypeUtility.GetByPrimaryKey(Me.m_releasePoint.ReleasePointTypeID)

        Me.ReleasePointTypeTableAdapter.FillByReleaseTypeID(Me.EmissionsDataSet.ReleasePointType, releasePointType.ReleaseTypeID)
        Tools.WindowsForms.LoadComboBox(Me.EmissionsDataSet.ReleasePointType, Me.ReleasePointTypeComboBox, False)

        Me.ReleaseTypeSubTypeTableAdapter.FillByReleaseTypeID(Me.EmissionsDataSet.ReleaseTypeSubType, releasePointType.ReleaseTypeID)
        Tools.WindowsForms.LoadComboBox(Me.EmissionsDataSet.ReleaseTypeSubType, Me.ReleaseTypeSubTypeComboBox, False)

    End Sub

    Private Sub LoadHistoryRecord_ReleasePoint()

        Dim row As EmissionsDataSet.ReleasePointHistoryRow = MainForm.EmissionsDataSet.ReleasePointHistory.NewReleasePointHistoryRow
        With row
            .ReleasePointID = Me.m_releasePoint.ReleasePointID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .PlantID = Me.m_releasePoint.PlantID
            .ReleasePointDescription = Me.m_releasePoint.ReleasePointDescription
            .XCoordinate = Me.m_releasePoint.XCoordinate
            .YCoordinate = Me.m_releasePoint.YCoordinate
            .ReleasePointTypeID = CInt(Me.ReleasePointTypeComboBox.SelectedValue)
            .ReleaseTypeSubTypeID = CInt(Me.ReleaseTypeSubTypeComboBox.SelectedValue)
            .ReleasePointAPCDID = Me.m_releasePoint.ReleasePointAPCDID
            .ReleasePointEISID = Me.m_releasePoint.ReleasePointEISID
            .BeginDate = Me.m_releasePoint.BeginDate
            If (Me.m_releasePoint.IsEndDateNull) Then
                .SetEndDateNull()
            Else
                .EndDate = Me.m_releasePoint.EndDate
            End If
            .CompanyComment = Me.m_releasePoint.CompanyComment
            .APCDComment = Me.m_releasePoint.APCDComment
        End With
        MainForm.EmissionsDataSet.ReleasePointHistory.Rows.Add(row)

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

    Private Sub DisableEditing()

        Me.IsExcludedCheckBox.Enabled = False
        Me.ButtonPanel.Visible = False

        Me.ReleasePointDetailDataGridView.ReadOnly = True

        Me.ReleasePointAPCDIDTextBox.ReadOnly = True
        Me.ReleasePointDescriptionTextBox.ReadOnly = True
        Me.CompanyCommentTextBox.ReadOnly = True
        Me.APCDCommentTextBox.ReadOnly = True
        Me.XCoordinateTextBox.ReadOnly = True
        Me.YCoordinateTextBox.ReadOnly = True

        Me.ReleasePointTypeComboBox.Enabled = False
        Me.ReleaseTypeSubTypeComboBox.Enabled = False

    End Sub

    Private Sub EnableEditing()

        Me.IsExcludedCheckBox.Enabled = True
        Me.ButtonPanel.Visible = True
        Me.ReleasePointDetailDataGridView.ReadOnly = False

        Me.ReleasePointAPCDIDTextBox.ReadOnly = False
        Me.ReleasePointDescriptionTextBox.ReadOnly = False
        Me.CompanyCommentTextBox.ReadOnly = False
        Me.APCDCommentTextBox.ReadOnly = False
        Me.XCoordinateTextBox.ReadOnly = False
        Me.YCoordinateTextBox.ReadOnly = False

        Me.ReleasePointTypeComboBox.Enabled = True
        Me.ReleaseTypeSubTypeComboBox.Enabled = True

    End Sub


#Region "----- changed events -----"

    Private Sub IsExcludedCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsExcludedCheckBox.CheckedChanged

        If (Me.controlIsLoaded) Then
            Me.m_releasePointYear.IsExcluded = Me.IsExcludedCheckBox.Checked
            Call Me.ToggleButtonStatus_FieldChanged()
            Me.m_isExcluded_Changed = True
        End If

    End Sub

    Private Sub ReleasePointAPCDIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleasePointAPCDIDTextBox.TextChanged
        If (Me.controlIsLoaded) Then
            Me.m_releasePoint.ReleasePointAPCDID = Me.ReleasePointAPCDIDTextBox.Text.Trim
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub ReleasePointDescriptionTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleasePointDescriptionTextBox.TextChanged
        If (Me.controlIsLoaded) Then
            If (Me.ReleasePointDescriptionTextBox.Text.Trim.Length = 0) Then
                Me.m_releasePoint.SetReleasePointDescriptionNull()
            Else
                Me.m_releasePoint.ReleasePointDescription = Me.ReleasePointDescriptionTextBox.Text.Trim
            End If
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub CompanyCommentTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyCommentTextBox.TextChanged
        If (Me.controlIsLoaded) Then
            Select Case Me.CompanyCommentTextBox.Text.Trim
                Case String.Empty
                    Me.m_releasePoint.CompanyComment = Nothing
                Case Else
                    Me.m_releasePoint.CompanyComment = Me.CompanyCommentTextBox.Text.Trim
            End Select
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub CommentInternalTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles APCDCommentTextBox.TextChanged
        If (Me.controlIsLoaded) Then
            Select Case Me.APCDCommentTextBox.Text.Trim
                Case String.Empty
                    Me.m_releasePoint.APCDComment = Nothing
                Case Else
                    Me.m_releasePoint.APCDComment = Me.APCDCommentTextBox.Text.Trim
            End Select
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub YCoordinateTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YCoordinateTextBox.TextChanged
        If (Me.controlIsLoaded) Then
            If (Me.IsValidYCoordinate) Then
                Me.m_releasePoint.YCoordinate = CDec(Me.YCoordinateTextBox.Text.Trim)
                Call Me.ToggleButtonStatus_FieldChanged()
            End If
        End If
    End Sub

    Private Sub XCoordinateTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XCoordinateTextBox.TextChanged
        If (Me.controlIsLoaded) Then
            If (Me.IsValidXCoordinate) Then
                Me.m_releasePoint.XCoordinate = CDec(Me.XCoordinateTextBox.Text.Trim)
                Call Me.ToggleButtonStatus_FieldChanged()
            End If
        End If
    End Sub

    Private Sub ReleasePointTypeIDComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleasePointTypeComboBox.SelectedIndexChanged
        If (Me.controlIsLoaded = True) Then
            Me.m_releasePoint.ReleasePointTypeID = CInt(Me.ReleasePointTypeComboBox.SelectedValue)
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Sub ReleaseTypeSubTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleaseTypeSubTypeComboBox.SelectedIndexChanged
        If (Me.controlIsLoaded) Then
            If (Me.IsValidForm) Then
                Me.m_releasePoint.ReleaseTypeSubTypeID = CInt(Me.ReleaseTypeSubTypeComboBox.SelectedValue)
                Me.CreateReleasePointDetailRows()

                'save then refresh so we have real IDs
                If (Me.SaveReleasePoint) Then
                    MainForm.ReleasePointDetailTableAdapter.FillByReleasePointID(MainForm.EmissionsDataSet.ReleasePointDetail, Me.m_releasePoint.ReleasePointID)
                    Me.m_releasePointDetails_ORIGINAL = CType(MainForm.EmissionsDataSet.ReleasePointDetail.Copy, EmissionsInventory.EmissionsDataSet.ReleasePointDetailDataTable)
                End If
            End If
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

#Region "----- detail row create/generate rows -----"

    Private Sub CreateReleasePointDetailRows()

        Dim releaseTypeSubType As ReleasePointHelper.ReleaseTypeSubType = CType(Me.ReleaseTypeSubTypeComboBox.SelectedValue, ReleasePointHelper.ReleaseTypeSubType)
        Dim measurementLookupTable As DataTable = Emissions.Utility.MeasurementUtility.GetByReleaseTypeSubTypeID(releaseTypeSubType)
        Call Me.GenerateReleasePointDetailRows(measurementLookupTable, releaseTypeSubType)

    End Sub

    Private Sub GenerateReleasePointDetailRows(ByVal measurementLookupTable As DataTable, ByVal releaseTypeSubType As ReleasePointHelper.ReleaseTypeSubType)

        'first find the rows to be deleted and delete them
        For Each row As EmissionsDataSet.ReleasePointDetailRow In MainForm.EmissionsDataSet.ReleasePointDetail
            Dim tempRows As DataRow() = measurementLookupTable.Select("MeasurementID = " & row.MeasurementID.ToString)
            If (tempRows.Length = 0) Then
                row.Delete()
            End If
        Next

        'now find the rows to add and add them
        For Each measurementRow As DataRow In measurementLookupTable.Rows
            Dim tempRows As EmissionsDataSet.ReleasePointDetailRow() = CType(MainForm.EmissionsDataSet.ReleasePointDetail.Select("MeasurementID =" & CStr(measurementRow("MeasurementID"))), EmissionsInventory.EmissionsDataSet.ReleasePointDetailRow())
            If (tempRows.Length = 0) Then
                Dim measurementName As String = CStr(measurementRow(Me.EmissionsDataSet.Measurement.MeasurementNameColumn.ColumnName))
                Select Case releaseTypeSubType
                    Case ReleasePointHelper.ReleaseTypeSubType.Round, ReleasePointHelper.ReleaseTypeSubType.Other
                        Select Case measurementName
                            Case "Fenceline Distance"
                                'do nothing
                            Case Else
                                Call Me.AddDetailRow(measurementRow)
                        End Select

                    Case ReleasePointHelper.ReleaseTypeSubType.Area, ReleasePointHelper.ReleaseTypeSubType.Point
                        Call Me.AddDetailRow(measurementRow)
                End Select
            End If
        Next

    End Sub

    Private Sub AddDetailRow(ByVal measurementRow As DataRow)

        Dim detailRow As EmissionsDataSet.ReleasePointDetailRow = MainForm.EmissionsDataSet.ReleasePointDetail.NewReleasePointDetailRow
        With detailRow
            .ReleasePointID = Me.m_releasePoint.ReleasePointID
            .MeasurementID = CInt(measurementRow(Me.EmissionsDataSet.Measurement.MeasurementIDColumn.ColumnName))
            .DetailValue = 0
        End With

        Dim measurementEnum As ReleasePointHelper.MeasurementEnum = CType(CInt(measurementRow(Me.EmissionsDataSet.Measurement.MeasurementIDColumn.ColumnName)), ReleasePointHelper.MeasurementEnum)
        detailRow.UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(measurementEnum)

        MainForm.EmissionsDataSet.ReleasePointDetail.Rows.Add(detailRow)

    End Sub

#End Region '----- detail row create/generate rows -----

#Region "----- cancel and save events and methods -----"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If ((Not Me.m_releasePoint.RowState = DataRowState.Unchanged) OrElse (Me.m_changedValueCount > 0)) Then
            If (MessageBox.Show("You have unsaved changes. Do you wish to save them?", "Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Call Me.SaveReleasePoint()
            End If
        End If

        For Each ctl As Control In Me.Controls
            Me.ErrorProvider1.SetError(ctl, String.Empty)
        Next

        RaiseEvent CancelButton_Pressed()


    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (Me.IsValidForm) Then

            Dim changes As DataTable = MainForm.EmissionsDataSet.ReleasePointDetail.GetChanges
            If (Not changes Is Nothing) Then
                Call Me.CreateReleasePointDetailHistoryRows(changes)
                Me.m_releasePointDetails_ORIGINAL = CType(MainForm.EmissionsDataSet.ReleasePointDetail.Copy, EmissionsInventory.EmissionsDataSet.ReleasePointDetailDataTable)
            End If

            If (Me.SaveReleasePoint) Then
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Modified)

                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()

                'load a new release point history
                MainForm.EmissionsDataSet.ReleasePointHistory.Clear()
                Call Me.LoadHistoryRecord_ReleasePoint()

                'clear the changed count
                Me.m_changedValueCount = 0
            End If

            If (Me.m_isExcluded_Changed = True) Then
                Call Me.SaveReleasePointYear()
                MainForm.EmissionsDataSet.ReleasePointYearHistory.Clear()
                Call Me.LoadHistoryRecord_ReleasePointYear()
                Me.m_isExcluded_Changed = False
            End If

        End If

    End Sub

    Private Sub CreateReleasePointDetailHistoryRows(ByVal changes As DataTable)
        For Each row As DataRow In changes.Rows
            If (row.RowState = DataRowState.Modified) Then
                Dim id As Int32 = CInt(row(EmissionsDataSet.ReleasePointDetail.ReleasePointDetailIDColumn.ColumnName))
                Dim originalRow() As EmissionsDataSet.ReleasePointDetailRow = CType(Me.m_releasePointDetails_ORIGINAL.Select(EmissionsDataSet.ReleasePointDetail.ReleasePointDetailIDColumn.ColumnName & " = " & id), EmissionsInventory.EmissionsDataSet.ReleasePointDetailRow())
                Call Me.LoadHistoryRecord_ReleasePointDetail(originalRow(0))
            End If
        Next
    End Sub

    Private Sub LoadHistoryRecord_ReleasePointDetail(ByVal row As EmissionsDataSet.ReleasePointDetailRow)

        Dim rowReleasePointDetailHistory = CType(MainForm.EmissionsDataSet.ReleasePointDetailHistory.NewRow, EmissionsInventory.EmissionsDataSet.ReleasePointDetailHistoryRow)
        With rowReleasePointDetailHistory
            .ReleasePointDetailID = row.ReleasePointDetailID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ReleasePointID = row.ReleasePointID
            .MeasurementID = row.MeasurementID
            .DetailValue = row.DetailValue
            .UnitOfMeasurementID = row.UnitOfMeasurementID
        End With
        MainForm.EmissionsDataSet.ReleasePointDetailHistory.Rows.Add(rowReleasePointDetailHistory)

    End Sub

#End Region '----- cancel and save events and methods -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim blnIsValidForm As Boolean

        If (Not Me.IsValidAPCDID) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidYCoordinate) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidXCoordinate) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidReleasePointType) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidReleaseTypeSubType) Then
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

        Const errorMessage As String = "Invalid data: The longitude must be >= -85.9586 and <= -85.4135."
        Dim dataIsValid As Boolean

        If (Me.XCoordinateTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, errorMessage)
            Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)

        ElseIf (Not IsNumeric(Me.XCoordinateTextBox.Text.Trim.Length)) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, errorMessage)
            Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)

        Else
            Try
                Dim decValue = CDec(Me.XCoordinateTextBox.Text.Trim)
                If (decValue < -85.9586) OrElse (decValue > -85.4135) Then
                    dataIsValid = False
                    Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, errorMessage)
                    Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
                Else
                    dataIsValid = True
                    Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, String.Empty)
                End If
            Catch ex As Exception
                dataIsValid = False
                Me.ErrorProvider1.SetError(Me.XCoordinateTextBox, errorMessage)
                Me.ErrorProvider1.SetIconAlignment(Me.XCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
            End Try

        End If

        Return dataIsValid

    End Function

    'done
    Private Function IsValidYCoordinate() As Boolean
        'min 37.9963
        'max 38.3837
        Const errorMessage As String = "Invalid data: The latitude must be >= 37.9963 and <= 38.3837."
        Dim dataIsValid As Boolean

        If (Me.YCoordinateTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, errorMessage)
            Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
        ElseIf (Not IsNumeric(Me.YCoordinateTextBox.Text.Trim.Length)) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, errorMessage)
            Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            Try
                Dim decValue = CDec(Me.YCoordinateTextBox.Text.Trim)
                If (decValue < 37.9963) OrElse (decValue > 38.3837) Then
                    dataIsValid = False
                    Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, errorMessage)
                    Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
                Else
                    dataIsValid = True
                    Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, String.Empty)
                End If
            Catch ex As Exception
                dataIsValid = False
                Me.ErrorProvider1.SetError(Me.YCoordinateTextBox, errorMessage)
                Me.ErrorProvider1.SetIconAlignment(Me.YCoordinateTextBox, ErrorIconAlignment.MiddleLeft)
            End Try

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

    Private Function IsValidReleaseTypeSubType() As Boolean

        Dim dataIsValid As Boolean

        If (Me.ReleaseTypeSubTypeComboBox.SelectedIndex < 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.ReleaseTypeSubTypeComboBox, "Please select a sub-type.")
            Me.ErrorProvider1.SetIconAlignment(Me.ReleaseTypeSubTypeComboBox, ErrorIconAlignment.MiddleRight)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.ReleaseTypeSubTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidReleasePointType() As Boolean

        Dim dataIsValid As Boolean

        If (ReleasePointTypeComboBox.SelectedIndex < 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(ReleasePointTypeComboBox, "Please select a Release Point Type.")
            Me.ErrorProvider1.SetIconAlignment(Me.ReleasePointTypeComboBox, ErrorIconAlignment.MiddleRight)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ReleasePointTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

#End Region '----- Validation -----


#Region "----- buttons -----"

    Private Sub btnShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShutdown.Click

        Dim response As DialogResult

        If (Me.btnShutdown.Text = GlobalVariables.Words.Shutdown) Then
            response = MessageBox.Show("Are you sure you want to shut down this release point?", "Shut Down " & Me.m_releasePoint.ReleasePointAPCDID, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                Call Me.Shutdown()
            End If

        ElseIf (Me.btnShutdown.Text = GlobalVariables.Words.Delete) Then
            response = MessageBox.Show("This action cannot be undone. Are you sure?", "Delete " & Me.m_releasePoint.ReleasePointAPCDID, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (response = Windows.Forms.DialogResult.Yes) Then
                Me.m_releasePoint.Delete()
                MainForm.ReleasePointTableAdapter.Update(MainForm.EmissionsDataSet.ReleasePoint)
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Deleted)
            End If
        End If

    End Sub

    Private Sub Shutdown()

        'to shutdown set the end date in ReleasePoint...
        Me.m_releasePoint.EndDate = New Date(Me.m_releasePointYear.EmissionYear - 1, 12, 31)

        '... and operating status to PS in ReleasePointYear (load a history rec first)
        Call Me.LoadHistoryRecord_ReleasePointYear()
        Me.m_releasePointYear.OperatingStatusTypeEISID = GlobalVariables.OperatingStatus.Shutdown

        'now save both
        If ((Me.SaveReleasePoint()) AndAlso (Me.SaveReleasePointYear())) Then
            RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Shutdown)

            Call Me.SetInventoryStatus()
            Call Me.SetControlStatus()

            Call Me.LoadHistoryRecord_ReleasePoint()
            MainForm.EmissionsDataSet.ReleasePointYearHistory.Clear()
        End If

    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click

        If (Me.btnApprove.Text = GlobalVariables.Words.Approve) Then
            If ((Me.m_releasePointYear.IsExcluded) OrElse (Me.okToApprove)) Then
                Call Me.Approve()
            End If
        ElseIf (Me.btnApprove.Text = GlobalVariables.Words.Unapprove) Then
            Call Me.UnApprove()
        End If

    End Sub

    Private Sub Approve()

        Dim frm As New ApproveForm(Me.m_releasePointYear, "Approve Release Point")
        Dim response As DialogResult = frm.ShowDialog
        If (response = DialogResult.OK) Then
            Call Me.LoadHistoryRecord_ReleasePointYear()

            With Me.m_releasePointYear
                .ApprovalEmployeeID = GlobalVariables.Employee.EmployeeID
                .ApprovalDate = Date.Now
            End With

            If (Me.SaveReleasePointYear) Then
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.Approved)
                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()
                MainForm.EmissionsDataSet.ReleasePointYearHistory.Clear()
            End If
        End If

    End Sub

    Private Sub UnApprove()

        Dim frm As New ApproveForm(Me.m_releasePointYear, "Un-approve Release Point")
        Dim response As DialogResult = frm.ShowDialog
        If (response = DialogResult.OK) Then
            Call Me.LoadHistoryRecord_ReleasePointYear()

            With Me.m_releasePointYear
                .SetApprovalEmployeeIDNull()
                .SetApprovalDateNull()
            End With

            If (Me.SaveReleasePointYear) Then
                RaiseEvent SaveButton_Pressed(GlobalVariables.InventoryStatus.UnApproved)
                Call Me.SetInventoryStatus()
                Call Me.SetControlStatus()
                MainForm.EmissionsDataSet.ReleasePointYearHistory.Clear()
            End If
        End If

    End Sub

    Private Function okToApprove() As Boolean
     
        Dim ok As Boolean

        Dim type As ReleasePointHelper.ReleaseTypeSubType = CType(Me.ReleaseTypeSubTypeComboBox.SelectedValue, ReleasePointHelper.ReleaseTypeSubType)
        Select Case type
            Case ReleasePointHelper.ReleaseTypeSubType.Round, ReleasePointHelper.ReleaseTypeSubType.Other
                ok = Me.StackMeasurementsAreValid(type)
            Case ReleasePointHelper.ReleaseTypeSubType.Point, ReleasePointHelper.ReleaseTypeSubType.Area
                ok = Me.FugitiveMeasurementsAreValid(type)
        End Select

        Return ok

    End Function

    Private Function StackMeasurementsAreValid(ByVal subType As ReleasePointHelper.ReleaseTypeSubType) As Boolean

        Dim ok As Boolean = True
        Dim errorMessage As New StringBuilder
        Dim releaseTypeMeasurement As EmissionsDataSet.ReleaseTypeMeasurementRow = Nothing

        Try
            For Each row As EmissionsDataSet.ReleasePointDetailRow In MainForm.EmissionsDataSet.ReleasePointDetail
                Dim measurement As ReleasePointHelper.MeasurementEnum = CType(row.MeasurementID, ReleasePointHelper.MeasurementEnum)
                Try
                    releaseTypeMeasurement = Me.EmissionsDataSet.ReleaseTypeMeasurement.FindByMeasurementIDReleaseTypeSubTypeID(measurement, subType)

                    If ((row.DetailValue < releaseTypeMeasurement.MinimumValue) OrElse (row.DetailValue > releaseTypeMeasurement.MaximumValue)) Then
                        errorMessage.Append("Invalid data: ")
                        If (measurement = ReleasePointHelper.MeasurementEnum.Height) Then
                            errorMessage.Append("Height")
                        ElseIf (measurement = ReleasePointHelper.MeasurementEnum.Diameter) Then
                            errorMessage.Append("Diameter")
                        ElseIf (measurement = ReleasePointHelper.MeasurementEnum.Length) Then
                            errorMessage.Append("Length")
                        ElseIf (measurement = ReleasePointHelper.MeasurementEnum.Width) Then
                            errorMessage.Append("Width")
                        ElseIf (measurement = ReleasePointHelper.MeasurementEnum.FencelineDistance) Then
                            errorMessage.Append("Fenceline Distance")
                        ElseIf (measurement = ReleasePointHelper.MeasurementEnum.ExitGasTemperature) Then
                            errorMessage.Append("Exit Gas Temperature")
                        ElseIf (measurement = ReleasePointHelper.MeasurementEnum.ExitGasFlowRate) Then
                            errorMessage.Append("Exit Gas Flow Rate")
                        End If
                        errorMessage.Append(" must be between ")
                        errorMessage.Append(CStr(releaseTypeMeasurement.MinimumValue))
                        errorMessage.Append(" and ")
                        errorMessage.Append(CStr(releaseTypeMeasurement.MaximumValue))
                        errorMessage.Append(" inclusive.")

                        ok = False
                        Exit For
                    End If
                Catch ex As Exception
                    MessageBox.Show("Warning: Unable to look up control limits for stack property " & measurement.ToString() & " for subtype " & subType.ToString() & "!")
                    GlobalMethods.HandleError(ex)
                End Try
            Next

            If (ok = True) Then
                Me.ErrorProvider1.SetError(Me.ReleasePointDetailDataGridView, String.Empty)
            Else
                Me.ErrorProvider1.SetError(Me.ReleasePointDetailDataGridView, errorMessage.ToString)
                Me.ErrorProvider1.SetIconAlignment(Me.ReleasePointDetailDataGridView, ErrorIconAlignment.MiddleRight)
            End If

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            ok = False
        End Try

        Return ok

    End Function

    Private Function FugitiveMeasurementsAreValid(ByVal subType As ReleasePointHelper.ReleaseTypeSubType) As Boolean

        Dim ok As Boolean = True
        Dim lengthExists As Boolean = False
        Dim widthExists As Boolean = False
        Dim errorMessage As New StringBuilder
        Dim releaseTypeMeasurement As EmissionsDataSet.ReleaseTypeMeasurementRow = Nothing

        Try
            For Each row As EmissionsDataSet.ReleasePointDetailRow In MainForm.EmissionsDataSet.ReleasePointDetail
                Dim measurement As ReleasePointHelper.MeasurementEnum = CType(row.MeasurementID, ReleasePointHelper.MeasurementEnum)
                Try
                    releaseTypeMeasurement = Me.EmissionsDataSet.ReleaseTypeMeasurement.FindByMeasurementIDReleaseTypeSubTypeID(measurement, subType)

                    If ((row.DetailValue < releaseTypeMeasurement.MinimumValue) OrElse (row.DetailValue > releaseTypeMeasurement.MaximumValue)) Then
                        errorMessage.Append("Invalid data: ")
                        If (measurement = ReleasePointHelper.MeasurementEnum.Height) Then
                            errorMessage.Append("Height")
                        ElseIf (measurement = ReleasePointHelper.MeasurementEnum.Length) Then
                            errorMessage.Append("Length")
                        ElseIf (measurement = ReleasePointHelper.MeasurementEnum.Width) Then
                            errorMessage.Append("Width")
                        ElseIf (measurement = ReleasePointHelper.MeasurementEnum.HorizontalAngle) Then
                            errorMessage.Append("Horizontal Angle")
                        End If
                        errorMessage.Append(" must be between ")
                        errorMessage.Append(CStr(releaseTypeMeasurement.MinimumValue))
                        errorMessage.Append(" and ")
                        errorMessage.Append(CStr(releaseTypeMeasurement.MaximumValue))
                        errorMessage.Append(" inclusive. ")

                        ok = False
                        Exit For
                    End If

                Catch ex As Exception
                    MessageBox.Show("Warning: Unable to look up control limits for fugitive release point property " & measurement.ToString() & " for subtype " & subType.ToString() & "!")
                    GlobalMethods.HandleError(ex)
                End Try
            Next

            If (ok = True) Then
                If (lengthExists = True AndAlso widthExists = False) OrElse (lengthExists = False AndAlso widthExists = True) Then
                    errorMessage.Append("Invalid data: If length or width is provided both must be provided.")
                    ok = False
                End If
            Else
            End If

            Me.ErrorProvider1.SetError(Me.ReleasePointDetailDataGridView, errorMessage.ToString)
            Me.ErrorProvider1.SetIconAlignment(Me.ReleasePointDetailDataGridView, ErrorIconAlignment.MiddleRight)

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            ok = False
        End Try

        Return ok

    End Function

#End Region '----- buttons -----

    Private Sub LoadHistoryRecord_ReleasePointYear()

        Dim row As EmissionsDataSet.ReleasePointYearHistoryRow = MainForm.EmissionsDataSet.ReleasePointYearHistory.NewReleasePointYearHistoryRow ' CType(MainForm.EmissionsDataSet.ReleasePointYearHistory.NewRow, EmissionsInventory.EmissionsDataSet.ReleasePointYearHistoryRow)
        With row
            .ReleasePointYearID = Me.m_releasePointYear.ReleasePointYearID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ReleasePointID = Me.m_releasePointYear.ReleasePointID
            .EmissionYear = Me.m_releasePointYear.EmissionYear
            .OperatingStatusTypeEISID = Me.m_releasePointYear.OperatingStatusTypeEISID
            .IsExcluded = Me.m_releasePointYear.IsExcluded

            If (Me.m_releasePointYear.IsDoneDateNull) Then
                .SetDoneDateNull()
            Else
                .DoneDate = Me.m_releasePointYear.DoneDate
            End If

            If (Me.m_releasePointYear.IsDoneByNull) Then
                .SetDoneByNull()
            Else
                .DoneBy = Me.m_releasePointYear.DoneBy
            End If

            If (Me.m_releasePointYear.IsApprovalEmployeeIDNull) Then
                .SetApprovalEmployeeIDNull()
            Else
                .ApprovalEmployeeID = Me.m_releasePointYear.ApprovalEmployeeID
            End If

            If (Me.m_releasePointYear.IsApprovalDateNull) Then
                .SetApprovalDateNull()
            Else
                .ApprovalDate = Me.m_releasePointYear.ApprovalDate
            End If

            .ApprovalComment = Me.m_releasePointYear.ApprovalComment
        End With
        MainForm.EmissionsDataSet.ReleasePointYearHistory.Rows.Add(row)

    End Sub

    Private Sub ReleasePointDetailDataGridView_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReleasePointDetailDataGridView.CellEndEdit
        Me.ReleasePointDetailDataGridView.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub ReleasePointDetailDataGridView_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReleasePointDetailDataGridView.CellValueChanged
        If (Me.controlIsLoaded = True) Then
            Call Me.ToggleButtonStatus_FieldChanged()
        End If
    End Sub

    Private Function SaveReleasePoint() As Boolean

        Dim saved As Boolean

        Me.Validate()
        MainForm.ReleasePointBindingSource.EndEdit()
        MainForm.ReleasePointHistoryBindingSource.EndEdit()
        ''MainForm.ReleasePointDetailBindingSource.EndEdit()
        ''MainForm.ReleasePointDetailHistoryBindingSource.EndEdit()

        Try
            MainForm.ReleasePointTableAdapter.Update(MainForm.EmissionsDataSet.ReleasePoint)
            MainForm.ReleasePointHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ReleasePointHistory)

            MainForm.ReleasePointDetailTableAdapter.Update(MainForm.EmissionsDataSet.ReleasePointDetail)
            MainForm.ReleasePointDetailHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ReleasePointDetailHistory)

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

    Private Function SaveReleasePointYear() As Boolean

        Dim saved As Boolean

        Try
            MainForm.ReleasePointYearTableAdapter.Update(MainForm.EmissionsDataSet.ReleasePointYear)
            MainForm.ReleasePointYearHistoryTableAdapter.Update(MainForm.EmissionsDataSet.ReleasePointYearHistory)
            saved = True
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saved = False
        End Try

        Return saved

    End Function

    Private Sub ToggleShutdownButtonText()

        If (Me.m_releasePoint.ReleasePointEISID < 0) Then
            Me.btnShutdown.Text = GlobalVariables.Words.Delete
        Else
            Me.btnShutdown.Text = GlobalVariables.Words.Shutdown
        End If

    End Sub

End Class

