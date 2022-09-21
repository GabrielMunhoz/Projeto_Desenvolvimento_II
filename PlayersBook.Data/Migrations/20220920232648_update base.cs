using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class updatebase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "Players",
                newName: "Nickname");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 20, 20, 26, 48, 543, DateTimeKind.Local).AddTicks(3758),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 20, 20, 26, 48, 543, DateTimeKind.Local).AddTicks(3575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 20, 20, 26, 48, 543, DateTimeKind.Local).AddTicks(3239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(6621));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Players",
                newName: "NickName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(7158),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 20, 20, 26, 48, 543, DateTimeKind.Local).AddTicks(3758));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(6972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 20, 20, 26, 48, 543, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 26, 29, 208, DateTimeKind.Local).AddTicks(6621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 20, 20, 26, 48, 543, DateTimeKind.Local).AddTicks(3239));
        }
    }
}
