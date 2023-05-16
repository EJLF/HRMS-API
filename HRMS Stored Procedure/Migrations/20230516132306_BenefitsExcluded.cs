using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class BenefitsExcluded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PagIbigId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhilHealthId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SSSNumber",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PagIbigId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhilHealthId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SSSNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
