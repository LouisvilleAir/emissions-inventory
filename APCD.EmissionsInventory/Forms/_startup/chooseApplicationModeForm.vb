Imports System.IO
Imports APCD.Common

Public Class chooseApplicationModeForm

    Public Sub New(ByVal devConfigFile As FileInfo)
        InitializeComponent()
        Me.m_fiDevConfigFile = devConfigFile
    End Sub

    Private m_fiDevConfigFile As FileInfo

    Private Sub ChooseConnectionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Label1.Text = "You are logged in as " & GlobalMethods.GetFriendlyUserName & ". Please choose your application mode:"

    End Sub

#Region "----- development mode -----"

    Private Sub btnDevelopment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDevelopment.Click

        GlobalVariables.DatabaseMode = GlobalVariables.DatabaseModeEnum.Development
        Dim userName As String = GlobalMethods.GetFriendlyUserName
        Call GlobalMethods.SetOfflineLogFilesAndConnectionStrings(Me.m_fiDevConfigFile.FullName)

        Call GlobalMethods.InitializeApplicationObject()
        Call GlobalMethods.ValidateTheUser(userName)
        Call GlobalMethods.AssignUserRole()

        GlobalVariables.ConnectionStatusColor = Color.Green
        Me.Close()

    End Sub

    Private Function CreateDeveloperConfigurationFile() As String

        Dim developerConnectionsAndLogs As New System.Text.StringBuilder

        'first the app logs
        developerConnectionsAndLogs.Append(Me.PromptForLogDirectory)

        'get the list of dbs used by this application
        Dim dtb As DataTable = Applications.Utility.ApplicationDatabasseUtility.GetByApplicationID(GlobalVariables.Application.ApplicationID)
        With developerConnectionsAndLogs
            For Each row As DataRow In dtb.Rows
                Dim databaseID As Int32 = CInt(row(Applications.Constants.ApplicationDatabasseConstants.FieldName.DatabasseID))
                Dim objDatabase As Applications.Business.Databasse = Applications.Utility.DatabasseUtility.GetByPrimaryKey(databaseID)
                Select Case objDatabase.DatabasseName
                    Case GlobalVariables.DatabaseName.Applications, GlobalVariables.DatabaseName.People
                        developerConnectionsAndLogs.Append(Me.PromptForConnectionString(objDatabase.DatabasseName))
                End Select
            Next
        End With

        Return developerConnectionsAndLogs.ToString

    End Function

    Private Function PromptForLogDirectory() As String

        Dim logDirectory As New System.Text.StringBuilder

        Dim logDirectoryString As String
        Dim badDirectoryCount As Byte = 0
        Dim directoryIsOK As Boolean
        Do
            badDirectoryCount = CByte(badDirectoryCount + 1)
            logDirectoryString = InputBox("Enter development log directory:", ProductName)
            directoryIsOK = Me.IsDirectoryOK(logDirectoryString)
            If (directoryIsOK) Then Exit Do
        Loop While (badDirectoryCount < 3)

        If (Not directoryIsOK) Then
            MessageBox.Show("3 attempts to set a valid directory have failed. The application will now close.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End If

        logDirectory.Append("logDirectory=")
        logDirectory.AppendLine(logDirectoryString)

        Return logDirectory.ToString

    End Function

    Private Function IsDirectoryOK(ByVal directoryPath As String) As Boolean

        Dim directoryIsOK As Boolean
        Try
            Dim dir As New System.IO.DirectoryInfo(directoryPath)
            directoryIsOK = True
        Catch ex As Exception
            directoryIsOK = False
        End Try
        Return directoryIsOK

    End Function

    Private Function PromptForConnectionString(ByVal databaseName As String) As String

        Dim keyValuePair As New System.Text.StringBuilder

        keyValuePair.Append(databaseName)
        keyValuePair.Append(Tools.Constants.Character.EqualSign)

        Dim cnString = InputBox("Enter development connection string for the following database:" & vbCrLf & databaseName, ProductName)
        If (cnString = String.Empty) Then
            keyValuePair.Clear()
        Else
            keyValuePair.AppendLine(cnString)
        End If

        Return keyValuePair.ToString

    End Function

#End Region '----- development mode -----

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click

        GlobalVariables.DatabaseMode = GlobalVariables.DatabaseModeEnum.Test
        Call Me.Engage()

    End Sub

    Private Sub btnProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProduction.Click

        GlobalVariables.DatabaseMode = GlobalVariables.DatabaseModeEnum.Production
        Call Me.Engage()

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>This method may only be called for Test and Production modes.</remarks>
    Private Sub Engage()

        'If the mode is not Test or Production raise an error.
        If (GlobalVariables.DatabaseMode = GlobalVariables.DatabaseModeEnum.Development) Then
            Throw New ApplicationException("This method may not be called when running as the developer.")
        End If

        Dim userName As String = GlobalMethods.GetFriendlyUserName
        Dim exitTheApplication As Boolean = False
        Try
            Call GlobalMethods.InitializeApplicationObject()
            Call GlobalMethods.InitializeApplicationDatabases()
            Call GlobalMethods.ValidateTheUser(userName)
            Call Me.ValidateTheConnection()
            Call GlobalMethods.AssignUserRole()
            Call Me.SetConnectionStatusColorAndLogDirectory()
            Applications.Utility.EmployeeApplicationUtility.Logon(GlobalVariables.EmployeeApplication.EmployeeApplicationID) 'flag the user as logged on
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred during application startup: " & ex.Message, "Application Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            exitTheApplication = True
        End Try

        If (exitTheApplication = True) Then
            End
        Else
            Me.Close()
        End If

    End Sub

    Private Sub ValidateTheConnection()

        Dim cnTesting123Testing As OleDb.OleDbConnection = Nothing
        Try
            cnTesting123Testing = New OleDb.OleDbConnection(PeopleLibrary.Globals.GlobalVariable.ConnectionString)
            cnTesting123Testing.Open()
        Catch ex As Exception
            Try
                PeopleLibrary.Globals.GlobalVariable.ConnectionString = Me.SwitchToOffline(PeopleLibrary.Globals.GlobalVariable.ConnectionString)
                cnTesting123Testing = New OleDb.OleDbConnection(PeopleLibrary.Globals.GlobalVariable.ConnectionString)
                cnTesting123Testing.Open()
                Dim sMode As String = ""
                Select Case GlobalVariables.DatabaseMode
                    Case GlobalVariables.DatabaseModeEnum.Production
                        sMode = "PRODUCTION"
                    Case GlobalVariables.DatabaseModeEnum.Test
                        sMode = "TEST"
                    Case Else
                        sMode = "DEVELOPMENT"
                End Select
                Throw New ApplicationException("Application is offline. You are connected to the " & sMode & " database")
            Catch ee As Exception
                Throw New ApplicationException("Critical error occurred. Database is missing or corrupt")
            End Try
        Finally
            If (cnTesting123Testing.State = ConnectionState.Open) Then cnTesting123Testing.Close()
        End Try

    End Sub

    Private Sub SetConnectionStatusColorAndLogDirectory()
        Select Case GlobalVariables.DatabaseMode
            Case GlobalVariables.DatabaseModeEnum.Test
                GlobalVariables.ConnectionStatusColor = Color.Yellow
                GlobalVariables.LogFullName = GlobalVariables.TestLogDirectory

            Case GlobalVariables.DatabaseModeEnum.Production
                GlobalVariables.ConnectionStatusColor = Color.Red
                GlobalVariables.LogFullName = GlobalVariables.ProductionLogDirectory
        End Select
    End Sub

    Private Function SwitchToOffline(ByVal connectionString As String) As String

        Dim strb As New System.Text.StringBuilder
        strb.Append(connectionString)
        Select Case GlobalVariables.DatabaseMode
            Case GlobalVariables.DatabaseModeEnum.Production
                strb.Insert(74, "_")
            Case GlobalVariables.DatabaseModeEnum.Test
                strb.Insert(68, "_")
        End Select
        Return strb.ToString()

    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

End Class