﻿using ExceptionHandler.Extensions;
using Microsoft.Extensions.Logging;
using PlayersBook.Application.Interfaces;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;


namespace PlayersBook.Application.Services
{
    public class PlayerProfileService : IPlayerProfileService
    {
        private readonly IPlayerProfileRepository playerProfileRepository;
        private readonly IPlayerService playerService;
        private readonly ILogger<PlayerService> logger;

        public PlayerProfileService(IPlayerProfileRepository playerProfileRepository, IPlayerService playerService,ILogger<PlayerService> logger)
        {
            this.playerProfileRepository = playerProfileRepository;
            this.playerService = playerService;
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
                logger.LogInformation(Resource.ERROR_LOG, nameof(GetallAsync), nameof(PlayerProfileService), ex.Message);
                throw;
            }
        }

        public async Task<PlayerProfile> GetByIdAsync(string id)
        {
            logger.LogInformation($"Method: {nameof(GetByIdAsync)} -- Service: {nameof(PlayerProfileService)}");
            try
            {
                if (!Guid.TryParse(id, out Guid profileId))
                    throw new ApiException(String.Format(Resource.VALOR_INVALIDO, id));

                var result = await playerProfileRepository.GetById(profileId); 

                if(result == null)
                    throw new ApiException(String.Format(Resource.NAO_ENCONTRADO, id));

                return result;
            }
            catch (Exception ex)
            {
                logger.LogInformation(Resource.ERROR_LOG, nameof(GetallAsync), nameof(PlayerProfileService), ex.Message);
                throw;
            }
        }

        public async Task<PlayerProfile> PostNewPlayerProfileAsync(PlayerProfile playerProfile)
        {
            logger.LogInformation($"Method: {nameof(PostNewPlayerProfileAsync)} -- Service: {nameof(PlayerProfileService)}");
            try
            {
                var profileBD = await playerProfileRepository.GetAsync(x => x.PlayerId == playerProfile.PlayerId);

                if(profileBD != null)
                {
                    return playerProfile; 
                }

                profileBD = await playerProfileRepository.CreateAsync(playerProfile); 

                return profileBD;
            }
            catch (Exception ex)
            {
                logger.LogInformation(Resource.ERROR_LOG, nameof(PostNewPlayerProfileAsync), nameof(PlayerProfileService), ex.Message);
                throw;
            }
        }
        
        public async Task<PlayerProfile> PutUpdatePlayerProfileAsync(PlayerProfile playerProfile)
        {
            logger.LogInformation($"Method: {nameof(PutUpdatePlayerProfileAsync)} -- Service: {nameof(PlayerProfileService)}");
            try
            {
                var ret = await playerProfileRepository.UpdateAsync(playerProfile);

                if (!ret)
                    throw new ApiException(string.Format(Resource.FALHA_ATUALIZAR_REGISTRO));
                
                var profileBD = await playerProfileRepository.GetById(playerProfile.Id);

                if (profileBD == null)
                    throw new ApiException(string.Format(Resource.NAO_ENCONTRADO, playerProfile.Id.ToString()));

                return profileBD;
            }
            catch (Exception ex)
            {
                logger.LogInformation(Resource.ERROR_LOG, nameof(PutUpdatePlayerProfileAsync), nameof(PlayerProfileService), ex.Message);
                throw;
            }
        }

        public async Task<bool> UpdateProfilePictureByPlayerId(string playerId, string url)
        {
            logger.LogInformation(Resource.INFORMATION_LOG, nameof(UpdateProfilePictureByPlayerId), nameof(PlayerProfileService));
            try
            {
                var profileBd = await playerProfileRepository.GetAsync(x=> x.Player.Id.ToString() == playerId); 

                if(profileBd == null)
                {
                    Player player = await playerService.GetByIdAsync(playerId);
                    if (player == null)
                        throw new ApiException(String.Format(Resource.NAO_ENCONTRADO, playerId));

                    PlayerProfile playerProfile = new PlayerProfile { PlayerId = player.Id, ImageUrl = url }; 

                    var playerBD = await playerProfileRepository.CreateAsync(playerProfile);

                    if(playerBD == null)
                        throw new ApiException(String.Format(Resource.FALHA_INSERIR_REGISTRO, "PlayerProfile PlayerID: "+ playerId));

                    return true; 
                }

                profileBd.ImageUrl = url;

                return await playerProfileRepository.UpdateAsync(profileBd); 

            }
            catch (Exception ex)
            {
                logger.LogInformation(Resource.ERROR_LOG, nameof(UpdateProfilePictureByPlayerId), nameof(PlayerProfileService), ex.Message);
                return false; 
            }
        }
    }
}
