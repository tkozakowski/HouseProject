using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class addenumfieldtoApplicationDocumentProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Payment",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Payment",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Payment",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Applications");
        }
    }
}
