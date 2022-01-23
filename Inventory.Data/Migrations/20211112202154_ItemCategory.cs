using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations;

public partial class ItemCategory : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Item_Category_CategoryId",
            table: "Item");

        migrationBuilder.DropTable(
            name: "Category");

        migrationBuilder.CreateTable(
            name: "ItemCategory",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                Description = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                ParentId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ItemCategory", x => x.Id);
                table.ForeignKey(
                    name: "FK_ItemCategory_ItemCategory_ParentId",
                    column: x => x.ParentId,
                    principalTable: "ItemCategory",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ItemCategory_ParentId",
            table: "ItemCategory",
            column: "ParentId");

        migrationBuilder.AddForeignKey(
            name: "FK_Item_ItemCategory_CategoryId",
            table: "Item",
            column: "CategoryId",
            principalTable: "ItemCategory",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Item_ItemCategory_CategoryId",
            table: "Item");

        migrationBuilder.DropTable(
            name: "ItemCategory");

        migrationBuilder.CreateTable(
            name: "Category",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Description = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Category", x => x.Id);
            });

        migrationBuilder.AddForeignKey(
            name: "FK_Item_Category_CategoryId",
            table: "Item",
            column: "CategoryId",
            principalTable: "Category",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}