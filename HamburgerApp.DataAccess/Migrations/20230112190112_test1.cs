using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerApp.DataAccess.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Orders");
        }
    }
}
