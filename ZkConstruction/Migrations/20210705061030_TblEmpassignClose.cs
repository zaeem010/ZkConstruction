using Microsoft.EntityFrameworkCore.Migrations;

namespace ZkConstruction.Migrations
{
    public partial class TblEmpassignClose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpassignClose",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proid = table.Column<int>(nullable: false),
                    Employeeid = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpassignClose", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpassignClose");
        }
    }
}
