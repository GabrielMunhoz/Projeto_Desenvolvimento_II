using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class AddedchannelStreams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamesTags");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(5186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "PlayerProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireIn",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6578));

            migrationBuilder.CreateTable(
                name: "ChannelStreams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4680)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelStreams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelStreams_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "PlayerProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelStreams_ProfileId",
                table: "ChannelStreams",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChannelStreams");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "PlayerProfile");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "PlayerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(7099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6968),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireIn",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 24, 19, 21, 2, 135, DateTimeKind.Local).AddTicks(6578),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 4, 20, 12, 38, 643, DateTimeKind.Local).AddTicks(4385));

            migrationBuilder.CreateTable(
                name: "GamesTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamesTags_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "PlayerProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamesTags_ProfileId",
                table: "GamesTags",
                column: "ProfileId");
        }
    }
}
