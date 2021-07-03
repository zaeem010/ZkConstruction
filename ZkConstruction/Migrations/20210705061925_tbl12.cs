using Microsoft.EntityFrameworkCore.Migrations;

namespace ZkConstruction.Migrations
{
    public partial class tbl12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CloseDateTime",
                table: "EmpassignClose",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseDateTime",
                table: "EmpassignClose");
        }
    }
}
