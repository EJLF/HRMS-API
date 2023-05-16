using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_Stored_Procedure.Migrations
{
    public partial class AddApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
        CREATE PROCEDURE AddApplicationUser
            @FirstName nvarchar(100),
            @MiddleName nvarchar(100),
            @LastName nvarchar(100),
            @FullName nvarchar(300),
            @Gender nvarchar(10),
            @DateOfBirth date,
            @Phone nvarchar(20),
            @Email nvarchar(256),
            @DepartmentId int,
            @PositionId int,
            @EmployeeType nvarchar(100),

            @Street nvarchar(100),
            @Barangay nvarchar(100),
            @City nvarchar(100),
            @State nvarchar(100),
            @PostalCode nvarchar(20),
            @DateHired date,
            @ActiveStatus bit,
            @DeleteStatus bit
        AS
        BEGIN
            INSERT INTO AspNetUsers (
                UserName, 
                NormalizedUserName, 
                Email, 
                NormalizedEmail, 
                EmailConfirmed, 
                PasswordHash, 
                SecurityStamp, 
                ConcurrencyStamp, 
                PhoneNumber, 
                PhoneNumberConfirmed, 
                TwoFactorEnabled, 
                LockoutEnabled, 
                AccessFailedCount, 
                FirstName, 
                MiddleName, 
                LastName, 
                FullName, 
                Gender, 
                DateOfBirth, 
                DepartmentId, 
                PositionId, 
                EmployeeType, 

                Street, 
                Barangay, 
                City, 
                State, 
                PostalCode, 
                DateHired, 
                ActiveStatus, 
                DeleteStatus)
            VALUES (
                @Email,
                UPPER(@Email),
                @Email,
                UPPER(@Email),
                0,
                '',
                '',
                '',
                @Phone,
                0,
                0,
                0,
                0,
                @FirstName,
                @MiddleName,
                @LastName,
                @FullName,
                @Gender,
                @DateOfBirth,
                @DepartmentId,
                @PositionId,
                @EmployeeType,
                
                @Street,
                @Barangay,
                @City,
                @State,
                @PostalCode,
                @DateHired,
                @ActiveStatus,
                @DeleteStatus
            );
        END";

            migrationBuilder.Sql(sp);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE AddApplicationUser";
            migrationBuilder.Sql(sp);
        }
    }
}
