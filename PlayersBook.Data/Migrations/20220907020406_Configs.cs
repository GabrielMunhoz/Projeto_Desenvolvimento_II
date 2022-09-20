using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class Configs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Players_HostId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Advertisements_AdvertisementId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Players_PlayerId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_PlayerId",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Advertisements",
                newName: "Advertisement");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_HostId",
                table: "Advertisement",
                newName: "IX_Advertisement_HostId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profiles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(2011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(1757),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Advertisement",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(1326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisement",
                table: "Advertisement",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AdvertisementId", "DateCreate", "DateUpdated", "Email", "LastName", "Name", "NickName", "Password" },
                values: new object[] { new Guid("d0f606a2-622c-46b8-a844-ae0e817b1839"), null, new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "gabrielmunhoz@playersbook.com", "Munhoz", "Gabriel", "Gmunho", "teste" });

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Players_HostId",
                table: "Advertisement",
                column: "HostId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Advertisement_AdvertisementId",
                table: "Players",
                column: "AdvertisementId",
                principalTable: "Advertisement",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Players_HostId",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Advertisement_AdvertisementId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisement",
                table: "Advertisement");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("d0f606a2-622c-46b8-a844-ae0e817b1839"));

            migrationBuilder.RenameTable(
                name: "Advertisement",
                newName: "Advertisements");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_HostId",
                table: "Advertisements",
                newName: "IX_Advertisements_HostId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Profiles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Players",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(1757));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Advertisements",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 6, 23, 4, 6, 167, DateTimeKind.Local).AddTicks(1326));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PlayerId",
                table: "Profiles",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Players_HostId",
                table: "Advertisements",
                column: "HostId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Advertisements_AdvertisementId",
                table: "Players",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Players_PlayerId",
                table: "Profiles",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
