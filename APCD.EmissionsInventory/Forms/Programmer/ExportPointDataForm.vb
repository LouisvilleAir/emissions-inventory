Imports System.IO

Public Class ExportPointDataForm

    Public Sub New(ByVal emissionYear As Int16)
        InitializeComponent()
        Me.m_emissionYear = emissionYear
    End Sub

    Private m_emissionYear As Int16
    Private m_intNumberOfSteps As Int32 = 10

    Private Sub ExportPointDataForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblStatus.Text = String.Empty

        Const ConnectionStringStart As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
        Const ConnectionStringEnd As String = ".mdb;Persist Security Info=True"
        ' ^ Specific to Access 2000-2003 format.

#If DEBUG Then
        EmissionsPointExport.Globals.GlobalVariables.ConnectionString = ConnectionStringStart _
            & My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Database Development\" _
            & Global.APCD.EmissionsInventory.GlobalVariables.DatabaseName.EmissionsPointExport _
            & ConnectionStringEnd
        'TODO 20131121: This ^ is specific to Bryan's setup; need to come up with a standardized location for multiple programmers.
#Else
        Dim Credentials As String = Emissions.Globals.GlobalVariables.ConnectionString.Substring(114)

        EmissionsPointExport.Globals.GlobalVariables.ConnectionString =  ConnectionStringStart _
            & "G:\DATA\Utility\"  & Global.APCD.EmissionsInventory.GlobalVariables.DatabaseName.EmissionsPointExport _
            & ConnectionStringEnd & Credentials
#End If

        Debug.Print("Point export connection string: " & Chr(34) & EmissionsPointExport.Globals.GlobalVariables.ConnectionString & Chr(34))

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Try
            Call Me.RemoveTempFilesFromWorkFolder()
            Call Me.CopyTemplateDatabaseToWorkFolder()
            Call Me.CopyEmissionsDBToWorkFolder()
            Call Me.CopyFacilitiesDBToWorkFolder()
            Call Me.SetCERSFields()
            Call Me.SetExchangeHeaderFields()

            Me.btnExport.Enabled = False
            Me.btnClose.Enabled = False

            Call Me.ExportData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.btnClose.Enabled = True

    End Sub

    Private Sub RemoveTempFilesFromWorkFolder()

        Dim workFolder As New DirectoryInfo("G:\DATA\Work")
        Dim files() As FileInfo = workFolder.GetFiles("*.zip")
        For Each File As FileInfo In files
            File.Delete()
        Next
        files = workFolder.GetFiles("*.xml")
        For Each File As FileInfo In files
            File.Delete()
        Next

    End Sub

    Private Sub CopyTemplateDatabaseToWorkFolder()
        Dim source As New FileInfo("G:\DATA\Templates\EIS Point Emissions Submittal.mdb")
        Dim destination As New FileInfo("G:\DATA\Work\" & source.Name)
        File.Copy(source.FullName, destination.FullName, True)
        destination.IsReadOnly = False
    End Sub

    Private Sub CopyEmissionsDBToWorkFolder()
        Dim source As New FileInfo("G:\DATA\Production\Emissions\Emissions.mdb")
        Dim destination As New FileInfo("G:\DATA\Work\" & source.Name)
        File.Copy(source.FullName, destination.FullName, True)
    End Sub

    Private Sub CopyFacilitiesDBToWorkFolder()
        Dim source As New FileInfo("G:\DATA\Production\Common\Facilities.mdb")
        Dim destination As New FileInfo("G:\DATA\Work\" & source.Name)
        File.Copy(source.FullName, destination.FullName, True)
    End Sub

    Private Sub SetCERSFields()

        'Dim updateText As String = "UPDATE CERS SET UserIdentifier = '" _
        '                           & PeopleLibrary.Utility.EmployeeEmailUtility.GetByEmployeeID(GlobalVariables.Employee.EmployeeID) _
        '                           & "', EmissionsYear = '" _
        '                           & CStr(Me.m_emissionYear) _
        '                           & "'"
        Dim updateText As String = "UPDATE CERS SET UserIdentifier = '" _
                                   & "starlet.raj@louisvilleky.gov" _
                                   & "', EmissionsYear = '" _
                                   & CStr(Me.m_emissionYear) _
                                   & "'"
        Dim cmd As New OleDb.OleDbCommand(updateText, New OleDb.OleDbConnection(EmissionsPointExport.Globals.GlobalVariables.ConnectionString))
        cmd.CommandType = CommandType.Text
        Try
            cmd.Connection.Open()
            cmd.ExecuteScalar()
        Catch ex As Exception
            Throw New ApplicationException("Unable to set CERS fields.") '
        Finally
            If (cmd.Connection.State = ConnectionState.Open) Then cmd.Connection.Close()
        End Try

    End Sub

    Private Sub SetExchangeHeaderFields()

        'Dim updateText As String = "UPDATE ExchangeHeader SET " _
        '                           & "AuthorName = '" _
        '                           & GlobalVariables.Employee.NickName _
        '                           & Space(1) _
        '                           & GlobalVariables.Employee.LastName _
        '                           & "', Keywords = 'point, stationary source, Louisville, Kentucky, " _
        '                           & CStr(Me.m_emissionYear) _
        '                           & "'"
        Dim updateText As String = "UPDATE ExchangeHeader SET " _
                                   & "AuthorName = '" _
                                   & "Starlet Raj" _
                                   & "', Keywords = 'point, stationary source, Louisville, Kentucky, " _
                                   & CStr(Me.m_emissionYear) _
                                   & "'"
        Dim cmd As New OleDb.OleDbCommand(updateText, New OleDb.OleDbConnection(EmissionsPointExport.Globals.GlobalVariables.ConnectionString))
        cmd.CommandType = CommandType.Text
        Try
            cmd.Connection.Open()
            cmd.ExecuteScalar()
        Catch ex As Exception
            Throw New ApplicationException("Unable to set ExchangeHeader fields.") '
        Finally
            If (cmd.Connection.State = ConnectionState.Open) Then cmd.Connection.Close()
        End Try

    End Sub

    Private Sub ExportData()

        Dim count As Int32 = 1
        Try
            Call Me.UpdateStatusLabel(count)
            Call EmissionsPointExport.Utility.GenericUtility.FacilitySite_Append()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsPointExport.Utility.GenericUtility.EmissionsUnit_Append()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsPointExport.Utility.GenericUtility.EmissionsProcess_Append()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsPointExport.Utility.GenericUtility.ReportingPeriod_Append_Annual()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsPointExport.Utility.GenericUtility.ReportingPeriod_Append_O3D()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsPointExport.Utility.GenericUtility.OperatingDetails_Append_Annual()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsPointExport.Utility.GenericUtility.OperatingDetails_Append_O3D()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsPointExport.Utility.GenericUtility.Emissions_Append_Annual()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsPointExport.Utility.GenericUtility.Emissions_Append_O3D()

            count += 1
            Call Me.UpdateStatusLabel(count)
            Call EmissionsPointExport.Utility.GenericUtility.SupplementalParameter_Append()

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