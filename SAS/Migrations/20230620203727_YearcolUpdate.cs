using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAS.Migrations
{
    /// <inheritdoc />
    public partial class YearcolUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "year",
                table: "Year",
                newName: "yearName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "yearName",
                table: "Year",
                newName: "year");
        }
    }
}
