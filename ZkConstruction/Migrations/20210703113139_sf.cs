using Microsoft.EntityFrameworkCore.Migrations;

namespace ZkConstruction.Migrations
{
    public partial class sf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StdateTimeFlooring",
                table: "Home",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StdateTimeFlooring",
                table: "Home");
        }
    }
}
