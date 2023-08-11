﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieHub.Data;

#nullable disable

namespace Movie_Hub.Data.Migrations
{
    [DbContext(typeof(MovieHubDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MovieHub.Data.Models.Actor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BornCityName")
                        .IsRequired()
                        .HasMaxLength(58)
                        .HasColumnType("nvarchar(58)");

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImgURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MovieHub.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1dfb8479-a8fa-4d20-9571-8571a9787e1b"),
                            Name = "Action"
                        },
                        new
                        {
                            Id = new Guid("2d2cc4a0-156a-44f8-9da1-e673a5cfc374"),
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = new Guid("c6465268-897b-4414-9b80-7e8f2bc18839"),
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = new Guid("35dc4850-211b-4b2e-aa18-7d1469f2d0a3"),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = new Guid("89b64294-3d23-40db-80c3-471bd74b58ff"),
                            Name = "Romance"
                        },
                        new
                        {
                            Id = new Guid("b956790b-a494-4f97-b491-10dd235472bc"),
                            Name = "Horror"
                        },
                        new
                        {
                            Id = new Guid("f8acb2e3-c517-470a-816c-0c259186f8f2"),
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = new Guid("1e837fa2-7ec1-4ccc-bac9-8716072c963b"),
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = new Guid("307e43a3-bb40-4740-a074-7578cb254d1f"),
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = new Guid("c83a6268-e094-4af5-a77f-0c99c3f22cca"),
                            Name = "Animation"
                        },
                        new
                        {
                            Id = new Guid("edbee819-ad24-4a37-b525-38112d9c4183"),
                            Name = "Family"
                        },
                        new
                        {
                            Id = new Guid("3428ab1a-059c-4785-95b6-9d77a5af8b1b"),
                            Name = "Musical"
                        },
                        new
                        {
                            Id = new Guid("e721e79c-3ded-4a8c-abc8-ebfd4fb5b983"),
                            Name = "Historical"
                        },
                        new
                        {
                            Id = new Guid("ba953e98-55bd-44b8-815f-450ef1eee495"),
                            Name = "War"
                        },
                        new
                        {
                            Id = new Guid("558fc1b8-a243-471d-a4c3-eaaa834711e7"),
                            Name = "Western"
                        },
                        new
                        {
                            Id = new Guid("812e7f50-b508-4365-9748-c6a24d9b712c"),
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = new Guid("2709abf3-632f-4e54-8436-1982c33ef457"),
                            Name = "Documentary"
                        },
                        new
                        {
                            Id = new Guid("4fa0f912-25e6-4361-aca7-572d9b812b9d"),
                            Name = "Sports"
                        },
                        new
                        {
                            Id = new Guid("feab0dd8-6d03-485b-b29d-fe358ff0623f"),
                            Name = "Biographical"
                        },
                        new
                        {
                            Id = new Guid("6af294e3-3e4e-4e82-8aff-93de2a5e9734"),
                            Name = "Musical Comedy"
                        });
                });

            modelBuilder.Entity("MovieHub.Data.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CommentEssence")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid?>("DirectorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("MovieId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MovieHub.Data.Models.Director", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BornCityName")
                        .IsRequired()
                        .HasMaxLength(58)
                        .HasColumnType("nvarchar(58)");

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImgURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("MovieHub.Data.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImgURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieLength")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StudioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(221)
                        .HasColumnType("nvarchar(221)");

                    b.HasKey("Id");

                    b.HasIndex("StudioId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieHub.Data.Models.MovieActor", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("MoviesActors");
                });

            modelBuilder.Entity("MovieHub.Data.Models.MovieCategory", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MovieId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("MoviesCategories");
                });

            modelBuilder.Entity("MovieHub.Data.Models.MovieDirector", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MovieId", "DirectorId");

                    b.HasIndex("DirectorId");

                    b.ToTable("MoviesDirectors");
                });

            modelBuilder.Entity("MovieHub.Data.Models.MovieLike", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FollowerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MovieId", "FollowerId");

                    b.HasIndex("FollowerId");

                    b.ToTable("MovieLikes");
                });

            modelBuilder.Entity("MovieHub.Data.Models.Reward", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DirectorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("MovieId");

                    b.ToTable("Rewards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b44f2db0-5e75-4f31-9062-13dec59c8ef4"),
                            Title = "Oscar"
                        },
                        new
                        {
                            Id = new Guid("6e492e9e-3a3c-4aa3-8dfb-1270a9c3cee9"),
                            Title = "None"
                        },
                        new
                        {
                            Id = new Guid("1dc14da0-7fec-4feb-914d-9d363787d8dc"),
                            Title = "Golden Globe"
                        },
                        new
                        {
                            Id = new Guid("7af8d047-f60e-4c0a-890a-af143715722e"),
                            Title = "BAFTA"
                        },
                        new
                        {
                            Id = new Guid("892eae8a-7f22-4faf-b522-b8221d423954"),
                            Title = "Palme d'Or"
                        },
                        new
                        {
                            Id = new Guid("55028d87-12ec-454a-94a6-e298a8674ae8"),
                            Title = "Golden Bear"
                        });
                });

            modelBuilder.Entity("MovieHub.Data.Models.Studio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieHub.Data.Models.Comment", b =>
                {
                    b.HasOne("MovieHub.Data.Models.Actor", null)
                        .WithMany("Comments")
                        .HasForeignKey("ActorId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieHub.Data.Models.Director", null)
                        .WithMany("Comments")
                        .HasForeignKey("DirectorId");

                    b.HasOne("MovieHub.Data.Models.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieHub.Data.Models.Movie", b =>
                {
                    b.HasOne("MovieHub.Data.Models.Studio", "MovieStudio")
                        .WithMany()
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieStudio");
                });

            modelBuilder.Entity("MovieHub.Data.Models.MovieActor", b =>
                {
                    b.HasOne("MovieHub.Data.Models.Actor", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieHub.Data.Models.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieHub.Data.Models.MovieCategory", b =>
                {
                    b.HasOne("MovieHub.Data.Models.Category", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieHub.Data.Models.Movie", "Movie")
                        .WithMany("Categories")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieHub.Data.Models.MovieDirector", b =>
                {
                    b.HasOne("MovieHub.Data.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieHub.Data.Models.Movie", "Movie")
                        .WithMany("MovieDirectors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieHub.Data.Models.MovieLike", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Follower")
                        .WithMany()
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieHub.Data.Models.Movie", "Movie")
                        .WithMany("MovieLikes")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieHub.Data.Models.Reward", b =>
                {
                    b.HasOne("MovieHub.Data.Models.Actor", null)
                        .WithMany("Rewards")
                        .HasForeignKey("ActorId");

                    b.HasOne("MovieHub.Data.Models.Director", null)
                        .WithMany("Rewards")
                        .HasForeignKey("DirectorId");

                    b.HasOne("MovieHub.Data.Models.Movie", null)
                        .WithMany("Rewards")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("MovieHub.Data.Models.Actor", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Movies");

                    b.Navigation("Rewards");
                });

            modelBuilder.Entity("MovieHub.Data.Models.Category", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieHub.Data.Models.Director", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Movies");

                    b.Navigation("Rewards");
                });

            modelBuilder.Entity("MovieHub.Data.Models.Movie", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Comments");

                    b.Navigation("MovieActors");

                    b.Navigation("MovieDirectors");

                    b.Navigation("MovieLikes");

                    b.Navigation("Rewards");
                });
#pragma warning restore 612, 618
        }
    }
}
