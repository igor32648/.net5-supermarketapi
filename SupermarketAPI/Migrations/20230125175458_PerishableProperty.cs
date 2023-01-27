using Microsoft.EntityFrameworkCore.Migrations;

namespace SupermarketAPI.Migrations
{
    public partial class PerishableProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Perishable",
                table: "Products",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perishable",
                table: "Products");
        }
    }
}
