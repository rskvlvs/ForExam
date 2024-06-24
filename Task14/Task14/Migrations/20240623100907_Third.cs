using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task14.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workers_works_WorkId",
                table: "workers");

            migrationBuilder.RenameColumn(
                name: "WorkId",
                table: "workers",
                newName: "workCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_workers_WorkId",
                table: "workers",
                newName: "IX_workers_workCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_workers_works_workCompanyId",
                table: "workers",
                column: "workCompanyId",
                principalTable: "works",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workers_works_workCompanyId",
                table: "workers");

            migrationBuilder.RenameColumn(
                name: "workCompanyId",
                table: "workers",
                newName: "WorkId");

            migrationBuilder.RenameIndex(
                name: "IX_workers_workCompanyId",
                table: "workers",
                newName: "IX_workers_WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_workers_works_WorkId",
                table: "workers",
                column: "WorkId",
                principalTable: "works",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
