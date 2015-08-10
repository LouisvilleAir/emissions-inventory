<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddControlMeasureStep1
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
        Dim ControlMeasureDescriptionLabel As System.Windows.Forms.Label
        Dim ControlMeasureTypeIDLabel As System.Windows.Forms.Label
        Dim ControlMeasureAPCDIDLabel As System.Windows.Forms.Label
        Dim CommentPublicLabel As System.Windows.Forms.Label
        Dim CommentInternalLabel As System.Windows.Forms.Label
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ControlMeasureDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ControlMeasureAPCDIDTextBox = New System.Windows.Forms.TextBox()
        Me.CompanyCommentTextBox = New System.Windows.Forms.TextBox()
        Me.APCDCommentTextBox = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ControlMeasureTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.ControlMeasureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ControlMeasureYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureYearTableAdapter()
        ControlMeasureDescriptionLabel = New System.Windows.Forms.Label()
        ControlMeasureTypeIDLabel = New System.Windows.Forms.Label()
        ControlMeasureAPCDIDLabel = New System.Windows.Forms.Label()
        CommentPublicLabel = New System.Windows.Forms.Label()
        CommentInternalLabel = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ControlMeasureDescriptionLabel
        '
        ControlMeasureDescriptionLabel.AutoSize = True
        ControlMeasureDescriptionLabel.Location = New System.Drawing.Point(9, 85)
        ControlMeasureDescriptionLabel.Name = "ControlMeasureDescriptionLabel"
        ControlMeasureDescriptionLabel.Size = New System.Drawing.Size(63, 13)
        ControlMeasureDescriptionLabel.TabIndex = 14
        ControlMeasureDescriptionLabel.Text = "Description:"
        '
        'ControlMeasureTypeIDLabel
        '
        ControlMeasureTypeIDLabel.AutoSize = True
        ControlMeasureTypeIDLabel.Location = New System.Drawing.Point(9, 59)
        ControlMeasureTypeIDLabel.Name = "ControlMeasureTypeIDLabel"
        ControlMeasureTypeIDLabel.Size = New System.Drawing.Size(38, 13)
        ControlMeasureTypeIDLabel.TabIndex = 18
        ControlMeasureTypeIDLabel.Text = "*Type:"
        '
        'ControlMeasureAPCDIDLabel
        '
        ControlMeasureAPCDIDLabel.AutoSize = True
        ControlMeasureAPCDIDLabel.Location = New System.Drawing.Point(9, 33)
        ControlMeasureAPCDIDLabel.Name = "ControlMeasureAPCDIDLabel"
        ControlMeasureAPCDIDLabel.Size = New System.Drawing.Size(57, 13)
        ControlMeasureAPCDIDLabel.TabIndex = 20
        ControlMeasureAPCDIDLabel.Text = "* APCDID:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.AutoSize = True
        CommentPublicLabel.Location = New System.Drawing.Point(9, 126)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(86, 13)
        CommentPublicLabel.TabIndex = 30
        CommentPublicLabel.Text = "Comment Public:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.AutoSize = True
        CommentInternalLabel.Location = New System.Drawing.Point(3, 179)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(92, 13)
        CommentInternalLabel.TabIndex = 32
        CommentInternalLabel.Text = "Comment Internal:"
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNext.Location = New System.Drawing.Point(526, 252)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = "Next >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(607, 252)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ControlMeasureDescriptionTextBox
        '
        Me.ControlMeasureDescriptionTextBox.Location = New System.Drawing.Point(98, 82)
        Me.ControlMeasureDescriptionTextBox.MaxLength = 100
        Me.ControlMeasureDescriptionTextBox.Multiline = True
        Me.ControlMeasureDescriptionTextBox.Name = "ControlMeasureDescriptionTextBox"
        Me.ControlMeasureDescriptionTextBox.Size = New System.Drawing.Size(590, 35)
        Me.ControlMeasureDescriptionTextBox.TabIndex = 2
        '
        'ControlMeasureAPCDIDTextBox
        '
        Me.ControlMeasureAPCDIDTextBox.Location = New System.Drawing.Point(98, 30)
        Me.ControlMeasureAPCDIDTextBox.MaxLength = 50
        Me.ControlMeasureAPCDIDTextBox.Name = "ControlMeasureAPCDIDTextBox"
        Me.ControlMeasureAPCDIDTextBox.Size = New System.Drawing.Size(325, 20)
        Me.ControlMeasureAPCDIDTextBox.TabIndex = 0
        '
        'CompanyCommentTextBox
        '
        Me.CompanyCommentTextBox.Location = New System.Drawing.Point(98, 123)
        Me.CompanyCommentTextBox.MaxLength = 255
        Me.CompanyCommentTextBox.Multiline = True
        Me.CompanyCommentTextBox.Name = "CompanyCommentTextBox"
        Me.CompanyCommentTextBox.Size = New System.Drawing.Size(590, 50)
        Me.CompanyCommentTextBox.TabIndex = 3
        '
        'APCDCommentTextBox
        '
        Me.APCDCommentTextBox.Location = New System.Drawing.Point(97, 179)
        Me.APCDCommentTextBox.MaxLength = 255
        Me.APCDCommentTextBox.Multiline = True
        Me.APCDCommentTextBox.Name = "APCDCommentTextBox"
        Me.APCDCommentTextBox.Size = New System.Drawing.Size(590, 50)
        Me.APCDCommentTextBox.TabIndex = 4
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ControlMeasureTypeComboBox
        '
        Me.ControlMeasureTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ControlMeasureTypeComboBox.FormattingEnabled = True
        Me.ControlMeasureTypeComboBox.Location = New System.Drawing.Point(98, 56)
        Me.ControlMeasureTypeComboBox.Name = "ControlMeasureTypeComboBox"
        Me.ControlMeasureTypeComboBox.Size = New System.Drawing.Size(200, 21)
        Me.ControlMeasureTypeComboBox.TabIndex = 1
        '
        'EmissionsDataSet
        '
        Me.EmissionsDataSet.DataSetName = "EmissionsDataSet"
        Me.EmissionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ControlMeasureBindingSource
        '
        Me.ControlMeasureBindingSource.DataMember = "ControlMeasure"
        Me.ControlMeasureBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasureTableAdapter
        '
        Me.ControlMeasureTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.ControlMeasureTypeTableAdapter = Nothing
        Me.TableAdapterManager.ControlMeasureYearHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ControlMeasureYearTableAdapter = Me.ControlMeasureYearTableAdapter
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
        'ControlMeasureYearBindingSource
        '
        Me.ControlMeasureYearBindingSource.DataMember = "ControlMeasureYear"
        Me.ControlMeasureYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasureYearTableAdapter
        '
        Me.ControlMeasureYearTableAdapter.ClearBeforeFill = True
        '
        'AddControlMeasureStep1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 287)
        Me.ControlBox = False
        Me.Controls.Add(Me.ControlMeasureTypeComboBox)
        Me.Controls.Add(ControlMeasureDescriptionLabel)
        Me.Controls.Add(Me.ControlMeasureDescriptionTextBox)
        Me.Controls.Add(ControlMeasureTypeIDLabel)
        Me.Controls.Add(ControlMeasureAPCDIDLabel)
        Me.Controls.Add(Me.ControlMeasureAPCDIDTextBox)
        Me.Controls.Add(CommentPublicLabel)
        Me.Controls.Add(Me.CompanyCommentTextBox)
        Me.Controls.Add(CommentInternalLabel)
        Me.Controls.Add(Me.APCDCommentTextBox)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "AddControlMeasureStep1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Control Measure Step 1"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ControlMeasureDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ControlMeasureAPCDIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompanyCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents APCDCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ControlMeasureTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ControlMeasureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ControlMeasureTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ControlMeasureYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureYearTableAdapter
    Friend WithEvents ControlMeasureYearBindingSource As System.Windows.Forms.BindingSource
End Class
