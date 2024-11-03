using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDishModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestauarantId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestauarantId",
                table: "Dishes");
        }
    }
}
