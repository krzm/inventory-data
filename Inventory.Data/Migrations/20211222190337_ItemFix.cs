using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations
{
    public partial class ItemFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_ItemCategory_CategoryId",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Item",
                newName: "ItemCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                newName: "IX_Item_ItemCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ItemCategory_ItemCategoryId",
                table: "Item",
                column: "ItemCategoryId",
                principalTable: "ItemCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_ItemCategory_ItemCategoryId",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "ItemCategoryId",
                table: "Item",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ItemCategoryId",
                table: "Item",
                newName: "IX_Item_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ItemCategory_CategoryId",
                table: "Item",
                column: "CategoryId",
                principalTable: "ItemCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
