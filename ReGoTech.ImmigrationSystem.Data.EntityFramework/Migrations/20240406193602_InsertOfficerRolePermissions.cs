using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertOfficerRolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var rolePermissionsInsert = @"
SET IDENTITY_INSERT RolePermissions ON;
INSERT INTO RolePermissions (RolePermissionId, RoleId, PermissionId, PermissionMask) VALUES
(25, 4, 7, 'NYNNNNNN'),      -- Grant read-only access to Application.Data for officer role
(26, 4, 8, 'YYYYNNNN'),      -- Grant CRUD access to Application.Workflows for officer role
(27, 4, 9, 'YYYYNNNN'),      -- Grant CRUD access to Application.Reports for officer role
(28, 4, 10, 'NYNNNNNN'),     -- Grant readonly access to Client.Data for officer role
(29, 4, 11, 'YYYYNNNN'),     -- Grant CRUD access to Client.Operations for officer role
(30, 4, 12, 'YYYYNNNN')      -- Grant CRUD access to Client.Reports for officer role
SET IDENTITY_INSERT RolePermissions OFF;
";
			migrationBuilder.Sql(rolePermissionsInsert);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			var rolePermissionsDelete = "DELETE FROM RolePermissions WHERE RolePermissionId IN (25, 26, 27, 28, 29, 30)";
			migrationBuilder.Sql(rolePermissionsDelete);
		}
    }
}
