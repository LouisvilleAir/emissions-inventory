Imports System.Data.OleDb

Public Class AddProcessStep1

    Public Sub New(ByVal emissionYear As Int16, ByVal plantEmissionUnitID As Int32)
        InitializeComponent()
        Me.m_emissionYear = emissionYear
        Me.m_plantEmissionUnitID = plantEmissionUnitID
    End Sub

    Private m_emissionYear As Int16
    Private m_plantEmissionUnitID As Int32
    Private m_process As EmissionsDataSet.ProcessRow



#Region "----- load -----"

    Private Sub AddProcessStep1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Tools.WindowsForms.LoadComboBox(GlobalVariables.LookupTable.ThroughputType_Real, Me.ThroughputTypeComboBox)
        Me.ThroughputTypeComboBox.SelectedIndex = -1
        Me.lblSCCName.Text = String.Empty
        Me.lblSCCNumber.Text = String.Empty

    End Sub

#End Region '----- load -----


#Region "----- buttons -----"

    Private Sub btnLookupProcessClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeProcessClass.Click

        Dim list As New ArrayList
        Dim frm As New SCCCodeSelectorForm(list)
        frm.ShowDialog()
        If (list.Count = 2) Then
            Me.lblSCCNumber.Text = CStr(list(0))
            Me.lblSCCName.Text = CStr(list(1))
        End If

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        If (Me.IsValidForm) Then
            Call Me.SetObjectValues()

            If (Me.Save) Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If

    End Sub

    Private Sub SetObjectValues()

        Me.m_process = Me.EmissionsDataSet.Process.NewProcessRow

        With Me.m_process
            .SetProcessNameNull()

            .ProcessClassID = Me.lblSCCNumber.Text
            .ThroughputTypeID = CInt(Me.ThroughputTypeComboBox.SelectedValue)
            .ProcessAPCDID = Me.ProcessAPCDIDTextBox.Text.Trim

            If (Me.ProcessDescriptionTextBox.Text.Trim.Length = 0) Then
                .SetProcessDescriptionNull()
            Else
                .ProcessDescription = Me.ProcessDescriptionTextBox.Text.Trim
            End If

            If (Me.CommentPublicTextBox.Text.Trim.Length = 0) Then
                .SetCommentPublicNull()
            Else
                .CommentPublic = Me.CommentPublicTextBox.Text.Trim
            End If

            If (Me.CommentInternalTextBox.Text.Trim.Length = 0) Then
                .SetCommentInternalNull()
            Else
                .CommentInternal = Me.CommentInternalTextBox.Text.Trim
            End If

            If (Me.ControlApproachDescriptionTextBox.Text.Trim.Length = 0) Then
                .SetControlApproachDescriptionNull()
            Else
                .ControlApproachDescription = Me.ControlApproachDescriptionTextBox.Text.Trim
            End If

            .PlantEmissionUnitID = Me.m_plantEmissionUnitID
            .ProcessEISID = EmissionsInventory.GlobalMethods.GenerateTempEISID
            .BeginDate = New Date(Date.Now.Year - 1, 1, 1)
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With

        Me.EmissionsDataSet.Process.Rows.Add(Me.m_process)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region '----- buttons -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        If (Not Me.IsValidProcessClass) Then
            IsValidForm = False
        ElseIf (Not Me.IsValidThroughputType) Then
            IsValidForm = False
        ElseIf (Not Me.IsValidAPCDID) Then
            IsValidForm = False
        Else
            IsValidForm = True
        End If

    End Function

    Private Function IsValidProcessClass() As Boolean

        Dim dataIsValid As Boolean

        If (Me.lblSCCNumber.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.lblSCCNumber, "SCC Number is required.")
            Me.ErrorProvider1.SetIconAlignment(Me.lblSCCNumber, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.lblSCCNumber, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidThroughputType() As Boolean

        Dim dataIsValid As Boolean

        If (ThroughputTypeComboBox.SelectedIndex = -1) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.ThroughputTypeComboBox, "Please select a Throughput Type")
            Me.ErrorProvider1.SetIconAlignment(Me.ThroughputTypeComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ThroughputTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidAPCDID() As Boolean

        Dim dataIsValid As Boolean

        If (ProcessAPCDIDTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(ProcessAPCDIDTextBox, "Please enter the APCD ID.")
            Me.ErrorProvider1.SetIconAlignment(ProcessAPCDIDTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ProcessAPCDIDTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

#End Region '----- Validation -----

    Private Function Save() As Boolean
        Me.Validate()
        Me.ProcessBindingSource.EndEdit()

        Dim processID As Int32

        Try
            Try
                'process
                Me.TableAdapterManager.ProcessTableAdapter.Connection.Open()
                Me.TableAdapterManager.ProcessTableAdapter.Update(Me.EmissionsDataSet.Process)
                Dim cmd As New OleDbCommand("SELECT @@IDENTITY", Me.TableAdapterManager.ProcessTableAdapter.Connection)
                processID = CInt(cmd.ExecuteScalar)
                Me.TableAdapterManager.ProcessTableAdapter.Connection.Close()
            Catch ex As Exception
                GlobalMethods.HandleError(ex)
                If (ex.Message = GlobalVariables.ErrorMessage.Database.DuplicateRecord) Then
                    Throw New ApplicationException("A process with the ID your trying to add already exists. Change the ID and try again.")
                Else
                    Throw New ApplicationException(GlobalVariables.ErrorPrompt.Database.SavingRecord)
                End If
            End Try

            Try
                'year
                Call Me.CreateYearRecord()
                Me.EmissionsDataSet.ProcessYear.Rows(0)(EmissionsDataSet.ProcessYear.ProcessIDColumn.ColumnName) = processID
                Me.TableAdapterManager.ProcessYearTableAdapter.Update(Me.EmissionsDataSet.ProcessYear)
            Catch ex As Exception
                GlobalMethods.HandleError(ex)
                Throw New ApplicationException(GlobalVariables.ErrorPrompt.Database.SavingRecord)
            End Try

            Save = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Save = False
        End Try

    End Function

    Private Sub CreateYearRecord()

        Dim newYearRow As EmissionsDataSet.ProcessYearRow = Me.EmissionsDataSet.ProcessYear.NewProcessYearRow
        With newYearRow
            .ProcessID = Me.m_process.ProcessID
            .EmissionYear = Me.m_emissionYear
        End With
        Me.EmissionsDataSet.ProcessYear.Rows.Add(newYearRow)

    End Sub
   
End Class