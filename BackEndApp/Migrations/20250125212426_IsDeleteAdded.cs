using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndApp.Migrations
{
    /// <inheritdoc />
    public partial class IsDeleteAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Subdivisions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChangeHistory",
                table: "HistorySubdivisions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChangeHistory",
                table: "HistoryDepartamentes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departamentes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Subdivisions");

            migrationBuilder.DropColumn(
                name: "DateChangeHistory",
                table: "HistorySubdivisions");

            migrationBuilder.DropColumn(
                name: "DateChangeHistory",
                table: "HistoryDepartamentes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departamentes");
        }
    }
}
