Imports System.Text
Imports APCD.Emissions

Public Class ReleasePointDetailAddEditForm

    Sub New(ByVal row As DataRow)
        InitializeComponent()
        Me.m_row = row
    End Sub

    Private m_row As DataRow
    Private m_blnFormIsLoaded As Boolean = False

    Private Sub ReleasePointDetailAddEditForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Me.SetDefaults()
        Me.m_blnFormIsLoaded = True

    End Sub

    Private Sub SetDefaults()

        Call Me.LoadComboBox()
        Call Me.AssignControlValues()

    End Sub

    Private Sub LoadComboBox()

        Dim MeasurementUnitOfMeasurementFilterView As DataView = Me.GetMeasurementUnitOfMeasurementFilterView
        If (MeasurementUnitOfMeasurementFilterView.Count > 0) Then
            Dim UnitOfMeasurementFilterView As DataView = Me.GetUnitOfMeasurementFilterView(MeasurementUnitOfMeasurementFilterView)
            If (UnitOfMeasurementFilterView.Count > 0) Then
                Tools.WindowsForms.LoadComboBox(UnitOfMeasurementFilterView, Me.UnitOfMeasurementComboBox)
            End If
        End If

    End Sub

    Private Sub AssignControlValues()

        'Me.Text = CStr(Me.m_row(Emissions.Constants.MeasurementConstants.FieldName.MeasurementName))
        'If (CDbl(Me.m_row(Emissions.Constants.ReleasePointDetailConstants.FieldName.DetailValue)) <> -1) Then
        '    Me.DetailValueTextBox.Text = CStr(CDbl(Me.m_row(Emissions.Constants.ReleasePointDetailConstants.FieldName.DetailValue)))
        'End If
        'Me.UnitOfMeasurementComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.UnitOfMeasurementComboBox, CInt(Me.m_row(Emissions.Constants.ReleasePointDetailConstants.FieldName.UnitOfMeasurementID)))

    End Sub

    Private Function GetMeasurementUnitOfMeasurementFilterView() As DataView

        'Dim filteredView As DataView
        'Dim filter As New StringBuilder
        'Dim intMeasurementID As Int32 = CInt(Me.m_row(Emissions.Constants.MeasurementConstants.FieldName.MeasurementID))

        'filteredView = GlobalVariables.MeasurementUnitOfMeasurementFilterTable.DefaultView
        'With filter
        '    .Append(Constants.MeasurementConstants.FieldName.MeasurementID)
        '    .Append(Tools.Constants.Character.Space)
        '    .Append(GlobalVariables.Words._In)

        '    .Append(Tools.Constants.Character.Space)
        '    .Append(Tools.Constants.Character.LeftParenthesis)
        '    .Append("0, ")
        '    .Append(intMeasurementID.ToString)
        '    .Append(Tools.Constants.Character.RightParenthesis)
        'End With
        'filteredView.RowFilter = filter.ToString

        'Return filteredView

    End Function

    Private Function GetUnitOfMeasurementFilterView(ByVal viewUnitOfMeasurements As DataView) As DataView

        Dim filteredView As DataView
        Dim filter As New StringBuilder

        filteredView = GlobalVariables.UnitOfMeasurementLookupTable.DefaultView
        With filter
            .Append(APCD.AirPollution.Constants.UnitOfMeasurementConstants.FieldName.UnitOfMeasurementID)
            .Append(Tools.Constants.Character.Space)
            .Append(GlobalVariables.Words._In)
            .Append(Tools.Constants.Character.Space)
            .Append(Tools.Constants.Character.LeftParenthesis)
            For rowCount As Int32 = 0 To viewUnitOfMeasurements.Count - 1
                If (rowCount > 0) Then
                    .Append(Tools.Constants.Character.Comma)
                End If
                .Append(CStr(viewUnitOfMeasurements(rowCount).Item(1)))
            Next
            .Append(Tools.Constants.Character.RightParenthesis)
        End With
        filteredView.RowFilter = filter.ToString

        Return filteredView

    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Dim blnFormIsValid As Boolean = False
        Dim strDetailValue As String = Me.DetailValueTextBox.Text.Trim

        If (strDetailValue.Length = 0) Then
            MessageBox.Show(GlobalVariables.ErrorPrompt.Misc.EnterAValue, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DetailValueTextBox.Focus()

        ElseIf (Not IsNumeric(strDetailValue)) Then
            MessageBox.Show(GlobalVariables.ErrorPrompt.Misc.ValueMustBeNumeric, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DetailValueTextBox.Focus()

        ElseIf (CDbl(strDetailValue) < 0) Then
            MessageBox.Show(GlobalVariables.ErrorPrompt.Misc.ValueMustBeGreaterThanOrEqualToZero, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DetailValueTextBox.Focus()

        Else
            Me.m_row(Emissions.Constants.ReleasePointDetailConstants.FieldName.DetailValue) = CDbl(strDetailValue)
            Me.m_row(Emissions.Constants.ReleasePointDetailConstants.FieldName.UnitOfMeasurementID) = CInt(Me.UnitOfMeasurementComboBox.SelectedValue)
            Me.m_row(AirPollution.Constants.UnitOfMeasurementConstants.FieldName.UnitOfMeasurementName) = CStr(Me.UnitOfMeasurementComboBox.Text)
            blnFormIsValid = True
        End If

        If (blnFormIsValid) Then
            Me.Close()
        End If

    End Sub

#Region "----- validation -----"

    Private Function IsValidMeasurement() As Boolean

        Dim isValidData As Boolean
        'see spreadsheet
        Return isValidData

    End Function


#End Region '----- validation -----

    Private Sub UnitOfMeasurementComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnitOfMeasurementComboBox.SelectedIndexChanged

    End Sub
End Class