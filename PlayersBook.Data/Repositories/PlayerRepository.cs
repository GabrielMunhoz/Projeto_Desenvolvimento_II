using Microsoft.EntityFrameworkCore;
using PlayersBook.Data.Context;
using PlayersBook.Data.Repositories.Base;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;

namespace PlayersBook.Data.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(PlayersBookDBContext context): base(context)
        {

        }
        public List<Player> GetAll()
        {
            return Query(x => !x.IsDeleted).ToList();
        }
    }
}
