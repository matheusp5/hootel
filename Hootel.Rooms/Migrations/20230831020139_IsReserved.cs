using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hootel.Rooms.Migrations
{
    /// <inheritdoc />
    public partial class IsReserved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isReserved",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isReserved",
                table: "Rooms");
        }
    }
}
