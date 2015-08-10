Imports System.Data.OleDb

Public Class AddControlMeasureStep1

    Public Sub New(ByVal emissionYear As Int16, ByVal plantID As Int32, ByRef controlMeasureID As ArrayList)
        InitializeComponent()
        Me.m_emissionYear = emissionYear
        Me.m_plantID = plantID
        Me.m_controlMeasureID = controlMeasureID
    End Sub

    Private m_emissionYear As Int16
    Private m_plantID As Int32
    Private m_controlMeasureID As ArrayList

    Private Sub AddControlMeasureStep1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tools.WindowsForms.LoadComboBox(GlobalVariables.LookupTable.ControlMeasureType, Me.ControlMeasureTypeComboBox, False)
        Me.ControlMeasureTypeComboBox.SelectedIndex = -1
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        GlobalVariables.AddControlMeasureStep = GlobalVariables.WizardStep._Cancel
        Me.Close()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If (Me.IsValidForm) Then
            If (Me.Save() = True) Then
                GlobalVariables.AddControlMeasureStep = GlobalVariables.WizardStep._Next
            Else
                GlobalVariables.AddControlMeasureStep = GlobalVariables.WizardStep._Cancel
            End If
            Me.Close()
        End If
    End Sub

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim blnIsValidForm As Boolean

        If (Not Me.IsValidAPCDID) Then
            blnIsValidForm = False
        ElseIf (Not Me.IsValidControlMeasureType) Then
            blnIsValidForm = False
        Else
            blnIsValidForm = True
        End If

        Return blnIsValidForm

    End Function

    Private Function IsValidAPCDID() As Boolean

        Dim dataIsValid As Boolean

        If (Me.ControlMeasureAPCDIDTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.ControlMeasureAPCDIDTextBox, "Please enter the APCD ID.")
            Me.ErrorProvider1.SetIconAlignment(Me.ControlMeasureAPCDIDTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.ControlMeasureAPCDIDTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidControlMeasureType() As Boolean

        Dim dataIsValid As Boolean

        If (Me.ControlMeasureTypeComboBox.SelectedIndex = -1) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.ControlMeasureTypeComboBox, "Please select a type.")
            Me.ErrorProvider1.SetIconAlignment(Me.ControlMeasureTypeComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(ControlMeasureTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

#End Region '----- Validation -----

    Private Function Save() As Boolean

        Dim controlMeasureID As Int32

        Me.Validate()
        Me.ControlMeasureBindingSource.EndEdit()

        Try
            Try
                Call Me.AddControlMeasureRow()
                Me.TableAdapterManager.ControlMeasureTableAdapter.Connection.Open()
                Me.TableAdapterManager.ControlMeasureTableAdapter.Update(Me.EmissionsDataSet.ControlMeasure)
                Dim cmd As New OleDbCommand("SELECT @@IDENTITY", Me.TableAdapterManager.ControlMeasureTableAdapter.Connection)
                controlMeasureID = CInt(cmd.ExecuteScalar)
            Catch ex As Exception
                GlobalMethods.HandleError(ex)
                If (ex.Message = GlobalVariables.ErrorMessage.Database.DuplicateRecord) Then
                    Throw New ApplicationException("A control measure with the ID your trying to add already exists. Change the ID and try again.")
                Else
                    Throw New ApplicationException("An error occured saving the control measure.")
                End If
            Finally
                Me.TableAdapterManager.ControlMeasureTableAdapter.Connection.Close()
            End Try

            Try
                Call Me.AddControlMeasureYearRow(controlMeasureID)
                Me.TableAdapterManager.ControlMeasureYearTableAdapter.Update(Me.EmissionsDataSet.ControlMeasureYear)
            Catch ex3 As Exception
                GlobalMethods.HandleError(ex3)
                Throw New ApplicationException("An error occured saving the control measure year.")
            End Try

            Me.m_controlMeasureID.Add(controlMeasureID)
            Save = True
        Catch exMain As Exception
            MessageBox.Show(exMain.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Save = False
        End Try

    End Function

    Private Sub AddControlMeasureRow()
        Dim row As EmissionsDataSet.ControlMeasureRow = Me.EmissionsDataSet.ControlMeasure.NewControlMeasureRow
        With row
            If (Me.ControlMeasureDescriptionTextBox.Text.Trim.Length = 0) Then
                .SetControlMeasureDescriptionNull()
            Else
                .ControlMeasureDescription = Me.ControlMeasureDescriptionTextBox.Text.Trim
            End If

            .PlantID = Me.m_plantID
            .ControlMeasureTypeID = CInt(Me.ControlMeasureTypeComboBox.SelectedValue)
            .ControlMeasureAPCDID = Me.ControlMeasureAPCDIDTextBox.Text.Trim
            .BeginDate = New Date(Date.Now.Year - 1, 1, 1)
            .SetEndDateNull()

            If (Me.CompanyCommentTextBox.Text.Trim.Length = 0) Then
                .SetCompanyCommentNull()
            Else
                .CompanyComment = Me.CompanyCommentTextBox.Text.Trim
            End If

            If (Me.APCDCommentTextBox.Text.Trim.Length = 0) Then
                .SetAPCDCommentNull()
            Else
                .APCDComment = Me.APCDCommentTextBox.Text.Trim
            End If

            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With
        Me.EmissionsDataSet.ControlMeasure.Rows.Add(row)
        ''Call Me.Save()
    End Sub

    Private Sub AddControlMeasureYearRow(ByVal controlMeasureID As Int32)
        Dim row As EmissionsDataSet.ControlMeasureYearRow = Me.EmissionsDataSet.ControlMeasureYear.NewControlMeasureYearRow
        With row
            .ControlMeasureID = controlMeasureID
            .EmissionYear = Me.m_emissionYear
            .IsExcluded = False
            .SetDoneDateNull()
            .SetDoneByNull()
            .SetApprovalEmployeeIDNull()
            .SetApprovalDateNull()
            .SetApprovalCommentNull()
        End With
        Me.EmissionsDataSet.ControlMeasureYear.Rows.Add(row)
    End Sub

    Private Sub ControlMeasureBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.ControlMeasureBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EmissionsDataSet)

    End Sub

    
End Class