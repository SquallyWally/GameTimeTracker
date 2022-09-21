using HowLongToBeat.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HowLongToBeat.Api.Context
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
    }
}
