using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class addposition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SP_AddPosition
                            @PostName VARCHAR(50)
                        AS
                        BEGIN
                            INSERT INTO Positions (PositionName)
                            VALUES (@PostName);
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SP_AddPosition";
            migrationBuilder.Sql(sp);
        }
    }
}
