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


            #region Inspector Commands Initialization

            InspectorEmployeeViewReservationFormsCommand = new MvxCommand(_InspectorEmployeeViewReservationForms);
            InspectorEmployeeViewMaintenanceDetailsCommand = new MvxCommand(_InspectorEmployeeViewMaintenanceDetails);

            InspectorMaintenanceReleasingMechanicCommand = new MvxCommand(_InspectorMaintenanceReleasingMechanic);
            InspectorMaintenanceVehicleCommand = new MvxCommand(_InspectorMaintenanceVehicle);
            InspectorMaintenanceReportCommand = new MvxCommand(_InspectorMaintenanceReport);

            InspectorMaintenanceMaintenanceDetailsCommand = new MvxCommand(_InspectorMaintenanceMaintenanceDetails);
            InspectorMaintenanceDetailMaintenanceCommand = new MvxCommand(_InspectorMaintenanceDetailMaintenance);
            InspectorMaintenanceDetailPartUsagesCommand = new MvxCommand(_InspectorMaintenanceDetailPartUsages);
            InspectorMaintenanceDetailEmployeeCommand = new MvxCommand(_InspectorMaintenanceDetailEmployee);

            InspectorPartPartUsagesCommand = new MvxCommand(_InspectorPartPartUsages);

            InspectorPartUsagePartCommand = new MvxCommand(_InspectorPartUsagePart);
            InspectorPartUsageMaintenanceDetailCommand = new MvxCommand(_InspectorPartUsageMaintenanceDetail);

            InspectorReportMaintenancesCommand = new MvxCommand(_InspectorReportMaintenances);
            InspectorReportReservationsCommand = new MvxCommand(_InspectorReportReservations);

            InspectorReservationProfessorCommand = new MvxCommand(_InspectorReservationProfessor);
            InspectorReservationVehicleCommand = new MvxCommand(_InspectorReservationVehicle);
            InspectorReservationReportCommand = new MvxCommand(_InspectorReservationReport);
            InspectorReservationReservationFormsCommand = new MvxCommand(_InspectorReservationReservationForms);

            InspectorReservationFormReservationCommand = new MvxCommand(_InspectorReservationFormReservation);
            InspectorReservationFormEmployeeCommand = new MvxCommand(_InspectorReservationFormEmployee);

            InspectorVehicleReservationsCommand = new MvxCommand(_InspectorVehicleReservations);

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

                _refreshManagerVisibility();
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
                    _refreshInspectorVisibility();
                }
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

        private void _fillInspectorFields(dynamic value)
        {
            switch (_browserSelectionType)
            {
                case EntityEnum.Employee:
                    InspectorEmployee = value;
                    RaisePropertyChanged(() => InspectorEmployee);
                    break;
                case EntityEnum.Maintenance:
                    InspectorMaintenance = value;
                    RaisePropertyChanged(() => InspectorMaintenance);
                    break;
                case EntityEnum.MaintenanceDetail:
                    InspectorMaintenanceDetail = value;
                    RaisePropertyChanged(() => InspectorMaintenanceDetail);
                    break;
                case EntityEnum.Part:
                    InspectorPart = value;
                    RaisePropertyChanged(() => InspectorPart);
                    break;
                case EntityEnum.PartUsage:
                    InspectorPartUsage = value;
                    RaisePropertyChanged(() => InspectorPartUsage);
                    break;
                case EntityEnum.Report:
                    InspectorReport = value;
                    RaisePropertyChanged(() => InspectorReport);
                    break;
                case EntityEnum.Reservation:
                    InspectorReservation = value;
                    RaisePropertyChanged(() => InspectorReservation);
                    break;
                case EntityEnum.ReservationForm:
                    InspectorReservationForm = value;
                    RaisePropertyChanged(() => InspectorReservationForm);
                    break;
                case EntityEnum.Vehicle:
                    InspectorVehicle = value;
                    RaisePropertyChanged(() => InspectorVehicle);
                    break;
                case EntityEnum.Advisory:
                    InspectorAdvisory = value;
                    RaisePropertyChanged(() => InspectorAdvisory);
                    break;
                case EntityEnum.Contract:
                    InspectorContract = value;
                    RaisePropertyChanged(() => InspectorContract);
                    break;
                case EntityEnum.Course:
                    InspectorCourse = value;
                    RaisePropertyChanged(() => InspectorCourse);
                    break;
                case EntityEnum.Department:
                    InspectorDepartment = value;
                    RaisePropertyChanged(() => InspectorDepartment);
                    break;
                case EntityEnum.Enrollment:
                    InspectorEnrollment = value;
                    RaisePropertyChanged(() => InspectorEnrollment);
                    break;
                case EntityEnum.Professor:
                    InspectorProfessor = value;
                    RaisePropertyChanged(() => InspectorProfessor);
                    break;
                case EntityEnum.ProfessorContract:
                    InspectorProfessorContract = value;
                    RaisePropertyChanged(() => InspectorProfessorContract);
                    break;
                case EntityEnum.Professorship:
                    InspectorProfessorship = value;
                    RaisePropertyChanged(() => InspectorProfessorship);
                    break;
                case EntityEnum.Schedule:
                    InspectorSchedule = value;
                    RaisePropertyChanged(() => InspectorSchedule);
                    break;
                case EntityEnum.School:
                    InspectorSchool = value;
                    RaisePropertyChanged(() => InspectorSchool);
                    break;
                case EntityEnum.Section:
                    InspectorSection = value;
                    RaisePropertyChanged(() => InspectorSection);
                    break;
                case EntityEnum.Student:
                    InspectorStudent = value;
                    RaisePropertyChanged(() => InspectorStudent);
                    break;
                case EntityEnum.Tenure:
                    InspectorTenure = value;
                    RaisePropertyChanged(() => InspectorTenure);
                    break;
            }
        }
        private void _refreshInspectorVisibility()
        {
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
        }
        #region Inspector Entities Properties

        public Employee InspectorEmployee { get; set; }
        public Maintenance InspectorMaintenance { get; set; }
        public MaintenanceDetail InspectorMaintenanceDetail { get; set; }
        public Part InspectorPart { get; set; }
        public PartUsage InspectorPartUsage { get; set; }
        public Report InspectorReport { get; set; }
        public Reservation InspectorReservation { get; set; }
        public ReservationForm InspectorReservationForm { get; set; }
        public Vehicle InspectorVehicle { get; set; }
        public Advisory InspectorAdvisory { get; set; }
        public Contract InspectorContract { get; set; }
        public Course InspectorCourse { get; set; }
        public Department InspectorDepartment { get; set; }
        public Enrollment InspectorEnrollment { get; set; }
        public Professor InspectorProfessor { get; set; }
        public ProfessorContract InspectorProfessorContract { get; set; }
        public Professorship InspectorProfessorship { get; set; }
        public Schedule InspectorSchedule { get; set; }
        public School InspectorSchool { get; set; }
        public Section InspectorSection { get; set; }
        public Student InspectorStudent { get; set; }
        public Tenure InspectorTenure { get; set; }

        #endregion

        #region Inspector Commands

        public IMvxCommand InspectorEmployeeViewReservationFormsCommand { get; set; }
        private void _InspectorEmployeeViewReservationForms()
        {
            var reservationForms = _superService.EmployeeService.GetEmployeeReservationForms(InspectorEmployee.EmployeeId).ToList();
            BrowserEnumerable = new ObservableCollection<IReservationForm>(reservationForms);
        }

        public IMvxCommand InspectorEmployeeViewMaintenanceDetailsCommand { get; set; }
        private void _InspectorEmployeeViewMaintenanceDetails()
        {
            var maintenanceDetails = _superService.EmployeeService.GetEmployeeMaintenanceDetails(InspectorEmployee.EmployeeId).ToList();
            BrowserEnumerable = new ObservableCollection<IMaintenanceDetail>(maintenanceDetails);
        }

        public IMvxCommand InspectorMaintenanceReleasingMechanicCommand { get; set; }
        private void _InspectorMaintenanceReleasingMechanic()
        {
            var releasingMechanicId = InspectorMaintenance.ReleasingMechanicId ?? 0;
            if (releasingMechanicId == 0) return;
            var maintenanceReleasingMechanic = _superService.MaintenanceService.GetMaintenanceReleasingMechanic(releasingMechanicId).ToList();
            BrowserSelection = maintenanceReleasingMechanic.First();
        }

        public IMvxCommand InspectorMaintenanceVehicleCommand { get; set; }
        private void _InspectorMaintenanceVehicle()
        {
            var maintenanceVehicle = _superService.MaintenanceService.GetMaintenanceVehicle(InspectorMaintenance.VehicleId).ToList();
            BrowserSelection = maintenanceVehicle.First();
        }

        public IMvxCommand InspectorMaintenanceReportCommand { get; set; }
        private void _InspectorMaintenanceReport()
        {
            var reportId = InspectorMaintenance.ReportId ?? 0;
            if (reportId == 0) return;
            var report = _superService.MaintenanceService.GetMaintenanceReport(reportId).ToList();
            BrowserSelection = report.First();
        }

        public IMvxCommand InspectorMaintenanceMaintenanceDetailsCommand { get; set; }
        private void _InspectorMaintenanceMaintenanceDetails()
        {
            var maintenanceDetails = _superService.MaintenanceService.GetMaintenanceMaintenanceDetails(InspectorMaintenance.MaintenanceId).ToList();
            BrowserEnumerable = new ObservableCollection<IMaintenanceDetail>(maintenanceDetails);
        }

        public IMvxCommand InspectorMaintenanceDetailMaintenanceCommand { get; set; }
        private void _InspectorMaintenanceDetailMaintenance()
        {
            var maintenance = _superService.MaintenanceDetailService.GetMaintenanceDetailMaintenance(InspectorMaintenanceDetail.MaintenanceId).ToList();
            BrowserSelection = maintenance.First();
        }

        public IMvxCommand InspectorMaintenanceDetailPartUsagesCommand { get; set; }
        private void _InspectorMaintenanceDetailPartUsages()
        {
            var partUsages = _superService.MaintenanceDetailService.GetMaintenanceDetailPartUsages(InspectorMaintenanceDetail.MaintenanceDetailId).ToList();
            BrowserEnumerable = new ObservableCollection<IPartUsage>(partUsages);
        }

        public IMvxCommand InspectorMaintenanceDetailEmployeeCommand { get; set; }
        private void _InspectorMaintenanceDetailEmployee()
        {
            var employee = _superService.MaintenanceDetailService.GetMaintenanceDetailEmployee(InspectorMaintenanceDetail.EmployeeId).ToList();
            BrowserSelection = employee.First();
        }

        public IMvxCommand InspectorPartPartUsagesCommand { get; set; }
        private void _InspectorPartPartUsages()
        {
            var partUsages = _superService.PartService.GetPartPartUsages(InspectorPart.PartId).ToList();
            BrowserEnumerable = new ObservableCollection<IPartUsage>(partUsages);
        }

        public IMvxCommand InspectorPartUsagePartCommand { get; set; }
        private void _InspectorPartUsagePart()
        {
            var part = _superService.PartUsageService.GetPartUsagePart(InspectorPartUsage.PartId).ToList();
            BrowserSelection = part.First();
        }

        public IMvxCommand InspectorPartUsageMaintenanceDetailCommand { get; set; }
        private void _InspectorPartUsageMaintenanceDetail()
        {
            var maintenanceDetail = _superService.PartUsageService.GetPartUsageMaintenanceDetail(InspectorPartUsage.MaintenanceDetailId).ToList();
            BrowserSelection = maintenanceDetail.First();
        }

        public IMvxCommand InspectorReportMaintenancesCommand { get; set; }
        private void _InspectorReportMaintenances()
        {
            var maintenances = _superService.ReportService.GetReportMaintenances(InspectorReport.ReportId).ToList();
            BrowserEnumerable = new ObservableCollection<IMaintenance>(maintenances);
        }

        public IMvxCommand InspectorReportReservationsCommand { get; set; }
        private void _InspectorReportReservations()
        {
            var reservations = _superService.ReportService.GetReportReservations(InspectorReport.ReportId).ToList();
            BrowserEnumerable = new ObservableCollection<IReservation>(reservations);
        }

        public IMvxCommand InspectorReservationProfessorCommand { get; set; }
        private void _InspectorReservationProfessor()
        {
            var professor = _superService.ReservationService.GetReservationProfessor(InspectorReservation.ProfessorId).ToList();
            BrowserSelection = professor.First();
        }

        public IMvxCommand InspectorReservationVehicleCommand { get; set; }
        private void _InspectorReservationVehicle()
        {
            var vehicle = _superService.ReservationService.GetReservationVehicle(InspectorReservation.VehicleId).ToList();
            BrowserSelection = vehicle.First();
        }

        public IMvxCommand InspectorReservationReportCommand { get; set; }
        private void _InspectorReservationReport()
        {
            var reportId = InspectorReservation.ReportId ?? 0;
            if (reportId == 0) return;
            var report = _superService.ReservationService.GetReservationReport(reportId).ToList();
            BrowserSelection = report.First();
        }

        public IMvxCommand InspectorReservationReservationFormsCommand { get; set; }
        private void _InspectorReservationReservationForms()
        {
            var reservationForms = _superService.ReservationService.GetReservationReservationForms(InspectorReservation.ReservationId).ToList();
            BrowserEnumerable = new ObservableCollection<IReservationForm>(reservationForms);
        }

        public IMvxCommand InspectorReservationFormReservationCommand { get; set; }
        private void _InspectorReservationFormReservation()
        {
            var reservation = _superService.ReservationFormService.GetReservationFormReservation(InspectorReservationForm.ReservationId).ToList();
            BrowserSelection = reservation.First();
        }

        public IMvxCommand InspectorReservationFormEmployeeCommand { get; set; }
        private void _InspectorReservationFormEmployee()
        {
            var employee = _superService.ReservationFormService.GetReservationFormEmployee(InspectorReservationForm.EmployeeId).ToList();
            BrowserSelection = employee.First();
        }

        public IMvxCommand InspectorVehicleReservationsCommand { get; set; }
        private void _InspectorVehicleReservations()
        {
            var reservations = _superService.VehicleService.GetVehicleReservations(InspectorVehicle.VehicleId).ToList();
            BrowserEnumerable = new ObservableCollection<IReservation>(reservations);
        }


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

        private void _fillManagerFields(dynamic value)
        {
            switch (_browserEnumerableType)
            {
                case EntityEnum.Employee:
                    ManagerEmployee = value;
                    RaisePropertyChanged(() => ManagerEmployee);
                    break;
                case EntityEnum.Maintenance:
                    ManagerMaintenance = value;
                    RaisePropertyChanged(() => ManagerMaintenance);
                    break;
                case EntityEnum.MaintenanceDetail:
                    ManagerMaintenanceDetail = value;
                    RaisePropertyChanged(() => ManagerMaintenanceDetail);
                    break;
                case EntityEnum.Part:
                    ManagerPart = value;
                    RaisePropertyChanged(() => ManagerPart);
                    break;
                case EntityEnum.PartUsage:
                    ManagerPartUsage = value;
                    RaisePropertyChanged(() => ManagerPartUsage);
                    break;
                case EntityEnum.Report:
                    ManagerReport = value;
                    RaisePropertyChanged(() => ManagerReport);
                    break;
                case EntityEnum.Reservation:
                    ManagerReservation = value;
                    RaisePropertyChanged(() => ManagerReservation);
                    break;
                case EntityEnum.ReservationForm:
                    ManagerReservationForm = value;
                    RaisePropertyChanged(() => ManagerReservationForm);
                    break;
                case EntityEnum.Vehicle:
                    ManagerVehicle = value;
                    RaisePropertyChanged(() => ManagerVehicle);
                    break;
                case EntityEnum.Advisory:
                    ManagerAdvisory = value;
                    RaisePropertyChanged(() => ManagerAdvisory);
                    break;
                case EntityEnum.Contract:
                    ManagerContract = value;
                    RaisePropertyChanged(() => ManagerContract);
                    break;
                case EntityEnum.Course:
                    ManagerCourse = value;
                    RaisePropertyChanged(() => ManagerCourse);
                    break;
                case EntityEnum.Department:
                    ManagerDepartment = value;
                    RaisePropertyChanged(() => ManagerDepartment);
                    break;
                case EntityEnum.Enrollment:
                    ManagerEnrollment = value;
                    RaisePropertyChanged(() => ManagerEnrollment);
                    break;
                case EntityEnum.Professor:
                    ManagerProfessor = value;
                    RaisePropertyChanged(() => ManagerProfessor);
                    break;
                case EntityEnum.ProfessorContract:
                    ManagerProfessorContract = value;
                    RaisePropertyChanged(() => ManagerProfessorContract);
                    break;
                case EntityEnum.Professorship:
                    ManagerProfessorship = value;
                    RaisePropertyChanged(() => ManagerProfessorship);
                    break;
                case EntityEnum.Schedule:
                    ManagerSchedule = value;
                    RaisePropertyChanged(() => ManagerSchedule);
                    break;
                case EntityEnum.School:
                    ManagerSchool = value;
                    RaisePropertyChanged(() => ManagerSchool);
                    break;
                case EntityEnum.Section:
                    ManagerSection = value;
                    RaisePropertyChanged(() => ManagerSection);
                    break;
                case EntityEnum.Student:
                    ManagerStudent = value;
                    RaisePropertyChanged(() => ManagerStudent);
                    break;
                case EntityEnum.Tenure:
                    ManagerTenure = value;
                    RaisePropertyChanged(() => ManagerTenure);
                    break;
            }
        }
        private void _refreshManagerVisibility()
        {

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
        }
        #region Manager Entities Properties

        public Employee ManagerEmployee;
        public Maintenance ManagerMaintenance;
        public MaintenanceDetail ManagerMaintenanceDetail;
        public Part ManagerPart;
        public PartUsage ManagerPartUsage;
        public Report ManagerReport;
        public Reservation ManagerReservation;
        public ReservationForm ManagerReservationForm;
        public Vehicle ManagerVehicle;
        public Advisory ManagerAdvisory;
        public Contract ManagerContract;
        public Course ManagerCourse;
        public Department ManagerDepartment;
        public Enrollment ManagerEnrollment;
        public Professor ManagerProfessor;
        public ProfessorContract ManagerProfessorContract;
        public Professorship ManagerProfessorship;
        public Schedule ManagerSchedule;
        public School ManagerSchool;
        public Section ManagerSection;
        public Student ManagerStudent;
        public Tenure ManagerTenure;

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