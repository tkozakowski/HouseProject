using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class AddedExecutiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExecutionId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Execution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CostPayed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Account = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LaborCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkStageID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Execution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Execution_WorkStages_WorkStageID",
                        column: x => x.WorkStageID,
                        principalTable: "WorkStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ExecutionId",
                table: "Materials",
                column: "ExecutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Execution_WorkStageID",
                table: "Execution",
                column: "WorkStageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Execution_ExecutionId",
                table: "Materials",
                column: "ExecutionId",
                principalTable: "Execution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Execution_ExecutionId",
                table: "Materials");

            migrationBuilder.DropTable(
                name: "Execution");

            migrationBuilder.DropIndex(
                name: "IX_Materials_ExecutionId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ExecutionId",
                table: "Materials");
        }
    }
}
