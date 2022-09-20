using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    public partial class Firstmigration : Migration
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
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertisementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingPositive = table.Column<int>(type: "int", nullable: false),
                    RatingNegative = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                        principalTable: "Profiles",
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
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_HostId",
                table: "Advertisements",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesCategory_ProfileId",
                table: "GamesCategory",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesTags_ProfileId",
                table: "GamesTags",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AdvertisementId",
                table: "Players",
                column: "AdvertisementId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Players_HostId",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "GamesCategory");

            migrationBuilder.DropTable(
                name: "GamesTags");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Advertisements");
        }
    }
}
