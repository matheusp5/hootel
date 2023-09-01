using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hootel.Reservations.Migrations
{
    /// <inheritdoc />
    public partial class ClientFieldsReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Applicationuser",
                table: "Reservations",
                newName: "ApplicationUser");

            migrationBuilder.AddColumn<string>(
                name: "ClientAddress",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientCity",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientState",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientAddress",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientCity",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientState",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "Reservations",
                newName: "Applicationuser");
        }
    }
}
