using HowLongToBeat.Api.Models;
using HowLongToBeat.Api.TrackerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HowLongToBeat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly GameTrackerService _gameTrackerBusinessLogic;

        // POST: GameController/Create
        public GameController(GameTrackerService gameTrackerBusinessLogic)
        {
            _gameTrackerBusinessLogic = gameTrackerBusinessLogic;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Game))]
        [ProducesResponseType(400)]
        public Task<IActionResult> Create([FromBody] Game game)
        {
            var addedGame = _gameTrackerBusinessLogic.CreateGame(game);

            return Task.FromResult<IActionResult>(CreatedAtAction(nameof(GetGame), new {id = addedGame.Id}, addedGame));
        }

        [HttpGet("{id:int}", Name = nameof(GetGame))]
        [ProducesResponseType(200, Type = typeof(Game))]
        [ProducesResponseType(404)]
        public Task<IActionResult> GetGame(int id)
        {
            var retrievedGame = _gameTrackerBusinessLogic.GetGame(id);

            return Task.FromResult<IActionResult>(Ok(retrievedGame));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        public Task<IActionResult> GetAllGames()
        {
            var retrievedGames = _gameTrackerBusinessLogic.GetGames();

            return Task.FromResult<IActionResult>(Ok(retrievedGames));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EditGameDetails(int id, [FromBody] Game game)
        {
            if (game.GameId != id)
            {
                return BadRequest();
            }

            var existing = await _gameTrackerBusinessLogic.EditGameTime(id, game);
            return await Task.FromResult<IActionResult>(Ok(existing));
        }


        [HttpDelete]
        public Task<IActionResult> Delete(int id)
        {
            var toBeDeletedGame = _gameTrackerBusinessLogic.DeleteGame(id);
            return Task.FromResult<IActionResult>(Ok(toBeDeletedGame));
        }
    }
}