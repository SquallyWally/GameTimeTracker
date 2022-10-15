using HowLongToBeat.Api.Models;
using HowLongToBeat.Api.Repositories;

namespace HowLongToBeat.Api.TrackerService
{
    public class GameTrackerService
    {
        private readonly IGameRepository _gameRepository;

        public GameTrackerService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // //GetGame
        // public async Task<Game?> GetGame(int id)
        // {
        //     return await _gameRepository.FindById(id);
        // }
        //
        // //GetGames
        // public async Task<IEnumerable<Game>> GetGames()
        // {
        //     return await _gameRepository.FindAll();
        // }

        //CreateGame
        public async Task<Game> CreateGame(Game game)
        {
            return await _gameRepository.InsertGame(game);
        }

        // //EditGameTime
        // public async Task<Game?> EditGameTime(int id, Game game)
        // {
        //     return await _gameRepository.EditGameTime(id, game);
        // }
        //
        // //DeleteGame
        // public async Task<Game?> DeleteGame(int id)
        // {
        //     return await _gameRepository.DeleteGame(id);
        // }
    }
}