<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReleasePointAddForm
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
        Dim ReleasePointNameLabel As System.Windows.Forms.Label
        Dim ReleasePointDescriptionLabel As System.Windows.Forms.Label
        Dim ReleasePointTypeIDLabel As System.Windows.Forms.Label
        Dim ReleasePointAPCDIDLabel As System.Windows.Forms.Label
        Dim CommentPublicLabel As System.Windows.Forms.Label
        Dim CommentInternalLabel As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim YCoordinateLabel As System.Windows.Forms.Label
        Dim XCoordinateLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReleasePointAddForm))
        Me.ReleasePointNameTextBox = New System.Windows.Forms.TextBox()
        Me.ReleasePointDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ReleasePointAPCDIDTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CommentPublicTextBox = New System.Windows.Forms.TextBox()
        Me.CommentInternalTextBox = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.BeginDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.BeginDateTextBox = New System.Windows.Forms.TextBox()
        Me.ReleasePointTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ReleaseTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ReleasePointDataSet = New APCD.EmissionsInventory.ReleasePointDataSet()
        Me.QryReleasePointAddFormBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.QryReleasePointAddFormTableAdapter = New APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.qryReleasePointAddFormTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.TableAdapterManager()
        Me.QryReleasePointAddFormDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.ShutdownButton = New System.Windows.Forms.Button()
        Me.lblShutdownPrompt = New System.Windows.Forms.Label()
        Me.YCoordinateTextBox = New System.Windows.Forms.TextBox()
        Me.XCoordinateTextBox = New System.Windows.Forms.TextBox()
        ReleasePointNameLabel = New System.Windows.Forms.Label()
        ReleasePointDescriptionLabel = New System.Windows.Forms.Label()
        ReleasePointTypeIDLabel = New System.Windows.Forms.Label()
        ReleasePointAPCDIDLabel = New System.Windows.Forms.Label()
        CommentPublicLabel = New System.Windows.Forms.Label()
        CommentInternalLabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        YCoordinateLabel = New System.Windows.Forms.Label()
        XCoordinateLabel = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QryReleasePointAddFormBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QryReleasePointAddFormDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReleasePointNameLabel
        '
        ReleasePointNameLabel.AutoSize = True
        ReleasePointNameLabel.Location = New System.Drawing.Point(19, 42)
        ReleasePointNameLabel.Name = "ReleasePointNameLabel"
        ReleasePointNameLabel.Size = New System.Drawing.Size(45, 13)
        ReleasePointNameLabel.TabIndex = 3
        ReleasePointNameLabel.Text = "* Name:"
        '
        'ReleasePointDescriptionLabel
        '
        ReleasePointDescriptionLabel.AutoSize = True
        ReleasePointDescriptionLabel.Location = New System.Drawing.Point(19, 68)
        ReleasePointDescriptionLabel.Name = "ReleasePointDescriptionLabel"
        ReleasePointDescriptionLabel.Size = New System.Drawing.Size(70, 13)
        ReleasePointDescriptionLabel.TabIndex = 7
        ReleasePointDescriptionLabel.Text = "* Description:"
        '
        'ReleasePointTypeIDLabel
        '
        ReleasePointTypeIDLabel.AutoSize = True
        ReleasePointTypeIDLabel.Location = New System.Drawing.Point(19, 304)
        ReleasePointTypeIDLabel.Name = "ReleasePointTypeIDLabel"
        ReleasePointTypeIDLabel.Size = New System.Drawing.Size(110, 13)
        ReleasePointTypeIDLabel.TabIndex = 11
        ReleasePointTypeIDLabel.Text = "* Release Point Type:"
        '
        'ReleasePointAPCDIDLabel
        '
        ReleasePointAPCDIDLabel.AutoSize = True
        ReleasePointAPCDIDLabel.Location = New System.Drawing.Point(19, 117)
        ReleasePointAPCDIDLabel.Name = "ReleasePointAPCDIDLabel"
        ReleasePointAPCDIDLabel.Size = New System.Drawing.Size(57, 13)
        ReleasePointAPCDIDLabel.TabIndex = 13
        ReleasePointAPCDIDLabel.Text = "* APCDID:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.AutoSize = True
        CommentPublicLabel.Location = New System.Drawing.Point(19, 169)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(86, 13)
        CommentPublicLabel.TabIndex = 31
        CommentPublicLabel.Text = "Comment Public:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.AutoSize = True
        CommentInternalLabel.Location = New System.Drawing.Point(19, 214)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(92, 13)
        CommentInternalLabel.TabIndex = 32
        CommentInternalLabel.Text = "Comment Internal:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(19, 143)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(70, 13)
        Label2.TabIndex = 38
        Label2.Text = "* Begin Date:"
        '
        'YCoordinateLabel
        '
        YCoordinateLabel.AutoSize = True
        YCoordinateLabel.Location = New System.Drawing.Point(16, 262)
        YCoordinateLabel.Name = "YCoordinateLabel"
        YCoordinateLabel.Size = New System.Drawing.Size(55, 13)
        YCoordinateLabel.TabIndex = 71
        YCoordinateLabel.Text = "* Latitude:"
        '
        'XCoordinateLabel
        '
        XCoordinateLabel.AutoSize = True
        XCoordinateLabel.Location = New System.Drawing.Point(271, 262)
        XCoordinateLabel.Name = "XCoordinateLabel"
        XCoordinateLabel.Size = New System.Drawing.Size(64, 13)
        XCoordinateLabel.TabIndex = 73
        XCoordinateLabel.Text = "* Longitude:"
        '
        'ReleasePointNameTextBox
        '
        Me.ReleasePointNameTextBox.Location = New System.Drawing.Point(115, 39)
        Me.ReleasePointNameTextBox.MaxLength = 50
        Me.ReleasePointNameTextBox.Name = "ReleasePointNameTextBox"
        Me.ReleasePointNameTextBox.Size = New System.Drawing.Size(277, 20)
        Me.ReleasePointNameTextBox.TabIndex = 0
        '
        'ReleasePointDescriptionTextBox
        '
        Me.ReleasePointDescriptionTextBox.Location = New System.Drawing.Point(115, 68)
        Me.ReleasePointDescriptionTextBox.MaxLength = 255
        Me.ReleasePointDescriptionTextBox.Multiline = True
        Me.ReleasePointDescriptionTextBox.Name = "ReleasePointDescriptionTextBox"
        Me.ReleasePointDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ReleasePointDescriptionTextBox.Size = New System.Drawing.Size(397, 40)
        Me.ReleasePointDescriptionTextBox.TabIndex = 1
        '
        'ReleasePointAPCDIDTextBox
        '
        Me.ReleasePointAPCDIDTextBox.Location = New System.Drawing.Point(115, 114)
        Me.ReleasePointAPCDIDTextBox.MaxLength = 20
        Me.ReleasePointAPCDIDTextBox.Name = "ReleasePointAPCDIDTextBox"
        Me.ReleasePointAPCDIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ReleasePointAPCDIDTextBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "* Required field"
        '
        'CommentPublicTextBox
        '
        Me.CommentPublicTextBox.Location = New System.Drawing.Point(115, 166)
        Me.CommentPublicTextBox.MaxLength = 255
        Me.CommentPublicTextBox.Multiline = True
        Me.CommentPublicTextBox.Name = "CommentPublicTextBox"
        Me.CommentPublicTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CommentPublicTextBox.Size = New System.Drawing.Size(397, 40)
        Me.CommentPublicTextBox.TabIndex = 4
        '
        'CommentInternalTextBox
        '
        Me.CommentInternalTextBox.Location = New System.Drawing.Point(115, 211)
        Me.CommentInternalTextBox.MaxLength = 255
        Me.CommentInternalTextBox.Multiline = True
        Me.CommentInternalTextBox.Name = "CommentInternalTextBox"
        Me.CommentInternalTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CommentInternalTextBox.Size = New System.Drawing.Size(397, 40)
        Me.CommentInternalTextBox.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(437, 512)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Enabled = False
        Me.OKButton.Location = New System.Drawing.Point(356, 512)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 12
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'BeginDateDateTimePicker
        '
        Me.BeginDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.BeginDateDateTimePicker.Location = New System.Drawing.Point(192, 140)
        Me.BeginDateDateTimePicker.Name = "BeginDateDateTimePicker"
        Me.BeginDateDateTimePicker.Size = New System.Drawing.Size(17, 20)
        Me.BeginDateDateTimePicker.TabIndex = 4
        Me.BeginDateDateTimePicker.TabStop = False
        '
        'BeginDateTextBox
        '
        Me.BeginDateTextBox.Location = New System.Drawing.Point(115, 140)
        Me.BeginDateTextBox.MaxLength = 10
        Me.BeginDateTextBox.Name = "BeginDateTextBox"
        Me.BeginDateTextBox.Size = New System.Drawing.Size(75, 20)
        Me.BeginDateTextBox.TabIndex = 3
        '
        'ReleasePointTypeComboBox
        '
        Me.ReleasePointTypeComboBox.DisplayMember = "ReleasePointTypeID"
        Me.ReleasePointTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ReleasePointTypeComboBox.FormattingEnabled = True
        Me.ReleasePointTypeComboBox.Location = New System.Drawing.Point(238, 301)
        Me.ReleasePointTypeComboBox.Name = "ReleasePointTypeComboBox"
        Me.ReleasePointTypeComboBox.Size = New System.Drawing.Size(141, 21)
        Me.ReleasePointTypeComboBox.TabIndex = 9
        Me.ReleasePointTypeComboBox.ValueMember = "ReleasePointTypeID"
        '
        'ReleaseTypeComboBox
        '
        Me.ReleaseTypeComboBox.DisplayMember = "ReleaseTypeID"
        Me.ReleaseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ReleaseTypeComboBox.FormattingEnabled = True
        Me.ReleaseTypeComboBox.Location = New System.Drawing.Point(157, 301)
        Me.ReleaseTypeComboBox.Name = "ReleaseTypeComboBox"
        Me.ReleaseTypeComboBox.Size = New System.Drawing.Size(75, 21)
        Me.ReleaseTypeComboBox.TabIndex = 8
        Me.ReleaseTypeComboBox.ValueMember = "ReleaseTypeID"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ReleasePointDataSet
        '
        Me.ReleasePointDataSet.DataSetName = "ReleasePointDataSet"
        Me.ReleasePointDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'QryReleasePointAddFormBindingSource
        '
        Me.QryReleasePointAddFormBindingSource.DataMember = "qryReleasePointAddForm"
        Me.QryReleasePointAddFormBindingSource.DataSource = Me.ReleasePointDataSet
        '
        'QryReleasePointAddFormTableAdapter
        '
        Me.QryReleasePointAddFormTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.ReleasePointDetailTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointDetailTypeTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointTableAdapter = Nothing
        'Me.TableAdapterManager.ReleasePointTypeTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointYearTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeDetailTypeTableAdapter = Nothing
        'Me.TableAdapterManager.ReleaseTypeTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'QryReleasePointAddFormDataGridView
        '
        Me.QryReleasePointAddFormDataGridView.AllowUserToAddRows = False
        Me.QryReleasePointAddFormDataGridView.AllowUserToDeleteRows = False
        Me.QryReleasePointAddFormDataGridView.AutoGenerateColumns = False
        Me.QryReleasePointAddFormDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.QryReleasePointAddFormDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.QryReleasePointAddFormDataGridView.DataSource = Me.QryReleasePointAddFormBindingSource
        Me.QryReleasePointAddFormDataGridView.Location = New System.Drawing.Point(22, 328)
        Me.QryReleasePointAddFormDataGridView.Name = "QryReleasePointAddFormDataGridView"
        Me.QryReleasePointAddFormDataGridView.ReadOnly = True
        Me.QryReleasePointAddFormDataGridView.Size = New System.Drawing.Size(428, 163)
        Me.QryReleasePointAddFormDataGridView.TabIndex = 10
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ReleasePointDetailTypeID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ReleasePointDetailTypeID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ReleasePointDetailTypeName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Measurement"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DetailValue"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "UnitOfMeasurementID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "UnitOfMeasurementID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "UnitOfMeasurementName"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Unit of Measurement"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.Location = New System.Drawing.Point(22, 512)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(90, 23)
        Me.btnApprove.TabIndex = 14
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        Me.btnApprove.Visible = False
        '
        'ShutdownButton
        '
        Me.ShutdownButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShutdownButton.Location = New System.Drawing.Point(227, 512)
        Me.ShutdownButton.Name = "ShutdownButton"
        Me.ShutdownButton.Size = New System.Drawing.Size(123, 23)
        Me.ShutdownButton.TabIndex = 13
        Me.ShutdownButton.Text = "Shutdown"
        Me.ShutdownButton.UseVisualStyleBackColor = True
        '
        'lblShutdownPrompt
        '
        Me.lblShutdownPrompt.ForeColor = System.Drawing.Color.Red
        Me.lblShutdownPrompt.Location = New System.Drawing.Point(154, 9)
        Me.lblShutdownPrompt.Name = "lblShutdownPrompt"
        Me.lblShutdownPrompt.Size = New System.Drawing.Size(345, 19)
        Me.lblShutdownPrompt.TabIndex = 70
        Me.lblShutdownPrompt.Text = "lblShutdownPrompt"
        Me.lblShutdownPrompt.Visible = False
        '
        'YCoordinateTextBox
        '
        Me.YCoordinateTextBox.Location = New System.Drawing.Point(115, 259)
        Me.YCoordinateTextBox.MaxLength = 20
        Me.YCoordinateTextBox.Name = "YCoordinateTextBox"
        Me.YCoordinateTextBox.Size = New System.Drawing.Size(132, 20)
        Me.YCoordinateTextBox.TabIndex = 6
        Me.YCoordinateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'XCoordinateTextBox
        '
        Me.XCoordinateTextBox.Location = New System.Drawing.Point(341, 259)
        Me.XCoordinateTextBox.MaxLength = 20
        Me.XCoordinateTextBox.Name = "XCoordinateTextBox"
        Me.XCoordinateTextBox.Size = New System.Drawing.Size(132, 20)
        Me.XCoordinateTextBox.TabIndex = 7
        Me.XCoordinateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ReleasePointAddForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(524, 547)
        Me.Controls.Add(Me.lblShutdownPrompt)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.YCoordinateTextBox)
        Me.Controls.Add(Me.ShutdownButton)
        Me.Controls.Add(YCoordinateLabel)
        Me.Controls.Add(Me.QryReleasePointAddFormDataGridView)
        Me.Controls.Add(Me.ReleaseTypeComboBox)
        Me.Controls.Add(Me.XCoordinateTextBox)
        Me.Controls.Add(XCoordinateLabel)
        Me.Controls.Add(Me.ReleasePointTypeComboBox)
        Me.Controls.Add(Me.BeginDateDateTimePicker)
        Me.Controls.Add(Me.BeginDateTextBox)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(CommentPublicLabel)
        Me.Controls.Add(Me.CommentPublicTextBox)
        Me.Controls.Add(CommentInternalLabel)
        Me.Controls.Add(Me.CommentInternalTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(ReleasePointNameLabel)
        Me.Controls.Add(Me.ReleasePointNameTextBox)
        Me.Controls.Add(ReleasePointDescriptionLabel)
        Me.Controls.Add(Me.ReleasePointDescriptionTextBox)
        Me.Controls.Add(ReleasePointTypeIDLabel)
        Me.Controls.Add(ReleasePointAPCDIDLabel)
        Me.Controls.Add(Me.ReleasePointAPCDIDTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReleasePointAddForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Release Point "
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QryReleasePointAddFormBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QryReleasePointAddFormDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReleasePointNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReleasePointDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReleasePointAPCDIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CommentPublicTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents BeginDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BeginDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReleasePointTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ReleaseTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents QryReleasePointAddFormBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointDataSet As APCD.EmissionsInventory.ReleasePointDataSet
    Friend WithEvents QryReleasePointAddFormTableAdapter As APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.qryReleasePointAddFormTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.TableAdapterManager
    Friend WithEvents QryReleasePointAddFormDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents ShutdownButton As System.Windows.Forms.Button
    Friend WithEvents lblShutdownPrompt As System.Windows.Forms.Label
    Friend WithEvents YCoordinateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents XCoordinateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
