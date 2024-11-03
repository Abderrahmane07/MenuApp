using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuApp.Migrations
{
    /// <inheritdoc />
    public partial class FixTypoInDishModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestauarantId",
                table: "Dishes",
                newName: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Dishes",
                newName: "RestauarantId");
        }
    }
}
