using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var rolesInsert = @"
SET IDENTITY_INSERT Roles ON;
INSERT INTO Roles (RoleId, Name, Description) VALUES
(1, 'SysAdmin', 'Has full control over the application including system level configurations, officer and client information'),
(2, 'TechAdmin', 'Has full control over system settings but not officer or client information'),
(3, 'Supervisor', 'Has full control over officer and cleint information but not system settings'),
(4, 'Officer', 'Can view client data, approve/disapprove applications but cannot modify any client information'),
(5, 'Applicant', 'Can view and modify his/her own information including documents and profile')
SET IDENTITY_INSERT Roles OFF;
";
			migrationBuilder.Sql(rolesInsert);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var rolesDelete = "DELETE FROM Roles WHERE RoleId IN (1, 2, 3, 4, 5);";
            migrationBuilder.Sql(rolesDelete);
		}
    }
}
