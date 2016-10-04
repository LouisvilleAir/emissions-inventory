Imports System.Text
Imports APCD.Common
Imports APCD.Emissions

Public Class GlobalVariables

    Friend Structure DatabaseName
        Const AirPollution As String = "AirPollution"
        Const Applications As String = "Applications"
        Const Emissions As String = "Emissions"
        Const EmissionsEIS_FacilityExport As String = "EmissionsEIS_FacilityExport"
        Const EmissionsPointExport As String = "EmissionsPointExport"
        Const Facilities As String = "Facilities"
        Const Geography As String = "Geography"
        Const People As String = "People"
    End Structure

    Friend Structure LookupTable
        Public Shared ControlMeasureType As New EmissionsDataSet.ControlMeasureTypeDataTable
        Public Shared EmissionUnitType As New EmissionsDataSet.EmissionUnitTypeDataTable
        Public Shared EmissionUnitType_Real As New EmissionsDataSet.EmissionUnitTypeDataTable
        Public Shared Plant As New EmissionsDataSet.PlantDataTable
        Public Shared Pollutant As New EmissionsDataSet.PollutantDataTable
        Public Shared ThroughputType As New EmissionsDataSet.ThroughputTypeDataTable
        Public Shared ThroughputType_Real As New EmissionsDataSet.ThroughputTypeDataTable
        Public Shared UnitOfMeasurement As New EmissionsDataSet.UnitOfMeasurementDataTable
    End Structure

    Public Enum ButtonMode
        ControlMeasures
        Processes
        ReleasePoints
    End Enum

    Public Enum DMLMode
        Insert
        Update
        Delete
        View
    End Enum

    ''' <summary>
    ''' Some common pollutants
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum PollutantEnum
        CO = 589
        NOX = 602
        PM10FILT = 611
        PM10PRIM = 612
        PM25FILT = 614
        PM25PRIM = 615
        SO2 = 621
        VOC = 624
    End Enum

    ''' <summary>
    ''' Some common units of measurement
    ''' </summary>
    ''' <remarks>Values must match those in the UnitOfMeasurement table.</remarks>
    Public Enum UnitOfMeasurementEnum
        actualCubicFeetPerMinute = 659
        compassDegrees = 14
        degreesFahrenheit = 15
        feet = 515
        pounds = 525
        tons = 528
        hours = 503
        days = 504
        weeks = 505
    End Enum

    Friend Structure UnitOfMeasurement
        Const pounds As String = "pounds"
        Const tons As String = "tons"
    End Structure

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>Values must match those in the ProcessParameterType table.</remarks>
    Public Enum ProcessParameterTypeEnum
        AnnualThroughput = 1
        HeatContent = 2
        PercentAshContent = 3
        PercentSulfurContent = 4
        MaterialVaporPressure = 5
        MaterialDensity = 6
        MaterialVOCContent = 7
        TotalDissolvedSolids = 8
        HoursPerDay = 9
        DaysPerWeek = 10
        WeeksPerYear = 11
        HoursPerYear = 12
        OzoneSeasonDailyThroughput = 13
    End Enum



    Friend Structure OperatingStatus
        Const Operating As String = "OP"
        Const Shutdown As String = "PS"
        Const TemporaryShutdown As String = "TS"
    End Structure

    Public Enum InventoryStatus
        None = -1
        Added
        Deleted
        Modified
        Shutdown
        Approved
        UnApproved
        EmissionYearClosed
    End Enum

    Public Enum ApprovalStatus
        Approved
        UnApproved
    End Enum

    Public Enum ApplicationModeEnum
        Development
        Test
        Production
    End Enum

    Private Shared m_strApplicationMode As ApplicationModeEnum
    Public Shared Property ApplicationMode() As ApplicationModeEnum
        Get
            Return m_strApplicationMode
        End Get
        Set(ByVal value As ApplicationModeEnum)
            m_strApplicationMode = value
        End Set
    End Property

    Public Enum Role
        User
        PowerUser
        Administrator
        Programmer
        Guest
        Approver
    End Enum


#Region "----- authentication -----"

    Private Shared m_enumUserRole As GlobalVariables.Role
    Public Shared Property UserRole() As GlobalVariables.Role
        Get
            Return m_enumUserRole
        End Get
        Set(ByVal value As GlobalVariables.Role)
            m_enumUserRole = value
        End Set
    End Property

    Private Shared m_colorConnectionStatusColor As Color
    Public Shared Property ConnectionStatusColor() As Color
        Get
            Return m_colorConnectionStatusColor
        End Get
        Set(ByVal value As Color)
            m_colorConnectionStatusColor = value
        End Set
    End Property

    Private Shared m_objEmployeeApplication As Applications.Business.EmployeeApplication
    Public Shared Property EmployeeApplication() As Applications.Business.EmployeeApplication
        Get
            Return m_objEmployeeApplication
        End Get
        Set(ByVal value As Applications.Business.EmployeeApplication)
            m_objEmployeeApplication = value
        End Set
    End Property

    Private Shared m_objEmployee As PeopleLibrary.Business.Employee
    Public Shared Property Employee() As PeopleLibrary.Business.Employee
        Get
            Return m_objEmployee
        End Get
        Set(ByVal value As PeopleLibrary.Business.Employee)
            m_objEmployee = value
        End Set
    End Property

    Private Shared m_objApplication As Applications.Business.Application
    Public Shared Property Application() As Applications.Business.Application
        Get
            Return m_objApplication
        End Get
        Set(ByVal value As Applications.Business.Application)
            m_objApplication = value
        End Set
    End Property


#End Region '----- authentication -----

#Region "----- navigation -----"

    ''Friend Structure NavigationTable

    ''    Private _trash As String
    ''    Public Shared PlantEmissionUnit As New Navigation_EmissionsDataSet.PlantEmissionUnit_NavigationViewDataTable


    ''    'Public Shared Emission As NavigationDataSet.Emissions_GetNavigationViewDatTable = New NavigationDataSet.Emissions_GetNavigationViewDataTable
    ''    Public Shared ReleasePoint As New Navigation_EmissionsDataSet.ReleasePoint_NavigationViewDataTable

    ''End Structure

    ''Friend Structure TableAdapter

    ''    Private _trash As String
    ''    Public Shared PlantEmissionUnit As APCD.EmissionsInventory.Navigation_EmissionsDataSetTableAdapters.PlantEmissionUnit_NavigationViewTableAdapter

    ''    ''Public Shared Process As APCD.EmissionsInventory.Navigation_EmissionsDataSetTableAdapters.Process_NavigationViewTableAdapter

    ''    'Public Shared Emission As APCD.EmissionsInventory.NavigationDataSetTableAdapters.Emissions_GetNavigationViewTableAdapter
    ''    Public Shared ReleasePoint As APCD.EmissionsInventory.Navigation_EmissionsDataSetTableAdapters.ReleasePoint_NavigationViewTableAdapter

    ''End Structure

    ''Friend Shared Sub InitializeDatasetTableAdapters()
    ''    TableAdapter.PlantEmissionUnit = New APCD.EmissionsInventory.Navigation_EmissionsDataSetTableAdapters.PlantEmissionUnit_NavigationViewTableAdapter

    ''    ''TableAdapter.Process = New APCD.EmissionsInventory.Navigation_EmissionsDataSetTableAdapters.Process_NavigationViewTableAdapter

    ''    '        GlobalVariables.TableAdapter.Emission = New APCD.EmissionsInventory.NavigationDataSetTableAdapters.Emissions_GetNavigationViewTableAdapter
    ''    TableAdapter.ReleasePoint = New APCD.EmissionsInventory.Navigation_EmissionsDataSetTableAdapters.ReleasePoint_NavigationViewTableAdapter

    ''End Sub

    ''Friend Shared Sub LoadNavigationTables()

    ''    Call LoadPlantEmissionUnitNavigationTable()
    ''    ''Call LoadProcessNavigationTable()
    ''    '       GlobalVariables.TableAdapter.Emission.Fill(GlobalVariables.NavigationTable.Emission)
    ''    Call LoadReleasePointNavigationTable()

    ''End Sub

    ''Friend Shared Sub LoadPlantEmissionUnitNavigationTable()
    ''    TableAdapter.PlantEmissionUnit.Fill(GlobalVariables.NavigationTable.PlantEmissionUnit)
    ''End Sub

    ''Friend Shared Sub LoadProcessNavigationTable
    ''    TableAdapter.Process.Fill(GlobalVariables.NavigationTable.Process)
    ''End Sub

    ''Friend Shared Sub LoadReleasePointNavigationTable()
    ''    TableAdapter.ReleasePoint.Fill(GlobalVariables.NavigationTable.ReleasePoint)
    ''End Sub

#End Region '----- navigation -----

#Region "----- error messages -----"

    Friend Structure ErrorPrompt

        Friend Structure Database
            Const APCDIDAlreadyExists As String = "The specified APCD ID is already being used."
            Const DeletingRecord As String = "An error occurred while deleting a record. Please contact APCD IT support for assistance."
            Const SavingRecord As String = "An error occurred while saving the record. Please contact APCD IT support for assistance."
            Const DuplicateKey As String = "It appears you are trying a add a new record whose identifying information is the same as that of an existing record!"
        End Structure

        Friend Structure Misc
            Const ActionCancelled As String = "Action Cancelled"
            Const AllValuesMustBeGreaterThanOrEqualToZero As String = "All values must be greater than or equal to zero."
            Const EnterAValue As String = "Enter a value."
            Const SelectAUnitOfMeasurement As String = "Select a unit of measurement."

            Const ValueMustBeNumeric As String = "Value must be numeric"
            Const ValueMustBeGreaterThanOrEqualToZero As String = "Value must be greater than or equal to zero."
            Const ValueMustBeGreaterThan0AndLessThanOrEqualTo100 As String = "Value must be greater than zero and less than or equal to 100."
            Const ValueMustBeBetween0And100 As String = "Value must be between 0 and 100."
            Const ValueMustBeGreaterThanOrEqualTo0AndLessThan100 As String = "Value must be greater than or equal to 0 and less than 100."

            Const EnterAValidDate As String = "Enter a valid date"

        End Structure

    End Structure

    Friend Structure ErrorMessage

        Friend Structure Database
            Const DuplicateRecord As String = "The changes you requested to the table were not successful because they would create duplicate values in the index, primary key, or relationship.  Change the data in the field or fields that contain duplicate data, remove the index, or redefine the index to permit duplicate entries and try again."
        End Structure

    End Structure

#End Region '----- error messages -----

    Friend Structure Words
        Const _And As String = "And"
        Const _In As String = "In"
        Const _Or As String = "Or"
        Const _Is As String = "Is"
        Const _Not As String = "Not"
        Const _Null As String = "Null"

        Const Approve As String = "Approve"
        Const Delete As String = "Delete"
        Const Shutdown As String = "Shut down"
        Const Unapprove As String = "Un-approve"
        Const Unknown As String = "Unknown"

        Const SystemApproved As String = "SYSTEM APPROVED"




    End Structure

    Friend Structure DateFormat
        Const _Short As String = "M/dd/yyyy"
        Const _Medium As String = "MMMM dd, yyyy"
    End Structure

    Friend Structure NumberFormat
        'per Predefined Numeric Formats (Format Function)
        'http://msdn.microsoft.com/en-us/library/y006s0cz(v=vs.90).aspx
        Const Currency As String = "Currency" ' Displays number with thousand separator, if appropriate; displays two digits to the right of the decimal separator. Output is based on system locale settings.
        Const Standard As String = "Standard" 'Displays number with thousand separator, at least one digit to the left and two digits to the right of the decimal separator.
    End Structure

#Region "----- log and log locations -----"

    Public Shared ReadOnly Property APCDApplicationsRootDataDirectory() As String
        Get
            Return My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\APCD Applications"
        End Get
    End Property

    Public Shared ReadOnly Property ApplicationDataDirectory As String
        Get
            Return APCDApplicationsRootDataDirectory & Tools.Constants.Character.BackSlash & My.Application.Info.ProductName
        End Get
    End Property

    Public Shared ReadOnly Property ApplicationConfigurationDirectory As String
        Get
            Return ApplicationDataDirectory & "\Config"
        End Get
    End Property

    Public Shared ReadOnly Property TestLogDirectory() As String
        Get
            Return "G:\DATA\Test\Application Logs\" _
                   & My.Application.Info.ProductName _
                   & Tools.Constants.Character.BackSlash & Format(Now, "yyyyMMdd") & ".log"
        End Get
    End Property

    Public Shared ReadOnly Property ProductionLogDirectory() As String
        Get
            Return "G:\DATA\Production\Application Logs\" _
                   & My.Application.Info.ProductName _
                   & Tools.Constants.Character.BackSlash & Format(Now, "yyyyMMdd") & ".log"
        End Get
    End Property

    Private Shared m_strbApplicationLog As StringBuilder = New StringBuilder
    Public Shared Property ApplicationLog() As StringBuilder
        Get
            Return m_strbApplicationLog
        End Get
        Set(ByVal value As StringBuilder)
            m_strbApplicationLog = value
        End Set
    End Property

    Private Shared m_strLogFullName As String
    Public Shared Property LogFullName() As String
        Get
            Return m_strLogFullName
        End Get
        Set(ByVal value As String)
            m_strLogFullName = value
        End Set
    End Property


#End Region '----- log locations -----

    Public Enum MainConnectionStatusEnum
        Available
        Unavailable
    End Enum

    Private Shared enumMainConnectionStatus As MainConnectionStatusEnum
    Public Shared Property MainConnectionStatus() As MainConnectionStatusEnum
        Get
            Return enumMainConnectionStatus
        End Get
        Set(ByVal value As MainConnectionStatusEnum)
            enumMainConnectionStatus = value
        End Set
    End Property

    Public Enum DatabaseModeEnum
        Development
        Test
        Production
    End Enum

    Private Shared m_strDatabaseMode As DatabaseModeEnum
    Public Shared Property DatabaseMode() As DatabaseModeEnum
        Get
            Return m_strDatabaseMode
        End Get
        Set(ByVal value As DatabaseModeEnum)
            m_strDatabaseMode = value
        End Set
    End Property


#Region "----- MainForm -----"

    Friend Enum WizardStep
        _Back
        _Cancel
        _Next
        _Save
    End Enum

    Friend Shared AddReleasePointStep As WizardStep
    Friend Shared AddProcessStep As WizardStep
    Friend Shared AddControlMeasureStep As WizardStep

#End Region '----- MainForm -----

    Friend Structure TemplateDirectory
        Shared Development As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Projects\Emissions\AutomationTemplates\"
        Shared Production As String = "G:\DATA\Production\Emissions\AutomationTemplates\"
    End Structure

    Friend Structure TemplateName
        'billing
        Public Const PreBill As String = "EmissionsPreBill.dotx"
        Public Const Bill As String = "EmissionsBill.dotx"

        'EI forms
        Public Const E91T As String = "E91T-ReleasePoints.xltx"
        Public Const E92T As String = "E92T-ControlMeasures.xltx"

    End Structure

    Friend Enum PlantClassEnum
        TitleV = 1
        FEDOOP = 2
        Minor = 3
    End Enum

End Class
