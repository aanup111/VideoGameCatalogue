using VideoGameCatalogue.Core.Interfaces;
using VideoGameCatalogue.Core.Models;

namespace VideoGameCatalogue.Services
{
    // Handles business logic for video game operations
    public class VideoGameService : IVideoGameService
    {
        private readonly IVideoGameRepository _repository;

        public VideoGameService(IVideoGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VideoGame>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<VideoGame?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<VideoGame> CreateAsync(VideoGame game)
        {
            ValidateVideoGame(game);
            return await _repository.CreateAsync(game);
        }

        public async Task<VideoGame?> UpdateAsync(VideoGame game)
        {
            ValidateVideoGame(game);
            return await _repository.UpdateAsync(game);
        }

        // Data validation before creating or updating a game
        private void ValidateVideoGame(VideoGame game)
        {
            if (string.IsNullOrWhiteSpace(game.Title))
                throw new ArgumentException("Title is required.");

            if (string.IsNullOrWhiteSpace(game.Genre))
                throw new ArgumentException("Genre is required.");

            if (string.IsNullOrWhiteSpace(game.Platform))
                throw new ArgumentException("Platform is required.");

            if (game.Price < 0)
                throw new ArgumentException("Price cannot be negative.");

            if (game.Rating < 0 || game.Rating > 10)
                throw new ArgumentException("Rating must be between 0 and 10.");

            if (game.ReleaseDate > DateTime.Now)
                throw new ArgumentException("Release date cannot be in the future.");
        }
    }
}