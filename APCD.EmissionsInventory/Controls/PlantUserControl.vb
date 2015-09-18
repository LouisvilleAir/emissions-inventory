Public Class PlantUserControl

#Region "----- Properties -----"

    'object variables
    Private m_emissionYear As EmissionsDataSet.EmissionYearRow
    Private m_plant As EmissionsDataSet.PlantRow
    Private m_plantYear As EmissionsDataSet.PlantYearRow

    Dim m_buttonMode As GlobalVariables.ButtonMode

    Private m_controlIsLoaded As Boolean
    Public Property ControlIsLoaded() As Boolean
        Get
            Return m_controlIsLoaded
        End Get
        Set(ByVal value As Boolean)
            m_controlIsLoaded = value
        End Set
    End Property

    Private m_distinctPollutantIDs As Hashtable

#End Region '----- Properties -----

    Private Sub PlantUserControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
    End Sub

    Friend Sub LoadObjectVariables(ByVal emissionYear As EmissionsDataSet.EmissionYearRow, ByVal plant As EmissionsInventory.EmissionsDataSet.PlantRow, ByVal plantYear As EmissionsDataSet.PlantYearRow, ByVal buttonMode As GlobalVariables.ButtonMode)

        Me.m_emissionYear = emissionYear
        Me.m_plant = plant
        Me.m_plantYear = plantYear
        Me.m_buttonMode = buttonMode

    End Sub

    Friend Sub LoadControls()

        With Me.m_plant
            Me.PlantNameTextBox.Text = .PlantName
            Me.PlantIDTextBox.Text = CStr(.PlantID)
            Me.PlantDescriptionTextBox.Text = .PlantDescription
        End With

        If (Me.m_buttonMode = GlobalVariables.ButtonMode.Processes) Then
            Me.btnViewEmissionsSummaryGrid.Visible = True
        Else
            Me.btnViewEmissionsSummaryGrid.Visible = False
        End If

        Me.TabControl1.Visible = False
        Me.ColumnSortLabel.Visible = False

    End Sub

    Private Sub btnViewEmissionsSummaryGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewEmissionsSummaryGrid.Click
        Me.lblLoading.Visible = True
        Call Me.LoadGridAndOtherValues()
        Me.lblLoading.Visible = False
    End Sub

    Private Sub LoadGridAndOtherValues()

        If (Me.m_buttonMode = GlobalVariables.ButtonMode.Processes) Then
            My.Application.DoEvents()
            Call Me.DisplayEmissionsSummary()
            Call Me.LoadTableOfDistinctNegativePollutants()

            Me.TabControl1.Visible = True
            Me.ColumnSortLabel.Visible = True
        End If

    End Sub

    Private Sub DisplayEmissionsSummary()

        Me.RptPlantEmissionsSummaryV2TableAdapter.FillByPlantID_EmissionYear(Me.EmissionsDataSet.rptPlantEmissionsSummaryV2, Me.m_plant.PlantID, Me.m_emissionYear.EmissionYear)
        Call Me.ComputeAndDisplayTotalHAPS()

    End Sub

    Private Sub LoadTableOfDistinctNegativePollutants()

        Dim tempTable As New EmissionsDataSet.rptPlantEmissionsDataTable
        Me.RptPlantEmissionsTableAdapter.FillByPlantID_EmissionYear(tempTable, Me.m_Plant.PlantID, Me.m_EmissionYear.EmissionYear)

        Dim filter As String = "EmissionValue <= 0"
        Dim negativePollutants() As EmissionsDataSet.rptPlantEmissionsRow = CType(tempTable.Select(filter), EmissionsInventory.EmissionsDataSet.rptPlantEmissionsRow())
        Me.m_distinctPollutantIDs = New Hashtable
        For Each row As EmissionsDataSet.rptPlantEmissionsRow In negativePollutants
            Try
                Me.m_distinctPollutantIDs.Add(row.PollutantID, row.PollutantName)
            Catch ex As Exception
                Dim _trash As String = ex.Message
            End Try
        Next

    End Sub

    Private Sub ComputeAndDisplayTotalHAPS()

        Dim total As Double = 0
        Dim expression As String = "Sum(SumOfEmissionValue)"
        Dim filter As String = "PollutantTypeEISID='HAP'"
        Dim obj As Object = Me.EmissionsDataSet.rptPlantEmissionsSummaryV2.Compute(expression, filter)
        If (IsNumeric(obj)) Then
            total = CDbl(obj) / 2000
        End If
        Me.lblTotalHAPS.Text = "Total HAPS: " & Format(Math.Round(total, 2), "#0,0.00")

    End Sub

    Private Sub RptPlantEmissionsSummaryV2DataGridView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RptPlantEmissionsSummaryV2DataGridView.Click
        If (Not Me.RptPlantEmissionsSummaryV2DataGridView.CurrentRow Is Nothing) Then
            Call Me.DisplaySummaryPollutants()
        End If
    End Sub

    Private Sub RptPlantEmissionsSummaryV2DataGridView_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RptPlantEmissionsSummaryV2DataGridView.SelectionChanged
        If (Not Me.RptPlantEmissionsSummaryV2DataGridView.CurrentRow Is Nothing) Then
            Call Me.DisplaySummaryPollutants()
        End If
    End Sub

    Private Sub DisplaySummaryPollutants()
        If (Me.ControlIsLoaded = True) Then
            Dim selectedRow As DataGridViewRow = Me.RptPlantEmissionsSummaryV2DataGridView.Rows(Me.RptPlantEmissionsSummaryV2DataGridView.CurrentRow.Index)
            Dim pollutantID As Int32 = CInt(selectedRow.Cells(5).Value) ' Changed from 4 due to moving pollutant type to first column. 20150813 BJF
            Me.RptPlantEmissionsTableAdapter.FillByPlantID_EmissionYear_PollutantID(Me.EmissionsDataSet.rptPlantEmissions, Me.m_Plant.PlantID, Me.m_EmissionYear.EmissionYear, pollutantID)
        End If
    End Sub

    Private Sub RptPlantEmissionsDataGridView_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles RptPlantEmissionsDataGridView.CellFormatting

        If (Me.RptPlantEmissionsDataGridView.Columns(e.ColumnIndex).HeaderText = "Value") Then
            Dim value As Object = e.Value
            If (IsNumeric(value)) Then
                If (CDbl(value) = -1) Then
                    Me.RptPlantEmissionsDataGridView.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
                End If
            End If
        End If

    End Sub

    Private Sub RptPlantEmissionsSummaryV2DataGridView_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles RptPlantEmissionsSummaryV2DataGridView.CellFormatting

        If (Me.RptPlantEmissionsSummaryV2DataGridView.Columns(e.ColumnIndex).HeaderText = "Pollutant") Then
            Dim value As String = CStr(e.Value)
            For Each de As DictionaryEntry In Me.m_distinctPollutantIDs
                If (de.Value.ToString = value) Then
                    Me.RptPlantEmissionsSummaryV2DataGridView.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
        End If
    End Sub

    Private Sub RptPlantEmissionsSummaryV2DataGridView_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles RptPlantEmissionsSummaryV2DataGridView.ColumnHeaderMouseClick
        'Me.RptPlantEmissionsDataGridView.Rows.Clear()
    End Sub


End Class
