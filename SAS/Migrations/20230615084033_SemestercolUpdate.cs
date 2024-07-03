using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAS.Migrations
{
    /// <inheritdoc />
    public partial class SemestercolUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "semester",
                table: "Semester",
                newName: "SemesterName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SemesterName",
                table: "Semester",
                newName: "semester");
        }
    }
}
