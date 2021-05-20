using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Data.Migrations
{
    public partial class LoanTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmount = table.Column<double>(type: "float", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RateOfInterest = table.Column<double>(type: "float", nullable: false),
                    LoanDuration = table.Column<int>(type: "int", nullable: false),
                    CourseFee = table.Column<double>(type: "float", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherSalary = table.Column<double>(type: "float", nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherCompany = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationLoans_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmount = table.Column<double>(type: "float", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RateOfInterest = table.Column<double>(type: "float", nullable: false),
                    LoanDuration = table.Column<int>(type: "int", nullable: false),
                    AnnualIncome = table.Column<double>(type: "float", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalExperience = table.Column<int>(type: "int", nullable: false),
                    TotalExperienceWithCurrentCompany = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalLoans_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationLoans_ApplicationUserId",
                table: "EducationLoans",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalLoans_ApplicationUserId",
                table: "PersonalLoans",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationLoans");

            migrationBuilder.DropTable(
                name: "PersonalLoans");
        }
    }
}
