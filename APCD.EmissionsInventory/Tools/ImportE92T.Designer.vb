<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportE92T
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
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.waitTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ControlMeasureDataSet = New APCD.EmissionsInventory.ControlMeasureDataSet()
        Me.ControlMeasureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureTableAdapter = New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasureTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.TableAdapterManager()
        Me.AutoE92T_ControlsPollutantsTableAdapter = New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.autoE92T_ControlsPollutantsTableAdapter()
        Me.ControlMeasureHistoryTableAdapter = New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasureHistoryTableAdapter()
        Me.ControlMeasurePollutantHistoryTableAdapter = New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasurePollutantHistoryTableAdapter()
        Me.ControlMeasurePollutantTableAdapter = New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasurePollutantTableAdapter()
        Me.ControlMeasureTypeTableAdapter = New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasureTypeTableAdapter()
        Me.ControlMeasureYearTableAdapter = New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasureYearTableAdapter()
        Me.ControlMeasureHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasurePollutantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasurePollutantHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmissionYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmissionYearTableAdapter = New APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.EmissionYearTableAdapter()
        Me.AutoE92T_ControlsPollutantsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ControlMeasureDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasurePollutantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasurePollutantHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutoE92T_ControlsPollutantsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(12, 17)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(213, 13)
        Me.lblProgress.TabIndex = 5
        Me.lblProgress.Text = "Please select the Excel workbook to import."
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(14, 77)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 4
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(197, 77)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(14, 50)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(257, 13)
        Me.ProgressBar1.TabIndex = 7
        Me.ProgressBar1.Visible = False
        '
        'waitTimer
        '
        Me.waitTimer.Interval = 1000
        '
        'ControlMeasureDataSet
        '
        Me.ControlMeasureDataSet.DataSetName = "ControlMeasureDataSet"
        Me.ControlMeasureDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ControlMeasureBindingSource
        '
        Me.ControlMeasureBindingSource.DataMember = "ControlMeasure"
        Me.ControlMeasureBindingSource.DataSource = Me.ControlMeasureDataSet
        '
        'ControlMeasureTableAdapter
        '
        Me.ControlMeasureTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.autoE92T_ControlsPollutantsTableAdapter = Me.AutoE92T_ControlsPollutantsTableAdapter
        Me.TableAdapterManager.autoE92T_ControlsTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.ControlMeasureHistoryTableAdapter = Me.ControlMeasureHistoryTableAdapter
        Me.TableAdapterManager.ControlMeasurePollutantHistoryTableAdapter = Me.ControlMeasurePollutantHistoryTableAdapter
        Me.TableAdapterManager.ControlMeasurePollutantTableAdapter = Me.ControlMeasurePollutantTableAdapter
        Me.TableAdapterManager.ControlMeasureTableAdapter = Me.ControlMeasureTableAdapter
        Me.TableAdapterManager.ControlMeasureTypeTableAdapter = Me.ControlMeasureTypeTableAdapter
        Me.TableAdapterManager.ControlMeasureYearTableAdapter = Me.ControlMeasureYearTableAdapter
        Me.TableAdapterManager.EmissionYearTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'AutoE92T_ControlsPollutantsTableAdapter
        '
        Me.AutoE92T_ControlsPollutantsTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasureHistoryTableAdapter
        '
        Me.ControlMeasureHistoryTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasurePollutantHistoryTableAdapter
        '
        Me.ControlMeasurePollutantHistoryTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasurePollutantTableAdapter
        '
        Me.ControlMeasurePollutantTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasureTypeTableAdapter
        '
        Me.ControlMeasureTypeTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasureYearTableAdapter
        '
        Me.ControlMeasureYearTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasureHistoryBindingSource
        '
        Me.ControlMeasureHistoryBindingSource.DataMember = "ControlMeasureHistory"
        Me.ControlMeasureHistoryBindingSource.DataSource = Me.ControlMeasureDataSet
        '
        'ControlMeasurePollutantBindingSource
        '
        Me.ControlMeasurePollutantBindingSource.DataMember = "ControlMeasurePollutant"
        Me.ControlMeasurePollutantBindingSource.DataSource = Me.ControlMeasureDataSet
        '
        'ControlMeasurePollutantHistoryBindingSource
        '
        Me.ControlMeasurePollutantHistoryBindingSource.DataMember = "ControlMeasurePollutantHistory"
        Me.ControlMeasurePollutantHistoryBindingSource.DataSource = Me.ControlMeasureDataSet
        '
        'ControlMeasureTypeBindingSource
        '
        Me.ControlMeasureTypeBindingSource.DataMember = "ControlMeasureType"
        Me.ControlMeasureTypeBindingSource.DataSource = Me.ControlMeasureDataSet
        '
        'ControlMeasureYearBindingSource
        '
        Me.ControlMeasureYearBindingSource.DataMember = "ControlMeasureYear"
        Me.ControlMeasureYearBindingSource.DataSource = Me.ControlMeasureDataSet
        '
        'EmissionYearBindingSource
        '
        Me.EmissionYearBindingSource.DataMember = "EmissionYear"
        Me.EmissionYearBindingSource.DataSource = Me.ControlMeasureDataSet
        '
        'EmissionYearTableAdapter
        '
        Me.EmissionYearTableAdapter.ClearBeforeFill = True
        '
        'AutoE92T_ControlsPollutantsBindingSource
        '
        Me.AutoE92T_ControlsPollutantsBindingSource.DataMember = "autoE92T_ControlsPollutants"
        Me.AutoE92T_ControlsPollutantsBindingSource.DataSource = Me.ControlMeasureDataSet
        '
        'ImportE92T
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 112)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.btnBrowse)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ImportE92T"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import E92T"
        CType(Me.ControlMeasureDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasurePollutantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasurePollutantHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutoE92T_ControlsPollutantsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ControlMeasureDataSet As APCD.EmissionsInventory.ControlMeasureDataSet
    Friend WithEvents ControlMeasureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureTableAdapter As APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasureTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ControlMeasureHistoryTableAdapter As APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasureHistoryTableAdapter
    Friend WithEvents ControlMeasureHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasurePollutantTableAdapter As APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasurePollutantTableAdapter
    Friend WithEvents ControlMeasurePollutantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasurePollutantHistoryTableAdapter As APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasurePollutantHistoryTableAdapter
    Friend WithEvents ControlMeasurePollutantHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureTypeTableAdapter As APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasureTypeTableAdapter
    Friend WithEvents ControlMeasureTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureYearTableAdapter As APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.ControlMeasureYearTableAdapter
    Friend WithEvents ControlMeasureYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionYearTableAdapter As APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.EmissionYearTableAdapter
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents waitTimer As System.Windows.Forms.Timer
    Friend WithEvents AutoE92T_ControlsPollutantsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AutoE92T_ControlsPollutantsTableAdapter As APCD.EmissionsInventory.ControlMeasureDataSetTableAdapters.autoE92T_ControlsPollutantsTableAdapter
End Class
