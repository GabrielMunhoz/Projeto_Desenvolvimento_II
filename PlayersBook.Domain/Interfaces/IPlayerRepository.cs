using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces.Base;

namespace PlayersBook.Domain.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        IEnumerable<Player> GetAll();
    }
}
