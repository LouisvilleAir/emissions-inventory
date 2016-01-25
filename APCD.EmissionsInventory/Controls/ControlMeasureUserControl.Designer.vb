<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlMeasureUserControl
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
        Dim APCDIDLabel As System.Windows.Forms.Label
        Dim ControlMeasureIDLabel As System.Windows.Forms.Label
        Dim CommentPublicLabel As System.Windows.Forms.Label
        Dim CommentInternalLabel As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ControlMeasureAPCDIDTextBox = New System.Windows.Forms.TextBox()
        Me.CompanyCommentTextBox = New System.Windows.Forms.TextBox()
        Me.APCDCommentTextBox = New System.Windows.Forms.TextBox()
        Me.PollutantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShutdownMessageLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ControlMeasureTypeIDComboBox = New System.Windows.Forms.ComboBox()
        Me.ControlMeasureTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTypeTableAdapter()
        Me.PollutantTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PollutantTableAdapter()
        Me.ControlMeasureDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.IsExcludedCheckBox = New System.Windows.Forms.CheckBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ProcessGroupBox = New System.Windows.Forms.GroupBox()
        Me.ControlMeasure_GetProcessesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControlMeasure_GetProcessesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessYearTableAdapter()
        Me.ControlMeasurePollutantDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonPanel = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnShutdown = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.PollutantComboBox = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.reductionEfficiencyTextBox = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.AddPollutantPanel = New System.Windows.Forms.Panel()
        Me.ReductionEfficiencyLabel = New System.Windows.Forms.Label()
        Me.PollutantLabel = New System.Windows.Forms.Label()
        Me.ControlMeasure_GetProcessesTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasure_GetProcessesTableAdapter()
        Me.ControlMeasurePollutantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        APCDIDLabel = New System.Windows.Forms.Label()
        ControlMeasureIDLabel = New System.Windows.Forms.Label()
        CommentPublicLabel = New System.Windows.Forms.Label()
        CommentInternalLabel = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PollutantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProcessGroupBox.SuspendLayout()
        CType(Me.ControlMeasure_GetProcessesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasure_GetProcessesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasurePollutantDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ButtonPanel.SuspendLayout()
        Me.AddPollutantPanel.SuspendLayout()
        CType(Me.ControlMeasurePollutantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'APCDIDLabel
        '
        APCDIDLabel.AutoSize = True
        APCDIDLabel.Location = New System.Drawing.Point(7, 81)
        APCDIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        APCDIDLabel.Name = "APCDIDLabel"
        APCDIDLabel.Size = New System.Drawing.Size(75, 17)
        APCDIDLabel.TabIndex = 82
        APCDIDLabel.Text = "* APCD ID:"
        '
        'ControlMeasureIDLabel
        '
        ControlMeasureIDLabel.AutoSize = True
        ControlMeasureIDLabel.Location = New System.Drawing.Point(7, 112)
        ControlMeasureIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ControlMeasureIDLabel.Name = "ControlMeasureIDLabel"
        ControlMeasureIDLabel.Size = New System.Drawing.Size(53, 17)
        ControlMeasureIDLabel.TabIndex = 83
        ControlMeasureIDLabel.Text = "* Type:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.Location = New System.Drawing.Point(7, 199)
        CommentPublicLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(115, 38)
        CommentPublicLabel.TabIndex = 84
        CommentPublicLabel.Text = "Company Comment:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.Location = New System.Drawing.Point(7, 268)
        CommentInternalLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(105, 42)
        CommentInternalLabel.TabIndex = 85
        CommentInternalLabel.Text = "APCD Comment:"
        '
        'Label6
        '
        Label6.Location = New System.Drawing.Point(7, 146)
        Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(84, 43)
        Label6.TabIndex = 95
        Label6.Text = "Company Description:"
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AffiliationTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BillingContactsTableAdapter = Nothing
        Me.TableAdapterManager.BillingFeeConfigTableAdapter = Nothing
        Me.TableAdapterManager.BillingHistoryTableAdapter = Nothing
        Me.TableAdapterManager.BillingTableAdapter = Nothing
        Me.TableAdapterManager.Connection = Nothing
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
        'ControlMeasureAPCDIDTextBox
        '
        Me.ControlMeasureAPCDIDTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ControlMeasureAPCDIDTextBox.Location = New System.Drawing.Point(131, 77)
        Me.ControlMeasureAPCDIDTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ControlMeasureAPCDIDTextBox.MaxLength = 50
        Me.ControlMeasureAPCDIDTextBox.Name = "ControlMeasureAPCDIDTextBox"
        Me.ControlMeasureAPCDIDTextBox.Size = New System.Drawing.Size(432, 26)
        Me.ControlMeasureAPCDIDTextBox.TabIndex = 11
        '
        'CompanyCommentTextBox
        '
        Me.CompanyCommentTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyCommentTextBox.Location = New System.Drawing.Point(131, 199)
        Me.CompanyCommentTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.CompanyCommentTextBox.MaxLength = 400
        Me.CompanyCommentTextBox.Multiline = True
        Me.CompanyCommentTextBox.Name = "CompanyCommentTextBox"
        Me.CompanyCommentTextBox.Size = New System.Drawing.Size(747, 61)
        Me.CompanyCommentTextBox.TabIndex = 14
        '
        'APCDCommentTextBox
        '
        Me.APCDCommentTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.APCDCommentTextBox.Location = New System.Drawing.Point(131, 268)
        Me.APCDCommentTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.APCDCommentTextBox.MaxLength = 400
        Me.APCDCommentTextBox.Multiline = True
        Me.APCDCommentTextBox.Name = "APCDCommentTextBox"
        Me.APCDCommentTextBox.Size = New System.Drawing.Size(747, 61)
        Me.APCDCommentTextBox.TabIndex = 15
        '
        'PollutantBindingSource
        '
        Me.PollutantBindingSource.DataMember = "Pollutant"
        Me.PollutantBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ShutdownMessageLabel
        '
        Me.ShutdownMessageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShutdownMessageLabel.ForeColor = System.Drawing.Color.Red
        Me.ShutdownMessageLabel.Location = New System.Drawing.Point(126, 7)
        Me.ShutdownMessageLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ShutdownMessageLabel.Name = "ShutdownMessageLabel"
        Me.ShutdownMessageLabel.Size = New System.Drawing.Size(301, 23)
        Me.ShutdownMessageLabel.TabIndex = 2
        Me.ShutdownMessageLabel.Text = "ShutdownMessageLabel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 17)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "* Required field"
        '
        'ControlMeasureTypeIDComboBox
        '
        Me.ControlMeasureTypeIDComboBox.DataSource = Me.ControlMeasureTypeBindingSource
        Me.ControlMeasureTypeIDComboBox.DisplayMember = "ControlMeasureTypeName"
        Me.ControlMeasureTypeIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ControlMeasureTypeIDComboBox.Enabled = False
        Me.ControlMeasureTypeIDComboBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ControlMeasureTypeIDComboBox.FormattingEnabled = True
        Me.ControlMeasureTypeIDComboBox.Location = New System.Drawing.Point(131, 112)
        Me.ControlMeasureTypeIDComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ControlMeasureTypeIDComboBox.Name = "ControlMeasureTypeIDComboBox"
        Me.ControlMeasureTypeIDComboBox.Size = New System.Drawing.Size(265, 26)
        Me.ControlMeasureTypeIDComboBox.TabIndex = 12
        Me.ControlMeasureTypeIDComboBox.ValueMember = "ControlMeasureTypeID"
        '
        'ControlMeasureTypeBindingSource
        '
        Me.ControlMeasureTypeBindingSource.DataMember = "ControlMeasureType"
        Me.ControlMeasureTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasureTypeTableAdapter
        '
        Me.ControlMeasureTypeTableAdapter.ClearBeforeFill = True
        '
        'PollutantTableAdapter
        '
        Me.PollutantTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasureDescriptionTextBox
        '
        Me.ControlMeasureDescriptionTextBox.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.ControlMeasureDescriptionTextBox.Location = New System.Drawing.Point(131, 146)
        Me.ControlMeasureDescriptionTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ControlMeasureDescriptionTextBox.MaxLength = 100
        Me.ControlMeasureDescriptionTextBox.Multiline = True
        Me.ControlMeasureDescriptionTextBox.Name = "ControlMeasureDescriptionTextBox"
        Me.ControlMeasureDescriptionTextBox.Size = New System.Drawing.Size(747, 42)
        Me.ControlMeasureDescriptionTextBox.TabIndex = 13
        '
        'IsExcludedCheckBox
        '
        Me.IsExcludedCheckBox.Location = New System.Drawing.Point(494, 8)
        Me.IsExcludedCheckBox.Margin = New System.Windows.Forms.Padding(4)
        Me.IsExcludedCheckBox.Name = "IsExcludedCheckBox"
        Me.IsExcludedCheckBox.Size = New System.Drawing.Size(191, 22)
        Me.IsExcludedCheckBox.TabIndex = 4
        Me.IsExcludedCheckBox.Text = "Exclude from inventory"
        Me.IsExcludedCheckBox.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ProcessGroupBox
        '
        Me.ProcessGroupBox.Controls.Add(Me.ControlMeasure_GetProcessesDataGridView)
        Me.ProcessGroupBox.Location = New System.Drawing.Point(463, 378)
        Me.ProcessGroupBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ProcessGroupBox.Name = "ProcessGroupBox"
        Me.ProcessGroupBox.Padding = New System.Windows.Forms.Padding(4)
        Me.ProcessGroupBox.Size = New System.Drawing.Size(429, 348)
        Me.ProcessGroupBox.TabIndex = 103
        Me.ProcessGroupBox.TabStop = False
        Me.ProcessGroupBox.Text = "Processes for this control measure:"
        '
        'ControlMeasure_GetProcessesDataGridView
        '
        Me.ControlMeasure_GetProcessesDataGridView.AllowUserToAddRows = False
        Me.ControlMeasure_GetProcessesDataGridView.AllowUserToDeleteRows = False
        Me.ControlMeasure_GetProcessesDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ControlMeasure_GetProcessesDataGridView.AutoGenerateColumns = False
        Me.ControlMeasure_GetProcessesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ControlMeasure_GetProcessesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ControlMeasure_GetProcessesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn15})
        Me.ControlMeasure_GetProcessesDataGridView.DataSource = Me.ControlMeasure_GetProcessesBindingSource
        Me.ControlMeasure_GetProcessesDataGridView.Location = New System.Drawing.Point(8, 23)
        Me.ControlMeasure_GetProcessesDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.ControlMeasure_GetProcessesDataGridView.Name = "ControlMeasure_GetProcessesDataGridView"
        Me.ControlMeasure_GetProcessesDataGridView.ReadOnly = True
        Me.ControlMeasure_GetProcessesDataGridView.RowHeadersVisible = False
        Me.ControlMeasure_GetProcessesDataGridView.Size = New System.Drawing.Size(413, 317)
        Me.ControlMeasure_GetProcessesDataGridView.TabIndex = 40
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "EmissionUnitAPCDID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "EU"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 52
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ProcessAPCDID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Process"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 84
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "PlantEmissionUnitID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "PlantEmissionUnitID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 159
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ProcessID"
        Me.DataGridViewTextBoxColumn3.HeaderText = "ProcessID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 97
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "EmissionYear"
        Me.DataGridViewTextBoxColumn5.HeaderText = "EmissionYear"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 119
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "ControlMeasureID"
        Me.DataGridViewTextBoxColumn15.HeaderText = "ControlMeasureID"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 146
        '
        'ControlMeasure_GetProcessesBindingSource
        '
        Me.ControlMeasure_GetProcessesBindingSource.DataMember = "ControlMeasure_GetProcesses"
        Me.ControlMeasure_GetProcessesBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessYearBindingSource
        '
        Me.ProcessYearBindingSource.DataMember = "ProcessYear"
        Me.ProcessYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessYearTableAdapter
        '
        Me.ProcessYearTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasurePollutantDataGridView
        '
        Me.ControlMeasurePollutantDataGridView.AllowUserToAddRows = False
        Me.ControlMeasurePollutantDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ControlMeasurePollutantDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ControlMeasurePollutantDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ControlMeasurePollutantDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11})
        Me.ControlMeasurePollutantDataGridView.Location = New System.Drawing.Point(5, 401)
        Me.ControlMeasurePollutantDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.ControlMeasurePollutantDataGridView.Name = "ControlMeasurePollutantDataGridView"
        Me.ControlMeasurePollutantDataGridView.Size = New System.Drawing.Size(450, 461)
        Me.ControlMeasurePollutantDataGridView.TabIndex = 30
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "PollutantID"
        Me.DataGridViewTextBoxColumn9.DataSource = Me.PollutantBindingSource
        Me.DataGridViewTextBoxColumn9.DisplayMember = "PollutantName"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Pollutant"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn9.ValueMember = "PollutantID"
        Me.DataGridViewTextBoxColumn9.Width = 88
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "ReductionEfficiency"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Reduction Efficiency (%)"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 150
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ControlMeasurePollutantID"
        Me.DataGridViewTextBoxColumn7.HeaderText = "ControlMeasurePollutantID"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "ControlMeasureID"
        Me.DataGridViewTextBoxColumn8.HeaderText = "ControlMeasureID"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "AddDate"
        Me.DataGridViewTextBoxColumn10.HeaderText = "AddDate"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "AddedBy"
        Me.DataGridViewTextBoxColumn11.HeaderText = "AddedBy"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'ButtonPanel
        '
        Me.ButtonPanel.Controls.Add(Me.btnSave)
        Me.ButtonPanel.Controls.Add(Me.btnShutdown)
        Me.ButtonPanel.Controls.Add(Me.btnCancel)
        Me.ButtonPanel.Controls.Add(Me.btnApprove)
        Me.ButtonPanel.Controls.Add(Me.IsExcludedCheckBox)
        Me.ButtonPanel.Controls.Add(Me.ShutdownMessageLabel)
        Me.ButtonPanel.Location = New System.Drawing.Point(0, 0)
        Me.ButtonPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(877, 37)
        Me.ButtonPanel.TabIndex = 105
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(693, 4)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 28)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnShutdown
        '
        Me.btnShutdown.Location = New System.Drawing.Point(369, 4)
        Me.btnShutdown.Margin = New System.Windows.Forms.Padding(4)
        Me.btnShutdown.Name = "btnShutdown"
        Me.btnShutdown.Size = New System.Drawing.Size(117, 28)
        Me.btnShutdown.TabIndex = 3
        Me.btnShutdown.Text = "Shut down"
        Me.btnShutdown.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(776, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 28)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(4, 4)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(117, 28)
        Me.btnApprove.TabIndex = 1
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'PollutantComboBox
        '
        Me.PollutantComboBox.DisplayMember = "PollutantID"
        Me.PollutantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PollutantComboBox.FormattingEnabled = True
        Me.PollutantComboBox.Location = New System.Drawing.Point(8, 30)
        Me.PollutantComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PollutantComboBox.Name = "PollutantComboBox"
        Me.PollutantComboBox.Size = New System.Drawing.Size(308, 24)
        Me.PollutantComboBox.TabIndex = 21
        Me.ToolTip1.SetToolTip(Me.PollutantComboBox, "Choose a pollutant")
        Me.PollutantComboBox.ValueMember = "PollutantID"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(391, 28)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(59, 28)
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.btnAdd, "Add the pollutant to this control measure")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'reductionEfficiencyTextBox
        '
        Me.reductionEfficiencyTextBox.Location = New System.Drawing.Point(325, 30)
        Me.reductionEfficiencyTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.reductionEfficiencyTextBox.MaxLength = 6
        Me.reductionEfficiencyTextBox.Name = "reductionEfficiencyTextBox"
        Me.reductionEfficiencyTextBox.Size = New System.Drawing.Size(56, 22)
        Me.reductionEfficiencyTextBox.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.reductionEfficiencyTextBox, "Enter a reduction efficience (.001 to 100)")
        '
        'AddPollutantPanel
        '
        Me.AddPollutantPanel.Controls.Add(Me.ReductionEfficiencyLabel)
        Me.AddPollutantPanel.Controls.Add(Me.PollutantLabel)
        Me.AddPollutantPanel.Controls.Add(Me.PollutantComboBox)
        Me.AddPollutantPanel.Controls.Add(Me.btnAdd)
        Me.AddPollutantPanel.Controls.Add(Me.reductionEfficiencyTextBox)
        Me.AddPollutantPanel.Location = New System.Drawing.Point(5, 337)
        Me.AddPollutantPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.AddPollutantPanel.Name = "AddPollutantPanel"
        Me.AddPollutantPanel.Size = New System.Drawing.Size(460, 64)
        Me.AddPollutantPanel.TabIndex = 109
        '
        'ReductionEfficiencyLabel
        '
        Me.ReductionEfficiencyLabel.AutoSize = True
        Me.ReductionEfficiencyLabel.Location = New System.Drawing.Point(321, 9)
        Me.ReductionEfficiencyLabel.Name = "ReductionEfficiencyLabel"
        Me.ReductionEfficiencyLabel.Size = New System.Drawing.Size(53, 17)
        Me.ReductionEfficiencyLabel.TabIndex = 110
        Me.ReductionEfficiencyLabel.Text = "RE (%)"
        '
        'PollutantLabel
        '
        Me.PollutantLabel.AutoSize = True
        Me.PollutantLabel.Location = New System.Drawing.Point(5, 9)
        Me.PollutantLabel.Name = "PollutantLabel"
        Me.PollutantLabel.Size = New System.Drawing.Size(63, 17)
        Me.PollutantLabel.TabIndex = 109
        Me.PollutantLabel.Text = "Pollutant"
        '
        'ControlMeasure_GetProcessesTableAdapter
        '
        Me.ControlMeasure_GetProcessesTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasurePollutantBindingSource
        '
        Me.ControlMeasurePollutantBindingSource.DataMember = "ControlMeasurePollutant"
        Me.ControlMeasurePollutantBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasureUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AddPollutantPanel)
        Me.Controls.Add(Me.ButtonPanel)
        Me.Controls.Add(Me.ControlMeasurePollutantDataGridView)
        Me.Controls.Add(Me.ProcessGroupBox)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Me.ControlMeasureDescriptionTextBox)
        Me.Controls.Add(Me.ControlMeasureTypeIDComboBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(APCDIDLabel)
        Me.Controls.Add(ControlMeasureIDLabel)
        Me.Controls.Add(CommentPublicLabel)
        Me.Controls.Add(CommentInternalLabel)
        Me.Controls.Add(Me.ControlMeasureAPCDIDTextBox)
        Me.Controls.Add(Me.CompanyCommentTextBox)
        Me.Controls.Add(Me.APCDCommentTextBox)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ControlMeasureUserControl"
        Me.Size = New System.Drawing.Size(896, 862)
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PollutantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProcessGroupBox.ResumeLayout(False)
        CType(Me.ControlMeasure_GetProcessesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasure_GetProcessesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasurePollutantDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ButtonPanel.ResumeLayout(False)
        Me.AddPollutantPanel.ResumeLayout(False)
        Me.AddPollutantPanel.PerformLayout()
        CType(Me.ControlMeasurePollutantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ControlMeasureAPCDIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompanyCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents APCDCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShutdownMessageLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ControlMeasureTypeIDComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ControlMeasureTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTypeTableAdapter
    Friend WithEvents PollutantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PollutantTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PollutantTableAdapter
    Friend WithEvents ControlMeasureDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IsExcludedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ControlPercentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentPublicColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentInternalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ProcessYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessYearTableAdapter
    Friend WithEvents ButtonPanel As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnShutdown As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents ControlMeasurePollutantDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents PollutantComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents reductionEfficiencyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddPollutantPanel As System.Windows.Forms.Panel
    Friend WithEvents ControlMeasure_GetProcessesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasure_GetProcessesTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasure_GetProcessesTableAdapter
    Friend WithEvents ControlMeasure_GetProcessesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ControlMeasurePollutantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReductionEfficiencyLabel As System.Windows.Forms.Label
    Friend WithEvents PollutantLabel As System.Windows.Forms.Label

End Class
