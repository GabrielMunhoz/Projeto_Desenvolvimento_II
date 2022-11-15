using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class addedExpireDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(7099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6968),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireIn",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6578),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(171));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(473),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireIn",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6578));
        }
    }
}
