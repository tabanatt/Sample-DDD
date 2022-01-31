using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketGenerate.Infrastructure.Migrations
{
    public partial class newId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                schema: "ticket",
                table: "tickets",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Id",
                schema: "ticket",
                table: "tickets");
        }
    }
}
