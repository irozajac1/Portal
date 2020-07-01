using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class korekcija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Abouts_AboutId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Literatures_LiteratureId",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_AboutId",
                table: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_LiteratureId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Attachment");

            migrationBuilder.DropColumn(
            name: "MessageId",
            table: "Attachment");

            migrationBuilder.DropColumn(
                name: "LiteratureId",
                table: "Attachment");

            migrationBuilder.AddColumn<Guid>(
                name: "FilesAttachmentId",
                table: "Literatures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Literatures_FilesAttachmentId",
                table: "Literatures",
                column: "FilesAttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Literatures_Attachment_FilesAttachmentId",
                table: "Literatures",
                column: "FilesAttachmentId",
                principalTable: "Attachment",
                principalColumn: "AttachmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Literatures_Attachment_FilesAttachmentId",
                table: "Literatures");

            migrationBuilder.DropIndex(
                name: "IX_Literatures_FilesAttachmentId",
                table: "Literatures");

            migrationBuilder.DropColumn(
                name: "FilesAttachmentId",
                table: "Literatures");

            migrationBuilder.AddColumn<Guid>(
                name: "AboutId",
                table: "Attachment",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LiteratureId",
                table: "Attachment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_AboutId",
                table: "Attachment",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_LiteratureId",
                table: "Attachment",
                column: "LiteratureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Abouts_AboutId",
                table: "Attachment",
                column: "AboutId",
                principalTable: "Abouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Literatures_LiteratureId",
                table: "Attachment",
                column: "LiteratureId",
                principalTable: "Literatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
