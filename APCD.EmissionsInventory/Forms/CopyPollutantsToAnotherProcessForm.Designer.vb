<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CopyPollutantsToAnotherProcessForm
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
        Me.PlantComboBox = New System.Windows.Forms.ComboBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.EUComboBox = New System.Windows.Forms.ComboBox()
        Me.ProcessComboBox = New System.Windows.Forms.ComboBox()
        Me.btnCopyProcess = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSourceProcessPrompt = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PlantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantTableAdapter()
        Me.ProcessDataSet = New APCD.EmissionsInventory.ProcessDataSet()
        Me.ProcessEmissionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessEmissionTableAdapter = New APCD.EmissionsInventory.ProcessDataSetTableAdapters.ProcessEmissionTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.ProcessDataSetTableAdapters.TableAdapterManager()
        CType(Me.PlantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessEmissionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlantComboBox
        '
        Me.PlantComboBox.DisplayMember = "PlantID"
        Me.PlantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PlantComboBox.FormattingEnabled = True
        Me.PlantComboBox.Location = New System.Drawing.Point(92, 67)
        Me.PlantComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PlantComboBox.Name = "PlantComboBox"
        Me.PlantComboBox.Size = New System.Drawing.Size(359, 24)
        Me.PlantComboBox.TabIndex = 0
        Me.PlantComboBox.ValueMember = "PlantID"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(351, 202)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 28)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'EUComboBox
        '
        Me.EUComboBox.DisplayMember = "PlantID"
        Me.EUComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EUComboBox.FormattingEnabled = True
        Me.EUComboBox.Location = New System.Drawing.Point(92, 100)
        Me.EUComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.EUComboBox.Name = "EUComboBox"
        Me.EUComboBox.Size = New System.Drawing.Size(359, 24)
        Me.EUComboBox.TabIndex = 1
        Me.EUComboBox.ValueMember = "PlantID"
        '
        'ProcessComboBox
        '
        Me.ProcessComboBox.DisplayMember = "PlantID"
        Me.ProcessComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProcessComboBox.FormattingEnabled = True
        Me.ProcessComboBox.Location = New System.Drawing.Point(92, 133)
        Me.ProcessComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ProcessComboBox.Name = "ProcessComboBox"
        Me.ProcessComboBox.Size = New System.Drawing.Size(359, 24)
        Me.ProcessComboBox.TabIndex = 2
        Me.ProcessComboBox.ValueMember = "PlantID"
        '
        'btnCopyProcess
        '
        Me.btnCopyProcess.Location = New System.Drawing.Point(183, 202)
        Me.btnCopyProcess.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCopyProcess.Name = "btnCopyProcess"
        Me.btnCopyProcess.Size = New System.Drawing.Size(100, 28)
        Me.btnCopyProcess.TabIndex = 3
        Me.btnCopyProcess.Text = "Copy"
        Me.btnCopyProcess.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 70)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Plant"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 103)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "EU"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 137)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Process"
        '
        'lblSourceProcessPrompt
        '
        Me.lblSourceProcessPrompt.AutoSize = True
        Me.lblSourceProcessPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSourceProcessPrompt.ForeColor = System.Drawing.Color.Red
        Me.lblSourceProcessPrompt.Location = New System.Drawing.Point(24, 16)
        Me.lblSourceProcessPrompt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSourceProcessPrompt.Name = "lblSourceProcessPrompt"
        Me.lblSourceProcessPrompt.Size = New System.Drawing.Size(0, 17)
        Me.lblSourceProcessPrompt.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(24, 42)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(248, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Select the destination to copy to:"
        '
        'PlantTableAdapter
        '
        Me.PlantTableAdapter.ClearBeforeFill = True
        '
        'ProcessDataSet
        '
        Me.ProcessDataSet.DataSetName = "ProcessDataSet"
        Me.ProcessDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProcessEmissionBindingSource
        '
        Me.ProcessEmissionBindingSource.DataMember = "ProcessEmission"
        Me.ProcessEmissionBindingSource.DataSource = Me.ProcessDataSet
        '
        'ProcessEmissionTableAdapter
        '
        Me.ProcessEmissionTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.EmissionPeriodTypeTableAdapter = Nothing
        Me.TableAdapterManager.PollutantTableAdapter = Nothing
        Me.TableAdapterManager.ProcessDetailPeriodTableAdapter = Nothing
        Me.TableAdapterManager.ProcessEmissionHistoryTableAdapter = Nothing
        Me.TableAdapterManager.ProcessEmissionTableAdapter = Me.ProcessEmissionTableAdapter
        Me.TableAdapterManager.UpdateOrder = APCD.EmissionsInventory.ProcessDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CopyPollutantsToAnotherProcessForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 280)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblSourceProcessPrompt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCopyProcess)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.ProcessComboBox)
        Me.Controls.Add(Me.EUComboBox)
        Me.Controls.Add(Me.PlantComboBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CopyPollutantsToAnotherProcessForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Copy Pollutants to Another Process"
        CType(Me.PlantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessEmissionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PlantComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents EUComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProcessComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents btnCopyProcess As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblSourceProcessPrompt As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PlantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantTableAdapter
    Friend WithEvents ProcessDataSet As APCD.EmissionsInventory.ProcessDataSet
    Friend WithEvents ProcessEmissionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessEmissionTableAdapter As APCD.EmissionsInventory.ProcessDataSetTableAdapters.ProcessEmissionTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.ProcessDataSetTableAdapters.TableAdapterManager
End Class
