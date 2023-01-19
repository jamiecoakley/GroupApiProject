﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamWater.Data;

#nullable disable

namespace TeamWater.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230119014505_updatedShowReviewEntity")]
    partial class updatedShowReviewEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TeamWater.Data.Entities.EpisodeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumberOfEpisode")
                        .HasColumnType("int");

                    b.Property<string>("SynopsisOfEpisode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleOfEpisode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TvShowEntityId")
                        .HasColumnType("int");

                    b.Property<int>("TvShowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TvShowEntityId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("TeamWater.Data.Entities.EpisodeReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfReview")
                        .HasColumnType("datetime2");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeRating")
                        .HasColumnType("int");

                    b.Property<string>("EpisodeReviewText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EpisodeReviews");
                });

            modelBuilder.Entity("TeamWater.Data.Entities.ShowReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateOfReview")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShowRating")
                        .HasColumnType("int");

                    b.Property<int>("TvShowId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TvShowId");

                    b.ToTable("ShowReviews");
                });

            modelBuilder.Entity("TeamWater.Data.Entities.StreamingPlatformEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlatformType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TvShowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StreamingPlatforms");
                });

            modelBuilder.Entity("TeamWater.Data.Entities.TvShowEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PlatformId")
                        .HasColumnType("int");

                    b.Property<string>("ShowDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShowEpisodes")
                        .HasColumnType("int");

                    b.Property<int>("ShowGenre")
                        .HasColumnType("int");

                    b.Property<string>("ShowTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.HasIndex("UserId");

                    b.ToTable("TvShows");
                });

            modelBuilder.Entity("TeamWater.Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TeamWater.Data.Entities.EpisodeEntity", b =>
                {
                    b.HasOne("TeamWater.Data.Entities.TvShowEntity", null)
                        .WithMany("EpisodeList")
                        .HasForeignKey("TvShowEntityId");
                });

            modelBuilder.Entity("TeamWater.Data.Entities.ShowReviewEntity", b =>
                {
                    b.HasOne("TeamWater.Data.Entities.TvShowEntity", "TvShow")
                        .WithMany("ShowReviewList")
                        .HasForeignKey("TvShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TvShow");
                });

            modelBuilder.Entity("TeamWater.Data.Entities.TvShowEntity", b =>
                {
                    b.HasOne("TeamWater.Data.Entities.StreamingPlatformEntity", "WhereToStream")
                        .WithMany()
                        .HasForeignKey("PlatformId");

                    b.HasOne("TeamWater.Data.Entities.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("WhereToStream");
                });

            modelBuilder.Entity("TeamWater.Data.Entities.TvShowEntity", b =>
                {
                    b.Navigation("EpisodeList");

                    b.Navigation("ShowReviewList");
                });
#pragma warning restore 612, 618
        }
    }
}
