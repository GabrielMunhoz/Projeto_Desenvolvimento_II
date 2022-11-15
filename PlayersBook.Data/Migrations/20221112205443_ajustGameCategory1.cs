using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class ajustGameCategory1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IdTwitch",
                table: "GamesCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 54, 43, 243, DateTimeKind.Local).AddTicks(5728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 54, 43, 243, DateTimeKind.Local).AddTicks(5911),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.AddColumn<int>(
                name: "IdTwitch",
                table: "GamesCategory",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "ChannelStreams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 54, 43, 243, DateTimeKind.Local).AddTicks(5556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(4794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 54, 43, 243, DateTimeKind.Local).AddTicks(5260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesCategory",
                table: "GamesCategory",
                column: "IdTwitch");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GamesCategory",
                table: "GamesCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(5206),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 54, 43, 243, DateTimeKind.Local).AddTicks(5728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(5365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 54, 43, 243, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.AlterColumn<int>(
                name: "IdTwitch",
                table: "GamesCategory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

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
                defaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(4957));

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
                defaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(4794),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 54, 43, 243, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 17, 45, 19, 40, DateTimeKind.Local).AddTicks(4498),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 17, 54, 43, 243, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamesCategory",
                table: "GamesCategory",
                column: "Id");
        }
    }
}
