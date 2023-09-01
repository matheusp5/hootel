using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hootel.Reservations.Migrations
{
    /// <inheritdoc />
    public partial class ChekInToCheckIn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChekIn",
                table: "Reservations",
                newName: "CheckIn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "Reservations",
                newName: "ChekIn");
        }
    }
}
