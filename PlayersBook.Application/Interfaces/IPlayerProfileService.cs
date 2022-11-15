﻿using PlayersBook.Application.ViewModels.Advertisement;
using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Application.Interfaces
{
    public interface IPlayerProfileService
    {
        Task<List<PlayerProfile>> GetallAsync();
        Task<PlayerProfile> GetByIdAsync(string id);
        Task<PlayerProfile> GetByPlayerIdAsync(string playerId);
        Task<PlayerProfile> PostNewPlayerProfileAsync(PlayerProfile playerProfile);
        Task<string> UpdateProfilePictureByPlayerId(string playerId, string url);
        Task<PlayerProfile> PutUpdatePlayerProfileAsync(PlayerProfile playerProfile);
        Task<bool> PostAvaliateAsync(AvaliateGuestViewModel avaliateGuestViewModel);
        Task<List<ChannelStreamDto>> GetChannelsStreamsByNameAsync(string channelName);
    }
}
