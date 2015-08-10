Imports Microsoft.Office.Interop
Imports System.Text

Public Class ImportE92T

#Region "----- properties -----"

    Private m_emissionYear As Int16
    Sub New(ByVal emissionYear As Int16)
        InitializeComponent()
        Me.m_emissionYear = emissionYear
    End Sub

    Private m_mainErrorLogFile As IO.FileInfo
    Private m_mainErrorLog As StringBuilder

    Private m_mainImportLog As StringBuilder
    Private m_mainImportLogFile As IO.FileInfo

    Private m_excelApp As Excel.Application
    Private m_workbook As Excel.Workbook
    Private m_e92TSheet As Excel.Worksheet
    Private m_controlsSheet As Excel.Worksheet

    Private m_plantID As Int32 = 0 ' set when checking the "E92T" sheet
    Private m_e92ControlCount As Int32 = 0 ' number of control measures; set after QAing the "Controls" sheet
    Private m_e92ControlPollutantCount As Int32 = 0 ' number of control measure pollutants; also set after QA

#End Region '----- properties -----

    Private Sub ImportE92T_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ControlMeasureTypeTableAdapter.Fill(Me.ControlMeasureDataSet.ControlMeasureType)
        'Me.lblProgress.Text = String.Empty

    End Sub

#Region "----- E92T Workbook -----"

    Private Enum SheetNameEnum
        E92T
        Controls
    End Enum

    Partial Structure SheetName
        Const E92T As String = "E92T"
        Const Controls As String = "Controls"
    End Structure

    Private Structure ColumnName
        Const Identifier As String = "Identifier"
        Const Type As String = "Type"
        Const Description As String = "Description"
        Const Comment As String = "Comment"
        Const PollutantControlled As String = "Pollutant Controlled"
        Const ReductionEfficiency As String = "Reduction Efficiency (%)"
    End Structure

    Private Structure ValidationMessages
        Const ColumnIsMissing As String = " column is missing."
        Const ValueIsMissing As String = " value is missing."
        Const ValueIsNotNumeric As String = " value is not numeric."
        'Const MustBe255CharactersOrLess As String = " must be <= 255 characters."
    End Structure

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel 'changes to OK only if successful import

        Try
            Dim e92TWorkBook As IO.FileInfo

            Dim fileDialog As New OpenFileDialog

            Me.btnBrowse.Enabled = False
            Me.lblProgress.Text = String.Empty
            Me.ProgressBar1.Visible = False

            With fileDialog
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                .Multiselect = False
                .Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx"
                If (.ShowDialog = DialogResult.OK) Then

                    'check to make sure that the facility submittal is not final
                    Me.EmissionYearTableAdapter.FillByEmissionYear(Me.ControlMeasureDataSet.EmissionYear, Me.m_emissionYear)
                    If (CType(Me.ControlMeasureDataSet.EmissionYear.Rows(0), ControlMeasureDataSet.EmissionYearRow).IsFacilityInEISDateNull) Then

                        If (.FileName <> String.Empty) Then
                            e92TWorkBook = New IO.FileInfo(.FileName)
                            Me.m_mainErrorLogFile = New IO.FileInfo(e92TWorkBook.FullName.Substring(0, e92TWorkBook.FullName.Length - 4) & ".ERROR REPORT.txt")

                            Call Me.QATheForm(e92TWorkBook)

                            If (Me.m_mainErrorLog.Length = 0) Then

                                If (MessageBox.Show("QA check completed without errors. Would you like to import this data into the database now?", "Import Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                                    Me.m_mainImportLogFile = New IO.FileInfo(e92TWorkBook.FullName.Substring(0, e92TWorkBook.FullName.Length - 4) & ".IMPORT REPORT.txt")
                                    Call Me.WriteImportReportHeader(e92TWorkBook)
                                    Call Me.ImportTheData()

                                    MessageBox.Show("Control Measures imported successfully", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.DialogResult = Windows.Forms.DialogResult.OK

                                    Process.Start(Me.m_mainImportLogFile.FullName)
                                    Me.Timer1.Start()
                                Else
                                    Me.Timer1.Start()
                                End If

                            Else

                                Call Me.CreateMainErrorLogHeaderText(e92TWorkBook)
                                Call Me.WriteMainErrorLogToFile()

                                MessageBox.Show("Errors occured", "Invalid Workbook", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Process.Start(Me.m_mainErrorLogFile.FullName)
                                Me.Timer1.Start()

                            End If

                        Else
                            Me.Timer1.Start()
                        End If 'FileName <> String.Empty

                    End If 'IsFacilityInEISDateNull

                End If 'ShowDialog = DialogResult.OK

            End With

            fileDialog = Nothing

            Me.Timer1.Start()

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show("An error occurred:  " & ex.Message, "Import Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            Me.btnBrowse.Enabled = True
        End Try

    End Sub

    Private Sub CreateMainErrorLogHeaderText(ByVal e92TWorkBook As IO.FileInfo)

        Dim message As New StringBuilder
        With message
            .AppendLine("******************************************************************************************")
            .AppendLine("Form 92T QA Error Report")
            .Append("Plant ID: ")
            If (Me.m_plantID = 0) Then
                .AppendLine("Invalid")
            Else
                .AppendLine(CStr(Me.m_plantID))
            End If
            .AppendLine("File Name: " & e92TWorkBook.Name)
            .AppendLine("Calendar Year: " & CStr(Me.m_emissionYear))
            .AppendLine("Report run date: " & Format(Date.Now, "dddd MMMM dd, yyyy  HH:mm:ss"))
            .AppendLine("******************************************************************************************")
            .AppendLine()
        End With

        Me.m_mainErrorLog.Insert(0, message.ToString)

    End Sub

    Private Sub WriteMainErrorLogToFile()

        Dim sw As New IO.StreamWriter(Me.m_mainErrorLogFile.FullName)
        sw.Write(Me.m_mainErrorLog.ToString)
        sw.Close()

    End Sub

    Private Sub QATheForm(ByVal sourceFile As IO.FileInfo)

        Me.btnCancel.Enabled = False

        If Me.m_mainErrorLogFile.Exists Then Me.m_mainErrorLogFile.Delete()

        Me.m_mainErrorLog = New StringBuilder

        Dim feedbackMessage As New StringBuilder

        Me.m_excelApp = New Excel.Application
        Me.m_workbook = Me.m_excelApp.Workbooks.Open(sourceFile.FullName)

        If (Me.E92TSheetsExists = True) Then
            Call Me.CheckE92TSheet()

            If (Me.m_mainErrorLog.Length = 0) Then
                If (Me.ControlsSheetsExists = True) Then
                    Call Me.CheckControlsSheet()
                End If
            End If
        End If

        'clean up
        Me.m_e92TSheet = Nothing
        Me.m_controlsSheet = Nothing
        m_workbook.Close()
        Me.m_excelApp = Nothing
        Me.lblProgress.Text = String.Empty
        Me.btnCancel.Enabled = True

    End Sub

    Private Function E92TSheetsExists() As Boolean

        Dim returnValue As Boolean

        Try
            Call Me.AddSheetToWorkbook(SheetNameEnum.E92T)
            returnValue = True
        Catch ex As Exception
            returnValue = False
            Me.m_mainErrorLog.AppendLine(ex.Message)
        End Try

        Return returnValue

    End Function

    Private Function ControlsSheetsExists() As Boolean

        Dim returnValue As Boolean

        Try
            Call Me.AddSheetToWorkbook(SheetNameEnum.Controls)
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
                Case SheetNameEnum.E92T
                    sheetNameToAdd = SheetName.E92T
                    Me.m_e92TSheet = CType(Me.m_workbook.Worksheets(sheetNameToAdd), Excel.Worksheet)
                Case SheetNameEnum.Controls
                    sheetNameToAdd = SheetName.Controls
                    Me.m_controlsSheet = CType(Me.m_workbook.Worksheets(sheetNameToAdd), Excel.Worksheet)
            End Select
        Catch ex As Exception
            Throw New ApplicationException(sheetNameToAdd & " sheet is missing.")
        End Try

    End Sub

#Region "----- E92T Workbook ----- 92T sheet -----"

    Private Sub CheckE92TSheet()

        Dim errorMessage As New StringBuilder
        Dim plantIDCoordinate As String = "D20"
        Dim emissionYearCoordinate As String = "J20"

        Try
            Dim range As Excel.Range = Me.m_e92TSheet.Range(plantIDCoordinate, plantIDCoordinate)
            Me.m_plantID = CInt(range.Value)
            If (Me.m_plantID = 0) Then Throw New ApplicationException(String.Empty)
        Catch ex As Exception
            errorMessage.Append("Plant ID (")
            errorMessage.Append(plantIDCoordinate)
            errorMessage.AppendLine(") is missing or invalid.")
        End Try

        Try
            Dim range As Excel.Range = Me.m_e92TSheet.Range(emissionYearCoordinate, emissionYearCoordinate)
            Dim emissionYear As Int16 = CShort(range.Value)
            If (emissionYear <> Me.m_emissionYear) Then Throw New ApplicationException(String.Empty)
        Catch ex As Exception
            errorMessage.Append("Emission Year (")
            errorMessage.Append(emissionYearCoordinate)
            errorMessage.AppendLine(") is missing or invalid.")
        End Try

        If (errorMessage.Length > 0) Then
            Dim header As String = "------------------------- E92T sheet -------------------------" & vbCrLf
            errorMessage.Insert(0, header)
            errorMessage.AppendLine()
            Me.m_mainErrorLog.Append(errorMessage.ToString)
        End If

    End Sub

#End Region '----- E92T Workbook ----- 92T sheet -----

#Region "----- E92T Workbook ----- Control sheet -----"

    Private Sub CheckControlsSheet()

        Dim errorMessage As New StringBuilder
        Dim header As String = "------------------------- controls sheet -------------------------" & vbCrLf

        Try
            Dim sht As Excel.Worksheet = CType(Me.m_workbook.ActiveSheet, Excel.Worksheet)
            Dim rng As Excel.Range = sht.UsedRange
            Dim endCell As Excel.Range = rng.End(Excel.XlDirection.xlDown)
            Dim rowCount As Integer = CInt(Val(endCell.Address.Substring(3)))     ' $A$nnn

            endCell = Nothing
            rng = Nothing
            sht = Nothing
            Call Me.SetTheProgressBar(rowCount)

            Dim rowNumber As Int32 = 1
            Dim row As ArrayList = Me.GetControlRow(rowNumber)

            Do While Me.IsEndOfSheet(row) = False
                Try
                    Call Me.CheckControlsSheetRow(rowNumber, row)

                Catch ex As Exception
                    errorMessage.Append(ex.Message)
                End Try
                rowNumber += 1
                row = Me.GetControlRow(rowNumber)
                Me.ProgressBar1.Value += 1
            Loop
            Me.m_e92ControlCount = Me.ControlMeasureDataSet.autoE92T_Controls.Rows.Count
            Me.m_e92ControlPollutantCount = Me.ControlMeasureDataSet.autoE92T_ControlsPollutants.Rows.Count

        Catch ex As Exception
            errorMessage.Append(ex.Message)
        End Try

        Me.ProgressBar1.Visible = False
        If (errorMessage.Length > 0) Then
            errorMessage.Insert(0, header)
            Me.m_mainErrorLog.Append(errorMessage.ToString)
        End If

    End Sub

    Private Function GetControlRow(ByVal rowNumber As Int32) As ArrayList
        Me.lblProgress.Text = "Running QA on 'Controls' row " & CStr(rowNumber)
        Call Application.DoEvents()

        Dim row As New ArrayList
        Dim value As String
        For characterCode As Byte = 65 To 71
            Dim coordinates As String = Chr(characterCode) & rowNumber.ToString
            If (IsNothing(CType(Me.m_controlsSheet.Range(coordinates, coordinates), Excel.Range).Value)) Then
                value = String.Empty
            Else
                value = CStr(CType(Me.m_controlsSheet.Range(coordinates, coordinates), Excel.Range).Value).Trim & String.Empty
            End If
            row.Add(value)
        Next
        Return row

    End Function

    ''' <summary>
    ''' Check a row in the E92T spreadsheet for validity.
    ''' </summary>
    ''' <param name="rowNumber">which row of the worksheet to check</param>
    ''' <param name="rowList">array containing the rows read in</param>
    ''' <remarks>
    ''' 2013-10-24 BJF: Added outer Try block.
    ''' </remarks>
    Private Sub CheckControlsSheetRow(ByVal rowNumber As Int32, ByVal rowList As ArrayList)

        'data type
        'empty/null
        'field lengths
        'range
        'lookup value
        Dim errorMessage As New StringBuilder
        Dim value As String

        Try
            Dim headerRow As ControlMeasureDataSet.autoE92T_ControlsRow = Me.ControlMeasureDataSet.autoE92T_Controls.NewautoE92T_ControlsRow

            '----- CM header -----
            'Identifier (APCDID)
            Try
                value = CStr(rowList(0))
                If (rowNumber = 1) Then
                    If (value <> ColumnName.Identifier) Then
                        Throw New ApplicationException(ColumnName.Identifier & ValidationMessages.ColumnIsMissing)
                    End If
                Else
                    If (value = String.Empty) Then
                        Throw New ApplicationException(ColumnName.Identifier & ValidationMessages.ValueIsMissing)
                    Else
                        If (value.Length > 50) Then
                            Throw New ApplicationException(ColumnName.Identifier & " must be between 1 and 50 characters inclusive.")
                        Else
                            headerRow.APCDID = value
                        End If
                    End If
                End If
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

            'Type (ControlMeasureType)
            Try
                value = CStr(rowList(1))
                If (rowNumber = 1) Then
                    If (value <> ColumnName.Type) Then Throw New ApplicationException(ColumnName.Type & ValidationMessages.ColumnIsMissing)
                Else
                    If (value = String.Empty) Then
                        Throw New ApplicationException(ColumnName.Type & ValidationMessages.ValueIsMissing)
                    Else
                        Dim controlMeasureType As Emissions.Business.ControlMeasureType _
                            = Emissions.Utility.ControlMeasureTypeUtility.GetByLookupName(value)
                        If (controlMeasureType Is Nothing) Then
                            Throw New ApplicationException(ColumnName.Type & " is invalid.")
                        Else
                            headerRow.ControlMeasureTypeID = controlMeasureType.ControlMeasureTypeID
                        End If
                    End If
                End If
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

            'Description
            Try
                value = CStr(rowList(2))
                If (rowNumber = 1) Then
                    If (value <> ColumnName.Description) Then Throw New ApplicationException(ColumnName.Description & ValidationMessages.ColumnIsMissing)
                Else
                    If (value = String.Empty) Then
                        headerRow.SetControlMeasureDescriptionNull()
                    Else
                        If (value.Length > 100) Then
                            Throw New ApplicationException(ColumnName.Description & " must be between 0 and 100 characters inclusive.")
                        Else
                            headerRow.ControlMeasureDescription = value
                        End If
                    End If
                End If
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

            'Comment
            Try
                value = CStr(rowList(3))
                If (rowNumber = 1) Then
                    If (value <> ColumnName.Comment) Then Throw New ApplicationException(ColumnName.Comment & ValidationMessages.ColumnIsMissing)
                Else
                    If (value = String.Empty) Then
                        headerRow.SetCompanyCommentNull()
                    Else
                        If (value.Length > 400) Then
                            Throw New ApplicationException(ColumnName.Comment & " must be between 0 and 400 characters inclusive.")
                        Else
                            headerRow.CompanyComment = value
                        End If
                    End If
                End If
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

            '----- CM pollutants -----
            Dim detailRow As ControlMeasureDataSet.autoE92T_ControlsPollutantsRow = Me.ControlMeasureDataSet.autoE92T_ControlsPollutants.NewautoE92T_ControlsPollutantsRow
            'pollutant
            Try
                value = CStr(rowList(4))
                If (rowNumber = 1) Then
                    If (value <> ColumnName.PollutantControlled) Then Throw New ApplicationException(ColumnName.PollutantControlled & ValidationMessages.ColumnIsMissing)
                Else
                    If (value = String.Empty) Then
                        Throw New ApplicationException(ColumnName.PollutantControlled & ValidationMessages.ValueIsMissing)
                    Else
                        Dim pollutant As Emissions.Business.Pollutant = Emissions.Utility.PollutantUtility.GetByLookupName(value)
                        If (pollutant Is Nothing) Then
                            Throw New ApplicationException(ColumnName.PollutantControlled & " is invalid.")
                        Else
                            detailRow.PollutantID = pollutant.PollutantID
                        End If
                    End If
                End If
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

            'reduction efficiency
            Try
                value = CStr(rowList(5))
                If (rowNumber = 1) Then
                    If (value <> ColumnName.ReductionEfficiency) Then Throw New ApplicationException(ColumnName.ReductionEfficiency & ValidationMessages.ColumnIsMissing)
                Else
                    If (value = String.Empty) Then
                        Throw New ApplicationException(ColumnName.ReductionEfficiency & ValidationMessages.ValueIsMissing)
                    Else
                        If (IsNumeric(value)) Then
                            Dim reductionEfficiency As Decimal = CDec(value)
                            If ((reductionEfficiency >= 1) AndAlso (reductionEfficiency < 100)) Then
                                detailRow.ReductionEfficiency = Math.Round(reductionEfficiency, 3)
                            Else
                                Throw New ApplicationException(ColumnName.ReductionEfficiency & " value needs to be >= 1 And < 100 %.")
                            End If
                        Else
                            Throw New ApplicationException(ColumnName.ReductionEfficiency & ValidationMessages.ValueIsNotNumeric)
                        End If
                    End If
                End If
            Catch ex As Exception
                Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
            End Try

            If ((errorMessage.Length = 0) AndAlso (rowNumber > 1)) Then
                headerRow.PlantID = Me.m_plantID
                Try
                    Me.ControlMeasureDataSet.autoE92T_Controls.Rows.Add(headerRow)

                    Try
                        Call Me.AddDetailRowToE92Table(headerRow, detailRow)
                    Catch e As Exception
                        Call Me.AddErrorMessageDetailLine(errorMessage, e.Message)
                    End Try

                Catch ex As Exception
                    If (InStr(ex.Message, "unique") > 0 Or InStr(ex.Message, "duplicate") > 0) Then
                        Try
                            Call Me.AddDetailRowToE92Table(headerRow, detailRow)
                        Catch e As Exception
                            If (InStr(ex.Message, "unique") > 0 Or InStr(ex.Message, "duplicate") > 0) Then
                                Call Me.AddErrorMessageDetailLine(errorMessage, "Duplicate pollutant '" & rowList(4).ToString _
                                                                  & "' for control measure '" & rowList(0).ToString & "'.")
                            Else
                                Call Me.AddErrorMessageDetailLine(errorMessage, e.Message)
                            End If
                        End Try

                    Else
                        Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
                    End If
                End Try
            End If

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
        End Try

        Dim header As String = "Row " & rowNumber.ToString & vbCrLf
        If (errorMessage.Length > 0) Then
            errorMessage.Insert(0, header)
            errorMessage.AppendLine()
            Throw New ApplicationException(errorMessage.ToString)
        End If

    End Sub

    Private Sub AddDetailRowToE92Table(ByVal headerRow As ControlMeasureDataSet.autoE92T_ControlsRow, ByVal detailRow As ControlMeasureDataSet.autoE92T_ControlsPollutantsRow)

        Dim errorMessage As New StringBuilder

        Try
            detailRow.PlantID = headerRow.PlantID
            detailRow.APCDID = headerRow.APCDID
            Me.ControlMeasureDataSet.autoE92T_ControlsPollutants.Rows.Add(detailRow)
        Catch ex As Exception
            If (InStr(ex.Message, "unique") > 0) Then
                With errorMessage
                    .Append("Control measure ")
                    .AppendLine(Tools.Constants.Character.DoubleQuote)
                    .Append(detailRow.APCDID)
                    .AppendLine(Tools.Constants.Character.DoubleQuote)
                    .Append(" has a duplicate pollutant ")
                    .AppendLine(Tools.Constants.Character.DoubleQuote)
                    .Append(CType(Emissions.Utility.PollutantUtility.GetByPrimaryKey(detailRow.PollutantID), Emissions.Business.Pollutant).PollutantName)
                    .AppendLine(Tools.Constants.Character.DoubleQuote)
                End With
                Throw New ApplicationException(errorMessage.ToString)
            Else
                Throw New ApplicationException(ex.Message)
            End If
        End Try

    End Sub

    ''Private Sub CheckControlsSheetRow_AdditionalPollutant(ByVal rowNumber As Int32, ByVal rowList As ArrayList, ByVal apcdID As String)

    ''    Dim errorMessage As New StringBuilder
    ''    Dim e92TpollutantRow As ControlMeasureDataSet.autoE92T_ControlsPollutantsRow = Me.ControlMeasureDataSet.autoE92T_ControlsPollutants.NewautoE92T_ControlsPollutantsRow

    ''    Try
    ''        Call Me.CheckControlsSheetRow_PollutantFields(rowNumber, rowList, e92TpollutantRow)
    ''    Catch ex As Exception
    ''        errorMessage.Append(ex.Message)
    ''    End Try

    ''    If ((errorMessage.Length = 0) AndAlso (rowNumber > 1)) Then
    ''        Try
    ''            e92TpollutantRow.APCDID = apcdID
    ''            e92TpollutantRow.PlantID = Me.m_plantID
    ''            Call Me.AddE92TPollutantToE92TPollutantTable(e92TpollutantRow, CStr(rowList(4)))
    ''        Catch ex As Exception
    ''            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
    ''        End Try
    ''    End If

    ''    If (errorMessage.Length > 0) Then
    ''        Dim header As String = "Row " & rowNumber.ToString & vbCrLf
    ''        errorMessage.Insert(0, header)
    ''        errorMessage.AppendLine()
    ''        Throw New ApplicationException(errorMessage.ToString)
    ''    End If

    ''End Sub

    ''Private Sub CheckControlsSheetRow_PollutantFields(ByVal rowNumber As Int32, ByVal rowList As ArrayList, ByVal e92TPollutantRow As ControlMeasureDataSet.autoE92T_ControlsPollutantsRow)

    ''    Dim errorMessage As New StringBuilder
    ''    Dim value As String



    ''    If (errorMessage.Length > 0) Then
    ''        Throw New ApplicationException(errorMessage.ToString)
    ''    End If

    ''End Sub

    ''Private Sub AddE92TPollutantToE92TPollutantTable(ByVal e92TpollutantRow As ControlMeasureDataSet.autoE92T_ControlsPollutantsRow, ByVal pollutantName As String)

    ''    Dim errorMessage As New StringBuilder

    ''    Try
    ''        Me.ControlMeasureDataSet.autoE92T_ControlsPollutants.Rows.Add(e92TpollutantRow)
    ''    Catch ex As Exception
    ''        If (InStr(ex.Message, "unique") > 0) Then
    ''            Call Me.AddErrorMessageDetailLine(errorMessage, "Duplicate control measure pollutant!  Identifier = " _
    ''                                              & e92TpollutantRow.APCDID _
    ''                                              & ", Pollutant = " _
    ''                                              & pollutantName)
    ''        Else
    ''            Call Me.AddErrorMessageDetailLine(errorMessage, ex.Message)
    ''        End If
    ''    End Try

    ''    If (errorMessage.Length > 0) Then
    ''        Throw New ApplicationException(errorMessage.ToString)
    ''    End If

    ''End Sub

#End Region '----- E92T Workbook ----- Control sheet -----

#End Region '----- E92T Workbook -----

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

    Private Sub AddErrorMessageDetailLine(ByVal messageToAddTo As StringBuilder, ByVal textToAdd As String)
        messageToAddTo.Append(vbTab)
        messageToAddTo.AppendLine(textToAdd)
    End Sub

#End Region '----- utils -----

#Region "----- import methods -----"

    Private Sub ImportTheData()

        Me.btnCancel.Enabled = False
        Call Me.SetTheProgressBar(Me.m_e92ControlCount)
        Call Me.ReconcileControls()
        Call Me.WriteImportReportToFile()
        Me.ProgressBar1.Visible = False

    End Sub

    Private Sub SetTheProgressBar(ByVal maxCount As Integer)
        With Me.ProgressBar1
            .Minimum = 0
            .Maximum = maxCount
            .Value = 0
            .Visible = True
        End With
    End Sub

    ''' <summary>
    ''' Compare the list of control measures in the spreadsheet with those already in the database for the plant.
    ''' </summary>
    ''' <remarks> 
    ''' </remarks>
    Private Sub ReconcileControls()

        Dim addedRowsMessage As New StringBuilder
        Dim addedRowCount As Int32 = 0
        Dim modifiedRowsMessage As New StringBuilder
        Dim modifiedRowCount As Int32 = 0

        Dim controlMeasure As ControlMeasureDataSet.ControlMeasureRow
        For Each e92TControlRow As ControlMeasureDataSet.autoE92T_ControlsRow In Me.ControlMeasureDataSet.autoE92T_Controls
            Me.lblProgress.Text = "Processing control: " & e92TControlRow.APCDID
            Me.ProgressBar1.Value += 1
            Call Application.DoEvents()
            If (Me.ControlMeasureTableAdapter.Connection.ConnectionString = String.Empty) Then
                Me.ControlMeasureTableAdapter.Connection.ConnectionString = APCD.Emissions.Globals.GlobalVariables.ConnectionString
            End If
            Me.ControlMeasureTableAdapter.FillByPlantID_APCDID(Me.ControlMeasureDataSet.ControlMeasure, _
                                                               e92TControlRow.PlantID, e92TControlRow.APCDID)

            If (Me.ControlMeasureDataSet.ControlMeasure.Rows.Count = 0) Then
                'not in the db, add it...
                Try
                    controlMeasure = Me.ReconcileControls_AddControlMeasure(e92TControlRow)
                    addedRowCount += 1
                    Call Me.ReconcileControls_AddControlMeasureYearRecord(controlMeasure)
                    Call Me.ReconcileControls_AddPollutants(controlMeasure)
                    addedRowsMessage.AppendLine(controlMeasure.ControlMeasureAPCDID)
                Catch ex As Exception
                    addedRowsMessage.AppendLine(ex.Message)
                End Try

            Else
                'in the db, update it (if needed)...
                Dim updateNotes As New StringBuilder

                'header
                controlMeasure = CType(Me.ControlMeasureDataSet.ControlMeasure.Rows(0), EmissionsInventory.ControlMeasureDataSet.ControlMeasureRow)
                If (controlMeasure.IsEndDateNull) Then
                    Call Me.CompareControls(controlMeasure, e92TControlRow, updateNotes)

                    'pollutants
                    Call Me.CompareControlPollutants(controlMeasure, e92TControlRow.APCDID, updateNotes)

                    If (updateNotes.Length > 0) Then
                        modifiedRowsMessage.AppendLine(updateNotes.ToString)
                        modifiedRowCount += 1
                    End If
                Else
                    'the CM is shut down
                    With updateNotes
                        .Append("WARNING! Control Measure ")
                        .Append(Tools.Constants.Character.DoubleQuote)
                        .Append(controlMeasure.ControlMeasureAPCDID)
                        .Append(Tools.Constants.Character.DoubleQuote)
                        .AppendLine(" is shut down and may not be updated.")
                        modifiedRowsMessage.AppendLine(updateNotes.ToString)
                    End With
                End If

            End If

        Next

        Call Me.WriteImportReportBody(addedRowsMessage, addedRowCount, modifiedRowsMessage, modifiedRowCount, SheetNameEnum.Controls)

    End Sub

    Private Sub Wait(ByVal seconds As Byte)
        Dim startTime As Date = Date.Now
        Dim endTime As Date = startTime.AddSeconds(seconds)
        Do Until endTime < Date.Now
        Loop
    End Sub

    Private Function ReconcileControls_AddControlMeasure(ByVal e92TControlRow As ControlMeasureDataSet.autoE92T_ControlsRow) _
        As ControlMeasureDataSet.ControlMeasureRow

        Call Me.Wait(1)

        Dim errorMessage As New StringBuilder

        Dim controlMeasure As ControlMeasureDataSet.ControlMeasureRow = Me.ControlMeasureDataSet.ControlMeasure.NewControlMeasureRow
        With controlMeasure
            If (e92TControlRow.IsControlMeasureDescriptionNull) Then
                .SetControlMeasureDescriptionNull()
            Else
                .ControlMeasureDescription = e92TControlRow.ControlMeasureDescription
            End If

            .PlantID = e92TControlRow.PlantID
            .ControlMeasureTypeID = e92TControlRow.ControlMeasureTypeID
            .ControlMeasureAPCDID = e92TControlRow.APCDID

            .BeginDate = New Date(Date.Now.Year - 1, 1, 1)

            If (e92TControlRow.IsCompanyCommentNull) Then
                .SetCompanyCommentNull()
            Else
                .CompanyComment = e92TControlRow.CompanyComment
            End If

            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With
        Me.ControlMeasureDataSet.ControlMeasure.Rows.Add(controlMeasure)

        Me.ControlMeasureBindingSource.EndEdit()

        Try
            Me.ControlMeasureTableAdapter.Connection.Open()
            Me.ControlMeasureTableAdapter.Update(Me.ControlMeasureDataSet.ControlMeasure)

            Dim cmd As New OleDb.OleDbCommand("SELECT @@IDENTITY", Me.ControlMeasureTableAdapter.Connection)
            controlMeasure.ControlMeasureID = CInt(cmd.ExecuteScalar)

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            With errorMessage
                .Append("An error occured attempting to add control measure ")
                .Append(Tools.Constants.Character.DoubleQuote)
                .Append(e92TControlRow.APCDID)
                .AppendLine(Tools.Constants.Character.DoubleQuote)
            End With
            controlMeasure = Nothing
            Throw New ApplicationException(errorMessage.ToString())
        Finally
            If (Me.ControlMeasureTableAdapter.Connection.State = ConnectionState.Open) Then Me.ControlMeasureTableAdapter.Connection.Close()
        End Try

        Return controlMeasure

    End Function

    Private Sub ReconcileControls_AddControlMeasureYearRecord(ByVal controlMeasure As ControlMeasureDataSet.ControlMeasureRow)

        Dim errorMessage As New StringBuilder

        Try
            Dim cmYear As ControlMeasureDataSet.ControlMeasureYearRow = Me.ControlMeasureDataSet.ControlMeasureYear.NewControlMeasureYearRow
            With cmYear
                .ControlMeasureID = controlMeasure.ControlMeasureID
                .EmissionYear = Me.m_emissionYear
            End With
            Me.ControlMeasureDataSet.ControlMeasureYear.Rows.Add(cmYear)
            Me.ControlMeasureYearTableAdapter.Update(cmYear)
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            With errorMessage
                .Append("An error occured attempting to add control measure year for ")
                .Append(Tools.Constants.Character.DoubleQuote)
                .Append(controlMeasure.ControlMeasureAPCDID)
                .AppendLine(Tools.Constants.Character.DoubleQuote)
            End With
            controlMeasure = Nothing
            Throw New ApplicationException(errorMessage.ToString())
        End Try


    End Sub

    Private Sub ReconcileControls_AddPollutants(ByVal controlMeasure As ControlMeasureDataSet.ControlMeasureRow)

        Dim filter As String = ControlMeasureDataSet.autoE92T_ControlsPollutants.APCDIDColumn.ColumnName _
                             & Tools.Constants.Character.EqualSign _
                             & Tools.Constants.Character.SingleQuote _
                             & controlMeasure.ControlMeasureAPCDID _
                             & Tools.Constants.Character.SingleQuote
        Dim e92TPollutants() As ControlMeasureDataSet.autoE92T_ControlsPollutantsRow _
            = CType(Me.ControlMeasureDataSet.autoE92T_ControlsPollutants.Select(filter), EmissionsInventory.ControlMeasureDataSet.autoE92T_ControlsPollutantsRow())
        If (e92TPollutants.Length > 0) Then
            For Each e92TPollutant As ControlMeasureDataSet.autoE92T_ControlsPollutantsRow In e92TPollutants
                Call Me.ReconcileControls_AddPollutant(e92TPollutant, controlMeasure)
            Next
            Try
                Me.ControlMeasurePollutantTableAdapter.Update(Me.ControlMeasureDataSet.ControlMeasurePollutant)
            Catch ex As Exception
                GlobalMethods.HandleError(ex)
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Adds the e92Pollutant to the ControlMeasure table for the given ControlMeasureRow passed in.
    ''' </summary>
    ''' <param name="e92TPollutant">ControlPollutant row created from the spreadsheet</param>
    ''' <param name="controlMeasure">ControlMeasure row from the database</param>
    ''' <remarks>
    ''' 2013-10-14 BJF:  Added EmissionYear to the fields filled in.
    ''' 2013-10-24 BJF:  Added Try block.
    ''' </remarks>
    Private Sub ReconcileControls_AddPollutant(ByVal e92TPollutant As ControlMeasureDataSet.autoE92T_ControlsPollutantsRow, ByVal controlMeasure As ControlMeasureDataSet.ControlMeasureRow)

        Call Me.Wait(1)

        Dim errorMessage As New StringBuilder

        Dim cmPollutant As ControlMeasureDataSet.ControlMeasurePollutantRow = Me.ControlMeasureDataSet.ControlMeasurePollutant.NewControlMeasurePollutantRow
        With cmPollutant
            .ControlMeasureID = controlMeasure.ControlMeasureID
            .EmissionYear = Me.m_emissionYear
            .PollutantID = e92TPollutant.PollutantID
            .ReductionEfficiency = e92TPollutant.ReductionEfficiency
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With

        Try
            Me.ControlMeasureDataSet.ControlMeasurePollutant.Rows.Add(cmPollutant)

            Me.ControlMeasurePollutantTableAdapter.Update(Me.ControlMeasureDataSet.ControlMeasurePollutant)

            Me.ControlMeasureDataSet.ControlMeasurePollutant.Clear()

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            With errorMessage
                .Append("An error occured attempting to add pollutant ")
                .Append(e92TPollutant.PollutantID)
                .Append(" to control measure ")
                .Append(Tools.Constants.Character.DoubleQuote)
                .Append(e92TPollutant.APCDID)
                .AppendLine(Tools.Constants.Character.DoubleQuote)
            End With
            controlMeasure = Nothing
            Throw New ApplicationException(errorMessage.ToString())
        End Try


    End Sub

    ''' <summary>
    ''' Compare the control measure from the spreadsheet with any matching control already in the database.
    ''' </summary>
    ''' <param name="originalRow">the existing control measure in the database</param>
    ''' <param name="e92TControlRow">the revised control from the spreadsheet</param>
    ''' <param name="updateNotes">log of changes</param>
    ''' <remarks>
    ''' 2013-10-24 BJF: Added a Try block around the DB update.
    ''' </remarks>
    Private Sub CompareControls(ByVal originalRow As ControlMeasureDataSet.ControlMeasureRow, _
                                ByVal e92TControlRow As ControlMeasureDataSet.autoE92T_ControlsRow, ByVal updateNotes As StringBuilder)

        Dim controlMeasureHistory As ControlMeasureDataSet.ControlMeasureHistoryRow = Me.CreateHistoryRow_ControlMeasure(originalRow)
        Dim changedNotes As New StringBuilder

        With originalRow
            If (.ControlMeasureDescription <> e92TControlRow.ControlMeasureDescription) Then
                Call Me.WriteChangeNote(ControlMeasureHelper.ColumnEnum.ControlMeasureDescription, .ControlMeasureDescription, e92TControlRow.ControlMeasureDescription, changedNotes)
                .ControlMeasureDescription = e92TControlRow.ControlMeasureDescription
            End If

            If (.ControlMeasureTypeID <> e92TControlRow.ControlMeasureTypeID) Then
                Call Me.WriteChangeNote(ControlMeasureHelper.ColumnEnum.ControlMeasureTypeID, CStr(.ControlMeasureTypeID), CStr(e92TControlRow.ControlMeasureTypeID), changedNotes)
                .ControlMeasureTypeID = e92TControlRow.ControlMeasureTypeID
            End If

            If (.CompanyComment <> e92TControlRow.CompanyComment) Then
                Call Me.WriteChangeNote(ControlMeasureHelper.ColumnEnum.CompanyComment, .CompanyComment, e92TControlRow.CompanyComment, changedNotes)
                .CompanyComment = e92TControlRow.CompanyComment
            End If
        End With

        If (changedNotes.Length > 0) Then
            changedNotes.Insert(0, originalRow.ControlMeasureAPCDID)
            updateNotes.Append(changedNotes.ToString)

            Try
                Me.ControlMeasureDataSet.ControlMeasureHistory.Rows.Add(controlMeasureHistory)

                'save
                Me.ControlMeasureTableAdapter.Update(originalRow)
                Me.ControlMeasureHistoryTableAdapter.Update(controlMeasureHistory)
            Catch ex As Exception
                If (InStr(ex.Message, "unique") > 0 Or InStr(ex.Message, "duplicate") > 0) Then
                    changedNotes.Append("A duplication error occurred updating the control measure!")
                Else
                    GlobalMethods.HandleError(ex)
                    changedNotes.Append("An error occurred updating the control measure:  " & ex.Message)
                End If
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Compare the pollutants listed for the control in the spreadsheet
    ''' to those already in the database.
    ''' </summary>
    ''' <param name="controlMeasure">ControlMeasure data row</param>
    ''' <param name="e92TControlIdentifier">ControlMeasureAPCDID from the spreadsheet</param>
    ''' <param name="updateNotes">Update Notes: Any changes are appended.</param>
    ''' <remarks>
    ''' 2013-10-14 BJF: Added EmissionYear to the selection criteria.
    '''                 Changed the parameter updateNotes to ByRef, so the change
    '''                 notes are passed back.
    ''' 2013-10-24 BJF: Added Try block.
    ''' </remarks>
    Private Sub CompareControlPollutants(ByVal controlMeasure As ControlMeasureDataSet.ControlMeasureRow, _
                                         ByVal e92TControlIdentifier As String, _
                                         ByRef updateNotes As StringBuilder)

        Dim changedNotes As New StringBuilder
        Dim e92TCriteria As String = ControlMeasureDataSet.ControlMeasure.PlantIDColumn.ColumnName _
                                   & Tools.Constants.Character.EqualSign _
                                   & controlMeasure.PlantID _
                                   & " AND APCDID " _
                                   & Tools.Constants.Character.EqualSign _
                                   & Tools.Constants.Character.SingleQuote _
                                   & e92TControlIdentifier _
                                   & Tools.Constants.Character.SingleQuote

        Try
            'Get the control measure's pollutants that are already in the db
            'Me.ControlMeasurePollutantTableAdapter.FillByControlMeasureID(Me.ControlMeasureDataSet.ControlMeasurePollutant, controlMeasure.ControlMeasureID)
            Me.ControlMeasurePollutantTableAdapter.FillByControlMeasureIDAndEmissionYear(Me.ControlMeasureDataSet.ControlMeasurePollutant, _
                                                                                         controlMeasure.ControlMeasureID, _
                                                                                         Me.m_emissionYear)

            'Get all of the pollutants for the same control measure that are in the e92T sheet
            Dim e92TPollutants() As ControlMeasureDataSet.autoE92T_ControlsPollutantsRow _
                = CType(Me.ControlMeasureDataSet.autoE92T_ControlsPollutants.Select(e92TCriteria),  _
                    EmissionsInventory.ControlMeasureDataSet.autoE92T_ControlsPollutantsRow())

            'check to see if the e92Ts pollutants are in the db; add/update as needed
            For Each e92TPollutant As ControlMeasureDataSet.autoE92T_ControlsPollutantsRow In e92TPollutants
                ' Add a dot to progress text to show some activity.
                Me.lblProgress.Text &= "."
                Dim controlMeasurePollutantFilter As String = ControlMeasureDataSet.ControlMeasurePollutant.PollutantIDColumn.ColumnName _
                                                            & Tools.Constants.Character.EqualSign _
                                                            & e92TPollutant.PollutantID
                Dim controlMeasurePollutants() As ControlMeasureDataSet.ControlMeasurePollutantRow _
                    = CType(Me.ControlMeasureDataSet.ControlMeasurePollutant.Select(controlMeasurePollutantFilter),  _
                            EmissionsInventory.ControlMeasureDataSet.ControlMeasurePollutantRow())

                If (controlMeasurePollutants.Length = 0) Then
                    'the pollutant in the e92T sheet is not in our DB, add it
                    Call Me.ReconcileControls_AddPollutant(e92TPollutant, controlMeasure)

                Else
                    If (controlMeasurePollutants(0).ReductionEfficiency <> e92TPollutant.ReductionEfficiency) Then
                        Dim controlMeasurePollutantHistory As ControlMeasureDataSet.ControlMeasurePollutantHistoryRow _
                            = Me.CreateHistoryRow_ControlMeasurePollutant(controlMeasurePollutants(0))
                        Dim currentPollutant As Emissions.Business.Pollutant _
                            = Emissions.Utility.PollutantUtility.GetByPrimaryKey(e92TPollutant.PollutantID)
                        Call Me.WriteChangeNote(currentPollutant.PollutantName, CStr(controlMeasurePollutants(0).ReductionEfficiency), _
                                                CStr(e92TPollutant.ReductionEfficiency), changedNotes)

                        controlMeasurePollutants(0).ReductionEfficiency = e92TPollutant.ReductionEfficiency
                        Me.ControlMeasureDataSet.ControlMeasurePollutantHistory.Rows.Add(controlMeasurePollutantHistory)

                        'save the pollutant and the history rec
                        Try
                            Me.ControlMeasurePollutantTableAdapter.Update(Me.ControlMeasureDataSet.ControlMeasurePollutant)
                            Me.ControlMeasurePollutantHistoryTableAdapter.Update(Me.ControlMeasureDataSet.ControlMeasurePollutantHistory)
                        Catch ex As Exception
                            If (InStr(ex.Message, "unique") > 0 Or InStr(ex.Message, "duplicate") > 0) Then
                                changedNotes.Append("Duplication error.")
                            Else
                                GlobalMethods.HandleError(ex)
                                changedNotes.Append("An error occurred:  " & ex.Message)
                            End If
                        End Try
                    End If
                End If
            Next

        Catch ex As Exception
            If (InStr(ex.Message, "unique") > 0 Or InStr(ex.Message, "duplicate") > 0) Then
                changedNotes.Append("Duplication error!")
            Else
                GlobalMethods.HandleError(ex)
                changedNotes.Append("An error occurred:  " & ex.Message)
            End If
        End Try

        If (changedNotes.Length > 0) Then
            If (updateNotes.Length = 0) Then
                changedNotes.Insert(0, e92TControlIdentifier)
            End If
            updateNotes.Append(changedNotes.ToString)
        End If

    End Sub

    Private Sub WriteChangeNote(ByVal column As ControlMeasureHelper.ColumnEnum, ByVal oldValue As String, ByVal newValue As String, ByVal notesToAddTo As StringBuilder)

        With notesToAddTo
            .AppendLine()
            .Append(vbTab)
            Select Case column
                Case ControlMeasureHelper.ColumnEnum.ControlMeasureDescription
                    .AppendLine(ControlMeasureDataSet.ControlMeasure.ControlMeasureDescriptionColumn.ColumnName)

                Case ControlMeasureHelper.ColumnEnum.ControlMeasureTypeID
                    .AppendLine(ControlMeasureDataSet.ControlMeasure.ControlMeasureTypeIDColumn.ColumnName)

                Case ControlMeasureHelper.ColumnEnum.CompanyComment
                    .AppendLine(ControlMeasureDataSet.ControlMeasure.CompanyCommentColumn.ColumnName)
            End Select

            .Append(vbTab)
            .Append("Old value: ")
            .AppendLine(oldValue)
            .Append(vbTab)
            .Append("New value: ")
            .AppendLine(newValue)
        End With

    End Sub

    Private Sub WriteChangeNote(ByVal pollutantName As String, ByVal oldValue As String, ByVal newValue As String, ByVal notesToAddTo As StringBuilder)

        With notesToAddTo
            .AppendLine()
            .Append(vbTab)

            .Append(ControlMeasureDataSet.ControlMeasurePollutant.ReductionEfficiencyColumn.ColumnName)
            .Append(Space(1))
            .Append(Tools.Constants.Character.MinusSign)
            .Append(Space(1))
            .AppendLine(pollutantName)

            .Append(vbTab)
            .Append("Old value: ")
            .AppendLine(oldValue)
            .Append(vbTab)
            .Append("New value: ")
            .AppendLine(newValue)
        End With

    End Sub

    Private Function CreateHistoryRow_ControlMeasure(ByVal originalRow As ControlMeasureDataSet.ControlMeasureRow) As ControlMeasureDataSet.ControlMeasureHistoryRow

        Dim controlMeasureHistory As ControlMeasureDataSet.ControlMeasureHistoryRow = Me.ControlMeasureDataSet.ControlMeasureHistory.NewControlMeasureHistoryRow

        With controlMeasureHistory
            .ControlMeasureID = originalRow.ControlMeasureID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID

            If (originalRow.IsControlMeasureDescriptionNull) Then
                .SetControlMeasureDescriptionNull()
            Else
                .ControlMeasureDescription = originalRow.ControlMeasureDescription
            End If

            .PlantID = originalRow.PlantID

            .ControlMeasureTypeID = originalRow.ControlMeasureTypeID
            .ControlMeasureAPCDID = originalRow.ControlMeasureAPCDID

            .BeginDate = originalRow.BeginDate

            If (originalRow.IsEndDateNull) Then
                .SetEndDateNull()
            Else
                .EndDate = originalRow.EndDate
            End If

            If (originalRow.IsCompanyCommentNull) Then
                .SetCompanyCommentNull()
            Else
                .CompanyComment = originalRow.CompanyComment
            End If

            If (originalRow.IsAPCDCommentNull) Then
                .SetAPCDCommentNull()
            Else
                .APCDComment = originalRow.APCDComment
            End If

        End With

        Return controlMeasureHistory

    End Function

    Private Function CreateHistoryRow_ControlMeasurePollutant(ByVal originalRow As ControlMeasureDataSet.ControlMeasurePollutantRow) As ControlMeasureDataSet.ControlMeasurePollutantHistoryRow

        Dim controlMeasurePollutantHistory As ControlMeasureDataSet.ControlMeasurePollutantHistoryRow = Me.ControlMeasureDataSet.ControlMeasurePollutantHistory.NewControlMeasurePollutantHistoryRow

        With controlMeasurePollutantHistory
            .ControlMeasurePollutantID = originalRow.ControlMeasurePollutantID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ReductionEfficiency = originalRow.ReductionEfficiency
        End With

        Return controlMeasurePollutantHistory

    End Function

  
#End Region '----- import methods -----

#Region "----- import report -----"

    Private Sub WriteImportReportHeader(ByVal sourceFile As IO.FileInfo)

        Me.m_mainImportLog = New StringBuilder

        With Me.m_mainImportLog
            .AppendLine("******************************************************************************************")
            .AppendLine("Form 92T Import Report")
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
                Case SheetNameEnum.Controls
                    .Append(SheetName.Controls)
                    .Append(": ")
            End Select

            .AppendLine(CStr(addedRowCount))
            .AppendLine("----------------------------------------------------------------------")
            .AppendLine(addedRows.ToString)

            .AppendLine("----------------------------------------------------------------------")
            .Append("Modified ")

            Select Case type
                Case SheetNameEnum.Controls
                    .Append(SheetName.Controls)
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

#End Region '----- import report -----

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class