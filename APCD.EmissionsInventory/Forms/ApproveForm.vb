Imports APCD.Emissions

Public Class ApproveForm

    Private m_processYear As EmissionsDataSet.ProcessYearRow
    Public Sub New(ByVal processYear As EmissionsDataSet.ProcessYearRow, ByVal prompt As String)
        InitializeComponent()
        Me.m_processYear = processYear
        Me.m_prompt = prompt
    End Sub

    Private m_emissionUnitYear As EmissionsDataSet.PlantEmissionUnitYearRow
    Public Sub New(ByVal emissionUnitYear As EmissionsDataSet.PlantEmissionUnitYearRow, ByVal prompt As String)
        InitializeComponent()
        Me.m_emissionUnitYear = emissionUnitYear
        Me.m_prompt = prompt
    End Sub

    Private m_controlMeasureYear As EmissionsDataSet.ControlMeasureYearRow
    Public Sub New(ByVal controlMeasureYear As EmissionsDataSet.ControlMeasureYearRow, ByVal prompt As String)
        InitializeComponent()
        Me.m_controlMeasureYear = controlMeasureYear
        Me.m_prompt = prompt
    End Sub

    Private m_releasePointYear As EmissionsDataSet.ReleasePointYearRow
    Public Sub New(ByVal releasePointYear As EmissionsDataSet.ReleasePointYearRow, ByVal prompt As String)
        InitializeComponent()
        Me.m_releasePointYear = releasePointYear
        Me.m_prompt = prompt
    End Sub

    Private m_prompt As String
    Private formIsLoaded As Boolean = False

    Private Sub ApproveForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If (Me.m_processYear IsNot Nothing) Then
            Me.m_processYear.ApprovalComment = Nothing

        ElseIf (Me.m_emissionUnitYear IsNot Nothing) Then
            Me.m_emissionUnitYear.ApprovalComment = Nothing

        ElseIf (Me.m_controlMeasureYear IsNot Nothing) Then
            Me.m_controlMeasureYear.ApprovalComment = Nothing

        ElseIf (Me.m_releasePointYear IsNot Nothing) Then
            Me.m_releasePointYear.ApprovalComment = Nothing
        End If

        Me.Text = Me.m_prompt
        Me.formIsLoaded = True

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub CommentTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommentTextBox.TextChanged

        If (Me.formIsLoaded = True) Then
            If (Me.m_processYear IsNot Nothing) Then
                If (Me.CommentTextBox.Text.Trim = String.Empty) Then
                    Me.m_processYear.SetApprovalCommentNull()
                Else
                    Me.m_processYear.ApprovalComment = Me.CommentTextBox.Text.Trim
                End If

            ElseIf (Me.m_emissionUnitYear IsNot Nothing) Then
                If (Me.CommentTextBox.Text.Trim = String.Empty) Then
                    Me.m_emissionUnitYear.SetApprovalCommentNull()
                Else
                    Me.m_emissionUnitYear.ApprovalComment = Me.CommentTextBox.Text.Trim
                End If

            ElseIf (Me.m_controlMeasureYear IsNot Nothing) Then
                If (Me.CommentTextBox.Text.Trim = String.Empty) Then
                    Me.m_controlMeasureYear.SetApprovalCommentNull()
                Else
                    Me.m_controlMeasureYear.ApprovalComment = Me.CommentTextBox.Text.Trim
                End If

            ElseIf (Me.m_releasePointYear IsNot Nothing) Then
                If (Me.CommentTextBox.Text.Trim = String.Empty) Then
                    Me.m_releasePointYear.SetApprovalCommentNull()
                Else
                    Me.m_releasePointYear.ApprovalComment = Me.CommentTextBox.Text.Trim
                End If
            End If
        End If

    End Sub

End Class