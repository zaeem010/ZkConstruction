using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZkConstruction.Migrations
{
    public partial class tblAbsentUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsentUser",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employeeid = table.Column<int>(nullable: false),
                    Proid = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsentUser", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbsentUser");
        }
    }
}
