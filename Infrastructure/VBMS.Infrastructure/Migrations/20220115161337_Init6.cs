using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VBMS.Infrastructure.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Membership_RequestId",
                table: "Loans");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ApproverId",
                table: "Loans",
                column: "ApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Membership_ApproverId",
                table: "Loans",
                column: "ApproverId",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Membership_ApproverId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_ApproverId",
                table: "Loans");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Membership_RequestId",
                table: "Loans",
                column: "RequestId",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
