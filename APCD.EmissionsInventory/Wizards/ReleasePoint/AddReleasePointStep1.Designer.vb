<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddReleasePointStep1
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
        Dim Label3 As System.Windows.Forms.Label
        Dim YCoordinateLabel As System.Windows.Forms.Label
        Dim CommentPublicLabel As System.Windows.Forms.Label
        Dim CommentInternalLabel As System.Windows.Forms.Label
        Dim ReleasePointDescriptionLabel As System.Windows.Forms.Label
        Dim ReleasePointAPCDIDLabel As System.Windows.Forms.Label
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.ReleasePointBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ReleasePointDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ReleasePointAPCDIDTextBox = New System.Windows.Forms.TextBox()
        Me.CompanyCommentTextBox = New System.Windows.Forms.TextBox()
        Me.APCDCommentTextBox = New System.Windows.Forms.TextBox()
        Me.XCoordinateTextBox = New System.Windows.Forms.TextBox()
        Me.YCoordinateTextBox = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ReleasePointYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointYearTableAdapter()
        Label3 = New System.Windows.Forms.Label()
        YCoordinateLabel = New System.Windows.Forms.Label()
        CommentPublicLabel = New System.Windows.Forms.Label()
        CommentInternalLabel = New System.Windows.Forms.Label()
        ReleasePointDescriptionLabel = New System.Windows.Forms.Label()
        ReleasePointAPCDIDLabel = New System.Windows.Forms.Label()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(11, 322)
        Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(84, 17)
        Label3.TabIndex = 137
        Label3.Text = "* Longitude:"
        '
        'YCoordinateLabel
        '
        YCoordinateLabel.AutoSize = True
        YCoordinateLabel.Location = New System.Drawing.Point(11, 288)
        YCoordinateLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        YCoordinateLabel.Name = "YCoordinateLabel"
        YCoordinateLabel.Size = New System.Drawing.Size(72, 17)
        YCoordinateLabel.TabIndex = 135
        YCoordinateLabel.Text = "* Latitude:"
        '
        'CommentPublicLabel
        '
        CommentPublicLabel.AutoSize = True
        CommentPublicLabel.Location = New System.Drawing.Point(11, 150)
        CommentPublicLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CommentPublicLabel.Name = "CommentPublicLabel"
        CommentPublicLabel.Size = New System.Drawing.Size(134, 17)
        CommentPublicLabel.TabIndex = 132
        CommentPublicLabel.Text = "Company Comment:"
        '
        'CommentInternalLabel
        '
        CommentInternalLabel.AutoSize = True
        CommentInternalLabel.Location = New System.Drawing.Point(11, 219)
        CommentInternalLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CommentInternalLabel.Name = "CommentInternalLabel"
        CommentInternalLabel.Size = New System.Drawing.Size(112, 17)
        CommentInternalLabel.TabIndex = 133
        CommentInternalLabel.Text = "APCD Comment:"
        '
        'ReleasePointDescriptionLabel
        '
        ReleasePointDescriptionLabel.AutoSize = True
        ReleasePointDescriptionLabel.Location = New System.Drawing.Point(11, 96)
        ReleasePointDescriptionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ReleasePointDescriptionLabel.Name = "ReleasePointDescriptionLabel"
        ReleasePointDescriptionLabel.Size = New System.Drawing.Size(83, 17)
        ReleasePointDescriptionLabel.TabIndex = 130
        ReleasePointDescriptionLabel.Text = "Description:"
        '
        'ReleasePointAPCDIDLabel
        '
        ReleasePointAPCDIDLabel.AutoSize = True
        ReleasePointAPCDIDLabel.Location = New System.Drawing.Point(11, 65)
        ReleasePointAPCDIDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ReleasePointAPCDIDLabel.Name = "ReleasePointAPCDIDLabel"
        ReleasePointAPCDIDLabel.Size = New System.Drawing.Size(71, 17)
        ReleasePointAPCDIDLabel.TabIndex = 131
        ReleasePointAPCDIDLabel.Text = "* APCDID:"
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
        'ReleasePointDescriptionTextBox
        '
        Me.ReleasePointDescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReleasePointBindingSource, "ReleasePointDescription", True))
        Me.ReleasePointDescriptionTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReleasePointDescriptionTextBox.Location = New System.Drawing.Point(135, 96)
        Me.ReleasePointDescriptionTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReleasePointDescriptionTextBox.MaxLength = 100
        Me.ReleasePointDescriptionTextBox.Multiline = True
        Me.ReleasePointDescriptionTextBox.Name = "ReleasePointDescriptionTextBox"
        Me.ReleasePointDescriptionTextBox.Size = New System.Drawing.Size(731, 42)
        Me.ReleasePointDescriptionTextBox.TabIndex = 1
        '
        'ReleasePointAPCDIDTextBox
        '
        Me.ReleasePointAPCDIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReleasePointBindingSource, "ReleasePointAPCDID", True))
        Me.ReleasePointAPCDIDTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReleasePointAPCDIDTextBox.Location = New System.Drawing.Point(135, 62)
        Me.ReleasePointAPCDIDTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReleasePointAPCDIDTextBox.MaxLength = 50
        Me.ReleasePointAPCDIDTextBox.Name = "ReleasePointAPCDIDTextBox"
        Me.ReleasePointAPCDIDTextBox.Size = New System.Drawing.Size(432, 26)
        Me.ReleasePointAPCDIDTextBox.TabIndex = 0
        '
        'CompanyCommentTextBox
        '
        Me.CompanyCommentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReleasePointBindingSource, "CompanyComment", True))
        Me.CompanyCommentTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyCommentTextBox.Location = New System.Drawing.Point(135, 146)
        Me.CompanyCommentTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CompanyCommentTextBox.MaxLength = 400
        Me.CompanyCommentTextBox.Multiline = True
        Me.CompanyCommentTextBox.Name = "CompanyCommentTextBox"
        Me.CompanyCommentTextBox.Size = New System.Drawing.Size(731, 61)
        Me.CompanyCommentTextBox.TabIndex = 3
        '
        'APCDCommentTextBox
        '
        Me.APCDCommentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReleasePointBindingSource, "APCDComment", True))
        Me.APCDCommentTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.APCDCommentTextBox.Location = New System.Drawing.Point(135, 215)
        Me.APCDCommentTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.APCDCommentTextBox.MaxLength = 400
        Me.APCDCommentTextBox.Multiline = True
        Me.APCDCommentTextBox.Name = "APCDCommentTextBox"
        Me.APCDCommentTextBox.Size = New System.Drawing.Size(731, 61)
        Me.APCDCommentTextBox.TabIndex = 4
        '
        'XCoordinateTextBox
        '
        Me.XCoordinateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReleasePointBindingSource, "XCoordinate", True))
        Me.XCoordinateTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XCoordinateTextBox.Location = New System.Drawing.Point(135, 319)
        Me.XCoordinateTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.XCoordinateTextBox.MaxLength = 20
        Me.XCoordinateTextBox.Name = "XCoordinateTextBox"
        Me.XCoordinateTextBox.Size = New System.Drawing.Size(109, 26)
        Me.XCoordinateTextBox.TabIndex = 6
        '
        'YCoordinateTextBox
        '
        Me.YCoordinateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReleasePointBindingSource, "YCoordinate", True))
        Me.YCoordinateTextBox.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YCoordinateTextBox.Location = New System.Drawing.Point(135, 284)
        Me.YCoordinateTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.YCoordinateTextBox.MaxLength = 20
        Me.YCoordinateTextBox.Name = "YCoordinateTextBox"
        Me.YCoordinateTextBox.Size = New System.Drawing.Size(109, 26)
        Me.YCoordinateTextBox.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(763, 446)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNext.Location = New System.Drawing.Point(389, 446)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(100, 28)
        Me.btnNext.TabIndex = 7
        Me.btnNext.Text = "Next >"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(712, 17)
        Me.Label1.TabIndex = 141
        Me.Label1.Text = "Enter the properties of the release point below. Properties marked with a * are r" & _
    "equired. Select Next to continue."
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ReleasePointYearBindingSource
        '
        Me.ReleasePointYearBindingSource.DataMember = "ReleasePointYear"
        Me.ReleasePointYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleasePointYearTableAdapter
        '
        Me.ReleasePointYearTableAdapter.ClearBeforeFill = True
        '
        'AddReleasePointStep1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 489)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Me.ReleasePointDescriptionTextBox)
        Me.Controls.Add(Me.ReleasePointAPCDIDTextBox)
        Me.Controls.Add(Me.CompanyCommentTextBox)
        Me.Controls.Add(Me.APCDCommentTextBox)
        Me.Controls.Add(Me.XCoordinateTextBox)
        Me.Controls.Add(Me.YCoordinateTextBox)
        Me.Controls.Add(YCoordinateLabel)
        Me.Controls.Add(CommentPublicLabel)
        Me.Controls.Add(CommentInternalLabel)
        Me.Controls.Add(ReleasePointDescriptionLabel)
        Me.Controls.Add(ReleasePointAPCDIDLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "AddReleasePointStep1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Release Point Step 1"
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ReleasePointBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ReleasePointDescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReleasePointAPCDIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompanyCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents APCDCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents XCoordinateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YCoordinateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ReleasePointYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointYearTableAdapter
End Class
