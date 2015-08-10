Imports APCD.Emissions
Imports System.Text

Public Class ProcessThroughputAddEditForm

    Private m_blnFormIsLoaded As Boolean = False
    Private m_process As EmissionsDataSet.ProcessRow
    Private m_processDetailPeriod As EmissionsDataSet.ProcessDetailPeriodRow
    Private m_DMLMode As GlobalVariables.DMLMode

    Sub New(ByVal process As EmissionsDataSet.ProcessRow, ByVal processDetailPeriod As EmissionsDataSet.ProcessDetailPeriodRow, ByVal mode As GlobalVariables.DMLMode)
        InitializeComponent()
        Me.m_process = process
        Me.m_processDetailPeriod = processDetailPeriod
        Me.m_DMLMode = mode
    End Sub

    Private m_dtbProcessParameterTypeLookupTable As DataTable

#Region "----- startup -----"

    Private Sub ProcessThroughputAddEditForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.m_blnFormIsLoaded = False
        Me.m_dtbProcessParameterTypeLookupTable = Utility.ProcessParameterTypeUtility.GetLookupTable
        Call Me.LoadComboBox_ProcessParameter()
        Call Me.AssignControlValues()
        Me.m_blnFormIsLoaded = True

    End Sub

    Private Sub LoadComboBox_ProcessParameter()

        Select Case Me.m_DMLMode
            Case GlobalVariables.DMLMode.Insert
                If (MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows.Count = 0) Then
                    Tools.WindowsForms.LoadComboBox(Me.m_dtbProcessParameterTypeLookupTable, Me.ProcessParameterComboBox, False)
                Else
                    Dim filteredView As DataView
                    Dim filter As New StringBuilder

                    filteredView = Me.m_dtbProcessParameterTypeLookupTable.DefaultView
                    With filter
                        .Append(Constants.ProcessParameterTypeConstants.FieldName.ProcessParameterTypeID)
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._Not)
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._In)
                        .Append(Tools.Constants.Character.Space)
                        .Append(Tools.Constants.Character.LeftParenthesis)
                        For rowCount As Int32 = 0 To MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows.Count - 1
                            If (rowCount > 0) Then
                                .Append(Tools.Constants.Character.Comma)
                            End If
                            .Append(CStr(MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows(rowCount)(Constants.ProcessDetailPeriodConstants.FieldName.ProcessParameterTypeID)))
                        Next
                        .Append(Tools.Constants.Character.RightParenthesis)
                    End With

                    filteredView.RowFilter = filter.ToString
                    Tools.WindowsForms.LoadComboBox(filteredView, Me.ProcessParameterComboBox)
                End If

                Me.ProcessParameterComboBox.SelectedIndex = -1

            Case GlobalVariables.DMLMode.Update
                Tools.WindowsForms.LoadComboBox(Me.m_dtbProcessParameterTypeLookupTable, Me.ProcessParameterComboBox, False)
        End Select

    End Sub

    Private Sub AssignControlValues()

        If (Me.m_DMLMode = GlobalVariables.DMLMode.Insert) Then
            Me.Text = "Add Process Throughput"
            Me.ProcessParameterComboBox.SelectedIndex = -1
        Else
            Me.Text = "Edit Process Throughput"
            Me.ProcessParameterComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ProcessParameterComboBox, Me.m_processDetailPeriod.ProcessParameterTypeID)
            Me.ProcessParameterValueTextBox.Text = CStr(Me.m_processDetailPeriod.ProcessParameterValue)
            Call Me.LoadUnitOfMeasurementComboBox()
            Me.UnitOfMeasurementComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.UnitOfMeasurementComboBox, Me.m_processDetailPeriod.UnitOfMeasurementID)
            Call Me.ToggleControlStatus()
        End If

    End Sub

    Private Sub LoadUnitOfMeasurementComboBox()

        With Me.m_processDetailPeriod
            If ((.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.AnnualThroughput) _
                OrElse (.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.OzoneSeasonDailyThroughput)) Then
                Me.UnitOfMeasurementTableAdapter.FillByThroughputTypeID(Me.EmissionsDataSet.UnitOfMeasurement, Me.m_process.ThroughputTypeID)
            Else
                Me.UnitOfMeasurementTableAdapter.FillByProcessParameterTypeID(Me.EmissionsDataSet.UnitOfMeasurement, .ProcessParameterTypeID)
            End If
        End With
        Tools.WindowsForms.LoadComboBox(Me.EmissionsDataSet.UnitOfMeasurement, Me.UnitOfMeasurementComboBox, False)

    End Sub

    Private Sub ToggleControlStatus()

        Me.ProcessParameterComboBox.Enabled = False
        Me.UnitOfMeasurementComboBox.Enabled = False

    End Sub

#End Region '----- startup -----

#Region "----- buttons -----"

    Private Sub ProcessParameterValueTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ProcessParameterValueTextBox.KeyPress

        If ((Asc(e.KeyChar) = 8) OrElse (Asc(e.KeyChar) = 46)) Then 'allow backspace and period
            '
        ElseIf (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If (Me.IsValidForm) Then
            If (Me.m_DMLMode = GlobalVariables.DMLMode.Insert) Then
                Call Me.AddRowForShow()
            Else
                Call Me.UpdateRowForShow()
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

#End Region '----- buttons -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim isValidData As Boolean

        If (Not Me.IsValidProcessParameter) Then
            isValidData = False
        ElseIf (Not Me.IsValidValue) Then
            isValidData = False
        ElseIf (Not Me.IsValidUnitOfMeasurement) Then
            isValidData = False
        Else
            isValidData = True
        End If

        Return isValidData

    End Function

    Private Function IsValidProcessParameter() As Boolean

        Dim isValidData As Boolean

        If (Me.ProcessParameterComboBox.SelectedIndex = -1) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.ProcessParameterComboBox, "Please select a parameter.")
            Me.ErrorProvider1.SetIconAlignment(Me.ProcessParameterComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            isValidData = True
            Me.ErrorProvider1.SetError(Me.ProcessParameterComboBox, String.Empty)
        End If

        Return isValidData

    End Function

    Private Function IsValidValue() As Boolean

        Dim isValidData As Boolean
        Dim intSelectedProcessParameter As Int32 = CInt(Me.ProcessParameterComboBox.SelectedValue)
        Dim strValue As String = Me.ProcessParameterValueTextBox.Text.Trim

        If (strValue.Length = 0) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.ProcessParameterValueTextBox, "Enter a value")

        ElseIf (Not IsNumeric(strValue)) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.ProcessParameterValueTextBox, "Enter a value")

        Else
            Dim dblValue As Double = CDbl(strValue)

            If (dblValue < 0) Then
                isValidData = False
                Me.ErrorProvider1.SetError(Me.ProcessParameterValueTextBox, "Value must be greater than 0.")
            Else
                Select Case intSelectedProcessParameter
                    Case 1, 2, 5, 6, 8, 13 'Throughput, heat content, material vapor pressure, material density,total dissolved solids, O3D
                        isValidData = True

                    Case 3, 4, 7 'percent ash, percent sulfur, material VOC content
                        If (dblValue > 100) Then
                            isValidData = False
                            Me.ErrorProvider1.SetError(Me.ProcessParameterValueTextBox, GlobalVariables.ErrorPrompt.Misc.ValueMustBeBetween0And100)
                        Else
                            isValidData = True
                        End If

                    Case 9 'hours per day
                        If (dblValue < 1 OrElse dblValue > 24) Then
                            isValidData = False
                            Me.ErrorProvider1.SetError(Me.ProcessParameterValueTextBox, "Value must be between 1 and 24")
                        Else
                            isValidData = True
                        End If

                    Case 10 'days per week
                        If (dblValue < 1 OrElse dblValue > 7) Then
                            isValidData = False
                            Me.ErrorProvider1.SetError(Me.ProcessParameterValueTextBox, "Value must be between 1 and 7")
                        Else
                            isValidData = True
                        End If

                    Case 11 'weeks per year
                        If (dblValue < 1 OrElse dblValue > 52) Then
                            isValidData = False
                            Me.ErrorProvider1.SetError(Me.ProcessParameterValueTextBox, "Value must be between 1 and 52")
                        Else
                            isValidData = True
                        End If

                    Case 12 'hours per year
                        If (dblValue < 1 OrElse dblValue > 8784) Then
                            isValidData = False
                            Me.ErrorProvider1.SetError(Me.ProcessParameterValueTextBox, "Value must be between 1 and 8784")
                        Else
                            isValidData = True
                        End If
                End Select
            End If
        End If

        If (isValidData = True) Then
            Me.ErrorProvider1.SetError(Me.ProcessParameterValueTextBox, String.Empty)
        Else
            Me.ErrorProvider1.SetIconAlignment(Me.ProcessParameterValueTextBox, ErrorIconAlignment.MiddleLeft)
        End If

        Return isValidData

    End Function

    Private Function IsValidUnitOfMeasurement() As Boolean

        Dim isValidData As Boolean

        If (Me.UnitOfMeasurementComboBox.SelectedIndex = -1) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.UnitOfMeasurementComboBox, "Please select a unit.")
            Me.ErrorProvider1.SetIconAlignment(Me.UnitOfMeasurementComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            isValidData = True
            Me.ErrorProvider1.SetError(Me.UnitOfMeasurementComboBox, String.Empty)
        End If

        Return isValidData

    End Function

#End Region '----- Validation -----

#Region "----- changed events -----"

    Private Sub ProcessParameterComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessParameterComboBox.SelectedIndexChanged

        If (m_blnFormIsLoaded = True) Then
            Me.m_processDetailPeriod.ProcessParameterTypeID = CInt(ProcessParameterComboBox.SelectedValue)

            Call Me.LoadUnitOfMeasurementComboBox()
            If (Me.UnitOfMeasurementComboBox.Items.Count > 1) Then
                Me.UnitOfMeasurementComboBox.SelectedIndex = -1
            End If

            'if user selected O3D, set the index to the UOM and disable the control
            If (Me.m_processDetailPeriod.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.OzoneSeasonDailyThroughput) Then
                Dim unitOfMeasurement As Int32 = Me.GetAnnualThroughputUnitOfMeasurement
                Me.UnitOfMeasurementComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.UnitOfMeasurementComboBox, unitOfMeasurement)
                Me.UnitOfMeasurementComboBox.Enabled = False
            Else
                Me.UnitOfMeasurementComboBox.Enabled = True
            End If

        End If

    End Sub

    Private Function GetAnnualThroughputUnitOfMeasurement() As Int32

        Dim UOM As Int32 = -1

        For Each row As EmissionsDataSet.ProcessDetailPeriodRow In MainForm.EmissionsDataSet.ProcessDetailPeriod
            If (row.ProcessParameterTypeID = GlobalVariables.ProcessParameterTypeEnum.AnnualThroughput) Then
                UOM = row.UnitOfMeasurementID
                Exit For
            End If
        Next

        Return UOM

    End Function

    Private Sub ProcessParameterValueTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessParameterValueTextBox.TextChanged
        If (m_blnFormIsLoaded = True) Then
            If (Me.ProcessParameterValueTextBox.Text.Trim.Length > 0) Then
                If (IsNumeric(Me.ProcessParameterValueTextBox.Text.Trim)) Then
                    Me.m_processDetailPeriod.ProcessParameterValue = CDbl(Me.ProcessParameterValueTextBox.Text.Trim)
                End If
            End If
        End If
    End Sub

    Private Sub UnitOfMeasurementComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnitOfMeasurementComboBox.SelectedIndexChanged
        If (m_blnFormIsLoaded = True) Then
            Me.m_processDetailPeriod.UnitOfMeasurementID = CInt(Me.UnitOfMeasurementComboBox.SelectedValue)
        End If
    End Sub

#End Region '----- changed events -----

    Private Sub AddRowForShow()

        Dim row As EmissionsDataSet.Process_ThroughputTabRow = MainForm.EmissionsDataSet.Process_ThroughputTab.NewProcess_ThroughputTabRow
        With row
            .ProcessDetailPeriodID = Me.m_processDetailPeriod.ProcessDetailPeriodID
            .ProcessID = Me.m_processDetailPeriod.ProcessID
            .EmissionYear = Me.m_processDetailPeriod.EmissionYear
            .ProcessParameterTypeName = Me.ProcessParameterComboBox.Text
            .ProcessParameterValue = CDbl(Me.ProcessParameterValueTextBox.Text.Trim)
            .UnitOfMeasurementName = Me.UnitOfMeasurementComboBox.Text
        End With
        MainForm.EmissionsDataSet.Process_ThroughputTab.Rows.Add(row)

    End Sub

    Private Sub UpdateRowForShow()

        For Each row As EmissionsDataSet.Process_ThroughputTabRow In MainForm.EmissionsDataSet.Process_ThroughputTab
            If (row.ProcessDetailPeriodID = Me.m_processDetailPeriod.ProcessDetailPeriodID) Then
                row.ProcessParameterValue = CDbl(Me.ProcessParameterValueTextBox.Text.Trim)
                Exit For
            End If
        Next

    End Sub

End Class