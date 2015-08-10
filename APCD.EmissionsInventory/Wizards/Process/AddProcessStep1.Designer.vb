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
        Label2.Location = New System.Drawing.Point(12, 129)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(99, 13)
        Label2.TabIndex = 79
        Label2.Text = "* Throughput Type:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(7, 196)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(63, 13)
        Label3.TabIndex = 80
        Label3.Text = "Description:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(9, 171)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(57, 13)
        Label4.TabIndex = 81
        Label4.Text = "*APCD ID:"
        '
        'Label6
        '
        Label6.Location = New System.Drawing.Point(11, 252)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(70, 31)
        Label6.TabIndex = 83
        Label6.Text = "Public Comment:"
        '
        'Label7
        '
        Label7.Location = New System.Drawing.Point(9, 308)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(70, 31)
        Label7.TabIndex = 84
        Label7.Text = "Internal Comment:"
        '
        'ControlApproachDescriptionLabel
        '
        ControlApproachDescriptionLabel.Location = New System.Drawing.Point(13, 364)
        ControlApproachDescriptionLabel.Name = "ControlApproachDescriptionLabel"
        ControlApproachDescriptionLabel.Size = New System.Drawing.Size(73, 61)
        ControlApproachDescriptionLabel.TabIndex = 85
        ControlApproachDescriptionLabel.Text = "Overall control measure description"
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(536, 437)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 8
        Me.btnNext.Text = "Save"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(617, 437)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSCCNumber)
        Me.GroupBox1.Controls.Add(Me.lblSCCName)
        Me.GroupBox1.Controls.Add(Me.btnChangeProcessClass)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(663, 66)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "* SCC Code"
        '
        'lblSCCNumber
        '
        Me.lblSCCNumber.AutoSize = True
        Me.lblSCCNumber.Location = New System.Drawing.Point(74, 23)
        Me.lblSCCNumber.Name = "lblSCCNumber"
        Me.lblSCCNumber.Size = New System.Drawing.Size(75, 13)
        Me.lblSCCNumber.TabIndex = 38
        Me.lblSCCNumber.Text = "lblSCCNumber"
        '
        'lblSCCName
        '
        Me.lblSCCName.AutoSize = True
        Me.lblSCCName.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lblSCCName.Location = New System.Drawing.Point(74, 42)
        Me.lblSCCName.Name = "lblSCCName"
        Me.lblSCCName.Size = New System.Drawing.Size(72, 14)
        Me.lblSCCName.TabIndex = 43
        Me.lblSCCName.Text = "lblSCCName"
        '
        'btnChangeProcessClass
        '
        Me.btnChangeProcessClass.Location = New System.Drawing.Point(12, 21)
        Me.btnChangeProcessClass.Name = "btnChangeProcessClass"
        Me.btnChangeProcessClass.Size = New System.Drawing.Size(56, 23)
        Me.btnChangeProcessClass.TabIndex = 0
        Me.btnChangeProcessClass.Text = "Change"
        Me.btnChangeProcessClass.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(423, 13)
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
        Me.TableAdapterManager.MeasurementTableAdapter = Nothing
        Me.TableAdapterManager.OperatingStatusTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitDetailTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitHistoryTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitYearTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearTableAdapter = Nothing
        Me.TableAdapterManager.PollutantTableAdapter = Nothing
        Me.TableAdapterManager.ProcessClassLevel1TypeTableAdapter = Nothing
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
        Me.ProcessDescriptionTextBox.Location = New System.Drawing.Point(89, 196)
        Me.ProcessDescriptionTextBox.Multiline = True
        Me.ProcessDescriptionTextBox.Name = "ProcessDescriptionTextBox"
        Me.ProcessDescriptionTextBox.Size = New System.Drawing.Size(595, 50)
        Me.ProcessDescriptionTextBox.TabIndex = 3
        '
        'ProcessAPCDIDTextBox
        '
        Me.ProcessAPCDIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProcessBindingSource, "ProcessAPCDID", True))
        Me.ProcessAPCDIDTextBox.Location = New System.Drawing.Point(89, 168)
        Me.ProcessAPCDIDTextBox.Name = "ProcessAPCDIDTextBox"
        Me.ProcessAPCDIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ProcessAPCDIDTextBox.TabIndex = 2
        '
        'CommentPublicTextBox
        '
        Me.CommentPublicTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProcessBindingSource, "CommentPublic", True))
        Me.CommentPublicTextBox.Location = New System.Drawing.Point(89, 252)
        Me.CommentPublicTextBox.Multiline = True
        Me.CommentPublicTextBox.Name = "CommentPublicTextBox"
        Me.CommentPublicTextBox.Size = New System.Drawing.Size(595, 50)
        Me.CommentPublicTextBox.TabIndex = 4
        '
        'CommentInternalTextBox
        '
        Me.CommentInternalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProcessBindingSource, "CommentInternal", True))
        Me.CommentInternalTextBox.Location = New System.Drawing.Point(89, 308)
        Me.CommentInternalTextBox.Multiline = True
        Me.CommentInternalTextBox.Name = "CommentInternalTextBox"
        Me.CommentInternalTextBox.Size = New System.Drawing.Size(595, 50)
        Me.CommentInternalTextBox.TabIndex = 5
        '
        'ThroughputTypeComboBox
        '
        Me.ThroughputTypeComboBox.DisplayMember = "ThroughputTypeID"
        Me.ThroughputTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ThroughputTypeComboBox.FormattingEnabled = True
        Me.ThroughputTypeComboBox.Location = New System.Drawing.Point(120, 126)
        Me.ThroughputTypeComboBox.Name = "ThroughputTypeComboBox"
        Me.ThroughputTypeComboBox.Size = New System.Drawing.Size(169, 21)
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
        Me.ControlApproachDescriptionTextBox.Location = New System.Drawing.Point(89, 364)
        Me.ControlApproachDescriptionTextBox.MaxLength = 255
        Me.ControlApproachDescriptionTextBox.Multiline = True
        Me.ControlApproachDescriptionTextBox.Name = "ControlApproachDescriptionTextBox"
        Me.ControlApproachDescriptionTextBox.Size = New System.Drawing.Size(592, 50)
        Me.ControlApproachDescriptionTextBox.TabIndex = 6
        '
        'AddProcessStep1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 472)
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
