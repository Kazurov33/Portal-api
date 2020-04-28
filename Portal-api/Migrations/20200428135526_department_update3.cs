using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class department_update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_HighDepartmentId",
                table: "Departments");

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
                name: "FK_Departments_Departments_HighDepartmentId",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "LowDepartmentId",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_LowDepartmentId",
                table: "Departments",
                column: "LowDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
