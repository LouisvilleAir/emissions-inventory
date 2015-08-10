Imports APCD.Common


Public Class WhoIsLoggedInForm

    Private WhoIsLoggedOnDataTable As DataTable

    Private Sub WhoIsLoggedInForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Me.RefreshData()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Call Me.RefreshData()
    End Sub

    Private Sub LoadData()
    End Sub

    Private Sub RefreshData()
        Me.WhoIsLoggedOnDataTable = Applications.Utility.EmployeeApplicationUtility.WhoIsLoggedOn(GlobalVariables.Application.ApplicationID)
        Me.DataGridView1.DataSource = Me.WhoIsLoggedOnDataTable
        Me.lblNumberOfUsers.Text = Me.WhoIsLoggedOnDataTable.Rows.Count.ToString
    End Sub

End Class