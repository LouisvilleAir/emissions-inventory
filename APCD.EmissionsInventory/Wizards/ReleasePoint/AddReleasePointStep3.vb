Public Class AddReleasePointStep3

    Public Sub New(ByVal ds As EmissionsDataSet)
        InitializeComponent()
        Me.m_ds = ds
    End Sub

    Private m_ds As EmissionsDataSet
    Private m_releasePoint As EmissionsDataSet.ReleasePointRow
    Private m_measurements As EmissionsDataSet.ReleasePointDetailDataTable

    Private Sub AddReleasePointStep3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.MeasurementTableAdapter.Fill(Me.EmissionsDataSet.Measurement)
        Me.UnitOfMeasurementTableAdapter.Fill(Me.EmissionsDataSet.UnitOfMeasurement)

        Me.m_releasePoint = CType(Me.m_ds.ReleasePoint.Rows(0), EmissionsInventory.EmissionsDataSet.ReleasePointRow)
        Me.m_measurements = Me.m_ds.ReleasePointDetail

        If (Me.m_measurements.Rows.Count = 0) Then
            Call Me.GenerateReleasePointDetailRows(CType(Me.m_releasePoint.ReleaseTypeSubTypeID, ReleasePointHelper.ReleaseTypeSubType))
        End If
        Me.ReleasePointDetailDataGridView.DataSource = Me.m_measurements

    End Sub

#Region "----- buttons -----"

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Call Me.StepHandler(2)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Call Me.StepHandler(4)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub StepHandler(ByVal _step As Int32)

        Select Case _step
            Case 2
                GlobalVariables.AddReleasePointStep = GlobalVariables.WizardStep._Back
            Case 4
                GlobalVariables.AddReleasePointStep = GlobalVariables.WizardStep._Next
        End Select

        Me.Close()

    End Sub

#End Region '----- buttons -----

    Private Sub GenerateReleasePointDetailRows(ByVal releaseTypeSubType As ReleasePointHelper.ReleaseTypeSubType)

        Dim dtbMeasurement As DataTable = Emissions.Utility.MeasurementUtility.GetByReleaseTypeSubTypeID(releaseTypeSubType)

        For Each measurementRow As DataRow In dtbMeasurement.Rows
            Dim measurementName As String = CStr(measurementRow(Me.EmissionsDataSet.Measurement.MeasurementNameColumn.ColumnName))
            Select Case releaseTypeSubType
                Case ReleasePointHelper.ReleaseTypeSubType.Round, ReleasePointHelper.ReleaseTypeSubType.Other
                    Select Case measurementName
                        Case "Fenceline Distance"
                            'do nothing
                        Case Else
                            Call Me.AddDetailRow(measurementRow)
                    End Select
                Case ReleasePointHelper.ReleaseTypeSubType.Area, ReleasePointHelper.ReleaseTypeSubType.Point
                    Call Me.AddDetailRow(measurementRow)
            End Select
        Next

    End Sub

    Private Sub AddDetailRow(ByVal measurementRow As DataRow)

        Dim measurementName As String = CStr(measurementRow(EmissionsDataSet.Measurement.MeasurementNameColumn.ColumnName))
        Dim detailRow As EmissionsDataSet.ReleasePointDetailRow = Me.m_measurements.NewReleasePointDetailRow
        With detailRow
            .ReleasePointID = Me.m_releasePoint.ReleasePointID
            .MeasurementID = CInt(measurementRow(Me.EmissionsDataSet.Measurement.MeasurementIDColumn.ColumnName))
            .DetailValue = 0
        End With

        Select Case measurementName
            Case "Height", "Diameter", "Width", "Length"
                detailRow.UnitOfMeasurementID = 515
            Case "Exit Gas Flow Rate"
                detailRow.UnitOfMeasurementID = 659
            Case "Exit Gas Temperature"
                detailRow.UnitOfMeasurementID = 15
            Case "HorizontalAngle"
                detailRow.UnitOfMeasurementID = 14
        End Select
        Me.m_measurements.Rows.Add(detailRow)

    End Sub

End Class