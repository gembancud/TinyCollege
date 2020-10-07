using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCollege.Data.Configurations;
using TinyCollege.Data.Configurations.MotorPool;
using TinyCollege.Data.Models.MotorPool;

namespace TinyCollege.Data.Models
{
    public class TinyCollegeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<MaintenanceDetail> MaintenanceDetails { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartUsage> PartUsages { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationForm> ReservationForms { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Advisory> Advisories { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<ProfessorContract> ProfessorContracts { get; set; }
        public DbSet<Professorship> Professorships { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tenure> Tenures { get; set; }

        public TinyCollegeContext(DbContextOptions options) : base(options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new MaintenanceConfig());
            modelBuilder.ApplyConfiguration(new MaintenanceDetailConfig());
            modelBuilder.ApplyConfiguration(new PartConfig());
            modelBuilder.ApplyConfiguration(new PartUsageConfig());
            modelBuilder.ApplyConfiguration(new ReportConfig());
            modelBuilder.ApplyConfiguration(new ReservationConfig());
            modelBuilder.ApplyConfiguration(new ReservationFormConfig());
            modelBuilder.ApplyConfiguration(new VehicleConfig());

            modelBuilder.ApplyConfiguration(new AdvisoryConfig());
            modelBuilder.ApplyConfiguration(new ContractConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
            modelBuilder.ApplyConfiguration(new EnrollmentConfig());
            modelBuilder.ApplyConfiguration(new ProfessorConfig());
            modelBuilder.ApplyConfiguration(new ProfessorContractConfig());
            modelBuilder.ApplyConfiguration(new ProfessorshipConfig());
            modelBuilder.ApplyConfiguration(new ScheduleConfig());
            modelBuilder.ApplyConfiguration(new SchoolConfig());
            modelBuilder.ApplyConfiguration(new SectionConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new TenureConfig());
        }
    }
}