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

        // Test method for returning all games
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

        // Test method for when the game exists
        [Fact]
        public async Task GetByIdAsync_ReturnsGame_WhenGameExists()
        {
            var expectedGame = new VideoGame { Id = 1, Title = "Valorant", Genre = "FPS", Platform = "PC", Price = 0, Rating = 8.5 };

            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(expectedGame);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Valorant", result.Title);
        }

        // Test mothod for when the game does not exist
        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenGameDoesNotExist()
        {
            _mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((VideoGame?)null);

            var result = await _service.GetByIdAsync(99);

            Assert.Null(result);
        }

        // Test method for creating a game with empty title
        [Fact]
        public async Task CreateAsync_ThrowsException_WhenTitleIsEmpty()
        {
            var game = new VideoGame { Title = "", Genre = "RPG", Platform = "PC", Price = 29.99m, Rating = 8.0 };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.CreateAsync(game));
        }

        // Test method for creating a game with invalid rating
        [Fact]
        public async Task CreateAsync_ThrowsException_WhenRatingIsOutOfRange()
        {
            var game = new VideoGame { Title = "Test", Genre = "RPG", Platform = "PC", Price = 29.99m, Rating = 11.0 };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.CreateAsync(game));
        }

        // Test method for creating a game with negative price
        [Fact]
        public async Task CreateAsync_ThrowsException_WhenPriceIsNegative()
        {
            var game = new VideoGame { Title = "Test", Genre = "RPG", Platform = "PC", Price = -5.00m, Rating = 8.0 };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.CreateAsync(game));
        }

        // Test method for creating a valid game
        [Fact]
        public async Task CreateAsync_Succeeds_WhenGameIsValid()
        {
            var game = new VideoGame { Title = "Valorant", Genre = "FPS", Platform = "PC", Price = 0, Rating = 8.5 };

            _mockRepo.Setup(r => r.CreateAsync(game)).ReturnsAsync(game);

            var result = await _service.CreateAsync(game);

            Assert.Equal("Valorant", result.Title);
        }

        // Test method for creating game with future date
        [Fact]
        public async Task CreateAsync_ThrowsException_WhenReleaseDateIsInFuture()
        {
            var game = new VideoGame
            {
                Title = "Future Game",
                Genre = "RPG",
                Platform = "PC",
                Price = 29.99m,
                Rating = 8.0,
                ReleaseDate = DateTime.Now.AddYears(1)
            };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.CreateAsync(game));
        }
    }
}