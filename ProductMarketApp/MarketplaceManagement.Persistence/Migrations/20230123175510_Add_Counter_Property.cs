using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketplaceManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCounterProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Counter",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Counter",
                table: "Products");
        }
    }
}
