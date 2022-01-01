using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VBMS.Infrastructure.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Membership_InverstorId",
                table: "Investments");

            migrationBuilder.RenameColumn(
                name: "InverstorId",
                table: "Investments",
                newName: "InvestorId");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_InverstorId",
                table: "Investments",
                newName: "IX_Investments_InvestorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInvested",
                table: "Investments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Investments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Investments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Investments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Investments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Membership_InvestorId",
                table: "Investments",
                column: "InvestorId",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Membership_InvestorId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "Investments");

            migrationBuilder.RenameColumn(
                name: "InvestorId",
                table: "Investments",
                newName: "InverstorId");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_InvestorId",
                table: "Investments",
                newName: "IX_Investments_InverstorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInvested",
                table: "Investments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Membership_InverstorId",
                table: "Investments",
                column: "InverstorId",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
