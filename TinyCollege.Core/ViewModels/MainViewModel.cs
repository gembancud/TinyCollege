using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.Core;
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
        public IEnumerable<object> BrowserEnumerable
        {
            get => _browserEnumerable;
            set
            {
                SetProperty(ref _browserEnumerable, value);
                SetProperty(ref _browserHeaderType, _checkEntityType(value.GetType().GetGenericArguments().First()));
                RaisePropertyChanged(() => BrowserHeader);
            }
        }

        public string BrowserHeader
        {
            get
            {
                if (_browserHeaderType == EntityEnums.Employee)
                    return "Employee";
                if (_browserHeaderType == EntityEnums.Maintenance)
                    return "Maintenance";
                if (_browserHeaderType == EntityEnums.MaintenanceDetail)
                    return "Maintenance Detail";
                if (_browserHeaderType == EntityEnums.Part)
                    return "Part";
                if (_browserHeaderType == EntityEnums.PartUsage)
                    return "Part Usage";
                if (_browserHeaderType == EntityEnums.Report)
                    return "Report";
                if (_browserHeaderType == EntityEnums.Reservation)
                    return "Reservation";
                if (_browserHeaderType == EntityEnums.ReservationForm)
                    return "Reservation Form";
                if (_browserHeaderType == EntityEnums.Vehicle)
                    return "Vehicle";
                if (_browserHeaderType == EntityEnums.Advisory)
                    return "Advisory";
                if (_browserHeaderType == EntityEnums.Contract)
                    return "Contract";
                if (_browserHeaderType == EntityEnums.Course)
                    return "Course";
                if (_browserHeaderType == EntityEnums.Department)
                    return "Department";
                if (_browserHeaderType == EntityEnums.Enrollment)
                    return "Enrollment";
                if (_browserHeaderType == EntityEnums.Professor)
                    return "Professor";
                if (_browserHeaderType == EntityEnums.ProfessorContract)
                    return "Professor Contract";
                if (_browserHeaderType == EntityEnums.Professorship)
                    return "Professorship";
                if (_browserHeaderType == EntityEnums.Schedule)
                    return "Schedule";
                if (_browserHeaderType == EntityEnums.School)
                    return "School";
                if (_browserHeaderType == EntityEnums.Section)
                    return "Section";
                if (_browserHeaderType == EntityEnums.Student)
                    return "Student";
                if (_browserHeaderType == EntityEnums.Tenure)
                    return "Tenure";
                return "";
            }

        }
        private EntityEnums _browserHeaderType;

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