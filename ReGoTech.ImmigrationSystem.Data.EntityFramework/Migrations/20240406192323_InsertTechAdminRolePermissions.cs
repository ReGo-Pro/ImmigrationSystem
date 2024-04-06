using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertTechAdminRolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var rolePermissionsInsert = @"
SET IDENTITY_INSERT RolePermissions ON;
INSERT INTO RolePermissions (RolePermissionId, RoleId, PermissionId, PermissionMask) VALUES
(13, 2, 1, 'YYYYYYYY'),      -- Grant full access to System.Settings for TechAdmin role
(14, 2, 2, 'YYYYYYYY'),      -- Grant full access to System.Security for TechAdmin role
(15, 2, 3, 'YYYYYYYY')       -- Grant full access to System.Reports for TechAdmin role
SET IDENTITY_INSERT RolePermissions OFF;
";
			migrationBuilder.Sql(rolePermissionsInsert);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			var rolePermissionsDelete = "DELETE FROM RolePermissions WHERE RolePermissionId IN (13, 14, 15)";
			migrationBuilder.Sql(rolePermissionsDelete);
		}
    }
}
