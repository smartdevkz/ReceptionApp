using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReceptionApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    IsMale = table.Column<bool>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitor");
        }
    }
}
