using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations;

public partial class InitialMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Item",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Item", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ImagePath",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ItemId = table.Column<int>(type: "int", nullable: false),
                Path = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ImagePath", x => x.Id);
                table.ForeignKey(
                    name: "FK_ImagePath_Item_ItemId",
                    column: x => x.ItemId,
                    principalTable: "Item",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ImagePath_ItemId",
            table: "ImagePath",
            column: "ItemId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ImagePath");

        migrationBuilder.DropTable(
            name: "Item");
    }
}