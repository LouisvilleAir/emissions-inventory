<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCCCodeSelectorForm
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
        Me.btnLookupProcessClass = New System.Windows.Forms.Button()
        Me.ProcessClassLevel1TypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ProcessClassLevel1TypeBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.ProcessClassLevel2TypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ProcessClassLevel3TypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ProcessClassLevel4TypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ProcessClassIDTextBox = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.ProcessClassLevel1TypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessClassLevel1TypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessClassLevel1TypeTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProcessClassComboBox = New System.Windows.Forms.ComboBox()
        CType(Me.ProcessClassLevel1TypeBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessClassLevel1TypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLookupProcessClass
        '
        Me.btnLookupProcessClass.Location = New System.Drawing.Point(91, 36)
        Me.btnLookupProcessClass.Name = "btnLookupProcessClass"
        Me.btnLookupProcessClass.Size = New System.Drawing.Size(56, 23)
        Me.btnLookupProcessClass.TabIndex = 39
        Me.btnLookupProcessClass.Text = "Look Up"
        Me.btnLookupProcessClass.UseVisualStyleBackColor = True
        '
        'ProcessClassLevel1TypeComboBox
        '
        Me.ProcessClassLevel1TypeComboBox.DataSource = Me.ProcessClassLevel1TypeBindingSource1
        Me.ProcessClassLevel1TypeComboBox.DisplayMember = "ProcessClassLevel1TypeName"
        Me.ProcessClassLevel1TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProcessClassLevel1TypeComboBox.FormattingEnabled = True
        Me.ProcessClassLevel1TypeComboBox.Location = New System.Drawing.Point(175, 38)
        Me.ProcessClassLevel1TypeComboBox.Name = "ProcessClassLevel1TypeComboBox"
        Me.ProcessClassLevel1TypeComboBox.Size = New System.Drawing.Size(355, 21)
        Me.ProcessClassLevel1TypeComboBox.TabIndex = 40
        Me.ProcessClassLevel1TypeComboBox.ValueMember = "ProcessClassLevel1TypeID"
        '
        'ProcessClassLevel1TypeBindingSource1
        '
        Me.ProcessClassLevel1TypeBindingSource1.DataMember = "ProcessClassLevel1Type"
        Me.ProcessClassLevel1TypeBindingSource1.DataSource = Me.EmissionsDataSet
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProcessClassLevel2TypeComboBox
        '
        Me.ProcessClassLevel2TypeComboBox.DisplayMember = "ProcessClassLevel2TypeID"
        Me.ProcessClassLevel2TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProcessClassLevel2TypeComboBox.FormattingEnabled = True
        Me.ProcessClassLevel2TypeComboBox.Location = New System.Drawing.Point(175, 65)
        Me.ProcessClassLevel2TypeComboBox.Name = "ProcessClassLevel2TypeComboBox"
        Me.ProcessClassLevel2TypeComboBox.Size = New System.Drawing.Size(355, 21)
        Me.ProcessClassLevel2TypeComboBox.TabIndex = 41
        Me.ProcessClassLevel2TypeComboBox.ValueMember = "ProcessClassLevel2TypeID"
        '
        'ProcessClassLevel3TypeComboBox
        '
        Me.ProcessClassLevel3TypeComboBox.DisplayMember = "ProcessClassLevel3TypeID"
        Me.ProcessClassLevel3TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProcessClassLevel3TypeComboBox.FormattingEnabled = True
        Me.ProcessClassLevel3TypeComboBox.Location = New System.Drawing.Point(175, 92)
        Me.ProcessClassLevel3TypeComboBox.Name = "ProcessClassLevel3TypeComboBox"
        Me.ProcessClassLevel3TypeComboBox.Size = New System.Drawing.Size(355, 21)
        Me.ProcessClassLevel3TypeComboBox.TabIndex = 42
        Me.ProcessClassLevel3TypeComboBox.ValueMember = "ProcessClassLevel3TypeID"
        '
        'ProcessClassLevel4TypeComboBox
        '
        Me.ProcessClassLevel4TypeComboBox.DisplayMember = "ProcessClassLevel4TypeID"
        Me.ProcessClassLevel4TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProcessClassLevel4TypeComboBox.FormattingEnabled = True
        Me.ProcessClassLevel4TypeComboBox.Location = New System.Drawing.Point(229, 119)
        Me.ProcessClassLevel4TypeComboBox.Name = "ProcessClassLevel4TypeComboBox"
        Me.ProcessClassLevel4TypeComboBox.Size = New System.Drawing.Size(277, 21)
        Me.ProcessClassLevel4TypeComboBox.TabIndex = 43
        Me.ProcessClassLevel4TypeComboBox.ValueMember = "ProcessClassLevel4TypeID"
        Me.ProcessClassLevel4TypeComboBox.Visible = False
        '
        'ProcessClassIDTextBox
        '
        Me.ProcessClassIDTextBox.Location = New System.Drawing.Point(15, 38)
        Me.ProcessClassIDTextBox.MaxLength = 10
        Me.ProcessClassIDTextBox.Name = "ProcessClassIDTextBox"
        Me.ProcessClassIDTextBox.Size = New System.Drawing.Size(70, 20)
        Me.ProcessClassIDTextBox.TabIndex = 38
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(459, 235)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 45
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(378, 235)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 25)
        Me.btnOK.TabIndex = 46
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ProcessClassLevel1TypeBindingSource
        '
        Me.ProcessClassLevel1TypeBindingSource.DataMember = "ProcessClassLevel1Type"
        Me.ProcessClassLevel1TypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessClassLevel1TypeTableAdapter
        '
        Me.ProcessClassLevel1TypeTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.ProcessClassLevel1TypeTableAdapter = Me.ProcessClassLevel1TypeTableAdapter
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
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(15, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(515, 50)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(506, 17)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Enter a code and choose [Look Up] -or-  select from the dropdown lists to look up" & _
            " the SCC."
        '
        'ProcessClassComboBox
        '
        Me.ProcessClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProcessClassComboBox.FormattingEnabled = True
        Me.ProcessClassComboBox.Location = New System.Drawing.Point(175, 119)
        Me.ProcessClassComboBox.Name = "ProcessClassComboBox"
        Me.ProcessClassComboBox.Size = New System.Drawing.Size(355, 21)
        Me.ProcessClassComboBox.TabIndex = 50
        '
        'SCCCodeSelectorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 272)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProcessClassComboBox)
        Me.Controls.Add(Me.ProcessClassLevel4TypeComboBox)
        Me.Controls.Add(Me.ProcessClassLevel3TypeComboBox)
        Me.Controls.Add(Me.ProcessClassLevel2TypeComboBox)
        Me.Controls.Add(Me.ProcessClassLevel1TypeComboBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ProcessClassIDTextBox)
        Me.Controls.Add(Me.btnLookupProcessClass)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "SCCCodeSelectorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SCC Lookup"
        CType(Me.ProcessClassLevel1TypeBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessClassLevel1TypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLookupProcessClass As System.Windows.Forms.Button
    Friend WithEvents ProcessClassLevel1TypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProcessClassLevel2TypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProcessClassLevel3TypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProcessClassLevel4TypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProcessClassIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ProcessClassLevel1TypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessClassLevel1TypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessClassLevel1TypeTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ProcessClassLevel1TypeBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProcessClassComboBox As System.Windows.Forms.ComboBox
End Class
