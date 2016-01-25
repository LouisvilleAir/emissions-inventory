<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReleasePointUserControl
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
        Dim YCoordinateLabel As System.Windows.Forms.Label
        Dim ReleasePointTypeIDLabel As System.Windows.Forms.Label
        Dim ReleasePointAPCDIDLabel As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim CommentPublicLabel As System.Windows.Forms.Label
        Dim CommentInternalLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ReleasePointDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ReleasePointAPCDIDTextBox = New System.Windows.Forms.TextBox()
        Me.CompanyCommentTextBox = New System.Windows.Forms.TextBox()
        Me.APCDCommentTextBox = New System.Windows.Forms.TextBox()
        Me.XCoordinateTextBox = New System.Windows.Forms.TextBox()
        Me.YCoordinateTextBox = New System.Windows.Forms.TextBox()
        Me.MeasurementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UnitOfMeasurementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MeasurementTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.MeasurementTableAdapter()
        Me.UnitOfMeasurementTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.UnitOfMeasurementTableAdapter()
        Me.ReleasePointTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ReleasePointTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointTypeTableAdapter()
        Me.IsExcludedCheckBox = New System.Windows.Forms.CheckBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ReleaseTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleaseTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleaseTypeTableAdapter()
        Me.ReleaseTypeSubTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ReleaseTypeSubTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleaseTypeSubTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleaseTypeSubTypeTableAdapter()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonPanel = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnShutdown = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.ShutdownMessageLabel = New System.Windows.Forms.Label()
        Me.ReleasePoint_GetProcessesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePoint_GetProcessesTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePoint_GetProcessesTableAdapter()
        Me.ReleasePoint_GetProcessesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReleasePointDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointDetailDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ReleaseTypeMeasurementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleaseTypeMeasurementTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleaseTypeMeasurementTableAdapter()
        YCoordinateLabel = New System.Windows.Forms.Label()
        ReleasePointTypeIDLabel = New System.Windows.Forms.Label()
        ReleasePointAPCDIDLabel = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        CommentPublicLabel = New System.Windows.Forms.Label()
        CommentInternalLabel = New System.Windows.Forms.Label()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeasurementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnitOfMeasurementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleaseTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleaseTypeSubTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ButtonPanel.SuspendLayout()
        CType(Me.ReleasePoint_GetProcessesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePoint_GetProcessesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointDetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleaseTypeMeasurementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'YCoordinateLabel
        '
        YCoordinateLabel.AutoSize = True
        YCoordinateLabel.Location = New System.Drawing.Point(10, 292)
        YCoordinateLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        YCoordinateLabel.Name = "YCoordinateLabel"
        YCoordinateLabel.Size = New System.Drawing.Size(72, 17)
        YCoordinateLabel.TabIndex = 80
        YCoordinateLabel.Text = "* Latitude:"
        '
        'ReleasePointTypeIDLabel
        '
        ReleasePointTypeIDLabel.AutoSize = True
        ReleasePointTypeIDLabel.Location = New System.Drawing.Point(10, 327)
        ReleasePointTypeIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ReleasePointTypeIDLabel.Name = "ReleasePointTypeIDLabel"
        ReleasePointTypeIDLabel.Size = New System.Drawing.Size(53, 17)
        ReleasePointTypeIDLabel.TabIndex = 74
        ReleasePointTypeIDLabel.Text = "* Type:"
        '
        'ReleasePointAPCDIDLabel
        '
        ReleasePointAPCDIDLabel.AutoSize = True
        ReleasePointAPCDIDLabel.Location = New System.Drawing.Point(10, 72)
        ReleasePointAPCDIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ReleasePointAPCDIDLabel.Name = "ReleasePointAPCDIDLabel"
        ReleasePointAPCDIDLabel.Size = New System.Drawing.Size(75, 17)
        ReleasePointAPCDIDLabel.TabIndex = 75
        ReleasePointAPCDIDLabel.Text = "* APCD ID:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(315, 292)
        Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(84, 17)
        Label3.TabIndex = 113
        Label3.Text = "* Longitude:"
        '
        'Label6
        '
        Label6.Location = New System.Drawing.Point(11, 100)
        Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(84, 43)
        Label6.TabIndex = 126
        Label6.Text = "Company Description:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.Location = New System.Drawing.Point(11, 153)
        CommentPublicLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(115, 38)
        CommentPublicLabel.TabIndex = 124
        CommentPublicLabel.Text = "Company Comment:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.Location = New System.Drawing.Point(11, 222)
        CommentInternalLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(100, 43)
        CommentInternalLabel.TabIndex = 125
        CommentInternalLabel.Text = "APCD Comment:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 41)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 17)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "* Required field"
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
        'ReleasePointDescriptionTextBox
        '
        Me.ReleasePointDescriptionTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReleasePointDescriptionTextBox.Location = New System.Drawing.Point(134, 100)
        Me.ReleasePointDescriptionTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReleasePointDescriptionTextBox.MaxLength = 100
        Me.ReleasePointDescriptionTextBox.Multiline = True
        Me.ReleasePointDescriptionTextBox.Name = "ReleasePointDescriptionTextBox"
        Me.ReleasePointDescriptionTextBox.Size = New System.Drawing.Size(723, 42)
        Me.ReleasePointDescriptionTextBox.TabIndex = 12
        '
        'ReleasePointAPCDIDTextBox
        '
        Me.ReleasePointAPCDIDTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReleasePointAPCDIDTextBox.Location = New System.Drawing.Point(134, 68)
        Me.ReleasePointAPCDIDTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReleasePointAPCDIDTextBox.MaxLength = 50
        Me.ReleasePointAPCDIDTextBox.Name = "ReleasePointAPCDIDTextBox"
        Me.ReleasePointAPCDIDTextBox.Size = New System.Drawing.Size(432, 26)
        Me.ReleasePointAPCDIDTextBox.TabIndex = 11
        '
        'CompanyCommentTextBox
        '
        Me.CompanyCommentTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyCommentTextBox.Location = New System.Drawing.Point(134, 151)
        Me.CompanyCommentTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CompanyCommentTextBox.MaxLength = 400
        Me.CompanyCommentTextBox.Multiline = True
        Me.CompanyCommentTextBox.Name = "CompanyCommentTextBox"
        Me.CompanyCommentTextBox.Size = New System.Drawing.Size(723, 61)
        Me.CompanyCommentTextBox.TabIndex = 13
        '
        'APCDCommentTextBox
        '
        Me.APCDCommentTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.APCDCommentTextBox.Location = New System.Drawing.Point(134, 220)
        Me.APCDCommentTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.APCDCommentTextBox.MaxLength = 400
        Me.APCDCommentTextBox.Multiline = True
        Me.APCDCommentTextBox.Name = "APCDCommentTextBox"
        Me.APCDCommentTextBox.Size = New System.Drawing.Size(723, 61)
        Me.APCDCommentTextBox.TabIndex = 14
        '
        'XCoordinateTextBox
        '
        Me.XCoordinateTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XCoordinateTextBox.Location = New System.Drawing.Point(439, 288)
        Me.XCoordinateTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.XCoordinateTextBox.MaxLength = 9
        Me.XCoordinateTextBox.Name = "XCoordinateTextBox"
        Me.XCoordinateTextBox.Size = New System.Drawing.Size(109, 26)
        Me.XCoordinateTextBox.TabIndex = 16
        '
        'YCoordinateTextBox
        '
        Me.YCoordinateTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YCoordinateTextBox.Location = New System.Drawing.Point(134, 289)
        Me.YCoordinateTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.YCoordinateTextBox.MaxLength = 9
        Me.YCoordinateTextBox.Name = "YCoordinateTextBox"
        Me.YCoordinateTextBox.Size = New System.Drawing.Size(109, 26)
        Me.YCoordinateTextBox.TabIndex = 15
        '
        'MeasurementBindingSource
        '
        Me.MeasurementBindingSource.DataMember = "Measurement"
        Me.MeasurementBindingSource.DataSource = Me.EmissionsDataSet
        '
        'UnitOfMeasurementBindingSource
        '
        Me.UnitOfMeasurementBindingSource.DataMember = "UnitOfMeasurement"
        Me.UnitOfMeasurementBindingSource.DataSource = Me.EmissionsDataSet
        '
        'MeasurementTableAdapter
        '
        Me.MeasurementTableAdapter.ClearBeforeFill = True
        '
        'UnitOfMeasurementTableAdapter
        '
        Me.UnitOfMeasurementTableAdapter.ClearBeforeFill = True
        '
        'ReleasePointTypeComboBox
        '
        Me.ReleasePointTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ReleasePointTypeComboBox.FormattingEnabled = True
        Me.ReleasePointTypeComboBox.Location = New System.Drawing.Point(134, 324)
        Me.ReleasePointTypeComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReleasePointTypeComboBox.Name = "ReleasePointTypeComboBox"
        Me.ReleasePointTypeComboBox.Size = New System.Drawing.Size(185, 24)
        Me.ReleasePointTypeComboBox.TabIndex = 17
        '
        'ReleasePointTypeBindingSource
        '
        Me.ReleasePointTypeBindingSource.DataMember = "ReleasePointType"
        Me.ReleasePointTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleasePointTypeTableAdapter
        '
        Me.ReleasePointTypeTableAdapter.ClearBeforeFill = True
        '
        'IsExcludedCheckBox
        '
        Me.IsExcludedCheckBox.Location = New System.Drawing.Point(444, 8)
        Me.IsExcludedCheckBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsExcludedCheckBox.Name = "IsExcludedCheckBox"
        Me.IsExcludedCheckBox.Size = New System.Drawing.Size(197, 22)
        Me.IsExcludedCheckBox.TabIndex = 4
        Me.IsExcludedCheckBox.TabStop = False
        Me.IsExcludedCheckBox.Text = "Exclude from inventory"
        Me.IsExcludedCheckBox.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ReleaseTypeBindingSource
        '
        Me.ReleaseTypeBindingSource.DataMember = "ReleaseType"
        Me.ReleaseTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleaseTypeTableAdapter
        '
        Me.ReleaseTypeTableAdapter.ClearBeforeFill = True
        '
        'ReleaseTypeSubTypeComboBox
        '
        Me.ReleaseTypeSubTypeComboBox.DataSource = Me.ReleaseTypeSubTypeBindingSource
        Me.ReleaseTypeSubTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ReleaseTypeSubTypeComboBox.FormattingEnabled = True
        Me.ReleaseTypeSubTypeComboBox.Location = New System.Drawing.Point(329, 324)
        Me.ReleaseTypeSubTypeComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReleaseTypeSubTypeComboBox.Name = "ReleaseTypeSubTypeComboBox"
        Me.ReleaseTypeSubTypeComboBox.Size = New System.Drawing.Size(99, 24)
        Me.ReleaseTypeSubTypeComboBox.TabIndex = 18
        '
        'ReleaseTypeSubTypeBindingSource
        '
        Me.ReleaseTypeSubTypeBindingSource.DataMember = "ReleaseTypeSubType"
        Me.ReleaseTypeSubTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleaseTypeSubTypeTableAdapter
        '
        Me.ReleaseTypeSubTypeTableAdapter.ClearBeforeFill = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 631)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(211, 17)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Processes for this release point:"
        '
        'ButtonPanel
        '
        Me.ButtonPanel.Controls.Add(Me.IsExcludedCheckBox)
        Me.ButtonPanel.Controls.Add(Me.btnSave)
        Me.ButtonPanel.Controls.Add(Me.btnShutdown)
        Me.ButtonPanel.Controls.Add(Me.ShutdownMessageLabel)
        Me.ButtonPanel.Controls.Add(Me.btnCancel)
        Me.ButtonPanel.Controls.Add(Me.btnApprove)
        Me.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonPanel.Location = New System.Drawing.Point(0, 0)
        Me.ButtonPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(896, 37)
        Me.ButtonPanel.TabIndex = 127
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(649, 4)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 28)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnShutdown
        '
        Me.btnShutdown.Location = New System.Drawing.Point(318, 4)
        Me.btnShutdown.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnShutdown.Name = "btnShutdown"
        Me.btnShutdown.Size = New System.Drawing.Size(118, 28)
        Me.btnShutdown.TabIndex = 3
        Me.btnShutdown.Text = "Shut down"
        Me.btnShutdown.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(757, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(4, 4)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(119, 28)
        Me.btnApprove.TabIndex = 1
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'ShutdownMessageLabel
        '
        Me.ShutdownMessageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShutdownMessageLabel.ForeColor = System.Drawing.Color.Red
        Me.ShutdownMessageLabel.Location = New System.Drawing.Point(131, 7)
        Me.ShutdownMessageLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ShutdownMessageLabel.Name = "ShutdownMessageLabel"
        Me.ShutdownMessageLabel.Size = New System.Drawing.Size(346, 23)
        Me.ShutdownMessageLabel.TabIndex = 2
        Me.ShutdownMessageLabel.Text = "ShutdownMessageLabel"
        '
        'ReleasePoint_GetProcessesBindingSource
        '
        Me.ReleasePoint_GetProcessesBindingSource.DataMember = "ReleasePoint_GetProcesses"
        Me.ReleasePoint_GetProcessesBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleasePoint_GetProcessesTableAdapter
        '
        Me.ReleasePoint_GetProcessesTableAdapter.ClearBeforeFill = True
        '
        'ReleasePoint_GetProcessesDataGridView
        '
        Me.ReleasePoint_GetProcessesDataGridView.AllowUserToAddRows = False
        Me.ReleasePoint_GetProcessesDataGridView.AllowUserToDeleteRows = False
        Me.ReleasePoint_GetProcessesDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReleasePoint_GetProcessesDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ReleasePoint_GetProcessesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ReleasePoint_GetProcessesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn14})
        Me.ReleasePoint_GetProcessesDataGridView.DataSource = Me.ReleasePoint_GetProcessesBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ReleasePoint_GetProcessesDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.ReleasePoint_GetProcessesDataGridView.Location = New System.Drawing.Point(14, 652)
        Me.ReleasePoint_GetProcessesDataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReleasePoint_GetProcessesDataGridView.Name = "ReleasePoint_GetProcessesDataGridView"
        Me.ReleasePoint_GetProcessesDataGridView.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReleasePoint_GetProcessesDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ReleasePoint_GetProcessesDataGridView.Size = New System.Drawing.Size(467, 228)
        Me.ReleasePoint_GetProcessesDataGridView.TabIndex = 40
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "PlantEmissionUnitID"
        Me.DataGridViewTextBoxColumn6.HeaderText = "PlantEmissionUnitID"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "EmissionUnitAPCDID"
        Me.DataGridViewTextBoxColumn7.HeaderText = "EU"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 150
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "ProcessID"
        Me.DataGridViewTextBoxColumn8.HeaderText = "ProcessID"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "ProcessAPCDID"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Process"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 150
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "ReleasePointID"
        Me.DataGridViewTextBoxColumn12.HeaderText = "ReleasePointID"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "EmissionYear"
        Me.DataGridViewTextBoxColumn14.HeaderText = "EmissionYear"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'ReleasePointDetailBindingSource
        '
        Me.ReleasePointDetailBindingSource.DataMember = "ReleasePointDetail"
        Me.ReleasePointDetailBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleasePointDetailDataGridView
        '
        Me.ReleasePointDetailDataGridView.AllowUserToAddRows = False
        Me.ReleasePointDetailDataGridView.AllowUserToDeleteRows = False
        Me.ReleasePointDetailDataGridView.AutoGenerateColumns = False
        Me.ReleasePointDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ReleasePointDetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.ReleasePointDetailDataGridView.DataSource = Me.ReleasePointDetailBindingSource
        Me.ReleasePointDetailDataGridView.Location = New System.Drawing.Point(13, 369)
        Me.ReleasePointDetailDataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReleasePointDetailDataGridView.Name = "ReleasePointDetailDataGridView"
        Me.ReleasePointDetailDataGridView.ReadOnly = True
        Me.ReleasePointDetailDataGridView.RowHeadersVisible = False
        Me.ReleasePointDetailDataGridView.Size = New System.Drawing.Size(633, 246)
        Me.ReleasePointDetailDataGridView.TabIndex = 30
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "MeasurementID"
        Me.DataGridViewTextBoxColumn4.DataSource = Me.MeasurementBindingSource
        Me.DataGridViewTextBoxColumn4.DisplayMember = "MeasurementName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Measurement"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn4.ValueMember = "MeasurementID"
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "DetailValue"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Value"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ReleasePointDetailID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ReleasePointDetailID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ReleasePointID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ReleasePointID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "UnitOfMeasurementID"
        Me.DataGridViewTextBoxColumn3.DataSource = Me.UnitOfMeasurementBindingSource
        Me.DataGridViewTextBoxColumn3.DisplayMember = "UnitOfMeasurementName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn3.ValueMember = "UnitOfMeasurementID"
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'ReleaseTypeMeasurementBindingSource
        '
        Me.ReleaseTypeMeasurementBindingSource.DataMember = "ReleaseTypeMeasurement"
        Me.ReleaseTypeMeasurementBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleaseTypeMeasurementTableAdapter
        '
        Me.ReleaseTypeMeasurementTableAdapter.ClearBeforeFill = True
        '
        'ReleasePointUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReleasePointDetailDataGridView)
        Me.Controls.Add(Me.ReleasePoint_GetProcessesDataGridView)
        Me.Controls.Add(Me.ButtonPanel)
        Me.Controls.Add(Label6)
        Me.Controls.Add(CommentPublicLabel)
        Me.Controls.Add(CommentInternalLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ReleaseTypeSubTypeComboBox)
        Me.Controls.Add(Me.ReleasePointTypeComboBox)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.ReleasePointDescriptionTextBox)
        Me.Controls.Add(Me.ReleasePointAPCDIDTextBox)
        Me.Controls.Add(Me.CompanyCommentTextBox)
        Me.Controls.Add(Me.APCDCommentTextBox)
        Me.Controls.Add(Me.XCoordinateTextBox)
        Me.Controls.Add(Me.YCoordinateTextBox)
        Me.Controls.Add(YCoordinateLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(ReleasePointTypeIDLabel)
        Me.Controls.Add(ReleasePointAPCDIDLabel)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ReleasePointUserControl"
        Me.Size = New System.Drawing.Size(896, 1057)
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeasurementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnitOfMeasurementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleaseTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleaseTypeSubTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ButtonPanel.ResumeLayout(False)
        CType(Me.ReleasePoint_GetProcessesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePoint_GetProcessesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointDetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleaseTypeMeasurementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ReleasePointDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReleasePointAPCDIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompanyCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents APCDCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents XCoordinateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YCoordinateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MeasurementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MeasurementTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.MeasurementTableAdapter
    Friend WithEvents UnitOfMeasurementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UnitOfMeasurementTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.UnitOfMeasurementTableAdapter
    Friend WithEvents ReleasePointTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ReleasePointTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointTypeTableAdapter
    Friend WithEvents IsExcludedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ReleaseTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleaseTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleaseTypeTableAdapter
    Friend WithEvents ReleaseTypeSubTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ReleaseTypeSubTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleaseTypeSubTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleaseTypeSubTypeTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonPanel As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnShutdown As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents ShutdownMessageLabel As System.Windows.Forms.Label
    Friend WithEvents ReleasePoint_GetProcessesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePoint_GetProcessesTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePoint_GetProcessesTableAdapter
    Friend WithEvents ReleasePoint_GetProcessesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReleasePointDetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointDetailDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ReleaseTypeMeasurementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleaseTypeMeasurementTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleaseTypeMeasurementTableAdapter

End Class
