using VideoGameCatalogue.Core.Models;

namespace VideoGameCatalogue.Data
{
    // initial sample data for the VideoGames table
    public static class VideoGameSeedData
    {
        public static List<VideoGame> GetSeedData()
        {
            return new List<VideoGame>
{
    new VideoGame
    {
        Id = 1,
        Title = "Valorant",
        Genre = "First-Person Shooter",
        Platform = "PC",
        ReleaseDate = new DateTime(2020, 6, 2),
        Price = 0.00m,
        Rating = 8.5,
        Description = "A free-to-play tactical shooter developed by Riot Games."
    },
    new VideoGame
    {
        Id = 2,
        Title = "League of Legends",
        Genre = "MOBA",
        Platform = "PC",
        ReleaseDate = new DateTime(2009, 10, 27),
        Price = 0.00m,
        Rating = 8.0,
        Description = null
    },
    new VideoGame
    {
        Id = 3,
        Title = "Clair Obscur: Expedition 33",
        Genre = "RPG",
        Platform = "PC",
        ReleaseDate = new DateTime(2025, 4, 24),
        Price = 49.99m,
        Rating = 9.0,
        Description = "A turn-based RPG inspired by French art and culture."
    },
    new VideoGame
    {
        Id = 4,
        Title = "Elden Ring",
        Genre = "RPG",
        Platform = "PC",
        ReleaseDate = new DateTime(2022, 2, 25),
        Price = 59.99m,
        Rating = 9.8,
        Description = "An open-world action RPG created by FromSoftware and George R.R. Martin."
    }
};
        }
    }
}
