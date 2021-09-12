﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class addedcolumnStagetoLoanTranchetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stage",
                table: "LoanTranches",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stage",
                table: "LoanTranches");
        }
    }
}
