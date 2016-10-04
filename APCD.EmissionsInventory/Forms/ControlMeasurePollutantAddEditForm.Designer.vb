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
        PollutantLabel.Location = New System.Drawing.Point(12, 65)
        PollutantLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        PollutantLabel.Name = "PollutantLabel"
        PollutantLabel.Size = New System.Drawing.Size(76, 17)
        PollutantLabel.TabIndex = 41
        PollutantLabel.Text = "* Pollutant:"
        '
        'ControlPercentLabel
        '
        ControlPercentLabel.AutoSize = True
        ControlPercentLabel.Location = New System.Drawing.Point(12, 97)
        ControlPercentLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ControlPercentLabel.Name = "ControlPercentLabel"
        ControlPercentLabel.Size = New System.Drawing.Size(119, 17)
        ControlPercentLabel.TabIndex = 43
        ControlPercentLabel.Text = "* Control Percent:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.AutoSize = True
        CommentPublicLabel.Location = New System.Drawing.Point(23, 129)
        CommentPublicLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(113, 17)
        CommentPublicLabel.TabIndex = 44
        CommentPublicLabel.Text = "Comment Public:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.AutoSize = True
        CommentInternalLabel.Location = New System.Drawing.Point(23, 234)
        CommentInternalLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(122, 17)
        CommentInternalLabel.TabIndex = 45
        CommentInternalLabel.Text = "Comment Internal:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(485, 343)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 42
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(377, 343)
        Me.OKButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(100, 28)
        Me.OKButton.TabIndex = 40
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 17)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "* Required field"
        '
        'CommentPublicTextBox
        '
        Me.CommentPublicTextBox.Location = New System.Drawing.Point(153, 129)
        Me.CommentPublicTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CommentPublicTextBox.MaxLength = 255
        Me.CommentPublicTextBox.Multiline = True
        Me.CommentPublicTextBox.Name = "CommentPublicTextBox"
        Me.CommentPublicTextBox.Size = New System.Drawing.Size(432, 83)
        Me.CommentPublicTextBox.TabIndex = 38
        '
        'PollutantComboBox
        '
        Me.PollutantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PollutantComboBox.FormattingEnabled = True
        Me.PollutantComboBox.Location = New System.Drawing.Point(153, 60)
        Me.PollutantComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PollutantComboBox.Name = "PollutantComboBox"
        Me.PollutantComboBox.Size = New System.Drawing.Size(432, 24)
        Me.PollutantComboBox.TabIndex = 36
        '
        'CommentInternalTextBox
        '
        Me.CommentInternalTextBox.Location = New System.Drawing.Point(153, 234)
        Me.CommentInternalTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CommentInternalTextBox.MaxLength = 255
        Me.CommentInternalTextBox.Multiline = True
        Me.CommentInternalTextBox.Name = "CommentInternalTextBox"
        Me.CommentInternalTextBox.Size = New System.Drawing.Size(432, 83)
        Me.CommentInternalTextBox.TabIndex = 39
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ControlPercentTextBox
        '
        Me.ControlPercentTextBox.Location = New System.Drawing.Point(153, 94)
        Me.ControlPercentTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ControlPercentTextBox.MaxLength = 5
        Me.ControlPercentTextBox.Name = "ControlPercentTextBox"
        Me.ControlPercentTextBox.Size = New System.Drawing.Size(52, 22)
        Me.ControlPercentTextBox.TabIndex = 37
        '
        'ControlMeasurePollutantAddEditForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(619, 412)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ControlMeasurePollutantAddEditForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add or Edit Pollutant on Control Measure"
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
