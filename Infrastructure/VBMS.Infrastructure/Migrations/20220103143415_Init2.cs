using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VBMS.Infrastructure.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Applicant_ApplicantId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_LoanTypes_LoanTypeId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoadNumber",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "RequestedAmount",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoanNumber",
                table: "LoanPayments");

            migrationBuilder.RenameColumn(
                name: "LoanTypeId",
                table: "Loans",
                newName: "RequestId");

            migrationBuilder.RenameColumn(
                name: "DateSubmitted",
                table: "Loans",
                newName: "DateDue");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                table: "Loans",
                newName: "RatingId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_LoanTypeId",
                table: "Loans",
                newName: "IX_Loans_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_ApplicantId",
                table: "Loans",
                newName: "IX_Loans_RatingId");

            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApproved",
                table: "Loans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LoanPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    RequestedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LoanTypeId = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplications_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplications_LoanTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_PeriodId",
                table: "Loans",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanPayments_LoanId",
                table: "LoanPayments",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ApplicantId",
                table: "LoanApplications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_LoanTypeId",
                table: "LoanApplications",
                column: "LoanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayments_Loans_LoanId",
                table: "LoanPayments",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_InvestmentPeriods_PeriodId",
                table: "Loans",
                column: "PeriodId",
                principalTable: "InvestmentPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_LoanApplications_RequestId",
                table: "Loans",
                column: "RequestId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_LoanInterestRates_RatingId",
                table: "Loans",
                column: "RatingId",
                principalTable: "LoanInterestRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Membership_RequestId",
                table: "Loans",
                column: "RequestId",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayments_Loans_LoanId",
                table: "LoanPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_InvestmentPeriods_PeriodId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_LoanApplications_RequestId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_LoanInterestRates_RatingId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Membership_RequestId",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_Loans_PeriodId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_LoanPayments_LoanId",
                table: "LoanPayments");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "DateApproved",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LoanPayments");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Loans",
                newName: "LoanTypeId");

            migrationBuilder.RenameColumn(
                name: "RatingId",
                table: "Loans",
                newName: "ApplicantId");

            migrationBuilder.RenameColumn(
                name: "DateDue",
                table: "Loans",
                newName: "DateSubmitted");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_RequestId",
                table: "Loans",
                newName: "IX_Loans_LoanTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_RatingId",
                table: "Loans",
                newName: "IX_Loans_ApplicantId");

            migrationBuilder.AddColumn<string>(
                name: "LoadNumber",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "RequestedAmount",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LoanNumber",
                table: "LoanPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Applicant_ApplicantId",
                table: "Loans",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_LoanTypes_LoanTypeId",
                table: "Loans",
                column: "LoanTypeId",
                principalTable: "LoanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
