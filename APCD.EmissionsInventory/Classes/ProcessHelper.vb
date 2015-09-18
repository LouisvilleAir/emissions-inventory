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

    ''' <summary>
    ''' Look up the annual throughput and ozone season daily throughput (if any)
    ''' for the current process for the current emission year selected on the main form.
    ''' </summary>
    ''' <param name="Process">An EmissionsDataSet.ProcessRow representing the process</param>
    ''' <param name="AnnualThroughput">OUTPUT PARAMETER: The annual throughput for the process for the current emissions year</param>
    ''' <param name="OzoneSeasonDailyThroughput">OUTPUT PARAMETER: The ozone season daily throughput for the process for the current emissions year</param>
    ''' <param name="ThroughputUnits">OUTPUT PARAMETER: The UnitOfMeasurementName of the units of the throughput</param>
    ''' <returns>True if successful, that is at least an annual throughput is found</returns>
    ''' <remarks>This only works predictably if the Process user control is loaded on the main form.
    ''' 20150814 BJF</remarks>
    Friend Shared Function ThroughputLookup(ByRef Process As APCD.EmissionsInventory.EmissionsDataSet.ProcessRow, _
                                            ByRef AnnualThroughput As Double, _
                                            ByRef OzoneSeasonDailyThroughput As Double, _
                                            ByRef ThroughputUnits As String) As Boolean
        Dim result As Boolean = False

        Try
            Dim UOMID As Int32 = -1
            Dim text As String = String.Empty
            Dim isAnnualFound As Boolean = False

            If (MainForm.EmissionsDataSet.ProcessDetailPeriod.Rows.Count = 0) Then
                text = Tools.Constants.Character.QuestionMark
            Else
                For Each row As EmissionsDataSet.ProcessDetailPeriodRow In MainForm.EmissionsDataSet.ProcessDetailPeriod
                    If (row.ProcessParameterTypeID = 1) Then
                        UOMID = row.UnitOfMeasurementID
                        AnnualThroughput = row.ProcessParameterValue
                        'Exit For
                        isAnnualFound = True
                        result = True
                    ElseIf (row.ProcessParameterTypeID = 13) Then
                        OzoneSeasonDailyThroughput = row.ProcessParameterValue
                        If isAnnualFound Then
                            Exit For
                        End If
                    End If
                Next

                If (UOMID = -1) Then
                    text = Tools.Constants.Character.QuestionMark
                Else
                    Dim UOM As EmissionsDataSet.UnitOfMeasurementRow = GlobalVariables.LookupTable.UnitOfMeasurement.FindByUnitOfMeasurementID(UOMID)
                    text = UOM.UnitOfMeasurementName
                End If
            End If
            ThroughputUnits = text

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' Calculate emissions from throughput and an emission factor where control efficiency is _not_ used in the calculation.
    ''' </summary>
    ''' <param name="Throughput">The value of a parameter of the process that is used by the emission factor.  
    ''' Must be in the same units as the the denominator unit of the emission factor.</param>
    ''' <param name="EmissionFactor">The emission factor for the pollutant.  
    ''' Must be in units of pounds (of the pollutant) per unit of the throughput.</param>
    ''' <returns>The emissions in pounds</returns>
    ''' <remarks>20150814 BJF</remarks>
    Friend Shared Function EmissionsFromEmissionFactorNoControl(ByVal Throughput As Double, ByVal EmissionFactor As Double) As Double
        Dim emissions As Double = 0.0#

        If Throughput > 0 AndAlso EmissionFactor > 0 Then
            emissions = Throughput * EmissionFactor
        End If
        Return emissions
    End Function

    ''' <summary>
    ''' Calculate post-control emissions from throughput and an emission factor taking 
    ''' into account control efficiency, control capture efficiency and control uptime.
    ''' </summary>
    ''' <param name="Throughput">The value of a parameter of the process that 
    ''' is used by the emission factor.  
    ''' Must be in the same units as the the denominator unit of the emission 
    ''' factor.</param>
    ''' <param name="EmissionFactor">The emission factor for the pollutant.  
    ''' Must be in units of pounds (of the pollutant) per unit of the 
    ''' throughput.</param>
    ''' <param name="ReductionEfficiency">The control measure's emissions reduction 
    ''' efficiency for the pollutant, expressed as a fraction between 0 and 1</param>
    ''' <param name="CaptureEfficiency">The capture efficiency of the 
    ''' control measure, expressed as a fraction between 0 and 1</param>
    ''' <param name="Uptime">The uptime of the control measure for this process 
    ''' for the emission period, expressed as a fraction between 0 and 1. 
    ''' (This is the "control measure effectiveness" in EPA terms.)</param>
    ''' <returns>The emissions in pounds (post-control)</returns>
    ''' <remarks>20150814 BJF</remarks>
    Friend Shared Function EmissionsFromEmissionFactorWithControl(ByVal Throughput As Double, _
                                                    ByVal EmissionFactor As Double, _
                                                    ByVal ReductionEfficiency As Double, _
                                                    ByVal CaptureEfficiency As Double, _
                                                    ByVal Uptime As Double) As Double
        Dim emissions As Double = 0.0#

        If Throughput > 0 AndAlso EmissionFactor > 0 Then
            emissions = Throughput * EmissionFactor * (1 - ReductionEfficiency * CaptureEfficiency * Uptime)
        End If
        Return emissions
    End Function

    ''' <summary>
    ''' For the provided ProcessEmissionRow record, calculate the emissions from the throughput 
    ''' if the emission calculation method uses an emission factor.
    ''' </summary>
    ''' <param name="processEmission">A EmissionsDataSet.ProcessEmissionRow 
    ''' representing emissions of a specific pollutant from a specific process 
    ''' for a specific period (normally a particular year or an average ozone 
    ''' season day of a particular year)</param>
    ''' <remarks>Calls the function ThrouputLookup() and may call the function 
    ''' EmissionFromEmissionFactorNoControl().
    ''' 20150818 BJF</remarks>
    Friend Shared Function EmissionsFromEmissionFactor(ByRef processEmission As APCD.EmissionsInventory.EmissionsDataSet.ProcessEmissionRow) As Double
        Dim emissionValue As Double = 0.0
        Try
            Dim annualThruput As Double = 0.0
            Dim emissionsPounds As Double = 0.0
            Dim ozoneSeasonThruput As Double = 0.0
            Dim pollutantID As Integer = processEmission.PollutantID
            Dim process As APCD.EmissionsInventory.EmissionsDataSet.ProcessRow = processEmission.ProcessRow
            Dim thruputUnits As String = String.Empty

            If (processEmission.IsEmissionCalculationMethodIDNull OrElse pollutantID < 1) Then
                ' Can't proceed.
            Else
                Select Case processEmission.EmissionCalculationMethodID
                    'Case 1, 2, 3, 4, 5, 6, 7, 24
                    '    ' No emission factor.  Try to calculate anyway if an emission factor is supplied.
                    'Case 8, 9, 10, 11, 12, 13
                    '    ' Emission factor not using control efficiency
                    ' Both of the above are handled in the "Case Else" below.
                    Case 28, 29, 30, 31, 32, 33
                        ' Emission factor (pre-control) taking into account control efficiency, capture, and uptime.

                        Try
                            If ThroughputLookup(process, annualThruput, ozoneSeasonThruput, thruputUnits) Then
                                Const c_ParallelMax As Integer = 20 ' Maximum number of controls in parallel
                                Const c_SeriesMax As Integer = 10 ' Maximum number of controls in series
                                Dim capture(c_SeriesMax, c_ParallelMax) As Double   ' capture efficiencies
                                Dim captureEfficiency As Double ' effective capture efficiency of control approach
                                Dim reduction(c_SeriesMax, c_ParallelMax) As Double ' reduction efficiencies
                                Dim reductionEfficiency As Double ' effective reduction efficiency
                                Dim uptime(c_SeriesMax, c_ParallelMax) As Double    ' uptime fractions
                                Dim uptimeFraction As Double ' effective uptime fraction
                                Dim parallel(c_SeriesMax) As Integer ' number of parallel controls with a given sequence #
                                Dim parallelCount As Integer = 0
                                Dim seriesCount As Integer = 0
                                Dim lastSequence As Integer = 0

                                ' Initialize arrays.
                                For i = 0 To c_SeriesMax - 1
                                    For j = 0 To c_ParallelMax - 1
                                        reduction(i, j) = 0.0
                                        capture(i, j) = 0.0
                                        uptime(i, j) = 0.0
                                    Next
                                Next

                                Dim processControlMeasures() As APCD.EmissionsInventory.EmissionsDataSet.ProcessControlMeasureRow

                                ' Get all of the control measures for the process.
                                processControlMeasures = process.GetProcessControlMeasureRows
                                ' Sort them by sequence.
                                processControlMeasures.OrderBy(Function(pcm) pcm.Sequence)

                                ' Switching to ControlMeasureDataSet!
                                Dim myCMDataset As New APCD.EmissionsInventory.ControlMeasureDataSet
                                Dim myCMTableAdapter As New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasureTableAdapter
                                Dim myCMPTableAdapter As New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasurePollutantTableAdapter

                                ' Find the control measure(s) for this pollutant.
                                For Each pcm As APCD.EmissionsInventory.EmissionsDataSet.ProcessControlMeasureRow In processControlMeasures
                                    Dim controlMeasureID As Integer = pcm.ControlMeasureID

                                    ' Load the control measures table with the single record.
                                    myCMTableAdapter.FillByControlMeasureID(myCMDataset.ControlMeasure, controlMeasureID)
                                    '' Get the control measure itself.
                                    ''Dim controlMeasure As APCD.EmissionsInventory.EmissionsDataSet.ControlMeasureRow = pcm.ControlMeasureRow
                                    'Dim controlMeasure As APCD.EmissionsInventory.ControlMeasureDataSet.ControlMeasureRow _
                                    '    = CType(myCMDataset.ControlMeasure.Rows(0), APCD.EmissionsInventory.ControlMeasureDataSet.ControlMeasureRow)

                                    ' Load the control measure pollutant table for this control measure for the selected emission year.
                                    myCMPTableAdapter.FillByControlMeasureIDAndEmissionYear(myCMDataset.ControlMeasurePollutant, controlMeasureID, CShort(MainForm.EmissionYearComboBox.SelectedValue))

                                    ' See if it controls the specified pollutant.
                                    'For Each cp As APCD.EmissionsInventory.ControlMeasureDataSet.ControlMeasurePollutantRow In controlMeasure.GetControlMeasurePollutantRows
                                    For Each cp As APCD.EmissionsInventory.ControlMeasureDataSet.ControlMeasurePollutantRow In myCMDataset.ControlMeasurePollutant
                                        If cp.PollutantID = pollutantID Then
                                            ' Found a control for the pollutant.
                                            reduction(seriesCount, parallelCount) = cp.ReductionEfficiency / 100.0
                                            capture(seriesCount, parallelCount) = pcm.CapturePercent / 100.0
                                            uptime(seriesCount, parallelCount) = pcm.UptimePercent / 100.0
                                            ' Does it have a higher sequence number than the previous one?
                                            ' Remember, we sorted by sequence.
                                            parallelCount += 1
                                            parallel(seriesCount) = parallelCount
                                            If pcm.Sequence > lastSequence Then
                                                seriesCount += 1
                                                parallelCount = 0
                                                'Else
                                            End If
                                            lastSequence = pcm.Sequence
                                            Exit For ' pollutant ID must be unique among control measure pollutants for a given control measure
                                        End If
                                    Next
                                Next

                                If seriesCount = 1 And parallel(0) = 1 Then
                                    ' There is only one control.
                                    reductionEfficiency = reduction(0, 0)
                                    captureEfficiency = capture(0, 0)
                                    uptimeFraction = uptime(0, 0)

                                    If processEmission.EmissionPeriodTypeID = "O3D" Then
                                        emissionsPounds = EmissionsFromEmissionFactorNoControl(ozoneSeasonThruput, processEmission.EmissionFactorValue) _
                                                    * (1 - reductionEfficiency * captureEfficiency * uptimeFraction)
                                    Else
                                        emissionsPounds = EmissionsFromEmissionFactorNoControl(annualThruput, processEmission.EmissionFactorValue) _
                                                    * (1 - reductionEfficiency * captureEfficiency * uptimeFraction)
                                    End If

                                Else
                                    Dim escapeProduct As Double = 1.0
                                    ' escapeProduct stores the product of all the
                                    ' (one minus reduction efficiency times
                                    ' capture efficiency times uptime fraction)
                                    ' terms for the layers: Product[(1 - R_i*C_i*U_i)]
                                    ' This is the fraction of emissions that
                                    ' _escape_ that layer of controls.

                                    For i = 0 To seriesCount - 1
                                        If parallel(i) = 1 Then
                                            ' There is only one control for this
                                            ' pollutant with the current sequence #.
                                            ' Multiply its statistics into the product.
                                            escapeProduct *= (1 - reduction(i, 0) * capture(i, 0) * uptime(i, 0))

                                        Else
                                            ' There is more than one control for this pollutant
                                            ' with the same sequence number; they are in parallel.
                                            ' How to calculate the effective statistics depends 
                                            ' on whether the control measures are spatially in parallel
                                            ' (for example distributed along a line) or temporally
                                            ' in parallel (for example, main and backup). 
                                            ' Standard procedure is to only put controls that are
                                            ' spatially in parallel in the same sequence number.
                                            ' If they are spatially in parallel, the total capture
                                            ' can be no more than 100%.
                                            Dim captureSum As Double = 0.0
                                            Dim reductionSum As Double = 0.0
                                            Dim uptimeSum As Double = 0.0
                                            Dim n As Integer = parallel(i)

                                            If n > 0 Then
                                                For j = 0 To n - 1
                                                    captureSum += capture(i, j)
                                                    reductionSum += reduction(i, j)
                                                    uptimeSum += uptime(i, j)
                                                Next
                                                If captureSum <= 1 Then
                                                    ' We are good.
                                                    captureEfficiency = captureSum
                                                    reductionEfficiency = reductionSum / n
                                                    uptimeFraction = uptimeSum / n

                                                Else
                                                    ' There is probably an error.
                                                    ' But maybe they are temporally parallel.
                                                    ' If so, then their uptime fractions should total
                                                    ' no more than 100%.
                                                    If uptimeSum <= 1 Then
                                                        ' Looks OK ...
                                                        reductionEfficiency = reductionSum / n
                                                        captureEfficiency = captureSum / n
                                                        uptimeFraction = uptimeSum
                                                    Else
                                                        ' This has to be an error.
                                                        escapeProduct = 0.0
                                                        Exit For
                                                    End If
                                                End If

                                                ' Roll the effective statistics for this layer into the product.
                                                ' We have to assume all surviving emissions from layer i-1
                                                ' go into _all_ the controls in layer i based on their capture.
                                                ' Any other permutation of configurations is not reflected
                                                ' in the database.
                                                escapeProduct *= (1 - reductionEfficiency * captureEfficiency * uptimeFraction)

                                            Else
                                                ' n is zero.  Something is wrong.
                                                escapeProduct = 0.0
                                            End If

                                        End If
                                    Next

                                    If escapeProduct = 0.0 Then
                                        ' An error was found; can't calculate a valid result.
                                        emissionsPounds = 0.0
                                        Throw New ArgumentException("Control measure configuration does not make sense!")
                                    Else

                                        ' Calculate the emissions.
                                        If processEmission.EmissionPeriodTypeID = "O3D" Then
                                            emissionsPounds = EmissionsFromEmissionFactorNoControl(ozoneSeasonThruput, processEmission.EmissionFactorValue) _
                                                        * escapeProduct
                                        Else
                                            emissionsPounds = EmissionsFromEmissionFactorNoControl(annualThruput, processEmission.EmissionFactorValue) _
                                                        * escapeProduct
                                        End If

                                    End If

                                End If ' 1 and 1

                            End If

                        Catch ex As Exception
                            GlobalMethods.HandleError(ex)
                        End Try

                    Case Else
                        ' Emission factor _not_ using control efficiency
                        ' Get the throughput.
                        'For Each row As APCD.EmissionsInventory.EmissionsDataSet.ProcessDetailPeriodRow In process.GetProcessDetailPeriodRows
                        '    If row.ProcessParameterTypeID = 1 Then
                        '        annualThruput = row.ProcessParameterValue
                        '    End If
                        '    If row.ProcessParameterTypeID = 13 Then
                        '        ozoneSeasonThruput = row.ProcessParameterValue
                        '    End If
                        'Next
                        If ThroughputLookup(process, annualThruput, ozoneSeasonThruput, thruputUnits) Then
                            If processEmission.EmissionPeriodTypeID = "O3D" Then
                                emissionsPounds = EmissionsFromEmissionFactorNoControl(ozoneSeasonThruput, processEmission.EmissionFactorValue)
                            Else
                                emissionsPounds = EmissionsFromEmissionFactorNoControl(annualThruput, processEmission.EmissionFactorValue)
                            End If
                        Else
                            ' Can't calculate emissions without the throughput.
                        End If

                End Select
            End If

            ' Convert to tons if appropriate.
            If processEmission.UnitofMeasurementID = 528 Then   ' tons
                emissionValue = emissionsPounds / 2000
            Else
                emissionValue = emissionsPounds
            End If

        Catch ex As Exception
            GlobalMethods.HandleError(ex)
        End Try

        Return emissionValue
    End Function

    ' ''' <summary>
    ' ''' Look up or calculate the (effective) control efficiency for a specified
    ' ''' pollutant for a specified process, taking into account the reduction
    ' ''' efficiency, capture efficiency, and uptime when multiple controls for 
    ' ''' a process control the same pollutant.
    ' ''' </summary>
    ' ''' <param name="Process">An EmissionsDataSet.ProcessRow record representing a particular emissions process</param>
    ' ''' <param name="PollutantID">The identifier for a specific pollutant</param>
    ' ''' <param name="ReductionEfficiency">OUTPUT PARAMETER: The (effective) 
    ' ''' reduction efficiency for the pollutant as a fraction, not a percent</param>
    ' ''' <param name="CaptureEfficiency">OUTPUT PARAMETER: The (effective) 
    ' ''' capture efficiency for the pollutant as a fraction, not a percent</param>
    ' ''' <param name="UptimeFraction">OUTPUT PARAMETER: The (effective) uptime of 
    ' ''' the control approach for the pollutant as a fraction, not a percent</param>
    ' ''' <returns>True if successful</returns>
    ' ''' <remarks>If there are two control measures on the process in series that 
    ' ''' affect the same pollutant, then we need to calculate the effective control 
    ' ''' statistics.  We are not going to worry about the possibility of three 
    ' ''' control measures in sequence affecting the same pollutant.
    ' ''' 20150818 BJF</remarks>
    'Friend Shared Function ControlEfficiencyForPollutant(ByRef Process As APCD.EmissionsInventory.EmissionsDataSet.ProcessRow, _
    '                                                     ByVal PollutantID As Integer, _
    '                                                     ByRef ReductionEfficiency As Double, _
    '                                                     ByRef CaptureEfficiency As Double, _
    '                                                     ByRef UptimeFraction As Double) As Boolean
    '    Dim result As Boolean = False

    '    Try
    '        Const c_ParallelMax As Integer = 20 ' Maximum number of controls in parallel
    '        Const c_SeriesMax As Integer = 10 ' Maximum number of controls in series
    '        Dim reduction(c_SeriesMax, c_ParallelMax) As Double ' reduction efficiencies
    '        Dim capture(c_SeriesMax, c_ParallelMax) As Double   ' capture efficiencies
    '        Dim uptime(c_SeriesMax, c_ParallelMax) As Double    ' uptime fractions
    '        Dim parallel(c_SeriesMax) As Integer ' number of parallel controls with a given sequence #
    '        Dim parallelCount As Integer = 0
    '        Dim seriesCount As Integer = 0
    '        Dim lastSequence As Integer = 0

    '        ' Initialize arrays.
    '        For i = 0 To c_SeriesMax - 1
    '            For j = 0 To c_ParallelMax - 1
    '                reduction(i, j) = 0.0#
    '                capture(i, j) = 0.0#
    '                uptime(i, j) = 0.0#
    '            Next
    '        Next

    '        Dim processControlMeasures() As APCD.EmissionsInventory.EmissionsDataSet.ProcessControlMeasureRow

    '        ' Get all of the control measures for the process.
    '        processControlMeasures = Process.GetProcessControlMeasureRows
    '        ' Sort them by sequence.
    '        processControlMeasures.OrderBy(Function(pcm) pcm.Sequence)

    '        ' Find the control measure(s) for this pollutant.
    '        For Each pcm As APCD.EmissionsInventory.EmissionsDataSet.ProcessControlMeasureRow In processControlMeasures
    '            ' See if it controls the specified pollutant.
    '            For Each cp As APCD.EmissionsInventory.EmissionsDataSet.ControlMeasurePollutantRow In pcm.ControlMeasureRow.GetControlMeasurePollutantRows
    '                If cp.PollutantID = PollutantID Then
    '                    ' Found a control for the pollutant.
    '                    reduction(seriesCount, parallelCount) = cp.ReductionEfficiency / 100.0#
    '                    capture(seriesCount, parallelCount) = pcm.CapturePercent / 100.0#
    '                    uptime(seriesCount, parallelCount) = pcm.UptimePercent / 100.0#
    '                    ' Does it have a higher sequence number than the previous one?
    '                    ' Remember, we sorted by sequence.
    '                    If pcm.Sequence > lastSequence Then
    '                        seriesCount += 1
    '                        parallelCount = 0
    '                    Else
    '                        parallelCount += 1
    '                    End If
    '                    parallel(seriesCount) = parallelCount
    '                    lastSequence = pcm.Sequence
    '                    Exit For ' pollutant ID must be unique among control measure pollutants for a given control measure
    '                End If
    '            Next
    '        Next

    '        If seriesCount = 1 And parallel(0) = 1 Then
    '            ' There is only one control.
    '            ReductionEfficiency = reduction(0, 0)
    '            CaptureEfficiency = capture(0, 0)
    '            UptimeFraction = uptime(0, 0)

    '            result = True
    '        Else
    '            Dim reductionProduct As Double = 1.0#
    '            Dim uptimeProduct As Double = 1.0#
    '            Dim capture1 As Double = capture(0, 0)

    '            For i = 0 To seriesCount - 1
    '                If parallel(i) = 1 Then
    '                    ' There is only one control with the current sequence #.
    '                    ' Multiply its statistics into the products.
    '                    reductionProduct *= (1 - reduction(i, 0) * capture(i, 0) * uptime(i, 0))
    '                    uptimeProduct *= uptime(i, 0)
    '                Else
    '                    ' There is more than one control for this pollutant
    '                    ' with the same sequence number; they are in parallel.
    '                    ' How to calculate the effective statistics depends 
    '                    ' on whether the control measures are spatially in parallel
    '                    ' (for example distributed along a line) or temporally
    '                    ' in parallel (for example, main and backup). 
    '                    ' Standard procedure is to only put controls that are
    '                    ' spatially in parallel in the same sequence number.
    '                    ' If they are spatially in parallel, the total capture
    '                    ' can be no more than 100%.
    '                    Dim captureSum As Double = 0.0#
    '                    Dim reductionSum As Double = 0.0#
    '                    Dim uptimeSum As Double = 0.0#
    '                    Dim n As Integer = parallel(i)

    '                    For j = 0 To n - 1
    '                        captureSum += capture(i, j)
    '                        reductionSum += reduction(i, j)
    '                        uptimeSum += uptime(i, j)
    '                    Next
    '                    If captureSum <= 1 Then
    '                        ' We are good.
    '                        ' Using our output variables temporarily to store the
    '                        ' values for this layer.
    '                        ReductionEfficiency = reductionSum / n
    '                        CaptureEfficiency = captureSum
    '                        UptimeFraction = uptimeSum / n
    '                    Else
    '                        ' There is probably an error.
    '                        ' But maybe they are temporally parallel.
    '                        ' If so, then their uptime fractions should total
    '                        ' no more than 100%.
    '                        For j = 0 To n - 1
    '                            captureSum += capture(i, j)
    '                            reductionSum += reduction(i, j)
    '                            uptimeSum += uptime(i, j)
    '                        Next
    '                        If uptimeSum <= 1 Then
    '                            ' OK
    '                            ReductionEfficiency = reductionSum / n
    '                            CaptureEfficiency = captureSum / n
    '                            UptimeFraction = uptimeSum
    '                        Else
    '                            ' This has to be an error.
    '                            result = False
    '                        End If
    '                    End If

    '                    ' Put the effective statistics for this layer into the products.
    '                    ' We have to assume all surviving emissions from layer i-1
    '                    ' go into _all_ the controls in layer i.
    '                    ' Any other permutation of configurations is not reflected
    '                    ' in the database.
    '                    reductionProduct *= (1 - ReductionEfficiency * CaptureEfficiency * UptimeFraction)
    '                    uptimeProduct *= UptimeFraction
    '                    If i = 0 Then
    '                        capture1 = CaptureEfficiency
    '                    End If
    '                End If
    '            Next

    '            ' Calculate the effective statistics.
    '            ' The effection reduction efficiency is one minus
    '            ' the product of the individual "one minus" terms.
    '            ' It may be easier to think of it in terms of the fraction of
    '            ' emissions that escape.
    '            ReductionEfficiency = 1 - reductionProduct
    '            ' The effective capture is the amount of the emissions
    '            ' stream captured by the _system_ of control measures.
    '            ' So it is simply the capture efficiency of the 
    '            ' sequence 1 controls.
    '            CaptureEfficiency = capture1
    '            ' The effective uptime fraction is simply the product of the uptime fractions.
    '            UptimeFraction = uptimeProduct
    '            result = True

    '        End If ' 1 and 1

    '        If ReductionEfficiency > 0.0# Then
    '            result = True
    '        End If

    '    Catch ex As Exception
    '        GlobalMethods.HandleError(ex)
    '    End Try

    '    Return result
    'End Function
End Class
