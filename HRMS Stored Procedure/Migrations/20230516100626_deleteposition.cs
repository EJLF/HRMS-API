using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class deleteposition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE DeletePositionById
                            @posId INT
                        AS
                        BEGIN
                            DELETE FROM Positions
                            WHERE PosId = @posId;
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE DeletePositionById";
            migrationBuilder.Sql(sp);
        }
    }
}
