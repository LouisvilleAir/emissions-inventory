<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEmissionUnit
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
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.PlantEmissionUnitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantEmissionUnitTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.EmissionUnitTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.EmissionUnitTypeTableAdapter()
        Me.PlantEmissionUnitYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitYearTableAdapter()
        Me.EmissionUnitAPCDIDTextBox = New System.Windows.Forms.TextBox()
        Me.EmissionUnitDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.CommentPublicTextBox = New System.Windows.Forms.TextBox()
        Me.CommentInternalTextBox = New System.Windows.Forms.TextBox()
        Me.PlantEmissionUnitYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmissionUnitTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.EmissionUnitTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Label4 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantEmissionUnitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantEmissionUnitYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionUnitTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(12, 39)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(41, 13)
        Label4.TabIndex = 84
        Label4.Text = "* Type:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(12, 66)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(60, 13)
        Label5.TabIndex = 85
        Label5.Text = "* APCD ID:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(12, 92)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(63, 13)
        Label6.TabIndex = 88
        Label6.Text = "Description:"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(12, 148)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(86, 13)
        Label7.TabIndex = 89
        Label7.Text = "Comment Public:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(12, 204)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(92, 13)
        Label8.TabIndex = 90
        Label8.Text = "Comment Internal:"
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PlantEmissionUnitBindingSource
        '
        Me.PlantEmissionUnitBindingSource.DataMember = "PlantEmissionUnit"
        Me.PlantEmissionUnitBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PlantEmissionUnitTableAdapter
        '
        Me.PlantEmissionUnitTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.EmissionUnitTypeTableAdapter = Me.EmissionUnitTypeTableAdapter
        Me.TableAdapterManager.EmissionYearTableAdapter = Nothing
        Me.TableAdapterManager.FacilityCategoryEISTableAdapter = Nothing
        Me.TableAdapterManager.FacilitySiteStatusTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.MeasurementTableAdapter = Nothing
        Me.TableAdapterManager.OperatingStatusTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitDetailTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitHistoryTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitTableAdapter = Me.PlantEmissionUnitTableAdapter
        Me.TableAdapterManager.PlantEmissionUnitYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitYearTableAdapter = Me.PlantEmissionUnitYearTableAdapter
        Me.TableAdapterManager.PlantYearTableAdapter = Nothing
        Me.TableAdapterManager.PollutantTableAdapter = Nothing
        Me.TableAdapterManager.ProcessClassLevel1TypeTableAdapter = Nothing
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
        'EmissionUnitTypeTableAdapter
        '
        Me.EmissionUnitTypeTableAdapter.ClearBeforeFill = True
        '
        'PlantEmissionUnitYearTableAdapter
        '
        Me.PlantEmissionUnitYearTableAdapter.ClearBeforeFill = True
        '
        'EmissionUnitAPCDIDTextBox
        '
        Me.EmissionUnitAPCDIDTextBox.Location = New System.Drawing.Point(103, 63)
        Me.EmissionUnitAPCDIDTextBox.MaxLength = 50
        Me.EmissionUnitAPCDIDTextBox.Name = "EmissionUnitAPCDIDTextBox"
        Me.EmissionUnitAPCDIDTextBox.Size = New System.Drawing.Size(250, 20)
        Me.EmissionUnitAPCDIDTextBox.TabIndex = 1
        '
        'EmissionUnitDescriptionTextBox
        '
        Me.EmissionUnitDescriptionTextBox.Location = New System.Drawing.Point(103, 92)
        Me.EmissionUnitDescriptionTextBox.MaxLength = 100
        Me.EmissionUnitDescriptionTextBox.Multiline = True
        Me.EmissionUnitDescriptionTextBox.Name = "EmissionUnitDescriptionTextBox"
        Me.EmissionUnitDescriptionTextBox.Size = New System.Drawing.Size(595, 35)
        Me.EmissionUnitDescriptionTextBox.TabIndex = 2
        '
        'CommentPublicTextBox
        '
        Me.CommentPublicTextBox.Location = New System.Drawing.Point(104, 148)
        Me.CommentPublicTextBox.MaxLength = 255
        Me.CommentPublicTextBox.Multiline = True
        Me.CommentPublicTextBox.Name = "CommentPublicTextBox"
        Me.CommentPublicTextBox.Size = New System.Drawing.Size(595, 50)
        Me.CommentPublicTextBox.TabIndex = 3
        '
        'CommentInternalTextBox
        '
        Me.CommentInternalTextBox.Location = New System.Drawing.Point(103, 204)
        Me.CommentInternalTextBox.MaxLength = 255
        Me.CommentInternalTextBox.Multiline = True
        Me.CommentInternalTextBox.Name = "CommentInternalTextBox"
        Me.CommentInternalTextBox.Size = New System.Drawing.Size(595, 50)
        Me.CommentInternalTextBox.TabIndex = 4
        '
        'PlantEmissionUnitYearBindingSource
        '
        Me.PlantEmissionUnitYearBindingSource.DataMember = "PlantEmissionUnitYear"
        Me.PlantEmissionUnitYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "* Required field"
        '
        'EmissionUnitTypeComboBox
        '
        Me.EmissionUnitTypeComboBox.DisplayMember = "EmissionUnitTypeID"
        Me.EmissionUnitTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmissionUnitTypeComboBox.FormattingEnabled = True
        Me.EmissionUnitTypeComboBox.Location = New System.Drawing.Point(103, 36)
        Me.EmissionUnitTypeComboBox.Name = "EmissionUnitTypeComboBox"
        Me.EmissionUnitTypeComboBox.Size = New System.Drawing.Size(200, 21)
        Me.EmissionUnitTypeComboBox.TabIndex = 0
        Me.EmissionUnitTypeComboBox.ValueMember = "EmissionUnitTypeID"
        '
        'EmissionUnitTypeBindingSource
        '
        Me.EmissionUnitTypeBindingSource.DataMember = "EmissionUnitType"
        Me.EmissionUnitTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(622, 277)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(541, 277)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'AddEmissionUnit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 312)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Label7)
        Me.Controls.Add(Label8)
        Me.Controls.Add(Me.EmissionUnitTypeComboBox)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.EmissionUnitAPCDIDTextBox)
        Me.Controls.Add(Me.EmissionUnitDescriptionTextBox)
        Me.Controls.Add(Me.CommentPublicTextBox)
        Me.Controls.Add(Me.CommentInternalTextBox)
        Me.Name = "AddEmissionUnit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Emission Unit"
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantEmissionUnitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantEmissionUnitYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionUnitTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents PlantEmissionUnitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantEmissionUnitTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PlantEmissionUnitYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitYearTableAdapter
    Friend WithEvents EmissionUnitAPCDIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmissionUnitDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentPublicTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CommentInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PlantEmissionUnitYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EmissionUnitTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents EmissionUnitTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.EmissionUnitTypeTableAdapter
    Friend WithEvents EmissionUnitTypeBindingSource As System.Windows.Forms.BindingSource
End Class
