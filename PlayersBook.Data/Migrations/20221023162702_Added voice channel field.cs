using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class Addedvoicechannelfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 22, 10, 56, 22, 125, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(473),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 22, 10, 56, 22, 125, DateTimeKind.Local).AddTicks(4078));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 22, 10, 56, 22, 125, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.AddColumn<bool>(
                name: "VoiceChannel",
                table: "Advertisements",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoiceChannel",
                table: "Advertisements");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 22, 10, 56, 22, 125, DateTimeKind.Local).AddTicks(4230),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 22, 10, 56, 22, 125, DateTimeKind.Local).AddTicks(4078),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 22, 10, 56, 22, 125, DateTimeKind.Local).AddTicks(3712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 23, 13, 27, 2, 75, DateTimeKind.Local).AddTicks(171));
        }
    }
}
