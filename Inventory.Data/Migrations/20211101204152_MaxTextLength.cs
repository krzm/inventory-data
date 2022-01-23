using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Data.Migrations;

public partial class MaxTextLength : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Item",
            type: "nvarchar(25)",
            maxLength: 25,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(50)",
            oldMaxLength: 50);

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "Item",
            type: "nvarchar(70)",
            maxLength: 70,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(250)",
            oldMaxLength: 250);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Category",
            type: "nvarchar(25)",
            maxLength: 25,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(50)",
            oldMaxLength: 50);

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "Category",
            type: "nvarchar(70)",
            maxLength: 70,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(250)",
            oldMaxLength: 250);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Item",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(25)",
            oldMaxLength: 25);

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "Item",
            type: "nvarchar(250)",
            maxLength: 250,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(70)",
            oldMaxLength: 70);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Category",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(25)",
            oldMaxLength: 25);

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "Category",
            type: "nvarchar(250)",
            maxLength: 250,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(70)",
            oldMaxLength: 70);
    }
}