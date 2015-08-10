Imports Microsoft.Office.Interop
Imports System.Text


Public Class ImportE91T

    Private m_emissionYear As Int16
    Sub New(ByVal emissionYear As Int16)
        InitializeComponent()
        Me.m_emissionYear = emissionYear
    End Sub

    Private m_errorFile As IO.FileInfo
    Private m_mainErrorLog As StringBuilder

    Private m_mainImportLog As StringBuilder
    Private m_mainImportLogFile As IO.FileInfo

    Private m_excelApp As Excel.Application
    Private m_workbook As Excel.Workbook
    Private m_e91TSheet As Excel.Worksheet
    Private m_stacksSheet As Excel.Worksheet
    Private m_fugitivesSheet As Excel.Worksheet

    Private m_plantID As Int32 = 0 'set when check the "E91T" sheet

    Private Sub ImportE91T_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ReleasePointTypeTableAdapter.Fill(Me.ReleasePointDataSet.ReleasePointType)
        'Me.lblProgress.Text = String.Empty

    End Sub

#Region "----- E91T Workbook -----"

    Private Enum SheetNameEnum
        E91T
        Stacks
        Fugitives
    End Enum

    Partial Structure SheetName
        Const E91T As String = "E91T"
        Const Stacks As String = "Stacks"
        Const Fugitives As String = "Fugitives"
    End Structure

    Private Structure ColumnName
        Const ReleasePointIdentifier As String = "Release Point Identifier"
        Const StackType As String = "Stack Type"
        Const Shape As String = "Shape"
        Const ReleasePointDescription As String = "Release Point Description"
        Const Latitude As String = "Latitude"
        Const Longitude As String = "Longitude"
        Const Height As String = "Height"
        Const Diameter As String = "Stack Diameter (ft)"
        Const Length As String = "Length"
        Const Width As String = "Width"
        Const ExhaustGasTemperature As String = "Exhaust Gas Temperature (°F)"
        Const ExitGasFlowRate As String = "Exit Gas Flow Rate (ACFM)"
        Const DistanceFromFenceLine As String = "Distance from Fence Line (ft)"
        Const Comment As String = "Comment"

        Const FugitiveReleaseType As String = "Fugitive Release Type"
        Const Angle As String = "Angle"
    End Structure

    Private Structure ValidationMessages
        Const ColumnIsMissing As String = " column is missing."
        Const ValueIsMissing As String = " value is missing."
        Const ValueIsNotNumeric As String = " value is not numeric."
        Const MustBe255CharactersOrLess As String = " must be <= 255 characters."
    End Structure

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel 'changes to OK only if successful import

        Dim sourceFile As IO.FileInfo

        Dim filedialog As New OpenFileDialog
        With filedialog
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Multiselect = False
            .Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx"
            If (.ShowDialog = DialogResult.OK) Then

                'check to make sure that the facility submittal is not final
                Me.EmissionYearTableAdapter.FillByEmissionYear(Me.ReleasePointDataSet.EmissionYear, Me.m_emissionYear)
                If (CType(Me.ReleasePointDataSet.EmissionYear.Rows(0), ReleasePointDataSet.EmissionYearRow).IsFacilityInEISDateNull) Then

                    If (.FileName <> String.Empty) Then
                        sourceFile = New IO.FileInfo(.FileName)
                        Me.m_errorFile = New IO.FileInfo(sourceFile.FullName.Substring(0, sourceFile.FullName.Length - 4) & ".ERROR REPORT.txt")

                        Call Me.QATheForm(sourceFile)

                        If (Me.m_mainErrorLog.Length = 0) Then

                            If (MessageBox.Show("QA check completed without errors. Would you like to import this data into the database now?", "Import Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                                Me.m_mainImportLogFile = New IO.FileInfo(sourceFile.FullName.Substring(0, sourceFile.FullName.Length - 4) & ".IMPORT REPORT.txt")
                                Call Me.WriteImportReportHeader(sourceFile)
                                Call Me.ImportTheData()
                                MessageBox.Show("Release points imported successfully", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                Me.DialogResult = Windows.Forms.DialogResult.OK

                                Process.Start(Me.m_mainImportLogFile.FullName)

                            Else
                                Me.Timer1.Start()
                            End If

                        ElseIf (Me.m_mainErrorLog.Length > 0) Then

                            Dim message As New StringBuilder
                            message.AppendLine("******************************************************************************************")
                            message.AppendLine("Form 91T QA Error Report")
                            message.AppendLine("Plant ID: " & CStr(Me.m_plantID))
                            message.AppendLine("File Name: " & sourceFile.Name)
                            message.AppendLine("Calendar Year: " & CStr(Me.m_emissionYear))
                            message.AppendLine("Report run date: " & Format(Date.Now, "dddd MMMM dd, yyyy  HH:mm:ss"))
                            message.AppendLine("******************************************************************************************")
                            message.AppendLine()
                            Me.m_mainErrorLog.Insert(0, message.ToString)
                            Dim sw As New IO.StreamWriter(Me.m_errorFile.FullName)
                            sw.Write(Me.m_mainErrorLog.ToString)
                            sw.Close()
                            MessageBox.Show("Errors occured", "Invalid Workbook", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Process.Start(Me.m_errorFile.FullName)
                        End If

                    End If 'FileName <> String.Empty

                End If 'IsFacilityInEISDateNull

            End If 'ShowDialog = DialogResult.OK

        End With

        filedialog = Nothing
        Me.Timer1.Start()

    End Sub

    Private Sub QATheForm(ByVal sourceFile As IO.FileInfo)

        Me.btnCancel.Enabled = False

        If Me.m_errorFile.Exists Then Me.m_errorFile.Delete()

        Me.m_mainErrorLog = New StringBuilder

        Dim feedbackMessage As New StringBuilder

        Me.m_excelApp = New Excel.Application
        Me.m_workbook = Me.m_excelApp.Workbooks.Open(sourceFile.FullName)

        If (Me.E91TSheetsExists = True) Then
            Call Me.CheckE91TSheet()

            If (Me.m_mainErrorLog.Length = 0) Then
                If (Me.StacksSheetsExists) Then
                    Call Me.CheckStacksSheet()
                End If

                If (Me.FugitivesSheetsExists) Then
                    Call Me.CheckFugitivesSheet()
                End If

            End If
        End If

        'clean up
        Me.m_e91TSheet = Nothing
        Me.m_stacksSheet = Nothing
        Me.m_fugitivesSheet = Nothing
        m_workbook.Close()
        Me.m_excelApp = Nothing

        Me.lblProgress.Text = String.Empty
        Me.btnCancel.Enabled = True

    End Sub

    Private Function E91TSheetsExists() As Boolean

        Dim returnValue As Boolean

        Try
            Call Me.AddSheetToWorkbook(SheetNameEnum.E91T)
            returnValue = True
        Catch ex As Exception
            returnValue = False
            Me.m_mainErrorLog.AppendLine(ex.Message)
        End Try

        Return returnValue

    End Function

    Private Function StacksSheetsExists() As Boolean

        Dim returnValue As Boolean

        Try
            Call Me.AddSheetToWorkbook(SheetNameEnum.Stacks)
            returnValue = True
        Catch ex As Exception
            returnValue = False
            Me.m_mainErrorLog.AppendLine(ex.Message)
        End Try

        Return returnValue

    End Function

    Private Function FugitivesSheetsExists() As Boolean

        Dim returnValue As Boolean

        Try
            Call Me.AddSheetToWorkbook(SheetNameEnum.Fugitives)
            returnValue = True
        Catch ex As Exception
            returnValue = False
            Me.m_mainErrorLog.AppendLine(ex.Message)
        End Try

        Return returnValue

    End Function

    Private Sub AddSheetToWorkbook(ByVal sheet As SheetNameEnum)

        Dim sheetNameToAdd As String = String.Empty

        Try
            Select Case sheet
                Case SheetNameEnum.E91T
                    sheetNameToAdd = SheetName.E91T
                    Me.m_e91TSheet = CType(Me.m_workbook.Worksheets(sheetNameToAdd), Excel.Worksheet)
                Case SheetNameEnum.Stacks
                    sheetNameToAdd = SheetName.Stacks
                    Me.m_stacksSheet = CType(Me.m_workbook.Worksheets(sheetNameToAdd), Excel.Worksheet)
                Case SheetNameEnum.Fugitives
                    sheetNameToAdd = SheetName.Fugitives
                    Me.m_fugitivesSheet = CType(Me.m_workbook.Worksheets(sheetNameToAdd), Excel.Worksheet)
            End Select
        Catch ex As Exception
            Throw New ApplicationException(sheetNameToAdd & " sheet is missing.")
        End Try

    End Sub

#Region "----- E91T Workbook ----- 91T sheet -----"

    Private Sub CheckE91TSheet()

        Dim errorMessage As New StringBuilder
        Dim header As String = "------------------------- E91T sheet -------------------------" & vbCrLf

        Dim plantIDCoordinate As String = "D30"
        Dim emissionYearCoordinate As String = "H30"

        Try
            Dim range As Excel.Range = Me.m_e91TSheet.Range(plantIDCoordinate, plantIDCoordinate)
            Me.m_plantID = CInt(range.Value)
            If (Me.m_plantID = 0) Then Throw New ApplicationException(String.Empty)
        Catch ex As Exception
            errorMessage.Append("* Plant ID (")
            errorMessage.Append(plantIDCoordinate)
            errorMessage.AppendLine(") is missing or invalid.")
        End Try

        Try
            Dim range As Excel.Range = Me.m_e91TSheet.Range(emissionYearCoordinate, emissionYearCoordinate)
            Dim emissionYear As Int16 = CShort(range.Value)
            If (emissionYear <> Me.m_emissionYear) Then Throw New ApplicationException(String.Empty)
        Catch ex As Exception
            errorMessage.Append("* Emission Year (")
            errorMessage.Append(emissionYearCoordinate)
            errorMessage.AppendLine(") is missing or invalid.")
        End Try

        If (errorMessage.Length > 0) Then
            errorMessage.Insert(0, header)
            errorMessage.AppendLine()
            Me.m_mainErrorLog.Append(errorMessage.ToString)
        End If

    End Sub

#End Region '----- E91T Workbook ----- 91T sheet -----

#Region "----- E91T Workbook ----- Stack sheet -----"

    Private Sub CheckStacksSheet()

        Dim errorMessage As New StringBuilder
        Dim header As String = "------------------------- stacks sheet -------------------------" & vbCrLf

        Dim rowNumber As Int32 = 1
        Dim row As ArrayList = Me.GetStackRow(rowNumber)

        Do While Me.IsEndOfSheet(row) = False
            Try
                Call Me.CheckStacksSheetRow(rowNumber, row)
            Catch ex As Exception
                errorMessage.Append(ex.Message)
            End Try
            rowNumber += 1
            row = Me.GetStackRow(rowNumber)
        Loop

        If (errorMessage.Length > 0) Then
            errorMessage.Insert(0, header)
            Me.m_mainErrorLog.Append(errorMessage.ToString)
        End If

    End Sub

    Private Function GetStackRow(ByVal rowNumber As Int32) As ArrayList

        Dim row As New ArrayList

        Try
            Dim value As String
            For characterCode As Byte = 65 To 78
                Dim coordinates As String = Chr(characterCode) & rowNumber.ToString
                If (IsNothing(CType(Me.m_stacksSheet.Range(coordinates, coordinates), Excel.Range).Value)) Then
                    value = String.Empty
                Else
                    value = CStr(CType(Me.m_stacksSheet.Range(coordinates, coordinates), Excel.Range).Value).Trim & String.Empty
                End If
                row.Add(value)
            Next
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            Throw New ApplicationException("An error occurred reading a row from the stacks worksheet.")
        End Try
        Return row

    End Function

    Private Sub CheckStacksSheetRow(ByVal rowNumber As Int32, ByVal rowList As ArrayList)
        Me.lblProgress.Text = "Running QA on 'Stacks' row " & rowNumber.ToString

        'data type
        'empty/null
        'field lengths
        'range
        'lookup value
        Dim errorMessage As New StringBuilder
        Dim header As String = "Row " & rowNumber.ToString & vbCrLf
        Dim value As String
        Dim row As ReleasePointDataSet.autoE91T_StacksRow = Me.ReleasePointDataSet.autoE91T_Stacks.NewautoE91T_StacksRow

        'Release Point Identifier (APCDID)
        Try
            value = CStr(rowList(0))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ReleasePointIdentifier) Then
                    Throw New ApplicationException(ColumnName.ReleasePointIdentifier & ValidationMessages.ColumnIsMissing)
                End If
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.ReleasePointIdentifier & ValidationMessages.ValueIsMissing)
                End If
                row.APCDID = value
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        'StackType (ReleasePointType)
        Try
            value = CStr(rowList(1))
            If (rowNumber = 1) Then
                If (value <> ColumnName.StackType) Then Throw New ApplicationException(ColumnName.StackType & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.StackType & ValidationMessages.ValueIsMissing)
                Else
                    Dim rows() As ReleasePointDataSet.ReleasePointTypeRow = CType(Me.ReleasePointDataSet.ReleasePointType.Select("ReleasePointTypeName = '" & value & "'"), EmissionsInventory.ReleasePointDataSet.ReleasePointTypeRow())
                    If (rows.Count = 0) Then
                        Throw New ApplicationException(ColumnName.StackType & " is invalid.")
                    Else
                        row.ReleasePointTypeID = rows(0).ReleasePointTypeID
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(2))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Shape) Then Throw New ApplicationException(ColumnName.Shape & ValidationMessages.ColumnIsMissing)
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(3))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ReleasePointDescription) Then Throw New ApplicationException(ColumnName.ReleasePointDescription & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    row.SetReleasePointDescriptionNull()
                Else
                    row.ReleasePointDescription = value
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(4))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Latitude) Then Throw New ApplicationException(ColumnName.Latitude & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Latitude & ValidationMessages.ValueIsMissing)
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= 37.9963) AndAlso (CDec(value) <= 38.3837)) Then
                            row.Latitude = Math.Round(CDec(value), 5)
                        Else
                            Throw New ApplicationException(ColumnName.Latitude & " value needs to be >= 37.9963 And <= 38.3837.")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Latitude & ValidationMessages.ValueIsNotNumeric)
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(5))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Longitude) Then Throw New ApplicationException(ColumnName.Longitude & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Longitude & ValidationMessages.ValueIsMissing)
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= -85.9586) AndAlso (CDec(value) <= -85.4135)) Then
                            row.Longitude = Math.Round(CDec(value), 5)
                        Else
                            Throw New ApplicationException(ColumnName.Longitude & " value needs to be >= -85.9586 And <= -85.4135.")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Longitude & ValidationMessages.ValueIsNotNumeric)
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(6))
            If (rowNumber = 1) Then
                ''If (value <> ColumnName.Height) Then Throw New ApplicationException(ColumnName.Height & ValidationMessages.ColumnIsMissing)
                If (InStr(value, ColumnName.Height) = 0) Then Throw New ApplicationException(ColumnName.Height & ValidationMessages.ColumnIsMissing)

            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Height & ValidationMessages.ValueIsMissing)
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= 1) AndAlso (CDec(value) <= 1300)) Then
                            row.Height = CDec(value)
                        Else
                            Throw New ApplicationException(ColumnName.Height & " value needs to be >= 1 And <= 1300 ft.")
                        End If

                    Else
                        Throw New ApplicationException(ColumnName.Height & ValidationMessages.ValueIsNotNumeric)
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try


        '--- START special handling for diameter, length, and width ---
        If (rowNumber = 1) Then
            Try
                value = CStr(rowList(7))
                If (value <> ColumnName.Diameter) Then Throw New ApplicationException(ColumnName.Diameter & ValidationMessages.ColumnIsMissing)
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

            Try
                value = CStr(rowList(8))
                If (InStr(value, ColumnName.Length) = 0) Then Throw New ApplicationException(ColumnName.Length & ValidationMessages.ColumnIsMissing)
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

            Try
                value = CStr(rowList(9))
                If (InStr(value, ColumnName.Width) = 0) Then Throw New ApplicationException(ColumnName.Width & ValidationMessages.ColumnIsMissing)
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

        Else

            Dim diameter As String = CStr(rowList(7))
            Dim length As String = CStr(rowList(8))
            Dim width As String = CStr(rowList(9))

            If ((diameter.Length > 0) AndAlso ((length.Length = 0) AndAlso (width.Length = 0))) Then
                Try
                    If (IsNumeric(diameter)) Then
                        If ((CDec(diameter) >= 0.1) AndAlso (CDec(diameter) <= 100)) Then
                            row.Diameter = Math.Round(CDec(diameter), 2)
                        Else
                            Throw New ApplicationException(ColumnName.Diameter & " value needs to be >= 0.1 And <= 100 ft.")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Diameter & ValidationMessages.ValueIsNotNumeric)
                    End If
                Catch ex As Exception
                    Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                End Try

            ElseIf ((diameter.Length = 0) AndAlso ((length.Length > 0) AndAlso (width.Length > 0))) Then
                'Approved/confirmed by Matt King on 12/17/2012
                'To calculate Equivalent Diameter use method #1 from http://www.weblakes.com/Newsletter/2007/Nov2007.html
                'That is: 2 * (Sqrt((L * W)/π))


                If (IsNumeric(length) AndAlso IsNumeric(width)) Then
                    Try
                        Dim equivalentDiameter As Decimal = CDec(2 * (Math.Sqrt((CDec(length) * CDec(width)) / Math.PI)))
                        If ((equivalentDiameter >= 0.1) AndAlso (equivalentDiameter <= 100)) Then
                            row.Length = Math.Round(CDec(length), 2)
                            row.Width = Math.Round(CDec(width), 2)
                        Else
                            Throw New ApplicationException("Equivalent diameter conversion for length and width is out of range. Both values need to be >= 0.1 And <= 100 ft and their product must be at least 0.025.")
                        End If
                    Catch ex As Exception
                        Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                    End Try
                Else
                    Try
                        If (Not IsNumeric(length)) Then
                            Throw New ApplicationException(ColumnName.Length & ValidationMessages.ValueIsNotNumeric)
                        End If
                    Catch ex As Exception
                        Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                    End Try

                    Try
                        If (Not IsNumeric(width)) Then
                            Throw New ApplicationException(ColumnName.Width & ValidationMessages.ValueIsNotNumeric)
                        End If
                    Catch ex As Exception
                        Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                    End Try
                End If
            Else
                Call Me.AddErrorMessageDetailLine(errorMessage, "Values for Diameter, Length, and Width are invalid.")
            End If
        End If
        '--- END special handling for diameter, length, and width ---


        Try
            value = CStr(rowList(10))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ExhaustGasTemperature) Then Throw New ApplicationException(ColumnName.ExhaustGasTemperature & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.ExhaustGasTemperature & ValidationMessages.ValueIsMissing)
                Else
                    If (IsNumeric(value)) Then
                        If ((CInt(value) >= 30) AndAlso (CInt(value) <= 3500)) Then
                            row.ExitGasTemperature = CInt(value)
                        Else
                            Throw New ApplicationException(ColumnName.ExhaustGasTemperature & " value needs to be >= 30 And <= 3500 °F.")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.ExhaustGasTemperature & ValidationMessages.ValueIsNotNumeric)
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(11))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ExitGasFlowRate) Then Throw New ApplicationException(ColumnName.ExitGasFlowRate & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.ExitGasFlowRate & ValidationMessages.ValueIsMissing)
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= 0.1) AndAlso (CDec(value) <= 12000000)) Then
                            row.ExitGasFlowRate = Math.Round(CDec(value), 2)
                        Else
                            Throw New ApplicationException(ColumnName.ExitGasFlowRate & " value needs to be >= 0.1 And <= 12,000,000 ACFM.")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.ExitGasFlowRate & ValidationMessages.ValueIsNotNumeric)
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(12))
            If (rowNumber = 1) Then
                If (value <> ColumnName.DistanceFromFenceLine) Then Throw New ApplicationException(ColumnName.DistanceFromFenceLine & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    row.SetFencelineDistanceNull()
                Else

                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= 1) AndAlso (CDec(value) <= 10000)) Then
                            row.FencelineDistance = CDec(value)
                        Else
                            Throw New ApplicationException(ColumnName.DistanceFromFenceLine & " value needs to be >= 1 And <= 10000 ft.")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.DistanceFromFenceLine & ValidationMessages.ValueIsNotNumeric)
                    End If

                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(13))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Comment) Then Throw New ApplicationException(ColumnName.Comment & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    row.SetCompanyCommentNull()
                Else
                    If (CStr(value).Length > 255) Then
                        Throw New ApplicationException(ColumnName.Comment & ValidationMessages.MustBe255CharactersOrLess)
                    Else
                        row.CompanyComment = value
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        If ((errorMessage.Length = 0) AndAlso (rowNumber > 1)) Then
            row.PlantID = Me.m_plantID
            Try
                Me.ReleasePointDataSet.autoE91T_Stacks.Rows.Add(row)
            Catch ex As Exception
                If (InStr(ex.Message, "unique") > 0) Then
                    Call Me.AddErrorMessageDetailLine(errorMessage, "Duplicate release point: " _
                                                      & row.APCDID)
                Else
                    Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                End If
            End Try
        End If

        If (errorMessage.Length > 0) Then
            errorMessage.Insert(0, header)
            errorMessage.AppendLine()
            Throw New ApplicationException(errorMessage.ToString)
        End If

    End Sub

#End Region '----- E91T Workbook ----- Stack sheet -----

#Region "----- E91T Workbook ----- fugitive sheet -----"

    Private Sub CheckFugitivesSheet()

        Dim errorMessage As New StringBuilder
        Dim header As String = "------------------------- fugitives sheet -------------------------" & vbCrLf

        Dim rowNumber As Int32 = 1
        Dim row As ArrayList = Me.GetFugitiveRow(rowNumber)

        Do While Me.IsEndOfSheet(row) = False
            Try
                Call Me.CheckFugitivesSheetRow(rowNumber, row)
            Catch ex As Exception
                errorMessage.Append(ex.Message)
            End Try
            rowNumber += 1
            row = Me.GetFugitiveRow(rowNumber)
        Loop

        If (errorMessage.Length > 0) Then
            errorMessage.Insert(0, header)
            Me.m_mainErrorLog.Append(errorMessage.ToString)
        End If

    End Sub

    Private Function GetFugitiveRow(ByVal rowNumber As Int32) As ArrayList

        Dim row As New ArrayList

        Try
            Dim value As String
            For characterCode As Byte = 65 To 74
                Dim coordinates As String = Chr(characterCode) & rowNumber.ToString
                If (IsNothing(CType(Me.m_fugitivesSheet.Range(coordinates, coordinates), Excel.Range).Value)) Then
                    value = String.Empty
                Else
                    value = CStr(CType(Me.m_fugitivesSheet.Range(coordinates, coordinates), Excel.Range).Value).Trim & String.Empty
                End If
                row.Add(value)
            Next
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            Throw New ApplicationException("An error occurred reading a row from the fugitive release point worksheet.")
        End Try
        Return row

    End Function

    Private Sub CheckFugitivesSheetRow(ByVal rowNumber As Int32, ByVal rowList As ArrayList)
        Me.lblProgress.Text = "Running QA on 'Fugitives' row " & rowNumber.ToString

        Dim errorMessage As New StringBuilder
        Dim header As String = "Row " & rowNumber.ToString & vbCrLf
        Dim value As String
        Dim row As ReleasePointDataSet.autoE91T_FugitivesRow = Me.ReleasePointDataSet.autoE91T_Fugitives.NewautoE91T_FugitivesRow

        'Release Point Identifier (APCDID)
        Try
            value = CStr(rowList(0))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ReleasePointIdentifier) Then
                    Throw New ApplicationException(ColumnName.ReleasePointIdentifier & ValidationMessages.ColumnIsMissing)
                End If
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.ReleasePointIdentifier & ValidationMessages.ValueIsMissing)
                End If
                row.APCDID = value
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(1))
            If (rowNumber = 1) Then
                If (value <> ColumnName.FugitiveReleaseType) Then Throw New ApplicationException(ColumnName.FugitiveReleaseType & ValidationMessages.ColumnIsMissing)
            Else
                'THIS COLUMN IS NOT NECESSARY
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(2))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ReleasePointDescription) Then Throw New ApplicationException(ColumnName.ReleasePointDescription & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    row.SetReleasePointDescriptionNull()
                Else
                    row.ReleasePointDescription = value
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        row.ReleasePointTypeID = 1

        Try
            value = CStr(rowList(3))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Latitude) Then Throw New ApplicationException(ColumnName.Latitude & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Latitude & ValidationMessages.ValueIsMissing)
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= 37.9963) AndAlso (CDec(value) <= 38.3837)) Then
                            row.Latitude = Math.Round(CDec(value), 5)
                        Else
                            Throw New ApplicationException(ColumnName.Latitude & " value needs to be >= 37.9963 And <= 38.3837.")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Latitude & ValidationMessages.ValueIsNotNumeric)
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(4))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Longitude) Then Throw New ApplicationException(ColumnName.Longitude & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Longitude & ValidationMessages.ValueIsMissing)
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= -85.9586) AndAlso (CDec(value) <= -85.4135)) Then
                            row.Longitude = Math.Round(CDec(value), 5)
                        Else
                            Throw New ApplicationException(ColumnName.Longitude & " value needs to be >= -85.9586 And <= -85.4135.")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Longitude & ValidationMessages.ValueIsNotNumeric)
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(5))
            If (rowNumber = 1) Then
                If (InStr(value, ColumnName.Height) = 0) Then Throw New ApplicationException(ColumnName.Height & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Height & ValidationMessages.ValueIsMissing)
                Else
                    If (IsNumeric(value)) Then
                        Dim fugitiveHeight As Decimal = CDec(value)
                        If ((fugitiveHeight >= 0) AndAlso (fugitiveHeight <= 500)) Then
                            row.Height = Math.Round(fugitiveHeight, 2)
                        Else
                            Throw New ApplicationException(ColumnName.Height & " value needs to be >= 0 And <= 500 ft.")
                        End If

                    Else
                        Throw New ApplicationException(ColumnName.Height & ValidationMessages.ValueIsNotNumeric)
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try


        '-------------------------- start length/width special handling -------------------------------------------------------------------------------------

        'if either Length or Width is supplied then both have to be supplied
        Dim lengthValue As String = CStr(rowList(6))
        Dim widthValue As String = CStr(rowList(7))

        Try
            If (rowNumber = 1) Then
                If (InStr(lengthValue, ColumnName.Length) = 0) Then Throw New ApplicationException(ColumnName.Length & ValidationMessages.ColumnIsMissing)
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            If (rowNumber = 1) Then
                If (InStr(widthValue, ColumnName.Width) = 0) Then Throw New ApplicationException(ColumnName.Width & ValidationMessages.ColumnIsMissing)
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            If (rowNumber > 1) Then
                If ((lengthValue.Length > 0) AndAlso (widthValue.Length > 0)) Then

                    If (IsNumeric(lengthValue)) AndAlso (IsNumeric(widthValue)) Then

                        Dim fugitiveLength As Decimal = CDec(lengthValue)
                        Try
                            If ((fugitiveLength >= 1) AndAlso (fugitiveLength <= 10000)) Then
                                row.Length = Math.Round(fugitiveLength, 2)
                            Else
                                Throw New ApplicationException(ColumnName.Length & " value needs to be >= 1 And <= 10000 ft.")
                            End If
                        Catch ex As Exception
                            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                        End Try

                        Dim fugitiveWidth As Decimal = CDec(widthValue)
                        Try
                            If ((fugitiveWidth >= 1) AndAlso (fugitiveWidth <= 10000)) Then
                                row.Width = Math.Round(fugitiveWidth, 2)
                            Else
                                Throw New ApplicationException(ColumnName.Width & " value needs to be >= 1 And <= 10000 ft.")
                            End If
                        Catch ex As Exception
                            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                        End Try
                    Else
                        Throw New ApplicationException("Both length and width values need to be >= 1 And <= 10000 ft.")
                    End If

                Else

                    If ((lengthValue.Length > 0) AndAlso (widthValue.Length = 0)) Then
                        Throw New ApplicationException(ColumnName.Width & ValidationMessages.ValueIsMissing)
                    ElseIf ((lengthValue.Length = 0) AndAlso (widthValue.Length > 0)) Then
                        Throw New ApplicationException(ColumnName.Length & ValidationMessages.ValueIsMissing)
                    End If

                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try
        '-------------------------- end length/width special handling ---------------------------------------------------------------------------------------

        Try
            value = CStr(rowList(8))
            If (rowNumber = 1) Then
                If (InStr(value, ColumnName.Angle) = 0) Then Throw New ApplicationException(ColumnName.Angle & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    'do nothing
                Else
                    If (IsNumeric(value)) Then
                        If ((CInt(value) >= 0) AndAlso (CInt(value) <= 179)) Then
                            row.HorizontalAngle = CInt(value)
                        Else
                            Throw New ApplicationException(ColumnName.Angle & " value needs to be >= 0° And <= 179°.")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Angle & ValidationMessages.ValueIsNotNumeric)
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(9))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Comment) Then Throw New ApplicationException(ColumnName.Comment & ValidationMessages.ColumnIsMissing)
            Else
                If (value = String.Empty) Then
                    row.SetCompanyCommentNull()
                Else
                    If (CStr(value).Length > 255) Then
                        Throw New ApplicationException(ColumnName.Comment & ValidationMessages.MustBe255CharactersOrLess)
                    Else
                        row.CompanyComment = value
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        If ((errorMessage.Length = 0) AndAlso (rowNumber > 1)) Then
            row.PlantID = Me.m_plantID
            Try
                Me.ReleasePointDataSet.autoE91T_Fugitives.Rows.Add(row)
            Catch ex As Exception
                If (InStr(ex.Message, "unique") > 0) Then
                    Call Me.AddErrorMessageDetailLine(errorMessage, "Duplicate release point: " _
                                                      & row.APCDID)
                Else
                    Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                End If
            End Try
        End If

        If (errorMessage.Length > 0) Then
            errorMessage.Insert(0, header)
            errorMessage.AppendLine()
            Throw New ApplicationException(errorMessage.ToString)
        End If

    End Sub


#End Region '----- E91T Workbook ----- fugitive sheet -----

#End Region '----- E91T Workbook -----

#Region "----- utils -----"

    Private Function IsEndOfSheet(ByVal row As ArrayList) As Boolean

        Dim returnValue As Boolean = True
        For valueCount As Int32 = 0 To row.Count - 1
            If (CStr(row(valueCount)) <> String.Empty) Then
                returnValue = False
                Exit For
            End If
        Next
        Return returnValue

    End Function

    Private Sub AddErrorMessageDetailLine(ByVal message As StringBuilder, ByVal textToAdd As String)
        message.Append(vbTab)
        message.AppendLine(textToAdd)
    End Sub

#End Region '----- utils -----

#Region "----- import methods -----"

    Private Sub ImportTheData()

        Me.btnCancel.Enabled = False
        Call Me.SetTheProgressBar()
        Call Me.ReconcileStacks()
        Call Me.ReconcileFugitives()
        Call Me.WriteImportReportToFile()
        Me.ProgressBar1.Visible = False

    End Sub

    Private Sub SetTheProgressBar()
        With Me.ProgressBar1
            .Minimum = 0
            .Maximum = Me.ReleasePointDataSet.autoE91T_Stacks.Rows.Count _
                       + Me.ReleasePointDataSet.autoE91T_Fugitives.Rows.Count
            .Visible = True
        End With
    End Sub

#Region "----- import methods ----- stacks -----"

    ''' <summary>
    ''' Compare stacks in the spreadsheet with those already in the database for the plant.
    ''' </summary>
    ''' <remarks>
    ''' 2013-10-24 BJF:  Added Try block for update case.
    ''' </remarks>
    Private Sub ReconcileStacks()
        Dim addedRowsMessage As New StringBuilder
        Dim addedRowCount As Int32 = 0
        Dim modifiedRowsMessage As New StringBuilder
        Dim modifiedRowCount As Int32 = 0

        Dim releasePoint As ReleasePointDataSet.ReleasePointRow = Nothing

        For Each stack As ReleasePointDataSet.autoE91T_StacksRow In Me.ReleasePointDataSet.autoE91T_Stacks
            Me.lblProgress.Text = "Processing stack: " & stack.APCDID
            Me.ProgressBar1.Value += 1

            Me.ReleasePointTableAdapter.FillByPlantID_APCDID(Me.ReleasePointDataSet.ReleasePoint, _
                                                             stack.PlantID, stack.APCDID)
            If (Me.ReleasePointDataSet.ReleasePoint.Rows.Count = 0) Then
                releasePoint = Me.ReleasePointDataSet.ReleasePoint.NewReleasePointRow
                With releasePoint
                    .PlantID = stack.PlantID

                    If (stack.IsReleasePointDescriptionNull) Then
                        .SetReleasePointDescriptionNull()
                    Else
                        .ReleasePointDescription = stack.ReleasePointDescription
                    End If

                    .XCoordinate = stack.Longitude
                    .YCoordinate = stack.Latitude

                    If (stack.IsDiameterNull) Then
                        .ReleaseTypeSubTypeID = CInt(ReleasePointHelper.ReleaseTypeSubType.Other)
                    Else
                        .ReleaseTypeSubTypeID = CInt(ReleasePointHelper.ReleaseTypeSubType.Round)
                    End If

                    .ReleasePointTypeID = stack.ReleasePointTypeID
                    .ReleasePointAPCDID = stack.APCDID
                    .ReleasePointEISID = GlobalMethods.GenerateTempEISID
                    Do While .ReleasePointEISID = GlobalMethods.GenerateTempEISID
                        'nothing
                    Loop

                    .BeginDate = New Date(Date.Now.Year - 1, 1, 1)

                    If (stack.IsCompanyCommentNull) Then
                        .SetCompanyCommentNull()
                    Else
                        .CompanyComment = stack.CompanyComment
                    End If

                    .AddDate = Date.Now
                    .AddedBy = GlobalVariables.Employee.EmployeeID
                End With
                Me.ReleasePointDataSet.ReleasePoint.Rows.Add(releasePoint)

                'save it
                Try
                    Me.ReleasePointBindingSource.EndEdit()
                    Me.ReleasePointTableAdapter.Connection.Open()
                    Me.ReleasePointTableAdapter.Update(Me.ReleasePointDataSet.ReleasePoint)

                    Dim cmd As New OleDb.OleDbCommand("SELECT @@IDENTITY", Me.ReleasePointTableAdapter.Connection)
                    Dim releasePointID As Int32 = CInt(cmd.ExecuteScalar)

                    Call ReleasePointHelper.CreateReleasePointYearRecord(releasePointID, Me.m_emissionYear, Me.ReleasePointDataSet.ReleasePointYear, _
                                                                         Me.ReleasePointYearTableAdapter)

                    Call Me.ReconcileStacks_AddDetails(stack, releasePointID)

                    addedRowsMessage.AppendLine(releasePoint.ReleasePointAPCDID)
                    addedRowCount += 1
                Catch ex As Exception
                    GlobalMethods.HandleError(ex)
                    addedRowsMessage.AppendLine("An error occured saving release point: " & releasePoint.ReleasePointAPCDID)
                Finally
                    If (Me.ReleasePointTableAdapter.Connection.State = ConnectionState.Open) Then Me.ReleasePointTableAdapter.Connection.Close()
                End Try

            Else

                Dim updateNotes As New StringBuilder

                Try
                    'header
                    releasePoint = CType(Me.ReleasePointDataSet.ReleasePoint.Rows(0), EmissionsInventory.ReleasePointDataSet.ReleasePointRow)
                    If (releasePoint.IsEndDateNull) Then
                        Call Me.CompareStacks(releasePoint, stack, updateNotes)


                        'measurements
                        Me.ReleasePointDetailTableAdapter.FillByReleasePointID(Me.ReleasePointDataSet.ReleasePointDetail, releasePoint.ReleasePointID)
                        Call Me.CompareStackDetails(stack, releasePoint.ReleasePointID, releasePoint.ReleasePointAPCDID, updateNotes)

                        If (updateNotes.Length > 0) Then
                            modifiedRowsMessage.AppendLine(updateNotes.ToString)
                            modifiedRowCount += 1
                        End If

                        'save
                        'Me.ReleasePointBindingSource.EndEdit()
                        'Me.ReleasePointHistoryBindingSource.EndEdit()
                        'Me.ReleasePointDetailBindingSource.EndEdit()
                        'Me.ReleasePointDetailHistoryBindingSource.EndEdit()

                        Me.ReleasePointTableAdapter.Update(Me.ReleasePointDataSet.ReleasePoint)
                        Me.ReleasePointHistoryTableAdapter.Update(Me.ReleasePointDataSet.ReleasePointHistory)
                        Me.ReleasePointDetailTableAdapter.Update(Me.ReleasePointDataSet.ReleasePointDetail)
                        Me.ReleasePointDetailHistoryTableAdapter.Update(Me.ReleasePointDataSet.ReleasePointDetailHistory)

                        ''Me.TableAdapterManager.UpdateAll(Me.ReleasePointDataSet)

                    Else
                        'the RP is shut down
                        With updateNotes
                            .Append("WARNING! Release point ")
                            .Append(Tools.Constants.Character.DoubleQuote)
                            .Append(releasePoint.ReleasePointAPCDID)
                            .Append(Tools.Constants.Character.DoubleQuote)
                            .AppendLine(" is shut down and may not be updated.")
                            modifiedRowsMessage.AppendLine(updateNotes.ToString)
                        End With
                    End If
                Catch ex As Exception
                    GlobalMethods.HandleError(ex)
                    addedRowsMessage.AppendLine("An error occured updating release point: " & releasePoint.ReleasePointAPCDID)
                Finally
                    If (Me.ReleasePointTableAdapter.Connection.State = ConnectionState.Open) Then Me.ReleasePointTableAdapter.Connection.Close()
                End Try


            End If

        Next

        Call Me.WriteImportReportBody(addedRowsMessage, addedRowCount, modifiedRowsMessage, modifiedRowCount, SheetNameEnum.Stacks)

    End Sub

    Private Sub CompareStacks(ByVal originalRow As ReleasePointDataSet.ReleasePointRow, ByVal stackRow As ReleasePointDataSet.autoE91T_StacksRow, ByVal updateNotes As StringBuilder)

        Dim releasePointHistory As ReleasePointDataSet.ReleasePointHistoryRow = Me.CreateHistoryRow(originalRow)

        With originalRow
            If (.ReleasePointDescription <> stackRow.ReleasePointDescription) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.ReleasePointDescription, .ReleasePointDescription, stackRow.ReleasePointDescription, updateNotes)
                .ReleasePointDescription = stackRow.ReleasePointDescription
            End If

            If (.XCoordinate <> stackRow.Longitude) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.XCoordinate, CStr(.XCoordinate), CStr(stackRow.Longitude), updateNotes)
                .XCoordinate = stackRow.Longitude
            End If

            If (.YCoordinate <> stackRow.Latitude) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.YCoordinate, CStr(.YCoordinate), CStr(stackRow.Latitude), updateNotes)
                .YCoordinate = stackRow.Latitude
            End If

            If ((.ReleaseTypeSubTypeID = ReleasePointHelper.ReleaseTypeSubType.Round) AndAlso (stackRow.IsDiameterNull)) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.ReleaseTypeSubTypeID, CStr(ReleasePointHelper.ReleaseTypeSubType.Round), CStr(ReleasePointHelper.ReleaseTypeSubType.Other), updateNotes)
                .ReleaseTypeSubTypeID = ReleasePointHelper.ReleaseTypeSubType.Other
            ElseIf ((.ReleaseTypeSubTypeID = ReleasePointHelper.ReleaseTypeSubType.Other) AndAlso (Not stackRow.IsDiameterNull)) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.ReleaseTypeSubTypeID, CStr(ReleasePointHelper.ReleaseTypeSubType.Other), CStr(ReleasePointHelper.ReleaseTypeSubType.Round), updateNotes)
                .ReleaseTypeSubTypeID = ReleasePointHelper.ReleaseTypeSubType.Round
            End If

            If (.ReleasePointTypeID <> stackRow.ReleasePointTypeID) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.ReleasePointTypeID, CStr(.ReleasePointTypeID), CStr(stackRow.ReleasePointTypeID), updateNotes)
                .ReleasePointTypeID = stackRow.ReleasePointTypeID
            End If

            If (.CompanyComment <> stackRow.CompanyComment) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.CompanyComment, .CompanyComment, stackRow.CompanyComment, updateNotes)
                .CompanyComment = stackRow.CompanyComment
            End If
        End With

        If (updateNotes.Length > 0) Then
            updateNotes.Insert(0, originalRow.ReleasePointAPCDID)
            Me.ReleasePointDataSet.ReleasePointHistory.Rows.Add(releasePointHistory)
        End If

    End Sub

    Private Sub ReconcileStacks_AddDetails(ByVal stack As ReleasePointDataSet.autoE91T_StacksRow, ByVal releasePointID As Int32)

        Me.ReleasePointDataSet.ReleasePointDetail.Clear()

        'height
        Dim heightRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
        With heightRow
            .ReleasePointID = releasePointID
            .MeasurementID = ReleasePointHelper.MeasurementEnum.Height
            .DetailValue = Math.Round(stack.Height, 2)
            .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Height)
        End With
        Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(heightRow)

        'diameter
        If (Not stack.IsDiameterNull) Then
            Dim diameterRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
            With diameterRow
                .ReleasePointID = releasePointID
                .MeasurementID = ReleasePointHelper.MeasurementEnum.Diameter
                .DetailValue = Math.Round(stack.Diameter, 2)
                .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Diameter)
            End With
            Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(diameterRow)
        End If

        'length
        If (Not stack.IsLengthNull) Then
            Dim lengthRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
            With lengthRow
                .ReleasePointID = releasePointID
                .MeasurementID = ReleasePointHelper.MeasurementEnum.Length
                .DetailValue = Math.Round(stack.Length, 2)
                .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Length)
            End With
            Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(lengthRow)
        End If

        'width
        If (Not stack.IsWidthNull) Then
            Dim widthRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
            With widthRow
                .ReleasePointID = releasePointID
                .MeasurementID = ReleasePointHelper.MeasurementEnum.Width
                .DetailValue = Math.Round(stack.Width, 2)
                .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Width)
            End With
            Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(widthRow)
        End If

        'exit gas temperature
        Dim exitGasTemperatureRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
        With exitGasTemperatureRow
            .ReleasePointID = releasePointID
            .MeasurementID = ReleasePointHelper.MeasurementEnum.ExitGasTemperature
            .DetailValue = Math.Round(stack.ExitGasTemperature, 2)
            .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.ExitGasTemperature)
        End With
        Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(exitGasTemperatureRow)

        'ExitGasFlowRate
        Dim exitGasFlowRateRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
        With exitGasFlowRateRow
            .ReleasePointID = releasePointID
            .MeasurementID = ReleasePointHelper.MeasurementEnum.ExitGasFlowRate
            .DetailValue = Math.Round(stack.ExitGasFlowRate, 2)
            .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.ExitGasFlowRate)
        End With
        Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(exitGasFlowRateRow)

        'fenceline distance
        If (Not stack.IsFencelineDistanceNull) Then
            Dim fencelineDistanceRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
            With fencelineDistanceRow
                .ReleasePointID = releasePointID
                .MeasurementID = ReleasePointHelper.MeasurementEnum.FencelineDistance
                .DetailValue = Math.Round(stack.FencelineDistance, 2)
                .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.FencelineDistance)
            End With
            Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(fencelineDistanceRow)
        End If

        Try
            Me.ReleasePointDetailTableAdapter.Update(Me.ReleasePointDataSet.ReleasePointDetail)
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            ' An error occurred updating release point measurements.
        End Try

    End Sub

    ''' <summary>
    ''' Compare stack details (height, diameter, exit gas flow rate, etc.) of
    ''' imported row with the existing release point.
    ''' </summary>
    ''' <param name="stack">AutoE91T_Stacks row</param>
    ''' <param name="releasePointID">ReleasePoint ID</param>
    ''' <param name="APCDID">ReleasePointAPCDID</param>
    ''' <param name="updateNotes">Update notes: A list of changes will be appended</param>
    ''' <remarks>
    ''' 2013-10-14 BJF:  Filled in missing "if row count is zero" cases
    '''                  for exit gas temperature and exit gas flow rate.
    '''                  Also changed updateNotes parameter to ByRef,
    '''                  so the appended notes are passed back.
    ''' </remarks>
    Private Sub CompareStackDetails(ByVal stack As ReleasePointDataSet.autoE91T_StacksRow, ByVal releasePointID As Int32, ByVal APCDID As String, ByRef updateNotes As StringBuilder)

        Dim detailNotes As New StringBuilder
        Dim measurementIDColumn As String = ReleasePointDataSet.ReleasePointDetail.MeasurementIDColumn.ColumnName
        Dim selectCriteria As String
        Dim detailRows() As ReleasePointDataSet.ReleasePointDetailRow

        '--- height ---
        selectCriteria = measurementIDColumn & "=" & CStr(ReleasePointHelper.MeasurementEnum.Height)
        detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
        If detailRows.Count = 0 Then
            ' Error in the database!  Each release point must have a height.
            ' Let it go; we will add it now.
            Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Height, "(missing!)", CStr(Math.Round(stack.Height, 2)), detailNotes)
            detailRows(0).DetailValue = Math.Round(stack.Height, 2)
        Else
            If (detailRows(0).DetailValue <> Math.Round(stack.Height, 2)) Then
                Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
                Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Height, CStr(detailRows(0).DetailValue), CStr(Math.Round(stack.Height, 2)), detailNotes)
                detailRows(0).DetailValue = Math.Round(stack.Height, 2)
            End If
        End If

        '--- diameter, length, width ---
        If ((Not stack.IsDiameterNull) AndAlso (stack.IsLengthNull AndAlso stack.IsWidthNull)) Then
            selectCriteria = measurementIDColumn & "=" & CStr(ReleasePointHelper.MeasurementEnum.Diameter)
            detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
            If (detailRows.Count = 0) Then
                'add the diameter
                Dim diameterRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
                With diameterRow
                    .ReleasePointID = releasePointID
                    .MeasurementID = ReleasePointHelper.MeasurementEnum.Diameter
                    .DetailValue = Math.Round(stack.Diameter, 2)
                    .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Diameter)
                End With
                Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(diameterRow)

                'delete length if exists
                selectCriteria = measurementIDColumn & "=" & CStr(ReleasePointHelper.MeasurementEnum.Length)
                detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
                If (detailRows.Count = 1) Then
                    detailRows(0).Delete()
                End If

                'delete width if exists
                selectCriteria = measurementIDColumn & "=" & CStr(ReleasePointHelper.MeasurementEnum.Width)
                detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
                If (detailRows.Count = 1) Then
                    detailRows(0).Delete()
                End If
            Else
                If (detailRows(0).DetailValue <> Math.Round(stack.Diameter, 2)) Then
                    Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
                    Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Diameter, CStr(detailRows(0).DetailValue), CStr(Math.Round(stack.Diameter, 2)), detailNotes)
                    detailRows(0).DetailValue = Math.Round(stack.Diameter, 2)
                End If

            End If

        ElseIf ((stack.IsDiameterNull) AndAlso (Not stack.IsLengthNull AndAlso Not stack.IsWidthNull)) Then
            'delete diameter if exists
            selectCriteria = measurementIDColumn & "=" & CStr(ReleasePointHelper.MeasurementEnum.Diameter)
            detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
            If (detailRows.Count = 1) Then
                detailRows(0).Delete()
            End If

            'length
            selectCriteria = measurementIDColumn & "=" & CStr(ReleasePointHelper.MeasurementEnum.Length)
            detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
            If (detailRows.Count = 0) Then
                Dim lengthRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
                With lengthRow
                    .ReleasePointID = releasePointID
                    .MeasurementID = ReleasePointHelper.MeasurementEnum.Length
                    .DetailValue = Math.Round(stack.Length, 2)
                    .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Length)
                End With
                Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(lengthRow)
            Else
                If (detailRows(0).DetailValue <> Math.Round(stack.Length, 2)) Then
                    Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
                    Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Length, CStr(detailRows(0).DetailValue), CStr(Math.Round(stack.Length, 2)), detailNotes)

                    detailRows(0).DetailValue = Math.Round(stack.Length, 2)
                End If
            End If

            'width
            selectCriteria = measurementIDColumn & "=" & CStr(ReleasePointHelper.MeasurementEnum.Width)
            detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
            If (detailRows.Count = 0) Then
                Dim widthRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
                With widthRow
                    .ReleasePointID = releasePointID
                    .MeasurementID = ReleasePointHelper.MeasurementEnum.Width
                    .DetailValue = Math.Round(stack.Width, 2)
                    .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Width)
                End With
                Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(widthRow)
            Else
                If (detailRows(0).DetailValue <> Math.Round(stack.Width, 2)) Then
                    Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
                    Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Width, CStr(detailRows(0).DetailValue), CStr(Math.Round(stack.Width, 2)), detailNotes)

                    detailRows(0).DetailValue = Math.Round(stack.Width, 2)
                End If
            End If

        End If

        '--- exit gas temperature ---
        selectCriteria = measurementIDColumn & "=" & CStr(ReleasePointHelper.MeasurementEnum.ExitGasTemperature)
        detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
        If (detailRows.Count = 0) Then
            Dim gasTempRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
            With gasTempRow
                .ReleasePointID = releasePointID
                .MeasurementID = ReleasePointHelper.MeasurementEnum.ExitGasTemperature
                .DetailValue = Math.Round(stack.ExitGasTemperature, 2)
                .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.ExitGasTemperature)
            End With
            Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(gasTempRow)
        Else
            If (detailRows(0).DetailValue <> stack.ExitGasTemperature) Then
                Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
                Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.ExitGasTemperature, CStr(detailRows(0).DetailValue), CStr(stack.ExitGasTemperature), detailNotes)

                detailRows(0).DetailValue = stack.ExitGasTemperature
            End If
        End If

        '--- ExitGasFlowRate ---
        selectCriteria = measurementIDColumn & "=" & CStr(ReleasePointHelper.MeasurementEnum.ExitGasFlowRate)
        detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
        If (detailRows.Count = 0) Then
            Dim flowRateRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
            With flowRateRow
                .ReleasePointID = releasePointID
                .MeasurementID = ReleasePointHelper.MeasurementEnum.ExitGasFlowRate
                .DetailValue = Math.Round(stack.ExitGasFlowRate, 2)
                .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.ExitGasFlowRate)
            End With
            Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(flowRateRow)
        Else
            If (detailRows(0).DetailValue <> Math.Round(stack.ExitGasFlowRate, 2)) Then
                Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
                Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.ExitGasFlowRate, CStr(detailRows(0).DetailValue), CStr(Math.Round(stack.ExitGasFlowRate, 2)), detailNotes)

                detailRows(0).DetailValue = Math.Round(stack.ExitGasFlowRate, 2)
            End If
        End If

        '--- fenceline distance --- 
        If (Not stack.IsFencelineDistanceNull) Then
            selectCriteria = measurementIDColumn & "=" & CStr(ReleasePointHelper.MeasurementEnum.FencelineDistance)
            detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
            If (detailRows.Count = 0) Then
                'add fenceline distance
                Dim fencelineDistanceRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
                With fencelineDistanceRow
                    .ReleasePointID = releasePointID
                    .MeasurementID = ReleasePointHelper.MeasurementEnum.FencelineDistance
                    .DetailValue = Math.Round(stack.FencelineDistance, 2)
                    .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.FencelineDistance)
                End With
                Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(fencelineDistanceRow)
            Else
                If (detailRows(0).DetailValue <> Math.Round(stack.FencelineDistance, 2)) Then
                    Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
                    Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.FencelineDistance, CStr(detailRows(0).DetailValue), CStr(Math.Round(stack.FencelineDistance, 2)), detailNotes)

                    detailRows(0).DetailValue = Math.Round(stack.FencelineDistance, 2)
                End If
            End If
        End If

        If (detailNotes.Length > 0) Then
            If (updateNotes.Length = 0) Then
                detailNotes.Insert(0, APCDID)
            End If
            updateNotes.Append(detailNotes.ToString)
        End If

    End Sub

#End Region '----- import methods ----- stacks -----

#Region "----- import methods ----- fugitives -----"

    Private Sub ReconcileFugitives()

        Dim addedRows As New StringBuilder
        Dim addedRowCount As Int32 = 0
        Dim modifiedRows As New StringBuilder
        Dim modifiedRowCount As Int32 = 0

        Dim releasePoint As ReleasePointDataSet.ReleasePointRow
        For Each fugitive As ReleasePointDataSet.autoE91T_FugitivesRow In Me.ReleasePointDataSet.autoE91T_Fugitives
            Me.lblProgress.Text = "Processing fugitive: " & fugitive.APCDID
            Me.ProgressBar1.Value += 1

            Me.ReleasePointTableAdapter.FillByPlantID_APCDID(Me.ReleasePointDataSet.ReleasePoint, fugitive.PlantID, fugitive.APCDID)
            If (Me.ReleasePointDataSet.ReleasePoint.Rows.Count = 0) Then
                releasePoint = Me.ReleasePointDataSet.ReleasePoint.NewReleasePointRow
                With releasePoint
                    .PlantID = fugitive.PlantID

                    If (fugitive.IsReleasePointDescriptionNull) Then
                        .SetReleasePointDescriptionNull()
                    Else
                        .ReleasePointDescription = fugitive.ReleasePointDescription
                    End If

                    .XCoordinate = fugitive.Longitude
                    .YCoordinate = fugitive.Latitude

                    If (fugitive.IsLengthNull AndAlso fugitive.IsWidthNull) Then
                        .ReleaseTypeSubTypeID = CInt(ReleasePointHelper.ReleaseTypeSubType.Point)
                    Else
                        .ReleaseTypeSubTypeID = CInt(ReleasePointHelper.ReleaseTypeSubType.Area)
                    End If

                    .ReleasePointTypeID = fugitive.ReleasePointTypeID
                    .ReleasePointAPCDID = fugitive.APCDID
                    .ReleasePointEISID = GlobalMethods.GenerateTempEISID
                    Do While .ReleasePointEISID = GlobalMethods.GenerateTempEISID
                        'nothing
                    Loop

                    .BeginDate = New Date(Date.Now.Year - 1, 1, 1)

                    If (fugitive.IsCompanyCommentNull) Then
                        .SetCompanyCommentNull()
                    Else
                        .CompanyComment = fugitive.CompanyComment
                    End If

                    .AddDate = Date.Now
                    .AddedBy = GlobalVariables.Employee.EmployeeID
                End With
                Me.ReleasePointDataSet.ReleasePoint.Rows.Add(releasePoint)

                'save it
                Try
                    Me.ReleasePointBindingSource.EndEdit()
                    Me.ReleasePointTableAdapter.Connection.Open()
                    Me.ReleasePointTableAdapter.Update(Me.ReleasePointDataSet.ReleasePoint)
                    Dim cmd As New OleDb.OleDbCommand("SELECT @@IDENTITY", Me.ReleasePointTableAdapter.Connection)
                    Dim releasePointID As Int32 = CInt(cmd.ExecuteScalar)

                    Call ReleasePointHelper.CreateReleasePointYearRecord(releasePointID, Me.m_emissionYear, Me.ReleasePointDataSet.ReleasePointYear, Me.ReleasePointYearTableAdapter)

                    Call Me.ReconcileFugitives_AddDetails(fugitive, releasePointID)

                    addedRows.AppendLine(releasePoint.ReleasePointAPCDID)
                    addedRowCount += 1
                Catch ex As Exception
                    GlobalMethods.HandleError(ex)
                    addedRows.AppendLine("An error occured saving RP: " & releasePoint.ReleasePointAPCDID)
                Finally
                    If (Me.ReleasePointTableAdapter.Connection.State = ConnectionState.Open) Then Me.ReleasePointTableAdapter.Connection.Close()
                End Try
            Else
                Dim updateNotes As New StringBuilder

                'header
                releasePoint = CType(Me.ReleasePointDataSet.ReleasePoint.Rows(0), EmissionsInventory.ReleasePointDataSet.ReleasePointRow)
                Call Me.CompareFugitives(releasePoint, fugitive, updateNotes)

                'measurements
                Me.ReleasePointDetailTableAdapter.FillByReleasePointID(Me.ReleasePointDataSet.ReleasePointDetail, releasePoint.ReleasePointID)
                Call Me.CompareFugitiveDetails(fugitive, releasePoint.ReleasePointID, releasePoint.ReleasePointAPCDID, updateNotes)
                If (updateNotes.Length > 0) Then
                    modifiedRows.AppendLine(updateNotes.ToString)
                    modifiedRowCount += 1
                End If
            End If

            'save it
            Me.ReleasePointBindingSource.EndEdit()
            Me.ReleasePointHistoryBindingSource.EndEdit()
            Me.ReleasePointTableAdapter.Update(Me.ReleasePointDataSet.ReleasePoint)
            Me.ReleasePointHistoryTableAdapter.Update(Me.ReleasePointDataSet.ReleasePointHistory)

            Me.ReleasePointTableAdapter.Update(Me.ReleasePointDataSet.ReleasePoint)
            Me.ReleasePointHistoryTableAdapter.Update(Me.ReleasePointDataSet.ReleasePointHistory)
            Me.ReleasePointDetailTableAdapter.Update(Me.ReleasePointDataSet.ReleasePointDetail)
            Me.ReleasePointDetailHistoryTableAdapter.Update(Me.ReleasePointDataSet.ReleasePointDetailHistory)
        Next

        Call Me.WriteImportReportBody(addedRows, addedRowCount, modifiedRows, modifiedRowCount, SheetNameEnum.Fugitives)

    End Sub

    Private Sub ReconcileFugitives_AddDetails(ByVal fugitive As ReleasePointDataSet.autoE91T_FugitivesRow, ByVal releasePointID As Int32)

        Me.ReleasePointDataSet.ReleasePointDetail.Clear()

        'height
        Dim heightRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
        With heightRow
            .ReleasePointID = releasePointID
            .MeasurementID = ReleasePointHelper.MeasurementEnum.Height
            .DetailValue = fugitive.Height
            .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Height)
        End With
        Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(heightRow)

        'length
        If (Not fugitive.IsLengthNull) Then
            Dim lengthRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
            With lengthRow
                .ReleasePointID = releasePointID
                .MeasurementID = ReleasePointHelper.MeasurementEnum.Length
                .DetailValue = fugitive.Length
                .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Length)
            End With
            Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(lengthRow)
        End If

        'width
        If (Not fugitive.IsWidthNull) Then
            Dim widthRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
            With widthRow
                .ReleasePointID = releasePointID
                .MeasurementID = ReleasePointHelper.MeasurementEnum.Width
                .DetailValue = fugitive.Width
                .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Width)
            End With
            Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(widthRow)
        End If

        'horizontal angle
        If (Not fugitive.IsHorizontalAngleNull) Then
            Dim horizontalAngleRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
            With horizontalAngleRow
                .ReleasePointID = releasePointID
                .MeasurementID = ReleasePointHelper.MeasurementEnum.HorizontalAngle
                .DetailValue = CDec(fugitive.HorizontalAngle)
                .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.HorizontalAngle)
            End With
            Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(horizontalAngleRow)
        End If

        Me.ReleasePointDetailTableAdapter.Update(Me.ReleasePointDataSet.ReleasePointDetail)

    End Sub

    Private Sub CompareFugitives(ByVal originalRow As ReleasePointDataSet.ReleasePointRow, ByVal fugitiveRow As ReleasePointDataSet.autoE91T_FugitivesRow, ByVal updateNotes As StringBuilder)

        Dim releasePointHistory As ReleasePointDataSet.ReleasePointHistoryRow = Me.CreateHistoryRow(originalRow)

        With originalRow
            If (.ReleasePointDescription <> fugitiveRow.ReleasePointDescription) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.ReleasePointDescription, .ReleasePointDescription, fugitiveRow.ReleasePointDescription, updateNotes)
                .ReleasePointDescription = fugitiveRow.ReleasePointDescription
            End If

            If (.XCoordinate <> fugitiveRow.Longitude) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.XCoordinate, CStr(.XCoordinate), CStr(fugitiveRow.Longitude), updateNotes)
                .XCoordinate = fugitiveRow.Longitude
            End If

            If (.YCoordinate <> fugitiveRow.Latitude) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.YCoordinate, CStr(.YCoordinate), CStr(fugitiveRow.Latitude), updateNotes)
                .YCoordinate = fugitiveRow.Latitude
            End If

            If ((.ReleaseTypeSubTypeID = ReleasePointHelper.ReleaseTypeSubType.Point) AndAlso (Not fugitiveRow.IsLengthNull AndAlso Not fugitiveRow.IsWidthNull)) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.ReleaseTypeSubTypeID, CStr(ReleasePointHelper.ReleaseTypeSubType.Point), CStr(ReleasePointHelper.ReleaseTypeSubType.Area), updateNotes)
                .ReleaseTypeSubTypeID = ReleasePointHelper.ReleaseTypeSubType.Area

            ElseIf ((.ReleaseTypeSubTypeID = ReleasePointHelper.ReleaseTypeSubType.Area) AndAlso (fugitiveRow.IsLengthNull AndAlso fugitiveRow.IsWidthNull)) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.ReleaseTypeSubTypeID, CStr(ReleasePointHelper.ReleaseTypeSubType.Area), CStr(ReleasePointHelper.ReleaseTypeSubType.Point), updateNotes)
                .ReleaseTypeSubTypeID = ReleasePointHelper.ReleaseTypeSubType.Point
            End If

            If (.ReleasePointTypeID <> fugitiveRow.ReleasePointTypeID) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.ReleasePointTypeID, CStr(.ReleasePointTypeID), CStr(fugitiveRow.ReleasePointTypeID), updateNotes)
                .ReleasePointTypeID = fugitiveRow.ReleasePointTypeID
            End If

            If (.CompanyComment <> fugitiveRow.CompanyComment) Then
                Call Me.WriteHeaderChangeNote(ReleasePointHelper.ColumnEnum.CompanyComment, .CompanyComment, fugitiveRow.CompanyComment, updateNotes)
                .CompanyComment = fugitiveRow.CompanyComment
            End If
        End With

        If (updateNotes.Length > 0) Then
            updateNotes.Insert(0, originalRow.ReleasePointAPCDID)
            Me.ReleasePointDataSet.ReleasePointHistory.Rows.Add(releasePointHistory)
        End If

    End Sub

    ''' <summary>
    ''' Compare fugitive release point details (height, etc.) with those of the existing RP
    ''' </summary>
    ''' <param name="fugitive">AutoE91T_Fugitive row</param>
    ''' <param name="releasePointID">ReleasePointID</param>
    ''' <param name="APCDID">ReleasePointAPCDID</param>
    ''' <param name="updateNotes">Update notes: any changes will be appended</param>
    ''' <remarks>
    ''' 2013-10-14 BJF:  Added adding of horizontal angle if supplied in spreadsheet
    '''                  but missing in DB.
    '''                  Also changed updateNotes parameter to ByRef, 
    '''                  so appended notes are passed back.
    ''' </remarks>
    Private Sub CompareFugitiveDetails(ByVal fugitive As ReleasePointDataSet.autoE91T_FugitivesRow, ByVal releasePointID As Int32, ByVal APCDID As String, ByRef updateNotes As StringBuilder)

        Dim detailNotes As New StringBuilder
        Dim measurementIDColumnName As String = ReleasePointDataSet.ReleasePointDetail.MeasurementIDColumn.ColumnName
        Dim selectCriteria As String
        Dim detailRows() As ReleasePointDataSet.ReleasePointDetailRow

        '--- height ---
        selectCriteria = measurementIDColumnName & "=" & CStr(ReleasePointHelper.MeasurementEnum.Height)
        detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())

        If detailRows.Count = 0 Then
            ' Error in the database!  Each release point must have a height.
            ' Let it go; we will add it now.
            Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Height, "(missing!)", CStr(Math.Round(fugitive.Height, 2)), detailNotes)
            detailRows(0).DetailValue = Math.Round(fugitive.Height, 2)
        ElseIf (detailRows(0).DetailValue <> fugitive.Height) Then
            Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
            Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Height, CStr(detailRows(0).DetailValue), CStr(fugitive.Height), detailNotes)
            detailRows(0).DetailValue = fugitive.Height
        End If

        '--- length, width ---
        If ((fugitive.IsLengthNull) AndAlso (fugitive.IsWidthNull)) Then

            'length
            selectCriteria = measurementIDColumnName & "=" & CStr(ReleasePointHelper.MeasurementEnum.Length)
            detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
            If (detailRows.Length = 1) Then
                Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Length, CStr(detailRows(0).DetailValue), "Deleted", detailNotes)
                detailRows(0).Delete()
            End If

            'width
            selectCriteria = measurementIDColumnName & "=" & CStr(ReleasePointHelper.MeasurementEnum.Width)
            detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
            If (detailRows.Length = 1) Then
                Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Width, CStr(detailRows(0).DetailValue), "Deleted", detailNotes)
                detailRows(0).Delete()
            End If

        ElseIf ((Not fugitive.IsLengthNull) AndAlso (Not fugitive.IsWidthNull)) Then
            'length
            selectCriteria = measurementIDColumnName & "=" & CStr(ReleasePointHelper.MeasurementEnum.Length)
            detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
            If (detailRows.Length = 0) Then
                Dim lengthRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
                With lengthRow
                    .ReleasePointID = releasePointID
                    .MeasurementID = ReleasePointHelper.MeasurementEnum.Length
                    .DetailValue = fugitive.Length
                    .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Length)
                End With
                Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(lengthRow)
            Else
                If (detailRows(0).DetailValue <> fugitive.Length) Then
                    Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
                    Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Length, CStr(detailRows(0).DetailValue), CStr(fugitive.Length), detailNotes)
                    detailRows(0).DetailValue = fugitive.Length
                End If
            End If

            'width
            selectCriteria = measurementIDColumnName & "=" & CStr(ReleasePointHelper.MeasurementEnum.Width)
            detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
            If (detailRows.Length = 0) Then
                Dim widthRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
                With widthRow
                    .ReleasePointID = releasePointID
                    .MeasurementID = ReleasePointHelper.MeasurementEnum.Width
                    .DetailValue = fugitive.Width
                    .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.Width)
                End With
                Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(widthRow)
            Else
                If (detailRows(0).DetailValue <> fugitive.Width) Then
                    Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
                    Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.Width, CStr(detailRows(0).DetailValue), CStr(fugitive.Width), detailNotes)
                    detailRows(0).DetailValue = fugitive.Width
                End If
            End If
        End If

        '--- Horizontal Angle ---
        selectCriteria = measurementIDColumnName & "=" & CStr(ReleasePointHelper.MeasurementEnum.HorizontalAngle)
        detailRows = CType(Me.ReleasePointDataSet.ReleasePointDetail.Select(selectCriteria), EmissionsInventory.ReleasePointDataSet.ReleasePointDetailRow())
        If detailRows.Count = 0 Then
            If Not fugitive.IsHorizontalAngleNull Then
                Dim angleRow As ReleasePointDataSet.ReleasePointDetailRow = Me.ReleasePointDataSet.ReleasePointDetail.NewReleasePointDetailRow
                With angleRow
                    .ReleasePointID = releasePointID
                    .MeasurementID = ReleasePointHelper.MeasurementEnum.HorizontalAngle
                    .DetailValue = fugitive.HorizontalAngle
                    .UnitOfMeasurementID = ReleasePointHelper.GetUnitOfMeasurementID(ReleasePointHelper.MeasurementEnum.HorizontalAngle)
                End With
                Me.ReleasePointDataSet.ReleasePointDetail.Rows.Add(angleRow)
            End If
        ElseIf (detailRows.Count = 1) Then
            If (fugitive.IsHorizontalAngleNull) Then
                Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.HorizontalAngle, CStr(detailRows(0).DetailValue), "Deleted", detailNotes)
                detailRows(0).Delete()
            Else
                If (detailRows(0).DetailValue <> CDec(fugitive.HorizontalAngle)) Then
                    Call ReleasePointHelper.AddHistoryRecord_ReleasePointDetail(detailRows(0), Me.ReleasePointDataSet.ReleasePointDetailHistory)
                    Call Me.WriteDetailChangeNote(ReleasePointHelper.MeasurementEnum.HorizontalAngle, CStr(detailRows(0).DetailValue), CStr(CDec(fugitive.HorizontalAngle)), detailNotes)
                    detailRows(0).DetailValue = CDec(fugitive.HorizontalAngle)
                End If
            End If

        End If

        If (detailNotes.Length > 0) Then
            If (updateNotes.Length = 0) Then
                detailNotes.Insert(0, APCDID)
            End If
            updateNotes.Append(detailNotes.ToString)
        End If

    End Sub

#End Region '----- import methods ----- fugitives -----

    Private Function CreateHistoryRow(ByVal originalRow As ReleasePointDataSet.ReleasePointRow) As ReleasePointDataSet.ReleasePointHistoryRow

        Dim releasePointHistory As ReleasePointDataSet.ReleasePointHistoryRow = Me.ReleasePointDataSet.ReleasePointHistory.NewReleasePointHistoryRow

        With releasePointHistory
            .ReleasePointID = originalRow.ReleasePointID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .PlantID = originalRow.PlantID
            .ReleasePointDescription = originalRow.ReleasePointDescription
            .XCoordinate = originalRow.XCoordinate
            .YCoordinate = originalRow.YCoordinate
            .ReleasePointTypeID = originalRow.ReleasePointTypeID
            .ReleaseTypeSubTypeID = originalRow.ReleaseTypeSubTypeID
            .ReleasePointAPCDID = originalRow.ReleasePointAPCDID
            .ReleasePointEISID = originalRow.ReleasePointEISID
            .BeginDate = originalRow.BeginDate
            If (originalRow.IsEndDateNull) Then
                .SetEndDateNull()
            Else
                .EndDate = originalRow.EndDate
            End If
            .CompanyComment = originalRow.CompanyComment
            .APCDComment = originalRow.APCDComment
        End With

        Return releasePointHistory

    End Function

    Private Sub WriteHeaderChangeNote(ByVal column As ReleasePointHelper.ColumnEnum, ByVal oldValue As String, ByVal newValue As String, ByVal notesToAddTo As StringBuilder)

        With notesToAddTo
            .AppendLine()
            .Append(vbTab)
            Select Case column
                Case ReleasePointHelper.ColumnEnum.ReleasePointDescription
                    .AppendLine(ReleasePointDataSet.ReleasePoint.ReleasePointDescriptionColumn.ColumnName)

                Case ReleasePointHelper.ColumnEnum.XCoordinate
                    .AppendLine(ReleasePointDataSet.ReleasePoint.XCoordinateColumn.ColumnName)

                Case ReleasePointHelper.ColumnEnum.YCoordinate
                    .AppendLine(ReleasePointDataSet.ReleasePoint.YCoordinateColumn.ColumnName)

                Case ReleasePointHelper.ColumnEnum.ReleaseTypeSubTypeID
                    .AppendLine(ReleasePointDataSet.ReleasePoint.ReleaseTypeSubTypeIDColumn.ColumnName)

                Case ReleasePointHelper.ColumnEnum.ReleasePointTypeID
                    .AppendLine(ReleasePointDataSet.ReleasePoint.ReleasePointTypeIDColumn.ColumnName)

                Case ReleasePointHelper.ColumnEnum.CompanyComment
                    .AppendLine(ReleasePointDataSet.ReleasePoint.CompanyCommentColumn.ColumnName)
            End Select

            .Append(vbTab)
            .Append("Old value: ")
            .AppendLine(oldValue)
            .Append(vbTab)
            .Append("New value: ")
            .AppendLine(newValue)
        End With

    End Sub

    Private Sub WriteDetailChangeNote(ByVal measurement As ReleasePointHelper.MeasurementEnum, ByVal oldValue As String, ByVal newValue As String, ByVal notesToAddTo As StringBuilder)

        With notesToAddTo
            .AppendLine()
            .Append(vbTab)
            Select Case measurement
                Case ReleasePointHelper.MeasurementEnum.Diameter
                    .AppendLine(ReleasePointHelper.MeasurementName.Diameter)

                Case ReleasePointHelper.MeasurementEnum.ExitGasFlowRate
                    .AppendLine(ReleasePointHelper.MeasurementName.ExitGasFlowRate)

                Case ReleasePointHelper.MeasurementEnum.ExitGasSpeed
                    .AppendLine(ReleasePointHelper.MeasurementName.ExitGasSpeed)

                Case ReleasePointHelper.MeasurementEnum.ExitGasTemperature
                    .AppendLine(ReleasePointHelper.MeasurementName.ExitGasTemperature)

                Case ReleasePointHelper.MeasurementEnum.FencelineDistance
                    .AppendLine(ReleasePointHelper.MeasurementName.FencelineDistance)

                Case ReleasePointHelper.MeasurementEnum.Height
                    .AppendLine(ReleasePointHelper.MeasurementName.Height)

                Case ReleasePointHelper.MeasurementEnum.HorizontalAngle
                    .AppendLine(ReleasePointHelper.MeasurementName.HorizontalAngle)

                Case ReleasePointHelper.MeasurementEnum.Length
                    .AppendLine(ReleasePointHelper.MeasurementName.Length)

                Case ReleasePointHelper.MeasurementEnum.Width
                    .AppendLine(ReleasePointHelper.MeasurementName.Width)
            End Select

            .Append(vbTab)
            .Append("Old value: ")
            .AppendLine(oldValue)
            .Append(vbTab)
            .Append("New value: ")
            .AppendLine(newValue)
        End With

    End Sub

    Private Sub WriteImportReportHeader(ByVal sourceFile As IO.FileInfo)

        Me.m_mainImportLog = New StringBuilder

        With Me.m_mainImportLog
            .AppendLine("******************************************************************************************")
            .AppendLine("Form 91T Import Report")
            .AppendLine("Plant ID: " & CStr(Me.m_plantID))
            .AppendLine("File Name: " & sourceFile.Name)
            .AppendLine("Calendar Year: " & CStr(Me.m_emissionYear))
            .AppendLine("Report run date: " & Format(Date.Now, "dddd MMMM dd, yyyy  HH:mm:ss"))
            .AppendLine("******************************************************************************************")
        End With

    End Sub

    Private Sub WriteImportReportBody(ByVal addedRows As StringBuilder, ByVal addedRowCount As Int32, ByVal modifiedRows As StringBuilder, ByVal modifiedRowCount As Int32, ByVal type As SheetNameEnum)

        With Me.m_mainImportLog
            .AppendLine("----------------------------------------------------------------------")
            .Append("Added ")

            Select Case type
                Case SheetNameEnum.Stacks
                    .Append(SheetName.Stacks)
                    .Append(": ")
                Case SheetNameEnum.Fugitives
                    .Append(SheetName.Fugitives)
                    .Append(": ")
            End Select

            .AppendLine(CStr(addedRowCount))
            .AppendLine("----------------------------------------------------------------------")
            .AppendLine(addedRows.ToString)

            .AppendLine("----------------------------------------------------------------------")
            .Append("Modified ")

            Select Case type
                Case SheetNameEnum.Stacks
                    .Append(SheetName.Stacks)
                    .Append(": ")
                Case SheetNameEnum.Fugitives
                    .Append(SheetName.Fugitives)
                    .Append(": ")
            End Select

            .AppendLine(CStr(modifiedRowCount))
            .AppendLine("----------------------------------------------------------------------")
            .AppendLine(modifiedRows.ToString)
        End With

    End Sub

    Private Sub WriteImportReportToFile()

        Dim sw As New IO.StreamWriter(Me.m_mainImportLogFile.FullName)
        sw.Write(Me.m_mainImportLog.ToString)
        sw.Close()

    End Sub

#End Region '----- import methods -----

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class