using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollBudget.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NedId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StartDater = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDater = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FiscalYearCycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYear = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CycleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYearCycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StaffCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayrollDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayPlan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<int>(type: "int", nullable: false),
                    CAN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NextWIGI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FY20Actions = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    StartDater = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDater = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HrSal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BenRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BenCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayPeriods_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayPeriods_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subtotals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    SalaryWithoutBenefits = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashAwards = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalaryBenefitsCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashAwardBenefits = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalSalaryWithBenefits = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BenefitPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FTEUsage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FTEAssign = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtotals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subtotals_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    PayrollDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accessions_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accessions_PayrollDetails_PayrollDetailId",
                        column: x => x.PayrollDetailId,
                        principalTable: "PayrollDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessions_EmployeeId",
                table: "Accessions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessions_OfficeId",
                table: "Accessions",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessions_PayrollDetailId",
                table: "Accessions",
                column: "PayrollDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PayPeriods_EmployeeId",
                table: "PayPeriods",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayPeriods_OfficeId",
                table: "PayPeriods",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtotals_OfficeId",
                table: "Subtotals",
                column: "OfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessions");

            migrationBuilder.DropTable(
                name: "FiscalYearCycles");

            migrationBuilder.DropTable(
                name: "PayPeriods");

            migrationBuilder.DropTable(
                name: "Subtotals");

            migrationBuilder.DropTable(
                name: "PayrollDetails");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
