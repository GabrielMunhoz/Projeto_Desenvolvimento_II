using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class Configs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(7158),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(6972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(1757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(6621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(1326));

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PlayerId",
                table: "Profiles",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Players_PlayerId",
                table: "Profiles",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Players_PlayerId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_PlayerId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Profiles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(2011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(1757),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(1326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(6621));
        }
    }
}
