<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessThroughputAddEditForm
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
        Dim Label2 As System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProcessParameterComboBox = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ProcessParameterValueTextBox = New System.Windows.Forms.TextBox()
        Me.UnitOfMeasurementComboBox = New System.Windows.Forms.ComboBox()
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.ProcessDetailPeriodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessDetailPeriodTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessDetailPeriodTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ProcessDetailPeriodHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessDetailPeriodHistoryTableAdapter()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ProcessDetailPeriodHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UnitOfMeasurementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UnitOfMeasurementTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.UnitOfMeasurementTableAdapter()
        ControlMeasureIDLabel = New System.Windows.Forms.Label()
        CapturePercentLabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessDetailPeriodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessDetailPeriodHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnitOfMeasurementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ControlMeasureIDLabel
        '
        ControlMeasureIDLabel.AutoSize = True
        ControlMeasureIDLabel.Location = New System.Drawing.Point(7, 51)
        ControlMeasureIDLabel.Name = "ControlMeasureIDLabel"
        ControlMeasureIDLabel.Size = New System.Drawing.Size(65, 13)
        ControlMeasureIDLabel.TabIndex = 41
        ControlMeasureIDLabel.Text = "* Parameter:"
        '
        'CapturePercentLabel
        '
        CapturePercentLabel.AutoSize = True
        CapturePercentLabel.Location = New System.Drawing.Point(7, 77)
        CapturePercentLabel.Name = "CapturePercentLabel"
        CapturePercentLabel.Size = New System.Drawing.Size(44, 13)
        CapturePercentLabel.TabIndex = 43
        CapturePercentLabel.Text = "* Value:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(7, 103)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(41, 13)
        Label2.TabIndex = 41
        Label2.Text = "* Units:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(357, 152)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(276, 152)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 3
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "* Required field"
        '
        'ProcessParameterComboBox
        '
        Me.ProcessParameterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProcessParameterComboBox.FormattingEnabled = True
        Me.ProcessParameterComboBox.Location = New System.Drawing.Point(113, 47)
        Me.ProcessParameterComboBox.Name = "ProcessParameterComboBox"
        Me.ProcessParameterComboBox.Size = New System.Drawing.Size(225, 21)
        Me.ProcessParameterComboBox.TabIndex = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ProcessParameterValueTextBox
        '
        Me.ProcessParameterValueTextBox.Location = New System.Drawing.Point(113, 74)
        Me.ProcessParameterValueTextBox.MaxLength = 10
        Me.ProcessParameterValueTextBox.Name = "ProcessParameterValueTextBox"
        Me.ProcessParameterValueTextBox.Size = New System.Drawing.Size(79, 20)
        Me.ProcessParameterValueTextBox.TabIndex = 1
        '
        'UnitOfMeasurementComboBox
        '
        Me.UnitOfMeasurementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UnitOfMeasurementComboBox.FormattingEnabled = True
        Me.UnitOfMeasurementComboBox.Location = New System.Drawing.Point(113, 100)
        Me.UnitOfMeasurementComboBox.Name = "UnitOfMeasurementComboBox"
        Me.UnitOfMeasurementComboBox.Size = New System.Drawing.Size(225, 21)
        Me.UnitOfMeasurementComboBox.TabIndex = 2
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProcessDetailPeriodBindingSource
        '
        Me.ProcessDetailPeriodBindingSource.DataMember = "ProcessDetailPeriod"
        Me.ProcessDetailPeriodBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessDetailPeriodTableAdapter
        '
        Me.ProcessDetailPeriodTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.ProcessDetailPeriodHistoryTableAdapter = Me.ProcessDetailPeriodHistoryTableAdapter
        Me.TableAdapterManager.ProcessDetailPeriodTableAdapter = Me.ProcessDetailPeriodTableAdapter
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
        Me.TableAdapterManager.UnitOfMeasurementTableAdapter = Me.UnitOfMeasurementTableAdapter
        Me.TableAdapterManager.UpdateOrder = APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ProcessDetailPeriodHistoryTableAdapter
        '
        Me.ProcessDetailPeriodHistoryTableAdapter.ClearBeforeFill = True
        '
        'ProcessDetailPeriodHistoryBindingSource
        '
        Me.ProcessDetailPeriodHistoryBindingSource.DataMember = "ProcessDetailPeriodHistory"
        Me.ProcessDetailPeriodHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'UnitOfMeasurementBindingSource
        '
        Me.UnitOfMeasurementBindingSource.DataMember = "UnitOfMeasurement"
        Me.UnitOfMeasurementBindingSource.DataSource = Me.EmissionsDataSet
        '
        'UnitOfMeasurementTableAdapter
        '
        Me.UnitOfMeasurementTableAdapter.ClearBeforeFill = True
        '
        'ProcessThroughputAddEditForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(444, 187)
        Me.ControlBox = False
        Me.Controls.Add(Me.UnitOfMeasurementComboBox)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProcessParameterComboBox)
        Me.Controls.Add(Label2)
        Me.Controls.Add(ControlMeasureIDLabel)
        Me.Controls.Add(CapturePercentLabel)
        Me.Controls.Add(Me.ProcessParameterValueTextBox)
        Me.Name = "ProcessThroughputAddEditForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ProcessThroughputAddEditForm"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessDetailPeriodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessDetailPeriodHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnitOfMeasurementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProcessParameterComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ProcessParameterValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UnitOfMeasurementComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProcessDetailPeriodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ProcessDetailPeriodTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessDetailPeriodTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ProcessDetailPeriodHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessDetailPeriodHistoryTableAdapter
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ProcessDetailPeriodHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UnitOfMeasurementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UnitOfMeasurementTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.UnitOfMeasurementTableAdapter
End Class
