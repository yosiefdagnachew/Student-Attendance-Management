using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAS.Migrations
{
    /// <inheritdoc />
    public partial class AcUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Academic_year",
                table: "Academic_Year",
                newName: "Academic_yearName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Academic_yearName",
                table: "Academic_Year",
                newName: "Academic_year");
        }
    }
}
