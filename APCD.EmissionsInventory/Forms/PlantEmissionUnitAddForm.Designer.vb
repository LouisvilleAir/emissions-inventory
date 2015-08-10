<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlantEmissionUnitAddForm
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
        Dim PlantEmissionUnitNameLabel As System.Windows.Forms.Label
        Dim EmissionUnitTypeIDLabel As System.Windows.Forms.Label
        Dim EmissionUnitAPCDIDLabel As System.Windows.Forms.Label
        Dim EmissionUnitDescriptionLabel As System.Windows.Forms.Label
        Dim CommentPublicLabel As System.Windows.Forms.Label
        Dim CommentInternalLabel As System.Windows.Forms.Label
        Dim BeginDateLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlantEmissionUnitAddForm))
        Me.PlantEmissionUnitNameTextBox = New System.Windows.Forms.TextBox()
        Me.EmissionUnitAPCDIDTextBox = New System.Windows.Forms.TextBox()
        Me.EmissionUnitDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.CommentPublicTextBox = New System.Windows.Forms.TextBox()
        Me.CommentInternalTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BeginDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.BeginDateTextBox = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OKButton = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.EmissionUnitTypeComboBox = New System.Windows.Forms.ComboBox()
        PlantEmissionUnitNameLabel = New System.Windows.Forms.Label()
        EmissionUnitTypeIDLabel = New System.Windows.Forms.Label()
        EmissionUnitAPCDIDLabel = New System.Windows.Forms.Label()
        EmissionUnitDescriptionLabel = New System.Windows.Forms.Label()
        CommentPublicLabel = New System.Windows.Forms.Label()
        CommentInternalLabel = New System.Windows.Forms.Label()
        BeginDateLabel = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlantEmissionUnitNameLabel
        '
        PlantEmissionUnitNameLabel.AutoSize = True
        PlantEmissionUnitNameLabel.Location = New System.Drawing.Point(12, 48)
        PlantEmissionUnitNameLabel.Name = "PlantEmissionUnitNameLabel"
        PlantEmissionUnitNameLabel.Size = New System.Drawing.Size(45, 13)
        PlantEmissionUnitNameLabel.TabIndex = 3
        PlantEmissionUnitNameLabel.Text = "* Name:"
        '
        'EmissionUnitTypeIDLabel
        '
        EmissionUnitTypeIDLabel.AutoSize = True
        EmissionUnitTypeIDLabel.Location = New System.Drawing.Point(12, 74)
        EmissionUnitTypeIDLabel.Name = "EmissionUnitTypeIDLabel"
        EmissionUnitTypeIDLabel.Size = New System.Drawing.Size(55, 13)
        EmissionUnitTypeIDLabel.TabIndex = 7
        EmissionUnitTypeIDLabel.Text = "* Type ID:"
        '
        'EmissionUnitAPCDIDLabel
        '
        EmissionUnitAPCDIDLabel.AutoSize = True
        EmissionUnitAPCDIDLabel.Location = New System.Drawing.Point(12, 101)
        EmissionUnitAPCDIDLabel.Name = "EmissionUnitAPCDIDLabel"
        EmissionUnitAPCDIDLabel.Size = New System.Drawing.Size(57, 13)
        EmissionUnitAPCDIDLabel.TabIndex = 9
        EmissionUnitAPCDIDLabel.Text = "* APCDID:"
        '
        'EmissionUnitDescriptionLabel
        '
        EmissionUnitDescriptionLabel.AutoSize = True
        EmissionUnitDescriptionLabel.Location = New System.Drawing.Point(14, 127)
        EmissionUnitDescriptionLabel.Name = "EmissionUnitDescriptionLabel"
        EmissionUnitDescriptionLabel.Size = New System.Drawing.Size(70, 13)
        EmissionUnitDescriptionLabel.TabIndex = 13
        EmissionUnitDescriptionLabel.Text = "* Description:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.AutoSize = True
        CommentPublicLabel.Location = New System.Drawing.Point(19, 201)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(86, 13)
        CommentPublicLabel.TabIndex = 15
        CommentPublicLabel.Text = "Comment Public:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.AutoSize = True
        CommentInternalLabel.Location = New System.Drawing.Point(19, 275)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(92, 13)
        CommentInternalLabel.TabIndex = 17
        CommentInternalLabel.Text = "Comment Internal:"
        '
        'BeginDateLabel
        '
        BeginDateLabel.AutoSize = True
        BeginDateLabel.Location = New System.Drawing.Point(19, 353)
        BeginDateLabel.Name = "BeginDateLabel"
        BeginDateLabel.Size = New System.Drawing.Size(70, 13)
        BeginDateLabel.TabIndex = 19
        BeginDateLabel.Text = "* Begin Date:"
        '
        'PlantEmissionUnitNameTextBox
        '
        Me.PlantEmissionUnitNameTextBox.Location = New System.Drawing.Point(115, 45)
        Me.PlantEmissionUnitNameTextBox.MaxLength = 100
        Me.PlantEmissionUnitNameTextBox.Name = "PlantEmissionUnitNameTextBox"
        Me.PlantEmissionUnitNameTextBox.Size = New System.Drawing.Size(325, 20)
        Me.PlantEmissionUnitNameTextBox.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.PlantEmissionUnitNameTextBox, "Enter the EU name that is in the permit")
        '
        'EmissionUnitAPCDIDTextBox
        '
        Me.EmissionUnitAPCDIDTextBox.Location = New System.Drawing.Point(115, 98)
        Me.EmissionUnitAPCDIDTextBox.MaxLength = 20
        Me.EmissionUnitAPCDIDTextBox.Name = "EmissionUnitAPCDIDTextBox"
        Me.EmissionUnitAPCDIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.EmissionUnitAPCDIDTextBox.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.EmissionUnitAPCDIDTextBox, "Enter the actual ID that is in the permit")
        '
        'EmissionUnitDescriptionTextBox
        '
        Me.EmissionUnitDescriptionTextBox.Location = New System.Drawing.Point(115, 124)
        Me.EmissionUnitDescriptionTextBox.MaxLength = 255
        Me.EmissionUnitDescriptionTextBox.Multiline = True
        Me.EmissionUnitDescriptionTextBox.Name = "EmissionUnitDescriptionTextBox"
        Me.EmissionUnitDescriptionTextBox.Size = New System.Drawing.Size(325, 68)
        Me.EmissionUnitDescriptionTextBox.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.EmissionUnitDescriptionTextBox, "A description of the emissions unit")
        '
        'CommentPublicTextBox
        '
        Me.CommentPublicTextBox.Location = New System.Drawing.Point(115, 198)
        Me.CommentPublicTextBox.MaxLength = 255
        Me.CommentPublicTextBox.Multiline = True
        Me.CommentPublicTextBox.Name = "CommentPublicTextBox"
        Me.CommentPublicTextBox.Size = New System.Drawing.Size(325, 68)
        Me.CommentPublicTextBox.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.CommentPublicTextBox, "Any comments that can be submitted to the US EPA or the public")
        '
        'CommentInternalTextBox
        '
        Me.CommentInternalTextBox.Location = New System.Drawing.Point(115, 272)
        Me.CommentInternalTextBox.MaxLength = 255
        Me.CommentInternalTextBox.Multiline = True
        Me.CommentInternalTextBox.Name = "CommentInternalTextBox"
        Me.CommentInternalTextBox.Size = New System.Drawing.Size(325, 68)
        Me.CommentInternalTextBox.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CommentInternalTextBox, "Any comments for internal use only")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "* Required field"
        '
        'BeginDateDateTimePicker
        '
        Me.BeginDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.BeginDateDateTimePicker.Location = New System.Drawing.Point(190, 350)
        Me.BeginDateDateTimePicker.Name = "BeginDateDateTimePicker"
        Me.BeginDateDateTimePicker.Size = New System.Drawing.Size(17, 20)
        Me.BeginDateDateTimePicker.TabIndex = 6
        '
        'BeginDateTextBox
        '
        Me.BeginDateTextBox.Location = New System.Drawing.Point(115, 350)
        Me.BeginDateTextBox.MaxLength = 10
        Me.BeginDateTextBox.Name = "BeginDateTextBox"
        Me.BeginDateTextBox.Size = New System.Drawing.Size(75, 20)
        Me.BeginDateTextBox.TabIndex = 10
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(286, 412)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 8
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(367, 412)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'EmissionUnitTypeComboBox
        '
        Me.EmissionUnitTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.EmissionUnitTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.EmissionUnitTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmissionUnitTypeComboBox.FormattingEnabled = True
        Me.EmissionUnitTypeComboBox.Location = New System.Drawing.Point(115, 71)
        Me.EmissionUnitTypeComboBox.Name = "EmissionUnitTypeComboBox"
        Me.EmissionUnitTypeComboBox.Size = New System.Drawing.Size(200, 21)
        Me.EmissionUnitTypeComboBox.TabIndex = 1
        '
        'PlantEmissionUnitAddForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(454, 447)
        Me.Controls.Add(Me.EmissionUnitTypeComboBox)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.BeginDateDateTimePicker)
        Me.Controls.Add(Me.BeginDateTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(PlantEmissionUnitNameLabel)
        Me.Controls.Add(Me.PlantEmissionUnitNameTextBox)
        Me.Controls.Add(EmissionUnitTypeIDLabel)
        Me.Controls.Add(EmissionUnitAPCDIDLabel)
        Me.Controls.Add(Me.EmissionUnitAPCDIDTextBox)
        Me.Controls.Add(EmissionUnitDescriptionLabel)
        Me.Controls.Add(Me.EmissionUnitDescriptionTextBox)
        Me.Controls.Add(CommentPublicLabel)
        Me.Controls.Add(Me.CommentPublicTextBox)
        Me.Controls.Add(CommentInternalLabel)
        Me.Controls.Add(Me.CommentInternalTextBox)
        Me.Controls.Add(BeginDateLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PlantEmissionUnitAddForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Emission Unit"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PlantEmissionUnitNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmissionUnitAPCDIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmissionUnitDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentPublicTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BeginDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BeginDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents EmissionUnitTypeComboBox As System.Windows.Forms.ComboBox
End Class
