Imports Microsoft.Office.Interop
Imports System.Text

Public Class ExcelDataImporter

    Private m_emissionYear As Int16
    Sub New(ByVal emissionYear As Int16)
        InitializeComponent()
        Me.m_emissionYear = emissionYear
    End Sub

    Dim m_mainErrorMessage As StringBuilder
    Private m_excelApp As Excel.Application
    Private m_workbook As Excel.Workbook
    Private m_e91TSheet As Excel.Worksheet
    Private m_stacksSheet As Excel.Worksheet
    Private m_fugitivesSheet As Excel.Worksheet

    Private Sub ExcelDataImporter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ReleasePointTypeTableAdapter.FillByReleaseTypeID(Me.EmissionsDataSet.ReleasePointType, 2)

    End Sub

    Private m_plantID As Int32 'set when check the "E91T" sheet

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

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        Dim filedialog As New OpenFileDialog
        With filedialog
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Multiselect = False
            If (.ShowDialog = DialogResult.OK) Then
                If (.FileName <> String.Empty) Then
                    Call Me.ImportForm(New IO.FileInfo(.FileName))
                End If
            End If
        End With

        filedialog = Nothing
        Me.Timer1.Start()

    End Sub

    Private Sub ImportForm(ByVal sourceFile As IO.FileInfo)

        Dim fiErrorLog As New IO.FileInfo(sourceFile.FullName.Substring(0, sourceFile.FullName.Length - 3) & "errorLog")
        If fiErrorLog.Exists Then fiErrorLog.Delete()

        Me.m_mainErrorMessage = New StringBuilder

        Dim feedbackMessage As New StringBuilder

        Me.m_excelApp = New Excel.Application
        Me.m_workbook = Me.m_excelApp.Workbooks.Open(sourceFile.FullName)

        If (Me.E91TSheetsExists = True) Then
            Call Me.CheckE91TSheet()
        End If

        If (Me.StacksSheetsExists) Then
            Call Me.CheckStacksSheet()
        End If

        If (Me.FugitivesSheetsExists) Then
            Call Me.CheckFugitivesSheet()
        End If

        'if no errors then save the sheets to the "auto" tables, otherwise, write the error log
        If (Me.m_mainErrorMessage.Length = 0) Then
            Call Me.Save()
        ElseIf (Me.m_mainErrorMessage.Length > 0) Then
            Dim sw As New IO.StreamWriter(fiErrorLog.FullName)
            sw.Write(Me.m_mainErrorMessage.ToString)
            sw.Close()
            MessageBox.Show("Errors occured", "Invalid Workbook", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        'clean up
        Me.m_e91TSheet = Nothing
        Me.m_stacksSheet = Nothing
        Me.m_fugitivesSheet = Nothing
        m_workbook.Close()
        Me.m_excelApp = Nothing

    End Sub

    Private Function E91TSheetsExists() As Boolean

        Dim returnValue As Boolean

        Try
            Call Me.AddSheetToWorkbook(SheetNameEnum.E91T)
            returnValue = True
        Catch ex As Exception
            returnValue = False
            Me.m_mainErrorMessage.AppendLine(ex.Message)
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
            Me.m_mainErrorMessage.AppendLine(ex.Message)
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
            Me.m_mainErrorMessage.AppendLine(ex.Message)
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
        Dim header As String = "***** E91T sheet *****" & vbCrLf

        Try
            Const plantIDCoordinate As String = "D26"
            Dim range As Excel.Range = Me.m_e91TSheet.Range(plantIDCoordinate, plantIDCoordinate)
            Me.m_plantID = CInt(range.Value)
            If (Me.m_plantID = 0) Then Throw New ApplicationException(String.Empty)
        Catch ex As Exception
            errorMessage.Append(vbTab)
            errorMessage.AppendLine("Plant ID is missing or invalid.")
        End Try

        Try
            Const emisisonYearCoordinate As String = "I26"
            Dim range As Excel.Range = Me.m_e91TSheet.Range(emisisonYearCoordinate, emisisonYearCoordinate)
            Dim emissionYear As Int16 = CShort(range.Value)
            If (emissionYear <> Me.m_emissionYear) Then Throw New ApplicationException(String.Empty)
        Catch ex As Exception
            errorMessage.Append(vbTab)
            errorMessage.AppendLine("Emission Year is missing or invalid.")
        End Try

        If (errorMessage.Length > 0) Then
            errorMessage.Insert(0, header)
            errorMessage.AppendLine()
            Me.m_mainErrorMessage.Append(errorMessage.ToString)
        End If

    End Sub

#End Region '----- E91T Workbook ----- 91T sheet -----

#Region "----- E91T Workbook ----- Stack sheet -----"

    Private Sub CheckStacksSheet()

        Dim errorMessage As New StringBuilder
        Dim header As String = "***** stacks sheet *****" & vbCrLf

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
            Me.m_mainErrorMessage.Append(errorMessage.ToString)
        End If

    End Sub

    Private Function GetStackRow(ByVal rowNumber As Int32) As ArrayList

        Dim row As New ArrayList
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
        Return row

    End Function

    Private Sub CheckStacksSheetRow(ByVal rowNumber As Int32, ByVal rowList As ArrayList)
        Me.lblProgress.Text = "Processing 'Stacks' sheet row " & rowNumber.ToString

        'data type
        'empty/null
        'field lengths
        'range
        'lookup value
        Dim errorMessage As New StringBuilder
        Dim header As String = "--- Row " & rowNumber.ToString & "---" & vbCrLf
        Dim value As String
        Dim row As EmissionsDataSet.autoE91T_StacksRow = Me.EmissionsDataSet.autoE91T_Stacks.NewautoE91T_StacksRow

        'Release Point Identifier (APCDID)
        Try
            value = CStr(rowList(0))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ReleasePointIdentifier) Then
                    Throw New ApplicationException(ColumnName.ReleasePointIdentifier & " column is missing.")
                End If
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.ReleasePointIdentifier & " value is missing.")
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
                If (value <> ColumnName.StackType) Then Throw New ApplicationException(ColumnName.StackType & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.StackType & " value is missing.")
                Else
                    Dim rows() As EmissionsDataSet.ReleasePointTypeRow = CType(Me.EmissionsDataSet.ReleasePointType.Select("ReleasePointTypeName = '" & value & "'"), EmissionsInventory.EmissionsDataSet.ReleasePointTypeRow())
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
                If (value <> ColumnName.Shape) Then Throw New ApplicationException(ColumnName.Shape & " column is missing.")
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(3))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ReleasePointDescription) Then Throw New ApplicationException(ColumnName.ReleasePointDescription & " column is missing.")
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
                If (value <> ColumnName.Latitude) Then Throw New ApplicationException(ColumnName.Latitude & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Latitude & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= 37.9963) AndAlso (CDec(value) <= 38.3837)) Then
                            row.Latitude = CDec(value)
                        Else
                            Throw New ApplicationException(ColumnName.Latitude & " value needs to be >= 37.9963 And <= 38.3837")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Latitude & " value is not numeric.")
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(5))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Longitude) Then Throw New ApplicationException(ColumnName.Longitude & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Longitude & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= -85.9586) AndAlso (CDec(value) <= -85.4135)) Then
                            row.Longitude = CDec(value)
                        Else
                            Throw New ApplicationException(ColumnName.Longitude & " value needs to be >= -85.9586 And <= -85.4135")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Longitude & " value is not numeric.")
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(6))
            If (rowNumber = 1) Then
                ''If (value <> ColumnName.Height) Then Throw New ApplicationException(ColumnName.Height & " column is missing.")
                If (InStr(value, ColumnName.Height) = 0) Then Throw New ApplicationException(ColumnName.Height & " column is missing.")

            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Height & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CInt(value) >= 1) AndAlso (CInt(value) <= 1300)) Then
                            row.Height = CInt(value)
                        Else
                            Throw New ApplicationException(ColumnName.Height & " value needs to be >= 1 And <= 1300")
                        End If

                    Else
                        Throw New ApplicationException(ColumnName.Height & " value is not numeric.")
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
                If (value <> ColumnName.Diameter) Then Throw New ApplicationException(ColumnName.Diameter & " column is missing.")
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

            Try
                value = CStr(rowList(8))
                If (InStr(value, ColumnName.Length) = 0) Then Throw New ApplicationException(ColumnName.Length & " column is missing.")
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

            Try
                value = CStr(rowList(9))
                If (InStr(value, ColumnName.Width) = 0) Then Throw New ApplicationException(ColumnName.Width & " column is missing.")
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
                            row.Diameter = CDec(diameter)
                        Else
                            Throw New ApplicationException(ColumnName.Diameter & " value needs to be >= 0.1 And <= 100")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Diameter & " value is not numeric.")
                    End If
                Catch ex As Exception
                    Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                End Try

            ElseIf ((diameter.Length = 0) AndAlso ((length.Length > 0) AndAlso (width.Length > 0))) Then
                'Approved/confirmed by Matt King on 12/17/2012
                'To calculae Equivalent Diameter use method #1 from http://www.weblakes.com/Newsletter/2007/Nov2007.html
                'That is: 2 * (Sqrt((L * W)/π))


                If (IsNumeric(length) AndAlso IsNumeric(width)) Then
                    Try
                        Dim equivalentDiameter As Decimal = CDec(2 * (Math.Sqrt((CDec(length) * CDec(width)) / Math.PI)))
                        If ((equivalentDiameter >= 0.1) AndAlso (equivalentDiameter <= 100)) Then
                            row.Length = CDec(length)
                            row.Width = CDec(width)
                        Else
                            Throw New ApplicationException("Equivalent Diameter conversion for Lenght and Width is out of range. Value needs to be >= 0.1 And <= 100")
                        End If
                    Catch ex As Exception
                        Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                    End Try
                Else
                    Try
                        If (Not IsNumeric(length)) Then
                            Throw New ApplicationException(ColumnName.Length & " value is not numeric.")
                        End If
                    Catch ex As Exception
                        Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                    End Try

                    Try
                        If (Not IsNumeric(width)) Then
                            Throw New ApplicationException(ColumnName.Width & " value is not numeric.")
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
                If (value <> ColumnName.ExhaustGasTemperature) Then Throw New ApplicationException(ColumnName.ExhaustGasTemperature & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.ExhaustGasTemperature & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CInt(value) >= 30) AndAlso (CInt(value) <= 3500)) Then
                            row.ExitGasTemperature = CInt(value)
                        Else
                            Throw New ApplicationException(ColumnName.ExhaustGasTemperature & " value needs to be >= 30 And <= 3500")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.ExhaustGasTemperature & " value is not numeric.")
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(11))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ExitGasFlowRate) Then Throw New ApplicationException(ColumnName.ExitGasFlowRate & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.ExitGasFlowRate & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= 0.1) AndAlso (CDec(value) <= 12000000)) Then
                            row.ExitGasFlowRate = CDec(value)
                        Else
                            Throw New ApplicationException(ColumnName.ExitGasFlowRate & " value needs to be >= 0.1 And <= 12000000")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.ExitGasFlowRate & " value is not numeric.")
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(12))
            If (rowNumber = 1) Then
                If (value <> ColumnName.DistanceFromFenceLine) Then Throw New ApplicationException(ColumnName.DistanceFromFenceLine & " column is missing.")
            Else
                If (value = String.Empty) Then
                    row.SetFencelineDistanceNull()
                Else

                    If (IsNumeric(value)) Then
                        If ((CInt(value) >= 1) AndAlso (CInt(value) <= 10000)) Then
                            row.FencelineDistance = CInt(value)
                        Else
                            Throw New ApplicationException(ColumnName.DistanceFromFenceLine & " value needs to be >= 1 And <= 10000")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.DistanceFromFenceLine & " value is not numeric.")
                    End If

                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(13))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Comment) Then Throw New ApplicationException(ColumnName.Comment & " column is missing.")
            Else
                If (value = String.Empty) Then
                    row.SetCommentPublicNull()
                Else
                    If (CStr(value).Length > 255) Then
                        Throw New ApplicationException(ColumnName.Comment & " must be <= 255 characters.")
                    Else
                        row.CommentPublic = value
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        If ((errorMessage.Length = 0) AndAlso (rowNumber > 1)) Then
            row.PlantID = Me.m_plantID
            Try
                Me.EmissionsDataSet.autoE91T_Stacks.Rows.Add(row)
            Catch ex As Exception
                If (InStr(ex.Message, "unique") > 0) Then
                    Call Me.AddErrorMessageDetailLine(errorMessage, "Duplicate release point: " & row.APCDID)
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
        Dim header As String = "***** fugitives sheet *****" & vbCrLf

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
            Me.m_mainErrorMessage.Append(errorMessage.ToString)
        End If

    End Sub

    Private Function GetFugitiveRow(ByVal rowNumber As Int32) As ArrayList

        Dim row As New ArrayList
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
        Return row

    End Function

    Private Sub CheckFugitivesSheetRow(ByVal rowNumber As Int32, ByVal rowList As ArrayList)
        Me.lblProgress.Text = "Processing 'Fugitives' sheet row " & rowNumber.ToString

        Dim errorMessage As New StringBuilder
        Dim header As String = "--- Row " & rowNumber.ToString & "---" & vbCrLf
        Dim value As String
        Dim row As EmissionsDataSet.autoE91T_FugitivesRow = Me.EmissionsDataSet.autoE91T_Fugitives.NewautoE91T_FugitivesRow

        'Release Point Identifier (APCDID)
        Try
            value = CStr(rowList(0))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ReleasePointIdentifier) Then
                    Throw New ApplicationException(ColumnName.ReleasePointIdentifier & " column is missing.")
                End If
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.ReleasePointIdentifier & " value is missing.")
                End If
                row.APCDID = value
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(1))
            If (rowNumber = 1) Then
                If (value <> ColumnName.FugitiveReleaseType) Then Throw New ApplicationException(ColumnName.FugitiveReleaseType & " column is missing.")
            Else
                'todo 20130125: THIS COLUMN IS NOT NECESSARY
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(2))
            If (rowNumber = 1) Then
                If (value <> ColumnName.ReleasePointDescription) Then Throw New ApplicationException(ColumnName.ReleasePointDescription & " column is missing.")
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
            value = CStr(rowList(3))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Latitude) Then Throw New ApplicationException(ColumnName.Latitude & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Latitude & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= 37.9963) AndAlso (CDec(value) <= 38.3837)) Then
                            row.Latitude = CDec(value)
                        Else
                            Throw New ApplicationException(ColumnName.Latitude & " value needs to be >= 37.9963 And <= 38.3837")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Latitude & " value is not numeric.")
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(4))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Longitude) Then Throw New ApplicationException(ColumnName.Longitude & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Longitude & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CDec(value) >= -85.9586) AndAlso (CDec(value) <= -85.4135)) Then
                            row.Longitude = CDec(value)
                        Else
                            Throw New ApplicationException(ColumnName.Longitude & " value needs to be >= -85.9586 And <= -85.4135")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Longitude & " value is not numeric.")
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(5))
            If (rowNumber = 1) Then
                If (InStr(value, ColumnName.Height) = 0) Then Throw New ApplicationException(ColumnName.Height & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Height & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CInt(value) >= 0) AndAlso (CInt(value) <= 500)) Then
                            row.Height = CInt(value)
                        Else
                            Throw New ApplicationException(ColumnName.Height & " value needs to be >= 0 And <= 500")
                        End If

                    Else
                        Throw New ApplicationException(ColumnName.Height & " value is not numeric.")
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try


        Try
            value = CStr(rowList(6))
            If (rowNumber = 1) Then
                If (InStr(value, ColumnName.Length) = 0) Then Throw New ApplicationException(ColumnName.Length & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Length & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CInt(value) >= 1) AndAlso (CInt(value) <= 10000)) Then
                            row.Height = CInt(value)
                        Else
                            Throw New ApplicationException(ColumnName.Length & " value needs to be >= 1 And <= 10000")
                        End If

                    Else
                        Throw New ApplicationException(ColumnName.Length & " value is not numeric.")
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(7))
            If (rowNumber = 1) Then
                If (InStr(value, ColumnName.Width) = 0) Then Throw New ApplicationException(ColumnName.Width & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Width & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CInt(value) >= 1) AndAlso (CInt(value) <= 10000)) Then
                            row.Height = CInt(value)
                        Else
                            Throw New ApplicationException(ColumnName.Width & " value needs to be >= 1 And <= 10000")
                        End If

                    Else
                        Throw New ApplicationException(ColumnName.Width & " value is not numeric.")
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try



        Try
            value = CStr(rowList(8))
            If (rowNumber = 1) Then
                If (InStr(value, ColumnName.Angle) = 0) Then Throw New ApplicationException(ColumnName.Angle & " column is missing.")
            Else
                If (value = String.Empty) Then
                    Throw New ApplicationException(ColumnName.Angle & " value is missing.")
                Else
                    If (IsNumeric(value)) Then
                        If ((CInt(value) >= 0) AndAlso (CInt(value) <= 179)) Then
                            row.HorizontalAngle = CInt(value)
                        Else
                            Throw New ApplicationException(ColumnName.Angle & " value needs to be >= 0 And <= 179")
                        End If
                    Else
                        Throw New ApplicationException(ColumnName.Angle & " value is not numeric.")
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Try
            value = CStr(rowList(9))
            If (rowNumber = 1) Then
                If (value <> ColumnName.Comment) Then Throw New ApplicationException(ColumnName.Comment & " column is missing.")
            Else
                If (value = String.Empty) Then
                    row.SetCommentPublicNull()
                Else
                    If (CStr(value).Length > 255) Then
                        Throw New ApplicationException(ColumnName.Comment & " must be <= 255 characters.")
                    Else
                        row.CommentPublic = value
                    End If
                End If
            End If
        Catch ex As Exception
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        If ((errorMessage.Length = 0) AndAlso (rowNumber > 1)) Then
            row.PlantID = Me.m_plantID
            Try
                Me.EmissionsDataSet.autoE91T_Fugitives.Rows.Add(row)
            Catch ex As Exception
                If (InStr(ex.Message, "unique") > 0) Then
                    Call Me.AddErrorMessageDetailLine(errorMessage, "Duplicate release point: " & row.APCDID)
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

    Private Sub Save()
        Me.Validate()
        Me.AutoE91T_StacksBindingSource.EndEdit()
        Me.AutoE91T_FugitivesBindingSource.EndEdit()

        'todo 20130125: import data into our RP table here.
#If DEBUG Then
        Debug.WriteLine("Stack RPs to import: " & CStr(Me.EmissionsDataSet.autoE91T_Stacks.Rows.Count))
        Debug.WriteLine("Fugitive RPs to import: " & CStr(Me.EmissionsDataSet.autoE91T_Fugitives.Rows.Count))
#End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class