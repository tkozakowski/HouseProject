using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class addtablePaymentTypeandchangeenumPaymenttoPaymentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Preparations");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Preparations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Material",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PaymentTypeId",
                table: "Projects",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Preparations_PaymentTypeId",
                table: "Preparations",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_PaymentTypeId",
                table: "Material",
                column: "PaymentTypeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_PaymentType_PaymentTypeId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_Preparations_PaymentType_PaymentTypeId",
                table: "Preparations");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_PaymentType_PaymentTypeId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PaymentTypeId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Preparations_PaymentTypeId",
                table: "Preparations");

            migrationBuilder.DropIndex(
                name: "IX_Material_PaymentTypeId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Preparations");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Material");

            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "Preparations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
