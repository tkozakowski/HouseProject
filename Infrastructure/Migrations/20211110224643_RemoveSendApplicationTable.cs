using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseProject.Api.Migrations
{
    public partial class RemoveSendApplicationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_SendApplications_ApplicationId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentsBackup_SendApplications_ApplicationId",
                table: "AttachmentsBackup");

            migrationBuilder.DropTable(
                name: "SendApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttachmentsBackup",
                table: "AttachmentsBackup");

            migrationBuilder.RenameTable(
                name: "AttachmentsBackup",
                newName: "AttachmentsSmall");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "Attachments",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_ApplicationId",
                table: "Attachments",
                newName: "IX_Attachments_DocumentId");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "AttachmentsSmall",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_AttachmentsBackup_ApplicationId",
                table: "AttachmentsSmall",
                newName: "IX_AttachmentsSmall_DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttachmentsSmall",
                table: "AttachmentsSmall",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Documents_DocumentId",
                table: "Attachments",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentsSmall_Documents_DocumentId",
                table: "AttachmentsSmall",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Documents_DocumentId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentsSmall_Documents_DocumentId",
                table: "AttachmentsSmall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttachmentsSmall",
                table: "AttachmentsSmall");

            migrationBuilder.RenameTable(
                name: "AttachmentsSmall",
                newName: "AttachmentsBackup");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Attachments",
                newName: "ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_DocumentId",
                table: "Attachments",
                newName: "IX_Attachments_ApplicationId");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "AttachmentsBackup",
                newName: "ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_AttachmentsSmall_DocumentId",
                table: "AttachmentsBackup",
                newName: "IX_AttachmentsBackup_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttachmentsBackup",
                table: "AttachmentsBackup",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SendApplications",
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
    }
}
