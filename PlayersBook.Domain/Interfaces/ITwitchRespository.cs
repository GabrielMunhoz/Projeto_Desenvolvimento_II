using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Domain.Interfaces
{
    public interface ITwitchRespository
    {
        Task<RetTopGamesTwitchDto?> GetTopGamesCategoryAsync();
        Task<RetTopGamesTwitchDto?> GetGamesCategoryAsync(long id);
        Task<List<ChannelStreamDto>?> GetChannelsStreamsByNameAsync(string channelName);
        Task<List<GamesCategory>?> GetGamesCategoryByNameAsync(string gameName);
    }
}
