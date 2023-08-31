using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hootel.Rooms.Migrations
{
    /// <inheritdoc />
    public partial class PeopleNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeopleNumber",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeopleNumber",
                table: "Rooms");
        }
    }
}
