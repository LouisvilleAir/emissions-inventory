<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessControlMeasureAddEditForm
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
        Dim CapturePercentLabel As System.Windows.Forms.Label
        Dim CommentPublicLabel As System.Windows.Forms.Label
        Dim CommentInternalLabel As System.Windows.Forms.Label
        Dim UptimePercentLabel As System.Windows.Forms.Label
        Dim SequenceLabel As System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CommentPublicTextBox = New System.Windows.Forms.TextBox()
        Me.CommentInternalTextBox = New System.Windows.Forms.TextBox()
        Me.ControlMeasureComboBox = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CapturePercentTextBox = New System.Windows.Forms.TextBox()
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.ProcessControlMeasureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessControlMeasureTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessControlMeasureTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ControlMeasureTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTableAdapter()
        Me.ControlMeasureTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTypeTableAdapter()
        Me.ProcessControlMeasureHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessControlMeasureHistoryTableAdapter()
        Me.ProcessControlMeasureHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UptimePercentTextBox = New System.Windows.Forms.TextBox()
        Me.SequenceTextBox = New System.Windows.Forms.TextBox()
        Me.ControlMeasureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        ControlMeasureIDLabel = New System.Windows.Forms.Label()
        CapturePercentLabel = New System.Windows.Forms.Label()
        CommentPublicLabel = New System.Windows.Forms.Label()
        CommentInternalLabel = New System.Windows.Forms.Label()
        UptimePercentLabel = New System.Windows.Forms.Label()
        SequenceLabel = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessControlMeasureHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ControlMeasureIDLabel
        '
        ControlMeasureIDLabel.AutoSize = True
        ControlMeasureIDLabel.Location = New System.Drawing.Point(9, 53)
        ControlMeasureIDLabel.Name = "ControlMeasureIDLabel"
        ControlMeasureIDLabel.Size = New System.Drawing.Size(94, 13)
        ControlMeasureIDLabel.TabIndex = 30
        ControlMeasureIDLabel.Text = "* Control Measure:"
        '
        'CapturePercentLabel
        '
        CapturePercentLabel.AutoSize = True
        CapturePercentLabel.Location = New System.Drawing.Point(9, 79)
        CapturePercentLabel.Name = "CapturePercentLabel"
        CapturePercentLabel.Size = New System.Drawing.Size(94, 13)
        CapturePercentLabel.TabIndex = 32
        CapturePercentLabel.Text = "* Capture Percent:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.Location = New System.Drawing.Point(17, 165)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(96, 39)
        CommentPublicLabel.TabIndex = 33
        CommentPublicLabel.Text = "APCD Public Comment:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.Location = New System.Drawing.Point(17, 250)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(96, 34)
        CommentInternalLabel.TabIndex = 34
        CommentInternalLabel.Text = "APCD Confidential Comment:"
        '
        'UptimePercentLabel
        '
        UptimePercentLabel.AutoSize = True
        UptimePercentLabel.Location = New System.Drawing.Point(12, 106)
        UptimePercentLabel.Name = "UptimePercentLabel"
        UptimePercentLabel.Size = New System.Drawing.Size(90, 13)
        UptimePercentLabel.TabIndex = 35
        UptimePercentLabel.Text = "* Uptime Percent:"
        '
        'SequenceLabel
        '
        SequenceLabel.AutoSize = True
        SequenceLabel.Location = New System.Drawing.Point(12, 132)
        SequenceLabel.Name = "SequenceLabel"
        SequenceLabel.Size = New System.Drawing.Size(66, 13)
        SequenceLabel.TabIndex = 36
        SequenceLabel.Text = "* Sequence:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(383, 365)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(302, 365)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 7
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "* Required field"
        '
        'CommentPublicTextBox
        '
        Me.CommentPublicTextBox.Location = New System.Drawing.Point(115, 165)
        Me.CommentPublicTextBox.MaxLength = 255
        Me.CommentPublicTextBox.Multiline = True
        Me.CommentPublicTextBox.Name = "CommentPublicTextBox"
        Me.CommentPublicTextBox.Size = New System.Drawing.Size(325, 68)
        Me.CommentPublicTextBox.TabIndex = 4
        '
        'CommentInternalTextBox
        '
        Me.CommentInternalTextBox.Location = New System.Drawing.Point(115, 250)
        Me.CommentInternalTextBox.MaxLength = 255
        Me.CommentInternalTextBox.Multiline = True
        Me.CommentInternalTextBox.Name = "CommentInternalTextBox"
        Me.CommentInternalTextBox.Size = New System.Drawing.Size(325, 68)
        Me.CommentInternalTextBox.TabIndex = 5
        '
        'ControlMeasureComboBox
        '
        Me.ControlMeasureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ControlMeasureComboBox.FormattingEnabled = True
        Me.ControlMeasureComboBox.Location = New System.Drawing.Point(115, 49)
        Me.ControlMeasureComboBox.Name = "ControlMeasureComboBox"
        Me.ControlMeasureComboBox.Size = New System.Drawing.Size(225, 21)
        Me.ControlMeasureComboBox.TabIndex = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'CapturePercentTextBox
        '
        Me.CapturePercentTextBox.Location = New System.Drawing.Point(115, 76)
        Me.CapturePercentTextBox.MaxLength = 4
        Me.CapturePercentTextBox.Name = "CapturePercentTextBox"
        Me.CapturePercentTextBox.Size = New System.Drawing.Size(30, 20)
        Me.CapturePercentTextBox.TabIndex = 1
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProcessControlMeasureBindingSource
        '
        Me.ProcessControlMeasureBindingSource.DataMember = "ProcessControlMeasure"
        Me.ProcessControlMeasureBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessControlMeasureTableAdapter
        '
        Me.ProcessControlMeasureTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.ControlMeasureTableAdapter = Me.ControlMeasureTableAdapter
        Me.TableAdapterManager.ControlMeasureTypeTableAdapter = Me.ControlMeasureTypeTableAdapter
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
        Me.TableAdapterManager.ProcessControlMeasureHistoryTableAdapter = Me.ProcessControlMeasureHistoryTableAdapter
        Me.TableAdapterManager.ProcessControlMeasureTableAdapter = Me.ProcessControlMeasureTableAdapter
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
        'ControlMeasureTableAdapter
        '
        Me.ControlMeasureTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasureTypeTableAdapter
        '
        Me.ControlMeasureTypeTableAdapter.ClearBeforeFill = True
        '
        'ProcessControlMeasureHistoryTableAdapter
        '
        Me.ProcessControlMeasureHistoryTableAdapter.ClearBeforeFill = True
        '
        'ProcessControlMeasureHistoryBindingSource
        '
        Me.ProcessControlMeasureHistoryBindingSource.DataMember = "ProcessControlMeasureHistory"
        Me.ProcessControlMeasureHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'UptimePercentTextBox
        '
        Me.UptimePercentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProcessControlMeasureHistoryBindingSource, "UptimePercent", True))
        Me.UptimePercentTextBox.Location = New System.Drawing.Point(115, 103)
        Me.UptimePercentTextBox.MaxLength = 3
        Me.UptimePercentTextBox.Name = "UptimePercentTextBox"
        Me.UptimePercentTextBox.Size = New System.Drawing.Size(30, 20)
        Me.UptimePercentTextBox.TabIndex = 2
        '
        'SequenceTextBox
        '
        Me.SequenceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProcessControlMeasureHistoryBindingSource, "Sequence", True))
        Me.SequenceTextBox.Location = New System.Drawing.Point(115, 132)
        Me.SequenceTextBox.MaxLength = 2
        Me.SequenceTextBox.Name = "SequenceTextBox"
        Me.SequenceTextBox.Size = New System.Drawing.Size(30, 20)
        Me.SequenceTextBox.TabIndex = 3
        '
        'ControlMeasureBindingSource
        '
        Me.ControlMeasureBindingSource.DataMember = "ControlMeasure"
        Me.ControlMeasureBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasureTypeBindingSource
        '
        Me.ControlMeasureTypeBindingSource.DataMember = "ControlMeasureType"
        Me.ControlMeasureTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessControlMeasureAddEditForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(470, 400)
        Me.ControlBox = False
        Me.Controls.Add(SequenceLabel)
        Me.Controls.Add(Me.SequenceTextBox)
        Me.Controls.Add(UptimePercentLabel)
        Me.Controls.Add(Me.UptimePercentTextBox)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CommentPublicTextBox)
        Me.Controls.Add(Me.CommentInternalTextBox)
        Me.Controls.Add(Me.ControlMeasureComboBox)
        Me.Controls.Add(ControlMeasureIDLabel)
        Me.Controls.Add(CapturePercentLabel)
        Me.Controls.Add(Me.CapturePercentTextBox)
        Me.Controls.Add(CommentPublicLabel)
        Me.Controls.Add(CommentInternalLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ProcessControlMeasureAddEditForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ProcessControlMeasureAddEditForm"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessControlMeasureHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CommentPublicTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ControlMeasureComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents CapturePercentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProcessControlMeasureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ProcessControlMeasureTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessControlMeasureTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ProcessControlMeasureHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessControlMeasureHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessControlMeasureHistoryTableAdapter
    Friend WithEvents SequenceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UptimePercentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ControlMeasureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTableAdapter
    Friend WithEvents ControlMeasureTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTypeTableAdapter
End Class
