using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task14.Migrations
{
    /// <inheritdoc />
    public partial class Secondone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "works",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "workers",
                newName: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "works",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "workers",
                newName: "Id");
        }
    }
}
