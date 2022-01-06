using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VBMS.Infrastructure.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "UploadFile");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "UploadFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "UploadFile");

            migrationBuilder.AddColumn<int>(
                name: "ContentType",
                table: "UploadFile",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
