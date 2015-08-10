Imports APCD.Emissions
Imports System.Text

Public Class ProcessControlMeasureAddEditForm

    Private m_blnFormIsLoaded As Boolean = False
    Private m_intPlantID As Int32
    Private m_DMLMode As GlobalVariables.DMLMode
    Private m_processControlMeasure As EmissionsDataSet.ProcessControlMeasureRow

    Sub New(ByVal intPlantID As Int32, ByVal processControlMeasure As EmissionsDataSet.ProcessControlMeasureRow, ByVal mode As GlobalVariables.DMLMode)
        InitializeComponent()
        Me.m_intPlantID = intPlantID
        Me.m_processControlMeasure = processControlMeasure
        Me.m_DMLMode = mode
    End Sub

#Region "----- startup -----"

    Private Sub ProcessControlMeasureAddEditForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Me.LoadComboBox()
        Call Me.AssignControlValues()
        Me.m_blnFormIsLoaded = True

    End Sub

    Private Sub LoadComboBox()

        Dim filteredView As DataView = MainForm.NavigationTable.ControlMeasure.DefaultView

        Dim filter As New StringBuilder
        With filter
            .Append(EmissionsDataSet.Plant.PlantIDColumn.ColumnName)
            .Append(Tools.Constants.Character.EqualSign)
            .Append(CStr(Me.m_intPlantID))
            .Append(" AND EndDate IS NULL AND IsExcluded = 'False'")
        End With

        filteredView.RowFilter = filter.ToString

        Select Case Me.m_DMLMode
            Case GlobalVariables.DMLMode.Insert
                If (MainForm.EmissionsDataSet.ProcessControlMeasure.Rows.Count = 0) Then
                    Tools.WindowsForms.LoadComboBox(filteredView, Me.ControlMeasureComboBox)
                Else
                    With filter
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._And)
                        .Append(Tools.Constants.Character.Space)
                        .Append(Constants.ControlMeasureConstants.FieldName.ControlMeasureID)
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._Not)
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._In)
                        .Append(Tools.Constants.Character.Space)
                        .Append(Tools.Constants.Character.LeftParenthesis)
                        For rowCount As Int32 = 0 To MainForm.EmissionsDataSet.ProcessControlMeasure.Rows.Count - 1
                            If (rowCount > 0) Then
                                .Append(Tools.Constants.Character.Comma)
                            End If
                            .Append(CStr(MainForm.EmissionsDataSet.ProcessControlMeasure.Rows(rowCount)(Constants.ControlMeasureConstants.FieldName.ControlMeasureID)))
                        Next
                        .Append(Tools.Constants.Character.RightParenthesis)
                    End With

                    filteredView.RowFilter = filter.ToString
                    Tools.WindowsForms.LoadComboBox(filteredView, Me.ControlMeasureComboBox)
                End If

            Case GlobalVariables.DMLMode.Update
                Tools.WindowsForms.LoadComboBox(filteredView, Me.ControlMeasureComboBox)
        End Select

    End Sub

    Private Sub AssignControlValues()

        If (Me.m_DMLMode = GlobalVariables.DMLMode.Insert) Then
            Me.Text = "Add Process Control Measure"
            Me.ControlMeasureComboBox.SelectedIndex = -1

        Else
            Me.Text = "Edit Process Control Measure"
            Me.ControlMeasureComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ControlMeasureComboBox, Me.m_processControlMeasure.ControlMeasureID)

            Me.CapturePercentTextBox.Text = CStr(Me.m_processControlMeasure.CapturePercent)
            Me.UptimePercentTextBox.Text = CStr(Me.m_processControlMeasure.UptimePercent)
            Me.SequenceTextBox.Text = CStr(Me.m_processControlMeasure.Sequence)

            If (Me.m_processControlMeasure.IsCommentPublicNull) Then
                Me.CommentPublicTextBox.Text = String.Empty
            Else
                Me.CommentPublicTextBox.Text = Me.m_processControlMeasure.CommentPublic
            End If

            If (Me.m_processControlMeasure.IsCommentInternalNull) Then
                Me.CommentInternalTextBox.Text = String.Empty
            Else
                Me.CommentInternalTextBox.Text = Me.m_processControlMeasure.CommentInternal
            End If

            Me.ControlMeasureComboBox.Enabled = False
        End If

    End Sub

#End Region '----- startup -----

#Region "----- buttons -----"
    Private Sub CapturePercentTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CapturePercentTextBox.KeyPress

        If ((Asc(e.KeyChar) = 8) OrElse (Asc(e.KeyChar) = 46)) Then 'allow backspace and period
            '
        ElseIf (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If (Me.IsValidForm) Then
            If (Me.m_DMLMode = GlobalVariables.DMLMode.Insert) Then
                Call Me.AddRowForShow()
            Else
                Call Me.UpdateRowForShow()
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

#End Region '----- buttons -----

#Region "----- Validation -----"

    Private Function IsValidForm() As Boolean

        If (Not Me.IsValidControlMeasure) Then
            IsValidForm = False
        ElseIf (Not Me.IsValidPercent(Me.CapturePercentTextBox)) Then
            IsValidForm = False
        ElseIf (Not Me.IsValidPercent(Me.UptimePercentTextBox)) Then
            IsValidForm = False
        ElseIf (Not Me.IsValidSequence) Then
            IsValidForm = False
        Else
            IsValidForm = True
        End If

    End Function

    Private Function IsValidControlMeasure() As Boolean

        Dim isValidData As Boolean

        If (Me.ControlMeasureComboBox.SelectedIndex = -1) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.ControlMeasureComboBox, "Please select a control measure.")
            Me.ErrorProvider1.SetIconAlignment(Me.ControlMeasureComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            isValidData = True
            Me.ErrorProvider1.SetError(Me.ControlMeasureComboBox, String.Empty)
        End If

        Return isValidData

    End Function

    Private Function IsValidPercent(ByVal ctl As Control) As Boolean

        Const cstrMessage As String = "Enter a value from 1 to 100."
        Dim isValidData As Boolean
        Dim strPercent As String = String.Empty

        If (ctl.Name = "CapturePercentTextBox") Then
            strPercent = Me.CapturePercentTextBox.Text.Trim
        ElseIf (ctl.Name = "UptimePercentTextBox") Then
            strPercent = Me.UptimePercentTextBox.Text.Trim
        End If

        If (strPercent.Length = 0) Then
            isValidData = False
            Me.ErrorProvider1.SetError(ctl, cstrMessage)
            Me.ErrorProvider1.SetIconAlignment(ctl, ErrorIconAlignment.MiddleLeft)

        ElseIf (Not IsNumeric(strPercent)) Then
            isValidData = False
            Me.ErrorProvider1.SetError(ctl, cstrMessage)
            Me.ErrorProvider1.SetIconAlignment(ctl, ErrorIconAlignment.MiddleLeft)

        Else
            Dim sngEmissionsPercent As Single = CSng(strPercent)
            If ((sngEmissionsPercent < 0) OrElse (sngEmissionsPercent > 100)) Then
                isValidData = False
                Me.ErrorProvider1.SetError(ctl, cstrMessage)
                Me.ErrorProvider1.SetIconAlignment(ctl, ErrorIconAlignment.MiddleLeft)
            Else
                isValidData = True
                Me.ErrorProvider1.SetError(ctl, String.Empty)
            End If
        End If

        Return isValidData

    End Function

    Private Function IsValidSequence() As Boolean

        Dim sequence As String = Me.SequenceTextBox.Text.Trim

        If (sequence.Length = 0) Then
            IsValidSequence = False
            Me.ErrorProvider1.SetError(Me.SequenceTextBox, "Enter a value greater than 0.")
            Me.ErrorProvider1.SetIconAlignment(Me.SequenceTextBox, ErrorIconAlignment.MiddleLeft)
        Else
            IsValidSequence = True
            Me.ErrorProvider1.SetError(Me.SequenceTextBox, String.Empty)
        End If

    End Function

#End Region '----- Validation -----

#Region "----- Control changed events -----"

    Private Sub ControlMeasureComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlMeasureComboBox.SelectedIndexChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_processControlMeasure.ControlMeasureID = CInt(Me.ControlMeasureComboBox.SelectedValue)
        End If
    End Sub

    Private Sub CapturePercentTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapturePercentTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            If (Me.CapturePercentTextBox.Text.Trim.Length > 0) Then
                If (IsNumeric(Me.CapturePercentTextBox.Text.Trim)) Then
                    Me.m_processControlMeasure.CapturePercent = CSng(Me.CapturePercentTextBox.Text.Trim)
                End If
            End If
        End If
    End Sub

    Private Sub UptimePercentTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UptimePercentTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            If (Me.UptimePercentTextBox.Text.Trim.Length > 0) Then
                If (IsNumeric(Me.UptimePercentTextBox.Text.Trim)) Then
                    Me.m_processControlMeasure.UptimePercent = CSng(Me.UptimePercentTextBox.Text.Trim)
                End If
            End If
        End If
    End Sub

    Private Sub SequenceTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SequenceTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            If (Me.SequenceTextBox.Text.Trim.Length > 0) Then
                If (IsNumeric(Me.SequenceTextBox.Text.Trim)) Then
                    Me.m_processControlMeasure.Sequence = CShort(Me.SequenceTextBox.Text.Trim)
                End If
            End If
        End If
    End Sub

    Private Sub CommentPublicTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentPublicTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            If (Me.CommentPublicTextBox.Text.Trim.Length = 0) Then
                Me.m_processControlMeasure.SetCommentPublicNull()
            Else
                Me.m_processControlMeasure.CommentPublic = Me.CommentPublicTextBox.Text.Trim
            End If
        End If
    End Sub

    Private Sub CommentInternalTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentInternalTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            If (Me.CommentInternalTextBox.Text.Trim.Length = 0) Then
                Me.m_processControlMeasure.SetCommentInternalNull()
            Else
                Me.m_processControlMeasure.CommentInternal = Me.CommentInternalTextBox.Text.Trim
            End If
        End If
    End Sub

#End Region '----- Control changed events -----

    Private Sub AddRowForShow()
        Try
            Dim row As EmissionsDataSet.Process_ControlMeasureTabRow = MainForm.EmissionsDataSet.Process_ControlMeasureTab.NewProcess_ControlMeasureTabRow
            With row
                .ProcessControlMeasureID = Me.m_processControlMeasure.ProcessControlMeasureID
                .ProcessID = Me.m_processControlMeasure.ProcessID
                .EmissionYear = Me.m_processControlMeasure.EmissionYear
                .ControlMeasureAPCDID = Me.ControlMeasureComboBox.Text
                .CapturePercent = CSng(Me.CapturePercentTextBox.Text.Trim)
                .UptimePercent = CSng(Me.UptimePercentTextBox.Text.Trim)
                .Sequence = CShort(Me.SequenceTextBox.Text.Trim)
            End With
            MainForm.EmissionsDataSet.Process_ControlMeasureTab.Rows.Add(row)
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateRowForShow()

        Try
            For Each row As EmissionsDataSet.Process_ControlMeasureTabRow In MainForm.EmissionsDataSet.Process_ControlMeasureTab
                If (row.ProcessControlMeasureID = Me.m_processControlMeasure.ProcessControlMeasureID) Then
                    row.CapturePercent = CSng(Me.CapturePercentTextBox.Text.Trim)
                    row.UptimePercent = CSng(Me.UptimePercentTextBox.Text.Trim)
                    row.Sequence = CShort(Me.SequenceTextBox.Text.Trim)
                    Exit For
                End If
            Next
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class