using Microsoft.EntityFrameworkCore;
using VideoGameCatalogue.Core.Models;

namespace VideoGameCatalogue.Data
{
    
    public class VideoGameCatalogueContext : DbContext
    {
        // Constructor to pass configuration options 
        public VideoGameCatalogueContext(DbContextOptions<VideoGameCatalogueContext> options)
            : base(options)
        {
        }
        // Configure seed data 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>().HasData(VideoGameSeedData.GetSeedData());
        }

        // Map the VideoGame model to a "VideoGames" table in the database
        public required DbSet<VideoGame> VideoGames { get; set; }
    }
}
