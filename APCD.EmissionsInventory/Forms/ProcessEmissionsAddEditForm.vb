Imports APCD.Emissions
Imports System.Text

Public Class ProcessEmissionsAddEditForm

    Private m_blnFormIsLoaded As Boolean = False
    Private m_blnEmissionFactorChanged As Boolean = False
    Private m_DMLMode As GlobalVariables.DMLMode
    Private m_processEmission As EmissionsDataSet.ProcessEmissionRow
    Private m_isFactorRequired As Boolean = False

    'Private m_intAnnualThroughputUOMID As Int32 = -1
    Private m_dblAnnualThroughput As Double = -1
    Private m_dblOzoneSeasonDailyThroughput As Double = -1
    Private m_strThroughputUnits As String = String.Empty

    Private m_pollutant As EmissionsDataSet.PollutantRow

    Private m_pollutantLookupView As DataView = GlobalVariables.LookupTable.Pollutant.DefaultView

    Private m_intProcessEmissionID As Int32

    Sub New(ByVal processEmission As EmissionsDataSet.ProcessEmissionRow, ByVal mode As GlobalVariables.DMLMode)
        InitializeComponent()
        Me.m_processEmission = processEmission
        Me.m_DMLMode = mode
    End Sub

#Region "----- startup -----"

    Private Sub ProcessEmissionsAddEditForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.m_blnFormIsLoaded = False
        Me.m_blnEmissionFactorChanged = False

        Call Me.LoadComboBoxes()
        Call Me.ThroughputLookup()
        Call Me.AssignControlValues()

        Me.m_blnFormIsLoaded = True

    End Sub

    Private Sub LoadComboBoxes()

        ' pollutant
        If (Me.m_processEmission.EmissionYear = Now.Date.Year - 1) Then
            Me.m_pollutantLookupView.RowFilter = "LastInventoryYear IS NULL"
        Else
            Me.m_pollutantLookupView.RowFilter = "LastInventoryYear IS NULL OR LastInventoryYear >= " & CStr(Me.m_processEmission.EmissionYear)
        End If
        Call Me.LoadComboBox_Pollutant()

        ' emission period type
        Dim emissionPeriodLookupTable As DataTable = Utility.EmissionPeriodTypeUtility.GetLookupTable
        Dim emissionPeriodTypeView As DataView = emissionPeriodLookupTable.DefaultView
        If (Me.m_processEmission.EmissionYear = Now.Date.Year - 1) Then
            emissionPeriodTypeView.RowFilter = "EmissionPeriodTypeID NOT IN ('U','1','2','3','4','5','6','7','8','9','10','11','12')"
        End If
        Tools.WindowsForms.LoadComboBox(emissionPeriodTypeView, Me.EmissionPeriodTypeComboBox)

        ' Calculation Method
        Dim calculationMethodLookupTable As DataTable = Utility.EmissionCalculationMethodUtility.GetLookupTable
        Tools.WindowsForms.LoadComboBox(calculationMethodLookupTable, Me.EmissionCalculationMethodComboBox, False)

    End Sub

    Private Sub LoadComboBox_Pollutant()

        Select Case Me.m_DMLMode
            Case GlobalVariables.DMLMode.Insert
                If (MainForm.EmissionsDataSet.ProcessEmission.Rows.Count = 0) Then
                    Tools.WindowsForms.LoadComboBox(Me.m_pollutantLookupView, Me.PollutantComboBox)
                Else
                    Dim filter As New StringBuilder
                    With filter
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._And)
                        .Append(Tools.Constants.Character.Space)

                        .Append(Constants.ProcessEmissionConstants.FieldName.PollutantID)
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._Not)
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._In)
                        .Append(Tools.Constants.Character.Space)
                        .Append(Tools.Constants.Character.LeftParenthesis)
                        For rowCount As Int32 = 0 To MainForm.EmissionsDataSet.ProcessEmission.Rows.Count - 1
                            If (rowCount > 0) Then
                                .Append(Tools.Constants.Character.Comma)
                            End If
                            Dim pollutantID As Int32 = CInt(MainForm.EmissionsDataSet.ProcessEmission.Rows(rowCount)(Constants.PollutantConstants.FieldName.PollutantID))

                            Select Case pollutantID
                                'allow CO, NOx, VOC to always be in the list
                                Case 589, 602, 624
                                    .Append("-1")
                                Case Else
                                    .Append(pollutantID.ToString)
                            End Select

                        Next
                        .Append(Tools.Constants.Character.RightParenthesis)
                    End With

                    Me.m_pollutantLookupView.RowFilter &= filter.ToString
                    Tools.WindowsForms.LoadComboBox(Me.m_pollutantLookupView, Me.PollutantComboBox)
                    Me.PollutantComboBox.SelectedIndex = -1
                End If

            Case Else ' GlobalVariables.DMLMode.Update, .View
                Tools.WindowsForms.LoadComboBox(Me.m_pollutantLookupView, Me.PollutantComboBox)
        End Select

    End Sub

    Private Sub AssignControlValues()

        Select Case Me.m_DMLMode
            Case GlobalVariables.DMLMode.Insert
                Me.Text = "Add Emission"
                Call Me.SetComboBoxDefaults()

                Me.EmissionValueUnitOfMeasurementLabel.Text = String.Empty
                Me.EmissionFactorValueUnitOfMeasurementLabel.Text = String.Empty
                'Me.EmissionFactorPanel.Visible = False
                Me.EmissionFactorPanel.Visible =True ' For now; see TODO item below.
                Me.btnCancel.Visible = True
            Case GlobalVariables.DMLMode.Update
                Me.Text = "Edit Emission"
                Me.PollutantComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.PollutantComboBox, Me.m_processEmission.PollutantID)
                Me.EmissionPeriodTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.EmissionPeriodTypeComboBox, Me.m_processEmission.EmissionPeriodTypeID)
                Me.EmissionValueTextBox.Text = CStr(Me.m_processEmission.EmissionValue)
                Me.EmissionCalculationMethodComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.EmissionCalculationMethodComboBox, Me.m_processEmission.EmissionCalculationMethodID)
                Me.m_pollutant = GlobalVariables.LookupTable.Pollutant.FindByPollutantID(CInt(Me.m_processEmission.PollutantID))
                Call Me.SetEmissionValueUnitOfMeasurementLabelText()

                'TODO 2015-09-17 BJF - Allow entry of an emission factor for 
                ' calculation methods Stack Test, Material Balance, and
                ' EPA Speciation Profile as well as requiring one for the
                ' emission-factor methods.
                ' In the meantime, we'll display the field regardless,
                ' but adjust its label.
                Me.EmissionFactorValueTextBox.Text = CStr(Me.m_processEmission.EmissionFactorValue)
                Call Me.SetEmissionFactorValueUnitOfMeasurementLabelText()
                Me.EmissionFactorPanel.Visible = True
                Me.m_isFactorRequired = CBool(Emissions.Utility.EmissionCalculationMethodUtility.GetIsEmissionFactorRequired(Me.m_processEmission.EmissionCalculationMethodID))
                If (Me.m_isFactorRequired = True) Then
                    '    Me.EmissionFactorValueTextBox.Text = CStr(Me.m_processEmission.EmissionFactorValue)
                    '    Call Me.SetEmissionFactorValueUnitOfMeasurementLabelText()
                    '    Me.EmissionFactorPanel.Visible = True
                    Me.EmissionFactorValueLabel.Text = "* Emission Factor:" ' required
                Else
                    '    Me.EmissionFactorValueTextBox.Text = String.Empty
                    '    Me.EmissionFactorValueUnitOfMeasurementLabel.Text = String.Empty
                    '    Me.EmissionFactorPanel.Visible = False
                    Me.EmissionFactorValueLabel.Text = "Emission Factor If Any:"   ' optional
                End If

                If (Me.m_processEmission.IsCommentPublicNull) Then
                    Me.CommentPublicTextBox.Text = String.Empty
                Else
                    Me.CommentPublicTextBox.Text = Me.m_processEmission.CommentPublic
                End If

                If (Me.m_processEmission.IsCommentInternalNull) Then
                    Me.CommentInternalTextBox.Text = String.Empty
                Else
                    Me.CommentInternalTextBox.Text = Me.m_processEmission.CommentInternal
                End If

                Me.PollutantComboBox.Enabled = False
                Me.EmissionPeriodTypeComboBox.Enabled = False
                Me.EmissionCalculationMethodComboBox.Enabled = True     ' BJF 2015-08-04 Changed from False.
                Me.btnCancel.Visible = True
            Case Else
                Me.Text = "View Emission"
                Me.PollutantComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.PollutantComboBox, Me.m_processEmission.PollutantID)
                Me.EmissionPeriodTypeComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.EmissionPeriodTypeComboBox, Me.m_processEmission.EmissionPeriodTypeID)
                Me.EmissionValueTextBox.Text = CStr(Me.m_processEmission.EmissionValue)
                Me.EmissionValueTextBox.Enabled = False

                Me.EmissionCalculationMethodComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.EmissionCalculationMethodComboBox, Me.m_processEmission.EmissionCalculationMethodID)
                Me.EmissionCalculationMethodComboBox.Enabled = False

                Me.m_pollutant = GlobalVariables.LookupTable.Pollutant.FindByPollutantID(CInt(Me.m_processEmission.PollutantID))
                Call Me.SetEmissionValueUnitOfMeasurementLabelText()

                'TODO: See above under Update.
                Me.EmissionFactorValueTextBox.Text = CStr(Me.m_processEmission.EmissionFactorValue)
                Me.EmissionFactorValueTextBox.Enabled = False
                Call Me.SetEmissionFactorValueUnitOfMeasurementLabelText()
                Me.EmissionFactorPanel.Visible = True
                Me.m_isFactorRequired = CBool(Emissions.Utility.EmissionCalculationMethodUtility.GetIsEmissionFactorRequired(Me.m_processEmission.EmissionCalculationMethodID))

                If (Me.m_isFactorRequired = True) Then
                    '    Me.EmissionFactorValueTextBox.Text = CStr(Me.m_processEmission.EmissionFactorValue)
                    '    Me.EmissionFactorValueTextBox.Enabled = False
                    '    Call Me.SetEmissionFactorValueUnitOfMeasurementLabelText()
                    '    Me.EmissionFactorPanel.Visible = True
                    Me.EmissionFactorValueLabel.Text = "* Emission Factor:" ' required
                Else
                    '    Me.EmissionFactorValueTextBox.Text = String.Empty
                    '    Me.EmissionFactorValueUnitOfMeasurementLabel.Text = String.Empty
                    '    Me.EmissionFactorPanel.Visible = False
                    Me.EmissionFactorValueLabel.Text = "Emission Factor:"   ' optional
                End If

                If (Me.m_processEmission.IsCommentPublicNull) Then
                    Me.CommentPublicTextBox.Text = String.Empty
                Else
                    Me.CommentPublicTextBox.Text = Me.m_processEmission.CommentPublic
                End If
                Me.CommentPublicTextBox.Enabled = False

                If (Me.m_processEmission.IsCommentInternalNull) Then
                    Me.CommentInternalTextBox.Text = String.Empty
                Else
                    Me.CommentInternalTextBox.Text = Me.m_processEmission.CommentInternal
                End If
                Me.CommentInternalTextBox.Enabled = False

                Me.PollutantComboBox.Enabled = False
                Me.EmissionPeriodTypeComboBox.Enabled = False
                Me.EmissionCalculationMethodComboBox.Enabled = False
                Me.btnCancel.Visible = False ' No need to show two buttons when they both have the same effect.
        End Select

    End Sub

    Private Sub SetComboBoxDefaults()

        Me.PollutantComboBox.SelectedIndex = -1

        Me.EmissionPeriodTypeComboBox.SelectedIndex = -1
        Me.EmissionPeriodTypeComboBox.Enabled = False

        Me.EmissionCalculationMethodComboBox.SelectedIndex = -1

    End Sub

    ''' <summary>
    ''' Look up the throughput value and units for the process.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ThroughputLookup()
        Try
            Dim UOMID As Int32 = -1
            Dim text As String = String.Empty
            Dim isAnnualFound As Boolean = False

            If (MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows.Count = 0) Then
                text = Tools.Constants.Character.QuestionMark
            Else
                For Each row As EmissionsDataSet.ProcessDetailPeriodRow In MainForm.EmissionsDataSet.ProcessDetailPeriod
                    If (row.ProcessParameterTypeID = 1) Then
                        UOMID = row.UnitOfMeasurementID
                        Me.m_dblAnnualThroughput = row.ProcessParameterValue
                        'Exit For
                        isAnnualFound = True
                    ElseIf (row.ProcessParameterTypeID = 13) Then
                        Me.m_dblOzoneSeasonDailyThroughput = row.ProcessParameterValue
                        If isAnnualFound Then
                            Exit For
                        End If
                    End If
                Next

                If (UOMID = -1) Then
                    text = Tools.Constants.Character.QuestionMark
                Else
                    Dim UOM As EmissionsDataSet.UnitOfMeasurementRow = GlobalVariables.LookupTable.UnitOfMeasurement.FindByUnitOfMeasurementID(UOMID)
                    text = UOM.UnitOfMeasurementName
                End If
            End If
            Me.m_strThroughputUnits = text

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
        End Try
    End Sub

#End Region '----- startup -----

#Region "----- buttons -----"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        If (Me.IsValidForm) Then
            Select Case Me.m_DMLMode
                Case GlobalVariables.DMLMode.Insert
                    Call Me.AddRowForShow()
                Case GlobalVariables.DMLMode.Update
                    Call Me.UpdateRowForShow()
                Case Else
                    ' Just close the window.
            End Select

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

#End Region '----- buttons -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim isValidData As Boolean

        If (Not Me.IsValidPollutant) Then
            isValidData = False
        ElseIf (Not Me.IsValidEmissionPeriodType) Then
            isValidData = False
        ElseIf (Not Me.IsValidEmissionValue) Then
            isValidData = False
        ElseIf (Not Me.IsValidEmissionCalculationMethod) Then
            isValidData = False
        ElseIf (Not Me.IsValidEmissionFactorValue) Then
            isValidData = False
        Else
            isValidData = True
        End If

        Return isValidData

    End Function

    Private Function IsValidPollutant() As Boolean

        Dim isValidData As Boolean

        If (Me.PollutantComboBox.SelectedIndex = -1) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.PollutantComboBox, "Please select a pollutant.")
            Me.ErrorProvider1.SetIconAlignment(Me.PollutantComboBox, ErrorIconAlignment.MiddleRight)
        Else
            isValidData = True
            Me.ErrorProvider1.SetError(Me.PollutantComboBox, String.Empty)
        End If

        Return isValidData

    End Function

    Private Function IsValidEmissionPeriodType() As Boolean

        Dim isValidData As Boolean

        If (Me.EmissionPeriodTypeComboBox.SelectedIndex = -1) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.EmissionPeriodTypeComboBox, "Please select a period.")
            Me.ErrorProvider1.SetIconAlignment(Me.EmissionPeriodTypeComboBox, ErrorIconAlignment.MiddleRight)

        ElseIf (CStr(Me.EmissionPeriodTypeComboBox.SelectedValue) = "U") Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.EmissionPeriodTypeComboBox, "Please select a value other than '!Unspecified'")
            Me.ErrorProvider1.SetIconAlignment(Me.EmissionPeriodTypeComboBox, ErrorIconAlignment.MiddleRight)

        Else
            isValidData = True
            Me.ErrorProvider1.SetError(Me.EmissionPeriodTypeComboBox, String.Empty)
        End If

        Return isValidData

    End Function

    Private Function IsValidEmissionValue() As Boolean

        Dim isValidData As Boolean
        Dim value As String = Me.EmissionValueTextBox.Text.Trim

        If (value.Length = 0) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.EmissionValueTextBox, GlobalVariables.ErrorPrompt.Misc.ValueMustBeGreaterThanOrEqualToZero)
            Me.ErrorProvider1.SetIconAlignment(Me.EmissionValueTextBox, ErrorIconAlignment.MiddleRight)

        ElseIf (Not IsNumeric(value)) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.EmissionValueTextBox, GlobalVariables.ErrorPrompt.Misc.ValueMustBeGreaterThanOrEqualToZero)
            Me.ErrorProvider1.SetIconAlignment(Me.EmissionValueTextBox, ErrorIconAlignment.MiddleRight)

        Else
            Dim dblValue As Double = CDbl(value)
            If (dblValue < 0) Then
                isValidData = False
                Me.ErrorProvider1.SetError(Me.EmissionValueTextBox, GlobalVariables.ErrorPrompt.Misc.ValueMustBeGreaterThanOrEqualToZero)
                Me.ErrorProvider1.SetIconAlignment(Me.EmissionValueTextBox, ErrorIconAlignment.MiddleRight)
            Else
                isValidData = True
                Me.ErrorProvider1.SetError(Me.EmissionValueTextBox, String.Empty)
            End If
        End If

        Return isValidData

    End Function

    Private Function IsValidEmissionCalculationMethod() As Boolean

        Dim isValidData As Boolean

        If (Me.EmissionCalculationMethodComboBox.SelectedIndex = -1) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.EmissionCalculationMethodComboBox, "Please select a calculation method.")
            Me.ErrorProvider1.SetIconAlignment(Me.EmissionCalculationMethodComboBox, ErrorIconAlignment.MiddleRight)
        Else
            isValidData = True
            Me.ErrorProvider1.SetError(Me.EmissionCalculationMethodComboBox, String.Empty)
        End If

        Return isValidData

    End Function

    Private Function IsValidEmissionFactorValue() As Boolean
        'value must be between 1e-13 to 1e6

        Dim isValidData As Boolean
        Dim valueString As String = Me.EmissionFactorValueTextBox.Text.Trim

        If (Me.m_isFactorRequired = True) Then

            If (valueString.Length = 0) Then
                isValidData = False
                Me.ErrorProvider1.SetError(Me.EmissionFactorValueTextBox, "Please enter a value.")
                Me.ErrorProvider1.SetIconAlignment(Me.EmissionFactorValueTextBox, ErrorIconAlignment.MiddleRight)

            ElseIf (Not IsNumeric(valueString)) Then
                isValidData = False
                Me.ErrorProvider1.SetError(Me.EmissionFactorValueTextBox, "Value must be between 1e-13 and 1e6.")
                Me.ErrorProvider1.SetIconAlignment(Me.EmissionFactorValueTextBox, ErrorIconAlignment.MiddleRight)

            Else
                Dim value As Double = CDbl(valueString)
                If ((value < 0.0000000000001) OrElse (value > 1000000.0)) Then
                    isValidData = False
                    Me.ErrorProvider1.SetError(Me.EmissionFactorValueTextBox, "Value must be between 1e-13 and 1e6.")
                    Me.ErrorProvider1.SetIconAlignment(Me.EmissionFactorValueTextBox, ErrorIconAlignment.MiddleRight)
                Else
                    isValidData = True
                    Me.ErrorProvider1.SetError(Me.EmissionFactorValueTextBox, String.Empty)
                End If
            End If
        Else
            isValidData = True
            Me.ErrorProvider1.SetError(Me.EmissionFactorValueTextBox, String.Empty)
        End If

        Return isValidData

    End Function

#End Region '----- Validation -----

#Region "----- changed events -----"

    Private Sub PollutantComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PollutantComboBox.SelectedIndexChanged

        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_pollutant = GlobalVariables.LookupTable.Pollutant.FindByPollutantID(CInt(Me.PollutantComboBox.SelectedValue))
            Me.m_processEmission.PollutantID = CInt(Me.PollutantComboBox.SelectedValue)
            Select Case CInt(Me.PollutantComboBox.SelectedValue)
                Case 589, 602, 624  ' CO, NOx, and VOC are the only ozone season pollutants.
                    Me.EmissionPeriodTypeComboBox.Enabled = True
                    Me.EmissionPeriodTypeComboBox.SelectedIndex = -1
                Case Else
                    Me.EmissionPeriodTypeComboBox.Enabled = False
                    Me.EmissionPeriodTypeComboBox.SelectedValue = "A"
            End Select
        End If

    End Sub

    Private Sub EmissionPeriodTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionPeriodTypeComboBox.SelectedIndexChanged

        If (Me.m_blnFormIsLoaded = True) Then
            If (Me.EmissionPeriodTypeComboBox.SelectedIndex = -1) Then
                Me.m_processEmission.EmissionPeriodTypeID = String.Empty
                Me.m_processEmission.UnitofMeasurementID = -1
                Me.EmissionValueUnitOfMeasurementLabel.Text = String.Empty
            Else
                Me.m_processEmission.EmissionPeriodTypeID = CStr(Me.EmissionPeriodTypeComboBox.SelectedValue)
                Call Me.SetEmissionsUnitOfMeasurement()
                Call Me.SetEmissionValueUnitOfMeasurementLabelText()
            End If
        End If

    End Sub

    ''' <summary>
    ''' Set the unit of measurement of the emissions for a new record.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetEmissionsUnitOfMeasurement()

        ' If the pollutant type is CAP and period is Annual then UOM is tons; otherwise it's pounds.
        ' HAPS is always pounds.

        If (Me.m_pollutant.PollutantTypeEISID = "CAP") Then
            If (CStr(Me.EmissionPeriodTypeComboBox.SelectedValue) = "A") Then
                Me.m_processEmission.UnitofMeasurementID = CInt(GlobalVariables.UnitOfMeasurementEnum.tons)
            Else
                Me.m_processEmission.UnitofMeasurementID = CInt(GlobalVariables.UnitOfMeasurementEnum.pounds)
            End If
        Else
            Me.m_processEmission.UnitofMeasurementID = CInt(GlobalVariables.UnitOfMeasurementEnum.pounds)
        End If

    End Sub

    Private Sub SetEmissionValueUnitOfMeasurementLabelText()

        Dim emissionValueUOM As GlobalVariables.UnitOfMeasurementEnum = CType(Me.m_processEmission.UnitofMeasurementID, GlobalVariables.UnitOfMeasurementEnum)

        Select Case emissionValueUOM
            Case GlobalVariables.UnitOfMeasurementEnum.tons
                Me.EmissionValueUnitOfMeasurementLabel.Text = GlobalVariables.UnitOfMeasurement.tons

            Case GlobalVariables.UnitOfMeasurementEnum.pounds
                Me.EmissionValueUnitOfMeasurementLabel.Text = GlobalVariables.UnitOfMeasurement.pounds
        End Select

    End Sub

    Private Sub EmissionCalculationMethodComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionCalculationMethodComboBox.SelectedIndexChanged

        If (m_blnFormIsLoaded = True) Then

            Me.m_processEmission.EmissionCalculationMethodID = CInt(Me.EmissionCalculationMethodComboBox.SelectedValue)
            Me.m_isFactorRequired = CBool(Emissions.Utility.EmissionCalculationMethodUtility.GetIsEmissionFactorRequired(Me.m_processEmission.EmissionCalculationMethodID))

            If (Me.m_isFactorRequired = True) Then
                Me.m_processEmission.EmissionFactorUnitOfMeasurementID = CInt(GlobalVariables.UnitOfMeasurementEnum.pounds)
                Me.m_processEmission.EmissionFactorProcessParameterTypeID = 1 'Throughput
                Call Me.SetEmissionFactorValueUnitOfMeasurementLabelText()
                'Me.EmissionFactorPanel.Visible = True
                Me.EmissionFactorValueLabel.Text = "* Emission Factor:" ' required
            Else
                Me.m_processEmission.EmissionFactorValue = -1
                ' 2016-04-15 BJF: Changed to enable user to enter an emission factor.
                'Me.m_processEmission.EmissionFactorUnitOfMeasurementID = -1
                'Me.m_processEmission.EmissionFactorProcessParameterTypeID = -1
                Me.m_processEmission.EmissionFactorUnitOfMeasurementID = CInt(GlobalVariables.UnitOfMeasurementEnum.pounds)
                Me.m_processEmission.EmissionFactorProcessParameterTypeID = 1 'Throughput

                'Me.EmissionFactorValueTextBox.Text = String.Empty
                Me.EmissionFactorValueUnitOfMeasurementLabel.Text = String.Empty
                'Me.EmissionFactorPanel.Visible = False
                Me.EmissionFactorValueLabel.Text = "Emission Factor If Any:"   ' optional
            End If

            Me.m_processEmission.EmissionFactorUnitOfMeasurementID = CInt(GlobalVariables.UnitOfMeasurementEnum.pounds)
            Me.m_processEmission.EmissionFactorProcessParameterTypeID = 1 'Throughput
            Call Me.SetEmissionFactorValueUnitOfMeasurementLabelText()
        End If


    End Sub

    Private Sub SetEmissionFactorValueUnitOfMeasurementLabelText()

        ' The numerator unit of measure is always pounds. 
        ' The denominator UOM is whatever the UOM for the throughput of the process detail record,

        Dim text As New System.Text.StringBuilder
        'Dim UOMID As Int32 = -1

        With text
            .Append(GlobalVariables.UnitOfMeasurement.pounds)
            .Append(Tools.Constants.Character.Space)
            .Append(Tools.Constants.Character.ForwardSlash)
            .Append(Tools.Constants.Character.Space)
            .Append(Me.m_strThroughputUnits)

            ' 2015-08-04 BJF: Moved the following code to new procedure ThroughputLookup() so it is only run once.
            'If (MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows.Count = 0) Then
            '    .Append(Tools.Constants.Character.QuestionMark)
            'Else
            '    For Each row As EmissionsDataSet.ProcessDetailPeriodRow In MainForm.EmissionsDataSet.ProcessDetailPeriod
            '        If (row.ProcessParameterTypeID = 1) Then
            '            UOMID = row.UnitOfMeasurementID
            '            Exit For
            '        End If
            '    Next

            '    If (UOMID = -1) Then
            '        .Append(Tools.Constants.Character.QuestionMark)
            '    Else
            '        Dim UOM As EmissionsDataSet.UnitOfMeasurementRow = GlobalVariables.LookupTable.UnitOfMeasurement.FindByUnitOfMeasurementID(UOMID)
            '        .Append(UOM.UnitOfMeasurementName)
            '    End If
            'End If

        End With

        Me.EmissionFactorValueUnitOfMeasurementLabel.Text = text.ToString

    End Sub

    Private Sub EmissionFactorValueTextBox_Leave(sender As Object, e As EventArgs) Handles EmissionFactorValueTextBox.Leave
        Dim emissionValue As Double

        If (m_blnFormIsLoaded AndAlso Me.m_blnEmissionFactorChanged) Then
            Dim text As String = Me.EmissionFactorValueTextBox.Text.Trim
            If (text.Length > 0) Then
                If (IsNumeric(text)) Then
                    Me.m_processEmission.EmissionFactorValue = CDbl(text)

                    ''If Me.EmissionValueTextBox.Text.Trim.Length = 0 OrElse CDbl(Me.EmissionValueTextBox.Text) = 0.0# Then
                    '' Calculate the emissions from the emission factor and throughput if appropriate.
                    'If Me.EmissionCalculationMethodComboBox.Text.Contains("(no control") Then
                    '    ' Emission factor _not_ using control efficiency.
                    '    If Me.EmissionPeriodTypeComboBox.SelectedValue.ToString() = "O3D" Then
                    '        If Me.m_dblOzoneSeasonDailyThroughput > 0.0# Then
                    '            Me.EmissionValueTextBox.Text = (Me.m_processEmission.EmissionFactorValue * Me.m_dblOzoneSeasonDailyThroughput).ToString()
                    '            ' Need to change to the format we use on the form if we decide to specify one.
                    '        End If
                    '    Else
                    '        If Me.m_dblAnnualThroughput > 0.0# Then
                    '            emissionsPounds = Me.m_processEmission.EmissionFactorValue * Me.m_dblAnnualThroughput
                    '            'emissionsPounds = APCD.EmissionsInventory.ProcessHelper.EmissionsFromEmissionFactorNoControl(Me.m_processEmission.EmissionFactorValue, Me.m_dblAnnualThroughput)
                    '            If Me.EmissionValueUnitOfMeasurementLabel.Text = "tons" Then
                    '                Me.EmissionValueTextBox.Text = (emissionsPounds / 2000).ToString()
                    '            Else
                    '                Me.EmissionValueTextBox.Text = emissionsPounds.ToString()
                    '            End If
                    '        End If
                    '    End If
                    'ElseIf Me.EmissionCalculationMethodComboBox.Text.Contains("(pre-control)") Then
                    '    'TODO 20150807:  Need to calculate effective control efficiency for this pollutant if more than one control in series affects the pollutant.
                    '    Dim controlEfficiency As Double = 0.0#
                    'End If
                    ''End If

                    emissionValue = ProcessHelper.EmissionsFromEmissionFactor(Me.m_processEmission)

                    Me.EmissionValueTextBox.Text = emissionValue.ToString()
                    Call Me.SetEmissionFactorValueUnitOfMeasurementLabelText()

            End If
        End If
        End If

    End Sub

    Private Sub EmissionFactorValueTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionFactorValueTextBox.TextChanged
        ' If the emission factor is zero or negative, hide it.
        If Me.EmissionFactorValueTextBox.Text.Length > 0 Then
            Dim factorText As String = Me.EmissionFactorValueTextBox.Text
            If IsNumeric(factorText) Then
                If CDbl(factorText) <= 0 Then
                    Me.EmissionFactorValueTextBox.ForeColor = Color.DarkRed ' Me.EmissionFactorValueTextBox.BackColor
                Else
                    Me.EmissionFactorValueTextBox.ForeColor = System.Drawing.SystemColors.WindowText
                End If
            End If
        End If

        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_blnEmissionFactorChanged = True
        End If
    End Sub

    Private Sub EmissionFactorValueTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EmissionFactorValueTextBox.KeyPress
        If (Asc(e.KeyChar) = 8 OrElse Asc(e.KeyChar) = 46 OrElse e.KeyChar = "E"c OrElse e.KeyChar = "e"c OrElse e.KeyChar = "-"c) Then ' Allow backspace, period, "E", minus
            '
        ElseIf (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
        Me.EmissionFactorValueTextBox.ForeColor = System.Drawing.SystemColors.WindowText
    End Sub

    Private Sub EmissionValueTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionValueTextBox.TextChanged

        If (m_blnFormIsLoaded = True) Then
            If (Me.EmissionValueTextBox.Text.Trim.Length > 0) Then
                If (IsNumeric(Me.EmissionValueTextBox.Text.Trim)) Then
                    Me.m_processEmission.EmissionValue = CDbl(Me.EmissionValueTextBox.Text.Trim)
                End If
            End If
        End If

    End Sub

    Private Sub EmissionValueTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EmissionValueTextBox.KeyPress
        If ((Asc(e.KeyChar) = 8) OrElse (Asc(e.KeyChar) = 46)) Then 'allow backspace and period
            '
        ElseIf (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CommentPublicTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentPublicTextBox.TextChanged

        If (m_blnFormIsLoaded = True) Then
            If (Me.CommentPublicTextBox.Text.Trim.Length = 0) Then
                Me.m_processEmission.SetCommentPublicNull()
            Else
                Me.m_processEmission.CommentPublic = Me.CommentPublicTextBox.Text.Trim
            End If
        End If

    End Sub

    Private Sub CommentInternalTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentInternalTextBox.TextChanged

        If (m_blnFormIsLoaded = True) Then
            If (Me.CommentInternalTextBox.Text.Trim.Length = 0) Then
                Me.m_processEmission.SetCommentInternalNull()
            Else
                Me.m_processEmission.CommentInternal = Me.CommentInternalTextBox.Text.Trim
            End If
        End If

    End Sub

#End Region '----- changed events -----

    Private Sub AddRowForShow()
        Dim factorText As String
        Dim methodText As String
        Dim row As EmissionsDataSet.Process_EmissionsTabRow = MainForm.EmissionsDataSet.Process_EmissionsTab.NewProcess_EmissionsTabRow

        ' Temporarily allow editing of columns that are read-only to users.
        MainForm.EmissionsDataSet.Process_EmissionsTab.Columns("EmissionCalculationMethodName").ReadOnly = False
        MainForm.EmissionsDataSet.Process_EmissionsTab.Columns("EFUnits").ReadOnly = False
        With row
            .ProcessEmissionID = Me.m_processEmission.ProcessEmissionID
            .ProcessID = Me.m_processEmission.ProcessID
            .EmissionYear = Me.m_processEmission.EmissionYear
            .PollutantName = Me.PollutantComboBox.Text
            .EmissionPeriodTypeName = Me.EmissionPeriodTypeComboBox.Text
            .EmissionValue = Me.m_processEmission.EmissionValue
            .UnitOfMeasurementName = Me.EmissionValueUnitOfMeasurementLabel.Text
            methodText = Me.EmissionCalculationMethodComboBox.Text
            .EmissionCalculationMethodName = methodText
            'If (methodText.Contains("(no control") OrElse methodText.Contains("(pre-control)")) Then
            '    ' Calc. method uses an emission factor.
            '    factorText = Me.EmissionFactorValueTextBox.Text
            '    If (IsNumeric(factorText)) Then
            '        .EmissionFactorValue = CDbl(factorText)
            '    End If
            'Else
            '    .EmissionFactorValue = -1.0#
            'End If
            factorText = Me.EmissionFactorValueTextBox.Text
            If (IsNumeric(factorText)) Then
                .EmissionFactorValue = CDbl(factorText)
            End If
            .EFUnits = Me.EmissionFactorValueUnitOfMeasurementLabel.Text
        End With
        MainForm.EmissionsDataSet.Process_EmissionsTab.Rows.Add(row)

        MainForm.EmissionsDataSet.Process_EmissionsTab.Columns("EmissionCalculationMethodName").ReadOnly = True
        MainForm.EmissionsDataSet.Process_EmissionsTab.Columns("EFUnits").ReadOnly = True

    End Sub

    Private Sub UpdateRowForShow()
        Dim factorText As String
        Dim methodText As String

        ' Temporarily allow editing of columns that are read-only to users.
        MainForm.EmissionsDataSet.Process_EmissionsTab.Columns("EmissionCalculationMethodName").ReadOnly = False
        MainForm.EmissionsDataSet.Process_EmissionsTab.Columns("EFUnits").ReadOnly = False
        For Each row As EmissionsDataSet.Process_EmissionsTabRow In MainForm.EmissionsDataSet.Process_EmissionsTab
            With row
                If row.RowState = DataRowState.Deleted Then
                    ' Skip over it.
                Else
                    If (.ProcessEmissionID = Me.m_processEmission.ProcessEmissionID) Then
                        .EmissionValue = CDbl(Me.EmissionValueTextBox.Text.Trim)
                        methodText = Me.EmissionCalculationMethodComboBox.Text
                        .EmissionCalculationMethodName = methodText
                        'If (methodText.Contains("(no control") OrElse methodText.Contains("(pre-control)")) Then
                        '    ' Calc. method uses an emission factor.
                        '    factorText = Me.EmissionFactorValueTextBox.Text
                        '    If (IsNumeric(factorText)) Then
                        '        .EmissionFactorValue = CDbl(factorText)
                        '    End If
                        'Else
                        '    .EmissionFactorValue = -1.0#
                        'End If
                        factorText = Me.EmissionFactorValueTextBox.Text
                        If (IsNumeric(factorText)) Then
                            .EmissionFactorValue = CDbl(factorText)
                        End If
                        .EFUnits = Me.EmissionFactorValueUnitOfMeasurementLabel.Text
                        Exit For
                    End If
                End If
            End With
        Next
        MainForm.EmissionsDataSet.Process_EmissionsTab.Columns("EmissionCalculationMethodName").ReadOnly = True
        MainForm.EmissionsDataSet.Process_EmissionsTab.Columns("EFUnits").ReadOnly = True

    End Sub

End Class
