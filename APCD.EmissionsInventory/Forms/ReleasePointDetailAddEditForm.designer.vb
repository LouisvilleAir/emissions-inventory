<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReleasePointDetailAddEditForm
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
        Dim DetailValueLabel As System.Windows.Forms.Label
        Dim UnitOfMeasurementIDLabel As System.Windows.Forms.Label
        Me.DetailValueTextBox = New System.Windows.Forms.TextBox()
        Me.UnitOfMeasurementComboBox = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        DetailValueLabel = New System.Windows.Forms.Label()
        UnitOfMeasurementIDLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'DetailValueLabel
        '
        DetailValueLabel.AutoSize = True
        DetailValueLabel.Location = New System.Drawing.Point(11, 13)
        DetailValueLabel.Name = "DetailValueLabel"
        DetailValueLabel.Size = New System.Drawing.Size(37, 13)
        DetailValueLabel.TabIndex = 5
        DetailValueLabel.Text = "Value:"
        '
        'UnitOfMeasurementIDLabel
        '
        UnitOfMeasurementIDLabel.AutoSize = True
        UnitOfMeasurementIDLabel.Location = New System.Drawing.Point(12, 43)
        UnitOfMeasurementIDLabel.Name = "UnitOfMeasurementIDLabel"
        UnitOfMeasurementIDLabel.Size = New System.Drawing.Size(111, 13)
        UnitOfMeasurementIDLabel.TabIndex = 7
        UnitOfMeasurementIDLabel.Text = "Unit of Measurement :"
        '
        'DetailValueTextBox
        '
        Me.DetailValueTextBox.Location = New System.Drawing.Point(129, 10)
        Me.DetailValueTextBox.Name = "DetailValueTextBox"
        Me.DetailValueTextBox.Size = New System.Drawing.Size(100, 20)
        Me.DetailValueTextBox.TabIndex = 6
        '
        'UnitOfMeasurementComboBox
        '
        Me.UnitOfMeasurementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UnitOfMeasurementComboBox.Enabled = False
        Me.UnitOfMeasurementComboBox.FormattingEnabled = True
        Me.UnitOfMeasurementComboBox.Location = New System.Drawing.Point(129, 40)
        Me.UnitOfMeasurementComboBox.Name = "UnitOfMeasurementComboBox"
        Me.UnitOfMeasurementComboBox.Size = New System.Drawing.Size(225, 21)
        Me.UnitOfMeasurementComboBox.TabIndex = 9
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(279, 102)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 36
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(198, 102)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 35
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'ReleasePointDetailAddEditForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(364, 137)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.UnitOfMeasurementComboBox)
        Me.Controls.Add(DetailValueLabel)
        Me.Controls.Add(Me.DetailValueTextBox)
        Me.Controls.Add(UnitOfMeasurementIDLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ReleasePointDetailAddEditForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Release Point Measurement"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DetailValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UnitOfMeasurementComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
End Class
