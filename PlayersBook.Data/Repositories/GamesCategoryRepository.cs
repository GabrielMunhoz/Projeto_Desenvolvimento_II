using PlayersBook.Data.Context;
using PlayersBook.Data.Repositories.Base;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;

namespace PlayersBook.Data.Repositories
{
    public class GamesCategoryRepository : BaseRepository<GamesCategory>, IGamesCategoryRepository
    {
        public GamesCategoryRepository(PlayersBookDBContext context) : base(context)
        {
        }

    }
}
