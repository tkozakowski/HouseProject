using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class ChangeTableNameToSendApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Applications_ApplicationId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentsBackup_Applications_ApplicationId",
                table: "AttachmentsBackup");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.CreateTable(
                name: "SendApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SendBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    SendTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SendApplications_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SendApplications_SendTypes_SendTypeId",
                        column: x => x.SendTypeId,
                        principalTable: "SendTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SendApplications_PostId",
                table: "SendApplications",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_SendApplications_SendTypeId",
                table: "SendApplications",
                column: "SendTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_SendApplications_ApplicationId",
                table: "Attachments",
                column: "ApplicationId",
                principalTable: "SendApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentsBackup_SendApplications_ApplicationId",
                table: "AttachmentsBackup",
                column: "ApplicationId",
                principalTable: "SendApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_SendApplications_ApplicationId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentsBackup_SendApplications_ApplicationId",
                table: "AttachmentsBackup");

            migrationBuilder.DropTable(
                name: "SendApplications");

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SendAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SendBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_SendTypes_SendTypeId",
                        column: x => x.SendTypeId,
                        principalTable: "SendTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PostId",
                table: "Applications",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_SendTypeId",
                table: "Applications",
                column: "SendTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Applications_ApplicationId",
                table: "Attachments",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentsBackup_Applications_ApplicationId",
                table: "AttachmentsBackup",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
