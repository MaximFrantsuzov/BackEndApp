using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndApp.Migrations
{
    /// <inheritdoc />
    public partial class IdDepartamentEmployeeAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartamentId",
                table: "Employees",
                column: "DepartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departamentes_DepartamentId",
                table: "Employees",
                column: "DepartamentId",
                principalTable: "Departamentes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departamentes_DepartamentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartamentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartamentId",
                table: "Employees");
        }
    }
}
