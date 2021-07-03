using Microsoft.EntityFrameworkCore.Migrations;

namespace ZkConstruction.Migrations
{
    public partial class employessda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnTime",
                table: "DEmployee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StTime",
                table: "DEmployee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnTime",
                table: "DEmployee");

            migrationBuilder.DropColumn(
                name: "StTime",
                table: "DEmployee");
        }
    }
}
