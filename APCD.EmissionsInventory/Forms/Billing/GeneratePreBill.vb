Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Text

Public Class GeneratePreBill

    Public Sub New(ByVal emissionYear As Int16)
        InitializeComponent()
        Me.m_emissionYear = emissionYear
    End Sub


    'todo 20121212: ultimately route files create to S:\Emissions Inventory\Billing; once approved, generate email to send to company then auto-load into DM with base keywords.

    'todo 20130215: automate updating billing contact info from Hansen before generating the db record for pre-bill
    'todo 20130215: automate updating billing contact info from Hansen before generating the db record for bill


    Private m_emissionYear As Int16

    Private m_exceptionLog As StringBuilder
    Private m_exceptionDetailLog As StringBuilder
    Private m_exceptionLogFile As IO.FileInfo

    Private Structure DestinationDirectory
        Friend Shared Development As String = GlobalVariables.ApplicationDataDirectory & "\Invoices\"
        Const Production As String = "S:\Emissions Inventory\Billing\Invoices\"
    End Structure


    Private m_billingFeeConfig As EmissionsDataSet.BillingFeeConfigRow

    Private Enum PollutantEnum
        NH3 = 597
        NO2 = 602
        PM10 = 611
        PMC = 616
        SO2 = 621
        VOC = 624
    End Enum

    Private Structure PollutantName
        Const VOC As String = "VOC"
        Const PMCondensable As String = "PM Condensable"
        Const PM10Filterable As String = "PM10 Filterable"
        Const NOX As String = "NOX"
        Const SO2 As String = "SO2"
        Const HAPS As String = "HAPS"
        Const NH3 As String = "NH3"
    End Structure

#Region "----- member variables -----"

    Private wordApp As Word.Application
    Private wordDoc As Word.Document
    Private wordSelection As Word.Selection 'represents the current selection in a window or pane

    Private Structure BookMark
        Private _trash As String
        Public Const addressLine1 As String = "addressLine1"
        Public Const addressLine2 As String = "addressLine2"
        Public Const dueDate As String = "dueDate"
        Public Const plantID1 As String = "plantID1"
        Public Const plantID2 As String = "plantID2"
        Public Const plantName As String = "plantName"
        Public Const printDate As String = "printDate"
        Public Const billingContact As String = "billingContact"

        Public Const fiscalYear As String = "fiscalYear"
        Public Const emissionYear1 As String = "emissionYear1"
        Public Const emissionYear2 As String = "emissionYear2"
        Public Const responseDate As String = "responseDate"

        Public Const plantName2 As String = "plantName2"
        Public Const grandTotal As String = "grandTotal"

        Public Const STARBillTotal As String = "STARBillTotal"
        Public Const STARBaseFee As String = "STARBaseFee"
        Public Const STAREmissionHAPs As String = "STAREmissionHAPs"
        Public Const STAREmissionNH3 As String = "STAREmissionNH3"
        Public Const STAREmissionTotal As String = "STAREmissionTotal"
        Public Const STARFee As String = "STARFee"
        Public Const STARFeeConstant As String = "STARFeeConstant"

        Public Const TVBillTotal As String = "TVBillTotal"
        Public Const TVEmissionHAPs As String = "TVEmissionHAPs"
        Public Const TVEmissionNO2 As String = "TVEmissionNO2"
        Public Const TVEmissionPMC As String = "TVEmissionPMC"
        Public Const TVEmissionPM10 As String = "TVEmissionPM10"
        Public Const TVEmissionSO2 As String = "TVEmissionSO2"
        Public Const TVEmissionTotal As String = "TVEmissionTotal"
        Public Const TVEmissionVOC As String = "TVEmissionVOC"
        Public Const TVFee As String = "TVFee"
        Public Const TVFeeConstant As String = "TVFeeConstant"

    End Structure

    Private Class Invoice
        Private _trash As String
        Public TVEmissionVOC As Double
        Public TVEmissionPMC As Double
        Public TVEmissionPM10 As Double
        Public TVEmissionNO2 As Double
        Public TVEmissionSO2 As Double
        Public TVEmissionHAPS As Double
        Public StarHAPS As Double
        Public StarNH3 As Double
    End Class

#End Region '----- member variables -----

    Private Sub GeneratePreBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

#If DEBUG Then
        If (Not Directory.Exists(DestinationDirectory.Development)) Then
            Directory.CreateDirectory(DestinationDirectory.Development)
        End If
#End If
        Me.m_exceptionLog = New StringBuilder
        Me.m_exceptionDetailLog = New StringBuilder

        Me.BillingContactsTableAdapter.Fill(Me.EmissionsDataSet.BillingContacts)
        Me.BillingFeeConfigTableAdapter.Fill(Me.EmissionsDataSet.BillingFeeConfig)
        Me.m_billingFeeConfig = CType(Me.EmissionsDataSet.BillingFeeConfig.Rows(0), EmissionsInventory.EmissionsDataSet.BillingFeeConfigRow)

        Call FillPlantComboBox()

    End Sub

    Private Sub FillPlantComboBox()
        Try
            Dim tbl As EmissionsDataSet.PlantDataTable = New EmissionsDataSet.PlantDataTable

            Me.PlantTableAdapter.FillLookupTableByEmissionYear(tbl, Me.m_emissionYear)

            Me.PlantBindingSource.DataSource = tbl

            ' Remove non-Title V plants from the drop-down list.
            Dim filter As String = "PlantClassID=1"     ' Title V
            Me.PlantBindingSource.Filter = filter

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show("An error occurred loading the list of plants!", Me.Text)
        End Try
    End Sub

    ''' <summary>
    ''' Generate pre-bill data and pre-bill letters or generate billing records and invoices.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 2013-11-20 BJF:  Added functionality to pass selected list of plants for which to generate pre-bill letters
    '''                  or invoices.  Added option to recalcuate if calculations have already been done.
    ''' </remarks>
    Private Sub btnGenerateBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateBill.Click

        Dim selectedPlantIDs() As Integer = {}
        Dim isDoAll As Boolean = True

        If Me.rdoSelectedPlants.Checked Then
            isDoAll = False

            Dim plantCount As Integer = Me.SelectedPlantListBox.Items.Count

            If plantCount > 0 Then
                ReDim selectedPlantIDs(plantCount)
                Dim i As Integer = 0

                For Each itm As Integer In Me.SelectedPlantListBox.Items
                    selectedPlantIDs(i) = itm
                    i += 1
                Next
            Else
                MessageBox.Show("No plants selected!", Me.Text)
                ' Disable further action.
                Me.rdoActual.Checked = False
                Me.rdoAssessment.Checked = False
            End If

        End If

        If (Me.rdoActual.Checked = True) Then

            Me.BillingTableAdapter.Fill(Me.EmissionsDataSet.Billing)
            ' If no rows exist then bills have not been created yet; get the preBill data
            If (Me.EmissionsDataSet.Billing.Rows.Count = 0) Then
                Me.PreBillingTableAdapter.Fill(Me.EmissionsDataSet.PreBilling)
                If (Me.EmissionsDataSet.PreBilling.Rows.Count = 0) Then
                    MessageBox.Show("Pre-bill data does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Call Me.CreateBillRecords()
                    If (MessageBox.Show("Billing records created successfully. Create invoices now?", "Create Invoices", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                        Call Me.CreateInvoices_Bill(isDoAll, selectedPlantIDs)
                    End If
                End If
            Else
                ' Recs exist: reprint existing? modify then reprint given plant(s)
                'If (MessageBox.Show("Billing records already exist. Create invoices now?", "Create Invoices", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                '    Call Me.CreateInvoices_Bill(isDoAll, selectedPlantIDs)
                'End If
                Select Case MessageBox.Show("Billing records already exist.  Recalculate?  No = Regenerate invoices without recalculation.", "Create Invoices", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.Yes
                        Call Me.DeleteAllBillRecords()
                        Call Me.CreateBillRecords()
                        Call Me.CreateInvoices_Bill(isDoAll, selectedPlantIDs)
                    Case Windows.Forms.DialogResult.No
                        Call Me.CreateInvoices_Bill(isDoAll, selectedPlantIDs)
                    Case Else
                        Me.m_exceptionLog.AppendLine("Pre-bill generation cancelled by user.")
                End Select
            End If

        ElseIf (Me.rdoAssessment.Checked = True) Then
            Me.PreBillingTableAdapter.Fill(Me.EmissionsDataSet.PreBilling)
            If (Me.EmissionsDataSet.PreBilling.Rows.Count = 0) Then
                Call Me.CreatePreBillRecords()
                Call Me.CreateInvoices_PreBill(isDoAll, selectedPlantIDs)
            Else
                Select Case MessageBox.Show("Pre-billing records already exist.  Recalculate?  No = Regenerate pre-bills without recalculation.", "Create Pre-Bills", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.Yes
                        Call Me.DeleteAllPreBillRecords()
                        Call Me.CreatePreBillRecords()
                        Call Me.CreateInvoices_PreBill(isDoAll, selectedPlantIDs)
                    Case Windows.Forms.DialogResult.No
                        Call Me.CreateInvoices_PreBill(isDoAll, selectedPlantIDs)
                    Case Else
                        Me.m_exceptionLog.AppendLine("Pre-bill generation cancelled by user.")
                End Select
            End If
        End If

        If (Me.m_exceptionLog.Length > 0) Then
            Call Me.WriteExceptionLogFooter()
            Call Me.WriteExceptionLogToFile()
        End If

    End Sub

    Private Sub CreatePreBillRecords()

        For Each row As EmissionsDataSet.PlantRow In GlobalVariables.LookupTable.Plant
            Dim billingContact As EmissionsDataSet.BillingContactsRow = Me.EmissionsDataSet.BillingContacts.FindByPLANT_ID(row.PlantID)
            If (Not billingContact Is Nothing) Then
                Me.RptPlantEmissionsSummaryV2TableAdapter.FillByPlantID_EmissionYear(Me.EmissionsDataSet.rptPlantEmissionsSummaryV2, row.PlantID, Me.m_emissionYear)
                Call Me.AddPreBillRecord(row, billingContact)
            End If
        Next

    End Sub

    Private Sub CreateBillRecords()

        For Each row As EmissionsDataSet.PreBillingRow In Me.EmissionsDataSet.PreBilling
            Dim newInvoice As Invoice = Me.GetNewInvoiceData(row)
            If (newInvoice Is Nothing) Then
                Call Me.AddBillRecord(row)
            Else
                Call Me.AddBillRecord(row, newInvoice)
            End If
        Next

        'save to db
        Me.BillingBindingSource.EndEdit()
        Me.BillingTableAdapter.Update(Me.EmissionsDataSet.Billing)

    End Sub

    ''' <summary>
    ''' Delete all existing records from the pre-billing table.
    ''' </summary>
    ''' <remarks>
    ''' 2013-11-20 BJF: Added.
    ''' </remarks>
    Private Sub DeleteAllPreBillRecords()
        Try
            Me.EmissionsDataSet.PreBilling.Clear()

            'save to db
            Me.PreBillingBindingSource.EndEdit()
            Me.PreBillingTableAdapter.Update(Me.EmissionsDataSet.PreBilling)
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
        End Try
    End Sub

    Private Sub DeleteAllBillRecords()
        Try
            Me.EmissionsDataSet.Billing.Clear()

            'save to db
            Me.BillingBindingSource.EndEdit()
            Me.BillingTableAdapter.Update(Me.EmissionsDataSet.Billing)
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
        End Try
    End Sub

    'Returns a valid invoice if the current data is different than the preBill data, otherwise returns nothing
    Private Function GetNewInvoiceData(ByVal row As EmissionsDataSet.PreBillingRow) As Invoice

        Me.RptPlantEmissionsSummaryV2TableAdapter.FillByPlantID_EmissionYear(Me.EmissionsDataSet.rptPlantEmissionsSummaryV2, row.PlantID, row.EmissionYear)

        Dim newInvoice As New Invoice
        With newInvoice
            'assign the current values...
            .TVEmissionVOC = Me.GetPollutantTotal(PollutantEnum.VOC)
            .TVEmissionPMC = Me.GetPollutantTotal(PollutantEnum.PMC)
            .TVEmissionPM10 = Me.GetPollutantTotal(PollutantEnum.PM10)

            .TVEmissionNO2 = Me.GetPollutantTotal(PollutantEnum.NO2)
            If (.TVEmissionNO2 > 4000) Then
                .TVEmissionNO2 = 4000
            End If

            .TVEmissionSO2 = Me.GetPollutantTotal(PollutantEnum.SO2)
            If (.TVEmissionSO2 > 4000) Then
                .TVEmissionSO2 = 4000
            End If

            .TVEmissionHAPS = Me.CalculateTotalHAPS(True)
            If (row.PlantID = 989) Then
                .StarHAPS = 0
                .StarNH3 = 0
            Else
                .StarHAPS = Me.CalculateTotalHAPS(False)
                .StarNH3 = Me.GetPollutantTotal(PollutantEnum.NH3)
            End If

            '...now see if they are the same in the prebill, if they are return nothing
            If ((.TVEmissionHAPS = row.TVEmissionHAPS) AndAlso (.TVEmissionNO2 = row.TVEmissionNO2) AndAlso (.TVEmissionPM10 = row.TVEmissionPM10) _
               AndAlso (.TVEmissionSO2 = row.TVEmissionSO2) AndAlso (.TVEmissionVOC = row.TVEmissionVOC) _
               AndAlso (.StarHAPS = row.StarHAPS) AndAlso (.StarNH3 = row.StarNH3)) Then
                newInvoice = Nothing
            Else
                If (Me.m_exceptionDetailLog.Length = 0) Then
                    Me.m_exceptionDetailLog.AppendLine()
                    Me.m_exceptionDetailLog.AppendLine("Pollutant differences")
                    Me.m_exceptionDetailLog.AppendLine("----------------------------------------------------------------------")
                    Me.m_exceptionDetailLog.AppendLine("Plant")
                    Me.m_exceptionDetailLog.AppendLine("----------------------------------------------------------------------")
                End If

                Me.m_exceptionDetailLog.AppendLine(CStr(row.PlantID))

                Me.m_exceptionDetailLog.Append(vbTab)
                Me.m_exceptionDetailLog.AppendLine("Title V")
                Me.m_exceptionDetailLog.Append(vbTab)
                Me.m_exceptionDetailLog.AppendLine("-------------")

                If (.TVEmissionHAPS <> row.TVEmissionHAPS) Then
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.AppendLine(GeneratePreBill.PollutantName.HAPS)
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  Old Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(row.TVEmissionHAPS)))
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  New Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(.TVEmissionHAPS)))
                    Me.m_exceptionDetailLog.AppendLine()
                End If

                If (.TVEmissionNO2 <> row.TVEmissionNO2) Then
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.AppendLine(GeneratePreBill.PollutantName.NOX)
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  Old Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(row.TVEmissionNO2)))
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  New Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(.TVEmissionNO2)))
                    Me.m_exceptionDetailLog.AppendLine()
                End If

                If (.TVEmissionPM10 <> row.TVEmissionPM10) Then
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.AppendLine(GeneratePreBill.PollutantName.PM10Filterable)
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  Old Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(row.TVEmissionPM10)))
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  New Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(.TVEmissionPM10)))
                    Me.m_exceptionDetailLog.AppendLine()
                End If

                If (.TVEmissionSO2 <> row.TVEmissionSO2) Then
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.AppendLine(GeneratePreBill.PollutantName.SO2)
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  Old Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(row.TVEmissionSO2)))
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  New Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(.TVEmissionSO2)))
                    Me.m_exceptionDetailLog.AppendLine()
                End If

                If (.TVEmissionVOC <> row.TVEmissionVOC) Then
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.AppendLine(GeneratePreBill.PollutantName.VOC)
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  Old Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(row.TVEmissionVOC)))
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  New Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(.TVEmissionVOC)))
                    Me.m_exceptionDetailLog.AppendLine()
                End If

                Me.m_exceptionDetailLog.AppendLine()
                Me.m_exceptionDetailLog.Append(vbTab)
                Me.m_exceptionDetailLog.AppendLine("Star")
                Me.m_exceptionDetailLog.Append(vbTab)
                Me.m_exceptionDetailLog.AppendLine("-------------")


                If (.StarHAPS <> row.StarHAPS) Then
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.AppendLine(GeneratePreBill.PollutantName.HAPS)
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  Old Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(row.StarHAPS)))
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  New Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(.StarHAPS)))
                    Me.m_exceptionDetailLog.AppendLine()
                End If

                If (.StarNH3 <> row.StarNH3) Then
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.AppendLine(GeneratePreBill.PollutantName.NH3)
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  Old Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(row.StarNH3)))
                    Me.m_exceptionDetailLog.Append(vbTab)
                    Me.m_exceptionDetailLog.Append("  New Value:")
                    Me.m_exceptionDetailLog.AppendLine(String.Format("{0,10}", FormatNumber(.StarNH3)))
                    Me.m_exceptionDetailLog.AppendLine()
                End If
                Me.m_exceptionDetailLog.AppendLine("----------------------------------------------------------------------")

            End If
        End With

        Return (newInvoice)

    End Function

    Private Sub AddPreBillRecord(ByVal row As EmissionsDataSet.PlantRow, ByVal billingContact As EmissionsDataSet.BillingContactsRow)

        'Sam Meyer (989) should not have STAR fees, only TV emission fees
        '4000 ton billable limit per pollutant (i.e. Mill Creek and Cane Run)

        Dim preBill As EmissionsDataSet.PreBillingRow = Me.EmissionsDataSet.PreBilling.NewPreBillingRow
        With preBill
            Dim id As Guid = Guid.NewGuid
            .PreBillingID = id.ToString()
            .PlantID = row.PlantID
            .PlantName = row.PlantName
            .EmissionYear = Me.m_emissionYear
            .PrintDate = Now.Date
            .FirstName = StrConv(billingContact.CNTCTFIRST, vbProperCase)
            .LastName = StrConv(billingContact.CNTCTLAST, vbProperCase)
            .Address = StrConv(billingContact.ADDR1, vbProperCase)
            .City = StrConv(billingContact.CITY, vbProperCase)
            .State = billingContact.STATE
            .Zip = billingContact.ZIP.Substring(0, 5)

            .TVEmissionVOC = Me.GetPollutantTotal(PollutantEnum.VOC)
            .TVEmissionPMC = Me.GetPollutantTotal(PollutantEnum.PMC)
            .TVEmissionPM10 = Me.GetPollutantTotal(PollutantEnum.PM10)

            .TVEmissionNO2 = Me.GetPollutantTotal(PollutantEnum.NO2)
            If (.TVEmissionNO2 > 4000) Then
                .TVEmissionNO2 = 4000
            End If

            .TVEmissionSO2 = Me.GetPollutantTotal(PollutantEnum.SO2)
            If (.TVEmissionSO2 > 4000) Then
                .TVEmissionSO2 = 4000
            End If

            .TVEmissionHAPS = Me.CalculateTotalHAPS(True)

            .TVEmissionTotal = Me.CalculateTVEmissionTotal(.TVEmissionHAPS, .TVEmissionNO2, .TVEmissionPMC, .TVEmissionPM10, .TVEmissionSO2, .TVEmissionVOC)
            .TVBillTotal = Me.CalculateTVBillTotal(.TVEmissionTotal)

            If (.PlantID = 989) Then
                .StarHAPS = 0
                .StarNH3 = 0
            Else
                .StarHAPS = Me.CalculateTotalHAPS(False)
                .StarNH3 = Me.GetPollutantTotal(PollutantEnum.NH3)
            End If

            .STAREmissionTotal = Me.CalculateSTAREmissionTotal(.StarHAPS, .StarNH3)
            .STARBillTotal = Me.CalculateSTARBillTotal(.STAREmissionTotal)

            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With
        Me.EmissionsDataSet.PreBilling.Rows.Add(preBill)

    End Sub

    Private Sub AddBillRecord(ByVal row As EmissionsDataSet.PreBillingRow)

        'get the latest latestBillingContact info for this plant
        Dim latestBillingContact As EmissionsDataSet.BillingContactsRow = Me.EmissionsDataSet.BillingContacts.FindByPLANT_ID(row.PlantID)


        Dim bill As EmissionsDataSet.BillingRow = Me.EmissionsDataSet.Billing.NewBillingRow
        With bill
            Dim id As Guid = Guid.NewGuid
            .BillingID = id.ToString()
            .PlantID = row.PlantID
            .PlantName = row.PlantName
            .EmissionYear = row.EmissionYear
            .PrintDate = Date.Now.Date

            .FirstName = StrConv(latestBillingContact.CNTCTFIRST, vbProperCase)
            .LastName = StrConv(latestBillingContact.CNTCTLAST, vbProperCase)
            .Address = StrConv(latestBillingContact.ADDR1, vbProperCase)
            .City = StrConv(latestBillingContact.CITY, vbProperCase)
            .State = latestBillingContact.STATE
            .Zip = latestBillingContact.ZIP.Substring(0, 5)

            .TVEmissionVOC = row.TVEmissionVOC
            .TVEmissionPMC = row.TVEmissionPMC
            .TVEmissionPM10 = row.TVEmissionPM10
            .TVEmissionNO2 = row.TVEmissionNO2
            .TVEmissionSO2 = row.TVEmissionSO2
            .TVEmissionHAPS = row.TVEmissionHAPS

            .TVEmissionTotal = row.TVEmissionTotal
            .TVBillTotal = row.TVBillTotal

            .StarHAPS = row.StarHAPS
            .StarNH3 = row.StarNH3

            .STAREmissionTotal = row.STAREmissionTotal
            .STARBillTotal = row.STARBillTotal

            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With
        Me.EmissionsDataSet.Billing.Rows.Add(bill)

    End Sub

    Private Sub AddBillRecord(ByVal row As EmissionsDataSet.PreBillingRow, ByVal newInvoice As Invoice)

        'get the latest latestBillingContact info for this plant
        Dim latestBillingContact As EmissionsDataSet.BillingContactsRow = Me.EmissionsDataSet.BillingContacts.FindByPLANT_ID(row.PlantID)

        If (Me.m_exceptionLog.Length = 0) Then
            Call Me.WriteExceptionLogHeader()
        End If

        Dim bill As EmissionsDataSet.BillingRow = Me.EmissionsDataSet.Billing.NewBillingRow
        With bill
            Dim id As Guid = Guid.NewGuid
            .BillingID = id.ToString()
            .PlantID = row.PlantID
            .PlantName = row.PlantName
            .EmissionYear = row.EmissionYear
            .PrintDate = Date.Now.Date

            .FirstName = StrConv(latestBillingContact.CNTCTFIRST, vbProperCase)
            .LastName = StrConv(latestBillingContact.CNTCTLAST, vbProperCase)
            .Address = StrConv(latestBillingContact.ADDR1, vbProperCase)
            .City = StrConv(latestBillingContact.CITY, vbProperCase)
            .State = latestBillingContact.STATE
            .Zip = latestBillingContact.ZIP.Substring(0, 5)

            .TVEmissionVOC = newInvoice.TVEmissionVOC
            .TVEmissionPMC = newInvoice.TVEmissionPMC

            .TVEmissionPM10 = newInvoice.TVEmissionPM10
            .TVEmissionNO2 = newInvoice.TVEmissionNO2
            .TVEmissionSO2 = newInvoice.TVEmissionSO2
            .TVEmissionHAPS = newInvoice.TVEmissionHAPS
            .TVEmissionTotal = Me.CalculateTVEmissionTotal(.TVEmissionHAPS, .TVEmissionNO2, .TVEmissionPMC, .TVEmissionPM10, .TVEmissionSO2, .TVEmissionVOC)
            .TVBillTotal = Me.CalculateTVBillTotal(.TVEmissionTotal)

            .StarHAPS = newInvoice.StarHAPS
            .StarNH3 = newInvoice.StarNH3
            .STAREmissionTotal = Me.CalculateSTAREmissionTotal(.StarHAPS, .StarNH3)
            .STARBillTotal = Me.CalculateSTARBillTotal(.STAREmissionTotal)

            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With
        Me.EmissionsDataSet.Billing.Rows.Add(bill)

        Call Me.WriteExcpetionLogItem(row.PlantID, row.TVBillTotal, bill.TVBillTotal, row.STARBillTotal, bill.STARBillTotal)

    End Sub

    Private Sub WriteExcpetionLogItem(ByVal plantID As Int32, ByVal oldTitleVTotal As Double, ByVal newTitleVTotal As Double, ByVal oldStarTotal As Double, ByVal newStarTotal As Double)

        Dim plantValue As String = String.Format("{0,5}", plantID)
        Dim old As String = "Old Value"
        Dim neww As String = "New Value"

        Dim oldValueLabel As String = String.Format("{0,-9}", old)
        Dim newValueLabel As String = String.Format("{0,-9}", neww)

        Dim oldTitleVTotalLabel As String = String.Format("{0,11}", FormatCurrency(oldTitleVTotal))
        Dim newTitleVTotalLabel As String = String.Format("{0,11}", FormatCurrency(newTitleVTotal))

        Dim oldStarTotalLabel As String = String.Format("{0,10}", FormatCurrency(oldStarTotal))
        Dim newStarTotalLabel As String = String.Format("{0,10}", FormatCurrency(newStarTotal))

        With Me.m_exceptionLog
            .Append(plantValue)
            .Append(Space(3))

            .Append(oldValueLabel)
            .Append(Space(4))

            If (oldTitleVTotal = newTitleVTotal) Then
                .Append(Space(11))
            Else
                .Append(oldTitleVTotalLabel)
            End If
            .Append(Space(4))

            If (oldStarTotal = newStarTotal) Then
                .AppendLine()
            Else
                .AppendLine(oldStarTotalLabel)
            End If

            .Append(Space(8))

            .Append(newValueLabel)
            .Append(Space(4))

            If (oldTitleVTotal = newTitleVTotal) Then
                .Append(Space(11))
            Else
                .Append(newTitleVTotalLabel)
            End If
            .Append(Space(4))

            If (oldStarTotal = newStarTotal) Then
                .AppendLine()
            Else
                .AppendLine(newStarTotalLabel)
            End If

            .AppendLine()
        End With

    End Sub

    Private Function GetPollutantTotal(ByVal pollutant As PollutantEnum) As Double

        Dim total As Double

        Dim filter As String = "PollutantID = " & CStr(CInt(pollutant))
        Dim rows() As EmissionsDataSet.rptPlantEmissionsSummaryV2Row = CType(Me.EmissionsDataSet.rptPlantEmissionsSummaryV2.Select(filter), EmissionsInventory.EmissionsDataSet.rptPlantEmissionsSummaryV2Row())
        If (rows.Count > 0) Then
            total = Math.Round(CDbl(rows(0)("SumOfEmissionValue")), 2)
        Else
            total = 0
        End If

        Return total

    End Function

    Private Function CalculateTotalHAPS(ByVal isTitleV As Boolean) As Double

        Dim filter As String = "PollutantTypeEISID = 'HAP'"
        If (isTitleV = True) Then filter &= "AND IsTitleVBillable = True"

        Dim expression As String = "Sum(SumOfEmissionValue)"
        Dim total As Double = -1

        Dim obj As Object = Me.EmissionsDataSet.rptPlantEmissionsSummaryV2.Compute(expression, filter)
        If (IsNumeric(obj)) Then
            total = CDbl(obj)
        End If

        Return Math.Round((total / 2000), 2)

    End Function

    Private Sub WriteBookmark(ByVal strBookMarkName As String, ByVal strDataToWrite As String)

        With Me.wordSelection
            .GoTo(Word.WdGoToItem.wdGoToBookmark, , , CType(strBookMarkName, Object))
            '.Font.Bold = Word.WdConstants.wdToggle 'research this
            .TypeText(strDataToWrite)
        End With

    End Sub

    Private Sub CreateInvoices_PreBill(Optional ByVal isDoAll As Boolean = True, Optional ByVal plantList As Integer() = Nothing)

#If DEBUG Then
        Dim templateFullName As String = GlobalVariables.TemplateDirectory.Development & GlobalVariables.TemplateName.PreBill
#Else
        Dim templateFullName As String = GlobalVariables.TemplateDirectory.Production & GlobalVariables.TemplateName.PreBill
#End If

        Me.wordApp = New Word.Application
        Cursor.Current = Cursors.WaitCursor

        If isDoAll = False Then
            ' Sort the list of selected plants.
            If plantList.Length > 1 Then
                Array.Sort(plantList)
            End If
        End If

        Try
            For Each preBill As EmissionsDataSet.PreBillingRow In Me.EmissionsDataSet.PreBilling

                If isDoAll OrElse Array.BinarySearch(plantList, preBill.PlantID) > 0 Then

                    Me.wordDoc = Me.wordApp.Documents.Add(CType(templateFullName, Object))
                    Me.wordSelection = Me.wordApp.Selection

                    With preBill
                        Me.WriteBookmark(BookMark.printDate, Format(.PrintDate, GlobalVariables.DateFormat._Short))
                        Me.WriteBookmark(BookMark.plantID1, CStr(.PlantID))
                        Me.WriteBookmark(BookMark.plantName, .PlantName)
                        Me.WriteBookmark(BookMark.addressLine1, .Address)
                        Me.WriteBookmark(BookMark.addressLine2, .City & ", " & .State & " " & .Zip)
                        Me.WriteBookmark(BookMark.billingContact, .FirstName & " " & .LastName)

                        Me.WriteBookmark(BookMark.fiscalYear, CStr(.EmissionYear + 2))
                        Me.WriteBookmark(BookMark.emissionYear1, CStr(.EmissionYear))

                        Dim responseDate As Date = .PrintDate.AddDays(30)
                        Me.WriteBookmark(BookMark.responseDate, Format(responseDate, GlobalVariables.DateFormat._Short))

                        Me.WriteBookmark(BookMark.emissionYear2, CStr(.EmissionYear))
                        Me.WriteBookmark(BookMark.plantID2, CStr(.PlantID))
                        Me.WriteBookmark(BookMark.plantName2, CStr(.PlantName))

                        'TV
                        Me.WriteBookmark(BookMark.TVEmissionVOC, Format(.TVEmissionVOC, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVEmissionPMC, Format(.TVEmissionPMC, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVEmissionPM10, Format(.TVEmissionPM10, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVEmissionNO2, Format(.TVEmissionNO2, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVEmissionSO2, Format(.TVEmissionSO2, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVEmissionHAPs, Format(.TVEmissionHAPS, GlobalVariables.NumberFormat.Standard))

                        Me.WriteBookmark(BookMark.TVEmissionTotal, Format(.TVEmissionTotal, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVFee, Format(.TVBillTotal, GlobalVariables.NumberFormat.Currency))
                        Me.WriteBookmark(BookMark.TVBillTotal, Format(.TVBillTotal, GlobalVariables.NumberFormat.Currency))
                        Me.WriteBookmark(BookMark.TVFeeConstant, Format(Me.m_billingFeeConfig.TVFeeConstant, GlobalVariables.NumberFormat.Currency))

                        'STAR
                        Me.WriteBookmark(BookMark.STAREmissionHAPs, Format(.StarHAPS, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.STAREmissionNH3, Format(.StarNH3, GlobalVariables.NumberFormat.Standard))

                        Me.WriteBookmark(BookMark.STAREmissionTotal, Format(.STAREmissionTotal, GlobalVariables.NumberFormat.Standard))

                        If (.PlantID = 989) Then
                            .STARBillTotal = 0
                        End If
                        Me.WriteBookmark(BookMark.STARFee, Format(.STARBillTotal, GlobalVariables.NumberFormat.Currency))
                        Me.WriteBookmark(BookMark.STARBillTotal, Format(.STARBillTotal, GlobalVariables.NumberFormat.Currency))
                        Me.WriteBookmark(BookMark.STARBaseFee, Format(Me.m_billingFeeConfig.STARBaseFee, GlobalVariables.NumberFormat.Currency))
                        Me.WriteBookmark(BookMark.STARFeeConstant, Format(Me.m_billingFeeConfig.STARFeeConstant, GlobalVariables.NumberFormat.Currency))

                        Dim grandTotal As Double = .TVBillTotal + .STARBillTotal
                        Me.WriteBookmark(BookMark.grandTotal, Format(grandTotal, GlobalVariables.NumberFormat.Currency))

                    End With

                    Dim filename As Object = Me.CreateFileName(preBill)
                    'Me.wordDoc.SaveAs(filename)
                    Me.wordDoc.ExportAsFixedFormat(CStr(filename), Word.WdExportFormat.wdExportFormatPDF)
                    Me.wordDoc.Close(False)
                    Me.wordDoc = Nothing

                End If

            Next

            Me.Save() ' Save here. That way we know that all docs were printed that correspond to the data.
            MessageBox.Show("Pre-bill invoices created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.wordDoc = Nothing
            Me.wordApp = Nothing
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub CreateInvoices_Bill(Optional ByVal isDoAll As Boolean = True, Optional ByVal plantList As Integer() = Nothing)
        ' When practical, we should send out and reconcile the pre-bills before we make our final data submittal to the EPA.
        ' Once all of the companies agree to their bill, we can then print the final bill and make our final data submittal.

#If DEBUG Then
        Dim templateFullName As String = GlobalVariables.TemplateDirectory.Development & GlobalVariables.TemplateName.Bill
#Else
        Dim templateFullName As String = GlobalVariables.TemplateDirectory.Production & GlobalVariables.TemplateName.Bill
#End If

        Cursor.Current = Cursors.WaitCursor
        Me.wordApp = New Word.Application

        If isDoAll = False Then
            ' Sort the list of selected plants.
            If plantList.Length > 1 Then
                Array.Sort(plantList)
            End If
        End If

        Try
            For Each bill As EmissionsDataSet.BillingRow In Me.EmissionsDataSet.Billing

                If isDoAll OrElse Array.BinarySearch(plantList, bill.PlantID) > 0 Then

                    Me.wordDoc = Me.wordApp.Documents.Add(CType(templateFullName, Object))
                    Me.wordSelection = Me.wordApp.Selection

                    With bill
                        Me.WriteBookmark(BookMark.printDate, Format(.PrintDate, GlobalVariables.DateFormat._Short))
                        Me.WriteBookmark(BookMark.plantID1, CStr(.PlantID))
                        Me.WriteBookmark(BookMark.plantName, .PlantName)
                        Me.WriteBookmark(BookMark.addressLine1, .Address)
                        Me.WriteBookmark(BookMark.addressLine2, .City & ", " & .State & " " & .Zip)
                        Me.WriteBookmark(BookMark.billingContact, .FirstName & " " & .LastName)

                        'Me.WriteBookmark(BookMark.fiscalYear, CStr(.EmissionYear + 2))
                        Me.WriteBookmark(BookMark.emissionYear1, CStr(.EmissionYear))

                        Dim dueDate As Date = .PrintDate.AddDays(45)
                        Me.WriteBookmark(BookMark.dueDate, Format(dueDate, GlobalVariables.DateFormat._Short))

                        Me.WriteBookmark(BookMark.emissionYear2, CStr(.EmissionYear))
                        Me.WriteBookmark(BookMark.plantID2, CStr(.PlantID))
                        Me.WriteBookmark(BookMark.plantName2, CStr(.PlantName))

                        'TV
                        Me.WriteBookmark(BookMark.TVEmissionVOC, Format(.TVEmissionVOC, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVEmissionPMC, Format(.TVEmissionPMC, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVEmissionPM10, Format(.TVEmissionPM10, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVEmissionNO2, Format(.TVEmissionNO2, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVEmissionSO2, Format(.TVEmissionSO2, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVEmissionHAPs, Format(.TVEmissionHAPS, GlobalVariables.NumberFormat.Standard))

                        Me.WriteBookmark(BookMark.TVEmissionTotal, Format(.TVEmissionTotal, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.TVFee, Format(.TVBillTotal, GlobalVariables.NumberFormat.Currency))
                        Me.WriteBookmark(BookMark.TVBillTotal, Format(.TVBillTotal, GlobalVariables.NumberFormat.Currency))
                        Me.WriteBookmark(BookMark.TVFeeConstant, Format(Me.m_billingFeeConfig.TVFeeConstant, GlobalVariables.NumberFormat.Currency))

                        'STAR
                        Me.WriteBookmark(BookMark.STAREmissionHAPs, Format(.StarHAPS, GlobalVariables.NumberFormat.Standard))
                        Me.WriteBookmark(BookMark.STAREmissionNH3, Format(.StarNH3, GlobalVariables.NumberFormat.Standard))

                        Me.WriteBookmark(BookMark.STAREmissionTotal, Format(.STAREmissionTotal, GlobalVariables.NumberFormat.Standard))
                        If (.PlantID = 989) Then
                            .STARBillTotal = 0
                        End If
                        Me.WriteBookmark(BookMark.STARFee, Format(.STARBillTotal, GlobalVariables.NumberFormat.Currency))
                        Me.WriteBookmark(BookMark.STARBillTotal, Format(.STARBillTotal, GlobalVariables.NumberFormat.Currency))
                        Me.WriteBookmark(BookMark.STARBaseFee, Format(Me.m_billingFeeConfig.STARBaseFee, GlobalVariables.NumberFormat.Currency))
                        Me.WriteBookmark(BookMark.STARFeeConstant, Format(Me.m_billingFeeConfig.STARFeeConstant, GlobalVariables.NumberFormat.Currency))

                        Dim grandTotal As Double = .TVBillTotal + .STARBillTotal
                        Me.WriteBookmark(BookMark.grandTotal, Format(grandTotal, GlobalVariables.NumberFormat.Currency))
                    End With

                    Dim filename As Object = Me.CreateFileName(bill)
                    'Me.wordDoc.SaveAs(filename)
                    Me.wordDoc.ExportAsFixedFormat(CStr(filename), Word.WdExportFormat.wdExportFormatPDF)
                    Me.wordDoc.Close(False)

                End If

            Next

            MessageBox.Show("Invoices created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            GlobalMethods.HandleError(ex)
        Finally
            Me.wordDoc = Nothing
            Me.wordApp = Nothing
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Function CalculateTVEmissionTotal(ByVal TVEmissionHAPS As Double, ByVal TVEmissionNO2 As Double, ByVal TVEmissionPMC As Double, ByVal TVEmissionPM10 As Double, ByVal TVEmissionSO2 As Double, ByVal TVEmissionVOC As Double) As Double
        Return CDbl(TVEmissionHAPS + TVEmissionNO2 + TVEmissionPMC + TVEmissionPM10 + TVEmissionSO2 + TVEmissionVOC)
    End Function

    Private Function CalculateTVBillTotal(ByVal TVEmissionTotal As Double) As Double
        Return CDbl(Math.Round(TVEmissionTotal * Me.m_billingFeeConfig.TVFeeConstant, 2))
    End Function

    Private Function CalculateSTAREmissionTotal(ByVal StarHAPS As Double, ByVal StarNH3 As Double) As Double
        Return CDbl(StarHAPS + StarNH3)
    End Function

    Private Function CalculateSTARBillTotal(ByVal STAREmissionTotal As Double) As Double
        Return CDbl(Math.Round(Me.m_billingFeeConfig.STARBaseFee + (STAREmissionTotal * Me.m_billingFeeConfig.STARFeeConstant), 2))
    End Function

    Private Function CreateFileName(ByVal preBill As EmissionsDataSet.PreBillingRow) As Object

        Dim filename As New StringBuilder
        With filename

#If DEBUG Then
            .Append(GeneratePreBill.DestinationDirectory.Development)
#Else
            .Append(GeneratePreBill.DestinationDirectory.Production)
#End If
            .Append(Tools.Constants.Character.BackSlash)
            .Append("FY ")
            .Append(CStr(preBill.EmissionYear + 2))

            'todo 20130215: user needs to be able to re-generate invoices if necessary; use this to show that it is a corrected invoice
            '.Append(" CORRECTED TV Emissions Pre-invoice -- ") 
            .Append(" TV Emissions Pre-invoice -- ")

            .Append(preBill.PlantName)
            .Append(Space(1))
            .Append(CStr(preBill.PlantID))
            '.Append(".docx")
            .Append(".pdf")
        End With

        Return filename.ToString

    End Function

    Private Function CreateFileName(ByVal bill As EmissionsDataSet.BillingRow) As Object

        Dim filename As New StringBuilder
        With filename

#If DEBUG Then
            .Append(GeneratePreBill.DestinationDirectory.Development)
#Else
            .Append(GeneratePreBill.DestinationDirectory.Production)
#End If
            .Append(Tools.Constants.Character.BackSlash)
            .Append("FY ")
            .Append(CStr(bill.EmissionYear + 2))
            .Append(" TV Emissions Invoice -- ")
            .Append(bill.PlantName)
            .Append(Space(1))
            .Append(CStr(bill.PlantID))
            '.Append(".docx")
            .Append(".pdf")
        End With

        Return filename.ToString

    End Function

    Private Sub Save()
        Me.Validate()
        Me.PreBillingBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EmissionsDataSet)

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub WriteExceptionLogHeader()

        With Me.m_exceptionLog
            .AppendLine("******************************************************************************************")
            .AppendLine("Emissions Billing Exception Report")
            .AppendLine("Fiscal Year: " & CStr(Me.m_emissionYear + 2))
            .AppendLine("Report run date: " & Format(Date.Now, "dddd MMMM dd, yyyy  HH:mm:ss"))
            .AppendLine("******************************************************************************************")
            .AppendLine()
            .AppendLine("Plant                Title V Fee      STAR Fee")
            .AppendLine("-----               --------------  ------------")
        End With

    End Sub

    Private Sub WriteExceptionLogFooter()

        With Me.m_exceptionLog
            .AppendLine()
            .AppendLine("******************************************************************************************")
        End With

    End Sub

    Private Sub WriteExceptionLogToFile()

        Dim destinationPath As String

#If DEBUG Then
        destinationPath = DestinationDirectory.Development
#Else
        destinationPath = DestinationDirectory.Production
#End If

        destinationPath &= "exceptionReport.txt"
        Dim sw As New IO.StreamWriter(destinationPath)
        sw.Write(Me.m_exceptionLog.ToString)
        sw.Write(Me.m_exceptionDetailLog.ToString)
        sw.Close()

    End Sub

    Private Sub AddPlantButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPlantButton.Click
        If Me.PlantComboBox.SelectedIndex > 0 Then
            Me.SelectedPlantListBox.Items.Add(Me.PlantComboBox.SelectedValue)
        End If
    End Sub

    Private Sub rdoSelectedPlants_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSelectedPlants.CheckedChanged
        If Me.rdoSelectedPlants.Checked Then
            Me.PlantComboBox.Enabled = True
            Me.AddPlantButton.Enabled = True
            Me.SelectedPlantListBox.Enabled = True
        Else
            Me.PlantComboBox.Enabled = False
            Me.AddPlantButton.Enabled = False
            Me.SelectedPlantListBox.Enabled = False
        End If
    End Sub

    Private Sub PlantComboBox_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles PlantComboBox.MouseDoubleClick

        Call Me.AddPlantButton_Click(sender, e)

    End Sub
End Class