using Microsoft.Extensions.Logging;
using PlayersBook.Application.Interfaces;
using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Interfaces;

namespace PlayersBook.Application.Services
{
    public class GamesCategoryService : IGamesCategoryService
    {
        private readonly ITwitchRespository twitchRespository;
        private readonly IGamesCategoryRepository gamesCategoryRepository;
        private readonly ILogger<GamesCategoryService> logger;

        public GamesCategoryService(ITwitchRespository twitchRespository, IGamesCategoryRepository gamesCategoryRepository, ILogger<GamesCategoryService> logger)
        {
            this.twitchRespository = twitchRespository;
            this.gamesCategoryRepository = gamesCategoryRepository;
            this.logger = logger;
        }

        public async Task<RetTopGamesTwitchDto> GetTopGamesCategoryTwitchAsync()
        {
            return await twitchRespository.GetTopGamesCategoryAsync();
        }
    }
}
