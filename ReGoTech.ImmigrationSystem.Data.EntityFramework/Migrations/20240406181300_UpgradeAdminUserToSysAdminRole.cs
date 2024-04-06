using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeAdminUserToSysAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var adminUpdate = "UPDATE Clients SET RoleId = 1 WHERE ClientId = 1";
            migrationBuilder.Sql(adminUpdate);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			var adminUpdate = "UPDATE Clients SET RoleId = 5 WHERE ClientId = 1"; // least privileged role
			migrationBuilder.Sql(adminUpdate);
		}
    }
}
