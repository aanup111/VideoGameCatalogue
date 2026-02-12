using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGameCatalogue.Core.Interfaces;
using VideoGameCatalogue.Core.Models;
using VideoGameCatalogue.Services;

namespace VideoGameCatalogue.Tests
{
    public class VideoGameServiceTests
    {
        // Mock repository to simulate database 
        private readonly Mock<IVideoGameRepository> _mockRepo;
        private readonly VideoGameService _service;

        // Runs before each test to setup a fresh mock and service
        public VideoGameServiceTests()
        {
            _mockRepo = new Mock<IVideoGameRepository>();
            _service = new VideoGameService(_mockRepo.Object);
        }
        
        [Fact]
        public async Task GetAllAsync_ReturnsAllGames()
        {
            // Set up the fake data
            var expectedGames = new List<VideoGame>
    {
        new VideoGame { Id = 1, Title = "Valorant", Genre = "FPS", Platform = "PC", Price = 0, Rating = 8.5 },
        new VideoGame { Id = 2, Title = "Elden Ring", Genre = "RPG", Platform = "PC", Price = 59.99m, Rating = 9.8 }
    };

            // When GetAllAsync is called, return this list
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedGames);

            // Call the actual service method 
            var result = await _service.GetAllAsync();

            // Verify result
            Assert.Equal(2, result.Count());
        }
    }
}