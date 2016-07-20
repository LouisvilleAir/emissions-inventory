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
        Me.lblTotalHAPS = New System.Windows.Forms.Label()
        Me.RptPlantEmissionsSummaryV2DataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PollutantID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RptPlantEmissionsSummaryV2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.RptPlantEmissionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.ColumnSortLabel = New System.Windows.Forms.Label()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.SummarySplitContainer = New System.Windows.Forms.SplitContainer()
        Me.SummaryHeaderPanel = New System.Windows.Forms.Panel()
        Me.SummaryTitleLabel = New System.Windows.Forms.Label()
        PlantIDLabel = New System.Windows.Forms.Label()
        PlantNameLabel = New System.Windows.Forms.Label()
        PlantDescriptionLabel = New System.Windows.Forms.Label()
        CType(Me.RptPlantEmissionsSummaryV2DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RptPlantEmissionsSummaryV2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RptPlantEmissionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RptPlantEmissionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        CType(Me.SummarySplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SummarySplitContainer.Panel1.SuspendLayout()
        Me.SummarySplitContainer.Panel2.SuspendLayout()
        Me.SummarySplitContainer.SuspendLayout()
        Me.SummaryHeaderPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlantIDLabel
        '
        PlantIDLabel.AutoSize = True
        PlantIDLabel.Font = New System.Drawing.Font("Calibri", 9.0!)
        PlantIDLabel.Location = New System.Drawing.Point(8, 11)
        PlantIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        PlantIDLabel.Name = "PlantIDLabel"
        PlantIDLabel.Size = New System.Drawing.Size(60, 18)
        PlantIDLabel.TabIndex = 2
        PlantIDLabel.Text = "Plant ID:"
        '
        'PlantNameLabel
        '
        PlantNameLabel.AutoSize = True
        PlantNameLabel.Font = New System.Drawing.Font("Calibri", 9.0!)
        PlantNameLabel.Location = New System.Drawing.Point(8, 43)
        PlantNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        PlantNameLabel.Name = "PlantNameLabel"
        PlantNameLabel.Size = New System.Drawing.Size(84, 18)
        PlantNameLabel.TabIndex = 4
        PlantNameLabel.Text = "Plant Name:"
        '
        'PlantDescriptionLabel
        '
        PlantDescriptionLabel.AutoSize = True
        PlantDescriptionLabel.Font = New System.Drawing.Font("Calibri", 9.0!)
        PlantDescriptionLabel.Location = New System.Drawing.Point(8, 75)
        PlantDescriptionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        PlantDescriptionLabel.Name = "PlantDescriptionLabel"
        PlantDescriptionLabel.Size = New System.Drawing.Size(117, 18)
        PlantDescriptionLabel.TabIndex = 6
        PlantDescriptionLabel.Text = "Plant Description:"
        '
        'PlantIDTextBox
        '
        Me.PlantIDTextBox.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.PlantIDTextBox.Location = New System.Drawing.Point(153, 7)
        Me.PlantIDTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PlantIDTextBox.Name = "PlantIDTextBox"
        Me.PlantIDTextBox.ReadOnly = True
        Me.PlantIDTextBox.Size = New System.Drawing.Size(52, 30)
        Me.PlantIDTextBox.TabIndex = 3
        '
        'PlantNameTextBox
        '
        Me.PlantNameTextBox.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.PlantNameTextBox.Location = New System.Drawing.Point(153, 39)
        Me.PlantNameTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PlantNameTextBox.Name = "PlantNameTextBox"
        Me.PlantNameTextBox.ReadOnly = True
        Me.PlantNameTextBox.Size = New System.Drawing.Size(532, 26)
        Me.PlantNameTextBox.TabIndex = 5
        '
        'PlantDescriptionTextBox
        '
        Me.PlantDescriptionTextBox.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.PlantDescriptionTextBox.Location = New System.Drawing.Point(153, 71)
        Me.PlantDescriptionTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PlantDescriptionTextBox.Multiline = True
        Me.PlantDescriptionTextBox.Name = "PlantDescriptionTextBox"
        Me.PlantDescriptionTextBox.ReadOnly = True
        Me.PlantDescriptionTextBox.Size = New System.Drawing.Size(739, 62)
        Me.PlantDescriptionTextBox.TabIndex = 7
        '
        'lblTotalHAPS
        '
        Me.lblTotalHAPS.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblTotalHAPS.Location = New System.Drawing.Point(4, 41)
        Me.lblTotalHAPS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalHAPS.Name = "lblTotalHAPS"
        Me.lblTotalHAPS.Size = New System.Drawing.Size(888, 24)
        Me.lblTotalHAPS.TabIndex = 10
        Me.lblTotalHAPS.Text = "Total HAPS in tons"
        '
        'RptPlantEmissionsSummaryV2DataGridView
        '
        Me.RptPlantEmissionsSummaryV2DataGridView.AllowUserToAddRows = False
        Me.RptPlantEmissionsSummaryV2DataGridView.AllowUserToDeleteRows = False
        Me.RptPlantEmissionsSummaryV2DataGridView.AutoGenerateColumns = False
        Me.RptPlantEmissionsSummaryV2DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.RptPlantEmissionsSummaryV2DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RptPlantEmissionsSummaryV2DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.PollutantID})
        Me.RptPlantEmissionsSummaryV2DataGridView.DataSource = Me.RptPlantEmissionsSummaryV2BindingSource
        Me.RptPlantEmissionsSummaryV2DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RptPlantEmissionsSummaryV2DataGridView.Location = New System.Drawing.Point(0, 0)
        Me.RptPlantEmissionsSummaryV2DataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.RptPlantEmissionsSummaryV2DataGridView.MinimumSize = New System.Drawing.Size(370, 200)
        Me.RptPlantEmissionsSummaryV2DataGridView.Name = "RptPlantEmissionsSummaryV2DataGridView"
        Me.RptPlantEmissionsSummaryV2DataGridView.ReadOnly = True
        Me.RptPlantEmissionsSummaryV2DataGridView.RowHeadersVisible = False
        Me.RptPlantEmissionsSummaryV2DataGridView.Size = New System.Drawing.Size(370, 569)
        Me.RptPlantEmissionsSummaryV2DataGridView.TabIndex = 10
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "PollutantTypeEISID"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 69
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "PollutantName"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn15.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn15.HeaderText = "Pollutant"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 92
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
        Me.DataGridViewTextBoxColumn17.Width = 69
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
        'RptPlantEmissionsDataGridView
        '
        Me.RptPlantEmissionsDataGridView.AllowUserToAddRows = False
        Me.RptPlantEmissionsDataGridView.AllowUserToDeleteRows = False
        Me.RptPlantEmissionsDataGridView.AllowUserToResizeRows = False
        Me.RptPlantEmissionsDataGridView.AutoGenerateColumns = False
        Me.RptPlantEmissionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.RptPlantEmissionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RptPlantEmissionsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn10})
        Me.RptPlantEmissionsDataGridView.DataSource = Me.RptPlantEmissionsBindingSource
        Me.RptPlantEmissionsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RptPlantEmissionsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.RptPlantEmissionsDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.RptPlantEmissionsDataGridView.MinimumSize = New System.Drawing.Size(500, 200)
        Me.RptPlantEmissionsDataGridView.Name = "RptPlantEmissionsDataGridView"
        Me.RptPlantEmissionsDataGridView.ReadOnly = True
        Me.RptPlantEmissionsDataGridView.RowHeadersVisible = False
        Me.RptPlantEmissionsDataGridView.Size = New System.Drawing.Size(528, 569)
        Me.RptPlantEmissionsDataGridView.TabIndex = 9
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "EmissionUnitAPCDID"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn12.HeaderText = "Emission Unit"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 122
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "ProcessAPCDID"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn11.HeaderText = "Process"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 88
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "EmissionValue"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn9.HeaderText = "Emissions"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
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
        'RptPlantEmissionsBindingSource
        '
        Me.RptPlantEmissionsBindingSource.DataMember = "rptPlantEmissions"
        Me.RptPlantEmissionsBindingSource.DataSource = Me.EmissionsDataSet
        '
        'lblLoading
        '
        Me.lblLoading.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoading.Location = New System.Drawing.Point(240, 141)
        Me.lblLoading.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(167, 28)
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
        Me.btnViewEmissionsSummaryGrid.Location = New System.Drawing.Point(11, 141)
        Me.btnViewEmissionsSummaryGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewEmissionsSummaryGrid.Name = "btnViewEmissionsSummaryGrid"
        Me.btnViewEmissionsSummaryGrid.Size = New System.Drawing.Size(220, 28)
        Me.btnViewEmissionsSummaryGrid.TabIndex = 10
        Me.btnViewEmissionsSummaryGrid.Text = "View Emissions Summary Grid"
        Me.btnViewEmissionsSummaryGrid.UseVisualStyleBackColor = True
        '
        'ColumnSortLabel
        '
        Me.ColumnSortLabel.AutoSize = True
        Me.ColumnSortLabel.Location = New System.Drawing.Point(241, 13)
        Me.ColumnSortLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ColumnSortLabel.Name = "ColumnSortLabel"
        Me.ColumnSortLabel.Size = New System.Drawing.Size(603, 17)
        Me.ColumnSortLabel.TabIndex = 13
        Me.ColumnSortLabel.Text = "CAP emissions are in tons, HAPs in pounds. You can click on a heading to sort by " & _
    "that column."
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(PlantIDLabel)
        Me.MainPanel.Controls.Add(Me.PlantDescriptionTextBox)
        Me.MainPanel.Controls.Add(Me.lblLoading)
        Me.MainPanel.Controls.Add(PlantDescriptionLabel)
        Me.MainPanel.Controls.Add(Me.btnViewEmissionsSummaryGrid)
        Me.MainPanel.Controls.Add(Me.PlantNameTextBox)
        Me.MainPanel.Controls.Add(PlantNameLabel)
        Me.MainPanel.Controls.Add(Me.PlantIDTextBox)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(896, 177)
        Me.MainPanel.TabIndex = 14
        '
        'SummarySplitContainer
        '
        Me.SummarySplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SummarySplitContainer.Location = New System.Drawing.Point(0, 245)
        Me.SummarySplitContainer.Name = "SummarySplitContainer"
        '
        'SummarySplitContainer.Panel1
        '
        Me.SummarySplitContainer.Panel1.Controls.Add(Me.RptPlantEmissionsSummaryV2DataGridView)
        '
        'SummarySplitContainer.Panel2
        '
        Me.SummarySplitContainer.Panel2.Controls.Add(Me.RptPlantEmissionsDataGridView)
        Me.SummarySplitContainer.Size = New System.Drawing.Size(896, 569)
        Me.SummarySplitContainer.SplitterDistance = 364
        Me.SummarySplitContainer.TabIndex = 11
        '
        'SummaryHeaderPanel
        '
        Me.SummaryHeaderPanel.Controls.Add(Me.lblTotalHAPS)
        Me.SummaryHeaderPanel.Controls.Add(Me.ColumnSortLabel)
        Me.SummaryHeaderPanel.Controls.Add(Me.SummaryTitleLabel)
        Me.SummaryHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.SummaryHeaderPanel.Location = New System.Drawing.Point(0, 177)
        Me.SummaryHeaderPanel.Name = "SummaryHeaderPanel"
        Me.SummaryHeaderPanel.Size = New System.Drawing.Size(896, 70)
        Me.SummaryHeaderPanel.TabIndex = 15
        '
        'SummaryTitleLabel
        '
        Me.SummaryTitleLabel.AutoSize = True
        Me.SummaryTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SummaryTitleLabel.Location = New System.Drawing.Point(4, 10)
        Me.SummaryTitleLabel.Name = "SummaryTitleLabel"
        Me.SummaryTitleLabel.Size = New System.Drawing.Size(180, 20)
        Me.SummaryTitleLabel.TabIndex = 0
        Me.SummaryTitleLabel.Text = "Emissions Summary"
        '
        'PlantUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SummarySplitContainer)
        Me.Controls.Add(Me.SummaryHeaderPanel)
        Me.Controls.Add(Me.MainPanel)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PlantUserControl"
        Me.Size = New System.Drawing.Size(896, 839)
        CType(Me.RptPlantEmissionsSummaryV2DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RptPlantEmissionsSummaryV2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RptPlantEmissionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RptPlantEmissionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.SummarySplitContainer.Panel1.ResumeLayout(False)
        Me.SummarySplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SummarySplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SummarySplitContainer.ResumeLayout(False)
        Me.SummaryHeaderPanel.ResumeLayout(False)
        Me.SummaryHeaderPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlantIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PlantNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PlantDescriptionTextBox As System.Windows.Forms.TextBox
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
    Friend WithEvents ColumnSortLabel As System.Windows.Forms.Label
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents SummarySplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents SummaryHeaderPanel As System.Windows.Forms.Panel
    Friend WithEvents SummaryTitleLabel As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PollutantID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
