Public Class AddControlMeasureStep2

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        GlobalVariables.AddControlMeasureStep = GlobalVariables.WizardStep._Cancel
        Me.Close()
    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        GlobalVariables.AddControlMeasureStep = GlobalVariables.WizardStep._Next
        Me.Close()
    End Sub

End Class