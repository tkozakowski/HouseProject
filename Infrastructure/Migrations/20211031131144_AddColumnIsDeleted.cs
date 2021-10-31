using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class AddColumnIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Executions_ExecutionId",
                table: "Materials");

            migrationBuilder.AlterColumn<int>(
                name: "ExecutionId",
                table: "Materials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Executions_ExecutionId",
                table: "Materials",
                column: "ExecutionId",
                principalTable: "Executions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Executions_ExecutionId",
                table: "Materials");

            migrationBuilder.AlterColumn<int>(
                name: "ExecutionId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Executions_ExecutionId",
                table: "Materials",
                column: "ExecutionId",
                principalTable: "Executions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
