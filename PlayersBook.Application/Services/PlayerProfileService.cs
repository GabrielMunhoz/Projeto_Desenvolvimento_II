using Microsoft.Extensions.Logging;
using PlayersBook.Application.Interfaces;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;

namespace PlayersBook.Application.Services
{
    public class PlayerProfileService: IPlayerProfileService
    {
        private readonly IPlayerProfileRepository playerProfileRepository;
        private readonly ILogger<PlayerService> logger;

        public PlayerProfileService(IPlayerProfileRepository playerProfileRepository, ILogger<PlayerService> logger)
        {
            this.playerProfileRepository = playerProfileRepository;
            this.logger = logger;
        }

        public async Task<List<PlayerProfile>> GetallAsync()
        {
            logger.LogInformation($"Method: {nameof(GetallAsync)} -- Service: {nameof(PlayerProfileService)}");
            try
            {
                return await playerProfileRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message); 
                throw;
            }
        }
    }
}
