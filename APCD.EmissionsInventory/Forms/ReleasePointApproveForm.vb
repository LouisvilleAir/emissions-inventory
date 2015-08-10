Imports APCD.Emissions

Public Class ReleasePointApproveForm

    'Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    '    GlobalVariables.ReleasePointObject.ReleasePointYear = Nothing
    '    Me.Close()
    'End Sub

    'Private Sub ReleasePointApproveForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    ''Dim dtb As DataTable = Utility.OperatingStatusTypeEISUtility.GetLookupTable
    '    ''Tools.WindowsForms.LoadComboBox(dtb, Me.OperatingStatusTypeEISComboBox, True)
    '    Dim dtb As DataTable = Utility.OperatingStatusTypeEISUtility.GetLookupTable
    '    Dim rowIndex As Int32 = Tools.Data.DataTableHelper.GetRowIndexForLookupValue("OP", dtb)

    '    'If it's not shut down, select operating and disable the control.
    '    If (GlobalVariables.ReleasePointObject.EndDate = Nothing) Then
    '        Tools.WindowsForms.LoadComboBox(dtb, Me.OperatingStatusTypeEISComboBox, True)
    '        Me.OperatingStatusTypeEISComboBox.SelectedIndex = rowIndex + 1
    '        Me.OperatingStatusTypeEISComboBox.Enabled = False
    '    Else
    '        'since it's shut down remove the 'operating' option
    '        dtb.Rows.RemoveAt(rowIndex)
    '        Tools.WindowsForms.LoadComboBox(dtb, Me.OperatingStatusTypeEISComboBox, True)
    '    End If

    'End Sub

    'Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
    '    If (Me.OperatingStatusTypeEISComboBox.SelectedIndex = 0) Then
    '        MessageBox.Show("Select an Operating Status")
    '    Else
    '        'create a new EUYear object and assign it's values
    '        GlobalVariables.ReleasePointObject.ReleasePointYear = New Business.ReleasePointYear
    '        With GlobalVariables.ReleasePointObject.ReleasePointYear
    '            .OperatingStatusTypeEISID = CStr(Me.OperatingStatusTypeEISComboBox.SelectedValue)
    '            .ApprovalComment = Me.CommentTextBox.Text.Trim & String.Empty
    '        End With
    '        Me.Close()
    '    End If
    'End Sub
End Class