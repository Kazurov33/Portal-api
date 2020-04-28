using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class dapartment_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighDepartmentId",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "HighDepartmentId",
                table: "Departments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LowDepartmentId",
                table: "Departments",
                column: "HighDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_HighDepartmentId",
                table: "Departments",
                column: "HighDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_LowDepartmentId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LowDepartmentId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LowDepartmentId",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "HighDepartmentId",
                table: "Departments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
