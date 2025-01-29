using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConnectionEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobTitles_JobTitleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkActivities_JobTitles_JobTitleId",
                table: "WorkActivities");

            migrationBuilder.DropIndex(
                name: "IX_WorkActivities_JobTitleId",
                table: "WorkActivities");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JobTitleId",
                table: "WorkActivities");

            migrationBuilder.DropColumn(
                name: "JobTitleId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TitleJobId",
                table: "Employees",
                column: "TitleJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobTitles_TitleJobId",
                table: "Employees",
                column: "TitleJobId",
                principalTable: "JobTitles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobTitles_TitleJobId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TitleJobId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "JobTitleId",
                table: "WorkActivities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobTitleId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkActivities_JobTitleId",
                table: "WorkActivities",
                column: "JobTitleId");

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
    }
}
