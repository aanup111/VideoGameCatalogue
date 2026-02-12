using VideoGameCatalogue.Core.Models;

namespace VideoGameCatalogue.Core.Interfaces
{
    // Contract for video game business logic
    public interface IVideoGameService
    {
        Task<IEnumerable<VideoGame>> GetAllAsync();
        Task<VideoGame?> GetByIdAsync(int id);
        Task<VideoGame> CreateAsync(VideoGame game);
        Task<VideoGame?> UpdateAsync(VideoGame game);
    }
}
