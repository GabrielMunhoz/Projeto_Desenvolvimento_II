using PlayersBook.Domain.DTOs;

namespace PlayersBook.Domain.Interfaces
{
    public interface ITwitchRespository
    {
        Task<RetTopGamesTwitchDto> GetTopGamesCategoryAsync();
        Task<RetTopGamesTwitchDto> GetGamesCategoryAsync(long id);

    }
}
