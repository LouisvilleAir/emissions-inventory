Public Class ExportFacilityDataForm

    Private m_intNumberOfSteps As Int32 = 13

    Private Sub ExportFacilityDataForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblStatus.Text = String.Empty

        Const ConnectionStringStart As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
        Const ConnectionStringEnd As String = ".mdb;Persist Security Info=True"
        ' ^ Specific to Access 2000-2003 format.

#If DEBUG Then
        EmissionsEIS_FacilityExport.Globals.GlobalVariables.ConnectionString = ConnectionStringStart _
            & My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Database Development\" _
            & Global.APCD.EmissionsInventory.GlobalVariables.DatabaseName.EmissionsEIS_FacilityExport _
            & ConnectionStringEnd
        'TODO 20131121: This ^ is specific to Bryan's setup; need to come up with a standardized location for multiple programmers.
#Else
        Dim Credentials As String = Emissions.Globals.GlobalVariables.ConnectionString.Substring(114)

        EmissionsEIS_FacilityExport.Globals.GlobalVariables.ConnectionString =  ConnectionStringStart _
            & "G:\DATA\Utility\"  & Global.APCD.EmissionsInventory.GlobalVariables.DatabaseName.EmissionsEIS_FacilityExport _
            & ConnectionStringEnd & Credentials
#End If

        Debug.Print("Facility export connection string: " & Chr(34) & EmissionsEIS_FacilityExport.Globals.GlobalVariables.ConnectionString & Chr(34))

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Me.btnExport.Enabled = False
        Me.btnClose.Enabled = False
        Call Me.ExportData()
        Me.btnClose.Enabled = True
    End Sub

    Private Sub ExportData()

        Dim count As Int32 = 1
        Try
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.FacilitySite_Append()


            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.FacilitySiteGeographicCoordinates_Append()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.EmissionsUnit_Append()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.EmissionsProcess_Append()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.ReleasePoint_Append_StackRound()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.ReleasePoint_Append_StackNotRound()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.ReleasePoint_Append_Fugitive()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.ReleasePointGeographicCoordinates_Append()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.ReleasePointApportionment_Append()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.ControlApproach_Append()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.ControlMeasure_Append()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.ControlPollutant_Append_EfficiencyProduct()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsEIS_FacilityExport.Utility.GenericUtility.ControlPollutant_Append()

            Me.lblStatus.Text = String.Empty
            MessageBox.Show("Export completed successfully.", Application.ProductName, MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub UpdateStatusLabel(ByVal count As Int32)

        Me.lblStatus.Text = "Executing step " _
                          & count.ToString _
                          & " of " _
                          & Me.m_intNumberOfSteps.ToString

        My.Application.DoEvents()

    End Sub


End Class