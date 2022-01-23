using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations
{
    public partial class ItemDetailAddDiameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Diameter",
                table: "ItemDetail",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diameter",
                table: "ItemDetail");
        }
    }
}
