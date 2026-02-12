using VideoGameCatalogue.Core.Models;

namespace VideoGameCatalogue.Core.Interfaces
{
    // Defines the contract for video game data operations
    public interface IVideoGameRepository
    {
        Task<IEnumerable<VideoGame>> GetAllAsync();
        Task<VideoGame?> GetByIdAsync(int id);
        Task<VideoGame> CreateAsync(VideoGame game);
        Task<VideoGame?> UpdateAsync(VideoGame game);
    }
}