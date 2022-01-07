using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VBMS.Infrastructure.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Applicant_ApplicantId",
                table: "LoanApplications");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.DropColumn(
                name: "PaybackDuration",
                table: "LoanTypes");

            migrationBuilder.AddColumn<int>(
                name: "PaybackDuration",
                table: "LoanInterestRates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterestRateId",
                table: "LoanApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_InterestRateId",
                table: "LoanApplications",
                column: "InterestRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_LoanInterestRates_InterestRateId",
                table: "LoanApplications",
                column: "InterestRateId",
                principalTable: "LoanInterestRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Membership_ApplicantId",
                table: "LoanApplications",
                column: "ApplicantId",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_LoanInterestRates_InterestRateId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Membership_ApplicantId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_InterestRateId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "PaybackDuration",
                table: "LoanInterestRates");

            migrationBuilder.DropColumn(
                name: "InterestRateId",
                table: "LoanApplications");

            migrationBuilder.AddColumn<int>(
                name: "PaybackDuration",
                table: "LoanTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applicant_Membership_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_MembershipId",
                table: "Applicant",
                column: "MembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Applicant_ApplicantId",
                table: "LoanApplications",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
