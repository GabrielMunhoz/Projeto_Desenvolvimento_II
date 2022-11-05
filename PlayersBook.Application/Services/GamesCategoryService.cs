using ExceptionHandler.Extensions;
using Microsoft.Extensions.Logging;
using PlayersBook.Application.Interfaces;
using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;
using System.Net.WebSockets;

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
            logger.LogInformation($"Method: {nameof(GetTopGamesCategoryTwitchAsync)} -- Service: {nameof(PlayerProfileService)}");
            try
            {
                var result = await twitchRespository.GetTopGamesCategoryAsync();
                if (result == null)
                    throw new ApiException(Resource.FALHA_AO_RECUPERAR_VALORES);
                return result; 
            }
            catch (Exception ex)
            {
                logger.LogError($"Method: {nameof(GetChannelStreamByNameAsync)} -- Service: {nameof(PlayerProfileService)} -- Ex: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ChannelStreamDto>> GetChannelStreamByNameAsync(string channelName)
        {
            logger.LogInformation(string.Format(Resource.INFORMATION_LOG,nameof(GetChannelStreamByNameAsync),nameof(PlayerProfileService)));
            try
            {
                List<ChannelStreamDto>? result = await twitchRespository.GetChannelsStreamsByNameAsync(channelName).ConfigureAwait(false);
                if (result == null)
                    throw new ApiException(string.Format(Resource.NAO_ENCONTRADO, channelName));

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format(Resource.ERROR_LOG, nameof(GetChannelStreamByNameAsync), nameof(PlayerProfileService), ex.Message));
                throw;
            }
        }
        public async Task<List<GamesCategory>> GetGameCategoryByName(string gameName)
        {
            logger.LogInformation(string.Format(Resource.INFORMATION_LOG, nameof(GetGameCategoryByName), nameof(PlayerProfileService)));
            try
            {
                List<GamesCategory>? result = await twitchRespository.GetGamesCategoryByNameAsync(gameName).ConfigureAwait(false);
                if (result == null || !result.Any())
                    throw new ApiException(string.Format(Resource.NAO_ENCONTRADO, gameName));

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format(Resource.ERROR_LOG, nameof(GetGameCategoryByName), nameof(PlayerProfileService), ex.Message));
                throw;
            }
        }

    }
}
