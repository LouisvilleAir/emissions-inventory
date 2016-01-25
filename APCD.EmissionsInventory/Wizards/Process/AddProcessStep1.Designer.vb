<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddProcessStep1
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
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim ControlApproachDescriptionLabel As System.Windows.Forms.Label
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSCCNumber = New System.Windows.Forms.Label()
        Me.lblSCCName = New System.Windows.Forms.Label()
        Me.btnChangeProcessClass = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.ProcessBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ProcessYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessYearTableAdapter()
        Me.ProcessDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ProcessAPCDIDTextBox = New System.Windows.Forms.TextBox()
        Me.CommentPublicTextBox = New System.Windows.Forms.TextBox()
        Me.CommentInternalTextBox = New System.Windows.Forms.TextBox()
        Me.ThroughputTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ProcessYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ControlApproachDescriptionTextBox = New System.Windows.Forms.TextBox()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        ControlApproachDescriptionLabel = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(16, 159)
        Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(131, 17)
        Label2.TabIndex = 79
        Label2.Text = "* Throughput Type:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(9, 241)
        Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(83, 17)
        Label3.TabIndex = 80
        Label3.Text = "Description:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(12, 210)
        Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(71, 17)
        Label4.TabIndex = 81
        Label4.Text = "*APCD ID:"
        '
        'Label6
        '
        Label6.Location = New System.Drawing.Point(15, 310)
        Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(93, 38)
        Label6.TabIndex = 83
        Label6.Text = "Public Comment:"
        '
        'Label7
        '
        Label7.Location = New System.Drawing.Point(12, 379)
        Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(93, 38)
        Label7.TabIndex = 84
        Label7.Text = "Internal Comment:"
        '
        'ControlApproachDescriptionLabel
        '
        ControlApproachDescriptionLabel.Location = New System.Drawing.Point(17, 448)
        ControlApproachDescriptionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ControlApproachDescriptionLabel.Name = "ControlApproachDescriptionLabel"
        ControlApproachDescriptionLabel.Size = New System.Drawing.Size(97, 75)
        ControlApproachDescriptionLabel.TabIndex = 85
        ControlApproachDescriptionLabel.Text = "Overall control measure description"
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(703, 538)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(100, 28)
        Me.btnNext.TabIndex = 8
        Me.btnNext.Text = "Save"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(811, 538)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSCCNumber)
        Me.GroupBox1.Controls.Add(Me.lblSCCName)
        Me.GroupBox1.Controls.Add(Me.btnChangeProcessClass)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 53)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(884, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "* SCC Code"
        '
        'lblSCCNumber
        '
        Me.lblSCCNumber.AutoSize = True
        Me.lblSCCNumber.Location = New System.Drawing.Point(99, 28)
        Me.lblSCCNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSCCNumber.Name = "lblSCCNumber"
        Me.lblSCCNumber.Size = New System.Drawing.Size(99, 17)
        Me.lblSCCNumber.TabIndex = 38
        Me.lblSCCNumber.Text = "lblSCCNumber"
        '
        'lblSCCName
        '
        Me.lblSCCName.AutoSize = True
        Me.lblSCCName.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lblSCCName.Location = New System.Drawing.Point(99, 52)
        Me.lblSCCName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSCCName.Name = "lblSCCName"
        Me.lblSCCName.Size = New System.Drawing.Size(84, 18)
        Me.lblSCCName.TabIndex = 43
        Me.lblSCCName.Text = "lblSCCName"
        '
        'btnChangeProcessClass
        '
        Me.btnChangeProcessClass.Location = New System.Drawing.Point(16, 26)
        Me.btnChangeProcessClass.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnChangeProcessClass.Name = "btnChangeProcessClass"
        Me.btnChangeProcessClass.Size = New System.Drawing.Size(75, 28)
        Me.btnChangeProcessClass.TabIndex = 0
        Me.btnChangeProcessClass.Text = "Change"
        Me.btnChangeProcessClass.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(566, 17)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Fill in the general information about the process below. Choose Save to add the p" & _
    "rocess."
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProcessBindingSource
        '
        Me.ProcessBindingSource.DataMember = "Process"
        Me.ProcessBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessTableAdapter
        '
        Me.ProcessTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AffiliationTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BillingContactsTableAdapter = Nothing
        Me.TableAdapterManager.BillingFeeConfigTableAdapter = Nothing
        Me.TableAdapterManager.BillingHistoryTableAdapter = Nothing
        Me.TableAdapterManager.BillingTableAdapter = Nothing
        Me.TableAdapterManager.ControlMeasureHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ControlMeasurePollutantHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ControlMeasurePollutantTableAdapter = Nothing
        Me.TableAdapterManager.ControlMeasureTableAdapter = Nothing
        Me.TableAdapterManager.ControlMeasureTypeTableAdapter = Nothing
        Me.TableAdapterManager.ControlMeasureYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ControlMeasureYearTableAdapter = Nothing
        Me.TableAdapterManager.EmissionUnitDetailTypeTableAdapter = Nothing
        Me.TableAdapterManager.EmissionUnitTypeGroupTableAdapter = Nothing
        Me.TableAdapterManager.EmissionUnitTypeTableAdapter = Nothing
        Me.TableAdapterManager.EmissionYearTableAdapter = Nothing
        Me.TableAdapterManager.FacilityCategoryEISTableAdapter = Nothing
        Me.TableAdapterManager.FacilitySiteStatusTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.FormTableAdapter = Nothing
        Me.TableAdapterManager.MeasurementTableAdapter = Nothing
        Me.TableAdapterManager.OperatingStatusTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitDetailTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitHistoryTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitYearTableAdapter = Nothing
        Me.TableAdapterManager.PlantTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearContactsTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearFormTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearTableAdapter = Nothing
        Me.TableAdapterManager.PollutantTableAdapter = Nothing
        Me.TableAdapterManager.PreBillingTableAdapter = Nothing
        Me.TableAdapterManager.ProcessClassLevel1TypeTableAdapter = Nothing
        Me.TableAdapterManager.ProcessClassLevel2TypeTableAdapter = Nothing
        Me.TableAdapterManager.ProcessClassLevel3TypeTableAdapter = Nothing
        Me.TableAdapterManager.ProcessClassLevel4TypeTableAdapter = Nothing
        Me.TableAdapterManager.ProcessClassTableAdapter = Nothing
        Me.TableAdapterManager.ProcessControlMeasureHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessControlMeasureTableAdapter = Nothing
        Me.TableAdapterManager.ProcessDetailPeriodHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessDetailPeriodTableAdapter = Nothing
        Me.TableAdapterManager.ProcessEmissionHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessEmissionTableAdapter = Nothing
        Me.TableAdapterManager.ProcessHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessReleasePointHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessReleasePointTableAdapter = Nothing
        Me.TableAdapterManager.ProcessSeasonalActivityHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessSeasonalActivityTableAdapter = Nothing
        Me.TableAdapterManager.ProcessTableAdapter = Me.ProcessTableAdapter
        Me.TableAdapterManager.ProcessYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessYearTableAdapter = Me.ProcessYearTableAdapter
        Me.TableAdapterManager.ReleasePointDetailHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointDetailTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointTypeTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointYearTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeMeasurementTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeSubTypeTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeTableAdapter = Nothing
        Me.TableAdapterManager.ThroughputTypeTableAdapter = Nothing
        Me.TableAdapterManager.UnitOfMeasurementTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ProcessYearTableAdapter
        '
        Me.ProcessYearTableAdapter.ClearBeforeFill = True
        '
        'ProcessDescriptionTextBox
        '
        Me.ProcessDescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProcessBindingSource, "ProcessDescription", True))
        Me.ProcessDescriptionTextBox.Location = New System.Drawing.Point(119, 241)
        Me.ProcessDescriptionTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ProcessDescriptionTextBox.Multiline = True
        Me.ProcessDescriptionTextBox.Name = "ProcessDescriptionTextBox"
        Me.ProcessDescriptionTextBox.Size = New System.Drawing.Size(792, 61)
        Me.ProcessDescriptionTextBox.TabIndex = 3
        '
        'ProcessAPCDIDTextBox
        '
        Me.ProcessAPCDIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProcessBindingSource, "ProcessAPCDID", True))
        Me.ProcessAPCDIDTextBox.Location = New System.Drawing.Point(119, 207)
        Me.ProcessAPCDIDTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ProcessAPCDIDTextBox.Name = "ProcessAPCDIDTextBox"
        Me.ProcessAPCDIDTextBox.Size = New System.Drawing.Size(265, 22)
        Me.ProcessAPCDIDTextBox.TabIndex = 2
        '
        'CommentPublicTextBox
        '
        Me.CommentPublicTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProcessBindingSource, "CommentPublic", True))
        Me.CommentPublicTextBox.Location = New System.Drawing.Point(119, 310)
        Me.CommentPublicTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CommentPublicTextBox.Multiline = True
        Me.CommentPublicTextBox.Name = "CommentPublicTextBox"
        Me.CommentPublicTextBox.Size = New System.Drawing.Size(792, 61)
        Me.CommentPublicTextBox.TabIndex = 4
        '
        'CommentInternalTextBox
        '
        Me.CommentInternalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProcessBindingSource, "CommentInternal", True))
        Me.CommentInternalTextBox.Location = New System.Drawing.Point(119, 379)
        Me.CommentInternalTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CommentInternalTextBox.Multiline = True
        Me.CommentInternalTextBox.Name = "CommentInternalTextBox"
        Me.CommentInternalTextBox.Size = New System.Drawing.Size(792, 61)
        Me.CommentInternalTextBox.TabIndex = 5
        '
        'ThroughputTypeComboBox
        '
        Me.ThroughputTypeComboBox.DisplayMember = "ThroughputTypeID"
        Me.ThroughputTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ThroughputTypeComboBox.FormattingEnabled = True
        Me.ThroughputTypeComboBox.Location = New System.Drawing.Point(160, 155)
        Me.ThroughputTypeComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ThroughputTypeComboBox.Name = "ThroughputTypeComboBox"
        Me.ThroughputTypeComboBox.Size = New System.Drawing.Size(224, 24)
        Me.ThroughputTypeComboBox.TabIndex = 1
        Me.ThroughputTypeComboBox.ValueMember = "ThroughputTypeID"
        '
        'ProcessYearBindingSource
        '
        Me.ProcessYearBindingSource.DataMember = "ProcessYear"
        Me.ProcessYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ControlApproachDescriptionTextBox
        '
        Me.ControlApproachDescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProcessBindingSource, "ControlApproachDescription", True))
        Me.ControlApproachDescriptionTextBox.Location = New System.Drawing.Point(119, 448)
        Me.ControlApproachDescriptionTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ControlApproachDescriptionTextBox.MaxLength = 255
        Me.ControlApproachDescriptionTextBox.Multiline = True
        Me.ControlApproachDescriptionTextBox.Name = "ControlApproachDescriptionTextBox"
        Me.ControlApproachDescriptionTextBox.Size = New System.Drawing.Size(792, 61)
        Me.ControlApproachDescriptionTextBox.TabIndex = 6
        '
        'AddProcessStep1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 597)
        Me.ControlBox = False
        Me.Controls.Add(ControlApproachDescriptionLabel)
        Me.Controls.Add(Me.ControlApproachDescriptionTextBox)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Label7)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Me.ThroughputTypeComboBox)
        Me.Controls.Add(Me.ProcessDescriptionTextBox)
        Me.Controls.Add(Me.ProcessAPCDIDTextBox)
        Me.Controls.Add(Me.CommentPublicTextBox)
        Me.Controls.Add(Me.CommentInternalTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "AddProcessStep1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add a Process - General Info"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSCCNumber As System.Windows.Forms.Label
    Friend WithEvents lblSCCName As System.Windows.Forms.Label
    Friend WithEvents btnChangeProcessClass As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ProcessBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ProcessDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProcessAPCDIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentPublicTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ThroughputTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProcessYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessYearTableAdapter
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ControlApproachDescriptionTextBox As System.Windows.Forms.TextBox
End Class
