using HowLongToBeat.Api.Models;
using HowLongToBeat.Api.Repositories;

namespace HowLongToBeat.Api.TrackerService;

public class AddGameTrackerService
{
    private readonly IGameRepository _gameRepository;

    public AddGameTrackerService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
        
    //CreateGame
    public async Task<Game> CreateGame(Game game)
    {
        return await _gameRepository.InsertGame(game);
    }
}