using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces.Base;

namespace PlayersBook.Domain.Interfaces
{
    public interface IPlayerProfileRepository: IBaseRepository<PlayerProfile>
    {
        Task<List<PlayerProfile>> GetAllAsync();
    }
}
