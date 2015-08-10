Public Class ControlMeasureHelper

    Public Enum ColumnEnum
        ControlMeasureDescription
        ControlMeasureTypeID
        ControlMeasureAPCDID
        CompanyComment

        ReductionEfficiency 'technically ControlMeasurePollutant column
    End Enum

    Friend Shared Sub AddHistoryRecord_ControlMeasurePollutant(ByVal rowToAdd As ControlMeasureDataSet.ControlMeasurePollutantRow, ByVal history As ControlMeasureDataSet.ControlMeasurePollutantHistoryDataTable)

        Dim rowControlMeasurePollutantHistory = history.NewControlMeasurePollutantHistoryRow
        With rowControlMeasurePollutantHistory
            .ControlMeasurePollutantID = rowToAdd.ControlMeasurePollutantID
            .UpdateDate = Date.Now
            .UpdatedBy = GlobalVariables.Employee.EmployeeID
            .ReductionEfficiency = rowToAdd.ReductionEfficiency
        End With
        history.Rows.Add(rowControlMeasurePollutantHistory)

    End Sub

End Class
