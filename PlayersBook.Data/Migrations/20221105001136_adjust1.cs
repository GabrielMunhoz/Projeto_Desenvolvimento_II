using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class adjust1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelStreams_Profiles_ProfileId",
                table: "ChannelStreams");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesCategory_Profiles_ProfileId",
                table: "GamesCategory");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "GamesCategory",
                newName: "PlayerProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_GamesCategory_ProfileId",
                table: "GamesCategory",
                newName: "IX_GamesCategory_PlayerProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "ChannelStreams",
                newName: "PlayerProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ChannelStreams_ProfileId",
                table: "ChannelStreams",
                newName: "IX_ChannelStreams_PlayerProfileId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(2061));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9466),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "ChannelStreams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(8726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelStreams_Profiles_PlayerProfileId",
                table: "ChannelStreams",
                column: "PlayerProfileId",
                principalTable: "PlayerProfile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesCategory_Profiles_PlayerProfileId",
                table: "GamesCategory",
                column: "PlayerProfileId",
                principalTable: "PlayerProfile",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelStreams_Profiles_PlayerProfileId",
                table: "ChannelStreams");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesCategory_Profiles_PlayerProfileId",
                table: "GamesCategory");

            migrationBuilder.RenameColumn(
                name: "PlayerProfileId",
                table: "GamesCategory",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_GamesCategory_PlayerProfileId",
                table: "GamesCategory",
                newName: "IX_GamesCategory_ProfileId");

            migrationBuilder.RenameColumn(
                name: "PlayerProfileId",
                table: "ChannelStreams",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ChannelStreams_PlayerProfileId",
                table: "ChannelStreams",
                newName: "IX_ChannelStreams_ProfileId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(2061),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1871),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "ChannelStreams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1588),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(9159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1329),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 21, 11, 35, 827, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelStreams_Profiles_ProfileId",
                table: "ChannelStreams",
                column: "ProfileId",
                principalTable: "PlayerProfile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesCategory_Profiles_ProfileId",
                table: "GamesCategory",
                column: "ProfileId",
                principalTable: "PlayerProfile",
                principalColumn: "Id");
        }
    }
}
