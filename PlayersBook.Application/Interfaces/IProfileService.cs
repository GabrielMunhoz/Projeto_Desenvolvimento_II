using PlayersBook.Domain.Entities;

namespace PlayersBook.Application.Interfaces
{
    public interface IPlayerProfileService
    {
        Task<List<PlayerProfile>> GetallAsync(); 
    }
}
