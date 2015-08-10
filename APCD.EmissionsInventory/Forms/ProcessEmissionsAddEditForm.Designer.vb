<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessEmissionsAddEditForm
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
        Dim ControlMeasureIDLabel As System.Windows.Forms.Label
        Dim CommentPublicLabel As System.Windows.Forms.Label
        Dim CommentInternalLabel As System.Windows.Forms.Label
        Dim CapturePercentLabel As System.Windows.Forms.Label
        Dim EmissionPeriodTypeIDLabel As System.Windows.Forms.Label
        Dim EmissionCalculationMethodIDLabel As System.Windows.Forms.Label
        Dim EmissionFactorValueLabel As System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CommentPublicTextBox = New System.Windows.Forms.TextBox()
        Me.PollutantComboBox = New System.Windows.Forms.ComboBox()
        Me.CommentInternalTextBox = New System.Windows.Forms.TextBox()
        Me.EmissionValueTextBox = New System.Windows.Forms.TextBox()
        Me.EmissionFactorValueTextBox = New System.Windows.Forms.TextBox()
        Me.EmissionPeriodTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.EmissionCalculationMethodComboBox = New System.Windows.Forms.ComboBox()
        Me.EmissionValueUnitOfMeasurementLabel = New System.Windows.Forms.Label()
        Me.EmissionFactorValueUnitOfMeasurementLabel = New System.Windows.Forms.Label()
        Me.EmissionFactorPanel = New System.Windows.Forms.Panel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ProcessDataSet = New APCD.EmissionsInventory.ProcessDataSet()
        Me.ProcessEmissionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessEmissionTableAdapter = New APCD.EmissionsInventory.ProcessDataSetTableAdapters.ProcessEmissionTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.ProcessDataSetTableAdapters.TableAdapterManager()
        Me.ProcessEmissionHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessEmissionHistoryTableAdapter = New APCD.EmissionsInventory.ProcessDataSetTableAdapters.ProcessEmissionHistoryTableAdapter()
        Me.ProcessDetailPeriodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessDetailPeriodTableAdapter = New APCD.EmissionsInventory.ProcessDataSetTableAdapters.ProcessDetailPeriodTableAdapter()
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.PollutantBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PollutantTableAdapter1 = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PollutantTableAdapter()
        Me.TableAdapterManager1 = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.emissionPanel = New System.Windows.Forms.Panel()
        ControlMeasureIDLabel = New System.Windows.Forms.Label()
        CommentPublicLabel = New System.Windows.Forms.Label()
        CommentInternalLabel = New System.Windows.Forms.Label()
        CapturePercentLabel = New System.Windows.Forms.Label()
        EmissionPeriodTypeIDLabel = New System.Windows.Forms.Label()
        EmissionCalculationMethodIDLabel = New System.Windows.Forms.Label()
        EmissionFactorValueLabel = New System.Windows.Forms.Label()
        Me.EmissionFactorPanel.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessEmissionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessEmissionHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessDetailPeriodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PollutantBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.emissionPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ControlMeasureIDLabel
        '
        ControlMeasureIDLabel.AutoSize = True
        ControlMeasureIDLabel.Location = New System.Drawing.Point(13, 20)
        ControlMeasureIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ControlMeasureIDLabel.Name = "ControlMeasureIDLabel"
        ControlMeasureIDLabel.Size = New System.Drawing.Size(76, 17)
        ControlMeasureIDLabel.TabIndex = 41
        ControlMeasureIDLabel.Text = "* Pollutant:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.Location = New System.Drawing.Point(19, 278)
        CommentPublicLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(140, 41)
        CommentPublicLabel.TabIndex = 44
        CommentPublicLabel.Text = "APCD Public Comment:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.Location = New System.Drawing.Point(19, 383)
        CommentInternalLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(140, 39)
        CommentInternalLabel.TabIndex = 45
        CommentInternalLabel.Text = "APCD Confidential Comment:"
        '
        'CapturePercentLabel
        '
        CapturePercentLabel.AutoSize = True
        CapturePercentLabel.Location = New System.Drawing.Point(18, 241)
        CapturePercentLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CapturePercentLabel.Name = "CapturePercentLabel"
        CapturePercentLabel.Size = New System.Drawing.Size(84, 17)
        CapturePercentLabel.TabIndex = 43
        CapturePercentLabel.Text = "* Emissions:"
        '
        'EmissionPeriodTypeIDLabel
        '
        EmissionPeriodTypeIDLabel.AutoSize = True
        EmissionPeriodTypeIDLabel.Location = New System.Drawing.Point(13, 57)
        EmissionPeriodTypeIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmissionPeriodTypeIDLabel.Name = "EmissionPeriodTypeIDLabel"
        EmissionPeriodTypeIDLabel.Size = New System.Drawing.Size(62, 17)
        EmissionPeriodTypeIDLabel.TabIndex = 47
        EmissionPeriodTypeIDLabel.Text = "* Period:"
        '
        'EmissionCalculationMethodIDLabel
        '
        EmissionCalculationMethodIDLabel.AutoSize = True
        EmissionCalculationMethodIDLabel.Location = New System.Drawing.Point(13, 96)
        EmissionCalculationMethodIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmissionCalculationMethodIDLabel.Name = "EmissionCalculationMethodIDLabel"
        EmissionCalculationMethodIDLabel.Size = New System.Drawing.Size(141, 17)
        EmissionCalculationMethodIDLabel.TabIndex = 48
        EmissionCalculationMethodIDLabel.Text = "* Calculation Method:"
        '
        'EmissionFactorValueLabel
        '
        EmissionFactorValueLabel.AutoSize = True
        EmissionFactorValueLabel.Location = New System.Drawing.Point(13, 12)
        EmissionFactorValueLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        EmissionFactorValueLabel.Name = "EmissionFactorValueLabel"
        EmissionFactorValueLabel.Size = New System.Drawing.Size(121, 17)
        EmissionFactorValueLabel.TabIndex = 50
        EmissionFactorValueLabel.Text = "* Emission Factor:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(529, 507)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(421, 507)
        Me.OKButton.Margin = New System.Windows.Forms.Padding(4)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(100, 28)
        Me.OKButton.TabIndex = 5
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 17)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "* Required field"
        '
        'CommentPublicTextBox
        '
        Me.CommentPublicTextBox.Location = New System.Drawing.Point(164, 278)
        Me.CommentPublicTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.CommentPublicTextBox.MaxLength = 255
        Me.CommentPublicTextBox.Multiline = True
        Me.CommentPublicTextBox.Name = "CommentPublicTextBox"
        Me.CommentPublicTextBox.Size = New System.Drawing.Size(440, 83)
        Me.CommentPublicTextBox.TabIndex = 2
        '
        'PollutantComboBox
        '
        Me.PollutantComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.PollutantComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.PollutantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PollutantComboBox.FormattingEnabled = True
        Me.PollutantComboBox.Location = New System.Drawing.Point(159, 16)
        Me.PollutantComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PollutantComboBox.Name = "PollutantComboBox"
        Me.PollutantComboBox.Size = New System.Drawing.Size(440, 24)
        Me.PollutantComboBox.TabIndex = 0
        '
        'CommentInternalTextBox
        '
        Me.CommentInternalTextBox.Location = New System.Drawing.Point(164, 383)
        Me.CommentInternalTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.CommentInternalTextBox.MaxLength = 255
        Me.CommentInternalTextBox.Multiline = True
        Me.CommentInternalTextBox.Name = "CommentInternalTextBox"
        Me.CommentInternalTextBox.Size = New System.Drawing.Size(440, 83)
        Me.CommentInternalTextBox.TabIndex = 3
        '
        'EmissionValueTextBox
        '
        Me.EmissionValueTextBox.Location = New System.Drawing.Point(164, 237)
        Me.EmissionValueTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.EmissionValueTextBox.MaxLength = 12
        Me.EmissionValueTextBox.Name = "EmissionValueTextBox"
        Me.EmissionValueTextBox.Size = New System.Drawing.Size(112, 22)
        Me.EmissionValueTextBox.TabIndex = 2
        Me.EmissionValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EmissionFactorValueTextBox
        '
        Me.EmissionFactorValueTextBox.Location = New System.Drawing.Point(159, 9)
        Me.EmissionFactorValueTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.EmissionFactorValueTextBox.MaxLength = 15
        Me.EmissionFactorValueTextBox.Name = "EmissionFactorValueTextBox"
        Me.EmissionFactorValueTextBox.Size = New System.Drawing.Size(160, 22)
        Me.EmissionFactorValueTextBox.TabIndex = 0
        Me.EmissionFactorValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EmissionPeriodTypeComboBox
        '
        Me.EmissionPeriodTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmissionPeriodTypeComboBox.FormattingEnabled = True
        Me.EmissionPeriodTypeComboBox.Location = New System.Drawing.Point(159, 53)
        Me.EmissionPeriodTypeComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.EmissionPeriodTypeComboBox.Name = "EmissionPeriodTypeComboBox"
        Me.EmissionPeriodTypeComboBox.Size = New System.Drawing.Size(235, 24)
        Me.EmissionPeriodTypeComboBox.TabIndex = 1
        '
        'EmissionCalculationMethodComboBox
        '
        Me.EmissionCalculationMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmissionCalculationMethodComboBox.FormattingEnabled = True
        Me.EmissionCalculationMethodComboBox.Location = New System.Drawing.Point(159, 93)
        Me.EmissionCalculationMethodComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.EmissionCalculationMethodComboBox.Name = "EmissionCalculationMethodComboBox"
        Me.EmissionCalculationMethodComboBox.Size = New System.Drawing.Size(440, 24)
        Me.EmissionCalculationMethodComboBox.TabIndex = 3
        '
        'EmissionValueUnitOfMeasurementLabel
        '
        Me.EmissionValueUnitOfMeasurementLabel.AutoSize = True
        Me.EmissionValueUnitOfMeasurementLabel.Location = New System.Drawing.Point(288, 241)
        Me.EmissionValueUnitOfMeasurementLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.EmissionValueUnitOfMeasurementLabel.Name = "EmissionValueUnitOfMeasurementLabel"
        Me.EmissionValueUnitOfMeasurementLabel.Size = New System.Drawing.Size(51, 17)
        Me.EmissionValueUnitOfMeasurementLabel.TabIndex = 55
        Me.EmissionValueUnitOfMeasurementLabel.Text = "Label2"
        '
        'EmissionFactorValueUnitOfMeasurementLabel
        '
        Me.EmissionFactorValueUnitOfMeasurementLabel.AutoSize = True
        Me.EmissionFactorValueUnitOfMeasurementLabel.Location = New System.Drawing.Point(328, 12)
        Me.EmissionFactorValueUnitOfMeasurementLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.EmissionFactorValueUnitOfMeasurementLabel.Name = "EmissionFactorValueUnitOfMeasurementLabel"
        Me.EmissionFactorValueUnitOfMeasurementLabel.Size = New System.Drawing.Size(51, 17)
        Me.EmissionFactorValueUnitOfMeasurementLabel.TabIndex = 56
        Me.EmissionFactorValueUnitOfMeasurementLabel.Text = "Label3"
        '
        'EmissionFactorPanel
        '
        Me.EmissionFactorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EmissionFactorPanel.Controls.Add(EmissionFactorValueLabel)
        Me.EmissionFactorPanel.Controls.Add(Me.EmissionFactorValueUnitOfMeasurementLabel)
        Me.EmissionFactorPanel.Controls.Add(Me.EmissionFactorValueTextBox)
        Me.EmissionFactorPanel.Location = New System.Drawing.Point(3, 180)
        Me.EmissionFactorPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.EmissionFactorPanel.Name = "EmissionFactorPanel"
        Me.EmissionFactorPanel.Size = New System.Drawing.Size(625, 41)
        Me.EmissionFactorPanel.TabIndex = 1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ProcessDataSet
        '
        Me.ProcessDataSet.DataSetName = "ProcessDataSet"
        Me.ProcessDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProcessEmissionBindingSource
        '
        Me.ProcessEmissionBindingSource.DataMember = "ProcessEmission"
        Me.ProcessEmissionBindingSource.DataSource = Me.ProcessDataSet
        '
        'ProcessEmissionTableAdapter
        '
        Me.ProcessEmissionTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.EmissionPeriodTypeTableAdapter = Nothing
        Me.TableAdapterManager.PollutantTableAdapter = Nothing
        Me.TableAdapterManager.ProcessDetailPeriodTableAdapter = Nothing
        Me.TableAdapterManager.ProcessEmissionHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessEmissionTableAdapter = Me.ProcessEmissionTableAdapter
        Me.TableAdapterManager.UpdateOrder = APCD.EmissionsInventory.ProcessDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ProcessEmissionHistoryBindingSource
        '
        Me.ProcessEmissionHistoryBindingSource.DataMember = "ProcessEmissionHistory"
        Me.ProcessEmissionHistoryBindingSource.DataSource = Me.ProcessDataSet
        '
        'ProcessEmissionHistoryTableAdapter
        '
        Me.ProcessEmissionHistoryTableAdapter.ClearBeforeFill = True
        '
        'ProcessDetailPeriodBindingSource
        '
        Me.ProcessDetailPeriodBindingSource.DataMember = "ProcessDetailPeriod"
        Me.ProcessDetailPeriodBindingSource.DataSource = Me.ProcessDataSet
        '
        'ProcessDetailPeriodTableAdapter
        '
        Me.ProcessDetailPeriodTableAdapter.ClearBeforeFill = True
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PollutantBindingSource1
        '
        Me.PollutantBindingSource1.DataMember = "Pollutant"
        Me.PollutantBindingSource1.DataSource = Me.EmissionsDataSet
        '
        'PollutantTableAdapter1
        '
        Me.PollutantTableAdapter1.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.AffiliationTypeEISTableAdapter = Nothing
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.BillingContactsTableAdapter = Nothing
        Me.TableAdapterManager1.BillingFeeConfigTableAdapter = Nothing
        Me.TableAdapterManager1.BillingHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.BillingTableAdapter = Nothing
        Me.TableAdapterManager1.ControlMeasureHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ControlMeasurePollutantHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ControlMeasurePollutantTableAdapter = Nothing
        Me.TableAdapterManager1.ControlMeasureTableAdapter = Nothing
        Me.TableAdapterManager1.ControlMeasureTypeTableAdapter = Nothing
        Me.TableAdapterManager1.ControlMeasureYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ControlMeasureYearTableAdapter = Nothing
        Me.TableAdapterManager1.EmissionUnitDetailTypeTableAdapter = Nothing
        Me.TableAdapterManager1.EmissionUnitTypeGroupTableAdapter = Nothing
        Me.TableAdapterManager1.EmissionUnitTypeTableAdapter = Nothing
        Me.TableAdapterManager1.EmissionYearTableAdapter = Nothing
        Me.TableAdapterManager1.FacilityCategoryEISTableAdapter = Nothing
        Me.TableAdapterManager1.FacilitySiteStatusTypeEISTableAdapter = Nothing
        Me.TableAdapterManager1.FormTableAdapter = Nothing
        Me.TableAdapterManager1.MeasurementTableAdapter = Nothing
        Me.TableAdapterManager1.OperatingStatusTypeEISTableAdapter = Nothing
        Me.TableAdapterManager1.PlantEmissionUnitDetailTableAdapter = Nothing
        Me.TableAdapterManager1.PlantEmissionUnitHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.PlantEmissionUnitTableAdapter = Nothing
        Me.TableAdapterManager1.PlantEmissionUnitYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.PlantEmissionUnitYearTableAdapter = Nothing
        Me.TableAdapterManager1.PlantTableAdapter = Nothing
        Me.TableAdapterManager1.PlantYearContactsTableAdapter = Nothing
        Me.TableAdapterManager1.PlantYearFormTableAdapter = Nothing
        Me.TableAdapterManager1.PlantYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.PlantYearTableAdapter = Nothing
        Me.TableAdapterManager1.PollutantTableAdapter = Me.PollutantTableAdapter1
        Me.TableAdapterManager1.PreBillingTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessClassLevel1TypeTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessClassLevel2TypeTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessClassLevel3TypeTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessClassLevel4TypeTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessClassTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessControlMeasureHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessControlMeasureTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessDetailPeriodHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessDetailPeriodTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessEmissionHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessEmissionTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessReleasePointHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessReleasePointTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessSeasonalActivityHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessSeasonalActivityTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ProcessYearTableAdapter = Nothing
        Me.TableAdapterManager1.ReleasePointDetailHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ReleasePointDetailTableAdapter = Nothing
        Me.TableAdapterManager1.ReleasePointHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ReleasePointTableAdapter = Nothing
        Me.TableAdapterManager1.ReleasePointTypeTableAdapter = Nothing
        Me.TableAdapterManager1.ReleasePointYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.ReleasePointYearTableAdapter = Nothing
        Me.TableAdapterManager1.ReleaseTypeMeasurementTableAdapter = Nothing
        Me.TableAdapterManager1.ReleaseTypeSubTypeTableAdapter = Nothing
        Me.TableAdapterManager1.ReleaseTypeTableAdapter = Nothing
        Me.TableAdapterManager1.ThroughputTypeTableAdapter = Nothing
        Me.TableAdapterManager1.UnitOfMeasurementTableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'emissionPanel
        '
        Me.emissionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.emissionPanel.Controls.Add(Me.PollutantComboBox)
        Me.emissionPanel.Controls.Add(ControlMeasureIDLabel)
        Me.emissionPanel.Controls.Add(Me.EmissionCalculationMethodComboBox)
        Me.emissionPanel.Controls.Add(EmissionCalculationMethodIDLabel)
        Me.emissionPanel.Controls.Add(EmissionPeriodTypeIDLabel)
        Me.emissionPanel.Controls.Add(Me.EmissionPeriodTypeComboBox)
        Me.emissionPanel.Location = New System.Drawing.Point(3, 34)
        Me.emissionPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.emissionPanel.Name = "emissionPanel"
        Me.emissionPanel.Size = New System.Drawing.Size(625, 138)
        Me.emissionPanel.TabIndex = 0
        '
        'ProcessEmissionsAddEditForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(645, 550)
        Me.ControlBox = False
        Me.Controls.Add(Me.emissionPanel)
        Me.Controls.Add(Me.EmissionFactorPanel)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.EmissionValueUnitOfMeasurementLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CommentPublicTextBox)
        Me.Controls.Add(Me.CommentInternalTextBox)
        Me.Controls.Add(Me.EmissionValueTextBox)
        Me.Controls.Add(CommentPublicLabel)
        Me.Controls.Add(CapturePercentLabel)
        Me.Controls.Add(CommentInternalLabel)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ProcessEmissionsAddEditForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ProcessEmissionsAddEditForm"
        Me.EmissionFactorPanel.ResumeLayout(False)
        Me.EmissionFactorPanel.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessEmissionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessEmissionHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessDetailPeriodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PollutantBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.emissionPanel.ResumeLayout(False)
        Me.emissionPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CommentPublicTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PollutantComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CommentInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmissionValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QryProcessAddFormEmissionsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionCalculationMethodComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents EmissionPeriodTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents EmissionFactorValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmissionValueUnitOfMeasurementLabel As System.Windows.Forms.Label
    Friend WithEvents EmissionFactorValueUnitOfMeasurementLabel As System.Windows.Forms.Label
    Friend WithEvents EmissionFactorPanel As System.Windows.Forms.Panel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ProcessDataSet As APCD.EmissionsInventory.ProcessDataSet
    Friend WithEvents ProcessEmissionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessEmissionTableAdapter As APCD.EmissionsInventory.ProcessDataSetTableAdapters.ProcessEmissionTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.ProcessDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ProcessEmissionHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessEmissionHistoryTableAdapter As APCD.EmissionsInventory.ProcessDataSetTableAdapters.ProcessEmissionHistoryTableAdapter
    Friend WithEvents ProcessDetailPeriodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessDetailPeriodTableAdapter As APCD.EmissionsInventory.ProcessDataSetTableAdapters.ProcessDetailPeriodTableAdapter
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents PollutantBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents PollutantTableAdapter1 As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PollutantTableAdapter
    Friend WithEvents TableAdapterManager1 As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents emissionPanel As System.Windows.Forms.Panel
End Class
