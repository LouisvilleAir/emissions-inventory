<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlMeasurePollutantAddEditForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim PollutantLabel As System.Windows.Forms.Label
        Dim ControlPercentLabel As System.Windows.Forms.Label
        Dim CommentPublicLabel As System.Windows.Forms.Label
        Dim CommentInternalLabel As System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CommentPublicTextBox = New System.Windows.Forms.TextBox()
        Me.PollutantComboBox = New System.Windows.Forms.ComboBox()
        Me.CommentInternalTextBox = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ControlPercentTextBox = New System.Windows.Forms.TextBox()
        PollutantLabel = New System.Windows.Forms.Label()
        ControlPercentLabel = New System.Windows.Forms.Label()
        CommentPublicLabel = New System.Windows.Forms.Label()
        CommentInternalLabel = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PollutantLabel
        '
        PollutantLabel.AutoSize = True
        PollutantLabel.Location = New System.Drawing.Point(9, 53)
        PollutantLabel.Name = "PollutantLabel"
        PollutantLabel.Size = New System.Drawing.Size(58, 13)
        PollutantLabel.TabIndex = 41
        PollutantLabel.Text = "* Pollutant:"
        '
        'ControlPercentLabel
        '
        ControlPercentLabel.AutoSize = True
        ControlPercentLabel.Location = New System.Drawing.Point(9, 79)
        ControlPercentLabel.Name = "ControlPercentLabel"
        ControlPercentLabel.Size = New System.Drawing.Size(90, 13)
        ControlPercentLabel.TabIndex = 43
        ControlPercentLabel.Text = "* Control Percent:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.AutoSize = True
        CommentPublicLabel.Location = New System.Drawing.Point(17, 105)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(86, 13)
        CommentPublicLabel.TabIndex = 44
        CommentPublicLabel.Text = "Comment Public:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.AutoSize = True
        CommentInternalLabel.Location = New System.Drawing.Point(17, 190)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(92, 13)
        CommentInternalLabel.TabIndex = 45
        CommentInternalLabel.Text = "Comment Internal:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(367, 292)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 42
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(286, 292)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 40
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "* Required field"
        '
        'CommentPublicTextBox
        '
        Me.CommentPublicTextBox.Location = New System.Drawing.Point(115, 105)
        Me.CommentPublicTextBox.MaxLength = 255
        Me.CommentPublicTextBox.Multiline = True
        Me.CommentPublicTextBox.Name = "CommentPublicTextBox"
        Me.CommentPublicTextBox.Size = New System.Drawing.Size(325, 68)
        Me.CommentPublicTextBox.TabIndex = 38
        '
        'PollutantComboBox
        '
        Me.PollutantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PollutantComboBox.FormattingEnabled = True
        Me.PollutantComboBox.Location = New System.Drawing.Point(115, 49)
        Me.PollutantComboBox.Name = "PollutantComboBox"
        Me.PollutantComboBox.Size = New System.Drawing.Size(325, 21)
        Me.PollutantComboBox.TabIndex = 36
        '
        'CommentInternalTextBox
        '
        Me.CommentInternalTextBox.Location = New System.Drawing.Point(115, 190)
        Me.CommentInternalTextBox.MaxLength = 255
        Me.CommentInternalTextBox.Multiline = True
        Me.CommentInternalTextBox.Name = "CommentInternalTextBox"
        Me.CommentInternalTextBox.Size = New System.Drawing.Size(325, 68)
        Me.CommentInternalTextBox.TabIndex = 39
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ControlPercentTextBox
        '
        Me.ControlPercentTextBox.Location = New System.Drawing.Point(115, 76)
        Me.ControlPercentTextBox.MaxLength = 5
        Me.ControlPercentTextBox.Name = "ControlPercentTextBox"
        Me.ControlPercentTextBox.Size = New System.Drawing.Size(40, 20)
        Me.ControlPercentTextBox.TabIndex = 37
        '
        'ControlMeasurePollutantAddEditForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(454, 327)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CommentPublicTextBox)
        Me.Controls.Add(Me.PollutantComboBox)
        Me.Controls.Add(Me.CommentInternalTextBox)
        Me.Controls.Add(PollutantLabel)
        Me.Controls.Add(ControlPercentLabel)
        Me.Controls.Add(Me.ControlPercentTextBox)
        Me.Controls.Add(CommentPublicLabel)
        Me.Controls.Add(CommentInternalLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ControlMeasurePollutantAddEditForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ControlMeasurePollutantAddEditForm"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CommentPublicTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PollutantComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CommentInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ControlPercentTextBox As System.Windows.Forms.TextBox
End Class
