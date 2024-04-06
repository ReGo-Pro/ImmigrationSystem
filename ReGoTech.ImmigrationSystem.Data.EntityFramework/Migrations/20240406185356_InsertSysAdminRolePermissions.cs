using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertSysAdminRolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var rolePermissionsInsert = @"
SET IDENTITY_INSERT RolePermissions ON;
INSERT INTO RolePermissions (RolePermissionId, RoleId, PermissionId, PermissionMask) VALUES
(1, 1, 1, 'YYYYYYYY'),      -- Grant full access to System.Settings for SysAdmin role
(2, 1, 2, 'YYYYYYYY'),      -- Grant full access to System.Security for SysAdmin role
(3, 1, 3, 'YYYYYYYY'),      -- Grant full access to System.Reports for SysAdmin role
(4, 1, 4, 'YYYYYYYY'),      -- Grant full access to Officer.Data for SysAdmin role
(5, 1, 5, 'YYYYYYYY'),      -- Grant full access to Officer.Workflows for SysAdmin role
(6, 1, 6, 'YYYYYYYY'),      -- Grant full access to Officer.Reports for SysAdmin role
(7, 1, 7, 'YYYYYYYY'),      -- Grant full access to Application.Data for SysAdmin role
(8, 1, 8, 'YYYYYYYY'),      -- Grant full access to Application.Workflows for SysAdmin role
(9, 1, 9, 'YYYYYYYY'),      -- Grant full access to Application.Reports for SysAdmin role
(10, 1, 10, 'YYYYYYYY'),    -- Grant full access to Client.Data for SysAdmin role
(11, 1, 11, 'YYYYYYYY'),    -- Grant full access to Client.Operations for SysAdmin role
(12, 1, 12, 'YYYYYYYY')     -- Grant full access to Client.Reports for SysAdmin role
SET IDENTITY_INSERT RolePermissions OFF;
";
            migrationBuilder.Sql(rolePermissionsInsert);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var rolePermissionsDelete = "DELETE FROM RolePermissions WHERE RolePermissionId IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)";
            migrationBuilder.Sql(rolePermissionsDelete);
        }
    }
}
