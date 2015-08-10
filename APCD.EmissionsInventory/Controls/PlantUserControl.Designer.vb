<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlantUserControl
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
        Dim PlantIDLabel As System.Windows.Forms.Label
        Dim PlantNameLabel As System.Windows.Forms.Label
        Dim PlantDescriptionLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PlantIDTextBox = New System.Windows.Forms.TextBox()
        Me.PlantNameTextBox = New System.Windows.Forms.TextBox()
        Me.PlantDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.processSummary = New System.Windows.Forms.TabPage()
        Me.RptPlantEmissionsSummaryV2DataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PollutantID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RptPlantEmissionsSummaryV2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.lblTotalHAPS = New System.Windows.Forms.Label()
        Me.RptPlantEmissionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.RptPlantEmissionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.PlantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.EmissionYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.EmissionYearTableAdapter()
        Me.EmissionYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RptPlantEmissionsTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.rptPlantEmissionsTableAdapter()
        Me.RptPlantEmissionsSummaryV2TableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.rptPlantEmissionsSummaryV2TableAdapter()
        Me.btnViewEmissionsSummaryGrid = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnSortLabel = New System.Windows.Forms.Label()
        PlantIDLabel = New System.Windows.Forms.Label()
        PlantNameLabel = New System.Windows.Forms.Label()
        PlantDescriptionLabel = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.processSummary.SuspendLayout()
        CType(Me.RptPlantEmissionsSummaryV2DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RptPlantEmissionsSummaryV2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RptPlantEmissionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RptPlantEmissionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlantIDLabel
        '
        PlantIDLabel.AutoSize = True
        PlantIDLabel.Font = New System.Drawing.Font("Calibri", 9.0!)
        PlantIDLabel.Location = New System.Drawing.Point(3, 13)
        PlantIDLabel.Name = "PlantIDLabel"
        PlantIDLabel.Size = New System.Drawing.Size(53, 14)
        PlantIDLabel.TabIndex = 2
        PlantIDLabel.Text = "Plant ID:"
        '
        'PlantNameLabel
        '
        PlantNameLabel.AutoSize = True
        PlantNameLabel.Font = New System.Drawing.Font("Calibri", 9.0!)
        PlantNameLabel.Location = New System.Drawing.Point(3, 39)
        PlantNameLabel.Name = "PlantNameLabel"
        PlantNameLabel.Size = New System.Drawing.Size(73, 14)
        PlantNameLabel.TabIndex = 4
        PlantNameLabel.Text = "Plant Name:"
        '
        'PlantDescriptionLabel
        '
        PlantDescriptionLabel.AutoSize = True
        PlantDescriptionLabel.Font = New System.Drawing.Font("Calibri", 9.0!)
        PlantDescriptionLabel.Location = New System.Drawing.Point(3, 65)
        PlantDescriptionLabel.Name = "PlantDescriptionLabel"
        PlantDescriptionLabel.Size = New System.Drawing.Size(103, 14)
        PlantDescriptionLabel.TabIndex = 6
        PlantDescriptionLabel.Text = "Plant Description:"
        '
        'PlantIDTextBox
        '
        Me.PlantIDTextBox.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.PlantIDTextBox.Location = New System.Drawing.Point(112, 10)
        Me.PlantIDTextBox.Name = "PlantIDTextBox"
        Me.PlantIDTextBox.ReadOnly = True
        Me.PlantIDTextBox.Size = New System.Drawing.Size(40, 25)
        Me.PlantIDTextBox.TabIndex = 3
        '
        'PlantNameTextBox
        '
        Me.PlantNameTextBox.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.PlantNameTextBox.Location = New System.Drawing.Point(112, 36)
        Me.PlantNameTextBox.Name = "PlantNameTextBox"
        Me.PlantNameTextBox.ReadOnly = True
        Me.PlantNameTextBox.Size = New System.Drawing.Size(400, 22)
        Me.PlantNameTextBox.TabIndex = 5
        '
        'PlantDescriptionTextBox
        '
        Me.PlantDescriptionTextBox.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.PlantDescriptionTextBox.Location = New System.Drawing.Point(112, 62)
        Me.PlantDescriptionTextBox.Multiline = True
        Me.PlantDescriptionTextBox.Name = "PlantDescriptionTextBox"
        Me.PlantDescriptionTextBox.ReadOnly = True
        Me.PlantDescriptionTextBox.Size = New System.Drawing.Size(585, 59)
        Me.PlantDescriptionTextBox.TabIndex = 7
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.processSummary)
        Me.TabControl1.Location = New System.Drawing.Point(5, 155)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(705, 470)
        Me.TabControl1.TabIndex = 9
        '
        'processSummary
        '
        Me.processSummary.AutoScroll = True
        Me.processSummary.Controls.Add(Me.RptPlantEmissionsSummaryV2DataGridView)
        Me.processSummary.Controls.Add(Me.lblTotalHAPS)
        Me.processSummary.Controls.Add(Me.RptPlantEmissionsDataGridView)
        Me.processSummary.Location = New System.Drawing.Point(4, 22)
        Me.processSummary.Name = "processSummary"
        Me.processSummary.Padding = New System.Windows.Forms.Padding(3)
        Me.processSummary.Size = New System.Drawing.Size(697, 444)
        Me.processSummary.TabIndex = 0
        Me.processSummary.Text = "Emissions Summary"
        Me.processSummary.UseVisualStyleBackColor = True
        '
        'RptPlantEmissionsSummaryV2DataGridView
        '
        Me.RptPlantEmissionsSummaryV2DataGridView.AllowUserToAddRows = False
        Me.RptPlantEmissionsSummaryV2DataGridView.AllowUserToDeleteRows = False
        Me.RptPlantEmissionsSummaryV2DataGridView.AllowUserToResizeRows = False
        Me.RptPlantEmissionsSummaryV2DataGridView.AutoGenerateColumns = False
        Me.RptPlantEmissionsSummaryV2DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RptPlantEmissionsSummaryV2DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.PollutantID, Me.DataGridViewTextBoxColumn16})
        Me.RptPlantEmissionsSummaryV2DataGridView.DataSource = Me.RptPlantEmissionsSummaryV2BindingSource
        Me.RptPlantEmissionsSummaryV2DataGridView.Location = New System.Drawing.Point(5, 33)
        Me.RptPlantEmissionsSummaryV2DataGridView.Name = "RptPlantEmissionsSummaryV2DataGridView"
        Me.RptPlantEmissionsSummaryV2DataGridView.ReadOnly = True
        Me.RptPlantEmissionsSummaryV2DataGridView.RowHeadersVisible = False
        Me.RptPlantEmissionsSummaryV2DataGridView.Size = New System.Drawing.Size(239, 405)
        Me.RptPlantEmissionsSummaryV2DataGridView.TabIndex = 10
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "PollutantName"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn15.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn15.HeaderText = "Pollutant"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 165
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "SumOfEmissionValue"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.Format = "N4"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn17.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn17.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 55
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "PlantID"
        Me.DataGridViewTextBoxColumn13.HeaderText = "PlantID"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "EmissionYear"
        Me.DataGridViewTextBoxColumn14.HeaderText = "EmissionYear"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'PollutantID
        '
        Me.PollutantID.DataPropertyName = "PollutantID"
        Me.PollutantID.HeaderText = "PollutantID"
        Me.PollutantID.Name = "PollutantID"
        Me.PollutantID.ReadOnly = True
        Me.PollutantID.Visible = False
        Me.PollutantID.Width = 85
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "PollutantTypeEISID"
        Me.DataGridViewTextBoxColumn16.HeaderText = "PollutantTypeEISID"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'RptPlantEmissionsSummaryV2BindingSource
        '
        Me.RptPlantEmissionsSummaryV2BindingSource.DataMember = "rptPlantEmissionsSummaryV2"
        Me.RptPlantEmissionsSummaryV2BindingSource.DataSource = Me.EmissionsDataSet
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblTotalHAPS
        '
        Me.lblTotalHAPS.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblTotalHAPS.Location = New System.Drawing.Point(6, 11)
        Me.lblTotalHAPS.Name = "lblTotalHAPS"
        Me.lblTotalHAPS.Size = New System.Drawing.Size(400, 17)
        Me.lblTotalHAPS.TabIndex = 10
        Me.lblTotalHAPS.Text = "Total HAPS"
        '
        'RptPlantEmissionsDataGridView
        '
        Me.RptPlantEmissionsDataGridView.AllowUserToAddRows = False
        Me.RptPlantEmissionsDataGridView.AllowUserToDeleteRows = False
        Me.RptPlantEmissionsDataGridView.AllowUserToResizeRows = False
        Me.RptPlantEmissionsDataGridView.AutoGenerateColumns = False
        Me.RptPlantEmissionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RptPlantEmissionsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn10})
        Me.RptPlantEmissionsDataGridView.DataSource = Me.RptPlantEmissionsBindingSource
        Me.RptPlantEmissionsDataGridView.Location = New System.Drawing.Point(249, 33)
        Me.RptPlantEmissionsDataGridView.Name = "RptPlantEmissionsDataGridView"
        Me.RptPlantEmissionsDataGridView.ReadOnly = True
        Me.RptPlantEmissionsDataGridView.RowHeadersVisible = False
        Me.RptPlantEmissionsDataGridView.Size = New System.Drawing.Size(443, 405)
        Me.RptPlantEmissionsDataGridView.TabIndex = 9
        '
        'RptPlantEmissionsBindingSource
        '
        Me.RptPlantEmissionsBindingSource.DataMember = "rptPlantEmissions"
        Me.RptPlantEmissionsBindingSource.DataSource = Me.EmissionsDataSet
        '
        'lblLoading
        '
        Me.lblLoading.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.Location = New System.Drawing.Point(177, 124)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(125, 23)
        Me.lblLoading.TabIndex = 12
        Me.lblLoading.Text = "Loading. . ."
        Me.lblLoading.Visible = False
        '
        'PlantBindingSource
        '
        Me.PlantBindingSource.DataMember = "Plant"
        Me.PlantBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PlantTableAdapter
        '
        Me.PlantTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.EmissionYearTableAdapter = Me.EmissionYearTableAdapter
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
        Me.TableAdapterManager.PlantTableAdapter = Me.PlantTableAdapter
        Me.TableAdapterManager.PlantYearContactsTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearFormTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearTableAdapter = Nothing
        Me.TableAdapterManager.PollutantTableAdapter = Nothing
        Me.TableAdapterManager.PreBillingTableAdapter = Nothing
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
        'EmissionYearTableAdapter
        '
        Me.EmissionYearTableAdapter.ClearBeforeFill = True
        '
        'EmissionYearBindingSource
        '
        Me.EmissionYearBindingSource.DataMember = "EmissionYear"
        Me.EmissionYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'RptPlantEmissionsTableAdapter
        '
        Me.RptPlantEmissionsTableAdapter.ClearBeforeFill = True
        '
        'RptPlantEmissionsSummaryV2TableAdapter
        '
        Me.RptPlantEmissionsSummaryV2TableAdapter.ClearBeforeFill = True
        '
        'btnViewEmissionsSummaryGrid
        '
        Me.btnViewEmissionsSummaryGrid.Location = New System.Drawing.Point(5, 124)
        Me.btnViewEmissionsSummaryGrid.Name = "btnViewEmissionsSummaryGrid"
        Me.btnViewEmissionsSummaryGrid.Size = New System.Drawing.Size(165, 23)
        Me.btnViewEmissionsSummaryGrid.TabIndex = 10
        Me.btnViewEmissionsSummaryGrid.Text = "View Emissions Summary Grid"
        Me.btnViewEmissionsSummaryGrid.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "EmissionUnitAPCDID"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn12.HeaderText = "Emission Unit"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 160
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "ProcessAPCDID"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn11.HeaderText = "Process"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 210
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "EmissionValue"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn9.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 55
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "PlantID"
        Me.DataGridViewTextBoxColumn6.HeaderText = "PlantID"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "EmissionYear"
        Me.DataGridViewTextBoxColumn7.HeaderText = "EmissionYear"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "PollutantID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "PollutantID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "PollutantName"
        Me.DataGridViewTextBoxColumn8.HeaderText = "PollutantName"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "PollutantTypeEISID"
        Me.DataGridViewTextBoxColumn10.HeaderText = "PollutantTypeEISID"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'ColumnSortLabel
        '
        Me.ColumnSortLabel.AutoSize = True
        Me.ColumnSortLabel.Location = New System.Drawing.Point(453, 129)
        Me.ColumnSortLabel.Name = "ColumnSortLabel"
        Me.ColumnSortLabel.Size = New System.Drawing.Size(244, 13)
        Me.ColumnSortLabel.TabIndex = 13
        Me.ColumnSortLabel.Text = "You can click on a heading to sort by that column."
        Me.ColumnSortLabel.Visible = False
        '
        'PlantUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ColumnSortLabel)
        Me.Controls.Add(Me.lblLoading)
        Me.Controls.Add(Me.btnViewEmissionsSummaryGrid)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(PlantIDLabel)
        Me.Controls.Add(Me.PlantIDTextBox)
        Me.Controls.Add(PlantNameLabel)
        Me.Controls.Add(Me.PlantNameTextBox)
        Me.Controls.Add(PlantDescriptionLabel)
        Me.Controls.Add(Me.PlantDescriptionTextBox)
        Me.Name = "PlantUserControl"
        Me.Size = New System.Drawing.Size(715, 640)
        Me.TabControl1.ResumeLayout(False)
        Me.processSummary.ResumeLayout(False)
        CType(Me.RptPlantEmissionsSummaryV2DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RptPlantEmissionsSummaryV2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RptPlantEmissionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RptPlantEmissionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PlantIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PlantNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PlantDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents processSummary As System.Windows.Forms.TabPage
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents PlantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents EmissionYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.EmissionYearTableAdapter
    Friend WithEvents EmissionYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RptPlantEmissionsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RptPlantEmissionsTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.rptPlantEmissionsTableAdapter
    Friend WithEvents RptPlantEmissionsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotalHAPS As System.Windows.Forms.Label
    Friend WithEvents RptPlantEmissionsSummaryV2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RptPlantEmissionsSummaryV2TableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.rptPlantEmissionsSummaryV2TableAdapter
    Friend WithEvents RptPlantEmissionsSummaryV2DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents btnViewEmissionsSummaryGrid As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PollutantID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnSortLabel As System.Windows.Forms.Label

End Class
