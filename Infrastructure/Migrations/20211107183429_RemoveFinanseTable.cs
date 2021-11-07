using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class RemoveFinanseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Difference = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanTrancheId = table.Column<int>(type: "int", nullable: false),
                    Savings = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Finances_LoanTranches_LoanTrancheId",
                        column: x => x.LoanTrancheId,
                        principalTable: "LoanTranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Finances_LoanTrancheId",
                table: "Finances",
                column: "LoanTrancheId");
        }
    }
}
