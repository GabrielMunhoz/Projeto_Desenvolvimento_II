using PlayersBook.Domain.Entities;

namespace PlayersBook.Application.Interfaces
{
    public interface IPlayerProfileService
    {
        Task<List<PlayerProfile>> GetallAsync();
        Task<PlayerProfile> GetByIdAsync(string id);
        Task<PlayerProfile> PostNewPlayerProfileAsync(PlayerProfile playerProfile);
        Task<bool> UpdateProfilePictureByPlayerId(string playerId, string url);
        Task<PlayerProfile> PutUpdatePlayerProfileAsync(PlayerProfile playerProfile);
    }
}
