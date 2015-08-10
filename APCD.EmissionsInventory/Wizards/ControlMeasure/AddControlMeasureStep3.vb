Public Class AddControlMeasureStep3

    Public Sub New(ByVal controlMeasureID As ArrayList, ByVal emissionYear As EmissionsDataSet.EmissionYearRow)
        InitializeComponent()
        Me.m_controlMeasureID = controlMeasureID
        Me.m_emissionYear = emissionYear
    End Sub

    Private m_formIsLoaded As Boolean = False
    Private m_controlMeasureID As ArrayList
    Private m_emissionYear As EmissionsDataSet.EmissionYearRow

    Private Sub AddControlMeasureStep3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.m_formIsLoaded = False
        Me.pollutantDataGridView.AutoGenerateColumns = False

        'pollutant cbo
        Dim pollutantView As DataView = GlobalVariables.LookupTable.Pollutant.DefaultView
        pollutantView.RowFilter = "LastInventoryYear IS NULL"
        Tools.WindowsForms.LoadComboBox(pollutantView, Me.PollutantComboBox)

        Call Me.SetControlDefaults()

        Me.m_formIsLoaded = True

    End Sub

    Private Sub SetControlDefaults()
        Me.PollutantComboBox.SelectedIndex = -1
        Me.percentTextBox.Text = String.Empty
        Me.ControlMeasurePollutantTableAdapter.FillByControlMeasureID_EmissionYear(Me.EmissionsDataSet.ControlMeasurePollutant, CInt(Me.m_controlMeasureID(0)), Me.m_emissionYear.EmissionYear)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If ((Me.PollutantComboBox.SelectedIndex = -1) OrElse (Me.percentTextBox.Text.Trim.Length = 0)) Then
            MessageBox.Show("Pick a pollutant and enter a % to add it to the list")
        Else
            Call Me.AddPollutant()
            Call Me.SetControlDefaults()
        End If

    End Sub

    Private Sub AddPollutant()

        Dim row As EmissionsDataSet.ControlMeasurePollutantRow = Me.EmissionsDataSet.ControlMeasurePollutant.NewControlMeasurePollutantRow
        With row
            .ControlMeasureID = CInt(Me.m_controlMeasureID(0))
            .PollutantID = CInt(Me.PollutantComboBox.SelectedValue)
            .EmissionYear = Me.m_emissionYear.EmissionYear
            .ReductionEfficiency = CDec(Me.percentTextBox.Text.Trim)
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With
        Me.EmissionsDataSet.ControlMeasurePollutant.Rows.Add(row)
        Me.ControlMeasurePollutantTableAdapter.Update(Me.EmissionsDataSet.ControlMeasurePollutant)

        Dim rowToShow As EmissionsDataSet.PollutantRow = Me.EmissionsDataSet.Pollutant.NewPollutantRow
        rowToShow.PollutantName = Me.PollutantComboBox.Text
        Me.EmissionsDataSet.Pollutant.Rows.Add(rowToShow)

        'Me.pollutantDataGridView.DataSource = Nothing
        Me.pollutantDataGridView.DataSource = Me.EmissionsDataSet.Pollutant

    End Sub

    Private Sub btnDone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub

End Class