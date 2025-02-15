using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamefiyAPI.Migrations
{
    /// <inheritdoc />
    public partial class changedCategoryToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categories",
                table: "Games",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Games",
                newName: "Categories");
        }
    }
}
