Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Text
Imports System.Net.Mail

'todo 20130215: automate updating contact address info from Hansen before generating the db record for these !!!

Public Class AnnualNotification

    Private m_emissionYear As Int16
    Public Sub New(ByVal emissionYear As Int16)
        InitializeComponent()
        Me.m_emissionYear = emissionYear
    End Sub

    Private Structure DestinationDirectory
        Friend Shared Development As String = GlobalVariables.ApplicationDataDirectory & "\EINotifications\"
        Const Production As String = "S:\Emissions Inventory\EINotifications\"
    End Structure

    Private Enum LetterTypeEnum
        TitleV
        FEDOOP
        Minor
    End Enum

    Private Structure TemplateName
        Public Const EINotification As String = "EINotification.dotx"
    End Structure


#Region "----- member variables -----"

    Private wordApp As Word.Application
    Private wordDoc As Word.Document
    Private wordSelection As Word.Selection 'represents the current selection in a window or pane

    Private Structure BookMark
        Private _trash As String

        Public Const addressLine1 As String = "addressLine1"
        Public Const addressLine2 As String = "addressLine2"

        Public Const calendarYear1 As String = "calendarYear1"
        Public Const calendarYear2 As String = "calendarYear2"
        Public Const plantLocation As String = "plantLocation"

        Public Const complianceCertifcateWording As String = "complianceCertifcateWording"
        Public Const complianceSupplementalWording As String = "complianceSupplementalWording"

        Public Const dueYear As String = "dueYear"

        Public Const eiEngineer As String = "eiEngineer"
        Public Const eiEngineerEmail As String = "eiEngineerEmail"
        Public Const eiEngineerPhone As String = "eiEngineerPhone"

        Public Const environmentalContact As String = "environmentalContact"
        Public Const plantID1 As String = "plantID1"
        Public Const plantName As String = "plantName"
        Public Const printDate As String = "printDate"
    End Structure

#End Region '----- member variables -----

    Private Sub AnnualNotification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Show()

#If DEBUG Then
        If (Not Directory.Exists(DestinationDirectory.Development)) Then
            Directory.CreateDirectory(DestinationDirectory.Development)
        End If
#End If

        Me.PlantYearContactsTableAdapter.Fill(Me.EmissionsDataSet.PlantYearContacts)

        Call Me.Go()

    End Sub

    Private Sub Go()

        Dim letterType As LetterTypeEnum
        Dim contactCount As Int32 = 1
        Me.ProgressBar1.Minimum = contactCount
        Me.ProgressBar1.Maximum = Me.EmissionsDataSet.PlantYearContacts.Count

        Try
            Me.wordApp = New Word.Application

            'company name, address, contact person name
            For Each contactRow As EmissionsDataSet.PlantYearContactsRow In Me.EmissionsDataSet.PlantYearContacts

                Me.ProgressBar1.Value = contactCount
                Me.Label1.Text = "Printing plant " _
                               & CStr(contactRow.PLANT_ID) _
                               & Tools.Constants.Character.Space _
                               & Tools.Constants.Character.LeftParenthesis _
                               & CStr(contactCount) _
                               & " of " _
                               & CStr(Me.EmissionsDataSet.PlantYearContacts.Count) _
                               & Tools.Constants.Character.RightParenthesis

                My.Application.DoEvents()


                'type of company, assigned engineer id
                Me.PlantYearTableAdapter.FillByPlantID_EmissionYear(Me.EmissionsDataSet.PlantYear, CInt(contactRow.PLANT_ID), Me.m_emissionYear)
                Dim plantYear As EmissionsDataSet.PlantYearRow = CType(Me.EmissionsDataSet.PlantYear.Rows(0), EmissionsInventory.EmissionsDataSet.PlantYearRow)

                'employee info
                Dim objEmployee As PeopleLibrary.Business.Employee = PeopleLibrary.Utility.EmployeeUtility.GetByPrimaryKey(plantYear.AssignedEditor)
                Dim employeeWorkPhone = PeopleLibrary.Utility.EmployeeTelephoneNumberUtility.GetWorkByEmployeeID(objEmployee.EmployeeID)
                Dim employeeEmail As String = PeopleLibrary.Utility.EmployeeEmailUtility.GetByEmployeeID(objEmployee.EmployeeID)

                'instantiate the template
#If DEBUG Then
                Dim templateFile As New FileInfo(GlobalVariables.TemplateDirectory.Development & TemplateName.EINotification)
#Else
                Dim templateFile As New FileInfo(GlobalVariables.TemplateDirectory.Production & TemplateName.EINotification)
#End If

                'determine if this plant is TV, FEDOOP, or Minor
                Dim thisPlant As EmissionsDataSet.PlantRow = GlobalVariables.LookupTable.Plant.FindByPlantID(contactRow.PLANT_ID)
                Select Case CType(thisPlant.PlantClassID, GlobalVariables.PlantClassEnum)
                    Case GlobalVariables.PlantClassEnum.TitleV
                        letterType = LetterTypeEnum.TitleV
                    Case GlobalVariables.PlantClassEnum.FEDOOP
                        letterType = LetterTypeEnum.FEDOOP
                    Case GlobalVariables.PlantClassEnum.Minor
                        letterType = LetterTypeEnum.Minor
                End Select

                Try
                    Me.wordDoc = Me.wordApp.Documents.Add(CType(templateFile.FullName, Object))
                    Me.wordSelection = Me.wordApp.Selection

                    Me.WriteBookmark(BookMark.printDate, Format(Date.Now, GlobalVariables.DateFormat._Medium))
                    Me.WriteBookmark(BookMark.plantID1, CStr(plantYear.PlantID))

                    Dim plant As EmissionsDataSet.PlantRow = GlobalVariables.LookupTable.Plant.FindByPlantID(plantYear.PlantID)
                    Me.WriteBookmark(BookMark.plantName, plant.PlantName)

                    '                    Me.WriteBookmark(BookMark.addressLine1, StrConv(contactRow.ADDR1, vbProperCase))
                    'TODO: Include address line 2 (ADDR2) if not empty.
                    Me.WriteBookmark(BookMark.addressLine1, contactRow.ADDR1)

                    'Me.WriteBookmark(BookMark.addressLine2, _
                    '                 StrConv(contactRow.CITY, vbProperCase) _
                    '                 & ", " _
                    '                 & contactRow.STATE _
                    '                 & " " _
                    '                 & contactRow.ZIP.Substring(0, 5))
                    Me.WriteBookmark(BookMark.addressLine2, contactRow.CITY _
                                     & ", " _
                                     & contactRow.STATE _
                                     & " " _
                                     & contactRow.ZIP.Substring(0, 5))



                    Me.WriteBookmark(BookMark.calendarYear1, CStr(Me.m_emissionYear))
                    Me.WriteBookmark(BookMark.plantLocation, contactRow.Location)

                    ''Me.WriteBookmark(BookMark.environmentalContact, _
                    ''                 StrConv(contactRow.CNTCTFIRST, vbProperCase) _
                    ''                 & " " _
                    ''                 & StrConv(contactRow.CNTCTLAST, vbProperCase))

                    Me.WriteBookmark(BookMark.environmentalContact, "To whom it may concern")

                    Me.WriteBookmark(BookMark.dueYear, CStr(Now.Date.Year))

                    Me.WriteBookmark(BookMark.calendarYear2, CStr(Me.m_emissionYear))

                    'Dim complianceCertifcateWording As String = String.Empty
                    'Dim complianceSupplementalWording As String = String.Empty
                    'Dim complianceCertifcateWordingFont As New Word.Font
                    'complianceCertifcateWordingFont.Bold = Word.WdConstants.wdToggle

                    'Select Case letterType
                    '    Case LetterTypeEnum.TitleV
                    '        complianceCertifcateWording = "Also, the Annual Compliance Certificate signed by the responsible official of your company is required. "
                    '        complianceSupplementalWording = "You are also required to submit the compliance certificate directly to EPA Region IV.  The mailing address is listed in the General Conditions of your Title V permit. "
                    '    Case LetterTypeEnum.FEDOOP
                    '        complianceCertifcateWording = "Also, the Annual Compliance Certificate signed by the responsible official of your company is required. "
                    'End Select

                    'Me.WriteBookmark(BookMark.complianceCertifcateWording, complianceCertifcateWording, complianceCertifcateWordingFont)
                    'Me.WriteBookmark(BookMark.complianceSupplementalWording, complianceSupplementalWording)

                    Me.WriteBookmark(BookMark.eiEngineer, _
                                     objEmployee.NickName _
                                     & " " _
                                     & objEmployee.LastName)

                    Me.WriteBookmarkEmail(BookMark.eiEngineerEmail, employeeEmail)
                    Me.WriteBookmark(BookMark.eiEngineerPhone, employeeWorkPhone)


                    Dim filename As Object = Me.CreateFileName(plant)
                    'Me.wordDoc.SaveAs(filename)
                    Me.wordDoc.ExportAsFixedFormat(CStr(filename), Word.WdExportFormat.wdExportFormatPDF)
                    Me.wordDoc.Close(False)
                    Me.wordDoc = Nothing

                Catch ex As Exception
                    Throw
                End Try

                contactCount += 1
            Next
            MessageBox.Show("Notifications successfully created.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.wordDoc = Nothing
        Me.wordApp = Nothing

        Me.Timer1.Start()

    End Sub

    Private Sub WriteBookmark(ByVal strBookMarkName As String, ByVal strDataToWrite As String)

        With Me.wordSelection
            .GoTo(Word.WdGoToItem.wdGoToBookmark, , , CType(strBookMarkName, Object))
            .TypeText(strDataToWrite)
        End With

    End Sub

    Private Sub WriteBookmark(ByVal strBookMarkName As String, ByVal strDataToWrite As String, ByVal font As Word.Font)

        With Me.wordSelection
            .GoTo(Word.WdGoToItem.wdGoToBookmark, , , CType(strBookMarkName, Object))
            .Font.Bold = Word.WdConstants.wdToggle
            .TypeText(strDataToWrite)
        End With

    End Sub

    Private Sub WriteBookmarkEmail(ByVal strBookMarkName As String, ByVal strDataToWrite As String)

        With Me.wordSelection
            .GoTo(Word.WdGoToItem.wdGoToBookmark, , , CType(strBookMarkName, Object))
            .Hyperlinks.Add(.Range, CType("mailto:" & strDataToWrite, Object), , , CType(strDataToWrite, Object))

            '.TypeText(strDataToWrite)
        End With

    End Sub


    Private Function CreateFileName(ByVal plant As EmissionsDataSet.PlantRow) As Object

        Dim filename As New StringBuilder
        With filename

#If DEBUG Then
            .Append(DestinationDirectory.Development)
#Else
            .Append(DestinationDirectory.Production)
#End If
            .Append(Tools.Constants.Character.BackSlash)
            .Append(CStr(Me.m_emissionYear))
            .Append(" EI Notification -- ")
            .Append(CStr(plant.PlantID))
            .Append(Space(1))
            .Append(plant.PlantName)
            '.Append(".docx")
            .Append(".pdf")
        End With

        Return filename.ToString

    End Function

    Private Sub CreateEmail()
        Dim message As New System.Net.Mail.MailMessage
        With (message)


        End With

        Dim server As New System.Net.Mail.SmtpClient
        With server
            .Host = "INSERT SMTP SERVER NAME HERE"
            '.Port 'IS THIS NEEDED?
            'CALL 'SEND' HERE
        End With

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

End Class