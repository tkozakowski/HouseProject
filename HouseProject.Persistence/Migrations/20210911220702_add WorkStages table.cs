using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class addWorkStagestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Applications_Application_Fk",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_Application_Fk",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Application_Fk",
                table: "Document");

            migrationBuilder.CreateTable(
                name: "WorkStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkStages");

            migrationBuilder.AddColumn<int>(
                name: "Application_Fk",
                table: "Document",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_Application_Fk",
                table: "Document",
                column: "Application_Fk");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Applications_Application_Fk",
                table: "Document",
                column: "Application_Fk",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
