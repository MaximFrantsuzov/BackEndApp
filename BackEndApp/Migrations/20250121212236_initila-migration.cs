using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndApp.Migrations
{
    /// <inheritdoc />
    public partial class initilamigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberPhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    LevelEducation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameJobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "money", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subdivisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSubdivision = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassportsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Series = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Number = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    TypePassport = table.Column<int>(type: "int", nullable: false),
                    IssuedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportsInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassportsInfo_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departamentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDepartament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubdivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentes_Subdivisions_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorySubdivisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeEventDepSub = table.Column<int>(type: "int", nullable: false),
                    SubdivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorySubdivisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorySubdivisions_Subdivisions_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffingTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    SubdivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffingTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffingTables_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffingTables_Subdivisions_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryDepartamentes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeEventDepSub = table.Column<int>(type: "int", nullable: false),
                    DepartamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryDepartamentes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HistoryDepartamentes_Departamentes_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departamentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Event = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeEventEmployee = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartamentId = table.Column<int>(type: "int", nullable: false),
                    JobTitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkActivities_Departamentes_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departamentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkActivities_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkActivities_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamentes_SubdivisionId",
                table: "Departamentes",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryDepartamentes_DepartamentId",
                table: "HistoryDepartamentes",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorySubdivisions_SubdivisionId",
                table: "HistorySubdivisions",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PassportsInfo_EmployeeId",
                table: "PassportsInfo",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffingTables_JobTitleId",
                table: "StaffingTables",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffingTables_SubdivisionId",
                table: "StaffingTables",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkActivities_DepartamentId",
                table: "WorkActivities",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkActivities_EmployeeId",
                table: "WorkActivities",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkActivities_JobTitleId",
                table: "WorkActivities",
                column: "JobTitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryDepartamentes");

            migrationBuilder.DropTable(
                name: "HistorySubdivisions");

            migrationBuilder.DropTable(
                name: "PassportsInfo");

            migrationBuilder.DropTable(
                name: "StaffingTables");

            migrationBuilder.DropTable(
                name: "WorkActivities");

            migrationBuilder.DropTable(
                name: "Departamentes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "Subdivisions");
        }
    }
}
