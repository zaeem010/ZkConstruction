using Microsoft.EntityFrameworkCore.Migrations;

namespace ZkConstruction.Migrations
{
    public partial class djksahd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CloseDateTime",
                table: "EmployeeAssigned",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseDateTime",
                table: "EmployeeAssigned");
        }
    }
}
