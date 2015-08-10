Public Class ReleasePointHelper

    Public Enum ColumnEnum
        ReleasePointDescription
        XCoordinate
        YCoordinate
        ReleaseTypeSubTypeID
        ReleasePointTypeID
        ReleasePointAPCDID
        CompanyComment
    End Enum

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>Values must match those in the ReleaseType table.</remarks>
    Public Enum ReleaseType
        Fugitive = 1
        Stack = 2
    End Enum

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>Values must match those in the ReleaseTypeSubType table.</remarks>
    Public Enum ReleaseTypeSubType
        'stack
        Round = 2
        Other = 3
        'fugitive
        Point = 1
        Area = 4
    End Enum

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>Values must match those in the Measurement table.</remarks>
    Public Enum MeasurementEnum
        Height = 1
        Diameter = 2
        FencelineDistance = 3
        ExitGasTemperature = 4
        ExitGasSpeed = 5
        ExitGasFlowRate = 6
        Length = 7
        Width = 8
        HorizontalAngle = 9
    End Enum

    Public Structure MeasurementName
        Const Height As String = "Height"
        Const Diameter As String = "Diameter"
        Const FencelineDistance As String = "Fenceline Distance"
        Const ExitGasTemperature As String = "Exit Gas Temperature"
        Const ExitGasSpeed As String = "Exit Gas Speed"
        Const ExitGasFlowRate As String = "Exit Gas Flow Rate"
        Const Length As String = "Length"
        Const Width As String = "Width"
        Const HorizontalAngle = "Horizontal Angle"
    End Structure

    Friend Shared Function GetUnitOfMeasurementID(ByVal measurement As ReleasePointHelper.MeasurementEnum) As Int32

        Dim returnValue As Int32

        Select Case measurement
            Case MeasurementEnum.Height, MeasurementEnum.Diameter, MeasurementEnum.Width, MeasurementEnum.Length, MeasurementEnum.FencelineDistance
                returnValue = CInt(GlobalVariables.UnitOfMeasurementEnum.feet)

            Case MeasurementEnum.ExitGasFlowRate
                returnValue = CInt(GlobalVariables.UnitOfMeasurementEnum.actualCubicFeetPerMinute)

            Case MeasurementEnum.ExitGasTemperature
                returnValue = CInt(GlobalVariables.UnitOfMeasurementEnum.degreesFahrenheit)

            Case MeasurementEnum.HorizontalAngle
                returnValue = CInt(GlobalVariables.UnitOfMeasurementEnum.compassDegrees)
        End Select

        Return returnValue

    End Function

    Friend Shared Sub AddHistoryRecord_ReleasePointDetail(ByVal rowToAdd As ReleasePointDataSet.ReleasePointDetailRow, ByVal history As ReleasePointDataSet.ReleasePointDetailHistoryDataTable)

        Dim rowReleasePointDetailHistory = history.NewReleasePointDetailHistoryRow
        With rowReleasePointDetailHistory
            .ReleasePointDetailID = rowToAdd.ReleasePointDetailID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ReleasePointID = rowToAdd.ReleasePointID
            .MeasurementID = rowToAdd.MeasurementID
            .DetailValue = rowToAdd.DetailValue
            .UnitOfMeasurementID = rowToAdd.UnitOfMeasurementID
        End With
        history.Rows.Add(rowReleasePointDetailHistory)

    End Sub

    Friend Shared Sub CreateReleasePointYearRecord(ByVal releasePointID As Int32, ByVal emissionYear As Int16, ByVal releasePointYearTable As ReleasePointDataSet.ReleasePointYearDataTable, ByVal tableAdapter As ReleasePointDataSetTableAdapters.ReleasePointYearTableAdapter)

        Dim rpYear As ReleasePointDataSet.ReleasePointYearRow = releasePointYearTable.NewReleasePointYearRow
        With rpYear
            .ReleasePointID = releasePointID
            .EmissionYear = emissionYear
            .OperatingStatusTypeEISID = GlobalVariables.OperatingStatus.Operating
        End With
        releasePointYearTable.Rows.Add(rpYear)

        tableAdapter.Update(rpYear)

    End Sub

End Class
