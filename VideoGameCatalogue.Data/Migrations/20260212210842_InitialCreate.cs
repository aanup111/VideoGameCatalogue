using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 

namespace VideoGameCatalogue.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGames", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "Description", "Genre", "Platform", "Price", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "A free-to-play tactical shooter developed by Riot Games.", "First-Person Shooter", "PC", 0.00m, 8.5, new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valorant" },
                    { 2, null, "MOBA", "PC", 0.00m, 8.0, new DateTime(2009, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "League of Legends" },
                    { 3, "A turn-based RPG inspired by French art and culture.", "RPG", "PC", 49.99m, 9.0, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clair Obscur: Expedition 33" },
                    { 4, "An open-world action RPG created by FromSoftware and George R.R. Martin.", "RPG", "PC", 59.99m, 9.8000000000000007, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elden Ring" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGames");
        }
    }
}
