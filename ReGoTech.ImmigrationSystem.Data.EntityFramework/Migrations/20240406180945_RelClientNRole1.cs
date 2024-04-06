using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelClientNRole1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_RoleId",
                table: "Clients",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Roles_RoleId",
                table: "Clients",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Roles_RoleId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_RoleId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Clients");
        }
    }
}
