<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddReleasePointStep2
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
        Me.ReleasePointBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ReleasePointTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointTypeTableAdapter()
        Me.ReleaseTypeSubTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleaseTypeSubTypeTableAdapter()
        Me.ReleaseTypeSubTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ReleaseTypeSubTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointTypeIDComboBox = New System.Windows.Forms.ComboBox()
        Me.ReleasePointTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleaseTypeSubTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReleasePointBindingSource
        '
        Me.ReleasePointBindingSource.DataMember = "ReleasePoint"
        Me.ReleasePointBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleasePointTableAdapter
        '
        Me.ReleasePointTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.ProcessTableAdapter = Nothing
        Me.TableAdapterManager.ProcessYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessYearTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointDetailHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointDetailTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointTableAdapter = Me.ReleasePointTableAdapter
        Me.TableAdapterManager.ReleasePointTypeTableAdapter = Me.ReleasePointTypeTableAdapter
        Me.TableAdapterManager.ReleasePointYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointYearTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeMeasurementTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeSubTypeTableAdapter = Me.ReleaseTypeSubTypeTableAdapter
        Me.TableAdapterManager.ReleaseTypeTableAdapter = Nothing
        Me.TableAdapterManager.ThroughputTypeTableAdapter = Nothing
        Me.TableAdapterManager.UnitOfMeasurementTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ReleasePointTypeTableAdapter
        '
        Me.ReleasePointTypeTableAdapter.ClearBeforeFill = True
        '
        'ReleaseTypeSubTypeTableAdapter
        '
        Me.ReleaseTypeSubTypeTableAdapter.ClearBeforeFill = True
        '
        'ReleaseTypeSubTypeComboBox
        '
        Me.ReleaseTypeSubTypeComboBox.DataSource = Me.ReleaseTypeSubTypeBindingSource
        Me.ReleaseTypeSubTypeComboBox.DisplayMember = "ReleaseTypeSubTypeName"
        Me.ReleaseTypeSubTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ReleaseTypeSubTypeComboBox.FormattingEnabled = True
        Me.ReleaseTypeSubTypeComboBox.Location = New System.Drawing.Point(265, 78)
        Me.ReleaseTypeSubTypeComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReleaseTypeSubTypeComboBox.Name = "ReleaseTypeSubTypeComboBox"
        Me.ReleaseTypeSubTypeComboBox.Size = New System.Drawing.Size(99, 24)
        Me.ReleaseTypeSubTypeComboBox.TabIndex = 1
        Me.ReleaseTypeSubTypeComboBox.ValueMember = "ReleaseTypeSubTypeID"
        '
        'ReleaseTypeSubTypeBindingSource
        '
        Me.ReleaseTypeSubTypeBindingSource.DataMember = "ReleaseTypeSubType"
        Me.ReleaseTypeSubTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleasePointTypeIDComboBox
        '
        Me.ReleasePointTypeIDComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ReleasePointBindingSource, "ReleasePointTypeID", True))
        Me.ReleasePointTypeIDComboBox.DataSource = Me.ReleasePointTypeBindingSource
        Me.ReleasePointTypeIDComboBox.DisplayMember = "ReleasePointTypeName"
        Me.ReleasePointTypeIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ReleasePointTypeIDComboBox.FormattingEnabled = True
        Me.ReleasePointTypeIDComboBox.Location = New System.Drawing.Point(71, 78)
        Me.ReleasePointTypeIDComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReleasePointTypeIDComboBox.Name = "ReleasePointTypeIDComboBox"
        Me.ReleasePointTypeIDComboBox.Size = New System.Drawing.Size(185, 24)
        Me.ReleasePointTypeIDComboBox.TabIndex = 0
        Me.ReleasePointTypeIDComboBox.ValueMember = "ReleasePointTypeID"
        '
        'ReleasePointTypeBindingSource
        '
        Me.ReleasePointTypeBindingSource.DataMember = "ReleasePointType"
        Me.ReleasePointTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNext.Location = New System.Drawing.Point(264, 150)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(100, 28)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Next >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(433, 150)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(445, 42)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "Choose the type of release point from the selections below.  Select Next to conti" & _
    "nue."
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnBack.Location = New System.Drawing.Point(156, 150)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(100, 28)
        Me.btnBack.TabIndex = 3
        Me.btnBack.Text = "< Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'AddReleasePointStep2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 233)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.ReleaseTypeSubTypeComboBox)
        Me.Controls.Add(Me.ReleasePointTypeIDComboBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "AddReleasePointStep2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Release Point Step 2"
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleaseTypeSubTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ReleasePointBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ReleaseTypeSubTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ReleasePointTypeIDComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ReleasePointTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointTypeTableAdapter
    Friend WithEvents ReleaseTypeSubTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleaseTypeSubTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleaseTypeSubTypeTableAdapter
End Class
