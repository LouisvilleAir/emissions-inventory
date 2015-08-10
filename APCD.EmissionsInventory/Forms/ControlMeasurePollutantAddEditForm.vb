Imports APCD.Emissions
Imports System.Text

Public Class ControlMeasurePollutantAddEditForm

    Sub New(ByVal row As DataRow, ByVal dtbControlMeasurePollutant As DataTable)
        InitializeComponent()
        Me.m_row = row
        Me.m_dtbControlMeasurePollutant = dtbControlMeasurePollutant
    End Sub

    Private Enum DMLMode
        Add
        Edit
    End Enum

    Private m_objProcess As Business.Process

    Private m_row As DataRow
    Private m_dtbControlMeasurePollutant As DataTable
    Private m_dtbPollutantLookupTable As DataTable

    Private m_blnFormIsLoaded As Boolean = False

    Private m_intControlMeasurePollutantID As Int32
    Private m_intPollutantID As Int32

#Region "----- startup -----"

    Private Sub ControlMeasurePollutantAddEditForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Me.SetDefaults()
        Me.m_blnFormIsLoaded = True

        If ((m_intControlMeasurePollutantID < 0) AndAlso (m_intPollutantID = -1)) Then
            Me.Text = "Add Control Measure Pollutant"
        Else
            Me.Text = "Edit Control Measure Pollutant"
            Call Me.AssignControlValues()
            Me.PollutantComboBox.Enabled = False
        End If

    End Sub

    Private Sub SetDefaults()

        m_intControlMeasurePollutantID = CInt(Me.m_row(Constants.ControlMeasurePollutantConstants.FieldName.ControlMeasurePollutantID))
        m_intPollutantID = CInt(Me.m_row(Constants.ControlMeasurePollutantConstants.FieldName.PollutantID))

        Call Me.LoadDataTables()

        If ((m_intControlMeasurePollutantID < 0) AndAlso (m_intPollutantID = -1)) Then
            Call Me.LoadComboBox(DMLMode.Add)
        Else
            Call Me.LoadComboBox(DMLMode.Edit)
        End If

    End Sub

    Private Sub LoadDataTables()

        Me.m_dtbPollutantLookupTable = Utility.PollutantUtility.GetLookupTable

    End Sub

    Private Sub LoadComboBox(ByVal mode As DMLMode)

        Select Case mode
            Case DMLMode.Add
                'load the combo with all Pollutants for this control measure except what is already assigned to it
                If (Me.m_dtbControlMeasurePollutant.Rows.Count = 0) Then
                    Tools.WindowsForms.LoadComboBox(Me.m_dtbPollutantLookupTable, Me.PollutantComboBox)
                Else
                    Dim filteredView As DataView
                    Dim filter As New StringBuilder

                    filteredView = Me.m_dtbPollutantLookupTable.DefaultView
                    With filter
                        .Append(Constants.PollutantConstants.FieldName.PollutantID)
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._Not)
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._In)
                        .Append(Tools.Constants.Character.Space)
                        .Append(Tools.Constants.Character.LeftParenthesis)
                        ''.Append("0,")
                        For rowCount As Int32 = 0 To Me.m_dtbControlMeasurePollutant.Rows.Count - 1
                            If (rowCount > 0) Then
                                .Append(Tools.Constants.Character.Comma)
                            End If
                            Dim pollutantID As String = CStr(Me.m_dtbControlMeasurePollutant.Rows(rowCount)(Constants.ControlMeasurePollutantConstants.FieldName.PollutantID))
                            .Append(pollutantID)
                        Next
                        .Append(Tools.Constants.Character.RightParenthesis)
                    End With

                    filteredView.RowFilter = filter.ToString
                    Tools.WindowsForms.LoadComboBox(filteredView, Me.PollutantComboBox)
                    Me.PollutantComboBox.SelectedIndex = -1
                End If

            Case DMLMode.Edit
                Tools.WindowsForms.LoadComboBox(Me.m_dtbPollutantLookupTable, Me.PollutantComboBox)
        End Select

    End Sub

    Private Sub AssignControlValues()

        Me.PollutantComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(PollutantComboBox, CInt(Me.m_row(Constants.PollutantConstants.FieldName.PollutantID)))
        Me.ControlPercentTextBox.Text = CStr(Me.m_row(Constants.ControlMeasurePollutantConstants.FieldName.ControlPercent))
        Me.CommentPublicTextBox.Text = CStr(Me.m_row(Constants.ControlMeasurePollutantConstants.FieldName.CommentPublic))
        Me.CommentInternalTextBox.Text = CStr(Me.m_row(Constants.ControlMeasurePollutantConstants.FieldName.CommentInternal))

    End Sub

#End Region '----- startup -----

#Region "----- buttons -----"
    Private Sub CapturePercentTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ControlPercentTextBox.KeyPress

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
            Call Me.AssignValuesToRow()
            Me.Close()
        End If
    End Sub

#End Region '----- buttons -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim isValidData As Boolean

        If (Not Me.IsValidPollutant) Then
            isValidData = False
        ElseIf (Not Me.IsValidPercent) Then
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
            Me.ErrorProvider1.SetIconAlignment(Me.PollutantComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            isValidData = True
            Me.ErrorProvider1.SetError(Me.PollutantComboBox, String.Empty)
        End If

        Return isValidData

    End Function

    Private Function IsValidPercent() As Boolean

        Dim isValidData As Boolean
        Dim strEmissionsPercent As String = Me.ControlPercentTextBox.Text.Trim

        If (strEmissionsPercent.Length = 0) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.ControlPercentTextBox, GlobalVariables.ErrorPrompt.Misc.ValueMustBeGreaterThanOrEqualTo0AndLessThan100)
            Me.ErrorProvider1.SetIconAlignment(Me.ControlPercentTextBox, ErrorIconAlignment.MiddleLeft)

        ElseIf (Not IsNumeric(strEmissionsPercent)) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.ControlPercentTextBox, GlobalVariables.ErrorPrompt.Misc.ValueMustBeGreaterThanOrEqualTo0AndLessThan100)
            Me.ErrorProvider1.SetIconAlignment(Me.ControlPercentTextBox, ErrorIconAlignment.MiddleLeft)

        Else
            Dim sngEmissionsPercent As Single = CSng(strEmissionsPercent)
            If ((sngEmissionsPercent < 0) OrElse (sngEmissionsPercent >= 100)) Then
                isValidData = False
                Me.ErrorProvider1.SetError(Me.ControlPercentTextBox, GlobalVariables.ErrorPrompt.Misc.ValueMustBeGreaterThanOrEqualTo0AndLessThan100)
                Me.ErrorProvider1.SetIconAlignment(Me.ControlPercentTextBox, ErrorIconAlignment.MiddleLeft)
            Else
                isValidData = True
                Me.ErrorProvider1.SetError(Me.ControlPercentTextBox, String.Empty)
            End If

        End If

        Return isValidData

    End Function

#End Region '----- Validation -----

#Region "----- save the data -----"

    Private Sub AssignValuesToRow()

        'needed to save the rec
        'Me.m_row(Constants.ControlMeasurePollutantConstants.FieldName.ControlMeasureID) = GlobalVariables.ControlMeasureObject.ControlMeasureID
        Me.m_row(Constants.ControlMeasurePollutantConstants.FieldName.PollutantID) = Me.PollutantComboBox.SelectedValue
        Me.m_row(Constants.ControlMeasurePollutantConstants.FieldName.ControlPercent) = Me.ControlPercentTextBox.Text.Trim
        Me.m_row(Constants.ControlMeasurePollutantConstants.FieldName.CommentPublic) = Me.CommentPublicTextBox.Text.Trim
        Me.m_row(Constants.ControlMeasurePollutantConstants.FieldName.CommentInternal) = Me.CommentInternalTextBox.Text.Trim

        'for show
        Me.m_row(Constants.PollutantConstants.FieldName.PollutantName) = Me.PollutantComboBox.Text

    End Sub

#End Region '----- save the data -----

End Class