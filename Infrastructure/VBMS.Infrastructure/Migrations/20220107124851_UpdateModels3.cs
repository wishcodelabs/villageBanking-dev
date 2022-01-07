using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VBMS.Infrastructure.Migrations
{
    public partial class UpdateModels3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadFile_LoanApplications_LoanApplicationId",
                table: "UploadFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UploadFile",
                table: "UploadFile");

            migrationBuilder.DropIndex(
                name: "IX_UploadFile_LoanApplicationId",
                table: "UploadFile");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UploadFile");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UploadFile");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "UploadFile");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "UploadFile");

            migrationBuilder.RenameTable(
                name: "UploadFile",
                newName: "LoanApplicationAttachedFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanApplicationAttachedFiles",
                table: "LoanApplicationAttachedFiles",
                columns: new[] { "LoanApplicationId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationAttachedFiles_LoanApplications_LoanApplicationId",
                table: "LoanApplicationAttachedFiles",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationAttachedFiles_LoanApplications_LoanApplicationId",
                table: "LoanApplicationAttachedFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanApplicationAttachedFiles",
                table: "LoanApplicationAttachedFiles");

            migrationBuilder.RenameTable(
                name: "LoanApplicationAttachedFiles",
                newName: "UploadFile");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UploadFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UploadFile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "UploadFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "UploadFile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UploadFile",
                table: "UploadFile",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UploadFile_LoanApplicationId",
                table: "UploadFile",
                column: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadFile_LoanApplications_LoanApplicationId",
                table: "UploadFile",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
