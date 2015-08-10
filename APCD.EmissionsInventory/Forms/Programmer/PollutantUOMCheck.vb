Imports System.Text
Imports System.IO

Public Class PollutantUOMCheck

    Sub New(ByVal processNavigationTable As DataTable)
        InitializeComponent()
        Me.m_processNavigationTable = processNavigationTable
    End Sub

    Private m_processNavigationTable As DataTable
    Private m_updateReport As New StringBuilder
    Private m_modifiedRecordCount As Int32 = 1

    Private Sub PollutantUOMCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = Me.m_processNavigationTable.Rows.Count

        Me.Visible = True
        Call Me.CheckIt()
        Me.Close()
    End Sub

    Private Sub CheckIt()

        Dim rowCount As Int32 = 1

        Call Me.WriteReportHeader()

        For Each row As DataRow In Me.m_processNavigationTable.Rows
            Me.Label1.Text = "Checking row " & rowCount.ToString & " of " & Me.m_processNavigationTable.Rows.Count.ToString
            My.Application.DoEvents()

            Dim processID As Int32 = CInt(row(EmissionsDataSet.Process.ProcessIDColumn.ColumnName))
            Dim emissionYear As Int16 = CShort(row(EmissionsDataSet.EmissionYear.EmissionYearColumn.ColumnName))
            If ((processID > 0) AndAlso (emissionYear > 0)) Then
                Me.ProcessEmissionTableAdapter.FillByProcessID_EmissionYear(Me.EmissionsDataSet.ProcessEmission, processID, emissionYear)
                Call Me.SetPollutantUnitOfMeasurement()
                Call Me.Save()
            End If
            Me.ProgressBar1.Value = rowCount
            rowCount += 1
        Next

        If (Me.m_modifiedRecordCount > 0) Then
            Call Me.WriteReportToFile()
        End If

    End Sub

    Private Sub SetPollutantUnitOfMeasurement()

        For Each row As EmissionsDataSet.ProcessEmissionRow In Me.EmissionsDataSet.ProcessEmission
            Dim pollutant As EmissionsDataSet.PollutantRow = GlobalVariables.LookupTable.Pollutant.FindByPollutantID(row.PollutantID)
            If (pollutant.PollutantTypeEISID = "CAP") Then
                If (row.EmissionPeriodTypeID = "A") Then
                    If (row.UnitofMeasurementID <> CInt(GlobalVariables.UnitOfMeasurementEnum.tons)) Then
                        Call Me.AddToReport(row, pollutant.PollutantTypeEISID, CInt(GlobalVariables.UnitOfMeasurementEnum.tons))
                        row.UnitofMeasurementID = CInt(GlobalVariables.UnitOfMeasurementEnum.tons)
                    End If
                Else
                    If (row.UnitofMeasurementID <> CInt(GlobalVariables.UnitOfMeasurementEnum.pounds)) Then
                        Call Me.AddToReport(row, pollutant.PollutantTypeEISID, CInt(GlobalVariables.UnitOfMeasurementEnum.pounds))
                        row.UnitofMeasurementID = CInt(GlobalVariables.UnitOfMeasurementEnum.pounds)
                    End If
                End If
            Else
                If (row.UnitofMeasurementID <> CInt(GlobalVariables.UnitOfMeasurementEnum.pounds)) Then
                    Call Me.AddToReport(row, pollutant.PollutantTypeEISID, CInt(GlobalVariables.UnitOfMeasurementEnum.pounds))
                    row.UnitofMeasurementID = CInt(GlobalVariables.UnitOfMeasurementEnum.pounds)
                End If
            End If
        Next

    End Sub

    Private Sub WriteReportHeader()
        With Me.m_updateReport
            .Append("ProcessID")
            .Append(vbTab)

            .Append("PollutantID")
            .Append(vbTab)

            .Append("PollutantTypeEISID")
            .Append(vbTab)

            .Append("EmissionPeriodTypeID")
            .Append(vbTab)

            .Append("Old Value")
            .Append(vbTab)

            .AppendLine("New Value")
        End With
    End Sub

    Private Sub WriteReportFooter()
        With Me.m_updateReport
            .AppendLine()
            .Append("Total records modified: ")
            .AppendLine(Me.m_modifiedRecordCount.ToString)
        End With
    End Sub

    Private Sub AddToReport(ByVal row As EmissionsDataSet.ProcessEmissionRow, ByVal pollutantType As String, ByVal newUnitOfMeasurement As Int32)

        Me.m_modifiedRecordCount += 1

        With Me.m_updateReport
            .Append(row.ProcessID)
            .Append(vbTab)

            .Append(row.PollutantID)
            .Append(vbTab)

            .Append(pollutantType)
            .Append(vbTab)

            .Append(row.EmissionPeriodTypeID)
            .Append(vbTab)

            .Append(row.UnitofMeasurementID)
            .Append(vbTab)

            .AppendLine(CStr(newUnitOfMeasurement))
        End With

    End Sub

    Private Sub Save()
        Me.Validate()
        Me.ProcessEmissionBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EmissionsDataSet)

    End Sub

    Private Sub WriteReportToFile()
        Dim reportFileName As String = GlobalVariables.ApplicationDataDirectory & "\PollutantUOMCheckReport.txt"
        Dim sw As New StreamWriter(reportFileName, False)
        sw.WriteLine(Me.m_updateReport.ToString)
        sw.Close()
    End Sub

End Class