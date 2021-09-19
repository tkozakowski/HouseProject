using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class addStageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stage",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "StageId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StageId",
                table: "Documents",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Stage_StageId",
                table: "Documents",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Stage_StageId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropIndex(
                name: "IX_Documents_StageId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "Stage",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
