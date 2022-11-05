using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PlayerHostId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 9, 23, 18, 39, 48, 958, DateTimeKind.Local).AddTicks(3229)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 9, 23, 18, 39, 48, 958, DateTimeKind.Local).AddTicks(3520)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementPlayers",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    advertisementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementPlayers", x => new { x.advertisementId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_AdvertisementPlayers_Advertisements_advertisementId",
                        column: x => x.advertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RatingPositive = table.Column<int>(type: "int", nullable: false),
                    RatingNegative = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 9, 23, 18, 39, 48, 958, DateTimeKind.Local).AddTicks(3653)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamesCategory_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "PlayerProfile",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "DateCreate", "DateUpdated", "Email", "LastName", "Name", "Nickname", "Password" },
                values: new object[] { new Guid("d0f606a2-622c-46b8-a844-ae0e817b1839"), new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "gabrielmunhoz@playersbook.com", "Munhoz", "Gabriel", "Gmunho", "teste" });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementPlayers_PlayerId",
                table: "AdvertisementPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesCategory_ProfileId",
                table: "GamesCategory",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesTags_ProfileId",
                table: "GamesTags",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PlayerId",
                table: "PlayerProfile",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementPlayers");

            migrationBuilder.DropTable(
                name: "GamesCategory");

            migrationBuilder.DropTable(
                name: "GamesTags");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "PlayerProfile");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
