using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TinyCollege.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsMechanic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    PartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CurrentAmount = table.Column<int>(nullable: false),
                    MinimumLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.PartId);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    SeatingCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorContract",
                columns: table => new
                {
                    ProfessorContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isActive = table.Column<bool>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    ContractId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorContract", x => x.ProfessorContractId);
                    table.ForeignKey(
                        name: "FK_ProfessorContract_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorContract_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DeanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId);
                    table.ForeignKey(
                        name: "FK_School_Professor_DeanId",
                        column: x => x.DeanId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    ReleasingMechanicId = table.Column<int>(nullable: true),
                    VehicleId = table.Column<int>(nullable: false),
                    ReportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.MaintenanceId);
                    table.ForeignKey(
                        name: "FK_Maintenance_Employee_ReleasingMechanicId",
                        column: x => x.ReleasingMechanicId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenance_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenance_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    Destination = table.Column<string>(nullable: true),
                    Billing = table.Column<int>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    ReportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SchoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceDetail",
                columns: table => new
                {
                    MaintenanceDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessingDate = table.Column<DateTime>(nullable: false),
                    MaintenanceId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceDetail", x => x.MaintenanceDetailId);
                    table.ForeignKey(
                        name: "FK_MaintenanceDetail_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceDetail_Maintenance_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenance",
                        principalColumn: "MaintenanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationForm",
                columns: table => new
                {
                    ReservationFormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTime>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationForm", x => x.ReservationFormId);
                    table.ForeignKey(
                        name: "FK_ReservationForm_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationForm_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professorship",
                columns: table => new
                {
                    ProfessorShipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isActive = table.Column<bool>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professorship", x => x.ProfessorShipId);
                    table.ForeignKey(
                        name: "FK_Professorship_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professorship_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    AdvisoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tenure",
                columns: table => new
                {
                    TenureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Succession = table.Column<int>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenure", x => x.TenureId);
                    table.ForeignKey(
                        name: "FK_Tenure_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tenure_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartUsage",
                columns: table => new
                {
                    PartUsageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    PartId = table.Column<int>(nullable: false),
                    MaintenanceDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartUsage", x => x.PartUsageId);
                    table.ForeignKey(
                        name: "FK_PartUsage_MaintenanceDetail_MaintenanceDetailId",
                        column: x => x.MaintenanceDetailId,
                        principalTable: "MaintenanceDetail",
                        principalColumn: "MaintenanceDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartUsage_Part_PartId",
                        column: x => x.PartId,
                        principalTable: "Part",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ScheduleId = table.Column<int>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Section_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Section_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advisory",
                columns: table => new
                {
                    AdvisoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisory", x => x.AdvisoryId);
                    table.ForeignKey(
                        name: "FK_Advisory_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advisory_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advisory_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollment_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(nullable: true),
                    RoomCode = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    SectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedule_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advisory_DepartmentId",
                table: "Advisory",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisory_ProfessorId",
                table: "Advisory",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisory_StudentId",
                table: "Advisory",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_SchoolId",
                table: "Department",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_SectionId",
                table: "Enrollment",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_ReleasingMechanicId",
                table: "Maintenance",
                column: "ReleasingMechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_ReportId",
                table: "Maintenance",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_VehicleId",
                table: "Maintenance",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDetail_EmployeeId",
                table: "MaintenanceDetail",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDetail_MaintenanceId",
                table: "MaintenanceDetail",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PartUsage_MaintenanceDetailId",
                table: "PartUsage",
                column: "MaintenanceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PartUsage_PartId",
                table: "PartUsage",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorContract_ContractId",
                table: "ProfessorContract",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorContract_ProfessorId",
                table: "ProfessorContract",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Professorship_DepartmentId",
                table: "Professorship",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Professorship_ProfessorId",
                table: "Professorship",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ProfessorId",
                table: "Reservation",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReportId",
                table: "Reservation",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_VehicleId",
                table: "Reservation",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationForm_EmployeeId",
                table: "ReservationForm",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationForm_ReservationId",
                table: "ReservationForm",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SectionId",
                table: "Schedule",
                column: "SectionId",
                unique: true,
                filter: "[SectionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_School_DeanId",
                table: "School",
                column: "DeanId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_CourseId",
                table: "Section",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_ProfessorId",
                table: "Section",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId",
                table: "Student",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenure_DepartmentId",
                table: "Tenure",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenure_ProfessorId",
                table: "Tenure",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advisory");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "PartUsage");

            migrationBuilder.DropTable(
                name: "ProfessorContract");

            migrationBuilder.DropTable(
                name: "Professorship");

            migrationBuilder.DropTable(
                name: "ReservationForm");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Tenure");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "MaintenanceDetail");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
