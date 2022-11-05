using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Application.Interfaces
{
    public interface IGamesCategoryService
    {
        Task<RetTopGamesTwitchDto> GetTopGamesCategoryTwitchAsync();
        Task<List<GamesCategory>> GetGameCategoryByName(string gameName);
        Task<List<ChannelStreamDto>> GetChannelStreamByNameAsync(string channelName);
        
    }
}
