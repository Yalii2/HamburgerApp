using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerApp.DataAccess.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Orders");
        }
    }
}
