using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertApplicantRolePermissions : Migration
    {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder) {
			var rolePermissionsInsert = @"
SET IDENTITY_INSERT RolePermissions ON;
INSERT INTO RolePermissions (RolePermissionId, RoleId, PermissionId, PermissionMask) VALUES
(31, 4, 7, 'YYYYNNNN'),      -- Grant CRUD access to Application.Data for applicant role
(32, 4, 10, 'YYYYNNNN')      -- Grant CRUD access to Client.Data for applicant role
SET IDENTITY_INSERT RolePermissions OFF;
";
			migrationBuilder.Sql(rolePermissionsInsert);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder) {
			var rolePermissionsDelete = "DELETE FROM RolePermissions WHERE RolePermissionId IN (31, 32)";
			migrationBuilder.Sql(rolePermissionsDelete);
		}
	}
}
