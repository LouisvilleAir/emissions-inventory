Imports System.Text

Public Class CopyPollutantsToAnotherProcessForm

    Sub New(ByVal process As EmissionsDataSet.ProcessRow)
        Call Me.InitializeComponent()
        Me.m_process = process
    End Sub

    Private m_blnFormIsLoaded As Boolean = False
    Private m_process As EmissionsDataSet.ProcessRow

    Private Sub CopyPollutantsToAnotherProcessForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sourceProcessPrompt As New StringBuilder
        With sourceProcessPrompt
            .Append("Source Process: ")
            .Append(Me.m_process.ProcessAPCDID)
        End With
        Me.lblSourceProcessPrompt.Text = sourceProcessPrompt.ToString

        Call Me.LoadPlantcomboBox()

        Me.m_blnFormIsLoaded = True

        Me.PlantComboBox.SelectedIndex = -1
        Me.btnCopyProcess.Enabled = False

    End Sub

    Private Sub LoadPlantcomboBox()
        Tools.WindowsForms.LoadComboBox(GlobalVariables.LookupTable.Plant, Me.PlantComboBox, False)
    End Sub

    Private Sub PlantComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlantComboBox.SelectedIndexChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Dim dtb As DataTable = Emissions.Utility.PlantEmissionUnitUtility.GetAPCDIDLookupTableByPlantID(CInt(Me.PlantComboBox.SelectedValue))
            Tools.WindowsForms.LoadComboBox(dtb, Me.EUComboBox, False)
            Me.EUComboBox.SelectedIndex = -1
            Me.ProcessComboBox.DataSource = Nothing
            Me.btnCopyProcess.Enabled = False
        End If
    End Sub

    Private Sub EUComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EUComboBox.SelectedIndexChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Dim dtb As DataTable = Emissions.Utility.ProcessUtility.GetAPCDIDLookupTableByPlantEmissionUnitID(CInt(Me.EUComboBox.SelectedValue))
            Tools.WindowsForms.LoadComboBox(dtb, Me.ProcessComboBox, False)
            Me.ProcessComboBox.SelectedIndex = -1
            Me.btnCopyProcess.Enabled = False
        End If
    End Sub

    Private Sub ProcessComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessComboBox.SelectedIndexChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.btnCopyProcess.Enabled = True
        End If
    End Sub

    Private Sub btnCopyProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyProcess.Click

        Dim caption As String = "Confirm Copy"
        Dim text As String = "This function will copy all of the pollutants from the source process to the process you have specified." _
                           & vbCrLf _
                           & vbCrLf _
                           & "This action cannot be undone." _
                           & vbCrLf _
                           & vbCrLf _
                           & "Are you sure?"

        If (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            Try
                Call Me.CopyProcess()
                MessageBox.Show("Copy complete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If

        Me.ProcessDataSet.ProcessEmission.Clear()
        Me.btnCopyProcess.Enabled = False

    End Sub

    Private Sub CopyProcess()

        Dim errorsOccured As Boolean = False

        For Each row As EmissionsDataSet.ProcessEmissionRow In MainForm.EmissionsDataSet.ProcessEmission.Rows
            Dim processEmission As ProcessDataSet.ProcessEmissionRow = Me.ProcessDataSet.ProcessEmission.NewProcessEmissionRow
            With processEmission
                .ProcessID = CInt(Me.ProcessComboBox.SelectedValue)
                .EmissionYear = row.EmissionYear
                .EmissionPeriodTypeID = row.EmissionPeriodTypeID
                .PollutantID = row.PollutantID
                .DataOriginID = 1
                .ProcessEmissionTypeID = "R"
                .EmissionValue = 0
                .UnitofMeasurementID = row.UnitofMeasurementID
                .EmissionCalculationMethodID = row.EmissionCalculationMethodID
                .EmissionFactorValue = row.EmissionFactorValue
                .EmissionFactorUnitOfMeasurementID = row.EmissionFactorUnitOfMeasurementID
                .EmissionFactorProcessParameterTypeID = row.EmissionFactorProcessParameterTypeID
                .SetEmissionFactorReferenceNull()
                .SetCommentInternalNull()
                .SetCommentPublicNull()
                .AddDate = Date.Now
                .AddedBy = GlobalVariables.Employee.EmployeeID
            End With
            Me.ProcessDataSet.ProcessEmission.Rows.Add(processEmission)

            Try
                Me.ProcessEmissionTableAdapter.Update(processEmission)
            Catch ex As Exception
                If (InStr(ex.Message, "duplicate") > 0) Then
                    'ignore; pollutant is already there
                Else
                    GlobalMethods.HandleError(ex)
                    Throw New ApplicationException("An error occured while copying pollutants. If the problem persists please contact APCD IT for assistance.")
                End If
            End Try
        Next

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

   
End Class