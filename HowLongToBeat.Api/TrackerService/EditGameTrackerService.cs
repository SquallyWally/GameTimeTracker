using HowLongToBeat.Api.Models;
using HowLongToBeat.Api.Repositories;

namespace HowLongToBeat.Api.TrackerService;

public class EditGameTrackerService
{
    private readonly IGameRepository _gameRepository;

    public EditGameTrackerService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Game?> EditGameTime(int id, Game game)
    {
        return await _gameRepository.EditGameTime(id, game);
    }

    //DeleteGame
    public async Task<Game?> DeleteGame(int id)
    {
        return await _gameRepository.DeleteGame(id);
    }
}