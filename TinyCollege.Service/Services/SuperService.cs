using System;
using System.Collections.Generic;
using System.Text;
using TinyCollege.Service.Services.MotorPool;

namespace TinyCollege.Service.Services
{
    public class SuperService
    {
        public SuperService()
        {
            EmployeeService = new EmployeeService();
            MaintenanceDetailService = new MaintenanceDetailService();
            MaintenanceService = new MaintenanceService();
            PartService = new PartService();
            PartUsageService = new PartUsageService();
            ReportService = new ReportService();
            ReservationFormService = new ReservationFormService();
            ReservationService = new ReservationService();
            VehicleService = new VehicleService();

            AdvisoryService = new AdvisoryService();
            ContractService = new ContractService();
            CourseService = new CourseService();
            DepartmentService = new DepartmentService();
            EnrollmentService = new EnrollmentService();
            ProfessorContractService = new ProfessorContractService();
            ProfessorService = new ProfessorService();
            ProfessorshipService = new ProfessorshipService();
            ScheduleService = new ScheduleService();
            SchoolService = new SchoolService();
            SectionService = new SectionService();
            StudentService = new StudentService();
            TenureService = new TenureService();
        }

        public EmployeeService EmployeeService { get; set; }
        public MaintenanceDetailService MaintenanceDetailService { get; set; }
        public MaintenanceService MaintenanceService { get; set; }
        public PartService PartService { get; set; }
        public PartUsageService PartUsageService { get; set; }
        public ReportService ReportService { get; set; }
        public ReservationFormService ReservationFormService { get; set; }
        public ReservationService ReservationService { get; set; }
        public VehicleService VehicleService { get; set; }

        public AdvisoryService AdvisoryService { get; set; }
        public ContractService ContractService { get; set; }
        public CourseService CourseService { get; set; }
        public DepartmentService DepartmentService { get; set; }
        public EnrollmentService EnrollmentService { get; set; }
        public ProfessorContractService ProfessorContractService { get; set; }
        public ProfessorService ProfessorService { get; set; }
        public ProfessorshipService ProfessorshipService { get; set; }
        public ScheduleService ScheduleService { get; set; }
        public SchoolService SchoolService { get; set; }
        public SectionService SectionService { get; set; }
        public StudentService StudentService { get; set; }
        public TenureService TenureService { get; set; }
    }
}
