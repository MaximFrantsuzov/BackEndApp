using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndApp.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTableUnkonwn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkActivities_JobTitles_JobTitleId",
                table: "WorkActivities");

            migrationBuilder.DropTable(
                name: "PassportsInfo");

            migrationBuilder.DropTable(
                name: "StaffingTables");

            migrationBuilder.AlterColumn<int>(
                name: "JobTitleId",
                table: "WorkActivities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JobTitleId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TitleJobId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isDismissal",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees",
                column: "JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobTitles_JobTitleId",
                table: "Employees",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkActivities_JobTitles_JobTitleId",
                table: "WorkActivities",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobTitles_JobTitleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkActivities_JobTitles_JobTitleId",
                table: "WorkActivities");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JobTitleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TitleJobId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "isDismissal",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "JobTitleId",
                table: "WorkActivities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PassportsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IssuedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Series = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    TypePassport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhenIssued = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_WorkActivities_JobTitles_JobTitleId",
                table: "WorkActivities",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
