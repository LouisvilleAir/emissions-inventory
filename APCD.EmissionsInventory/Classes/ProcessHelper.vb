Public Class ProcessHelper

    Friend Sub Shutdown(ByVal process As EmissionsDataSet.ProcessRow, ByVal emissionYear As EmissionsDataSet.EmissionYearRow)

        'SP to delete all Throughput for given emission year

        'SP to delete all Emissions for given emission year

        'SP to delete all Seasonal for given emission year

        'SP to delete a process control measure for given emission year

        'SP to delete a process release point for given emission year

    End Sub

    Friend Shared Sub LoadHistoryRecord_ProcessReleasePoint(ByVal processReleasePoint As EmissionsDataSet.ProcessReleasePointRow)

        Dim processReleasePointHistory As EmissionsDataSet.ProcessReleasePointHistoryRow = MainForm.EmissionsDataSet.ProcessReleasePointHistory.NewProcessReleasePointHistoryRow
        With processReleasePointHistory
            .ProcessReleasePointID = processReleasePoint.ProcessReleasePointID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .EmissionsPercent = processReleasePoint.EmissionsPercent

            If (processReleasePoint.IsCommentPublicNull) Then
                .SetCommentPublicNull()
            Else
                .CommentPublic = processReleasePoint.CommentPublic
            End If

            If (processReleasePoint.IsCommentInternalNull) Then
                .SetCommentInternalNull()
            Else
                .CommentInternal = processReleasePoint.CommentInternal
            End If
        End With
        MainForm.EmissionsDataSet.ProcessReleasePointHistory.Rows.Add(processReleasePointHistory)

    End Sub

    Friend Shared Sub LoadHistoryRecord_ProcessControlMeasure(ByVal processControlMeasure As EmissionsDataSet.ProcessControlMeasureRow)

        Dim processControlMeasureHistory As EmissionsDataSet.ProcessControlMeasureHistoryRow = MainForm.EmissionsDataSet.ProcessControlMeasureHistory.NewProcessControlMeasureHistoryRow
        With processControlMeasureHistory
            .ProcessControlMeasureID = processControlMeasure.ProcessControlMeasureID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .CapturePercent = processControlMeasure.CapturePercent
            .UptimePercent = processControlMeasure.UptimePercent
            .Sequence = processControlMeasure.Sequence

            If (processControlMeasure.IsCommentPublicNull) Then
                .SetCommentPublicNull()
            Else
                .CommentPublic = processControlMeasure.CommentPublic
            End If

            If (processControlMeasure.IsCommentInternalNull) Then
                .SetCommentInternalNull()
            Else
                .CommentInternal = processControlMeasure.CommentInternal
            End If
        End With
        MainForm.EmissionsDataSet.ProcessControlMeasureHistory.Rows.Add(processControlMeasureHistory)

    End Sub

    Friend Shared Sub LoadHistoryRecord_ProcessEmission(ByVal processEmission As EmissionsDataSet.ProcessEmissionRow)

        Dim processEmissionHistory As EmissionsDataSet.ProcessEmissionHistoryRow = MainForm.EmissionsDataSet.ProcessEmissionHistory.NewProcessEmissionHistoryRow
        With processEmissionHistory
            .ProcessEmissionID = processEmission.ProcessEmissionID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ProcessID = processEmission.ProcessID
            .EmissionYear = processEmission.EmissionYear

            .EmissionPeriodTypeID = processEmission.EmissionPeriodTypeID
            .PollutantID = processEmission.PollutantID
            .DataOriginID = processEmission.DataOriginID
            .ProcessEmissionTypeID = processEmission.ProcessEmissionTypeID
            .EmissionValue = processEmission.EmissionValue

            .UnitofMeasurementID = processEmission.UnitofMeasurementID
            .EmissionCalculationMethodID = processEmission.EmissionCalculationMethodID
            .EmissionFactorValue = processEmission.EmissionFactorValue
            .EmissionFactorUnitOfMeasurementID = processEmission.EmissionFactorUnitOfMeasurementID
            .EmissionFactorProcessParameterTypeID = processEmission.EmissionFactorProcessParameterTypeID

            .EmissionFactorReference = processEmission.EmissionFactorReference
            .CommentPublic = processEmission.CommentPublic
            .CommentInternal = processEmission.CommentInternal
        End With
        MainForm.EmissionsDataSet.ProcessEmissionHistory.Rows.Add(processEmissionHistory)

    End Sub

    Friend Shared Sub LoadHistoryRecord_ProcessDetailPeriod(ByVal processDetailPeriod As EmissionsDataSet.ProcessDetailPeriodRow)

        Dim processDetailPeriodHistory As EmissionsDataSet.ProcessDetailPeriodHistoryRow = MainForm.EmissionsDataSet.ProcessDetailPeriodHistory.NewProcessDetailPeriodHistoryRow
        With processDetailPeriodHistory
            .ProcessDetailPeriodID = processDetailPeriod.ProcessDetailPeriodID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ProcessID = processDetailPeriod.ProcessID
            .EmissionYear = processDetailPeriod.EmissionYear
            .EmissionPeriodTypeID = processDetailPeriod.EmissionPeriodTypeID
            .DataOriginID = processDetailPeriod.DataOriginID
            .ProcessParameterTypeID = processDetailPeriod.ProcessParameterTypeID
            .ProcessParameterValue = processDetailPeriod.ProcessParameterValue
            .UnitOfMeasurementID = processDetailPeriod.UnitOfMeasurementID
            .DataYear = processDetailPeriod.DataYear

            If (processDetailPeriod.IsDataSourceNull) Then
                .SetDataSourceNull()
            Else
                .DataSource = processDetailPeriod.DataSource
            End If
        End With
        MainForm.EmissionsDataSet.ProcessDetailPeriodHistory.Rows.Add(processDetailPeriodHistory)

    End Sub

    Friend Shared Sub LoadHistoryRecord_ProcessSeasonalActivity(ByVal processSeasonalActivity As EmissionsDataSet.ProcessSeasonalActivityRow)

        Dim row As EmissionsDataSet.ProcessSeasonalActivityHistoryRow = MainForm.EmissionsDataSet.ProcessSeasonalActivityHistory.NewProcessSeasonalActivityHistoryRow
        With row
            .ProcessSeasonalActivityID = processSeasonalActivity.ProcessSeasonalActivityID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ProcessID = processSeasonalActivity.ProcessID
            .EmissionYear = processSeasonalActivity.EmissionYear
            .DataOriginID = processSeasonalActivity.DataOriginID
            .Winter = processSeasonalActivity.Winter
            .Spring = processSeasonalActivity.Spring
            .Summer = processSeasonalActivity.Summer
            .Fall = processSeasonalActivity.Fall
        End With
        MainForm.EmissionsDataSet.ProcessSeasonalActivityHistory.Rows.Add(row)

    End Sub

    Friend Shared Function NegativeValuesExist(ByVal throughput As EmissionsDataSet.ProcessDetailPeriodDataTable) As Boolean

        Dim exists As Boolean = False

        For Each row As EmissionsDataSet.ProcessDetailPeriodRow In throughput
            If row.ProcessParameterValue < 0 Then
                exists = True
                Exit For
            End If
        Next

        Return exists

    End Function

    Friend Shared Function NegativeValuesExist(ByVal emissions As EmissionsDataSet.ProcessEmissionDataTable) As Boolean

        Dim exists As Boolean = False

        For Each row As EmissionsDataSet.ProcessEmissionRow In emissions
            If row.EmissionValue < 0 Then
                exists = True
                Exit For
            End If
        Next

        Return exists

    End Function

    Friend Shared Function SumOfEmissions_NonO3D(ByVal emissions As EmissionsDataSet.ProcessEmissionDataTable, ByVal process As EmissionsDataSet.ProcessRow) As Double

        Dim sum As Double = -1
        Dim expression As String = "Sum(EmissionValue)"
        Dim filter As String = "ProcessID = " _
                               & CStr(process.ProcessID) _
                               & " AND EmissionPeriodTypeID = 'A'"

        Dim obj As Object = emissions.Compute(expression, filter)
        If (IsNumeric(obj)) Then
            sum = CDbl(obj)
        End If

        Return sum

    End Function

    Friend Shared Function SumOfEmissions_O3DPollutant_O3D(ByVal emissions As EmissionsDataSet.ProcessEmissionDataTable, ByVal process As EmissionsDataSet.ProcessRow) As Double

        Dim sum As Double = -1
        Dim expression As String = "Sum(EmissionValue)"
        Dim filter As String = "ProcessID = " _
                               & CStr(process.ProcessID) _
                               & " AND EmissionPeriodTypeID = 'O3D'" _
                               & " AND PollutantID IN (589, 602, 624)" 'Carbon Monoxide, Nitrogen Oxides, Volatile Organic Compounds


        Dim obj As Object = emissions.Compute(expression, filter)
        If (IsNumeric(obj)) Then
            sum = CDbl(obj)
        End If

        Return sum

    End Function

    Friend Shared Function SumOfEmissions_O3DPollutant_Annual(ByVal emissions As EmissionsDataSet.ProcessEmissionDataTable, ByVal process As EmissionsDataSet.ProcessRow) As Double

        Dim sum As Double = -1
        Dim expression As String = "Sum(EmissionValue)"
        Dim filter As String = "ProcessID = " _
                               & CStr(process.ProcessID) _
                               & " AND EmissionPeriodTypeID = 'A'" _
                               & " AND PollutantID IN (589, 602, 624)" 'Carbon Monoxide, Nitrogen Oxides, Volatile Organic Compounds

        Dim obj As Object = emissions.Compute(expression, filter)
        If (IsNumeric(obj)) Then
            sum = CDbl(obj)
        End If

        Return sum

    End Function

    Friend Shared Function GetO3DPollutants(ByVal emissions As EmissionsDataSet.ProcessEmissionDataTable, ByVal process As EmissionsDataSet.ProcessRow) As O3DPollutants

        Dim o3dPollutants As New O3DPollutants
        Dim filter As String = "ProcessID = " _
                               & CStr(process.ProcessID) _
                               & " AND PollutantID IN (589, 602, 624)" 'Carbon Monoxide, Nitrogen Oxides, Volatile Organic Compounds

        Dim rows() As EmissionsDataSet.ProcessEmissionRow = CType(emissions.Select(filter), EmissionsDataSet.ProcessEmissionRow())

        For Each row As EmissionsDataSet.ProcessEmissionRow In rows

            Select Case row.EmissionPeriodTypeID
                Case "A"
                    If (row.PollutantID = 589) Then
                        o3dPollutants.COAnnual = row.EmissionValue
                    ElseIf (row.PollutantID = 602) Then
                        o3dPollutants.NOXAnnual = row.EmissionValue
                    ElseIf (row.PollutantID = 624) Then
                        o3dPollutants.VOCAnnual = row.EmissionValue
                    End If
                Case "O3D"
                    If (row.PollutantID = 589) Then
                        o3dPollutants.COO3D = row.EmissionValue
                    ElseIf (row.PollutantID = 602) Then
                        o3dPollutants.NOXO3D = row.EmissionValue
                    ElseIf (row.PollutantID = 624) Then
                        o3dPollutants.VOCO3D = row.EmissionValue
                    End If
            End Select
        Next

        Return o3dPollutants

    End Function

End Class
