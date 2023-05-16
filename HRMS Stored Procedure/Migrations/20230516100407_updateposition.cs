using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class updateposition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE UpdatePositionById
                        @posId INT,
                        @NewPositionName VARCHAR(100)
                    AS
                    BEGIN
                        UPDATE Positions
                        SET PositionName = @NewPositionName
                        WHERE PosId = @posId;
                    END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE UpdatePositionById";
            migrationBuilder.Sql(sp);
        }
    }
}
