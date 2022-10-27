using HowLongToBeat.Api.Models;
using HowLongToBeat.Api.TrackerService;
using Microsoft.AspNetCore.Mvc;

namespace HowLongToBeat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly AddGameTrackerService _gameTrackerBusinessLogic;
        private readonly GetGameTrackerService _getGameTrackerBusinessLogic;
        private readonly EditGameTrackerService _editGameTrackerBusinessLogic;

        public GameController(
            AddGameTrackerService gameTrackerBusinessLogic,
            GetGameTrackerService getGameTrackerBusinessLogic,
            EditGameTrackerService editGameTrackerBusinessLogic)
        {
            _gameTrackerBusinessLogic = gameTrackerBusinessLogic;
            _getGameTrackerBusinessLogic = getGameTrackerBusinessLogic;
            _editGameTrackerBusinessLogic = editGameTrackerBusinessLogic;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Game))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Game game)
        {
            var addedGame = await _gameTrackerBusinessLogic.CreateGame(game);

            return await Task.FromResult<IActionResult>(CreatedAtAction(nameof(GetGame), new {id = addedGame.GameId},
                addedGame));
        }

        [HttpGet("{id:int}", Name = nameof(GetGame))]
        [ProducesResponseType(200, Type = typeof(Game))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetGame(int id)
        {
            var retrievedGame = await _getGameTrackerBusinessLogic.GetGame(id);

            return await Task.FromResult<IActionResult>(Ok(retrievedGame));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        public async Task<IActionResult> GetAllGames()
        {
            var retrievedGames = await _getGameTrackerBusinessLogic.GetGames();

            return await Task.FromResult<IActionResult>(Ok(retrievedGames));
        }

        [HttpPut("Edit/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EditGameDetails(int id, [FromBody] Game game)
        {
            if (game.GameId != id)
            {
                return BadRequest();
            }

            var existing = await _editGameTrackerBusinessLogic.EditGameTime(id, game);
            return await Task.FromResult<IActionResult>(Ok(existing));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var toBeDeletedGame = await _editGameTrackerBusinessLogic.DeleteGame(id);
            return await Task.FromResult<IActionResult>(Ok(toBeDeletedGame));
        }
    }
}