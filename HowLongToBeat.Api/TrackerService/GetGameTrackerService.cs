using HowLongToBeat.Api.Models;
using HowLongToBeat.Api.Repositories;

namespace HowLongToBeat.Api.TrackerService;

public class GetGameTrackerService
{
    private readonly IGameRepository _gameRepository;

    public GetGameTrackerService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    //GetGame
    public async Task<Game?> GetGame(int id)
    {
        return await _gameRepository.FindById(id);
    }

    //GetGames
    public async Task<IEnumerable<Game>> GetGames()
    {
        return await _gameRepository.FindAll();
    }
}