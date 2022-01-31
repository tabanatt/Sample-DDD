using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketGenerate.Infrastructure.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ticket");

            migrationBuilder.CreateSequence(
                name: "ticketeq",
                schema: "ticket",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "tickets",
                schema: "ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    User_Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets",
                schema: "ticket");

            migrationBuilder.DropSequence(
                name: "ticketeq",
                schema: "ticket");
        }
    }
}
