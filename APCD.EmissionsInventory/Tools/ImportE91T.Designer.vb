<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportE91T
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
        Me.ReleasePointDataSet = New APCD.EmissionsInventory.ReleasePointDataSet()
        Me.AutoE91T_FugitivesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AutoE91T_StacksBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointTypeTableAdapter = New APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointTypeTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.TableAdapterManager()
        Me.ReleasePointBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointTableAdapter = New APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointTableAdapter()
        Me.ReleasePointDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointDetailTableAdapter = New APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointDetailTableAdapter()
        Me.ReleasePointHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointHistoryTableAdapter = New APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointHistoryTableAdapter()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ReleasePointDetailHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointDetailHistoryTableAdapter = New APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointDetailHistoryTableAdapter()
        Me.ReleasePointYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointYearTableAdapter = New APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointYearTableAdapter()
        Me.EmissionYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmissionYearTableAdapter = New APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.EmissionYearTableAdapter()
        CType(Me.ReleasePointDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutoE91T_FugitivesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutoE91T_StacksBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointDetailHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(14, 17)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(213, 13)
        Me.lblProgress.TabIndex = 3
        Me.lblProgress.Text = "Please select the Excel workbook to import."
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(14, 77)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse..."
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
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ReleasePointDataSet
        '
        Me.ReleasePointDataSet.DataSetName = "ReleasePointDataSet"
        Me.ReleasePointDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AutoE91T_FugitivesBindingSource
        '
        Me.AutoE91T_FugitivesBindingSource.DataMember = "autoE91T_Fugitives"
        Me.AutoE91T_FugitivesBindingSource.DataSource = Me.ReleasePointDataSet
        '
        'AutoE91T_StacksBindingSource
        '
        Me.AutoE91T_StacksBindingSource.DataMember = "autoE91T_Stacks"
        Me.AutoE91T_StacksBindingSource.DataSource = Me.ReleasePointDataSet
        '
        'ReleasePointTypeBindingSource
        '
        Me.ReleasePointTypeBindingSource.DataMember = "ReleasePointType"
        Me.ReleasePointTypeBindingSource.DataSource = Me.ReleasePointDataSet
        '
        'ReleasePointTypeTableAdapter
        '
        Me.ReleasePointTypeTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.autoE91T_FugitivesTableAdapter = Nothing
        Me.TableAdapterManager.autoE91T_StacksTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.EmissionYearTableAdapter = Nothing
        Me.TableAdapterManager.MeasurementTableAdapter = Nothing
        Me.TableAdapterManager.ProcessReleasePointTableAdapter = Nothing
        Me.TableAdapterManager.ProcessTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointDetailHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointDetailMeasurementUnitOfMeasurementTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointDetailTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointTypeTableAdapter = Me.ReleasePointTypeTableAdapter
        Me.TableAdapterManager.ReleasePointYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointYearTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeMeasurementTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeSubTypeTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeTableAdapter = Nothing
        Me.TableAdapterManager.UnitOfMeasurementTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ReleasePointBindingSource
        '
        Me.ReleasePointBindingSource.DataMember = "ReleasePoint"
        Me.ReleasePointBindingSource.DataSource = Me.ReleasePointDataSet
        '
        'ReleasePointTableAdapter
        '
        Me.ReleasePointTableAdapter.ClearBeforeFill = True
        '
        'ReleasePointDetailBindingSource
        '
        Me.ReleasePointDetailBindingSource.DataMember = "ReleasePointDetail"
        Me.ReleasePointDetailBindingSource.DataSource = Me.ReleasePointDataSet
        '
        'ReleasePointDetailTableAdapter
        '
        Me.ReleasePointDetailTableAdapter.ClearBeforeFill = True
        '
        'ReleasePointHistoryBindingSource
        '
        Me.ReleasePointHistoryBindingSource.DataMember = "ReleasePointHistory"
        Me.ReleasePointHistoryBindingSource.DataSource = Me.ReleasePointDataSet
        '
        'ReleasePointHistoryTableAdapter
        '
        Me.ReleasePointHistoryTableAdapter.ClearBeforeFill = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 41)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(257, 13)
        Me.ProgressBar1.TabIndex = 5
        Me.ProgressBar1.Visible = False
        '
        'ReleasePointDetailHistoryBindingSource
        '
        Me.ReleasePointDetailHistoryBindingSource.DataMember = "ReleasePointDetailHistory"
        Me.ReleasePointDetailHistoryBindingSource.DataSource = Me.ReleasePointDataSet
        '
        'ReleasePointDetailHistoryTableAdapter
        '
        Me.ReleasePointDetailHistoryTableAdapter.ClearBeforeFill = True
        '
        'ReleasePointYearBindingSource
        '
        Me.ReleasePointYearBindingSource.DataMember = "ReleasePointYear"
        Me.ReleasePointYearBindingSource.DataSource = Me.ReleasePointDataSet
        '
        'ReleasePointYearTableAdapter
        '
        Me.ReleasePointYearTableAdapter.ClearBeforeFill = True
        '
        'EmissionYearBindingSource
        '
        Me.EmissionYearBindingSource.DataMember = "EmissionYear"
        Me.EmissionYearBindingSource.DataSource = Me.ReleasePointDataSet
        '
        'EmissionYearTableAdapter
        '
        Me.EmissionYearTableAdapter.ClearBeforeFill = True
        '
        'ImportE91T
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(284, 112)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.btnBrowse)
        Me.Name = "ImportE91T"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import E91T"
        CType(Me.ReleasePointDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutoE91T_FugitivesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutoE91T_StacksBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointDetailHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ReleasePointDataSet As APCD.EmissionsInventory.ReleasePointDataSet
    Friend WithEvents AutoE91T_FugitivesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AutoE91T_StacksBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointTypeTableAdapter As APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointTypeTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ReleasePointBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointTableAdapter As APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointTableAdapter
    Friend WithEvents ReleasePointDetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointDetailTableAdapter As APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointDetailTableAdapter
    Friend WithEvents ReleasePointHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointHistoryTableAdapter As APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointHistoryTableAdapter
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ReleasePointDetailHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointDetailHistoryTableAdapter As APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointDetailHistoryTableAdapter
    Friend WithEvents ReleasePointYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointYearTableAdapter As APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.ReleasePointYearTableAdapter
    Friend WithEvents EmissionYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionYearTableAdapter As APCD.EmissionsInventory.ReleasePointDataSetTableAdapters.EmissionYearTableAdapter
End Class
