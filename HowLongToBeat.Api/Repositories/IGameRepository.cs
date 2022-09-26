using HowLongToBeat.Api.Models;

namespace HowLongToBeat.Api.Repositories
{
    public interface IGameRepository
    {
        //FindById
        Task<Game?> FindById(int id);

        //FindAll
        Task<IEnumerable<Game>> FindAll();

        //InsertGame
        Task<Game> InsertGame(Game game);

        //EditGameDetails
        Task<Game> EditGameTime(int id, Game game);

        //DeleteGame
        Task<Game?> DeleteGame(int id);
    }
}