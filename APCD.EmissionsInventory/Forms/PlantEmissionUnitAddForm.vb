Imports APCD.Emissions

Public Class PlantEmissionUnitAddForm

    Sub New()
        InitializeComponent()
    End Sub

    Private Sub PlantEmissionUnitAddForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Me.SetDefaults()

    End Sub

    Private Sub SetDefaults()

        Call Me.LoadDataTables()
        Call Me.LoadComboBoxes()

    End Sub

    Private Sub LoadDataTables()

        If (GlobalVariables.EmissionUnitTypeLookupTable Is Nothing) Then
            GlobalVariables.EmissionUnitTypeLookupTable = Utility.EmissionUnitTypeUtility.GetLookupTable
            Call Tools.Data.DataTableHelper.InsertBlankRowToTop(GlobalVariables.EmissionUnitTypeLookupTable)
        End If

    End Sub

    Private Sub LoadComboBoxes()

        Tools.WindowsForms.LoadComboBox(GlobalVariables.EmissionUnitTypeLookupTable, Me.EmissionUnitTypeComboBox)

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        If (Me.IsValidForm) Then
            Me.Save()
            Me.Close()
        End If

    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        'set the objec to nothing since it's nothing is being added.
        GlobalVariables.PlantEmissionUnitObject = Nothing
        Me.Close()

    End Sub

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        Dim blnIsFormValid As Boolean

        If (Not Me.IsValidPlantEmissionUnitName) Then
            blnIsFormValid = False
        ElseIf (Not Me.IsValidEmissionUnitType) Then
            blnIsFormValid = False
        ElseIf (Not Me.IsValidAPCDID) Then
            blnIsFormValid = False
        ElseIf (Not Me.IsValidEmissionUnitDescription) Then
            blnIsFormValid = False
        ElseIf (Not Me.IsValidBeginDate) Then
            blnIsFormValid = False
        Else
            blnIsFormValid = True
        End If

        Return blnIsFormValid

    End Function

    'plantEmissionUnit
    Private Function IsValidPlantEmissionUnitName() As Boolean

        Dim dataIsValid As Boolean

        If (Me.PlantEmissionUnitNameTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(PlantEmissionUnitNameTextBox, "Please enter a name")
            Me.ErrorProvider1.SetIconAlignment(PlantEmissionUnitNameTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(PlantEmissionUnitNameTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    'emissionunitType
    Private Function IsValidEmissionUnitType() As Boolean

        Dim dataIsValid As Boolean

        If (EmissionUnitTypeComboBox.SelectedIndex < 1) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(EmissionUnitTypeComboBox, "Please select an Emission Unit Type")
            Me.ErrorProvider1.SetIconAlignment(EmissionUnitTypeComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(EmissionUnitTypeComboBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    'APCD ID
    Private Function IsValidAPCDID() As Boolean

        Dim dataIsValid As Boolean

        If (EmissionUnitAPCDIDTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(EmissionUnitAPCDIDTextBox, "Please enter the APCD ID.")
            Me.ErrorProvider1.SetIconAlignment(EmissionUnitAPCDIDTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(EmissionUnitAPCDIDTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    'description
    Private Function IsValidEmissionUnitDescription() As Boolean

        Dim dataIsValid As Boolean

        If (EmissionUnitDescriptionTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(EmissionUnitDescriptionTextBox, "Please enter a description.")
            Me.ErrorProvider1.SetIconAlignment(EmissionUnitDescriptionTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(EmissionUnitDescriptionTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function

    'begin date
    Private Function IsValidBeginDate() As Boolean

        Dim dataIsValid As Boolean

        If (Me.BeginDateTextBox.Text.Trim.Length = 0) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.BeginDateTextBox, "Begin date is required.")
            Me.ErrorProvider1.SetIconAlignment(Me.BeginDateTextBox, ErrorIconAlignment.MiddleLeft)

        ElseIf (Not IsDate(Me.BeginDateTextBox.Text.Trim)) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.BeginDateTextBox, "Invalid date.")
            Me.ErrorProvider1.SetIconAlignment(Me.BeginDateTextBox, ErrorIconAlignment.MiddleLeft)

        ElseIf (CDate(Me.BeginDateTextBox.Text.Trim).Year > CInt(My.Settings.CurrentEmissionYear)) Then
            dataIsValid = False
            Me.ErrorProvider1.SetError(Me.BeginDateTextBox, "Begin date year cannot be after the current emission year.")
            Me.ErrorProvider1.SetIconAlignment(Me.BeginDateTextBox, ErrorIconAlignment.MiddleLeft)

        Else
            dataIsValid = True
            Me.ErrorProvider1.SetError(Me.BeginDateTextBox, String.Empty)
        End If

        Return dataIsValid

    End Function


#End Region '----- Validation -----

#Region "----- save the data -----"

    Private Function Save() As Boolean

        Dim savedStatus As Boolean

        Call Me.AssignObjectVariables()
        Try
            GlobalVariables.PlantEmissionUnitObject.Insert()
            savedStatus = True
        Catch ex As Exception
            GlobalVariables.ApplicationLog.AppendLine(ex.Message)
            GlobalVariables.ApplicationLog.AppendLine(GlobalVariables.PlantEmissionUnitObject.ToString)
            If (ex.Message = GlobalVariables.ErrorMessage.Database.DuplicateRecord) Then
                MessageBox.Show(GlobalVariables.ErrorPrompt.Database.APCDIDAlreadyExists, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            GlobalVariables.PlantEmissionUnitObject = Nothing
            savedStatus = False
        End Try

        Return savedStatus

    End Function

    Private Sub AssignObjectVariables()

        With GlobalVariables.PlantEmissionUnitObject
            .PlantEmissionUnitName = Me.PlantEmissionUnitNameTextBox.Text.Trim & String.Empty
            .EmissionUnitTypeID = CInt(Me.EmissionUnitTypeComboBox.SelectedValue)
            .EmissionUnitAPCDID = Me.EmissionUnitAPCDIDTextBox.Text.Trim
            .EmissionUnitEISID = Globals.GlobalMethods.GenerateTempEISID
            .EmissionUnitDescription = Me.EmissionUnitDescriptionTextBox.Text.Trim
            .CommentPublic = Me.CommentPublicTextBox.Text.Trim
            .CommentInternal = Me.CommentInternalTextBox.Text.Trim
            .BeginDate = CDate(Me.BeginDateTextBox.Text.Trim)
            .AddDate = Date.Now
            .AddedBy = GlobalVariables.Employee.EmployeeID
        End With

    End Sub

#End Region '----- save the data -----

    Private Sub BeginDateDateTimePicker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeginDateDateTimePicker.ValueChanged
        Me.BeginDateTextBox.Text = Format(Me.BeginDateDateTimePicker.Value, GlobalVariables.DateFormat._Short)
    End Sub

    Private Sub PlantEmissionUnitNameTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PlantEmissionUnitNameTextBox.Validating
        Call Me.IsValidPlantEmissionUnitName()
    End Sub

    Private Sub EmissionUnitTypeComboBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EmissionUnitTypeComboBox.Validating
        Call Me.IsValidEmissionUnitType()
    End Sub

    Private Sub EmissionUnitAPCDIDTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EmissionUnitAPCDIDTextBox.KeyPress

        If ((Asc(e.KeyChar) = 8) OrElse (Asc(e.KeyChar) = 45)) Then 'allow backspace and hyphen
            '
        ElseIf (Not Char.IsLetterOrDigit(e.KeyChar)) Then
            e.Handled = True
        End If

    End Sub


    Private Sub EmissionUnitAPCDIDTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EmissionUnitAPCDIDTextBox.Validating
        Call Me.IsValidAPCDID()
    End Sub

    Private Sub EmissionUnitDescriptionTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EmissionUnitDescriptionTextBox.Validating
        Call Me.IsValidEmissionUnitDescription()
    End Sub

   
End Class