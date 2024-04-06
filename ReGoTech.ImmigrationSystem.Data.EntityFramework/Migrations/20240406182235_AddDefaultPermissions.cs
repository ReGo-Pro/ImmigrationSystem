using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var premissionsInsert = @"
SET IDENTITY_INSERT Permissions ON;
INSERT INTO Permissions (PermissionId, Name, Description) VALUES
(1, 'System.Settings', 'Manage system level settings and configurations'),
(2, 'System.Security', 'Manage roles, permissions and other security aspects of the system'),
(3, 'System.Reports', 'Manage system level reports'),
(4, 'Officer.Data', 'Manage immigration officer information'),
(5, 'Officer.Workflows', 'Manage application workflows'),
(6, 'Officer.Reports', 'Manage reports related to immigration officers'),
(7, 'Application.Data', 'Manage client application data'),
(8, 'Application.Workflow', 'Manage application workflows'),
(9, 'Application.Reports', 'Manage reports related to client applications'),
(10, 'Client.Data', 'Manage client data including persnal information and documents'),
(11, 'Client.Operations', 'Manage cleint operations'),
(12, 'Client.Reports', 'Manage reports related to client information');
SET IDENTITY_INSERT Permissions OFF;
";
            migrationBuilder.Sql(premissionsInsert);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var eprmissionsDelete = @"DELETE FROM Permissions WHERE PermissionId IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)";
            migrationBuilder.Sql(eprmissionsDelete);
        }
    }
}
