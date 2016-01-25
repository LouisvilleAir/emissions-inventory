<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessUserControl
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
        Dim ProcessDescriptionLabel As System.Windows.Forms.Label
        Dim ProcessAPCDIDLabel As System.Windows.Forms.Label
        Dim ThroughputTypeIDLabel As System.Windows.Forms.Label
        Dim CommentPublicLabel As System.Windows.Forms.Label
        Dim CommentInternalLabel As System.Windows.Forms.Label
        Dim ControlApproachDescriptionLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.GeneralTabPage = New System.Windows.Forms.TabPage()
        Me.ControlApproachDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSCCNumber = New System.Windows.Forms.Label()
        Me.lblSCCName = New System.Windows.Forms.Label()
        Me.btnChangeProcessClass = New System.Windows.Forms.Button()
        Me.ThroughputTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ProcessDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ProcessAPCDIDTextBox = New System.Windows.Forms.TextBox()
        Me.CommentPublicTextBox = New System.Windows.Forms.TextBox()
        Me.CommentInternalTextBox = New System.Windows.Forms.TextBox()
        Me.ReleasePointsTabPage = New System.Windows.Forms.TabPage()
        Me.Process_ReleasePointTabDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process_ReleasePointTabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.lblReleasePointPercentTotal = New System.Windows.Forms.Label()
        Me.btnAddReleasePoint = New System.Windows.Forms.Button()
        Me.ControlMeasuresTabPage = New System.Windows.Forms.TabPage()
        Me.Process_ControlMeasureTabDataGridView = New System.Windows.Forms.DataGridView()
        Me.ControlMeasureAPCDID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessControlMeasureID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process_ControlMeasureTabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnAddControlMeasure = New System.Windows.Forms.Button()
        Me.ThroughputTabPage = New System.Windows.Forms.TabPage()
        Me.Process_ThroughputTabDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Process_ThroughputTabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnLoadThroughputDefaults = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoadSeasonalDefaults = New System.Windows.Forms.Button()
        Me.lblSeasonalTotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FallTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SummerTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SpringTextBox = New System.Windows.Forms.TextBox()
        Me.WinterTextBox = New System.Windows.Forms.TextBox()
        Me.btnAddThroughput = New System.Windows.Forms.Button()
        Me.EmissionsTabPage = New System.Windows.Forms.TabPage()
        Me.TonsCheckBox = New System.Windows.Forms.CheckBox()
        Me.OzoneSeasonCheckBox = New System.Windows.Forms.CheckBox()
        Me.btnRecalculateFromThroughput = New System.Windows.Forms.Button()
        Me.Process_EmissionsTabDataGridView = New System.Windows.Forms.DataGridView()
        Me.Process_EmissionsTabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnCopyToProcess = New System.Windows.Forms.Button()
        Me.btnAddEmissions = New System.Windows.Forms.Button()
        Me.PollutantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessDataSet = New APCD.EmissionsInventory.ProcessDataSet()
        Me.EmissionPeriodTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UnitOfMeasurement_ProcessEmissionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IsExcludedCheckBox = New System.Windows.Forms.CheckBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ProcessDataSetTableAdapterManager = New APCD.EmissionsInventory.ProcessDataSetTableAdapters.TableAdapterManager()
        Me.PollutantTableAdapter = New APCD.EmissionsInventory.ProcessDataSetTableAdapters.PollutantTableAdapter()
        Me.UnitOfMeasurement_ProcessEmissionTableAdapter = New APCD.EmissionsInventory.ProcessDataSetTableAdapters.UnitOfMeasurement_ProcessEmissionTableAdapter()
        Me.EmissionPeriodTypeTableAdapter = New APCD.EmissionsInventory.ProcessDataSetTableAdapters.EmissionPeriodTypeTableAdapter()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnShutdown = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ButtonPanel = New System.Windows.Forms.Panel()
        Me.ShutdownMessageLabel = New System.Windows.Forms.Label()
        Me.ProcessTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ControlMeasureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTableAdapter()
        Me.Process_ControlMeasureTabTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ControlMeasureTabTableAdapter()
        Me.Process_ReleasePointTabTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ReleasePointTabTableAdapter()
        Me.Process_EmissionsTabTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_EmissionsTabTableAdapter()
        Me.Process_ThroughputTabTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ThroughputTabTableAdapter()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PollutantName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmissionPeriodTypeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmissionValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitOfMeasurementName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessEmissionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmissionCalculationMethodName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmissionFactorValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EFUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        ProcessDescriptionLabel = New System.Windows.Forms.Label()
        ProcessAPCDIDLabel = New System.Windows.Forms.Label()
        ThroughputTypeIDLabel = New System.Windows.Forms.Label()
        CommentPublicLabel = New System.Windows.Forms.Label()
        CommentInternalLabel = New System.Windows.Forms.Label()
        ControlApproachDescriptionLabel = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.GeneralTabPage.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ReleasePointsTabPage.SuspendLayout()
        CType(Me.Process_ReleasePointTabDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Process_ReleasePointTabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlMeasuresTabPage.SuspendLayout()
        CType(Me.Process_ControlMeasureTabDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Process_ControlMeasureTabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ThroughputTabPage.SuspendLayout()
        CType(Me.Process_ThroughputTabDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Process_ThroughputTabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.EmissionsTabPage.SuspendLayout()
        CType(Me.Process_EmissionsTabDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Process_EmissionsTabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PollutantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionPeriodTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnitOfMeasurement_ProcessEmissionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ButtonPanel.SuspendLayout()
        CType(Me.ControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProcessDescriptionLabel
        '
        ProcessDescriptionLabel.AutoSize = True
        ProcessDescriptionLabel.Location = New System.Drawing.Point(4, 144)
        ProcessDescriptionLabel.Name = "ProcessDescriptionLabel"
        ProcessDescriptionLabel.Size = New System.Drawing.Size(82, 18)
        ProcessDescriptionLabel.TabIndex = 4
        ProcessDescriptionLabel.Text = "Description:"
        '
        'ProcessAPCDIDLabel
        '
        ProcessAPCDIDLabel.AutoSize = True
        ProcessAPCDIDLabel.Location = New System.Drawing.Point(6, 119)
        ProcessAPCDIDLabel.Name = "ProcessAPCDIDLabel"
        ProcessAPCDIDLabel.Size = New System.Drawing.Size(69, 18)
        ProcessAPCDIDLabel.TabIndex = 10
        ProcessAPCDIDLabel.Text = "*APCD ID:"
        '
        'ThroughputTypeIDLabel
        '
        ThroughputTypeIDLabel.AutoSize = True
        ThroughputTypeIDLabel.Location = New System.Drawing.Point(6, 86)
        ThroughputTypeIDLabel.Name = "ThroughputTypeIDLabel"
        ThroughputTypeIDLabel.Size = New System.Drawing.Size(126, 18)
        ThroughputTypeIDLabel.TabIndex = 14
        ThroughputTypeIDLabel.Text = "* Throughput Type:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.Location = New System.Drawing.Point(8, 200)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(122, 50)
        CommentPublicLabel.TabIndex = 20
        CommentPublicLabel.Text = "APCD Public Comment:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.Location = New System.Drawing.Point(6, 256)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(122, 50)
        CommentInternalLabel.TabIndex = 22
        CommentInternalLabel.Text = "APCD Confidential Comment:"
        '
        'ControlApproachDescriptionLabel
        '
        ControlApproachDescriptionLabel.Location = New System.Drawing.Point(6, 316)
        ControlApproachDescriptionLabel.Name = "ControlApproachDescriptionLabel"
        ControlApproachDescriptionLabel.Size = New System.Drawing.Size(121, 61)
        ControlApproachDescriptionLabel.TabIndex = 46
        ControlApproachDescriptionLabel.Text = "Overall control approach description:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(749, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 18)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "* Required field"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.GeneralTabPage)
        Me.TabControl1.Controls.Add(Me.ReleasePointsTabPage)
        Me.TabControl1.Controls.Add(Me.ControlMeasuresTabPage)
        Me.TabControl1.Controls.Add(Me.ThroughputTabPage)
        Me.TabControl1.Controls.Add(Me.EmissionsTabPage)
        Me.TabControl1.Location = New System.Drawing.Point(0, 30)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(896, 764)
        Me.TabControl1.TabIndex = 0
        '
        'GeneralTabPage
        '
        Me.GeneralTabPage.BackColor = System.Drawing.SystemColors.Control
        Me.GeneralTabPage.Controls.Add(ControlApproachDescriptionLabel)
        Me.GeneralTabPage.Controls.Add(Me.ControlApproachDescriptionTextBox)
        Me.GeneralTabPage.Controls.Add(Me.GroupBox1)
        Me.GeneralTabPage.Controls.Add(Me.Label3)
        Me.GeneralTabPage.Controls.Add(Me.ThroughputTypeComboBox)
        Me.GeneralTabPage.Controls.Add(ProcessDescriptionLabel)
        Me.GeneralTabPage.Controls.Add(Me.ProcessDescriptionTextBox)
        Me.GeneralTabPage.Controls.Add(ProcessAPCDIDLabel)
        Me.GeneralTabPage.Controls.Add(Me.ProcessAPCDIDTextBox)
        Me.GeneralTabPage.Controls.Add(ThroughputTypeIDLabel)
        Me.GeneralTabPage.Controls.Add(CommentPublicLabel)
        Me.GeneralTabPage.Controls.Add(Me.CommentPublicTextBox)
        Me.GeneralTabPage.Controls.Add(CommentInternalLabel)
        Me.GeneralTabPage.Controls.Add(Me.CommentInternalTextBox)
        Me.GeneralTabPage.Location = New System.Drawing.Point(4, 27)
        Me.GeneralTabPage.Name = "GeneralTabPage"
        Me.GeneralTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTabPage.Size = New System.Drawing.Size(932, 733)
        Me.GeneralTabPage.TabIndex = 0
        Me.GeneralTabPage.Text = "General"
        '
        'ControlApproachDescriptionTextBox
        '
        Me.ControlApproachDescriptionTextBox.Location = New System.Drawing.Point(134, 316)
        Me.ControlApproachDescriptionTextBox.MaxLength = 255
        Me.ControlApproachDescriptionTextBox.Multiline = True
        Me.ControlApproachDescriptionTextBox.Name = "ControlApproachDescriptionTextBox"
        Me.ControlApproachDescriptionTextBox.Size = New System.Drawing.Size(721, 50)
        Me.ControlApproachDescriptionTextBox.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSCCNumber)
        Me.GroupBox1.Controls.Add(Me.lblSCCName)
        Me.GroupBox1.Controls.Add(Me.btnChangeProcessClass)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(663, 66)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "* SCC Code"
        '
        'lblSCCNumber
        '
        Me.lblSCCNumber.AutoSize = True
        Me.lblSCCNumber.Location = New System.Drawing.Point(120, 23)
        Me.lblSCCNumber.Name = "lblSCCNumber"
        Me.lblSCCNumber.Size = New System.Drawing.Size(98, 18)
        Me.lblSCCNumber.TabIndex = 38
        Me.lblSCCNumber.Text = "lblSCCNumber"
        '
        'lblSCCName
        '
        Me.lblSCCName.AutoSize = True
        Me.lblSCCName.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lblSCCName.Location = New System.Drawing.Point(120, 42)
        Me.lblSCCName.MaximumSize = New System.Drawing.Size(400, 14)
        Me.lblSCCName.Name = "lblSCCName"
        Me.lblSCCName.Size = New System.Drawing.Size(84, 14)
        Me.lblSCCName.TabIndex = 43
        Me.lblSCCName.Text = "lblSCCName"
        '
        'btnChangeProcessClass
        '
        Me.btnChangeProcessClass.Location = New System.Drawing.Point(12, 21)
        Me.btnChangeProcessClass.Name = "btnChangeProcessClass"
        Me.btnChangeProcessClass.Size = New System.Drawing.Size(63, 35)
        Me.btnChangeProcessClass.TabIndex = 0
        Me.btnChangeProcessClass.Text = "Change"
        Me.btnChangeProcessClass.UseVisualStyleBackColor = True
        '
        'ThroughputTypeComboBox
        '
        Me.ThroughputTypeComboBox.DisplayMember = "ThroughputTypeID"
        Me.ThroughputTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ThroughputTypeComboBox.FormattingEnabled = True
        Me.ThroughputTypeComboBox.Location = New System.Drawing.Point(134, 83)
        Me.ThroughputTypeComboBox.Name = "ThroughputTypeComboBox"
        Me.ThroughputTypeComboBox.Size = New System.Drawing.Size(200, 26)
        Me.ThroughputTypeComboBox.TabIndex = 1
        Me.ThroughputTypeComboBox.ValueMember = "ThroughputTypeID"
        '
        'ProcessDescriptionTextBox
        '
        Me.ProcessDescriptionTextBox.Location = New System.Drawing.Point(134, 144)
        Me.ProcessDescriptionTextBox.MaxLength = 200
        Me.ProcessDescriptionTextBox.Multiline = True
        Me.ProcessDescriptionTextBox.Name = "ProcessDescriptionTextBox"
        Me.ProcessDescriptionTextBox.Size = New System.Drawing.Size(721, 35)
        Me.ProcessDescriptionTextBox.TabIndex = 3
        '
        'ProcessAPCDIDTextBox
        '
        Me.ProcessAPCDIDTextBox.Location = New System.Drawing.Point(134, 116)
        Me.ProcessAPCDIDTextBox.MaxLength = 50
        Me.ProcessAPCDIDTextBox.Name = "ProcessAPCDIDTextBox"
        Me.ProcessAPCDIDTextBox.Size = New System.Drawing.Size(325, 26)
        Me.ProcessAPCDIDTextBox.TabIndex = 2
        '
        'CommentPublicTextBox
        '
        Me.CommentPublicTextBox.Location = New System.Drawing.Point(134, 200)
        Me.CommentPublicTextBox.MaxLength = 255
        Me.CommentPublicTextBox.Multiline = True
        Me.CommentPublicTextBox.Name = "CommentPublicTextBox"
        Me.CommentPublicTextBox.Size = New System.Drawing.Size(721, 50)
        Me.CommentPublicTextBox.TabIndex = 4
        '
        'CommentInternalTextBox
        '
        Me.CommentInternalTextBox.Location = New System.Drawing.Point(134, 256)
        Me.CommentInternalTextBox.MaxLength = 255
        Me.CommentInternalTextBox.Multiline = True
        Me.CommentInternalTextBox.Name = "CommentInternalTextBox"
        Me.CommentInternalTextBox.Size = New System.Drawing.Size(721, 50)
        Me.CommentInternalTextBox.TabIndex = 5
        '
        'ReleasePointsTabPage
        '
        Me.ReleasePointsTabPage.BackColor = System.Drawing.SystemColors.Control
        Me.ReleasePointsTabPage.Controls.Add(Me.Process_ReleasePointTabDataGridView)
        Me.ReleasePointsTabPage.Controls.Add(Me.lblReleasePointPercentTotal)
        Me.ReleasePointsTabPage.Controls.Add(Me.btnAddReleasePoint)
        Me.ReleasePointsTabPage.Location = New System.Drawing.Point(4, 27)
        Me.ReleasePointsTabPage.Name = "ReleasePointsTabPage"
        Me.ReleasePointsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ReleasePointsTabPage.Size = New System.Drawing.Size(932, 733)
        Me.ReleasePointsTabPage.TabIndex = 1
        Me.ReleasePointsTabPage.Text = "Release Points"
        '
        'Process_ReleasePointTabDataGridView
        '
        Me.Process_ReleasePointTabDataGridView.AllowUserToAddRows = False
        Me.Process_ReleasePointTabDataGridView.AutoGenerateColumns = False
        Me.Process_ReleasePointTabDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Process_ReleasePointTabDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Process_ReleasePointTabDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        Me.Process_ReleasePointTabDataGridView.DataSource = Me.Process_ReleasePointTabBindingSource
        Me.Process_ReleasePointTabDataGridView.Location = New System.Drawing.Point(6, 60)
        Me.Process_ReleasePointTabDataGridView.Name = "Process_ReleasePointTabDataGridView"
        Me.Process_ReleasePointTabDataGridView.Size = New System.Drawing.Size(566, 667)
        Me.Process_ReleasePointTabDataGridView.TabIndex = 11
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ProcessID"
        Me.DataGridViewTextBoxColumn7.HeaderText = "ProcessID"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "EmissionYear"
        Me.DataGridViewTextBoxColumn8.HeaderText = "EmissionYear"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "ReleasePointAPCDID"
        Me.DataGridViewTextBoxColumn9.HeaderText = "APCD ID"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 77
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "EmissionsPercent"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn11.HeaderText = "Emissions Stream %"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 129
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "ProcessReleasePointID"
        Me.DataGridViewTextBoxColumn12.HeaderText = "ProcessReleasePointID"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'Process_ReleasePointTabBindingSource
        '
        Me.Process_ReleasePointTabBindingSource.DataMember = "Process_ReleasePointTab"
        Me.Process_ReleasePointTabBindingSource.DataSource = Me.EmissionsDataSet
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblReleasePointPercentTotal
        '
        Me.lblReleasePointPercentTotal.Location = New System.Drawing.Point(53, 25)
        Me.lblReleasePointPercentTotal.Name = "lblReleasePointPercentTotal"
        Me.lblReleasePointPercentTotal.Size = New System.Drawing.Size(109, 25)
        Me.lblReleasePointPercentTotal.TabIndex = 77
        Me.lblReleasePointPercentTotal.Text = "lblReleasePointPercentTotal"
        Me.lblReleasePointPercentTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAddReleasePoint
        '
        Me.btnAddReleasePoint.Location = New System.Drawing.Point(6, 20)
        Me.btnAddReleasePoint.Name = "btnAddReleasePoint"
        Me.btnAddReleasePoint.Size = New System.Drawing.Size(41, 34)
        Me.btnAddReleasePoint.TabIndex = 10
        Me.btnAddReleasePoint.Text = "Add"
        Me.btnAddReleasePoint.UseVisualStyleBackColor = True
        '
        'ControlMeasuresTabPage
        '
        Me.ControlMeasuresTabPage.BackColor = System.Drawing.SystemColors.Control
        Me.ControlMeasuresTabPage.Controls.Add(Me.Process_ControlMeasureTabDataGridView)
        Me.ControlMeasuresTabPage.Controls.Add(Me.btnAddControlMeasure)
        Me.ControlMeasuresTabPage.Location = New System.Drawing.Point(4, 27)
        Me.ControlMeasuresTabPage.Name = "ControlMeasuresTabPage"
        Me.ControlMeasuresTabPage.Size = New System.Drawing.Size(932, 733)
        Me.ControlMeasuresTabPage.TabIndex = 2
        Me.ControlMeasuresTabPage.Text = "Control Measures"
        '
        'Process_ControlMeasureTabDataGridView
        '
        Me.Process_ControlMeasureTabDataGridView.AllowUserToAddRows = False
        Me.Process_ControlMeasureTabDataGridView.AutoGenerateColumns = False
        Me.Process_ControlMeasureTabDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Process_ControlMeasureTabDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Process_ControlMeasureTabDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ControlMeasureAPCDID, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.ProcessControlMeasureID})
        Me.Process_ControlMeasureTabDataGridView.DataSource = Me.Process_ControlMeasureTabBindingSource
        Me.Process_ControlMeasureTabDataGridView.Location = New System.Drawing.Point(6, 62)
        Me.Process_ControlMeasureTabDataGridView.Name = "Process_ControlMeasureTabDataGridView"
        Me.Process_ControlMeasureTabDataGridView.Size = New System.Drawing.Size(711, 654)
        Me.Process_ControlMeasureTabDataGridView.TabIndex = 21
        '
        'ControlMeasureAPCDID
        '
        Me.ControlMeasureAPCDID.DataPropertyName = "ControlMeasureAPCDID"
        Me.ControlMeasureAPCDID.HeaderText = "APCD ID"
        Me.ControlMeasureAPCDID.Name = "ControlMeasureAPCDID"
        Me.ControlMeasureAPCDID.Width = 77
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "CapturePercent"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn4.HeaderText = "Capture %"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 88
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "UptimePercent"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn5.HeaderText = "Uptime %"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 85
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Sequence"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn6.HeaderText = "Sequence"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 94
        '
        'ProcessControlMeasureID
        '
        Me.ProcessControlMeasureID.DataPropertyName = "ProcessControlMeasureID"
        Me.ProcessControlMeasureID.HeaderText = "ProcessControlMeasureID"
        Me.ProcessControlMeasureID.Name = "ProcessControlMeasureID"
        Me.ProcessControlMeasureID.Visible = False
        '
        'Process_ControlMeasureTabBindingSource
        '
        Me.Process_ControlMeasureTabBindingSource.DataMember = "Process_ControlMeasureTab"
        Me.Process_ControlMeasureTabBindingSource.DataSource = Me.EmissionsDataSet
        '
        'btnAddControlMeasure
        '
        Me.btnAddControlMeasure.Location = New System.Drawing.Point(6, 20)
        Me.btnAddControlMeasure.Name = "btnAddControlMeasure"
        Me.btnAddControlMeasure.Size = New System.Drawing.Size(41, 30)
        Me.btnAddControlMeasure.TabIndex = 20
        Me.btnAddControlMeasure.Text = "Add"
        Me.btnAddControlMeasure.UseVisualStyleBackColor = True
        '
        'ThroughputTabPage
        '
        Me.ThroughputTabPage.AutoScroll = True
        Me.ThroughputTabPage.BackColor = System.Drawing.SystemColors.Control
        Me.ThroughputTabPage.Controls.Add(Me.Process_ThroughputTabDataGridView)
        Me.ThroughputTabPage.Controls.Add(Me.btnLoadThroughputDefaults)
        Me.ThroughputTabPage.Controls.Add(Me.GroupBox3)
        Me.ThroughputTabPage.Controls.Add(Me.btnAddThroughput)
        Me.ThroughputTabPage.Location = New System.Drawing.Point(4, 27)
        Me.ThroughputTabPage.Name = "ThroughputTabPage"
        Me.ThroughputTabPage.Size = New System.Drawing.Size(932, 733)
        Me.ThroughputTabPage.TabIndex = 3
        Me.ThroughputTabPage.Text = "Throughput"
        '
        'Process_ThroughputTabDataGridView
        '
        Me.Process_ThroughputTabDataGridView.AllowUserToAddRows = False
        Me.Process_ThroughputTabDataGridView.AutoGenerateColumns = False
        Me.Process_ThroughputTabDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Process_ThroughputTabDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn30})
        Me.Process_ThroughputTabDataGridView.DataSource = Me.Process_ThroughputTabBindingSource
        Me.Process_ThroughputTabDataGridView.Location = New System.Drawing.Point(6, 58)
        Me.Process_ThroughputTabDataGridView.Name = "Process_ThroughputTabDataGridView"
        Me.Process_ThroughputTabDataGridView.Size = New System.Drawing.Size(495, 437)
        Me.Process_ThroughputTabDataGridView.TabIndex = 32
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "ProcessParameterTypeName"
        Me.DataGridViewTextBoxColumn22.HeaderText = "Parameter"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 200
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "ProcessParameterValue"
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.DataGridViewTextBoxColumn28.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn28.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.Width = 75
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "UnitOfMeasurementName"
        Me.DataGridViewTextBoxColumn29.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        Me.DataGridViewTextBoxColumn29.Width = 125
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "ProcessID"
        Me.DataGridViewTextBoxColumn20.HeaderText = "ProcessID"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "EmissionYear"
        Me.DataGridViewTextBoxColumn21.HeaderText = "EmissionYear"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.Visible = False
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "ProcessDetailPeriodID"
        Me.DataGridViewTextBoxColumn30.HeaderText = "ProcessDetailPeriodID"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.Visible = False
        '
        'Process_ThroughputTabBindingSource
        '
        Me.Process_ThroughputTabBindingSource.DataMember = "Process_ThroughputTab"
        Me.Process_ThroughputTabBindingSource.DataSource = Me.EmissionsDataSet
        '
        'btnLoadThroughputDefaults
        '
        Me.btnLoadThroughputDefaults.Location = New System.Drawing.Point(363, 23)
        Me.btnLoadThroughputDefaults.Name = "btnLoadThroughputDefaults"
        Me.btnLoadThroughputDefaults.Size = New System.Drawing.Size(115, 29)
        Me.btnLoadThroughputDefaults.TabIndex = 31
        Me.btnLoadThroughputDefaults.Text = "Load Defaults"
        Me.btnLoadThroughputDefaults.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.btnLoadSeasonalDefaults)
        Me.GroupBox3.Controls.Add(Me.lblSeasonalTotal)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.FallTextBox)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.SummerTextBox)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.SpringTextBox)
        Me.GroupBox3.Controls.Add(Me.WinterTextBox)
        Me.GroupBox3.Location = New System.Drawing.Point(519, 59)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(125, 190)
        Me.GroupBox3.TabIndex = 89
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Seasonal"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(18, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 21)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLoadSeasonalDefaults
        '
        Me.btnLoadSeasonalDefaults.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.btnLoadSeasonalDefaults.Location = New System.Drawing.Point(6, 156)
        Me.btnLoadSeasonalDefaults.Name = "btnLoadSeasonalDefaults"
        Me.btnLoadSeasonalDefaults.Size = New System.Drawing.Size(113, 28)
        Me.btnLoadSeasonalDefaults.TabIndex = 37
        Me.btnLoadSeasonalDefaults.Text = "Load Defaults"
        Me.btnLoadSeasonalDefaults.UseVisualStyleBackColor = True
        '
        'lblSeasonalTotal
        '
        Me.lblSeasonalTotal.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSeasonalTotal.Location = New System.Drawing.Point(73, 120)
        Me.lblSeasonalTotal.Name = "lblSeasonalTotal"
        Me.lblSeasonalTotal.Size = New System.Drawing.Size(39, 21)
        Me.lblSeasonalTotal.TabIndex = 96
        Me.lblSeasonalTotal.Text = "Label1"
        Me.lblSeasonalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(18, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 18)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Fall"
        '
        'FallTextBox
        '
        Me.FallTextBox.Location = New System.Drawing.Point(84, 93)
        Me.FallTextBox.Name = "FallTextBox"
        Me.FallTextBox.Size = New System.Drawing.Size(25, 26)
        Me.FallTextBox.TabIndex = 36
        Me.FallTextBox.Text = "0"
        Me.FallTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(18, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 18)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Summer"
        '
        'SummerTextBox
        '
        Me.SummerTextBox.Location = New System.Drawing.Point(84, 68)
        Me.SummerTextBox.Name = "SummerTextBox"
        Me.SummerTextBox.Size = New System.Drawing.Size(25, 26)
        Me.SummerTextBox.TabIndex = 35
        Me.SummerTextBox.Text = "0"
        Me.SummerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(18, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 18)
        Me.Label8.TabIndex = 79
        Me.Label8.Text = "Spring"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(18, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 18)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "Winter"
        '
        'SpringTextBox
        '
        Me.SpringTextBox.Location = New System.Drawing.Point(84, 43)
        Me.SpringTextBox.Name = "SpringTextBox"
        Me.SpringTextBox.Size = New System.Drawing.Size(25, 26)
        Me.SpringTextBox.TabIndex = 34
        Me.SpringTextBox.Text = "0"
        Me.SpringTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'WinterTextBox
        '
        Me.WinterTextBox.Location = New System.Drawing.Point(84, 18)
        Me.WinterTextBox.Name = "WinterTextBox"
        Me.WinterTextBox.Size = New System.Drawing.Size(25, 26)
        Me.WinterTextBox.TabIndex = 33
        Me.WinterTextBox.Text = "0"
        Me.WinterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAddThroughput
        '
        Me.btnAddThroughput.Location = New System.Drawing.Point(6, 23)
        Me.btnAddThroughput.Name = "btnAddThroughput"
        Me.btnAddThroughput.Size = New System.Drawing.Size(41, 29)
        Me.btnAddThroughput.TabIndex = 30
        Me.btnAddThroughput.Text = "Add"
        Me.btnAddThroughput.UseVisualStyleBackColor = True
        '
        'EmissionsTabPage
        '
        Me.EmissionsTabPage.AutoScroll = True
        Me.EmissionsTabPage.BackColor = System.Drawing.SystemColors.Control
        Me.EmissionsTabPage.Controls.Add(Me.TonsCheckBox)
        Me.EmissionsTabPage.Controls.Add(Me.OzoneSeasonCheckBox)
        Me.EmissionsTabPage.Controls.Add(Me.btnRecalculateFromThroughput)
        Me.EmissionsTabPage.Controls.Add(Me.Process_EmissionsTabDataGridView)
        Me.EmissionsTabPage.Controls.Add(Me.btnCopyToProcess)
        Me.EmissionsTabPage.Controls.Add(Me.btnAddEmissions)
        Me.EmissionsTabPage.Location = New System.Drawing.Point(4, 27)
        Me.EmissionsTabPage.Name = "EmissionsTabPage"
        Me.EmissionsTabPage.Size = New System.Drawing.Size(888, 733)
        Me.EmissionsTabPage.TabIndex = 4
        Me.EmissionsTabPage.Text = "Emissions"
        '
        'TonsCheckBox
        '
        Me.TonsCheckBox.AutoSize = True
        Me.TonsCheckBox.Location = New System.Drawing.Point(208, 46)
        Me.TonsCheckBox.Name = "TonsCheckBox"
        Me.TonsCheckBox.Size = New System.Drawing.Size(208, 22)
        Me.TonsCheckBox.TabIndex = 45
        Me.TonsCheckBox.Text = "Show only emissions in tons."
        Me.TonsCheckBox.UseVisualStyleBackColor = True
        '
        'OzoneSeasonCheckBox
        '
        Me.OzoneSeasonCheckBox.AutoSize = True
        Me.OzoneSeasonCheckBox.Location = New System.Drawing.Point(6, 46)
        Me.OzoneSeasonCheckBox.Name = "OzoneSeasonCheckBox"
        Me.OzoneSeasonCheckBox.Size = New System.Drawing.Size(184, 22)
        Me.OzoneSeasonCheckBox.TabIndex = 44
        Me.OzoneSeasonCheckBox.Text = "Show ozone season only."
        Me.OzoneSeasonCheckBox.UseVisualStyleBackColor = True
        '
        'btnRecalculateFromThroughput
        '
        Me.btnRecalculateFromThroughput.Location = New System.Drawing.Point(222, 12)
        Me.btnRecalculateFromThroughput.Name = "btnRecalculateFromThroughput"
        Me.btnRecalculateFromThroughput.Size = New System.Drawing.Size(215, 28)
        Me.btnRecalculateFromThroughput.TabIndex = 41
        Me.btnRecalculateFromThroughput.Text = "Recalculate from throughput"
        Me.btnRecalculateFromThroughput.UseVisualStyleBackColor = True
        '
        'Process_EmissionsTabDataGridView
        '
        Me.Process_EmissionsTabDataGridView.AllowUserToAddRows = False
        Me.Process_EmissionsTabDataGridView.AllowUserToOrderColumns = True
        Me.Process_EmissionsTabDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Process_EmissionsTabDataGridView.AutoGenerateColumns = False
        Me.Process_EmissionsTabDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Process_EmissionsTabDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Process_EmissionsTabDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.PollutantName, Me.EmissionPeriodTypeName, Me.EmissionValue, Me.UnitOfMeasurementName, Me.ProcessEmissionID, Me.EmissionCalculationMethodName, Me.EmissionFactorValue, Me.EFUnits})
        Me.Process_EmissionsTabDataGridView.DataSource = Me.Process_EmissionsTabBindingSource
        Me.Process_EmissionsTabDataGridView.Location = New System.Drawing.Point(0, 74)
        Me.Process_EmissionsTabDataGridView.Name = "Process_EmissionsTabDataGridView"
        Me.Process_EmissionsTabDataGridView.Size = New System.Drawing.Size(888, 659)
        Me.Process_EmissionsTabDataGridView.TabIndex = 47
        '
        'Process_EmissionsTabBindingSource
        '
        Me.Process_EmissionsTabBindingSource.DataMember = "Process_EmissionsTab"
        Me.Process_EmissionsTabBindingSource.DataSource = Me.EmissionsDataSet
        '
        'btnCopyToProcess
        '
        Me.btnCopyToProcess.Location = New System.Drawing.Point(610, 12)
        Me.btnCopyToProcess.Name = "btnCopyToProcess"
        Me.btnCopyToProcess.Size = New System.Drawing.Size(272, 28)
        Me.btnCopyToProcess.TabIndex = 42
        Me.btnCopyToProcess.Text = "Copy these pollutants to another process"
        Me.btnCopyToProcess.UseVisualStyleBackColor = True
        '
        'btnAddEmissions
        '
        Me.btnAddEmissions.Location = New System.Drawing.Point(6, 12)
        Me.btnAddEmissions.Name = "btnAddEmissions"
        Me.btnAddEmissions.Size = New System.Drawing.Size(46, 28)
        Me.btnAddEmissions.TabIndex = 40
        Me.btnAddEmissions.Text = "Add"
        Me.btnAddEmissions.UseVisualStyleBackColor = True
        '
        'PollutantBindingSource
        '
        Me.PollutantBindingSource.DataMember = "Pollutant"
        Me.PollutantBindingSource.DataSource = Me.ProcessDataSet
        '
        'ProcessDataSet
        '
        Me.ProcessDataSet.DataSetName = "ProcessDataSet"
        Me.ProcessDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmissionPeriodTypeBindingSource
        '
        Me.EmissionPeriodTypeBindingSource.DataMember = "EmissionPeriodType"
        Me.EmissionPeriodTypeBindingSource.DataSource = Me.ProcessDataSet
        '
        'UnitOfMeasurement_ProcessEmissionBindingSource
        '
        Me.UnitOfMeasurement_ProcessEmissionBindingSource.DataMember = "UnitOfMeasurement_ProcessEmission"
        Me.UnitOfMeasurement_ProcessEmissionBindingSource.DataSource = Me.ProcessDataSet
        '
        'ProcessBindingSource
        '
        Me.ProcessBindingSource.DataMember = "Process"
        Me.ProcessBindingSource.DataSource = Me.EmissionsDataSet
        '
        'IsExcludedCheckBox
        '
        Me.IsExcludedCheckBox.AutoSize = True
        Me.IsExcludedCheckBox.Location = New System.Drawing.Point(476, 5)
        Me.IsExcludedCheckBox.Name = "IsExcludedCheckBox"
        Me.IsExcludedCheckBox.Size = New System.Drawing.Size(174, 22)
        Me.IsExcludedCheckBox.TabIndex = 118
        Me.IsExcludedCheckBox.TabStop = False
        Me.IsExcludedCheckBox.Text = "Exclude from inventory"
        Me.IsExcludedCheckBox.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ProcessDataSetTableAdapterManager
        '
        Me.ProcessDataSetTableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.ProcessDataSetTableAdapterManager.Connection = Nothing
        Me.ProcessDataSetTableAdapterManager.EmissionPeriodTypeTableAdapter = Nothing
        Me.ProcessDataSetTableAdapterManager.PollutantTableAdapter = Nothing
        Me.ProcessDataSetTableAdapterManager.ProcessDetailPeriodTableAdapter = Nothing
        Me.ProcessDataSetTableAdapterManager.ProcessEmissionHistoryTableAdapter = Nothing
        Me.ProcessDataSetTableAdapterManager.ProcessEmissionTableAdapter = Nothing
        Me.ProcessDataSetTableAdapterManager.UpdateOrder = APCD.EmissionsInventory.ProcessDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'PollutantTableAdapter
        '
        Me.PollutantTableAdapter.ClearBeforeFill = True
        '
        'UnitOfMeasurement_ProcessEmissionTableAdapter
        '
        Me.UnitOfMeasurement_ProcessEmissionTableAdapter.ClearBeforeFill = True
        '
        'EmissionPeriodTypeTableAdapter
        '
        Me.EmissionPeriodTypeTableAdapter.ClearBeforeFill = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(672, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 25)
        Me.btnSave.TabIndex = 94
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnShutdown
        '
        Me.btnShutdown.Location = New System.Drawing.Point(370, 3)
        Me.btnShutdown.Name = "btnShutdown"
        Me.btnShutdown.Size = New System.Drawing.Size(100, 25)
        Me.btnShutdown.TabIndex = 93
        Me.btnShutdown.Text = "Shut down"
        Me.btnShutdown.UseVisualStyleBackColor = True
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.Location = New System.Drawing.Point(10, 3)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(100, 25)
        Me.btnApprove.TabIndex = 90
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(767, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 25)
        Me.btnCancel.TabIndex = 95
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ButtonPanel
        '
        Me.ButtonPanel.Controls.Add(Me.IsExcludedCheckBox)
        Me.ButtonPanel.Controls.Add(Me.btnShutdown)
        Me.ButtonPanel.Controls.Add(Me.ShutdownMessageLabel)
        Me.ButtonPanel.Controls.Add(Me.btnApprove)
        Me.ButtonPanel.Controls.Add(Me.btnCancel)
        Me.ButtonPanel.Controls.Add(Me.btnSave)
        Me.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonPanel.Location = New System.Drawing.Point(0, 0)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(896, 30)
        Me.ButtonPanel.TabIndex = 120
        '
        'ShutdownMessageLabel
        '
        Me.ShutdownMessageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShutdownMessageLabel.ForeColor = System.Drawing.Color.Red
        Me.ShutdownMessageLabel.Location = New System.Drawing.Point(117, 4)
        Me.ShutdownMessageLabel.Name = "ShutdownMessageLabel"
        Me.ShutdownMessageLabel.Size = New System.Drawing.Size(400, 19)
        Me.ShutdownMessageLabel.TabIndex = 121
        Me.ShutdownMessageLabel.Text = "ShutdownMessageLabel"
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
        'ControlMeasureBindingSource
        '
        Me.ControlMeasureBindingSource.DataMember = "ControlMeasure"
        Me.ControlMeasureBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasureTableAdapter
        '
        Me.ControlMeasureTableAdapter.ClearBeforeFill = True
        '
        'Process_ControlMeasureTabTableAdapter
        '
        Me.Process_ControlMeasureTabTableAdapter.ClearBeforeFill = True
        '
        'Process_ReleasePointTabTableAdapter
        '
        Me.Process_ReleasePointTabTableAdapter.ClearBeforeFill = True
        '
        'Process_EmissionsTabTableAdapter
        '
        Me.Process_EmissionsTabTableAdapter.ClearBeforeFill = True
        '
        'Process_ThroughputTabTableAdapter
        '
        Me.Process_ThroughputTabTableAdapter.ClearBeforeFill = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "ProcessID"
        Me.DataGridViewTextBoxColumn13.HeaderText = "ProcessID"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 5
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "EmissionYear"
        Me.DataGridViewTextBoxColumn14.HeaderText = "EmissionYear"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 5
        '
        'PollutantName
        '
        Me.PollutantName.DataPropertyName = "PollutantName"
        Me.PollutantName.HeaderText = "Pollutant"
        Me.PollutantName.Name = "PollutantName"
        Me.PollutantName.Width = 90
        '
        'EmissionPeriodTypeName
        '
        Me.EmissionPeriodTypeName.DataPropertyName = "EmissionPeriodTypeName"
        Me.EmissionPeriodTypeName.HeaderText = "Period"
        Me.EmissionPeriodTypeName.Name = "EmissionPeriodTypeName"
        Me.EmissionPeriodTypeName.Width = 74
        '
        'EmissionValue
        '
        Me.EmissionValue.DataPropertyName = "EmissionValue"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.Format = "#0.000"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.EmissionValue.DefaultCellStyle = DataGridViewCellStyle7
        Me.EmissionValue.HeaderText = "Emissions"
        Me.EmissionValue.Name = "EmissionValue"
        Me.EmissionValue.Width = 94
        '
        'UnitOfMeasurementName
        '
        Me.UnitOfMeasurementName.DataPropertyName = "UnitOfMeasurementName"
        Me.UnitOfMeasurementName.HeaderText = "Emissions Units"
        Me.UnitOfMeasurementName.Name = "UnitOfMeasurementName"
        Me.UnitOfMeasurementName.Width = 118
        '
        'ProcessEmissionID
        '
        Me.ProcessEmissionID.DataPropertyName = "ProcessEmissionID"
        Me.ProcessEmissionID.HeaderText = "ProcessEmissionID"
        Me.ProcessEmissionID.Name = "ProcessEmissionID"
        Me.ProcessEmissionID.Visible = False
        Me.ProcessEmissionID.Width = 5
        '
        'EmissionCalculationMethodName
        '
        Me.EmissionCalculationMethodName.DataPropertyName = "EmissionCalculationMethodName"
        Me.EmissionCalculationMethodName.HeaderText = "Calculation Method"
        Me.EmissionCalculationMethodName.Name = "EmissionCalculationMethodName"
        Me.EmissionCalculationMethodName.ReadOnly = True
        Me.EmissionCalculationMethodName.Width = 140
        '
        'EmissionFactorValue
        '
        Me.EmissionFactorValue.DataPropertyName = "EmissionFactorValue"
        Me.EmissionFactorValue.HeaderText = "Emission Factor"
        Me.EmissionFactorValue.Name = "EmissionFactorValue"
        Me.EmissionFactorValue.Width = 118
        '
        'EFUnits
        '
        Me.EFUnits.DataPropertyName = "EFUnits"
        Me.EFUnits.HeaderText = "EF Units"
        Me.EFUnits.Name = "EFUnits"
        Me.EFUnits.ReadOnly = True
        Me.EFUnits.Width = 76
        '
        'ProcessUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonPanel)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Name = "ProcessUserControl"
        Me.Size = New System.Drawing.Size(896, 800)
        Me.TabControl1.ResumeLayout(False)
        Me.GeneralTabPage.ResumeLayout(False)
        Me.GeneralTabPage.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ReleasePointsTabPage.ResumeLayout(False)
        CType(Me.Process_ReleasePointTabDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Process_ReleasePointTabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlMeasuresTabPage.ResumeLayout(False)
        CType(Me.Process_ControlMeasureTabDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Process_ControlMeasureTabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ThroughputTabPage.ResumeLayout(False)
        CType(Me.Process_ThroughputTabDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Process_ThroughputTabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.EmissionsTabPage.ResumeLayout(False)
        Me.EmissionsTabPage.PerformLayout()
        CType(Me.Process_EmissionsTabDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Process_EmissionsTabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PollutantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionPeriodTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnitOfMeasurement_ProcessEmissionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ButtonPanel.ResumeLayout(False)
        Me.ButtonPanel.PerformLayout()
        CType(Me.ControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents GeneralTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ReleasePointsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ControlMeasuresTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ThroughputTabPage As System.Windows.Forms.TabPage
    Friend WithEvents EmissionsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ProcessBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ProcessDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProcessAPCDIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentPublicTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ThroughputTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnChangeProcessClass As System.Windows.Forms.Button
    Friend WithEvents IsExcludedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents lblReleasePointPercentTotal As System.Windows.Forms.Label
    Friend WithEvents btnAddReleasePoint As System.Windows.Forms.Button
    Friend WithEvents lblSCCNumber As System.Windows.Forms.Label
    Friend WithEvents lblSCCName As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddControlMeasure As System.Windows.Forms.Button
    Friend WithEvents btnAddThroughput As System.Windows.Forms.Button
    Friend WithEvents btnCopyToProcess As System.Windows.Forms.Button
    Friend WithEvents btnAddEmissions As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ControlApproachDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FallTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SummerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SpringTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WinterTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadSeasonalDefaults As System.Windows.Forms.Button
    Friend WithEvents btnLoadThroughputDefaults As System.Windows.Forms.Button
    Friend WithEvents lblSeasonalTotal As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessDataSet As APCD.EmissionsInventory.ProcessDataSet
    Friend WithEvents ProcessDataSetTableAdapterManager As APCD.EmissionsInventory.ProcessDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PollutantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PollutantTableAdapter As APCD.EmissionsInventory.ProcessDataSetTableAdapters.PollutantTableAdapter
    Friend WithEvents UnitOfMeasurement_ProcessEmissionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UnitOfMeasurement_ProcessEmissionTableAdapter As APCD.EmissionsInventory.ProcessDataSetTableAdapters.UnitOfMeasurement_ProcessEmissionTableAdapter
    Friend WithEvents EmissionPeriodTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionPeriodTypeTableAdapter As APCD.EmissionsInventory.ProcessDataSetTableAdapters.EmissionPeriodTypeTableAdapter
    Friend WithEvents ControlMeasureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTableAdapter
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents btnShutdown As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ButtonPanel As System.Windows.Forms.Panel
    Friend WithEvents ShutdownMessageLabel As System.Windows.Forms.Label
    Friend WithEvents Process_ControlMeasureTabBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Process_ControlMeasureTabTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ControlMeasureTabTableAdapter
    Friend WithEvents Process_ControlMeasureTabDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Process_ReleasePointTabBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Process_ReleasePointTabTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ReleasePointTabTableAdapter
    Friend WithEvents Process_ReleasePointTabDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Process_EmissionsTabBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Process_EmissionsTabTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_EmissionsTabTableAdapter
    Friend WithEvents Process_EmissionsTabDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Process_ThroughputTabDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Process_ThroughputTabBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Process_ThroughputTabTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ThroughputTabTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRecalculateFromThroughput As System.Windows.Forms.Button
    Friend WithEvents OzoneSeasonCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TonsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ControlMeasureAPCDID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessControlMeasureID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PollutantName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmissionPeriodTypeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmissionValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitOfMeasurementName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessEmissionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmissionCalculationMethodName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmissionFactorValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EFUnits As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
