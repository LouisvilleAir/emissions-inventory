Imports System.Data.OleDb

Public Class AddEmissionUnit

    Public Sub New(ByVal emissionYear As Int16, ByVal plantID As Int32)
        InitializeComponent()
        Me.m_emissionYear = emissionYear
        Me.m_plantID = plantID
    End Sub

    Private m_emissionYear As Int16
    Private m_plantID As Int32
    Private m_emissionUnit As EmissionsDataSet.PlantEmissionUnitRow

#Region "----- load -----"

    Private Sub AddEmissionUnit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Me.LoadComboBox()

    End Sub

    Private Sub LoadComboBox()

        Tools.WindowsForms.LoadComboBox(GlobalVariables.LookupTable.EmissionUnitType_Real, Me.EmissionUnitTypeComboBox)
        Me.EmissionUnitTypeComboBox.SelectedIndex = -1

    End Sub

#End Region '----- load -----

#Region "----- buttons -----"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (Me.IsValidForm) Then
            Call Me.SetObjectValues()

            If (Me.Save) Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region '----- buttons -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        If (Not Me.IsValidEmissionUnitType) Then
            IsValidForm = False
        ElseIf (Not Me.IsValidAPCDID) Then
            IsValidForm = False
        Else
            IsValidForm = True
        End If

    End Function

    Private Function IsValidEmissionUnitType() As Boolean

        Dim dataIsValid As Boolean

        If (Me.EmissionUnitTypeComboBox.SelectedIndex = -1) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.EmissionUnitTypeComboBox, "Please select a Throughput Type")
            Me.ErrorProvider1.SetIconAlignment(Me.EmissionUnitTypeComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.EmissionUnitTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    Private Function IsValidAPCDID() As Boolean

        Dim dataIsValid As Boolean

        If (Me.EmissionUnitAPCDIDTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.EmissionUnitAPCDIDTextBox, "Please enter the APCD ID.")
            Me.ErrorProvider1.SetIconAlignment(Me.EmissionUnitAPCDIDTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.EmissionUnitAPCDIDTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

#End Region '----- Validation -----

    Private Sub SetObjectValues()

        If (Me.m_emissionUnit Is Nothing) Then
            Me.m_emissionUnit = Me.EmissionsDataSet.PlantEmissionUnit.NewPlantEmissionUnitRow
            Me.EmissionsDataSet.PlantEmissionUnit.Rows.Add(Me.m_emissionUnit)

            With Me.m_emissionUnit
                .PlantEmissionUnitName = "DELETE THIS FIELD FOR EI YEAR 2012"
                .PlantID = Me.m_plantID
                .EmissionUnitEISID = EmissionsInventory.GlobalMethods.GenerateTempEISID
                .BeginDate = New Date(Date.Now.Year - 1, 1, 1)
                .SetEndDateNull()
                .AddDate = Date.Now
                .AddedBy = GlobalVariables.Employee.EmployeeID
            End With
        End If

        With Me.m_emissionUnit
            .EmissionUnitTypeID = CInt(Me.EmissionUnitTypeComboBox.SelectedValue)
            .EmissionUnitAPCDID = Me.EmissionUnitAPCDIDTextBox.Text.Trim

            If (Me.EmissionUnitDescriptionTextBox.Text.Trim.Length = 0) Then
                Me.m_emissionUnit.SetEmissionUnitDescriptionNull()
            Else
                Me.m_emissionUnit.EmissionUnitDescription = Me.EmissionUnitDescriptionTextBox.Text.Trim
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
        End With

    End Sub

    Private Function Save() As Boolean
        Me.Validate()
        Me.PlantEmissionUnitBindingSource.EndEdit()

        Dim emissionUnitID As Int32

        Try
            Try
                Me.TableAdapterManager.PlantEmissionUnitTableAdapter.Connection.Open()
                Me.TableAdapterManager.PlantEmissionUnitTableAdapter.Update(Me.EmissionsDataSet.PlantEmissionUnit)
                Dim cmd As New OleDbCommand("SELECT @@IDENTITY", Me.TableAdapterManager.PlantEmissionUnitTableAdapter.Connection)
                emissionUnitID = CInt(cmd.ExecuteScalar)
            Catch ex As Exception
                GlobalMethods.HandleError(ex)
                If (ex.Message = GlobalVariables.ErrorMessage.Database.DuplicateRecord) Then
                    Throw New ApplicationException("An emission unit with the ID your trying to add already exists. Change the ID and try again.")
                Else
                    Throw New ApplicationException("An error occured saving the EU.")
                End If
            Finally
                Me.TableAdapterManager.PlantEmissionUnitTableAdapter.Connection.Close()
            End Try

            Try
                Call Me.CreateYearRecord(emissionUnitID)
            Catch ex As Exception
                GlobalMethods.HandleError(ex)
                Throw New ApplicationException("An error occured saving the EU Year record.")
            End Try

            Save = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Save = False
        End Try

    End Function

    Private Sub CreateYearRecord(ByVal emissionUnitID As Int32)

        'create the row
        Dim newYearRow As EmissionsDataSet.PlantEmissionUnitYearRow = Me.EmissionsDataSet.PlantEmissionUnitYear.NewPlantEmissionUnitYearRow
        With newYearRow
            .PlantEmissionUnitID = emissionUnitID
            .EmissionYear = Me.m_emissionYear
            .OperatingStatusTypeEISID = GlobalVariables.OperatingStatus.Operating
            .IsExcluded = False
            .SetApprovalCommentNull()
        End With
        Me.EmissionsDataSet.PlantEmissionUnitYear.Rows.Add(newYearRow)

        'save it
        Me.TableAdapterManager.PlantEmissionUnitYearTableAdapter.Update(Me.EmissionsDataSet.PlantEmissionUnitYear)

    End Sub

   
End Class