<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnnualNotification
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
        Me.PlantYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearTableAdapter()
        Me.PlantYearContactsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.PlantYearContactsTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearContactsTableAdapter()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.EmissionsDataSet1 = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PlantYearTableAdapter1 = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearTableAdapter()
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableAdapterManager1 = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.PlantYearContactsTableAdapter1 = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearContactsTableAdapter()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantYearContactsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionsDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PlantYearBindingSource
        '
        Me.PlantYearBindingSource.DataMember = "PlantYear"
        Me.PlantYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PlantYearTableAdapter
        '
        Me.PlantYearTableAdapter.ClearBeforeFill = True
        '
        'PlantYearContactsBindingSource
        '
        Me.PlantYearContactsBindingSource.DataMember = "PlantYearContacts"
        Me.PlantYearContactsBindingSource.DataSource = Me.EmissionsDataSet
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
        Me.TableAdapterManager.PlantYearContactsTableAdapter = Me.PlantYearContactsTableAdapter
        Me.TableAdapterManager.PlantYearFormTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearTableAdapter = Me.PlantYearTableAdapter
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
        'PlantYearContactsTableAdapter
        '
        Me.PlantYearContactsTableAdapter.ClearBeforeFill = True
        '
        'Timer1
        '
        '
        'EmissionsDataSet1
        '
        Me.EmissionsDataSet1.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(20, 70)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(343, 18)
        Me.ProgressBar1.TabIndex = 3
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "PlantYear"
        Me.BindingSource1.DataSource = Me.EmissionsDataSet1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 50)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(343, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Preparing to generate letters..."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlantYearTableAdapter1
        '
        Me.PlantYearTableAdapter1.ClearBeforeFill = True
        '
        'BindingSource2
        '
        Me.BindingSource2.DataMember = "PlantYearContacts"
        Me.BindingSource2.DataSource = Me.EmissionsDataSet1
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
        Me.TableAdapterManager1.PlantYearContactsTableAdapter = Me.PlantYearContactsTableAdapter1
        Me.TableAdapterManager1.PlantYearFormTableAdapter = Nothing
        Me.TableAdapterManager1.PlantYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager1.PlantYearTableAdapter = Me.PlantYearTableAdapter1
        Me.TableAdapterManager1.PollutantTableAdapter = Nothing
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
        'PlantYearContactsTableAdapter1
        '
        Me.PlantYearContactsTableAdapter1.ClearBeforeFill = True
        '
        'AnnualNotification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 138)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AnnualNotification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Annual Notifications"
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantYearContactsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionsDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents PlantYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearTableAdapter
    Friend WithEvents PlantYearContactsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PlantYearContactsTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearContactsTableAdapter
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents EmissionsDataSet1 As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PlantYearTableAdapter1 As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearTableAdapter
    Friend WithEvents BindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents TableAdapterManager1 As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PlantYearContactsTableAdapter1 As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearContactsTableAdapter
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
