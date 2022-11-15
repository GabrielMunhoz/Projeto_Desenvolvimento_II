﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayersBook.Data.Context;

#nullable disable

namespace PlayersBook.Data.Migrations
{
    [DbContext(typeof(PlayersBookDBContext))]
    [Migration("20221104231703_Adjust")]
    partial class Adjust
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PlayersBook.Domain.Entities.Advertisement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1329));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpireIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LinkDiscord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerHostId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagHostGame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VoiceChannel")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.AdvertisementPlayers", b =>
                {
                    b.Property<Guid>("advertisementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("advertisementId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("AdvertisementPlayers");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.ChannelStreams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1588));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageProfile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("ChannelStreams");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.GamesCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BoxArtUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("GamesCategory");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(1871));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d0f606a2-622c-46b8-a844-ae0e817b1839"),
                            DateCreate = new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "gabrielmunhoz@playersbook.com",
                            IsDeleted = false,
                            LastName = "Munhoz",
                            Name = "Gabriel",
                            Nickname = "Gmunho",
                            Password = "2E6F9B0D5885B6010F9167787445617F553A735F"
                        });
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.PlayerProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 11, 4, 20, 17, 3, 494, DateTimeKind.Local).AddTicks(2061));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RatingNegative")
                        .HasColumnType("int");

                    b.Property<int>("RatingPositive")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerProfile");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.AdvertisementPlayers", b =>
                {
                    b.HasOne("PlayersBook.Domain.Entities.Player", "Player")
                        .WithMany("Advertisements")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayersBook.Domain.Entities.Advertisement", "Advertisement")
                        .WithMany("Guests")
                        .HasForeignKey("advertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.ChannelStreams", b =>
                {
                    b.HasOne("PlayersBook.Domain.Entities.PlayerProfile", null)
                        .WithMany("ChannelStreams")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.GamesCategory", b =>
                {
                    b.HasOne("PlayersBook.Domain.Entities.PlayerProfile", null)
                        .WithMany("GamesCategoryProfile")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.PlayerProfile", b =>
                {
                    b.HasOne("PlayersBook.Domain.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.Advertisement", b =>
                {
                    b.Navigation("Guests");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.Player", b =>
                {
                    b.Navigation("Advertisements");
                });

            modelBuilder.Entity("PlayersBook.Domain.Entities.PlayerProfile", b =>
                {
                    b.Navigation("ChannelStreams");

                    b.Navigation("GamesCategoryProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
