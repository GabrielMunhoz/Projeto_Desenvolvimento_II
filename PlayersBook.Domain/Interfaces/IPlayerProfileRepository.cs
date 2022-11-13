using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces.Base;

namespace PlayersBook.Domain.Interfaces
{
    public interface IPlayerProfileRepository: IBaseRepository<PlayerProfile>
    {
        Task<List<PlayerProfile>> GetAllAsync();
        Task<PlayerProfile?> GetByIdAsync(Guid id);
        Task<PlayerProfile?> GetByPlayerIdAsync(Guid playerId);
        Task<PlayerProfile> UpdatePlayerProfileAsync(PlayerProfile playerProfile);
    }
}
