using Microsoft.EntityFrameworkCore;
using VideoGameCatalogue.Core.Interfaces;
using VideoGameCatalogue.Core.Models;

namespace VideoGameCatalogue.Data
{
    // Handles all database operations
    public class VideoGameRepository : IVideoGameRepository
    {
        private readonly VideoGameCatalogueContext _context;

        // DbContext injected through the constructor
        public VideoGameRepository(VideoGameCatalogueContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VideoGame>> GetAllAsync()
        {
            return await _context.VideoGames.ToListAsync();
        }

        public async Task<VideoGame?> GetByIdAsync(int id)
        {
            return await _context.VideoGames.FindAsync(id);
        }

        public async Task<VideoGame> CreateAsync(VideoGame game)
        {
            _context.VideoGames.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<VideoGame?> UpdateAsync(VideoGame game)
        {
            var existingGame = await _context.VideoGames.FindAsync(game.Id);

            if (existingGame == null)
                return null;

            // Update each field with the new values
            existingGame.Title = game.Title;
            existingGame.Genre = game.Genre;
            existingGame.Platform = game.Platform;
            existingGame.ReleaseDate = game.ReleaseDate;
            existingGame.Price = game.Price;
            existingGame.Rating = game.Rating;
            existingGame.Description = game.Description;

            await _context.SaveChangesAsync();
            return existingGame;
        }
    }
}