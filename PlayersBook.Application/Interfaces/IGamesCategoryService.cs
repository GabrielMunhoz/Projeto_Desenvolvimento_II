using PlayersBook.Domain.DTOs;

namespace PlayersBook.Application.Interfaces
{
    public interface IGamesCategoryService
    {
        Task<RetTopGamesTwitchDto> GetTopGamesCategoryTwitchAsync();
    }
}
