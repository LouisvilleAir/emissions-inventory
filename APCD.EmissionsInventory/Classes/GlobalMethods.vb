'***********************************************************************************************************************
'Assembly Name: APCD.EmissionsInventory
'Filename: Classes\GlobalMethods.vb
'Author: Mike Farris
'Date: 09/20/2011
'Description: Provides a central point to access global methods used by the application.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Emissions
Imports APCD.Common

Imports System.IO

Public Class GlobalMethods

    Friend Shared Function GetFriendlyUserName() As String

        Dim strUserName As String

        If (My.User.Name.Contains("\")) Then
            strUserName = My.User.Name.Substring(My.User.Name.IndexOf("\") + 1)
        Else
            strUserName = My.User.Name
        End If

        Return strUserName

    End Function

    Friend Shared Sub SetOfflineLogFilesAndConnectionStrings(ByVal path As String)

        'read the file into a hashtable
        Dim sr As New StreamReader(path)
        Dim keyValuePairTable As New Hashtable
        Do While (sr.Peek > -1)
            Dim tempLine As String = sr.ReadLine()
            If (Not tempLine Is Nothing) AndAlso (tempLine.Length > 0) Then
                Dim indexOfFirstEqualSign As Int32 = tempLine.IndexOf(Tools.Constants.Character.EqualSign)
                Dim key As String = tempLine.Substring(0, indexOfFirstEqualSign)
                Dim value As String = tempLine.Substring(indexOfFirstEqualSign + 1, tempLine.Length - (indexOfFirstEqualSign + 1))
                keyValuePairTable.Add(key, value)
            End If
        Loop
        sr.Close()

        'all apps need the log file and Applications and People for authentication
        GlobalVariables.LogFullName = CStr(keyValuePairTable("logDirectory")) & "\" & Format(Now, "yyyyMMdd") & ".log"
        Applications.Globals.GlobalVariables.ConnectionString = CStr(keyValuePairTable(GlobalVariables.DatabaseName.Applications))
        PeopleLibrary.Globals.GlobalVariable.ConnectionString = CStr(keyValuePairTable(GlobalVariables.DatabaseName.People))
        Emissions.Globals.GlobalVariables.ConnectionString = CStr(keyValuePairTable(GlobalVariables.DatabaseName.Emissions))
        AirPollution.Globals.GlobalVariables.ConnectionString = CStr(keyValuePairTable(GlobalVariables.DatabaseName.AirPollution))

    End Sub

#Region "----- methods to handle a connected session -----"

    Friend Shared Sub SetMainConnnection(ByVal mainConnection As String)

        Try
            Applications.Globals.GlobalVariables.ConnectionString = mainConnection
        Catch ex As Exception
            Throw New ApplicationException("Unable to set main connection.")
        End Try

    End Sub

    Friend Shared Sub InitializeApplicationObject()

        Try
            GlobalVariables.Application = Applications.Utility.ApplicationUtility.GetByLookupName(My.Application.Info.ProductName)
            If (GlobalVariables.Application Is Nothing) Then
                Throw New ApplicationException("Unable to obtain application information.")
            End If
        Catch ex As Exception
            Throw New ApplicationException("Unable to obtain application information.")
        End Try

    End Sub

    Friend Shared Sub InitializeApplicationDatabases()
        Try
            'set all of the DBs for a given application
            Dim dtb As DataTable = Applications.Utility.ApplicationDatabasseUtility.GetByApplicationID(GlobalVariables.Application.ApplicationID)
            For Each row As DataRow In dtb.Rows
                Dim databaseID As Int32 = CInt(row(Applications.Constants.ApplicationDatabasseConstants.FieldName.DatabasseID))
                Dim objDatabase As Applications.Business.Databasse = Applications.Utility.DatabasseUtility.GetByPrimaryKey(databaseID)

                Select Case GlobalVariables.DatabaseMode
                    Case GlobalVariables.DatabaseModeEnum.Test
                        Select Case objDatabase.DatabasseName
                            Case GlobalVariables.DatabaseName.Applications
                                Applications.Globals.GlobalVariables.ConnectionString = objDatabase.TestConnectionString
                            Case GlobalVariables.DatabaseName.Emissions
                                Emissions.Globals.GlobalVariables.ConnectionString = objDatabase.TestConnectionString
                            Case GlobalVariables.DatabaseName.People
                                PeopleLibrary.Globals.GlobalVariable.ConnectionString = objDatabase.TestConnectionString
                        End Select

                    Case GlobalVariables.DatabaseModeEnum.Production
                        Select Case objDatabase.DatabasseName
                            Case GlobalVariables.DatabaseName.Applications
                                Applications.Globals.GlobalVariables.ConnectionString = objDatabase.ProductionConnectionString
                            Case GlobalVariables.DatabaseName.Emissions
                                Emissions.Globals.GlobalVariables.ConnectionString = objDatabase.ProductionConnectionString
                            Case GlobalVariables.DatabaseName.People
                                PeopleLibrary.Globals.GlobalVariable.ConnectionString = objDatabase.ProductionConnectionString

                            Case GlobalVariables.DatabaseName.EmissionsEIS_FacilityExport
                                EmissionsEIS_FacilityExport.Globals.GlobalVariables.ConnectionString = objDatabase.ProductionConnectionString

                            Case GlobalVariables.DatabaseName.EmissionsPointExport
                                EmissionsPointExport.Globals.GlobalVariables.ConnectionString = objDatabase.ProductionConnectionString
                        End Select
                End Select
                Console.WriteLine(objDatabase.ProductionConnectionString)

            Next
        Catch ex As Exception
            Throw New ApplicationException("Unable to initialize application databases.")
        End Try
    End Sub

    Friend Shared Sub ValidateTheUser(ByVal userName As String)

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
            Throw New ApplicationException("You are not a user of this system.")
        ElseIf (GlobalVariables.EmployeeApplication.IsActive = False) Then
            Throw New ApplicationException("Your access to this application has been disabled. Please contact APCD IT for assistance.")
        End If

    End Sub

#End Region '----- methods to handle a connected session -----

    Friend Shared Sub HandleError(ByVal ex As Exception)

        Dim message As New System.Text.StringBuilder
        Dim messagePrefix As New System.Text.StringBuilder
        Dim outerMessage As New System.Text.StringBuilder
        Dim ok As Boolean

        With messagePrefix
            .Append(Format(Date.Now, "HH:mm:ss"))
            .Append(Tools.Constants.Character.Space)
            .Append(GlobalVariables.Employee.UserName)
            .Append(vbTab)
        End With

        message.Append(messagePrefix.ToString())
        message.Append("Error message: ")
        message.AppendLine(ex.Message)

        message.Append(messagePrefix.ToString())
        message.Append("StackTrace: ")
        message.AppendLine(ex.StackTrace)
        message.AppendLine("------------------------------------------------------------------------------------------------------------------------------------------")

        Dim writer As IO.StreamWriter = Nothing
        Try
            writer = New IO.StreamWriter(GlobalVariables.LogFullName, True)
            writer.Write(message.ToString)
            ok = True
        Catch e As Exception
            ok = False
            With outerMessage
                .AppendLine("An error occurred while writing the application log file:")
                .AppendLine(e.Message)
                .AppendLine("Original error: ")
                .Append(message.ToString)
            End With
        End Try
        If (Not writer Is Nothing) Then writer.Close()

        'write to MyDocuments if unable to write to the app log 
        If (ok = False) Then
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments _
                                 & Tools.Constants.Character.BackSlash _
                                 & My.Application.Info.ProductName _
                                 & Tools.Constants.Character.Space _
                                 & Tools.Constants.Character.MinusSign _
                                 & Tools.Constants.Character.Space _
                                 & Format(Date.Now, "yyyyMMddhhmmss") & ".txt"
            writer = New IO.StreamWriter(path, True)
            writer.Write(outerMessage.ToString)
            writer.Close()
        End If

    End Sub

    Friend Shared Sub AssignUserRole()

        Select Case GlobalVariables.EmployeeApplication.RoleID
            Case 1
                GlobalVariables.UserRole = GlobalVariables.Role.User
            Case 2
                GlobalVariables.UserRole = GlobalVariables.Role.PowerUser
            Case 3
                GlobalVariables.UserRole = GlobalVariables.Role.Administrator
            Case 4
                GlobalVariables.UserRole = GlobalVariables.Role.Programmer
            Case 5
                GlobalVariables.UserRole = GlobalVariables.Role.Guest
            Case 6
                GlobalVariables.UserRole = GlobalVariables.Role.Approver
        End Select

    End Sub

    ''' <summary>
    ''' Provides a temporary ID for the new record until we make a facility submittal to obtain the EPA assigned ID.
    ''' </summary>
    ''' <returns>Returns a negative 9 to 10 digit number in the format MMddhhmmss</returns>
    ''' <remarks></remarks>
    Public Shared Function GenerateTempEISID() As Int32

        Dim eisidString As String = Format(Date.Now, "MMddHHmmss")
        Return -(CInt(eisidString))

    End Function

    Friend Shared Sub ToggleApprovalButtonText(ByVal status As GlobalVariables.ApprovalStatus, ByVal approveButton As Windows.Forms.Button)

        Select Case status
            Case GlobalVariables.ApprovalStatus.Approved
                approveButton.Text = GlobalVariables.Words.Unapprove

            Case GlobalVariables.ApprovalStatus.UnApproved
                approveButton.Text = GlobalVariables.Words.Approve
        End Select

    End Sub

    Friend Shared Sub ToggleApprovalButtonEnabled(ByVal approveButton As Windows.Forms.Button)

#If DEBUG Then
        If ((GlobalVariables.UserRole = GlobalVariables.Role.Approver) OrElse (GlobalVariables.UserRole = GlobalVariables.Role.Programmer)) Then
            approveButton.Enabled = True
        Else
            approveButton.Enabled = False
        End If
#Else
        If (GlobalVariables.UserRole = GlobalVariables.Role.Approver) Then
            approveButton.Enabled = True
        Else
            approveButton.Enabled = False
        End If
#End If

    End Sub

End Class
