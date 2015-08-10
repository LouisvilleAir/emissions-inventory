<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddControlMeasureStep3
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
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.ControlMeasurePollutantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasurePollutantTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasurePollutantTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.PollutantComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.percentTextBox = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.pollutantDataGridView = New System.Windows.Forms.DataGridView()
        Me.PollutantName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PollutantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PollutantTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PollutantTableAdapter()
        Me.PercentSignLabel = New System.Windows.Forms.Label()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasurePollutantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pollutantDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PollutantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ControlMeasurePollutantBindingSource
        '
        Me.ControlMeasurePollutantBindingSource.DataMember = "ControlMeasurePollutant"
        Me.ControlMeasurePollutantBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasurePollutantTableAdapter
        '
        Me.ControlMeasurePollutantTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.ControlMeasurePollutantTableAdapter = Me.ControlMeasurePollutantTableAdapter
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
        'PollutantComboBox
        '
        Me.PollutantComboBox.DisplayMember = "PollutantID"
        Me.PollutantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PollutantComboBox.FormattingEnabled = True
        Me.PollutantComboBox.Location = New System.Drawing.Point(16, 50)
        Me.PollutantComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PollutantComboBox.Name = "PollutantComboBox"
        Me.PollutantComboBox.Size = New System.Drawing.Size(332, 24)
        Me.PollutantComboBox.TabIndex = 3
        Me.PollutantComboBox.ValueMember = "PollutantID"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(557, 37)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Pick a pollutant from the drop down list and enter a value for the reduction effi" & _
    "ciency, then choose Add to add it to the grid"
        '
        'percentTextBox
        '
        Me.percentTextBox.Location = New System.Drawing.Point(357, 50)
        Me.percentTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.percentTextBox.Name = "percentTextBox"
        Me.percentTextBox.Size = New System.Drawing.Size(42, 22)
        Me.percentTextBox.TabIndex = 5
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(443, 47)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(59, 28)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDone.Location = New System.Drawing.Point(469, 390)
        Me.btnDone.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(100, 28)
        Me.btnDone.TabIndex = 7
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'pollutantDataGridView
        '
        Me.pollutantDataGridView.AllowUserToAddRows = False
        Me.pollutantDataGridView.AllowUserToDeleteRows = False
        Me.pollutantDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pollutantDataGridView.ColumnHeadersVisible = False
        Me.pollutantDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PollutantName})
        Me.pollutantDataGridView.Location = New System.Drawing.Point(16, 84)
        Me.pollutantDataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pollutantDataGridView.Name = "pollutantDataGridView"
        Me.pollutantDataGridView.ReadOnly = True
        Me.pollutantDataGridView.Size = New System.Drawing.Size(553, 277)
        Me.pollutantDataGridView.TabIndex = 8
        '
        'PollutantName
        '
        Me.PollutantName.DataPropertyName = "PollutantName"
        Me.PollutantName.HeaderText = "Pollutant"
        Me.PollutantName.Name = "PollutantName"
        Me.PollutantName.ReadOnly = True
        Me.PollutantName.Width = 250
        '
        'PollutantBindingSource
        '
        Me.PollutantBindingSource.DataMember = "Pollutant"
        Me.PollutantBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PollutantTableAdapter
        '
        Me.PollutantTableAdapter.ClearBeforeFill = True
        '
        'PercentSignLabel
        '
        Me.PercentSignLabel.AutoSize = True
        Me.PercentSignLabel.Location = New System.Drawing.Point(406, 53)
        Me.PercentSignLabel.Name = "PercentSignLabel"
        Me.PercentSignLabel.Size = New System.Drawing.Size(20, 17)
        Me.PercentSignLabel.TabIndex = 9
        Me.PercentSignLabel.Text = "%"
        '
        'AddControlMeasureStep3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 433)
        Me.ControlBox = False
        Me.Controls.Add(Me.PercentSignLabel)
        Me.Controls.Add(Me.pollutantDataGridView)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.percentTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PollutantComboBox)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "AddControlMeasureStep3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Control Measure Pollutants"
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasurePollutantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pollutantDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PollutantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ControlMeasurePollutantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasurePollutantTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasurePollutantTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PollutantComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents percentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pollutantDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents PollutantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PollutantTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PollutantTableAdapter
    Friend WithEvents PollutantName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PercentSignLabel As System.Windows.Forms.Label
End Class
