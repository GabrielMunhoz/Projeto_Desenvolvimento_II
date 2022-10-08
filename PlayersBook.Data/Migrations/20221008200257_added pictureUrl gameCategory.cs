using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class addedpictureUrlgameCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 8, 17, 2, 57, 33, DateTimeKind.Local).AddTicks(4516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 23, 18, 39, 48, 958, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 8, 17, 2, 57, 33, DateTimeKind.Local).AddTicks(4369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 23, 18, 39, 48, 958, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.AddColumn<string>(
                name: "BoxArtUrl",
                table: "GamesCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 8, 17, 2, 57, 33, DateTimeKind.Local).AddTicks(4074),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 23, 18, 39, 48, 958, DateTimeKind.Local).AddTicks(3229));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d0f606a2-622c-46b8-a844-ae0e817b1839"),
                column: "Password",
                value: "2E6F9B0D5885B6010F9167787445617F553A735F");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxArtUrl",
                table: "GamesCategory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 23, 18, 39, 48, 958, DateTimeKind.Local).AddTicks(3653),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 8, 17, 2, 57, 33, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 23, 18, 39, 48, 958, DateTimeKind.Local).AddTicks(3520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 8, 17, 2, 57, 33, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 23, 18, 39, 48, 958, DateTimeKind.Local).AddTicks(3229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 8, 17, 2, 57, 33, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d0f606a2-622c-46b8-a844-ae0e817b1839"),
                column: "Password",
                value: "teste");
        }
    }
}
