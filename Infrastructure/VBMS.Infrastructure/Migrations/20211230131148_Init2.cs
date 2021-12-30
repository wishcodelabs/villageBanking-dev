using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VBMS.Infrastructure.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membership_VillageBankGroups_VillageBankGroupId",
                table: "Membership");

            migrationBuilder.DropIndex(
                name: "IX_Membership_VillageBankGroupId",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "VillageBankGroupId",
                table: "Membership");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_VillageGroupId",
                table: "Membership",
                column: "VillageGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_VillageBankGroups_VillageGroupId",
                table: "Membership",
                column: "VillageGroupId",
                principalTable: "VillageBankGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membership_VillageBankGroups_VillageGroupId",
                table: "Membership");

            migrationBuilder.DropIndex(
                name: "IX_Membership_VillageGroupId",
                table: "Membership");

            migrationBuilder.AddColumn<int>(
                name: "VillageBankGroupId",
                table: "Membership",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Membership_VillageBankGroupId",
                table: "Membership",
                column: "VillageBankGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_VillageBankGroups_VillageBankGroupId",
                table: "Membership",
                column: "VillageBankGroupId",
                principalTable: "VillageBankGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
