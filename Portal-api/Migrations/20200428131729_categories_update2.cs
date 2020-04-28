using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class categories_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NestingLevel",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NestingLevel",
                table: "Categories");
        }
    }
}
