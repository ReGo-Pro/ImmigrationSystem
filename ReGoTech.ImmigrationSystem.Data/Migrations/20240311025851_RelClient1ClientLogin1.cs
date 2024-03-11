using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelClient1ClientLogin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "ClientLogins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientLogins_ClientId",
                table: "ClientLogins",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientLogins_Clients_ClientId",
                table: "ClientLogins",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientLogins_Clients_ClientId",
                table: "ClientLogins");

            migrationBuilder.DropIndex(
                name: "IX_ClientLogins_ClientId",
                table: "ClientLogins");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ClientLogins");
        }
    }
}
