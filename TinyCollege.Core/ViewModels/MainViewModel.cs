using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private EntityEnums _browserEnumerableType;
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
                if (_browserEnumerableType == EntityEnums.Employee)
                    return "Employee";
                if (_browserEnumerableType == EntityEnums.Maintenance)
                    return "Maintenance";
                if (_browserEnumerableType == EntityEnums.MaintenanceDetail)
                    return "Maintenance Detail";
                if (_browserEnumerableType == EntityEnums.Part)
                    return "Part";
                if (_browserEnumerableType == EntityEnums.PartUsage)
                    return "Part Usage";
                if (_browserEnumerableType == EntityEnums.Report)
                    return "Report";
                if (_browserEnumerableType == EntityEnums.Reservation)
                    return "Reservation";
                if (_browserEnumerableType == EntityEnums.ReservationForm)
                    return "Reservation Form";
                if (_browserEnumerableType == EntityEnums.Vehicle)
                    return "Vehicle";
                if (_browserEnumerableType == EntityEnums.Advisory)
                    return "Advisory";
                if (_browserEnumerableType == EntityEnums.Contract)
                    return "Contract";
                if (_browserEnumerableType == EntityEnums.Course)
                    return "Course";
                if (_browserEnumerableType == EntityEnums.Department)
                    return "Department";
                if (_browserEnumerableType == EntityEnums.Enrollment)
                    return "Enrollment";
                if (_browserEnumerableType == EntityEnums.Professor)
                    return "Professor";
                if (_browserEnumerableType == EntityEnums.ProfessorContract)
                    return "Professor Contract";
                if (_browserEnumerableType == EntityEnums.Professorship)
                    return "Professorship";
                if (_browserEnumerableType == EntityEnums.Schedule)
                    return "Schedule";
                if (_browserEnumerableType == EntityEnums.School)
                    return "School";
                if (_browserEnumerableType == EntityEnums.Section)
                    return "Section";
                if (_browserEnumerableType == EntityEnums.Student)
                    return "Student";
                if (_browserEnumerableType == EntityEnums.Tenure)
                    return "Tenure";
                return "";
            }

        }

        private dynamic _browserSelection;
        private EntityEnums _browserSelectionType;
        public dynamic BrowserSelection
        {
            get => _browserSelection;
            set
            {
                if(value!=null)
                {
                    SetProperty(ref _browserSelectionType, _checkEntityType(value.GetType()));
                    SetProperty(ref _browserSelection, value);
                    RaisePropertyChanged(() => InspectorHeader);


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


        public string InspectorHeader
        {
            get
            {
                if (_browserSelectionType == EntityEnums.Employee)
                    return "Employee";
                if (_browserSelectionType == EntityEnums.Maintenance)
                    return "Maintenance";
                if (_browserSelectionType == EntityEnums.MaintenanceDetail)
                    return "Maintenance Detail";
                if (_browserSelectionType == EntityEnums.Part)
                    return "Part";
                if (_browserSelectionType == EntityEnums.PartUsage)
                    return "Part Usage";
                if (_browserSelectionType == EntityEnums.Report)
                    return "Report";
                if (_browserSelectionType == EntityEnums.Reservation)
                    return "Reservation";
                if (_browserSelectionType == EntityEnums.ReservationForm)
                    return "Reservation Form";
                if (_browserSelectionType == EntityEnums.Vehicle)
                    return "Vehicle";
                if (_browserSelectionType == EntityEnums.Advisory)
                    return "Advisory";
                if (_browserSelectionType == EntityEnums.Contract)
                    return "Contract";
                if (_browserSelectionType == EntityEnums.Course)
                    return "Course";
                if (_browserSelectionType == EntityEnums.Department)
                    return "Department";
                if (_browserSelectionType == EntityEnums.Enrollment)
                    return "Enrollment";
                if (_browserSelectionType == EntityEnums.Professor)
                    return "Professor";
                if (_browserSelectionType == EntityEnums.ProfessorContract)
                    return "Professor Contract";
                if (_browserSelectionType == EntityEnums.Professorship)
                    return "Professorship";
                if (_browserSelectionType == EntityEnums.Schedule)
                    return "Schedule";
                if (_browserSelectionType == EntityEnums.School)
                    return "School";
                if (_browserSelectionType == EntityEnums.Section)
                    return "Section";
                if (_browserSelectionType == EntityEnums.Student)
                    return "Student";
                if (_browserSelectionType == EntityEnums.Tenure)
                    return "Tenure";
                return "";
            }
        }
        #region Inspector Entities Visibility Properties
        
        public bool InspectorEmployeeVisibility => _browserSelectionType == EntityEnums.Employee;
        public bool InspectorMaintenanceVisibility => _browserSelectionType == EntityEnums.Maintenance;
        public bool InspectorMaintenanceDetailVisibility => _browserSelectionType == EntityEnums.MaintenanceDetail;
        public bool InspectorPartVisibility => _browserSelectionType == EntityEnums.Part;
        public bool InspectorPartUsageVisibility => _browserSelectionType == EntityEnums.PartUsage;
        public bool InspectorReportVisibility => _browserSelectionType == EntityEnums.Report;
        public bool InspectorReservationVisibility => _browserSelectionType == EntityEnums.Reservation;
        public bool InspectorReservationFormVisibility => _browserSelectionType == EntityEnums.ReservationForm;
        public bool InspectorVehicleVisibility => _browserSelectionType == EntityEnums.Vehicle;
        public bool InspectorAdvisoryVisibility => _browserSelectionType == EntityEnums.Advisory;
        public bool InspectorContractVisibility => _browserSelectionType == EntityEnums.Contract;
        public bool InspectorCourseVisibility => _browserSelectionType == EntityEnums.Course;
        public bool InspectorDepartmentVisibility => _browserSelectionType == EntityEnums.Department;
        public bool InspectorEnrollmentVisibility => _browserSelectionType == EntityEnums.Enrollment;
        public bool InspectorProfessorVisibility => _browserSelectionType == EntityEnums.Professor;
        public bool InspectorProfessorContractVisibility => _browserSelectionType == EntityEnums.ProfessorContract;
        public bool InspectorProfessorshipVisibility => _browserSelectionType == EntityEnums.Professorship;
        public bool InspectorScheduleVisibility => _browserSelectionType == EntityEnums.Schedule;
        public bool InspectorSchoolVisibility => _browserSelectionType == EntityEnums.School;
        public bool InspectorSectionVisibility => _browserSelectionType == EntityEnums.Section;
        public bool InspectorStudentVisibility => _browserSelectionType == EntityEnums.Student;
        public bool InspectorTenureVisibility => _browserSelectionType == EntityEnums.Tenure;

        #endregion

        public string ManagerHeader
        {
            get
            {
                if (_browserEnumerableType == EntityEnums.Employee)
                    return "Employee";
                if (_browserEnumerableType == EntityEnums.Maintenance)
                    return "Maintenance";
                if (_browserEnumerableType == EntityEnums.MaintenanceDetail)
                    return "Maintenance Detail";
                if (_browserEnumerableType == EntityEnums.Part)
                    return "Part";
                if (_browserEnumerableType == EntityEnums.PartUsage)
                    return "Part Usage";
                if (_browserEnumerableType == EntityEnums.Report)
                    return "Report";
                if (_browserEnumerableType == EntityEnums.Reservation)
                    return "Reservation";
                if (_browserEnumerableType == EntityEnums.ReservationForm)
                    return "Reservation Form";
                if (_browserEnumerableType == EntityEnums.Vehicle)
                    return "Vehicle";
                if (_browserEnumerableType == EntityEnums.Advisory)
                    return "Advisory";
                if (_browserEnumerableType == EntityEnums.Contract)
                    return "Contract";
                if (_browserEnumerableType == EntityEnums.Course)
                    return "Course";
                if (_browserEnumerableType == EntityEnums.Department)
                    return "Department";
                if (_browserEnumerableType == EntityEnums.Enrollment)
                    return "Enrollment";
                if (_browserEnumerableType == EntityEnums.Professor)
                    return "Professor";
                if (_browserEnumerableType == EntityEnums.ProfessorContract)
                    return "Professor Contract";
                if (_browserEnumerableType == EntityEnums.Professorship)
                    return "Professorship";
                if (_browserEnumerableType == EntityEnums.Schedule)
                    return "Schedule";
                if (_browserEnumerableType == EntityEnums.School)
                    return "School";
                if (_browserEnumerableType == EntityEnums.Section)
                    return "Section";
                if (_browserEnumerableType == EntityEnums.Student)
                    return "Student";
                if (_browserEnumerableType == EntityEnums.Tenure)
                    return "Tenure";
                return "";
            }
        }
        #region Manager Entities Visibility Properties

        public bool ManagerEmployeeVisibility => _browserEnumerableType == EntityEnums.Employee;
        public bool ManagerMaintenanceVisibility => _browserEnumerableType == EntityEnums.Maintenance;
        public bool ManagerMaintenanceDetailVisibility => _browserEnumerableType == EntityEnums.MaintenanceDetail;
        public bool ManagerPartVisibility => _browserEnumerableType == EntityEnums.Part;
        public bool ManagerPartUsageVisibility => _browserEnumerableType == EntityEnums.PartUsage;
        public bool ManagerReportVisibility => _browserEnumerableType == EntityEnums.Report;
        public bool ManagerReservationVisibility => _browserEnumerableType == EntityEnums.Reservation;
        public bool ManagerReservationFormVisibility => _browserEnumerableType == EntityEnums.ReservationForm;
        public bool ManagerVehicleVisibility => _browserEnumerableType == EntityEnums.Vehicle;
        public bool ManagerAdvisoryVisibility => _browserEnumerableType == EntityEnums.Advisory;
        public bool ManagerContractVisibility => _browserEnumerableType == EntityEnums.Contract;
        public bool ManagerCourseVisibility => _browserEnumerableType == EntityEnums.Course;
        public bool ManagerDepartmentVisibility => _browserEnumerableType == EntityEnums.Department;
        public bool ManagerEnrollmentVisibility => _browserEnumerableType == EntityEnums.Enrollment;
        public bool ManagerProfessorVisibility => _browserEnumerableType == EntityEnums.Professor;
        public bool ManagerProfessorContractVisibility => _browserEnumerableType == EntityEnums.ProfessorContract;
        public bool ManagerProfessorshipVisibility => _browserEnumerableType == EntityEnums.Professorship;
        public bool ManagerScheduleVisibility => _browserEnumerableType == EntityEnums.Schedule;
        public bool ManagerSchoolVisibility => _browserEnumerableType == EntityEnums.School;
        public bool ManagerSectionVisibility => _browserEnumerableType == EntityEnums.Section;
        public bool ManagerStudentVisibility => _browserEnumerableType == EntityEnums.Student;
        public bool ManagerTenureVisibility => _browserEnumerableType == EntityEnums.Tenure;

        #endregion



        private EntityEnums _checkEntityType(Type T)
        {
            if (T == typeof(Employee) || T == typeof(IEmployee))
                return EntityEnums.Employee;
            if (T == typeof(Maintenance) || T == typeof(IMaintenance))
                return EntityEnums.Maintenance;
            if (T == typeof(MaintenanceDetail) || T == typeof(IMaintenanceDetail))
                return EntityEnums.MaintenanceDetail;
            if (T == typeof(Part) || T == typeof(IPart))
                return EntityEnums.Part;
            if (T == typeof(PartUsage) || T == typeof(IPartUsage))
                return EntityEnums.PartUsage;
            if (T == typeof(Report) || T == typeof(IReport))
                return EntityEnums.Report;
            if (T == typeof(Reservation) || T == typeof(IReservation))
                return EntityEnums.Reservation;
            if (T == typeof(ReservationForm) || T == typeof(IReservationForm))
                return EntityEnums.ReservationForm;
            if (T == typeof(Vehicle) || T == typeof(IVehicle))
                return EntityEnums.Vehicle;
            if (T == typeof(Advisory) || T == typeof(IAdvisory))
                return EntityEnums.Advisory;
            if (T == typeof(Contract) || T == typeof(IContract))
                return EntityEnums.Contract;
            if (T == typeof(Course) || T == typeof(ICourse))
                return EntityEnums.Course;
            if (T == typeof(Department) || T == typeof(IDepartment))
                return EntityEnums.Department;
            if (T == typeof(Enrollment) || T == typeof(IEnrollment))
                return EntityEnums.Enrollment;
            if (T == typeof(Professor) || T == typeof(IProfessor))
                return EntityEnums.Professor;
            if (T == typeof(ProfessorContract) || T == typeof(IProfessorContract))
                return EntityEnums.ProfessorContract;
            if (T == typeof(Professorship) || T == typeof(IProfessorship))
                return EntityEnums.Professorship;
            if (T == typeof(Schedule) || T == typeof(ISchedule))
                return EntityEnums.Schedule;
            if (T == typeof(School) || T == typeof(ISchool))
                return EntityEnums.School;
            if (T == typeof(Section) || T == typeof(ISection))
                return EntityEnums.Section;
            if (T == typeof(Student) || T== typeof(IStudent))
                return EntityEnums.Student;
            if (T == typeof(Tenure) || T == typeof(ITenure))
                return EntityEnums.Tenure;
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