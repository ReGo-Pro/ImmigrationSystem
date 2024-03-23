using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReGoTech.ImmigrationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVerificationColumnsToClientLoginTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastVerificationSentTime",
                table: "ClientLogins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "VerificationResendRequestCount",
                table: "ClientLogins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VerificationSentFailCount",
                table: "ClientLogins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastVerificationSentTime",
                table: "ClientLogins");

            migrationBuilder.DropColumn(
                name: "VerificationResendRequestCount",
                table: "ClientLogins");

            migrationBuilder.DropColumn(
                name: "VerificationSentFailCount",
                table: "ClientLogins");
        }
    }
}
