using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class AddFinanceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinanceId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinanceId",
                table: "Preparations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinanceId",
                table: "Executions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinanceId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Finance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectsCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PreparationsCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DocumentsCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExecutionsCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finance", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_FinanceId",
                table: "Projects",
                column: "FinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Preparations_FinanceId",
                table: "Preparations",
                column: "FinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Executions_FinanceId",
                table: "Executions",
                column: "FinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FinanceId",
                table: "Documents",
                column: "FinanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Finance_FinanceId",
                table: "Documents",
                column: "FinanceId",
                principalTable: "Finance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Executions_Finance_FinanceId",
                table: "Executions",
                column: "FinanceId",
                principalTable: "Finance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Preparations_Finance_FinanceId",
                table: "Preparations",
                column: "FinanceId",
                principalTable: "Finance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Finance_FinanceId",
                table: "Projects",
                column: "FinanceId",
                principalTable: "Finance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Finance_FinanceId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Executions_Finance_FinanceId",
                table: "Executions");

            migrationBuilder.DropForeignKey(
                name: "FK_Preparations_Finance_FinanceId",
                table: "Preparations");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Finance_FinanceId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Finance");

            migrationBuilder.DropIndex(
                name: "IX_Projects_FinanceId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Preparations_FinanceId",
                table: "Preparations");

            migrationBuilder.DropIndex(
                name: "IX_Executions_FinanceId",
                table: "Executions");

            migrationBuilder.DropIndex(
                name: "IX_Documents_FinanceId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FinanceId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "FinanceId",
                table: "Preparations");

            migrationBuilder.DropColumn(
                name: "FinanceId",
                table: "Executions");

            migrationBuilder.DropColumn(
                name: "FinanceId",
                table: "Documents");
        }
    }
}
