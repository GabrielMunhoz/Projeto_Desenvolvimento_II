using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class ChangedIdGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesCategory",
                table: "GamesCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 18, 15, 41, 296, DateTimeKind.Local).AddTicks(4353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 18, 11, 0, 402, DateTimeKind.Local).AddTicks(4748));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 18, 15, 41, 296, DateTimeKind.Local).AddTicks(4485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 18, 11, 0, 402, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.DropColumn(
            name: "IdTwitch",
            table: "GamesCategory");

            migrationBuilder.AddColumn<int>(
                name: "IdTwitch",
                table: "GamesCategory",
                type: "int",
                nullable: false);
                

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "GamesCategory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "GamesCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 18, 15, 41, 296, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "GamesCategory",
                type: "datetime2",
                nullable: true);

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
                defaultValue: new DateTime(2022, 11, 12, 18, 15, 41, 296, DateTimeKind.Local).AddTicks(4004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 18, 11, 0, 402, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 18, 15, 41, 296, DateTimeKind.Local).AddTicks(3705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 18, 11, 0, 402, DateTimeKind.Local).AddTicks(4232));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesCategory",
                table: "GamesCategory",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesCategory",
                table: "GamesCategory");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GamesCategory");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "GamesCategory");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "GamesCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GamesCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 18, 11, 0, 402, DateTimeKind.Local).AddTicks(4748),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 18, 15, 41, 296, DateTimeKind.Local).AddTicks(4353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 18, 11, 0, 402, DateTimeKind.Local).AddTicks(4922),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 18, 15, 41, 296, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.AlterColumn<int>(
                name: "IdTwitch",
                table: "GamesCategory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "ChannelStreams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 18, 11, 0, 402, DateTimeKind.Local).AddTicks(4567),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 18, 15, 41, 296, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 18, 11, 0, 402, DateTimeKind.Local).AddTicks(4232),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 18, 15, 41, 296, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesCategory",
                table: "GamesCategory",
                column: "IdTwitch");
        }
    }
}
