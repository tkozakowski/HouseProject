using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class adStagetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Stage_StageId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Execution_WorkStages_WorkStageID",
                table: "Execution");

            migrationBuilder.DropForeignKey(
                name: "FK_Finance_LoanTranches_LoanTrancheId",
                table: "Finance");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_Execution_ExecutionId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_LoanTranches_LoanTrancheId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_PaymentType_PaymentTypeId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_Preparations_PaymentType_PaymentTypeId",
                table: "Preparations");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_PaymentType_PaymentTypeId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stage",
                table: "Stage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentType",
                table: "PaymentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Finance",
                table: "Finance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Execution",
                table: "Execution");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Material");

            migrationBuilder.RenameTable(
                name: "Stage",
                newName: "Stages");

            migrationBuilder.RenameTable(
                name: "PaymentType",
                newName: "PaymentTypes");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "Materials");

            migrationBuilder.RenameTable(
                name: "Finance",
                newName: "Finances");

            migrationBuilder.RenameTable(
                name: "Execution",
                newName: "Executions");

            migrationBuilder.RenameIndex(
                name: "IX_Material_PaymentTypeId",
                table: "Materials",
                newName: "IX_Materials_PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Material_LoanTrancheId",
                table: "Materials",
                newName: "IX_Materials_LoanTrancheId");

            migrationBuilder.RenameIndex(
                name: "IX_Material_ExecutionId",
                table: "Materials",
                newName: "IX_Materials_ExecutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Finance_LoanTrancheId",
                table: "Finances",
                newName: "IX_Finances_LoanTrancheId");

            migrationBuilder.RenameIndex(
                name: "IX_Execution_WorkStageID",
                table: "Executions",
                newName: "IX_Executions_WorkStageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stages",
                table: "Stages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypes",
                table: "PaymentTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finances",
                table: "Finances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Executions",
                table: "Executions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Stages_StageId",
                table: "Documents",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Executions_WorkStages_WorkStageID",
                table: "Executions",
                column: "WorkStageID",
                principalTable: "WorkStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_LoanTranches_LoanTrancheId",
                table: "Finances",
                column: "LoanTrancheId",
                principalTable: "LoanTranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Executions_ExecutionId",
                table: "Materials",
                column: "ExecutionId",
                principalTable: "Executions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_LoanTranches_LoanTrancheId",
                table: "Materials",
                column: "LoanTrancheId",
                principalTable: "LoanTranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_PaymentTypes_PaymentTypeId",
                table: "Materials",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Preparations_PaymentTypes_PaymentTypeId",
                table: "Preparations",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_PaymentTypes_PaymentTypeId",
                table: "Projects",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Stages_StageId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Executions_WorkStages_WorkStageID",
                table: "Executions");

            migrationBuilder.DropForeignKey(
                name: "FK_Finances_LoanTranches_LoanTrancheId",
                table: "Finances");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Executions_ExecutionId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_LoanTranches_LoanTrancheId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_PaymentTypes_PaymentTypeId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Preparations_PaymentTypes_PaymentTypeId",
                table: "Preparations");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_PaymentTypes_PaymentTypeId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stages",
                table: "Stages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypes",
                table: "PaymentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Finances",
                table: "Finances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Executions",
                table: "Executions");

            migrationBuilder.RenameTable(
                name: "Stages",
                newName: "Stage");

            migrationBuilder.RenameTable(
                name: "PaymentTypes",
                newName: "PaymentType");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Material");

            migrationBuilder.RenameTable(
                name: "Finances",
                newName: "Finance");

            migrationBuilder.RenameTable(
                name: "Executions",
                newName: "Execution");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_PaymentTypeId",
                table: "Material",
                newName: "IX_Material_PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_LoanTrancheId",
                table: "Material",
                newName: "IX_Material_LoanTrancheId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_ExecutionId",
                table: "Material",
                newName: "IX_Material_ExecutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Finances_LoanTrancheId",
                table: "Finance",
                newName: "IX_Finance_LoanTrancheId");

            migrationBuilder.RenameIndex(
                name: "IX_Executions_WorkStageID",
                table: "Execution",
                newName: "IX_Execution_WorkStageID");

            migrationBuilder.AddColumn<int>(
                name: "Payment",
                table: "Material",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stage",
                table: "Stage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentType",
                table: "PaymentType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finance",
                table: "Finance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Execution",
                table: "Execution",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Stage_StageId",
                table: "Documents",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Execution_WorkStages_WorkStageID",
                table: "Execution",
                column: "WorkStageID",
                principalTable: "WorkStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Finance_LoanTranches_LoanTrancheId",
                table: "Finance",
                column: "LoanTrancheId",
                principalTable: "LoanTranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Execution_ExecutionId",
                table: "Material",
                column: "ExecutionId",
                principalTable: "Execution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_LoanTranches_LoanTrancheId",
                table: "Material",
                column: "LoanTrancheId",
                principalTable: "LoanTranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_PaymentType_PaymentTypeId",
                table: "Material",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Preparations_PaymentType_PaymentTypeId",
                table: "Preparations",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_PaymentType_PaymentTypeId",
                table: "Projects",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
