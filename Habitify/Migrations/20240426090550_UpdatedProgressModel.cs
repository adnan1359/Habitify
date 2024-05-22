using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habitify.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProgressModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HabitIdentity",
                table: "UserProgress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HabitIdentity",
                table: "UserProgress");
        }
    }
}
