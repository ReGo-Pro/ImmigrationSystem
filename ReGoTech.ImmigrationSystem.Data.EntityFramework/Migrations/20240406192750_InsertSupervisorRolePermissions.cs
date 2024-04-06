using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertSupervisorRolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var rolePermissionsInsert = @"
SET IDENTITY_INSERT RolePermissions ON;
INSERT INTO RolePermissions (RolePermissionId, RoleId, PermissionId, PermissionMask) VALUES
(16, 3, 4, 'YYYYYYYY'),      -- Grant full access to Officer.Data for Supervisor role
(17, 3, 5, 'YYYYYYYY'),      -- Grant full access to Officer.Workflows for Supervisor role
(18, 3, 6, 'YYYYYYYY'),      -- Grant full access to Officer.Reports for Supervisor role
(19, 3, 7, 'YYYYYYYY'),      -- Grant full access to Application.Data for Supervisor role
(20, 3, 8, 'YYYYYYYY'),      -- Grant full access to Application.Workflows for Supervisor role
(21, 3, 9, 'YYYYYYYY'),      -- Grant full access to Application.Reports for Supervisor role
(22, 3, 10, 'YYYYYYYY'),     -- Grant full access to Client.Data for Supervisor role
(23, 3, 11, 'YYYYYYYY'),     -- Grant full access to Client.Operations for Supervisor role
(24, 3, 12, 'YYYYYYYY')      -- Grant full access to Client.Reports for Supervisor role
SET IDENTITY_INSERT RolePermissions OFF;
";
			migrationBuilder.Sql(rolePermissionsInsert);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			var rolePermissionsDelete = "DELETE FROM RolePermissions WHERE RolePermissionId IN (16, 17, 18, 19, 20, 21, 22, 23, 24)";
			migrationBuilder.Sql(rolePermissionsDelete);
		}
    }
}
