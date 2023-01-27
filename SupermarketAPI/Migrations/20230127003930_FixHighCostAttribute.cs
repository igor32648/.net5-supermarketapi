using Microsoft.EntityFrameworkCore.Migrations;

namespace SupermarketAPI.Migrations
{
    public partial class FixHighCostAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HighCost",
                table: "Brands",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(30)",
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "HighCost",
                table: "Brands",
                type: "tinyint(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }
    }
}
