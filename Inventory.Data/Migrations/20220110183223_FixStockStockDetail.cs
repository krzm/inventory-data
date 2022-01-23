using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations
{
    public partial class FixStockStockDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stored",
                table: "StockDetail");

            migrationBuilder.DropColumn(
                name: "Used",
                table: "StockDetail");

            migrationBuilder.AddColumn<DateTime>(
                name: "Open",
                table: "Stock",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Stored",
                table: "Stock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Used",
                table: "Stock",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Open",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Stored",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Used",
                table: "Stock");

            migrationBuilder.AddColumn<DateTime>(
                name: "Stored",
                table: "StockDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Used",
                table: "StockDetail",
                type: "datetime2",
                nullable: true);
        }
    }
}
