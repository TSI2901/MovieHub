using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Hub.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    BornCityName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BornCityName = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(221)", maxLength: 221, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieLength = table.Column<int>(type: "int", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StudioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentEssence = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLikes",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLikes", x => new { x.MovieId, x.FollowerId });
                    table.ForeignKey(
                        name: "FK_MovieLikes_AspNetUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLikes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesActors",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MoviesActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesCategories",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCategories", x => new { x.MovieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MoviesCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesCategories_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesDirectors",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesDirectors", x => new { x.MovieId, x.DirectorId });
                    table.ForeignKey(
                        name: "FK_MoviesDirectors_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesDirectors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    
                }
                );

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1dfb8479-a8fa-4d20-9571-8571a9787e1b"), "Action" },
                    { new Guid("1e837fa2-7ec1-4ccc-bac9-8716072c963b"), "Science Fiction" },
                    { new Guid("2709abf3-632f-4e54-8436-1982c33ef457"), "Documentary" },
                    { new Guid("2d2cc4a0-156a-44f8-9da1-e673a5cfc374"), "Comedy" },
                    { new Guid("307e43a3-bb40-4740-a074-7578cb254d1f"), "Fantasy" },
                    { new Guid("3428ab1a-059c-4785-95b6-9d77a5af8b1b"), "Musical" },
                    { new Guid("35dc4850-211b-4b2e-aa18-7d1469f2d0a3"), "Drama" },
                    { new Guid("4fa0f912-25e6-4361-aca7-572d9b812b9d"), "Sports" },
                    { new Guid("558fc1b8-a243-471d-a4c3-eaaa834711e7"), "Western" },
                    { new Guid("6af294e3-3e4e-4e82-8aff-93de2a5e9734"), "Musical Comedy" },
                    { new Guid("812e7f50-b508-4365-9748-c6a24d9b712c"), "Mystery" },
                    { new Guid("89b64294-3d23-40db-80c3-471bd74b58ff"), "Romance" },
                    { new Guid("b956790b-a494-4f97-b491-10dd235472bc"), "Horror" },
                    { new Guid("ba953e98-55bd-44b8-815f-450ef1eee495"), "War" },
                    { new Guid("c6465268-897b-4414-9b80-7e8f2bc18839"), "Adventure" },
                    { new Guid("c83a6268-e094-4af5-a77f-0c99c3f22cca"), "Animation" },
                    { new Guid("e721e79c-3ded-4a8c-abc8-ebfd4fb5b983"), "Historical" },
                    { new Guid("edbee819-ad24-4a37-b525-38112d9c4183"), "Family" },
                    { new Guid("f8acb2e3-c517-470a-816c-0c259186f8f2"), "Thriller" },
                    { new Guid("feab0dd8-6d03-485b-b29d-fe358ff0623f"), "Biographical" }
                });

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "ActorId", "DirectorId", "MovieId", "Title" },
                values: new object[,]
                {
                    { new Guid("1dc14da0-7fec-4feb-914d-9d363787d8dc"), null, null, null, "Golden Globe" },
                    { new Guid("55028d87-12ec-454a-94a6-e298a8674ae8"), null, null, null, "Golden Bear" },
                    { new Guid("6e492e9e-3a3c-4aa3-8dfb-1270a9c3cee9"), null, null, null, "None" },
                    { new Guid("7af8d047-f60e-4c0a-890a-af143715722e"), null, null, null, "BAFTA" },
                    { new Guid("892eae8a-7f22-4faf-b522-b8221d423954"), null, null, null, "Palme d'Or" },
                    { new Guid("b44f2db0-5e75-4f31-9062-13dec59c8ef4"), null, null, null, "Oscar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ActorId",
                table: "Comments",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DirectorId",
                table: "Comments",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLikes_FollowerId",
                table: "MovieLikes",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_StudioId",
                table: "Movies",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActors_ActorId",
                table: "MoviesActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCategories_CategoryId",
                table: "MoviesCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesDirectors_DirectorId",
                table: "MoviesDirectors",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_ActorId",
                table: "Rewards",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_DirectorId",
                table: "Rewards",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_MovieId",
                table: "Rewards",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "MovieLikes");

            migrationBuilder.DropTable(
                name: "MoviesActors");

            migrationBuilder.DropTable(
                name: "MoviesCategories");

            migrationBuilder.DropTable(
                name: "MoviesDirectors");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
