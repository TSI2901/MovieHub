using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Hub.Data.Migrations
{
    public partial class InitialCreate : Migration
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
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(221)", maxLength: 221, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieLength = table.Column<int>(type: "int", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
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
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rewards_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rewards_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("034cf6e7-d0c6-4869-9c1b-103b63be67a4"), "Historical" },
                    { new Guid("08501d88-400e-4b5c-bddd-bac83f91b38e"), "Action" },
                    { new Guid("1086223a-370f-407e-b92c-93cedfc9dcdb"), "Documentary" },
                    { new Guid("10cdddf5-fbb6-44dc-9495-be3bd8957d51"), "Romance" },
                    { new Guid("2142bf2a-cdd7-4843-b8f9-c7edc1a79c4c"), "War" },
                    { new Guid("2b09b4de-1fd0-441f-ba7b-f9bd4744a362"), "Family" },
                    { new Guid("2ffd814b-db12-419b-8d8b-f294caec3edf"), "Thriller" },
                    { new Guid("392ebcf8-55d3-422e-8eac-b427aec190a3"), "Musical" },
                    { new Guid("41a94db3-fdc2-4951-aa7a-e26870c6ff4b"), "Adventure" },
                    { new Guid("4dc0dd78-9781-40df-a128-2ef187bb89fe"), "Mystery" },
                    { new Guid("4e424ba7-e296-4ea6-88bd-4a183c924a4a"), "Drama" },
                    { new Guid("59c08c10-9d23-4108-949a-08393a28a232"), "Animation" },
                    { new Guid("869b471b-6653-4d40-873e-5dbc2cbbd87d"), "Fantasy" },
                    { new Guid("882ea7a4-2f75-493c-b7dd-ba5b62120892"), "Horror" },
                    { new Guid("9cbe1256-457c-4f9e-92c0-ee2756ee0822"), "Western" },
                    { new Guid("bc83edb7-3818-485d-8faf-1a71df4276f1"), "Biographical" },
                    { new Guid("cd7ff128-5564-46bb-9d61-2479fbbee7dc"), "Musical Comedy" },
                    { new Guid("cd9271ad-c284-400e-a9cd-439b0bb8c259"), "Science Fiction" },
                    { new Guid("eed318fa-9c5f-493c-9a4e-e3431ae8a574"), "Sports" },
                    { new Guid("f8c3ff99-9b61-4541-8e9c-4916840c5aa5"), "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "ActorId", "DirectorId", "MovieId", "Title" },
                values: new object[,]
                {
                    { new Guid("008e1821-5238-471a-b152-c34752667202"), null, null, null, "Golden Globe" },
                    { new Guid("3799001d-1e62-45e9-a51f-74fe21d357db"), null, null, null, "BAFTA" },
                    { new Guid("5f793f10-43ea-4ced-8953-64a443469ae4"), null, null, null, "Palme d'Or" },
                    { new Guid("fd120e6b-5a2b-496d-a28c-d2ea21dc444d"), null, null, null, "Oscar" },
                    { new Guid("ffeaa387-0520-491a-aca7-0edbf896bce9"), null, null, null, "Golden Bear" }
                });

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
                name: "MoviesActors");

            migrationBuilder.DropTable(
                name: "MoviesCategories");

            migrationBuilder.DropTable(
                name: "MoviesDirectors");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
