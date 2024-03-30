using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAdminUser : Migration
    {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder) {
			// This is just for demo, we never insert data like this into codebase and check into repository
			// username = Admin
			// Password = P@ssW0rd
			migrationBuilder.Sql(@"
                BEGIN TRANSACTION; 
                SET IDENTITY_INSERT Clients ON;
                INSERT INTO Clients (ClientId, Uid, Type, FirstName, LastName) VALUES (1, 'ReGoAdmin', 0, 'Reza', 'Ghochkhani');
                SET IDENTITY_INSERT Clients OFF;                  
                SET IDENTITY_INSERT ClientLogins ON;
                INSERT INTO ClientLogins(ClientLoginId, Username, Email, PasswordHash, IsLockedOut, IsEmailVerified, ClientId, EmailVerificationCode) Values (1, 'Admin', 'admin@regotech.net', '$2a$11$ds8mKk405cxRBENafoFyFe2yMEPFnb0Vw75JzXXShTLDwBm6gBdzS', 0, 1, 1, 'VerificationNotRequired');
                SET IDENTITY_INSERT ClientLogins OFF;
                COMMIT; 
            ");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.Sql("DELETE FROM ClientLogins WHERE ClientLoginId = 1");
			migrationBuilder.Sql("DELETE FROM Clients WHERE ClientLoginId = 1");
		}
	}
}
