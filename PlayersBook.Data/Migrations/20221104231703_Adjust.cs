using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class Adjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(2061),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1871),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "ChannelStreams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1588),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1329),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4385));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(5186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(2061));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "ChannelStreams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4680),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1329));
        }
    }
}
