using ExceptionHandler.Extensions;
using Microsoft.Extensions.Logging;
using PlayersBook.Application.Interfaces;
using PlayersBook.Application.ViewModels.Advertisement;
using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;


namespace PlayersBook.Application.Services
{
    public class PlayerProfileService : IPlayerProfileService
    {
        private readonly IPlayerProfileRepository playerProfileRepository;
        private readonly IPlayerService playerService;
        private readonly ITwitchRespository twitchRespository;
        private readonly ILogger<PlayerService> logger;

        public PlayerProfileService(IPlayerProfileRepository playerProfileRepository, IPlayerService playerService, ITwitchRespository twitchRespository, ILogger<PlayerService> logger)
        {
            this.playerProfileRepository = playerProfileRepository;
            this.playerService = playerService;
            this.twitchRespository = twitchRespository;
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

                var result = await playerProfileRepository.GetByIdAsync(profileId);

                if (result == null)
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

                if (profileBD != null)
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
                var ret = await playerProfileRepository.UpdatePlayerProfileAsync(playerProfile);

                return ret;
            }
            catch (Exception ex)
            {
                logger.LogInformation(Resource.ERROR_LOG, nameof(PutUpdatePlayerProfileAsync), nameof(PlayerProfileService), ex.Message);
                throw;
            }
        }

        public async Task<string> UpdateProfilePictureByPlayerId(string playerId, string url)
        {
            logger.LogInformation(Resource.INFORMATION_LOG, nameof(UpdateProfilePictureByPlayerId), nameof(PlayerProfileService));
            try
            {
                var profileBd = await playerProfileRepository.GetAsync(x => x.Player.Id.ToString() == playerId);

                if (profileBd == null)
                {
                    Player player = await playerService.GetByIdAsync(playerId);
                    if (player == null)
                        throw new ApiException(String.Format(Resource.NAO_ENCONTRADO, playerId));

                    PlayerProfile playerProfile = new PlayerProfile { PlayerId = player.Id, ImageUrl = url };

                    var playerBD = await playerProfileRepository.CreateAsync(playerProfile);

                    if (playerBD == null)
                        throw new ApiException(String.Format(Resource.FALHA_INSERIR_REGISTRO, "PlayerProfile PlayerID: " + playerId));

                    return playerBD.ImageUrl;
                }

                profileBd.ImageUrl = url;

                var result = await playerProfileRepository.UpdateAsync(profileBd); 
                if(!result)
                    throw new ApiException(String.Format(Resource.FALHA_INSERIR_REGISTRO, "PlayerProfile PlayerID: " + playerId));
                
                return url;

            }
            catch (Exception ex)
            {
                logger.LogInformation(Resource.ERROR_LOG, nameof(UpdateProfilePictureByPlayerId), nameof(PlayerProfileService), ex.Message);
                throw; 
            }
        }

        public async Task<bool> PostAvaliateAsync(AvaliateGuestViewModel avaliateGuestViewModel)
        {
            logger.LogInformation(String.Format(Resource.INFORMATION_LOG, nameof(PostAvaliateAsync), nameof(AdvertisementService)));
            try
            {
                if (avaliateGuestViewModel.Avaliate.HasValue && (avaliateGuestViewModel.PlayerId != Guid.Empty))
                {
                    if (avaliateGuestViewModel.Avaliate.Value)
                    {
                        var profile = playerProfileRepository.Find(x => x.PlayerId == avaliateGuestViewModel.PlayerId);

                        if (profile == null)
                            throw new ApiException(String.Format(Resource.NAO_ENCONTRADO, avaliateGuestViewModel.PlayerId));

                        if (!profile.RatingPositive.HasValue)
                            profile.RatingPositive = 1; 
                        else
                            profile.RatingPositive++;

                        var update = await playerProfileRepository.UpdateAsync(profile);

                        return update;
                    }
                    else
                    {
                        var profile = playerProfileRepository.Find(x => x.PlayerId == avaliateGuestViewModel.PlayerId);

                        if (profile == null)
                            throw new ApiException(String.Format(Resource.NAO_ENCONTRADO, avaliateGuestViewModel.PlayerId));

                        if (!profile.RatingNegative.HasValue)
                            profile.RatingNegative = 1;
                        else
                            profile.RatingNegative++;

                        var update = await playerProfileRepository.UpdateAsync(profile);

                        return update;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                logger.LogInformation(String.Format(Resource.INFORMATION_LOG, nameof(PostAvaliateAsync), nameof(AdvertisementService), ex.Message));
                throw;
            }
        }

        public async Task<PlayerProfile> GetByPlayerIdAsync(string playerId)
        {
            logger.LogInformation($"Method: {nameof(GetByIdAsync)} -- Service: {nameof(PlayerProfileService)}");
            try
            {
                if (!Guid.TryParse(playerId, out Guid playerprofileId))
                    throw new ApiException(String.Format(Resource.VALOR_INVALIDO, playerprofileId));

                var result = await playerProfileRepository.GetByPlayerIdAsync(playerprofileId);

                if (result == null)
                {
                    var playerConsulted = await playerService.GetByIdAsync(playerprofileId.ToString());

                    if(playerConsulted == null)
                        throw new ApiException(String.Format(Resource.NAO_ENCONTRADO, playerprofileId));

                    PlayerProfile newPlayerProfile = new PlayerProfile
                    {
                        PlayerId = playerprofileId
                    };

                    var saveProfile = await playerProfileRepository.CreateAsync(newPlayerProfile); 

                    return saveProfile;
                }
                    
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(Resource.ERROR_LOG, nameof(GetallAsync), nameof(PlayerProfileService), ex.Message);
                throw;
            }
        }

        public async Task<List<ChannelStreamDto>> GetChannelsStreamsByNameAsync(string channelName)
        {
            logger.LogInformation($"Method: {nameof(GetChannelsStreamsByNameAsync)} -- Service: {nameof(PlayerProfileService)}");
            try
            {
                return await twitchRespository.GetChannelsStreamsByNameAsync(channelName);
            }
            catch (Exception ex)
            {
                logger.LogError(Resource.ERROR_LOG, nameof(GetChannelsStreamsByNameAsync), nameof(PlayerProfileService), ex.Message);
                throw;
            }
        }
    }
}
