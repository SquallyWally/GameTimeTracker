using HowLongToBeat.Api.Context;
using HowLongToBeat.Api.Models;

namespace HowLongToBeat.Api.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _context;
        private readonly ILogger<GameRepository> _logger;

        public GameRepository(GameContext injectedContext, ILogger<GameRepository> logger)
        {
            _context = injectedContext;
            _logger = logger;
        }

        public Task<Game?> FindById(int id)
        {
            return Task.FromResult(_context.Games.Find(id));
        }

        public Task<IEnumerable<Game>> FindAll()
        {
            return Task.FromResult<IEnumerable<Game>>(_context.Games.ToList());
        }

        public Task<Game> InsertGame(Game game)
        {
            _context.Add(game);
            _context.SaveChanges();
            return Task.FromResult(game);
        }

        public Task<Game> EditGameTime(int id, Game game)
        {
            Game? oldGameDetails = _context.Games.Find(id);
            _logger.LogCritical(game.Title);

            if (oldGameDetails == null)
            {
                return Task.FromResult(game);
            }

            oldGameDetails.ClockedTime = game.ClockedTime;
            oldGameDetails.IsCompleted = game.IsCompleted;
            _context.SaveChanges();

            return Task.FromResult(game);
        }

        public Task<Game?> DeleteGame(int id)
        {
            Game? game = _context.Games.Find(id);

            if (game != null)
            {
                _context.Remove(game);
                _context.SaveChanges();
            }

            return Task.FromResult(game);
        }
    }
}