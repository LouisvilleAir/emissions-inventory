<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerateBills
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerateBills))
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.PreBillingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PreBillingTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PreBillingTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.BillingContactsTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.BillingContactsTableAdapter()
        Me.BillingTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.BillingTableAdapter()
        Me.BillingContactsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RptPlantEmissionsSummaryV2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RptPlantEmissionsSummaryV2TableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.rptPlantEmissionsSummaryV2TableAdapter()
        Me.BillingFeeConfigBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BillingFeeConfigTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.BillingFeeConfigTableAdapter()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoActual = New System.Windows.Forms.RadioButton()
        Me.rdoAssessment = New System.Windows.Forms.RadioButton()
        Me.btnGenerateBill = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.BillingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantGroupBox = New System.Windows.Forms.GroupBox()
        Me.AddPlantButton = New System.Windows.Forms.Button()
        Me.PlantComboBox = New System.Windows.Forms.ComboBox()
        Me.PlantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SelectedPlantListBox = New System.Windows.Forms.ListBox()
        Me.rdoSelectedPlants = New System.Windows.Forms.RadioButton()
        Me.rdoAllPlants = New System.Windows.Forms.RadioButton()
        Me.PlantTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantTableAdapter()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PreBillingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillingContactsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RptPlantEmissionsSummaryV2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillingFeeConfigBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BillingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PlantGroupBox.SuspendLayout()
        CType(Me.PlantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PreBillingBindingSource
        '
        Me.PreBillingBindingSource.DataMember = "PreBilling"
        Me.PreBillingBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PreBillingTableAdapter
        '
        Me.PreBillingTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AffiliationTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BillingContactsTableAdapter = Me.BillingContactsTableAdapter
        Me.TableAdapterManager.BillingFeeConfigTableAdapter = Nothing
        Me.TableAdapterManager.BillingHistoryTableAdapter = Nothing
        Me.TableAdapterManager.BillingTableAdapter = Me.BillingTableAdapter
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
        Me.TableAdapterManager.PreBillingTableAdapter = Me.PreBillingTableAdapter
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
        Me.TableAdapterManager.ProcessTableAdapter = Nothing
        Me.TableAdapterManager.ProcessYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessYearTableAdapter = Nothing
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
        'BillingContactsTableAdapter
        '
        Me.BillingContactsTableAdapter.ClearBeforeFill = True
        '
        'BillingTableAdapter
        '
        Me.BillingTableAdapter.ClearBeforeFill = True
        '
        'BillingContactsBindingSource
        '
        Me.BillingContactsBindingSource.DataMember = "BillingContacts"
        Me.BillingContactsBindingSource.DataSource = Me.EmissionsDataSet
        '
        'RptPlantEmissionsSummaryV2BindingSource
        '
        Me.RptPlantEmissionsSummaryV2BindingSource.DataMember = "rptPlantEmissionsSummaryV2"
        Me.RptPlantEmissionsSummaryV2BindingSource.DataSource = Me.EmissionsDataSet
        '
        'RptPlantEmissionsSummaryV2TableAdapter
        '
        Me.RptPlantEmissionsSummaryV2TableAdapter.ClearBeforeFill = True
        '
        'BillingFeeConfigBindingSource
        '
        Me.BillingFeeConfigBindingSource.DataMember = "BillingFeeConfig"
        Me.BillingFeeConfigBindingSource.DataSource = Me.EmissionsDataSet
        '
        'BillingFeeConfigTableAdapter
        '
        Me.BillingFeeConfigTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoActual)
        Me.GroupBox1.Controls.Add(Me.rdoAssessment)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(163, 44)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bill Type"
        '
        'rdoActual
        '
        Me.rdoActual.AutoSize = True
        Me.rdoActual.Location = New System.Drawing.Point(93, 19)
        Me.rdoActual.Name = "rdoActual"
        Me.rdoActual.Size = New System.Drawing.Size(55, 17)
        Me.rdoActual.TabIndex = 1
        Me.rdoActual.TabStop = True
        Me.rdoActual.Text = "Actual"
        Me.rdoActual.UseVisualStyleBackColor = True
        '
        'rdoAssessment
        '
        Me.rdoAssessment.AutoSize = True
        Me.rdoAssessment.Location = New System.Drawing.Point(6, 19)
        Me.rdoAssessment.Name = "rdoAssessment"
        Me.rdoAssessment.Size = New System.Drawing.Size(81, 17)
        Me.rdoAssessment.TabIndex = 0
        Me.rdoAssessment.TabStop = True
        Me.rdoAssessment.Text = "Assessment"
        Me.rdoAssessment.UseVisualStyleBackColor = True
        '
        'btnGenerateBill
        '
        Me.btnGenerateBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateBill.Location = New System.Drawing.Point(12, 240)
        Me.btnGenerateBill.Name = "btnGenerateBill"
        Me.btnGenerateBill.Size = New System.Drawing.Size(120, 28)
        Me.btnGenerateBill.TabIndex = 1
        Me.btnGenerateBill.Text = "Generate Bills"
        Me.btnGenerateBill.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(375, 240)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 28)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'BillingBindingSource
        '
        Me.BillingBindingSource.DataMember = "Billing"
        Me.BillingBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PlantGroupBox
        '
        Me.PlantGroupBox.Controls.Add(Me.AddPlantButton)
        Me.PlantGroupBox.Controls.Add(Me.PlantComboBox)
        Me.PlantGroupBox.Controls.Add(Me.SelectedPlantListBox)
        Me.PlantGroupBox.Controls.Add(Me.rdoSelectedPlants)
        Me.PlantGroupBox.Controls.Add(Me.rdoAllPlants)
        Me.PlantGroupBox.Location = New System.Drawing.Point(12, 74)
        Me.PlantGroupBox.Name = "PlantGroupBox"
        Me.PlantGroupBox.Size = New System.Drawing.Size(438, 145)
        Me.PlantGroupBox.TabIndex = 3
        Me.PlantGroupBox.TabStop = False
        Me.PlantGroupBox.Text = "Plant Selection"
        '
        'AddPlantButton
        '
        Me.AddPlantButton.Enabled = False
        Me.AddPlantButton.Location = New System.Drawing.Point(319, 67)
        Me.AddPlantButton.Name = "AddPlantButton"
        Me.AddPlantButton.Size = New System.Drawing.Size(38, 23)
        Me.AddPlantButton.TabIndex = 4
        Me.AddPlantButton.Text = "Add"
        Me.AddPlantButton.UseVisualStyleBackColor = True
        '
        'PlantComboBox
        '
        Me.PlantComboBox.DataSource = Me.PlantBindingSource
        Me.PlantComboBox.DisplayMember = "PlantName"
        Me.PlantComboBox.Enabled = False
        Me.PlantComboBox.FormattingEnabled = True
        Me.PlantComboBox.Location = New System.Drawing.Point(22, 67)
        Me.PlantComboBox.Name = "PlantComboBox"
        Me.PlantComboBox.Size = New System.Drawing.Size(291, 21)
        Me.PlantComboBox.TabIndex = 3
        Me.PlantComboBox.ValueMember = "PlantID"
        '
        'PlantBindingSource
        '
        Me.PlantBindingSource.DataMember = "Plant"
        Me.PlantBindingSource.DataSource = Me.EmissionsDataSet
        '
        'SelectedPlantListBox
        '
        Me.SelectedPlantListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SelectedPlantListBox.Enabled = False
        Me.SelectedPlantListBox.FormattingEnabled = True
        Me.SelectedPlantListBox.Location = New System.Drawing.Point(363, 44)
        Me.SelectedPlantListBox.Name = "SelectedPlantListBox"
        Me.SelectedPlantListBox.Size = New System.Drawing.Size(57, 80)
        Me.SelectedPlantListBox.Sorted = True
        Me.SelectedPlantListBox.TabIndex = 2
        '
        'rdoSelectedPlants
        '
        Me.rdoSelectedPlants.AutoSize = True
        Me.rdoSelectedPlants.Location = New System.Drawing.Point(6, 44)
        Me.rdoSelectedPlants.Name = "rdoSelectedPlants"
        Me.rdoSelectedPlants.Size = New System.Drawing.Size(104, 17)
        Me.rdoSelectedPlants.TabIndex = 1
        Me.rdoSelectedPlants.Text = "Selected plant(s)"
        Me.rdoSelectedPlants.UseVisualStyleBackColor = True
        '
        'rdoAllPlants
        '
        Me.rdoAllPlants.AutoSize = True
        Me.rdoAllPlants.Checked = True
        Me.rdoAllPlants.Location = New System.Drawing.Point(7, 20)
        Me.rdoAllPlants.Name = "rdoAllPlants"
        Me.rdoAllPlants.Size = New System.Drawing.Size(100, 17)
        Me.rdoAllPlants.TabIndex = 0
        Me.rdoAllPlants.TabStop = True
        Me.rdoAllPlants.Text = "All Title V plants"
        Me.rdoAllPlants.UseVisualStyleBackColor = True
        '
        'PlantTableAdapter
        '
        Me.PlantTableAdapter.ClearBeforeFill = True
        '
        'GeneratePreBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(464, 282)
        Me.ControlBox = False
        Me.Controls.Add(Me.PlantGroupBox)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnGenerateBill)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GeneratePreBill"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "GeneratePreBill"
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PreBillingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillingContactsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RptPlantEmissionsSummaryV2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillingFeeConfigBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BillingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PlantGroupBox.ResumeLayout(False)
        Me.PlantGroupBox.PerformLayout()
        CType(Me.PlantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents PreBillingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PreBillingTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PreBillingTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents BillingContactsTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.BillingContactsTableAdapter
    Friend WithEvents BillingContactsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RptPlantEmissionsSummaryV2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RptPlantEmissionsSummaryV2TableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.rptPlantEmissionsSummaryV2TableAdapter
    Friend WithEvents BillingFeeConfigBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BillingFeeConfigTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.BillingFeeConfigTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActual As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAssessment As System.Windows.Forms.RadioButton
    Friend WithEvents btnGenerateBill As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents BillingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BillingTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.BillingTableAdapter
    Friend WithEvents PlantGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SelectedPlantListBox As System.Windows.Forms.ListBox
    Friend WithEvents rdoSelectedPlants As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAllPlants As System.Windows.Forms.RadioButton
    Friend WithEvents PlantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantTableAdapter
    Friend WithEvents AddPlantButton As System.Windows.Forms.Button
    Friend WithEvents PlantComboBox As System.Windows.Forms.ComboBox
End Class
