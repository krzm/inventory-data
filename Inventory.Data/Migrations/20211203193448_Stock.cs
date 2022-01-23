using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations;

public partial class Stock : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ImagePath");

        migrationBuilder.DropColumn(
            name: "Description",
            table: "Item");

        migrationBuilder.AddColumn<int>(
            name: "ItemDetailId",
            table: "Item",
            type: "int",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "ItemDetail",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                Width = table.Column<int>(type: "int", nullable: false),
                Depth = table.Column<int>(type: "int", nullable: false),
                Heigth = table.Column<int>(type: "int", nullable: false),
                Volume = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ItemDetail", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ItemImage",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ItemId = table.Column<int>(type: "int", nullable: false),
                Path = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ItemImage", x => x.Id);
                table.ForeignKey(
                    name: "FK_ItemImage_Item_ItemId",
                    column: x => x.ItemId,
                    principalTable: "Item",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "StockDetail",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                Stored = table.Column<DateTime>(type: "datetime2", nullable: false),
                Used = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StockDetail", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Stock",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ItemId = table.Column<int>(type: "int", nullable: false),
                ContainerId = table.Column<int>(type: "int", nullable: false),
                StockDetailId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Stock", x => x.Id);
                table.ForeignKey(
                    name: "FK_Stock_Item_ContainerId",
                    column: x => x.ContainerId,
                    principalTable: "Item",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Stock_Item_ItemId",
                    column: x => x.ItemId,
                    principalTable: "Item",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Stock_StockDetail_StockDetailId",
                    column: x => x.StockDetailId,
                    principalTable: "StockDetail",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Item_ItemDetailId",
            table: "Item",
            column: "ItemDetailId");

        migrationBuilder.CreateIndex(
            name: "IX_ItemImage_ItemId",
            table: "ItemImage",
            column: "ItemId");

        migrationBuilder.CreateIndex(
            name: "IX_Stock_ContainerId",
            table: "Stock",
            column: "ContainerId");

        migrationBuilder.CreateIndex(
            name: "IX_Stock_ItemId",
            table: "Stock",
            column: "ItemId");

        migrationBuilder.CreateIndex(
            name: "IX_Stock_StockDetailId",
            table: "Stock",
            column: "StockDetailId");

        migrationBuilder.AddForeignKey(
            name: "FK_Item_ItemDetail_ItemDetailId",
            table: "Item",
            column: "ItemDetailId",
            principalTable: "ItemDetail",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Item_ItemDetail_ItemDetailId",
            table: "Item");

        migrationBuilder.DropTable(
            name: "ItemDetail");

        migrationBuilder.DropTable(
            name: "ItemImage");

        migrationBuilder.DropTable(
            name: "Stock");

        migrationBuilder.DropTable(
            name: "StockDetail");

        migrationBuilder.DropIndex(
            name: "IX_Item_ItemDetailId",
            table: "Item");

        migrationBuilder.DropColumn(
            name: "ItemDetailId",
            table: "Item");

        migrationBuilder.AddColumn<string>(
            name: "Description",
            table: "Item",
            type: "nvarchar(70)",
            maxLength: 70,
            nullable: false,
            defaultValue: "");

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
}