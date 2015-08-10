<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmissionUnitUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Me.EmissionUnitTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.EmissionUnitAPCDIDTextBox = New System.Windows.Forms.TextBox()
        Me.CompanyDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.CompanyCommentTextBox = New System.Windows.Forms.TextBox()
        Me.APCDCommentTextBox = New System.Windows.Forms.TextBox()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.btnShutdown = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.IsExcludedCheckBox = New System.Windows.Forms.CheckBox()
        Me.ButtonPanel = New System.Windows.Forms.Panel()
        Me.ShutdownMessageLabel = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ButtonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(3, 71)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(41, 13)
        Label4.TabIndex = 75
        Label4.Text = "* Type:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(3, 42)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(60, 13)
        Label5.TabIndex = 76
        Label5.Text = "* APCD ID:"
        '
        'Label6
        '
        Label6.Location = New System.Drawing.Point(3, 100)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(63, 35)
        Label6.TabIndex = 77
        Label6.Text = "Company Description:"
        '
        'Label7
        '
        Label7.Location = New System.Drawing.Point(3, 156)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(86, 50)
        Label7.TabIndex = 78
        Label7.Text = "Company Comment:"
        '
        'Label8
        '
        Label8.Location = New System.Drawing.Point(3, 212)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(75, 35)
        Label8.TabIndex = 79
        Label8.Text = "APCD Comment:"
        '
        'EmissionUnitTypeComboBox
        '
        Me.EmissionUnitTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmissionUnitTypeComboBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmissionUnitTypeComboBox.FormattingEnabled = True
        Me.EmissionUnitTypeComboBox.Location = New System.Drawing.Point(95, 70)
        Me.EmissionUnitTypeComboBox.Name = "EmissionUnitTypeComboBox"
        Me.EmissionUnitTypeComboBox.Size = New System.Drawing.Size(200, 22)
        Me.EmissionUnitTypeComboBox.TabIndex = 0
        '
        'EmissionUnitAPCDIDTextBox
        '
        Me.EmissionUnitAPCDIDTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmissionUnitAPCDIDTextBox.Location = New System.Drawing.Point(95, 42)
        Me.EmissionUnitAPCDIDTextBox.MaxLength = 50
        Me.EmissionUnitAPCDIDTextBox.Name = "EmissionUnitAPCDIDTextBox"
        Me.EmissionUnitAPCDIDTextBox.Size = New System.Drawing.Size(325, 22)
        Me.EmissionUnitAPCDIDTextBox.TabIndex = 1
        '
        'CompanyDescriptionTextBox
        '
        Me.CompanyDescriptionTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyDescriptionTextBox.Location = New System.Drawing.Point(95, 100)
        Me.CompanyDescriptionTextBox.MaxLength = 100
        Me.CompanyDescriptionTextBox.Multiline = True
        Me.CompanyDescriptionTextBox.Name = "CompanyDescriptionTextBox"
        Me.CompanyDescriptionTextBox.Size = New System.Drawing.Size(595, 35)
        Me.CompanyDescriptionTextBox.TabIndex = 2
        '
        'CompanyCommentTextBox
        '
        Me.CompanyCommentTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyCommentTextBox.Location = New System.Drawing.Point(95, 156)
        Me.CompanyCommentTextBox.MaxLength = 255
        Me.CompanyCommentTextBox.Multiline = True
        Me.CompanyCommentTextBox.Name = "CompanyCommentTextBox"
        Me.CompanyCommentTextBox.Size = New System.Drawing.Size(595, 50)
        Me.CompanyCommentTextBox.TabIndex = 3
        '
        'APCDCommentTextBox
        '
        Me.APCDCommentTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.APCDCommentTextBox.Location = New System.Drawing.Point(95, 212)
        Me.APCDCommentTextBox.MaxLength = 255
        Me.APCDCommentTextBox.Multiline = True
        Me.APCDCommentTextBox.Name = "APCDCommentTextBox"
        Me.APCDCommentTextBox.Size = New System.Drawing.Size(595, 50)
        Me.APCDCommentTextBox.TabIndex = 4
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(3, 3)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(125, 23)
        Me.btnApprove.TabIndex = 8
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'btnShutdown
        '
        Me.btnShutdown.Location = New System.Drawing.Point(400, 3)
        Me.btnShutdown.Name = "btnShutdown"
        Me.btnShutdown.Size = New System.Drawing.Size(125, 23)
        Me.btnShutdown.TabIndex = 7
        Me.btnShutdown.Text = "Shut down"
        Me.btnShutdown.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(531, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "* Required field"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(612, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'IsExcludedCheckBox
        '
        Me.IsExcludedCheckBox.Location = New System.Drawing.Point(547, 7)
        Me.IsExcludedCheckBox.Name = "IsExcludedCheckBox"
        Me.IsExcludedCheckBox.Size = New System.Drawing.Size(143, 18)
        Me.IsExcludedCheckBox.TabIndex = 9
        Me.IsExcludedCheckBox.Text = "Exclude from inventory"
        Me.IsExcludedCheckBox.UseVisualStyleBackColor = True
        '
        'ButtonPanel
        '
        Me.ButtonPanel.Controls.Add(Me.btnSave)
        Me.ButtonPanel.Controls.Add(Me.btnShutdown)
        Me.ButtonPanel.Controls.Add(Me.btnCancel)
        Me.ButtonPanel.Controls.Add(Me.btnApprove)
        Me.ButtonPanel.Location = New System.Drawing.Point(5, 325)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(690, 32)
        Me.ButtonPanel.TabIndex = 84
        '
        'ShutdownMessageLabel
        '
        Me.ShutdownMessageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShutdownMessageLabel.ForeColor = System.Drawing.Color.Red
        Me.ShutdownMessageLabel.Location = New System.Drawing.Point(92, 4)
        Me.ShutdownMessageLabel.Name = "ShutdownMessageLabel"
        Me.ShutdownMessageLabel.Size = New System.Drawing.Size(400, 19)
        Me.ShutdownMessageLabel.TabIndex = 89
        Me.ShutdownMessageLabel.Text = "ShutdownMessageLabel"
        '
        'EmissionUnitUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ShutdownMessageLabel)
        Me.Controls.Add(Me.ButtonPanel)
        Me.Controls.Add(Me.IsExcludedCheckBox)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Label7)
        Me.Controls.Add(Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.EmissionUnitTypeComboBox)
        Me.Controls.Add(Me.EmissionUnitAPCDIDTextBox)
        Me.Controls.Add(Me.CompanyDescriptionTextBox)
        Me.Controls.Add(Me.CompanyCommentTextBox)
        Me.Controls.Add(Me.APCDCommentTextBox)
        Me.Name = "EmissionUnitUserControl"
        Me.Size = New System.Drawing.Size(700, 700)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ButtonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EmissionUnitTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents EmissionUnitAPCDIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompanyDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompanyCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents APCDCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents btnShutdown As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents IsExcludedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonPanel As System.Windows.Forms.Panel
    Friend WithEvents ShutdownMessageLabel As System.Windows.Forms.Label

End Class
