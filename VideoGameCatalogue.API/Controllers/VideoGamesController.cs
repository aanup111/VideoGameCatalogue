using Microsoft.AspNetCore.Mvc;
using VideoGameCatalogue.Core.Interfaces;
using VideoGameCatalogue.Core.Models;

namespace VideoGameCatalogue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGameService _service;

        public VideoGamesController(IVideoGameService service)
        {
            _service = service;
        }

        // GET: api/videogames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGame>>> GetAll()
        {
            var games = await _service.GetAllAsync();
            return Ok(games);
        }

        // GET: api/videogames/id
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetById(int id)
        {
            var game = await _service.GetByIdAsync(id);

            if (game == null)
                return NotFound();

            return Ok(game);
        }

        // POST: api/videogames
        [HttpPost]
        public async Task<ActionResult<VideoGame>> Create(VideoGame game)
        {
            try
            {
                var created = await _service.CreateAsync(game);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/videogames/id
        [HttpPut("{id}")]
        public async Task<ActionResult<VideoGame>> Update(int id, VideoGame game)
        {
            if (id != game.Id)
                return BadRequest("URL id does not match game id.");

            try
            {
                var updated = await _service.UpdateAsync(game);

                if (updated == null)
                    return NotFound();

                return Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}