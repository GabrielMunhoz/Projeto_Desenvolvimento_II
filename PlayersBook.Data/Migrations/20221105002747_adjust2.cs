using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class adjust2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 27, 47, 573, DateTimeKind.Local).AddTicks(4896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 27, 47, 573, DateTimeKind.Local).AddTicks(5080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "ChannelStreams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 27, 47, 573, DateTimeKind.Local).AddTicks(4619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 27, 47, 573, DateTimeKind.Local).AddTicks(4274),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(8726));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9466),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 27, 47, 573, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 27, 47, 573, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "ChannelStreams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 27, 47, 573, DateTimeKind.Local).AddTicks(4619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(8726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 27, 47, 573, DateTimeKind.Local).AddTicks(4274));
        }
    }
}
