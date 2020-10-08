using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.Core;
using MvvmCross.UI;
using MvvmCross.ViewModels;
using TinyCollege.Core.Helpers;
using TinyCollege.Data.Interfaces;
using TinyCollege.Data.Interfaces.IMotorPool;
using TinyCollege.Data.Models;
using TinyCollege.Data.Models.MotorPool;
using TinyCollege.Service.Services;
using TinyCollege.Service.Services.MotorPool;

namespace TinyCollege.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly SuperService _superService;

        public MainViewModel()
        {
            _superService = new SuperService();
            _Initialize();
            _AddCommands();
        }

        private void _Initialize()
        {
            var students = _superService.StudentService.GetStudents().ToList();
            BrowserEnumerable = new ObservableCollection<IStudent>(students);
        }

        private void _AddCommands()
        {
            #region View_Entities_Commands_and_Methods_Initialization
            ViewEmployeesCommand = new MvxCommand(_ViewEmployees);
            ViewMaintenancesCommand = new MvxCommand(_ViewMaintenances);
            ViewMaintenanceDetailsCommand = new MvxCommand(_ViewMaintenanceDetails);
            ViewPartsCommand = new MvxCommand(_ViewParts);
            ViewPartUsagesCommand = new MvxCommand(_ViewPartUsages);
            ViewReportsCommand = new MvxCommand(_ViewReports);
            ViewReservationsCommand = new MvxCommand(_ViewReservations);
            ViewReservationFormsCommand = new MvxCommand(_ViewReservationForms);
            ViewVehiclesCommand = new MvxCommand(_ViewVehicles);

            ViewAdvisoriesCommand = new MvxCommand(_ViewAdvisories);
            ViewContractsCommand = new MvxCommand(_ViewContracts);
            ViewCoursesCommand = new MvxCommand(_ViewCourses);
            ViewDepartmentsCommand = new MvxCommand(_ViewDepartments);
            ViewEnrollmentsCommand = new MvxCommand(_ViewEnrollments);
            ViewProfessorsCommand = new MvxCommand(_ViewProfessors);
            ViewProfessorContractsCommand = new MvxCommand(_ViewProfessorContract);
            ViewProfessorshipsCommand = new MvxCommand(_ViewProfessorships);
            ViewSchedulesCommand = new MvxCommand(_ViewSchedules);
            ViewSchoolsCommand = new MvxCommand(_ViewSchools);
            ViewSectionsCommand = new MvxCommand(_ViewSections);
            ViewStudentsCommand = new MvxCommand(_ViewStudents);
            ViewTenuresCommand = new MvxCommand(_ViewTenures);
            #endregion
        }

        private IEnumerable<object> _browserEnumerable;
        private EntityEnum _browserEnumerableType;
        public IEnumerable<object> BrowserEnumerable
        {
            get => _browserEnumerable;
            set
            {
                SetProperty(ref _browserEnumerable, value);
                SetProperty(ref _browserEnumerableType, _checkEntityType(value.GetType().GetGenericArguments().First()));
                RaisePropertyChanged(() => BrowserHeader);
                RaisePropertyChanged(() => ManagerHeader);

                #region Manager Entities Visibility RaisePropertyChanged

                RaisePropertyChanged(() => ManagerEmployeeVisibility);
                RaisePropertyChanged(() => ManagerMaintenanceVisibility);
                RaisePropertyChanged(() => ManagerMaintenanceDetailVisibility);
                RaisePropertyChanged(() => ManagerPartVisibility);
                RaisePropertyChanged(() => ManagerPartUsageVisibility);
                RaisePropertyChanged(() => ManagerReportVisibility);
                RaisePropertyChanged(() => ManagerReservationVisibility);
                RaisePropertyChanged(() => ManagerReservationFormVisibility);
                RaisePropertyChanged(() => ManagerVehicleVisibility);
                RaisePropertyChanged(() => ManagerAdvisoryVisibility);
                RaisePropertyChanged(() => ManagerContractVisibility);
                RaisePropertyChanged(() => ManagerCourseVisibility);
                RaisePropertyChanged(() => ManagerDepartmentVisibility);
                RaisePropertyChanged(() => ManagerEnrollmentVisibility);
                RaisePropertyChanged(() => ManagerProfessorVisibility);
                RaisePropertyChanged(() => ManagerProfessorContractVisibility);
                RaisePropertyChanged(() => ManagerProfessorshipVisibility);
                RaisePropertyChanged(() => ManagerScheduleVisibility);
                RaisePropertyChanged(() => ManagerSchoolVisibility);
                RaisePropertyChanged(() => ManagerSectionVisibility);
                RaisePropertyChanged(() => ManagerStudentVisibility);
                RaisePropertyChanged(() => ManagerTenureVisibility);
                #endregion
            }
        }

        public string BrowserHeader
        {
            get
            {
                if (_browserEnumerableType == EntityEnum.Employee)
                    return "Employee";
                if (_browserEnumerableType == EntityEnum.Maintenance)
                    return "Maintenance";
                if (_browserEnumerableType == EntityEnum.MaintenanceDetail)
                    return "Maintenance Detail";
                if (_browserEnumerableType == EntityEnum.Part)
                    return "Part";
                if (_browserEnumerableType == EntityEnum.PartUsage)
                    return "Part Usage";
                if (_browserEnumerableType == EntityEnum.Report)
                    return "Report";
                if (_browserEnumerableType == EntityEnum.Reservation)
                    return "Reservation";
                if (_browserEnumerableType == EntityEnum.ReservationForm)
                    return "Reservation Form";
                if (_browserEnumerableType == EntityEnum.Vehicle)
                    return "Vehicle";
                if (_browserEnumerableType == EntityEnum.Advisory)
                    return "Advisory";
                if (_browserEnumerableType == EntityEnum.Contract)
                    return "Contract";
                if (_browserEnumerableType == EntityEnum.Course)
                    return "Course";
                if (_browserEnumerableType == EntityEnum.Department)
                    return "Department";
                if (_browserEnumerableType == EntityEnum.Enrollment)
                    return "Enrollment";
                if (_browserEnumerableType == EntityEnum.Professor)
                    return "Professor";
                if (_browserEnumerableType == EntityEnum.ProfessorContract)
                    return "Professor Contract";
                if (_browserEnumerableType == EntityEnum.Professorship)
                    return "Professorship";
                if (_browserEnumerableType == EntityEnum.Schedule)
                    return "Schedule";
                if (_browserEnumerableType == EntityEnum.School)
                    return "School";
                if (_browserEnumerableType == EntityEnum.Section)
                    return "Section";
                if (_browserEnumerableType == EntityEnum.Student)
                    return "Student";
                if (_browserEnumerableType == EntityEnum.Tenure)
                    return "Tenure";
                return "";
            }

        }

        private dynamic _browserSelection;
        private EntityEnum _browserSelectionType;
        public dynamic BrowserSelection
        {
            get => _browserSelection;
            set
            {
                if (value != null)
                {
                    SetProperty(ref _browserSelectionType, _checkEntityType(value.GetType()));
                    SetProperty(ref _browserSelection, value);
                    RaisePropertyChanged(() => InspectorHeader);

                    _fillInspectorFields(value);
                    #region Inspector Entities Visibility RaisePropertyChanged

                    RaisePropertyChanged(() => InspectorEmployeeVisibility);
                    RaisePropertyChanged(() => InspectorMaintenanceVisibility);
                    RaisePropertyChanged(() => InspectorMaintenanceDetailVisibility);
                    RaisePropertyChanged(() => InspectorPartVisibility);
                    RaisePropertyChanged(() => InspectorPartUsageVisibility);
                    RaisePropertyChanged(() => InspectorReportVisibility);
                    RaisePropertyChanged(() => InspectorReservationVisibility);
                    RaisePropertyChanged(() => InspectorReservationFormVisibility);
                    RaisePropertyChanged(() => InspectorVehicleVisibility);
                    RaisePropertyChanged(() => InspectorAdvisoryVisibility);
                    RaisePropertyChanged(() => InspectorContractVisibility);
                    RaisePropertyChanged(() => InspectorCourseVisibility);
                    RaisePropertyChanged(() => InspectorDepartmentVisibility);
                    RaisePropertyChanged(() => InspectorEnrollmentVisibility);
                    RaisePropertyChanged(() => InspectorProfessorVisibility);
                    RaisePropertyChanged(() => InspectorProfessorContractVisibility);
                    RaisePropertyChanged(() => InspectorProfessorshipVisibility);
                    RaisePropertyChanged(() => InspectorScheduleVisibility);
                    RaisePropertyChanged(() => InspectorSchoolVisibility);
                    RaisePropertyChanged(() => InspectorSectionVisibility);
                    RaisePropertyChanged(() => InspectorStudentVisibility);
                    RaisePropertyChanged(() => InspectorTenureVisibility);
                    #endregion


                }
            }
        }

        private void _fillInspectorFields(dynamic value)
        {
            if (_browserSelectionType == EntityEnum.Employee)
            {
                InspectorEmployee = value;
                RaisePropertyChanged(() => InspectorEmployee);
                //InspectorEmployeeId = value.EmployeeId;
                //InspectorEmployeeName = value.Name;
                //InspectorEmployeeIsMechanic = value.IsMechanic;
                //RaisePropertyChanged(() => InspectorEmployeeId);
                //RaisePropertyChanged(() => InspectorEmployeeName);
                //RaisePropertyChanged(() => InspectorEmployeeIsMechanic);
            }
            if (_browserSelectionType == EntityEnum.Maintenance)
            {
                InspectorMaintenance = value;
                InspectorMaintenanceId = value.MaintenanceId;
                InspectorMaintenanceType = value.Type;
                InspectorMaintenanceCompletionDate = value.CompletionDate;
                InspectorMaintenanceReleasingMechanicId = value.ReleasingMechanicId;
                InspectorMaintenanceVehicleId = value.VehicleId;
                InspectorMaintenanceReportId = value.ReportId;
            }

            if(_browserSelectionType == EntityEnum.MaintenanceDetail)
            {
                InspectorMaintenance = value;
            }
        }


        public string InspectorHeader
        {
            get
            {
                if (_browserSelectionType == EntityEnum.Employee)
                    return "Employee";
                if (_browserSelectionType == EntityEnum.Maintenance)
                    return "Maintenance";
                if (_browserSelectionType == EntityEnum.MaintenanceDetail)
                    return "Maintenance Detail";
                if (_browserSelectionType == EntityEnum.Part)
                    return "Part";
                if (_browserSelectionType == EntityEnum.PartUsage)
                    return "Part Usage";
                if (_browserSelectionType == EntityEnum.Report)
                    return "Report";
                if (_browserSelectionType == EntityEnum.Reservation)
                    return "Reservation";
                if (_browserSelectionType == EntityEnum.ReservationForm)
                    return "Reservation Form";
                if (_browserSelectionType == EntityEnum.Vehicle)
                    return "Vehicle";
                if (_browserSelectionType == EntityEnum.Advisory)
                    return "Advisory";
                if (_browserSelectionType == EntityEnum.Contract)
                    return "Contract";
                if (_browserSelectionType == EntityEnum.Course)
                    return "Course";
                if (_browserSelectionType == EntityEnum.Department)
                    return "Department";
                if (_browserSelectionType == EntityEnum.Enrollment)
                    return "Enrollment";
                if (_browserSelectionType == EntityEnum.Professor)
                    return "Professor";
                if (_browserSelectionType == EntityEnum.ProfessorContract)
                    return "Professor Contract";
                if (_browserSelectionType == EntityEnum.Professorship)
                    return "Professorship";
                if (_browserSelectionType == EntityEnum.Schedule)
                    return "Schedule";
                if (_browserSelectionType == EntityEnum.School)
                    return "School";
                if (_browserSelectionType == EntityEnum.Section)
                    return "Section";
                if (_browserSelectionType == EntityEnum.Student)
                    return "Student";
                if (_browserSelectionType == EntityEnum.Tenure)
                    return "Tenure";
                return "";
            }
        }
        #region Inspector Entities Visibility Properties

        public bool InspectorEmployeeVisibility => _browserSelectionType == EntityEnum.Employee;
        public bool InspectorMaintenanceVisibility => _browserSelectionType == EntityEnum.Maintenance;
        public bool InspectorMaintenanceDetailVisibility => _browserSelectionType == EntityEnum.MaintenanceDetail;
        public bool InspectorPartVisibility => _browserSelectionType == EntityEnum.Part;
        public bool InspectorPartUsageVisibility => _browserSelectionType == EntityEnum.PartUsage;
        public bool InspectorReportVisibility => _browserSelectionType == EntityEnum.Report;
        public bool InspectorReservationVisibility => _browserSelectionType == EntityEnum.Reservation;
        public bool InspectorReservationFormVisibility => _browserSelectionType == EntityEnum.ReservationForm;
        public bool InspectorVehicleVisibility => _browserSelectionType == EntityEnum.Vehicle;
        public bool InspectorAdvisoryVisibility => _browserSelectionType == EntityEnum.Advisory;
        public bool InspectorContractVisibility => _browserSelectionType == EntityEnum.Contract;
        public bool InspectorCourseVisibility => _browserSelectionType == EntityEnum.Course;
        public bool InspectorDepartmentVisibility => _browserSelectionType == EntityEnum.Department;
        public bool InspectorEnrollmentVisibility => _browserSelectionType == EntityEnum.Enrollment;
        public bool InspectorProfessorVisibility => _browserSelectionType == EntityEnum.Professor;
        public bool InspectorProfessorContractVisibility => _browserSelectionType == EntityEnum.ProfessorContract;
        public bool InspectorProfessorshipVisibility => _browserSelectionType == EntityEnum.Professorship;
        public bool InspectorScheduleVisibility => _browserSelectionType == EntityEnum.Schedule;
        public bool InspectorSchoolVisibility => _browserSelectionType == EntityEnum.School;
        public bool InspectorSectionVisibility => _browserSelectionType == EntityEnum.Section;
        public bool InspectorStudentVisibility => _browserSelectionType == EntityEnum.Student;
        public bool InspectorTenureVisibility => _browserSelectionType == EntityEnum.Tenure;

        #endregion

        #region Inspector Entities Properties

        public Employee InspectorEmployee { get; set; }
        public int InspectorEmployeeId { get; set; }
        public string InspectorEmployeeName { get; set; }
        public bool InspectorEmployeeIsMechanic { get; set; }

        public Maintenance InspectorMaintenance { get; set; }
        public int InspectorMaintenanceId { get; set; }
        public string InspectorMaintenanceType { get; set; }
        public DateTime InspectorMaintenanceCompletionDate { get; set; }
        public int InspectorMaintenanceReleasingMechanicId { get; set; }
        public int InspectorMaintenanceVehicleId { get; set; }
        public int InspectorMaintenanceReportId { get; set; }

        public MaintenanceDetail InspectorMaintenanceDetail { get; set; }
        public int InspectorMaintenanceDetailId { get; set; }
        public DateTime InspectorMaintenanceDetailProcessingDate { get; set; }
        public int InspectorMaintenanceDetailMaintenanceId { get; set; }
        public int InspectorMaintenanceDetailEmployeeId { get; set; }

        public Part InspectorPart { get; set; }
        public int InspectorPartId { get; set; }
        public string InspectorPartName { get; set; }
        public int InspectorPartCurrentAmount { get; set; }
        public int InspectorPartMinimumLevel { get; set; }

        public PartUsage InspectorPartUsage { get; set; }
        public int InspectorPartUsageId { get; set; }
        public int InspectorPartUsageCount { get; set; }
        public int InspectorPartUsagePartId { get; set; }
        public int InspectorPartUsageMaintenanceDetailId { get; set; }

        public Report InspectorReport { get; set; }
        public int InspectorReportId { get; set; }
        public DateTime InspectorReportMonth { get; set; }
        public string InspectorReportType { get; set; }

        public Reservation InspectorReservation { get; set; }
        public int InspectorReservationId { get; set; }
        public DateTime InspectorReservationDepartureDate { get; set; }
        public string InspectorReservationDestination { get; set; }
        public int InspectorReservationBilling { get; set; }
        public int InspectorReservationMileage { get; set; }
        public int InspectorReservationProfessorId { get; set; }
        public int InspectorReservationVehicleId { get; set; }
        public int InspectorReservationReportId { get; set; }

        public ReservationForm InspectorReservationForm { get; set; }
        public int InspectorReservationFormId { get; set; }
        public string InspectorReservationFormType { get; set; }
        public string InspectorReservationFormNotes { get; set; }
        public DateTime InspectorReservationFormSubmissionDate { get; set; }
        public int InspectorReservationFormReservationId { get; set; }
        public int InspectorReservationFormEmployeeId { get; set; }

        public Vehicle InspectorVehicle { get; set; }
        public int InspectorVehicleId { get; set; }
        public string InspectorVehicleType { get; set; }
        public int InspectorVehicleSeatingCapacity { get; set; }

        public Advisory InspectorAdvisory { get; set; }
        public int InspectorAdvisoryId { get; set; }
        public int InspectorAdvisoryDepartmentId { get; set; }
        public int InspectorAdvisoryProfessorId { get; set; }
        public int InspectorAdvisoryStudentId { get; set; }

        public Contract InspectorContract { get; set; }
        public int InspectorContractId { get; set; }
        public string InspectorContractType { get; set; }

        public Course InspectorCourse { get; set; }
        public int InspectorCourseId { get; set; }
        public string InspectorCourseName { get; set; }
        public int InspectorCourseDepartmentId { get; set; }

        public Department InspectorDepartment { get; set; }
        public int InspectorDepartmentId { get; set; }
        public string InspectorDepartmentName { get; set; }
        public int InspectorDepartmentSchoolId { get; set; }

        public Enrollment InspectorEnrollment { get; set; }
        public int InspectorEnrollmentId { get; set; }
        public int InspectorEnrollmentStudentId { get; set; }
        public int InspectorEnrollmentSectionId { get; set; }

        public Professor InspectorProfessor { get; set; }
        public int InspectorProfessorId { get; set; }
        public string InspectorProfessorName { get; set; }

        public ProfessorContract InspectorProfessorContract { get; set; }
        public int InspectorProfessorContractId { get; set; }
        public bool InspectorProfessorContractisActive { get; set; }
        public int InspectorProfessorContractProfessorId { get; set; }
        public int InspectorProfessorContractContractId { get; set; }

        public Professorship InspectorProfessorship { get; set; }
        public int InspectorProfessorShipId { get; set; }
        public bool InspectorProfessorisActive { get; set; }
        public int InspectorProfessorProfessorId { get; set; }
        public int InspectorProfessorDepartmentId { get; set; }

        public Schedule InspectorSchedule { get; set; }
        public int InspectorScheduleId { get; set; }
        public string InspectorScheduleDay { get; set; }
        public string InspectorScheduleRoomCode { get; set; }
        public DateTime InspectorScheduleTime { get; set; }
        public int? InspectorScheduleSectionId { get; set; }

        public School InspectorSchool { get; set; }
        public int InspectorSchoolId { get; set; }
        public string InspectorSchoolName { get; set; }
        public int InspectorSchoolDeanId { get; set; }

        public Section InspectorSection { get; set; }
        public int InspectorSectionId { get; set; }
        public string InspectorSectionName { get; set; }
        public int InspectorSectionScheduleId { get; set; }
        public int InspectorSectionProfessorId { get; set; }
        public int InspectorSectionCourseId { get; set; }

        public Student InspectorStudent { get; set; }
        public int InspectorStudentId { get; set; }
        public string InspectorStudentName { get; set; }
        public int? InspectorStudentDepartmentId { get; set; }
        public int? InspectorStudentAdvisoryId { get; set; }

        public Tenure InspectorTenure { get; set; }
        public int InspectorTenureId { get; set; }
        public int InspectorTenureSuccession { get; set; }
        public int InspectorTenureProfessorId { get; set; }
        public int InspectorTenureDepartmentId { get; set; }

        #endregion

        #region Inspector Commands

        #endregion



        public string ManagerHeader
        {
            get
            {
                if (_browserEnumerableType == EntityEnum.Employee)
                    return "Employee";
                if (_browserEnumerableType == EntityEnum.Maintenance)
                    return "Maintenance";
                if (_browserEnumerableType == EntityEnum.MaintenanceDetail)
                    return "Maintenance Detail";
                if (_browserEnumerableType == EntityEnum.Part)
                    return "Part";
                if (_browserEnumerableType == EntityEnum.PartUsage)
                    return "Part Usage";
                if (_browserEnumerableType == EntityEnum.Report)
                    return "Report";
                if (_browserEnumerableType == EntityEnum.Reservation)
                    return "Reservation";
                if (_browserEnumerableType == EntityEnum.ReservationForm)
                    return "Reservation Form";
                if (_browserEnumerableType == EntityEnum.Vehicle)
                    return "Vehicle";
                if (_browserEnumerableType == EntityEnum.Advisory)
                    return "Advisory";
                if (_browserEnumerableType == EntityEnum.Contract)
                    return "Contract";
                if (_browserEnumerableType == EntityEnum.Course)
                    return "Course";
                if (_browserEnumerableType == EntityEnum.Department)
                    return "Department";
                if (_browserEnumerableType == EntityEnum.Enrollment)
                    return "Enrollment";
                if (_browserEnumerableType == EntityEnum.Professor)
                    return "Professor";
                if (_browserEnumerableType == EntityEnum.ProfessorContract)
                    return "Professor Contract";
                if (_browserEnumerableType == EntityEnum.Professorship)
                    return "Professorship";
                if (_browserEnumerableType == EntityEnum.Schedule)
                    return "Schedule";
                if (_browserEnumerableType == EntityEnum.School)
                    return "School";
                if (_browserEnumerableType == EntityEnum.Section)
                    return "Section";
                if (_browserEnumerableType == EntityEnum.Student)
                    return "Student";
                if (_browserEnumerableType == EntityEnum.Tenure)
                    return "Tenure";
                return "";
            }
        }
        #region Manager Entities Visibility Properties

        public bool ManagerEmployeeVisibility => _browserEnumerableType == EntityEnum.Employee;
        public bool ManagerMaintenanceVisibility => _browserEnumerableType == EntityEnum.Maintenance;
        public bool ManagerMaintenanceDetailVisibility => _browserEnumerableType == EntityEnum.MaintenanceDetail;
        public bool ManagerPartVisibility => _browserEnumerableType == EntityEnum.Part;
        public bool ManagerPartUsageVisibility => _browserEnumerableType == EntityEnum.PartUsage;
        public bool ManagerReportVisibility => _browserEnumerableType == EntityEnum.Report;
        public bool ManagerReservationVisibility => _browserEnumerableType == EntityEnum.Reservation;
        public bool ManagerReservationFormVisibility => _browserEnumerableType == EntityEnum.ReservationForm;
        public bool ManagerVehicleVisibility => _browserEnumerableType == EntityEnum.Vehicle;
        public bool ManagerAdvisoryVisibility => _browserEnumerableType == EntityEnum.Advisory;
        public bool ManagerContractVisibility => _browserEnumerableType == EntityEnum.Contract;
        public bool ManagerCourseVisibility => _browserEnumerableType == EntityEnum.Course;
        public bool ManagerDepartmentVisibility => _browserEnumerableType == EntityEnum.Department;
        public bool ManagerEnrollmentVisibility => _browserEnumerableType == EntityEnum.Enrollment;
        public bool ManagerProfessorVisibility => _browserEnumerableType == EntityEnum.Professor;
        public bool ManagerProfessorContractVisibility => _browserEnumerableType == EntityEnum.ProfessorContract;
        public bool ManagerProfessorshipVisibility => _browserEnumerableType == EntityEnum.Professorship;
        public bool ManagerScheduleVisibility => _browserEnumerableType == EntityEnum.Schedule;
        public bool ManagerSchoolVisibility => _browserEnumerableType == EntityEnum.School;
        public bool ManagerSectionVisibility => _browserEnumerableType == EntityEnum.Section;
        public bool ManagerStudentVisibility => _browserEnumerableType == EntityEnum.Student;
        public bool ManagerTenureVisibility => _browserEnumerableType == EntityEnum.Tenure;

        #endregion

        #region Manager Entities Properties

        private Employee managerEmployee;
        public int ManagerEmployeeId { get; set; }
        public string ManagerEmployeeName { get; set; }
        public bool ManagerEmployeeIsMechanic { get; set; }

        private Maintenance managerMaintenance;
        public string ManagerMaintenanceType { get; set; }
        public DateTime ManagerMaintenanceCompletionDate { get; set; }
        public int ManagerMaintenanceReleasingMechanicId { get; set; }
        public int ManagerMaintenanceVehicleId { get; set; }
        public int ManagerMaintenanceReportId { get; set; }

        private MaintenanceDetail managerMaintenanceDetail;
        public int ManagerMaintenanceDetailId { get; set; }
        public DateTime ManagerMaintenanceDetailProcessingDate { get; set; }
        public int ManagerMaintenanceDetailMaintenanceId { get; set; }
        public int ManagerMaintenanceDetailEmployeeId { get; set; }

        private Part managerPart;
        public int ManagerPartId { get; set; }
        public string ManagerPartName { get; set; }
        public int ManagerPartCurrentAmount { get; set; }
        public int ManagerPartMinimumLevel { get; set; }

        private PartUsage managerPartUsage;
        public int ManagerPartUsageId { get; set; }
        public int ManagerPartUsageCount { get; set; }
        public int ManagerPartUsagePartId { get; set; }
        public int ManagerPartUsageMaintenanceDetailId { get; set; }

        private Report managerReport;
        public int ManagerReportId { get; set; }
        public DateTime ManagerReportMonth { get; set; }
        public string ManagerReportType { get; set; }

        private Reservation managerReservation;
        public int ManagerReservationId { get; set; }
        public DateTime ManagerReservationDepartureDate { get; set; }
        public string ManagerReservationDestination { get; set; }
        public int ManagerReservationBilling { get; set; }
        public int ManagerReservationMileage { get; set; }
        public int ManagerReservationProfessorId { get; set; }
        public int ManagerReservationVehicleId { get; set; }
        public int ManagerReservationReportId { get; set; }

        private ReservationForm managerReservationForm;
        public int ManagerReservationFormId { get; set; }
        public string ManagerReservationFormType { get; set; }
        public string ManagerReservationFormNotes { get; set; }
        public DateTime ManagerReservationFormSubmissionDate { get; set; }
        public int ManagerReservationFormReservationId { get; set; }
        public int ManagerReservationFormEmployeeId { get; set; }

        private Vehicle managerVehicle;
        public int ManagerVehicleId { get; set; }
        public string ManagerVehicleType { get; set; }
        public int ManagerVehicleSeatingCapacity { get; set; }

        private Advisory managerAdvisory;
        public int ManagerAdvisoryId { get; set; }
        public int ManagerAdvisoryDepartmentId { get; set; }
        public int ManagerAdvisoryProfessorId { get; set; }
        public int ManagerAdvisoryStudentId { get; set; }

        private Contract managerContract;
        public int ManagerContractId { get; set; }
        public string ManagerContractType { get; set; }

        private Course managerCourse;
        public int ManagerCourseId { get; set; }
        public string ManagerCourseName { get; set; }
        public int ManagerCourseDepartmentId { get; set; }

        private Department managerDepartment;
        public int ManagerDepartmentId { get; set; }
        public string ManagerDepartmentName { get; set; }
        public int ManagerDepartmentSchoolId { get; set; }

        private Enrollment managerEnrollment;
        public int ManagerEnrollmentId { get; set; }
        public int ManagerEnrollmentStudentId { get; set; }
        public int ManagerEnrollmentSectionId { get; set; }

        private Professor managerProfessor;
        public int ManagerProfessorId { get; set; }
        public string ManagerProfessorName { get; set; }

        private ProfessorContract managerProfessorContract;
        public int ManagerProfessorContractId { get; set; }
        public bool ManagerProfessorContractisActive { get; set; }
        public int ManagerProfessorContractProfessorId { get; set; }
        public int ManagerProfessorContractContractId { get; set; }

        private Professorship managerProfessorship;
        public int ManagerProfessorShipId { get; set; }
        public bool ManagerProfessorisActive { get; set; }
        public int ManagerProfessorProfessorId { get; set; }
        public int ManagerProfessorDepartmentId { get; set; }

        private Schedule managerSchedule;
        public int ManagerScheduleId { get; set; }
        public string ManagerScheduleDay { get; set; }
        public string ManagerScheduleRoomCode { get; set; }
        public DateTime ManagerScheduleTime { get; set; }
        public int? ManagerScheduleSectionId { get; set; }

        private School managerSchool;
        public int ManagerSchoolId { get; set; }
        public string ManagerSchoolName { get; set; }
        public int ManagerSchoolDeanId { get; set; }

        private Section managerSection;
        public int ManagerSectionId { get; set; }
        public string ManagerSectionName { get; set; }
        public int ManagerSectionScheduleId { get; set; }
        public int ManagerSectionProfessorId { get; set; }
        public int ManagerSectionCourseId { get; set; }

        private Student managerStudent;
        public int ManagerStudentId { get; set; }
        public string ManagerStudentName { get; set; }
        public int? ManagerStudentDepartmentId { get; set; }
        public int? ManagerStudentAdvisoryId { get; set; }

        private Tenure managerTenure;
        public int ManagerTenureId { get; set; }
        public int ManagerTenureSuccession { get; set; }
        public int ManagerTenureProfessorId { get; set; }
        public int ManagerTenureDepartmentId { get; set; }

        #endregion


        private EntityEnum _checkEntityType(Type T)
        {
            if (T == typeof(Employee) || T == typeof(IEmployee))
                return EntityEnum.Employee;
            if (T == typeof(Maintenance) || T == typeof(IMaintenance))
                return EntityEnum.Maintenance;
            if (T == typeof(MaintenanceDetail) || T == typeof(IMaintenanceDetail))
                return EntityEnum.MaintenanceDetail;
            if (T == typeof(Part) || T == typeof(IPart))
                return EntityEnum.Part;
            if (T == typeof(PartUsage) || T == typeof(IPartUsage))
                return EntityEnum.PartUsage;
            if (T == typeof(Report) || T == typeof(IReport))
                return EntityEnum.Report;
            if (T == typeof(Reservation) || T == typeof(IReservation))
                return EntityEnum.Reservation;
            if (T == typeof(ReservationForm) || T == typeof(IReservationForm))
                return EntityEnum.ReservationForm;
            if (T == typeof(Vehicle) || T == typeof(IVehicle))
                return EntityEnum.Vehicle;
            if (T == typeof(Advisory) || T == typeof(IAdvisory))
                return EntityEnum.Advisory;
            if (T == typeof(Contract) || T == typeof(IContract))
                return EntityEnum.Contract;
            if (T == typeof(Course) || T == typeof(ICourse))
                return EntityEnum.Course;
            if (T == typeof(Department) || T == typeof(IDepartment))
                return EntityEnum.Department;
            if (T == typeof(Enrollment) || T == typeof(IEnrollment))
                return EntityEnum.Enrollment;
            if (T == typeof(Professor) || T == typeof(IProfessor))
                return EntityEnum.Professor;
            if (T == typeof(ProfessorContract) || T == typeof(IProfessorContract))
                return EntityEnum.ProfessorContract;
            if (T == typeof(Professorship) || T == typeof(IProfessorship))
                return EntityEnum.Professorship;
            if (T == typeof(Schedule) || T == typeof(ISchedule))
                return EntityEnum.Schedule;
            if (T == typeof(School) || T == typeof(ISchool))
                return EntityEnum.School;
            if (T == typeof(Section) || T == typeof(ISection))
                return EntityEnum.Section;
            if (T == typeof(Student) || T == typeof(IStudent))
                return EntityEnum.Student;
            if (T == typeof(Tenure) || T == typeof(ITenure))
                return EntityEnum.Tenure;
            throw new Exception("Not within bounds of enums");
        }

        #region View_Entities_Commands_and_Methods
        public IMvxCommand ViewEmployeesCommand { get; set; }
        private void _ViewEmployees()
        {
            var employees = _superService.EmployeeService.GetEmployees().ToList();
            BrowserEnumerable = new ObservableCollection<IEmployee>(employees);
        }

        public IMvxCommand ViewMaintenancesCommand { get; set; }
        private void _ViewMaintenances()
        {
            var maintenances = _superService.MaintenanceService.GetMaintenances().ToList();
            BrowserEnumerable = new ObservableCollection<IMaintenance>(maintenances);
        }

        public IMvxCommand ViewMaintenanceDetailsCommand { get; set; }
        private void _ViewMaintenanceDetails()
        {
            var maintenanceDetails = _superService.MaintenanceDetailService.GetMaintenanceDetails().ToList();
            BrowserEnumerable = new ObservableCollection<IMaintenanceDetail>(maintenanceDetails);
        }

        public IMvxCommand ViewPartsCommand { get; set; }
        private void _ViewParts()
        {
            var parts = _superService.PartService.GetParts().ToList();
            BrowserEnumerable = new ObservableCollection<IPart>(parts);
        }

        public IMvxCommand ViewPartUsagesCommand { get; set; }
        private void _ViewPartUsages()
        {
            var partUsages = _superService.PartUsageService.GetPartUsages().ToList();
            BrowserEnumerable = new ObservableCollection<IPartUsage>(partUsages);
        }

        public IMvxCommand ViewReportsCommand { get; set; }
        private void _ViewReports()
        {
            var reports = _superService.ReportService.GetReports().ToList();
            BrowserEnumerable = new ObservableCollection<IReport>(reports);
        }

        public IMvxCommand ViewReservationsCommand { get; set; }
        private void _ViewReservations()
        {
            var reservations = _superService.ReservationService.GetReservations().ToList();
            BrowserEnumerable = new ObservableCollection<IReservation>(reservations);
        }

        public IMvxCommand ViewReservationFormsCommand { get; set; }
        private void _ViewReservationForms()
        {
            var reservationForms = _superService.ReservationFormService.GetReservationForms().ToList();
            BrowserEnumerable = new ObservableCollection<IReservationForm>(reservationForms);
        }

        public IMvxCommand ViewVehiclesCommand { get; set; }
        private void _ViewVehicles()
        {
            var vehicles = _superService.VehicleService.GetVehicles().ToList();
            BrowserEnumerable = new ObservableCollection<IVehicle>(vehicles);
        }

        public IMvxCommand ViewAdvisoriesCommand { get; set; }
        private void _ViewAdvisories()
        {
            var advisories = _superService.AdvisoryService.GetAdvisories().ToList();
            BrowserEnumerable = new ObservableCollection<IAdvisory>(advisories);
        }

        public IMvxCommand ViewContractsCommand { get; set; }
        private void _ViewContracts()
        {
            var contracts = _superService.ContractService.GetContracts().ToList();
            BrowserEnumerable = new ObservableCollection<IContract>(contracts);
        }

        public IMvxCommand ViewCoursesCommand { get; set; }
        private void _ViewCourses()
        {
            var courses = _superService.CourseService.GetCourses().ToList();
            BrowserEnumerable = new ObservableCollection<ICourse>(courses);
        }

        public IMvxCommand ViewDepartmentsCommand { get; set; }
        private void _ViewDepartments()
        {
            var departments = _superService.DepartmentService.GetDepartments().ToList();
            BrowserEnumerable = new ObservableCollection<IDepartment>(departments);
        }

        public IMvxCommand ViewEnrollmentsCommand { get; set; }
        private void _ViewEnrollments()
        {
            var enrollments = _superService.EnrollmentService.GetEnrollments().ToList();
            BrowserEnumerable = new ObservableCollection<IEnrollment>(enrollments);
        }

        public IMvxCommand ViewProfessorsCommand { get; set; }
        private void _ViewProfessors()
        {
            var professors = _superService.ProfessorService.GetProfessors().ToList();
            BrowserEnumerable = new ObservableCollection<IProfessor>(professors);
        }

        public IMvxCommand ViewProfessorContractsCommand { get; set; }
        private void _ViewProfessorContract()
        {
            var professorContracts = _superService.ProfessorContractService.GetProfessorContracts().ToList();
            BrowserEnumerable = new ObservableCollection<IProfessorContract>(professorContracts);
        }

        public IMvxCommand ViewProfessorshipsCommand { get; set; }
        private void _ViewProfessorships()
        {
            var professorships = _superService.ProfessorshipService.GetProfessorships().ToList();
            BrowserEnumerable = new ObservableCollection<IProfessorship>(professorships);
        }

        public IMvxCommand ViewSchedulesCommand { get; set; }
        private void _ViewSchedules()
        {
            var schedules = _superService.ScheduleService.GetSchedules().ToList();
            BrowserEnumerable = new ObservableCollection<ISchedule>(schedules);
        }

        public IMvxCommand ViewSchoolsCommand { get; set; }
        private void _ViewSchools()
        {
            var schools = _superService.SchoolService.GetSchools().ToList();
            BrowserEnumerable = new ObservableCollection<ISchool>(schools);
        }

        public IMvxCommand ViewSectionsCommand { get; set; }
        private void _ViewSections()
        {
            var sections = _superService.SectionService.GetSections().ToList();
            BrowserEnumerable = new ObservableCollection<ISection>(sections);
        }

        public IMvxCommand ViewStudentsCommand { get; set; }
        private void _ViewStudents()
        {
            var students = _superService.StudentService.GetStudents().ToList();
            BrowserEnumerable = new ObservableCollection<IStudent>(students);
        }

        public IMvxCommand ViewTenuresCommand { get; set; }
        private void _ViewTenures()
        {
            var tenures = _superService.TenureService.GetTenures().ToList();
            BrowserEnumerable = new ObservableCollection<ITenure>(tenures);
        }
        #endregion

    }
}