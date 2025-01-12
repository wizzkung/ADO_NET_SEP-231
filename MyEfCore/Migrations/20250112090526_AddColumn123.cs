using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEfCore.Migrations
{
    public partial class AddColumn123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Column123",
                table: "Stars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Column123",
                table: "Stars");
        }
    }
}
