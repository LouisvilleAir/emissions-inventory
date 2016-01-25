<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateInvoicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateAnnaulNotificationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportWebsiteMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgrammerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WhosLoggedOnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportFacilityDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportPointDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CheckPollutantUOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Import91TFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Import92TFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerLeft = New System.Windows.Forms.SplitContainer()
        Me.TreeViewMain = New System.Windows.Forms.TreeView()
        Me.btnControlMeasures = New System.Windows.Forms.Button()
        Me.btnPlantsAndReleasePoints = New System.Windows.Forms.Button()
        Me.btnPlantsAndProcesses = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusMode = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.statusLevel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.EmissionsDataSet = New APCD.EmissionsInventory.EmissionsDataSet()
        Me.ControlMeasureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTableAdapter()
        Me.ControlMeasureTableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ControlMeasurePollutantTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasurePollutantTableAdapter()
        Me.ControlMeasurePollutantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointTableAdapter()
        Me.ReleasePointTableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ReleasePointDetailTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointDetailTableAdapter()
        Me.ReleasePointDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmissionYearLabel = New System.Windows.Forms.Label()
        Me.EmissionYearComboBox = New System.Windows.Forms.ComboBox()
        Me.EmissionYear_GetLookupTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantTableAdapter()
        Me.TableAdapterManager = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager()
        Me.ControlMeasureHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureHistoryTableAdapter()
        Me.ControlMeasurePollutantHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasurePollutantHistoryTableAdapter()
        Me.ControlMeasureTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTypeTableAdapter()
        Me.ControlMeasureYearHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureYearHistoryTableAdapter()
        Me.ControlMeasureYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureYearTableAdapter()
        Me.EmissionUnitTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.EmissionUnitTypeTableAdapter()
        Me.EmissionYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.EmissionYearTableAdapter()
        Me.PlantEmissionUnitHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitHistoryTableAdapter()
        Me.PlantEmissionUnitTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitTableAdapter()
        Me.PlantEmissionUnitYearHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitYearHistoryTableAdapter()
        Me.PlantEmissionUnitYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitYearTableAdapter()
        Me.PlantYearHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearHistoryTableAdapter()
        Me.PlantYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearTableAdapter()
        Me.PollutantTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PollutantTableAdapter()
        Me.ProcessTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessTableAdapter()
        Me.ProcessYearHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessYearHistoryTableAdapter()
        Me.ProcessYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessYearTableAdapter()
        Me.ReleasePointDetailHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointDetailHistoryTableAdapter()
        Me.ReleasePointHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointHistoryTableAdapter()
        Me.ReleasePointYearHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointYearHistoryTableAdapter()
        Me.ReleasePointYearTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointYearTableAdapter()
        Me.ThroughputTypeTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ThroughputTypeTableAdapter()
        Me.UnitOfMeasurementTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.UnitOfMeasurementTableAdapter()
        Me.PlantEmissionUnitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantEmissionUnitYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmissionYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmissionYear_GetLookupTableTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.EmissionYear_GetLookupTableTableAdapter()
        Me.PlantEmissionUnitHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantEmissionUnitYearHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureYearHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasurePollutantHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointYearHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReleasePointDetailHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessHistoryTableAdapter()
        Me.ProcessYearHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UnitOfMeasurementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblWhereAmI = New System.Windows.Forms.Label()
        Me.EmissionUnitTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ThroughputTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ControlMeasureTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantYearBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlantYearHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PollutantBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessControlMeasureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessControlMeasureTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessControlMeasureTableAdapter()
        Me.ProcessControlMeasureHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessControlMeasureHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessControlMeasureHistoryTableAdapter()
        Me.ProcessReleasePointBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessReleasePointTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessReleasePointTableAdapter()
        Me.ProcessReleasePointHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessReleasePointHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessReleasePointHistoryTableAdapter()
        Me.Process_ControlMeasureTabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Process_ControlMeasureTabTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ControlMeasureTabTableAdapter()
        Me.Process_ReleasePointTabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Process_ReleasePointTabTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ReleasePointTabTableAdapter()
        Me.ProcessEmissionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessEmissionTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessEmissionTableAdapter()
        Me.Process_EmissionsTabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Process_EmissionsTabTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_EmissionsTabTableAdapter()
        Me.ProcessEmissionHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessEmissionHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessEmissionHistoryTableAdapter()
        Me.Process_ThroughputTabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Process_ThroughputTabTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ThroughputTabTableAdapter()
        Me.ProcessSeasonalActivityBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessSeasonalActivityTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessSeasonalActivityTableAdapter()
        Me.ProcessDetailPeriodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessDetailPeriodTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessDetailPeriodTableAdapter()
        Me.ProcessDetailPeriodHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessDetailPeriodHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessDetailPeriodHistoryTableAdapter()
        Me.ProcessSeasonalActivityHistoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProcessSeasonalActivityHistoryTableAdapter = New APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessSeasonalActivityHistoryTableAdapter()
        Me.TopNavigationPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.Panel1.SuspendLayout()
        Me.SplitContainerMain.SuspendLayout()
        CType(Me.SplitContainerLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerLeft.Panel1.SuspendLayout()
        Me.SplitContainerLeft.Panel2.SuspendLayout()
        Me.SplitContainerLeft.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasurePollutantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionYear_GetLookupTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantEmissionUnitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantEmissionUnitYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantEmissionUnitHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantEmissionUnitYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasurePollutantHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReleasePointDetailHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnitOfMeasurementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmissionUnitTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThroughputTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlMeasureTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantYearBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlantYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PollutantBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessControlMeasureHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessReleasePointBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessReleasePointHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Process_ControlMeasureTabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Process_ReleasePointTabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessEmissionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Process_EmissionsTabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessEmissionHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Process_ThroughputTabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessSeasonalActivityBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessDetailPeriodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessDetailPeriodHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProcessSeasonalActivityHistoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopNavigationPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AdminToolStripMenuItem, Me.HelpToolStripMenuItem, Me.ProgrammerToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1262, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(102, 24)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateInvoicesToolStripMenuItem, Me.GenerateAnnaulNotificationsToolStripMenuItem})
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(65, 24)
        Me.AdminToolStripMenuItem.Text = "&Admin"
        '
        'GenerateInvoicesToolStripMenuItem
        '
        Me.GenerateInvoicesToolStripMenuItem.Name = "GenerateInvoicesToolStripMenuItem"
        Me.GenerateInvoicesToolStripMenuItem.Size = New System.Drawing.Size(277, 24)
        Me.GenerateInvoicesToolStripMenuItem.Text = "Generate Invoices"
        '
        'GenerateAnnaulNotificationsToolStripMenuItem
        '
        Me.GenerateAnnaulNotificationsToolStripMenuItem.Name = "GenerateAnnaulNotificationsToolStripMenuItem"
        Me.GenerateAnnaulNotificationsToolStripMenuItem.Size = New System.Drawing.Size(277, 24)
        Me.GenerateAnnaulNotificationsToolStripMenuItem.Text = "Generate Annual Notifications"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SupportWebsiteMenuItem, Me.ToolStripSeparator2, Me.toolStripSeparator7, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'SupportWebsiteMenuItem
        '
        Me.SupportWebsiteMenuItem.Name = "SupportWebsiteMenuItem"
        Me.SupportWebsiteMenuItem.Size = New System.Drawing.Size(189, 24)
        Me.SupportWebsiteMenuItem.Text = "Support Website"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(186, 6)
        '
        'toolStripSeparator7
        '
        Me.toolStripSeparator7.Name = "toolStripSeparator7"
        Me.toolStripSeparator7.Size = New System.Drawing.Size(186, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(189, 24)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'ProgrammerToolStripMenuItem
        '
        Me.ProgrammerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WhosLoggedOnToolStripMenuItem, Me.ToolStripSeparator1, Me.ExportFacilityDataToolStripMenuItem, Me.ExportPointDataToolStripMenuItem, Me.ToolStripSeparator3, Me.CheckPollutantUOMToolStripMenuItem, Me.ToolStripSeparator4})
        Me.ProgrammerToolStripMenuItem.Name = "ProgrammerToolStripMenuItem"
        Me.ProgrammerToolStripMenuItem.Size = New System.Drawing.Size(104, 24)
        Me.ProgrammerToolStripMenuItem.Text = "&Programmer"
        '
        'WhosLoggedOnToolStripMenuItem
        '
        Me.WhosLoggedOnToolStripMenuItem.Name = "WhosLoggedOnToolStripMenuItem"
        Me.WhosLoggedOnToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.WhosLoggedOnToolStripMenuItem.Text = "&Who's logged on?"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(216, 6)
        '
        'ExportFacilityDataToolStripMenuItem
        '
        Me.ExportFacilityDataToolStripMenuItem.Name = "ExportFacilityDataToolStripMenuItem"
        Me.ExportFacilityDataToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.ExportFacilityDataToolStripMenuItem.Text = "Export &Facility Data"
        '
        'ExportPointDataToolStripMenuItem
        '
        Me.ExportPointDataToolStripMenuItem.Name = "ExportPointDataToolStripMenuItem"
        Me.ExportPointDataToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.ExportPointDataToolStripMenuItem.Text = "Export Point Data"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(216, 6)
        '
        'CheckPollutantUOMToolStripMenuItem
        '
        Me.CheckPollutantUOMToolStripMenuItem.Name = "CheckPollutantUOMToolStripMenuItem"
        Me.CheckPollutantUOMToolStripMenuItem.Size = New System.Drawing.Size(219, 24)
        Me.CheckPollutantUOMToolStripMenuItem.Text = "Check pollutant UOM"
        Me.CheckPollutantUOMToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(216, 6)
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Import91TFormToolStripMenuItem, Me.Import92TFormToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(57, 24)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'Import91TFormToolStripMenuItem
        '
        Me.Import91TFormToolStripMenuItem.Name = "Import91TFormToolStripMenuItem"
        Me.Import91TFormToolStripMenuItem.Size = New System.Drawing.Size(195, 24)
        Me.Import91TFormToolStripMenuItem.Text = "Import E91T form"
        '
        'Import92TFormToolStripMenuItem
        '
        Me.Import92TFormToolStripMenuItem.Name = "Import92TFormToolStripMenuItem"
        Me.Import92TFormToolStripMenuItem.Size = New System.Drawing.Size(195, 24)
        Me.Import92TFormToolStripMenuItem.Text = "Import E92T form"
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainerMain.Location = New System.Drawing.Point(0, 64)
        Me.SplitContainerMain.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        '
        'SplitContainerMain.Panel1
        '
        Me.SplitContainerMain.Panel1.Controls.Add(Me.SplitContainerLeft)
        '
        'SplitContainerMain.Panel2
        '
        Me.SplitContainerMain.Panel2.AutoScroll = True
        Me.SplitContainerMain.Size = New System.Drawing.Size(1262, 954)
        Me.SplitContainerMain.SplitterDistance = 366
        Me.SplitContainerMain.SplitterWidth = 5
        Me.SplitContainerMain.TabIndex = 0
        Me.SplitContainerMain.TabStop = False
        '
        'SplitContainerLeft
        '
        Me.SplitContainerLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerLeft.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerLeft.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainerLeft.Name = "SplitContainerLeft"
        Me.SplitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerLeft.Panel1
        '
        Me.SplitContainerLeft.Panel1.Controls.Add(Me.TreeViewMain)
        '
        'SplitContainerLeft.Panel2
        '
        Me.SplitContainerLeft.Panel2.Controls.Add(Me.btnControlMeasures)
        Me.SplitContainerLeft.Panel2.Controls.Add(Me.btnPlantsAndReleasePoints)
        Me.SplitContainerLeft.Panel2.Controls.Add(Me.btnPlantsAndProcesses)
        Me.SplitContainerLeft.Size = New System.Drawing.Size(366, 954)
        Me.SplitContainerLeft.SplitterDistance = 595
        Me.SplitContainerLeft.SplitterWidth = 5
        Me.SplitContainerLeft.TabIndex = 0
        Me.SplitContainerLeft.TabStop = False
        '
        'TreeViewMain
        '
        Me.TreeViewMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewMain.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeViewMain.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewMain.Margin = New System.Windows.Forms.Padding(4)
        Me.TreeViewMain.Name = "TreeViewMain"
        Me.TreeViewMain.Size = New System.Drawing.Size(364, 593)
        Me.TreeViewMain.TabIndex = 0
        '
        'btnControlMeasures
        '
        Me.btnControlMeasures.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlMeasures.BackColor = System.Drawing.Color.LightGray
        Me.btnControlMeasures.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnControlMeasures.Location = New System.Drawing.Point(0, 73)
        Me.btnControlMeasures.Margin = New System.Windows.Forms.Padding(4)
        Me.btnControlMeasures.Name = "btnControlMeasures"
        Me.btnControlMeasures.Size = New System.Drawing.Size(363, 37)
        Me.btnControlMeasures.TabIndex = 2
        Me.btnControlMeasures.Text = "Control Measures"
        Me.btnControlMeasures.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnControlMeasures.UseVisualStyleBackColor = False
        '
        'btnPlantsAndReleasePoints
        '
        Me.btnPlantsAndReleasePoints.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPlantsAndReleasePoints.BackColor = System.Drawing.Color.LightGray
        Me.btnPlantsAndReleasePoints.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlantsAndReleasePoints.Location = New System.Drawing.Point(0, 38)
        Me.btnPlantsAndReleasePoints.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlantsAndReleasePoints.Name = "btnPlantsAndReleasePoints"
        Me.btnPlantsAndReleasePoints.Size = New System.Drawing.Size(363, 37)
        Me.btnPlantsAndReleasePoints.TabIndex = 1
        Me.btnPlantsAndReleasePoints.Text = "Release Points"
        Me.btnPlantsAndReleasePoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPlantsAndReleasePoints.UseVisualStyleBackColor = False
        '
        'btnPlantsAndProcesses
        '
        Me.btnPlantsAndProcesses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPlantsAndProcesses.BackColor = System.Drawing.Color.LightGray
        Me.btnPlantsAndProcesses.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlantsAndProcesses.Location = New System.Drawing.Point(0, 4)
        Me.btnPlantsAndProcesses.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPlantsAndProcesses.Name = "btnPlantsAndProcesses"
        Me.btnPlantsAndProcesses.Size = New System.Drawing.Size(363, 37)
        Me.btnPlantsAndProcesses.TabIndex = 0
        Me.btnPlantsAndProcesses.Text = "Emission Units and Processes"
        Me.btnPlantsAndProcesses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPlantsAndProcesses.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusMode, Me.ToolStripSplitButton1, Me.statusLevel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 954)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1262, 25)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusMode
        '
        Me.statusMode.Name = "statusMode"
        Me.statusMode.Size = New System.Drawing.Size(50, 20)
        Me.statusMode.Text = "Ready"
        Me.statusMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 23)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'statusLevel
        '
        Me.statusLevel.Name = "statusLevel"
        Me.statusLevel.Size = New System.Drawing.Size(0, 20)
        Me.statusLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'ControlMeasureTableAdapterManager
        '
        Me.ControlMeasureTableAdapterManager.AffiliationTypeEISTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.ControlMeasureTableAdapterManager.BillingContactsTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.BillingFeeConfigTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.BillingHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.BillingTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ControlMeasureHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ControlMeasurePollutantHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ControlMeasurePollutantTableAdapter = Me.ControlMeasurePollutantTableAdapter
        Me.ControlMeasureTableAdapterManager.ControlMeasureTableAdapter = Me.ControlMeasureTableAdapter
        Me.ControlMeasureTableAdapterManager.ControlMeasureTypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ControlMeasureYearHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ControlMeasureYearTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.EmissionUnitDetailTypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.EmissionUnitTypeGroupTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.EmissionUnitTypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.EmissionYearTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.FacilityCategoryEISTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.FacilitySiteStatusTypeEISTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.FormTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.MeasurementTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.OperatingStatusTypeEISTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PlantEmissionUnitDetailTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PlantEmissionUnitHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PlantEmissionUnitTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PlantEmissionUnitYearHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PlantEmissionUnitYearTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PlantTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PlantYearContactsTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PlantYearFormTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PlantYearHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PlantYearTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PollutantTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.PreBillingTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessClassLevel1TypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessClassLevel2TypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessClassLevel3TypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessClassLevel4TypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessClassTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessControlMeasureHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessControlMeasureTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessDetailPeriodHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessDetailPeriodTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessEmissionHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessEmissionTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessReleasePointHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessReleasePointTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessSeasonalActivityHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessSeasonalActivityTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessYearHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ProcessYearTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ReleasePointDetailHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ReleasePointDetailTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ReleasePointHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ReleasePointTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ReleasePointTypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ReleasePointYearHistoryTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ReleasePointYearTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ReleaseTypeMeasurementTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ReleaseTypeSubTypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ReleaseTypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.ThroughputTypeTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.UnitOfMeasurementTableAdapter = Nothing
        Me.ControlMeasureTableAdapterManager.UpdateOrder = APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ControlMeasurePollutantTableAdapter
        '
        Me.ControlMeasurePollutantTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasurePollutantBindingSource
        '
        Me.ControlMeasurePollutantBindingSource.DataMember = "ControlMeasureControlMeasurePollutant"
        Me.ControlMeasurePollutantBindingSource.DataSource = Me.ControlMeasureBindingSource
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
        'ReleasePointTableAdapterManager
        '
        Me.ReleasePointTableAdapterManager.AffiliationTypeEISTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.ReleasePointTableAdapterManager.BillingContactsTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.BillingFeeConfigTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.BillingHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.BillingTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ControlMeasureHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ControlMeasurePollutantHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ControlMeasurePollutantTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ControlMeasureTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ControlMeasureTypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ControlMeasureYearHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ControlMeasureYearTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.EmissionUnitDetailTypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.EmissionUnitTypeGroupTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.EmissionUnitTypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.EmissionYearTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.FacilityCategoryEISTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.FacilitySiteStatusTypeEISTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.FormTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.MeasurementTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.OperatingStatusTypeEISTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PlantEmissionUnitDetailTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PlantEmissionUnitHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PlantEmissionUnitTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PlantEmissionUnitYearHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PlantEmissionUnitYearTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PlantTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PlantYearContactsTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PlantYearFormTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PlantYearHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PlantYearTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PollutantTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.PreBillingTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessClassLevel1TypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessClassLevel2TypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessClassLevel3TypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessClassLevel4TypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessClassTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessControlMeasureHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessControlMeasureTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessDetailPeriodHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessDetailPeriodTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessEmissionHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessEmissionTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessReleasePointHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessReleasePointTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessSeasonalActivityHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessSeasonalActivityTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessYearHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ProcessYearTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ReleasePointDetailHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ReleasePointDetailTableAdapter = Me.ReleasePointDetailTableAdapter
        Me.ReleasePointTableAdapterManager.ReleasePointHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ReleasePointTableAdapter = Me.ReleasePointTableAdapter
        Me.ReleasePointTableAdapterManager.ReleasePointTypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ReleasePointYearHistoryTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ReleasePointYearTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ReleaseTypeMeasurementTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ReleaseTypeSubTypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ReleaseTypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.ThroughputTypeTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.UnitOfMeasurementTableAdapter = Nothing
        Me.ReleasePointTableAdapterManager.UpdateOrder = APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ReleasePointDetailTableAdapter
        '
        Me.ReleasePointDetailTableAdapter.ClearBeforeFill = True
        '
        'ReleasePointDetailBindingSource
        '
        Me.ReleasePointDetailBindingSource.DataMember = "ReleasePointReleasePointDetail"
        Me.ReleasePointDetailBindingSource.DataSource = Me.ReleasePointBindingSource
        '
        'EmissionYearLabel
        '
        Me.EmissionYearLabel.AutoSize = True
        Me.EmissionYearLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.EmissionYearLabel.Location = New System.Drawing.Point(4, 4)
        Me.EmissionYearLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.EmissionYearLabel.Name = "EmissionYearLabel"
        Me.EmissionYearLabel.Size = New System.Drawing.Size(100, 20)
        Me.EmissionYearLabel.TabIndex = 4
        Me.EmissionYearLabel.Text = "Emission Year"
        '
        'EmissionYearComboBox
        '
        Me.EmissionYearComboBox.DataSource = Me.EmissionYear_GetLookupTableBindingSource
        Me.EmissionYearComboBox.DisplayMember = "EmissionYear"
        Me.EmissionYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmissionYearComboBox.FormattingEnabled = True
        Me.EmissionYearComboBox.Location = New System.Drawing.Point(112, 2)
        Me.EmissionYearComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.EmissionYearComboBox.Name = "EmissionYearComboBox"
        Me.EmissionYearComboBox.Size = New System.Drawing.Size(65, 24)
        Me.EmissionYearComboBox.TabIndex = 6
        Me.EmissionYearComboBox.ValueMember = "EmissionYear"
        '
        'EmissionYear_GetLookupTableBindingSource
        '
        Me.EmissionYear_GetLookupTableBindingSource.DataMember = "EmissionYear_GetLookupTable"
        Me.EmissionYear_GetLookupTableBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PlantBindingSource
        '
        Me.PlantBindingSource.DataMember = "Plant"
        Me.PlantBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PlantTableAdapter
        '
        Me.PlantTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AffiliationTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BillingContactsTableAdapter = Nothing
        Me.TableAdapterManager.BillingFeeConfigTableAdapter = Nothing
        Me.TableAdapterManager.BillingHistoryTableAdapter = Nothing
        Me.TableAdapterManager.BillingTableAdapter = Nothing
        Me.TableAdapterManager.ControlMeasureHistoryTableAdapter = Me.ControlMeasureHistoryTableAdapter
        Me.TableAdapterManager.ControlMeasurePollutantHistoryTableAdapter = Me.ControlMeasurePollutantHistoryTableAdapter
        Me.TableAdapterManager.ControlMeasurePollutantTableAdapter = Me.ControlMeasurePollutantTableAdapter
        Me.TableAdapterManager.ControlMeasureTableAdapter = Me.ControlMeasureTableAdapter
        Me.TableAdapterManager.ControlMeasureTypeTableAdapter = Me.ControlMeasureTypeTableAdapter
        Me.TableAdapterManager.ControlMeasureYearHistoryTableAdapter = Me.ControlMeasureYearHistoryTableAdapter
        Me.TableAdapterManager.ControlMeasureYearTableAdapter = Me.ControlMeasureYearTableAdapter
        Me.TableAdapterManager.EmissionUnitDetailTypeTableAdapter = Nothing
        Me.TableAdapterManager.EmissionUnitTypeGroupTableAdapter = Nothing
        Me.TableAdapterManager.EmissionUnitTypeTableAdapter = Me.EmissionUnitTypeTableAdapter
        Me.TableAdapterManager.EmissionYearTableAdapter = Me.EmissionYearTableAdapter
        Me.TableAdapterManager.FacilityCategoryEISTableAdapter = Nothing
        Me.TableAdapterManager.FacilitySiteStatusTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.FormTableAdapter = Nothing
        Me.TableAdapterManager.MeasurementTableAdapter = Nothing
        Me.TableAdapterManager.OperatingStatusTypeEISTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitDetailTableAdapter = Nothing
        Me.TableAdapterManager.PlantEmissionUnitHistoryTableAdapter = Me.PlantEmissionUnitHistoryTableAdapter
        Me.TableAdapterManager.PlantEmissionUnitTableAdapter = Me.PlantEmissionUnitTableAdapter
        Me.TableAdapterManager.PlantEmissionUnitYearHistoryTableAdapter = Me.PlantEmissionUnitYearHistoryTableAdapter
        Me.TableAdapterManager.PlantEmissionUnitYearTableAdapter = Me.PlantEmissionUnitYearTableAdapter
        Me.TableAdapterManager.PlantTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearContactsTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearFormTableAdapter = Nothing
        Me.TableAdapterManager.PlantYearHistoryTableAdapter = Me.PlantYearHistoryTableAdapter
        Me.TableAdapterManager.PlantYearTableAdapter = Me.PlantYearTableAdapter
        Me.TableAdapterManager.PollutantTableAdapter = Me.PollutantTableAdapter
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
        Me.TableAdapterManager.ProcessTableAdapter = Me.ProcessTableAdapter
        Me.TableAdapterManager.ProcessYearHistoryTableAdapter = Me.ProcessYearHistoryTableAdapter
        Me.TableAdapterManager.ProcessYearTableAdapter = Me.ProcessYearTableAdapter
        Me.TableAdapterManager.ReleasePointDetailHistoryTableAdapter = Me.ReleasePointDetailHistoryTableAdapter
        Me.TableAdapterManager.ReleasePointDetailTableAdapter = Me.ReleasePointDetailTableAdapter
        Me.TableAdapterManager.ReleasePointHistoryTableAdapter = Me.ReleasePointHistoryTableAdapter
        Me.TableAdapterManager.ReleasePointTableAdapter = Me.ReleasePointTableAdapter
        Me.TableAdapterManager.ReleasePointTypeTableAdapter = Nothing
        Me.TableAdapterManager.ReleasePointYearHistoryTableAdapter = Me.ReleasePointYearHistoryTableAdapter
        Me.TableAdapterManager.ReleasePointYearTableAdapter = Me.ReleasePointYearTableAdapter
        Me.TableAdapterManager.ReleaseTypeMeasurementTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeSubTypeTableAdapter = Nothing
        Me.TableAdapterManager.ReleaseTypeTableAdapter = Nothing
        Me.TableAdapterManager.ThroughputTypeTableAdapter = Me.ThroughputTypeTableAdapter
        Me.TableAdapterManager.UnitOfMeasurementTableAdapter = Me.UnitOfMeasurementTableAdapter
        Me.TableAdapterManager.UpdateOrder = APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ControlMeasureHistoryTableAdapter
        '
        Me.ControlMeasureHistoryTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasurePollutantHistoryTableAdapter
        '
        Me.ControlMeasurePollutantHistoryTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasureTypeTableAdapter
        '
        Me.ControlMeasureTypeTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasureYearHistoryTableAdapter
        '
        Me.ControlMeasureYearHistoryTableAdapter.ClearBeforeFill = True
        '
        'ControlMeasureYearTableAdapter
        '
        Me.ControlMeasureYearTableAdapter.ClearBeforeFill = True
        '
        'EmissionUnitTypeTableAdapter
        '
        Me.EmissionUnitTypeTableAdapter.ClearBeforeFill = True
        '
        'EmissionYearTableAdapter
        '
        Me.EmissionYearTableAdapter.ClearBeforeFill = True
        '
        'PlantEmissionUnitHistoryTableAdapter
        '
        Me.PlantEmissionUnitHistoryTableAdapter.ClearBeforeFill = True
        '
        'PlantEmissionUnitTableAdapter
        '
        Me.PlantEmissionUnitTableAdapter.ClearBeforeFill = True
        '
        'PlantEmissionUnitYearHistoryTableAdapter
        '
        Me.PlantEmissionUnitYearHistoryTableAdapter.ClearBeforeFill = True
        '
        'PlantEmissionUnitYearTableAdapter
        '
        Me.PlantEmissionUnitYearTableAdapter.ClearBeforeFill = True
        '
        'PlantYearHistoryTableAdapter
        '
        Me.PlantYearHistoryTableAdapter.ClearBeforeFill = True
        '
        'PlantYearTableAdapter
        '
        Me.PlantYearTableAdapter.ClearBeforeFill = True
        '
        'PollutantTableAdapter
        '
        Me.PollutantTableAdapter.ClearBeforeFill = True
        '
        'ProcessTableAdapter
        '
        Me.ProcessTableAdapter.ClearBeforeFill = True
        '
        'ProcessYearHistoryTableAdapter
        '
        Me.ProcessYearHistoryTableAdapter.ClearBeforeFill = True
        '
        'ProcessYearTableAdapter
        '
        Me.ProcessYearTableAdapter.ClearBeforeFill = True
        '
        'ReleasePointDetailHistoryTableAdapter
        '
        Me.ReleasePointDetailHistoryTableAdapter.ClearBeforeFill = True
        '
        'ReleasePointHistoryTableAdapter
        '
        Me.ReleasePointHistoryTableAdapter.ClearBeforeFill = True
        '
        'ReleasePointYearHistoryTableAdapter
        '
        Me.ReleasePointYearHistoryTableAdapter.ClearBeforeFill = True
        '
        'ReleasePointYearTableAdapter
        '
        Me.ReleasePointYearTableAdapter.ClearBeforeFill = True
        '
        'ThroughputTypeTableAdapter
        '
        Me.ThroughputTypeTableAdapter.ClearBeforeFill = True
        '
        'UnitOfMeasurementTableAdapter
        '
        Me.UnitOfMeasurementTableAdapter.ClearBeforeFill = True
        '
        'PlantEmissionUnitBindingSource
        '
        Me.PlantEmissionUnitBindingSource.DataMember = "PlantEmissionUnit"
        Me.PlantEmissionUnitBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PlantEmissionUnitYearBindingSource
        '
        Me.PlantEmissionUnitYearBindingSource.DataMember = "PlantEmissionUnitYear"
        Me.PlantEmissionUnitYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'EmissionYearBindingSource
        '
        Me.EmissionYearBindingSource.DataMember = "EmissionYear"
        Me.EmissionYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'EmissionYear_GetLookupTableTableAdapter
        '
        Me.EmissionYear_GetLookupTableTableAdapter.ClearBeforeFill = True
        '
        'PlantEmissionUnitHistoryBindingSource
        '
        Me.PlantEmissionUnitHistoryBindingSource.DataMember = "PlantEmissionUnitHistory"
        Me.PlantEmissionUnitHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PlantEmissionUnitYearHistoryBindingSource
        '
        Me.PlantEmissionUnitYearHistoryBindingSource.DataMember = "PlantEmissionUnitYearHistory"
        Me.PlantEmissionUnitYearHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasureYearBindingSource
        '
        Me.ControlMeasureYearBindingSource.DataMember = "ControlMeasureYear"
        Me.ControlMeasureYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasureYearHistoryBindingSource
        '
        Me.ControlMeasureYearHistoryBindingSource.DataMember = "ControlMeasureYearHistory"
        Me.ControlMeasureYearHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasureHistoryBindingSource
        '
        Me.ControlMeasureHistoryBindingSource.DataMember = "ControlMeasureHistory"
        Me.ControlMeasureHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasurePollutantHistoryBindingSource
        '
        Me.ControlMeasurePollutantHistoryBindingSource.DataMember = "ControlMeasurePollutantHistory"
        Me.ControlMeasurePollutantHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleasePointHistoryBindingSource
        '
        Me.ReleasePointHistoryBindingSource.DataMember = "ReleasePointHistory"
        Me.ReleasePointHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleasePointYearBindingSource
        '
        Me.ReleasePointYearBindingSource.DataMember = "ReleasePointYear"
        Me.ReleasePointYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleasePointYearHistoryBindingSource
        '
        Me.ReleasePointYearHistoryBindingSource.DataMember = "ReleasePointYearHistory"
        Me.ReleasePointYearHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ReleasePointDetailHistoryBindingSource
        '
        Me.ReleasePointDetailHistoryBindingSource.DataMember = "ReleasePointDetailHistory"
        Me.ReleasePointDetailHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessBindingSource
        '
        Me.ProcessBindingSource.DataMember = "Process"
        Me.ProcessBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessYearBindingSource
        '
        Me.ProcessYearBindingSource.DataMember = "ProcessYear"
        Me.ProcessYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessHistoryBindingSource
        '
        Me.ProcessHistoryBindingSource.DataMember = "ProcessHistory"
        Me.ProcessHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessHistoryTableAdapter
        '
        Me.ProcessHistoryTableAdapter.ClearBeforeFill = True
        '
        'ProcessYearHistoryBindingSource
        '
        Me.ProcessYearHistoryBindingSource.DataMember = "ProcessYearHistory"
        Me.ProcessYearHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'UnitOfMeasurementBindingSource
        '
        Me.UnitOfMeasurementBindingSource.DataMember = "UnitOfMeasurement"
        Me.UnitOfMeasurementBindingSource.DataSource = Me.EmissionsDataSet
        '
        'lblWhereAmI
        '
        Me.lblWhereAmI.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblWhereAmI.Location = New System.Drawing.Point(383, 7)
        Me.lblWhereAmI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWhereAmI.Name = "lblWhereAmI"
        Me.lblWhereAmI.Size = New System.Drawing.Size(948, 22)
        Me.lblWhereAmI.TabIndex = 7
        Me.lblWhereAmI.Text = "Where Am I"
        Me.lblWhereAmI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EmissionUnitTypeBindingSource
        '
        Me.EmissionUnitTypeBindingSource.DataMember = "EmissionUnitType"
        Me.EmissionUnitTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ThroughputTypeBindingSource
        '
        Me.ThroughputTypeBindingSource.DataMember = "ThroughputType"
        Me.ThroughputTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ControlMeasureTypeBindingSource
        '
        Me.ControlMeasureTypeBindingSource.DataMember = "ControlMeasureType"
        Me.ControlMeasureTypeBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PlantYearBindingSource
        '
        Me.PlantYearBindingSource.DataMember = "PlantYear"
        Me.PlantYearBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PlantYearHistoryBindingSource
        '
        Me.PlantYearHistoryBindingSource.DataMember = "PlantYearHistory"
        Me.PlantYearHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'PollutantBindingSource
        '
        Me.PollutantBindingSource.DataMember = "Pollutant"
        Me.PollutantBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessControlMeasureBindingSource
        '
        Me.ProcessControlMeasureBindingSource.DataMember = "ProcessControlMeasure"
        Me.ProcessControlMeasureBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessControlMeasureTableAdapter
        '
        Me.ProcessControlMeasureTableAdapter.ClearBeforeFill = True
        '
        'ProcessControlMeasureHistoryBindingSource
        '
        Me.ProcessControlMeasureHistoryBindingSource.DataMember = "ProcessControlMeasureHistory"
        Me.ProcessControlMeasureHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessControlMeasureHistoryTableAdapter
        '
        Me.ProcessControlMeasureHistoryTableAdapter.ClearBeforeFill = True
        '
        'ProcessReleasePointBindingSource
        '
        Me.ProcessReleasePointBindingSource.DataMember = "ProcessReleasePoint"
        Me.ProcessReleasePointBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessReleasePointTableAdapter
        '
        Me.ProcessReleasePointTableAdapter.ClearBeforeFill = True
        '
        'ProcessReleasePointHistoryBindingSource
        '
        Me.ProcessReleasePointHistoryBindingSource.DataMember = "ProcessReleasePointHistory"
        Me.ProcessReleasePointHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessReleasePointHistoryTableAdapter
        '
        Me.ProcessReleasePointHistoryTableAdapter.ClearBeforeFill = True
        '
        'Process_ControlMeasureTabBindingSource
        '
        Me.Process_ControlMeasureTabBindingSource.DataMember = "Process_ControlMeasureTab"
        Me.Process_ControlMeasureTabBindingSource.DataSource = Me.EmissionsDataSet
        '
        'Process_ControlMeasureTabTableAdapter
        '
        Me.Process_ControlMeasureTabTableAdapter.ClearBeforeFill = True
        '
        'Process_ReleasePointTabBindingSource
        '
        Me.Process_ReleasePointTabBindingSource.DataMember = "Process_ReleasePointTab"
        Me.Process_ReleasePointTabBindingSource.DataSource = Me.EmissionsDataSet
        '
        'Process_ReleasePointTabTableAdapter
        '
        Me.Process_ReleasePointTabTableAdapter.ClearBeforeFill = True
        '
        'ProcessEmissionBindingSource
        '
        Me.ProcessEmissionBindingSource.DataMember = "ProcessEmission"
        Me.ProcessEmissionBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessEmissionTableAdapter
        '
        Me.ProcessEmissionTableAdapter.ClearBeforeFill = True
        '
        'Process_EmissionsTabBindingSource
        '
        Me.Process_EmissionsTabBindingSource.DataMember = "Process_EmissionsTab"
        Me.Process_EmissionsTabBindingSource.DataSource = Me.EmissionsDataSet
        '
        'Process_EmissionsTabTableAdapter
        '
        Me.Process_EmissionsTabTableAdapter.ClearBeforeFill = True
        '
        'ProcessEmissionHistoryBindingSource
        '
        Me.ProcessEmissionHistoryBindingSource.DataMember = "ProcessEmissionHistory"
        Me.ProcessEmissionHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessEmissionHistoryTableAdapter
        '
        Me.ProcessEmissionHistoryTableAdapter.ClearBeforeFill = True
        '
        'Process_ThroughputTabBindingSource
        '
        Me.Process_ThroughputTabBindingSource.DataMember = "Process_ThroughputTab"
        Me.Process_ThroughputTabBindingSource.DataSource = Me.EmissionsDataSet
        '
        'Process_ThroughputTabTableAdapter
        '
        Me.Process_ThroughputTabTableAdapter.ClearBeforeFill = True
        '
        'ProcessSeasonalActivityBindingSource
        '
        Me.ProcessSeasonalActivityBindingSource.DataMember = "ProcessSeasonalActivity"
        Me.ProcessSeasonalActivityBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessSeasonalActivityTableAdapter
        '
        Me.ProcessSeasonalActivityTableAdapter.ClearBeforeFill = True
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
        'ProcessDetailPeriodHistoryBindingSource
        '
        Me.ProcessDetailPeriodHistoryBindingSource.DataMember = "ProcessDetailPeriodHistory"
        Me.ProcessDetailPeriodHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessDetailPeriodHistoryTableAdapter
        '
        Me.ProcessDetailPeriodHistoryTableAdapter.ClearBeforeFill = True
        '
        'ProcessSeasonalActivityHistoryBindingSource
        '
        Me.ProcessSeasonalActivityHistoryBindingSource.DataMember = "ProcessSeasonalActivityHistory"
        Me.ProcessSeasonalActivityHistoryBindingSource.DataSource = Me.EmissionsDataSet
        '
        'ProcessSeasonalActivityHistoryTableAdapter
        '
        Me.ProcessSeasonalActivityHistoryTableAdapter.ClearBeforeFill = True
        '
        'TopNavigationPanel
        '
        Me.TopNavigationPanel.Controls.Add(Me.lblWhereAmI)
        Me.TopNavigationPanel.Controls.Add(Me.EmissionYearLabel)
        Me.TopNavigationPanel.Controls.Add(Me.EmissionYearComboBox)
        Me.TopNavigationPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopNavigationPanel.Location = New System.Drawing.Point(0, 28)
        Me.TopNavigationPanel.Name = "TopNavigationPanel"
        Me.TopNavigationPanel.Size = New System.Drawing.Size(1262, 30)
        Me.TopNavigationPanel.TabIndex = 1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 979)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Controls.Add(Me.TopNavigationPanel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APCD Emissions Inventory"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainerMain.Panel1.ResumeLayout(False)
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        Me.SplitContainerLeft.Panel1.ResumeLayout(False)
        Me.SplitContainerLeft.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerLeft.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.EmissionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasurePollutantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionYear_GetLookupTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantEmissionUnitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantEmissionUnitYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantEmissionUnitHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantEmissionUnitYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasurePollutantHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReleasePointDetailHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnitOfMeasurementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmissionUnitTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThroughputTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlMeasureTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantYearBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlantYearHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PollutantBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessControlMeasureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessControlMeasureHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessReleasePointBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessReleasePointHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Process_ControlMeasureTabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Process_ReleasePointTabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessEmissionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Process_EmissionsTabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessEmissionHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Process_ThroughputTabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessSeasonalActivityBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessDetailPeriodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessDetailPeriodHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProcessSeasonalActivityHistoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopNavigationPanel.ResumeLayout(False)
        Me.TopNavigationPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainerMain As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerLeft As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeViewMain As System.Windows.Forms.TreeView
    Friend WithEvents btnPlantsAndProcesses As System.Windows.Forms.Button
    Friend WithEvents btnPlantsAndReleasePoints As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusMode As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusLevel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgrammerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WhosLoggedOnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnControlMeasures As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportFacilityDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportPointDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmissionsDataSet As APCD.EmissionsInventory.EmissionsDataSet
    Friend WithEvents ControlMeasureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTableAdapter
    Friend WithEvents ControlMeasureTableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ControlMeasurePollutantTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasurePollutantTableAdapter
    Friend WithEvents ControlMeasurePollutantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointTableAdapter
    Friend WithEvents ReleasePointTableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ReleasePointDetailTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointDetailTableAdapter
    Friend WithEvents ReleasePointDetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionYearLabel As System.Windows.Forms.Label
    Friend WithEvents EmissionYearComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PlantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantTableAdapter
    Friend WithEvents TableAdapterManager As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PlantEmissionUnitTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitTableAdapter
    Friend WithEvents PlantEmissionUnitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantEmissionUnitYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitYearTableAdapter
    Friend WithEvents PlantEmissionUnitYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.EmissionYearTableAdapter
    Friend WithEvents EmissionYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionYear_GetLookupTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionYear_GetLookupTableTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.EmissionYear_GetLookupTableTableAdapter
    Friend WithEvents PlantEmissionUnitHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantEmissionUnitHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitHistoryTableAdapter
    Friend WithEvents PlantEmissionUnitYearHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantEmissionUnitYearHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantEmissionUnitYearHistoryTableAdapter
    Friend WithEvents ControlMeasureYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureYearTableAdapter
    Friend WithEvents ControlMeasureYearHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureYearHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureYearHistoryTableAdapter
    Friend WithEvents ControlMeasureHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureHistoryTableAdapter
    Friend WithEvents ControlMeasurePollutantHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasurePollutantHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasurePollutantHistoryTableAdapter
    Friend WithEvents ReleasePointHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointHistoryTableAdapter
    Friend WithEvents ReleasePointYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointYearTableAdapter
    Friend WithEvents ReleasePointYearHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointYearHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointYearHistoryTableAdapter
    Friend WithEvents ReleasePointDetailHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReleasePointDetailHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ReleasePointDetailHistoryTableAdapter
    Friend WithEvents ProcessBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessTableAdapter
    Friend WithEvents ProcessYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessYearTableAdapter
    Friend WithEvents ProcessHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessHistoryTableAdapter
    Friend WithEvents ProcessYearHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessYearHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessYearHistoryTableAdapter
    Friend WithEvents UnitOfMeasurementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UnitOfMeasurementTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.UnitOfMeasurementTableAdapter
    Friend WithEvents lblWhereAmI As System.Windows.Forms.Label
    Friend WithEvents EmissionUnitTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmissionUnitTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.EmissionUnitTypeTableAdapter
    Friend WithEvents ThroughputTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ThroughputTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ThroughputTypeTableAdapter
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ControlMeasureTypeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ControlMeasureTypeTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ControlMeasureTypeTableAdapter
    Friend WithEvents PlantYearBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantYearTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearTableAdapter
    Friend WithEvents PlantYearHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlantYearHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PlantYearHistoryTableAdapter
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents PollutantBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PollutantTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.PollutantTableAdapter
    Friend WithEvents CheckPollutantUOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Import91TFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Import92TFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateInvoicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateAnnaulNotificationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupportWebsiteMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessControlMeasureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessControlMeasureTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessControlMeasureTableAdapter
    Friend WithEvents ProcessControlMeasureHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessControlMeasureHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessControlMeasureHistoryTableAdapter
    Friend WithEvents ProcessReleasePointBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessReleasePointTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessReleasePointTableAdapter
    Friend WithEvents ProcessReleasePointHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessReleasePointHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessReleasePointHistoryTableAdapter
    Friend WithEvents Process_ControlMeasureTabBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Process_ControlMeasureTabTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ControlMeasureTabTableAdapter
    Friend WithEvents Process_ReleasePointTabBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Process_ReleasePointTabTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ReleasePointTabTableAdapter
    Friend WithEvents ProcessEmissionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessEmissionTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessEmissionTableAdapter
    Friend WithEvents Process_EmissionsTabBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Process_EmissionsTabTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_EmissionsTabTableAdapter
    Friend WithEvents ProcessEmissionHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessEmissionHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessEmissionHistoryTableAdapter
    Friend WithEvents Process_ThroughputTabBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Process_ThroughputTabTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.Process_ThroughputTabTableAdapter
    Friend WithEvents ProcessSeasonalActivityBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessSeasonalActivityTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessSeasonalActivityTableAdapter
    Friend WithEvents ProcessDetailPeriodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessDetailPeriodTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessDetailPeriodTableAdapter
    Friend WithEvents ProcessDetailPeriodHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessDetailPeriodHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessDetailPeriodHistoryTableAdapter
    Friend WithEvents ProcessSeasonalActivityHistoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProcessSeasonalActivityHistoryTableAdapter As APCD.EmissionsInventory.EmissionsDataSetTableAdapters.ProcessSeasonalActivityHistoryTableAdapter
    Friend WithEvents TopNavigationPanel As System.Windows.Forms.Panel



End Class
