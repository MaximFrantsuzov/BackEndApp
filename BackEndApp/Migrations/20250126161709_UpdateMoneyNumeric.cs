using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMoneyNumeric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "JobTitles",
                type: "numeric(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "JobTitles",
                type: "money",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,0)");
        }
    }
}
