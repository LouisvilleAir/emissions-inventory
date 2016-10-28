Imports APCD.Common 'Applications, People
Imports System.IO

Public Class splashScreenForm

    Private Sub splashScreenForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''If (Me.ApplicationIsRunning) Then
        ''    MessageBox.Show("Application is already running", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ''    End
        ''Else
        ''    Call Me.StartUp()
        ''    Me.Timer1.Start()
        ''End If

        Call Me.StartUp()
        Me.Timer1.Start()

    End Sub

    Private Function ApplicationIsRunning() As Boolean

        Dim blnApplicationIsRunning As Boolean
        Dim strProcessName As String = Process.GetCurrentProcess().ProcessName
        Dim processes As Process() = Process.GetProcessesByName(strProcessName)

        If (processes.Length > 1) Then
            blnApplicationIsRunning = True
        Else
            blnApplicationIsRunning = False
        End If

        Return blnApplicationIsRunning

    End Function

    Private Sub StartUp()

        Dim exitTheApplication As Boolean = False
        Me.Show()
        Application.DoEvents()

        Dim mainConnection As String = Me.GetMain
        Dim devConfigFile As New FileInfo(GlobalVariables.ApplicationConfigurationDirectory & "\developer.cfg")

        If (mainConnection = String.Empty) Then
            GlobalVariables.MainConnectionStatus = GlobalVariables.MainConnectionStatusEnum.Unavailable
            If (devConfigFile.Exists) Then
                GlobalVariables.DatabaseMode = GlobalVariables.DatabaseModeEnum.Development
                Call Me.Engage(devConfigFile)
            Else
                MessageBox.Show("Main connection does not exist.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                exitTheApplication = True
            End If

        Else

            Call GlobalMethods.SetMainConnnection(mainConnection)
            GlobalVariables.MainConnectionStatus = GlobalVariables.MainConnectionStatusEnum.Available

            If (devConfigFile.Exists) Then 'user is a programmer
#If DEBUG Then
                Dim frm As New chooseApplicationModeForm(devConfigFile)
                frm.ShowDialog()

                If (GlobalVariables.UserRole <> GlobalVariables.Role.Programmer) Then
                    MessageBox.Show("Your user role is invalid.")
                    exitTheApplication = True
                End If
#Else
                GlobalVariables.DatabaseMode = GlobalVariables.DatabaseModeEnum.Production
                Call Me.Engage()
#End If

            Else 'user is not a programmer

#If DEBUG Then
                GlobalVariables.DatabaseMode = GlobalVariables.DatabaseModeEnum.Test
#Else
                GlobalVariables.DatabaseMode = GlobalVariables.DatabaseModeEnum.Production
#End If
                Call Me.Engage()

            End If
        End If

        If (exitTheApplication = True) Then
            End
        End If

    End Sub

    Private Function GetMain() As String

        Dim main As String = String.Empty
        Dim obj As APCD.DataProviderLibrary.MainService
        'Dim url As String = "tcp://apcbar02tryand1:6000/MainServiceDataProvider"
        Dim url As String = "tcp://svapps164:6000/MainServiceDataProvider"

        Try
            obj = CType(Activator.GetObject(Type.GetType("APCD.DataProviderLibrary.MainService, APCD.DataProviderLibrary"), _
                 url),  _
                  APCD.DataProviderLibrary.MainService)
            main = obj.GetMain
        Catch ex As Exception
            main = String.Empty
        Finally
            obj = Nothing
        End Try

        Return main

    End Function

#Region "----- methods to handle a connected session -----"

    Private Sub Engage()

        Dim userName As String = GlobalMethods.GetFriendlyUserName
        Dim exitTheApplication As Boolean = False
        Try
            Call GlobalMethods.InitializeApplicationObject()
            Call GlobalMethods.InitializeApplicationDatabases()
            Call GlobalMethods.ValidateTheUser(userName)
            Call Me.ValidateTheConnection()
            Call GlobalMethods.AssignUserRole()
            Call Me.SetLogDirectory()

            Applications.Utility.EmployeeApplicationUtility.Logon(GlobalVariables.EmployeeApplication.EmployeeApplicationID) 'flag the user as logged on
        Catch ex As Exception
            MessageBox.Show("An error occured during application startup: " & ex.Message, "Application Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            exitTheApplication = True
        End Try

        If (exitTheApplication = True) Then
            End
        End If

    End Sub

    Private Sub ValidateTheConnection()

        Dim cnTesting123Testing As OleDb.OleDbConnection = Nothing

        Try
            cnTesting123Testing = New OleDb.OleDbConnection(Emissions.Globals.GlobalVariables.ConnectionString)
            cnTesting123Testing.Open()
        Catch ex As Exception
            MessageBox.Show("The application is currently offline.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        Finally
            If (cnTesting123Testing.State = ConnectionState.Open) Then cnTesting123Testing.Close()
        End Try

    End Sub

    Private Sub SetLogDirectory()
        Select Case GlobalVariables.DatabaseMode
            Case GlobalVariables.DatabaseModeEnum.Test
                GlobalVariables.ConnectionStatusColor = Color.Yellow
                GlobalVariables.LogFullName = GlobalVariables.TestLogDirectory

            Case GlobalVariables.DatabaseModeEnum.Production
                GlobalVariables.LogFullName = GlobalVariables.ProductionLogDirectory
        End Select
        Console.WriteLine(GlobalVariables.LogFullName)
    End Sub

#End Region '----- methods to handle a connected session -----

#Region "----- methods to handle a disconnected session -----"

    Private Sub Engage(ByVal devConfigFilePath As FileInfo)

        Dim userName As String = GlobalMethods.GetFriendlyUserName

        Call GlobalMethods.SetOfflineLogFilesAndConnectionStrings(devConfigFilePath.FullName)

        Try
            Try
                GlobalVariables.Application = Applications.Utility.ApplicationUtility.GetByLookupName(Application.ProductName)
                If (GlobalVariables.Application Is Nothing) Then
                    Throw New ApplicationException("Unable to obtain application information.")
                End If
            Catch ex As Exception
                Throw New ApplicationException("Unable to obtain application information.")
            End Try

            Try
                GlobalVariables.Employee = PeopleLibrary.Utility.EmployeeUtility.GetByUserName(userName)
            Catch ex As Exception
                Throw New ApplicationException("Unable to obtain user information.")
            End Try

            Try
                GlobalVariables.EmployeeApplication = Applications.Utility.EmployeeApplicationUtility.GetByEmployeeID_ApplicationID(GlobalVariables.Employee.EmployeeID, GlobalVariables.Application.ApplicationID)
            Catch ex As Exception
                Throw New ApplicationException("Unable to obtain employee application information.")
            End Try

            If (GlobalVariables.EmployeeApplication Is Nothing) Then
                MessageBox.Show("You are not a user of this system.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf (GlobalVariables.EmployeeApplication.IsActive = False) Then
                MessageBox.Show("Your access to this application has been disabled. Please contact APCD IT for assistance.", "Access Disabled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Call GlobalMethods.AssignUserRole()

            Applications.Utility.EmployeeApplicationUtility.Logon(GlobalVariables.EmployeeApplication.EmployeeApplicationID) 'flag the user as logged on
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred during user validation: " & ex.Message, "Application Aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End Try

    End Sub

#End Region '----- methods to handle a disconnected session -----



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

End Class