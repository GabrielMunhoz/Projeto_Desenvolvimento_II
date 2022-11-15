using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class ajustGameCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(5206),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 6, 15, 54, 45, 980, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(5365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 6, 15, 54, 45, 980, DateTimeKind.Local).AddTicks(9995));


            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "GamesCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "GamesCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTwitch",
                table: "GamesCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GamesCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "ChannelStreams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(4794),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 6, 15, 54, 45, 980, DateTimeKind.Local).AddTicks(9562));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(4498),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 6, 15, 54, 45, 980, DateTimeKind.Local).AddTicks(9248));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "GamesCategory");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "GamesCategory");

            migrationBuilder.DropColumn(
                name: "IdTwitch",
                table: "GamesCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 6, 15, 54, 45, 980, DateTimeKind.Local).AddTicks(9851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 6, 15, 54, 45, 980, DateTimeKind.Local).AddTicks(9995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GamesCategory",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "ChannelStreams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 6, 15, 54, 45, 980, DateTimeKind.Local).AddTicks(9562),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(4794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 6, 15, 54, 45, 980, DateTimeKind.Local).AddTicks(9248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(4498));
        }
    }
}
