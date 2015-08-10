Imports APCD.Emissions
Imports System.Text

Public Class ProcessReleasePointAddEditForm

    Private m_blnFormIsLoaded As Boolean = False

    Private m_intPlantID As Int32
    Private m_processReleasePoint As EmissionsDataSet.ProcessReleasePointRow
    Private m_processReleasePoints As EmissionsDataSet.ProcessReleasePointDataTable

    Sub New(ByVal intPlantID As Int32, ByVal processReleasePoint As EmissionsDataSet.ProcessReleasePointRow, ByVal processReleasePoints As EmissionsDataSet.ProcessReleasePointDataTable)
        InitializeComponent()
        Me.m_intPlantID = intPlantID
        Me.m_processReleasePoint = processReleasePoint
        Me.m_processReleasePoints = processReleasePoints
    End Sub

    Sub New(ByVal intPlantID As Int32, ByVal processReleasePoint As EmissionsDataSet.ProcessReleasePointRow)
        InitializeComponent()
        Me.m_intPlantID = intPlantID
        Me.m_processReleasePoint = processReleasePoint
    End Sub

    Private m_DMLMode As DMLMode
    Private Enum DMLMode
        Add
        Edit
    End Enum

#Region "----- startup -----"

    Private Sub ProcessReleasePointAddEditForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Me.SetDMLMode()
        Call Me.LoadComboBox()
        Call Me.AssignControlValues()

        Me.m_blnFormIsLoaded = True

    End Sub

    Private Sub SetDMLMode()

        If (Me.m_processReleasePoints Is Nothing) Then
            Me.m_DMLMode = DMLMode.Edit
        Else
            Me.m_DMLMode = DMLMode.Add
        End If

    End Sub

    Private Sub LoadComboBox()

        Dim filteredView As DataView = MainForm.NavigationTable.ReleasePoint.DefaultView

        Dim filter As New StringBuilder
        With filter
            .Append(EmissionsDataSet.Plant.PlantIDColumn.ColumnName)
            .Append(Tools.Constants.Character.EqualSign)
            .Append(CStr(Me.m_intPlantID))
            .Append(" AND EndDate IS NULL AND IsExcluded = 'False'")
        End With

        filteredView.RowFilter = filter.ToString

        Select Case Me.m_DMLMode
            Case DMLMode.Add
                If (Me.m_processReleasePoints.Rows.Count = 0) Then
                    Tools.WindowsForms.LoadComboBox(filteredView, Me.ReleasePointComboBox)
                Else
                    With filter
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._And)
                        .Append(Tools.Constants.Character.Space)
                        .Append(Constants.ReleasePointConstants.FieldName.ReleasePointID)
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._Not)
                        .Append(Tools.Constants.Character.Space)
                        .Append(GlobalVariables.Words._In)
                        .Append(Tools.Constants.Character.Space)
                        .Append(Tools.Constants.Character.LeftParenthesis)
                        For rowCount As Int32 = 0 To Me.m_processReleasePoints.Rows.Count - 1
                            If (rowCount > 0) Then
                                .Append(Tools.Constants.Character.Comma)
                            End If
                            .Append(CStr(Me.m_processReleasePoints.Rows(rowCount)(Constants.ReleasePointConstants.FieldName.ReleasePointID)))
                        Next
                        .Append(Tools.Constants.Character.RightParenthesis)
                    End With

                    filteredView.RowFilter = filter.ToString
                    Tools.WindowsForms.LoadComboBox(filteredView, Me.ReleasePointComboBox)
                End If

            Case DMLMode.Edit
                Tools.WindowsForms.LoadComboBox(filteredView, Me.ReleasePointComboBox)
        End Select

    End Sub

    Private Sub AssignControlValues()

        If (Me.m_DMLMode = DMLMode.Add) Then
            Me.Text = "Add Process Release Point"
            Me.ReleasePointComboBox.SelectedIndex = -1
        Else
            Me.Text = "Edit Process Release Point"
            Me.ReleasePointComboBox.SelectedIndex = Tools.WindowsForms.GetIndexForValueMember(Me.ReleasePointComboBox, Me.m_processReleasePoint.ReleasePointID)
            Me.EmissionsPercentTextBox.Text = CStr(Me.m_processReleasePoint.EmissionsPercent)

            If (Me.m_processReleasePoint.IsCommentPublicNull) Then
                Me.CommentPublicTextBox.Text = String.Empty
            Else
                Me.CommentPublicTextBox.Text = Me.m_processReleasePoint.CommentPublic
            End If

            If (Me.m_processReleasePoint.IsCommentInternalNull) Then
                Me.CommentInternalTextBox.Text = String.Empty
            Else
                Me.CommentInternalTextBox.Text = Me.m_processReleasePoint.CommentInternal
            End If

            Me.ReleasePointComboBox.Enabled = False
        End If

    End Sub

#End Region '----- startup -----

#Region "----- buttons -----"

    Private Sub EmissionsPercentTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EmissionsPercentTextBox.KeyPress
        If (Asc(e.KeyChar) = 8) Then 'allow backspace 
            '
        ElseIf (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub '----- buttons -----

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If (Me.IsValidForm) Then
            If (Me.m_DMLMode = DMLMode.Add) Then
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

        If (Not Me.IsValidReleasePoint) Then
            IsValidForm = False
        ElseIf (Not Me.IsValidEmissionPercent) Then
            IsValidForm = False
        Else
            IsValidForm = True
        End If

    End Function

    Private Function IsValidReleasePoint() As Boolean

        Dim isValidData As Boolean

        If (Me.ReleasePointComboBox.SelectedIndex = -1) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.ReleasePointComboBox, "Please select a release point.")
            Me.ErrorProvider1.SetIconAlignment(Me.ReleasePointComboBox, ErrorIconAlignment.MiddleLeft)
        Else
            isValidData = True
            Me.ErrorProvider1.SetError(Me.ReleasePointComboBox, String.Empty)
        End If

        Return isValidData

    End Function

    Private Function IsValidEmissionPercent() As Boolean

        Dim isValidData As Boolean
        Dim strEmissionsPercent As String = Me.EmissionsPercentTextBox.Text.Trim

        If (strEmissionsPercent.Length = 0) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.EmissionsPercentTextBox, "Enter a value from 0 to 100.")
            Me.ErrorProvider1.SetIconAlignment(Me.EmissionsPercentTextBox, ErrorIconAlignment.MiddleLeft)

        ElseIf (Not IsNumeric(strEmissionsPercent)) Then
            isValidData = False
            Me.ErrorProvider1.SetError(Me.EmissionsPercentTextBox, "Enter a value from 0 to 100.")
            Me.ErrorProvider1.SetIconAlignment(Me.EmissionsPercentTextBox, ErrorIconAlignment.MiddleLeft)

        Else
            Dim intEmissionsPercent As Int32 = CInt(strEmissionsPercent)
            If ((intEmissionsPercent < 0) OrElse (intEmissionsPercent > 100)) Then
                isValidData = False
                Me.ErrorProvider1.SetError(Me.EmissionsPercentTextBox, "Enter a value from 0 to 100.")
                Me.ErrorProvider1.SetIconAlignment(Me.EmissionsPercentTextBox, ErrorIconAlignment.MiddleLeft)
            Else
                isValidData = True
                Me.ErrorProvider1.SetError(Me.EmissionsPercentTextBox, String.Empty)
            End If

        End If

        Return isValidData

    End Function

#End Region '----- Validation -----

#Region "----- changed events -----"

    Private Sub ReleasePointComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleasePointComboBox.SelectedIndexChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Me.m_processReleasePoint.ReleasePointID = CInt(Me.ReleasePointComboBox.SelectedValue)
        End If
    End Sub

    Private Sub EmissionsPercentTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmissionsPercentTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Dim text As String = Me.EmissionsPercentTextBox.Text.Trim
            If (text.Length > 0) Then
                If (IsNumeric(text)) Then
                    Me.m_processReleasePoint.EmissionsPercent = CShort(text)
                End If
            End If
        End If
    End Sub

    Private Sub CommentPublicTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentPublicTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Dim text As String = Me.CommentPublicTextBox.Text.Trim
            If (text.Length = 0) Then
                Me.m_processReleasePoint.SetCommentPublicNull()
            Else
                Me.m_processReleasePoint.CommentPublic = text
            End If
        End If
    End Sub

    Private Sub CommentInternalTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentInternalTextBox.TextChanged
        If (Me.m_blnFormIsLoaded = True) Then
            Dim text As String = Me.CommentInternalTextBox.Text.Trim
            If (text.Length = 0) Then
                Me.m_processReleasePoint.SetCommentInternalNull()
            Else
                Me.m_processReleasePoint.CommentInternal = text
            End If
        End If
    End Sub

#End Region '----- changed events -----

    Private Sub AddRowForShow()

        Try
            Dim row As EmissionsDataSet.Process_ReleasePointTabRow = MainForm.EmissionsDataSet.Process_ReleasePointTab.NewProcess_ReleasePointTabRow
            With row
                .ProcessReleasePointID = Me.m_processReleasePoint.ProcessReleasePointID
                .ProcessID = Me.m_processReleasePoint.ProcessID
                .EmissionYear = Me.m_processReleasePoint.EmissionYear
                .ReleasePointAPCDID = Me.ReleasePointComboBox.Text
                .EmissionsPercent = CShort(Me.EmissionsPercentTextBox.Text.Trim)
            End With
            MainForm.EmissionsDataSet.Process_ReleasePointTab.Rows.Add(row)
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateRowForShow()

        Try
            For Each row As EmissionsDataSet.Process_ReleasePointTabRow In MainForm.EmissionsDataSet.Process_ReleasePointTab
                If (row.ProcessReleasePointID = Me.m_processReleasePoint.ProcessReleasePointID) Then
                    row.EmissionsPercent = Me.m_processReleasePoint.EmissionsPercent
                    Exit For
                End If
            Next
        Catch ex As Exception
            GlobalMethods.HandleError(ex)
            MessageBox.Show(GlobalVariables.ErrorPrompt.Database.SavingRecord, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class