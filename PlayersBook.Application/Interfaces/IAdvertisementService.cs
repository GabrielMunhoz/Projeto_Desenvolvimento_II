﻿using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Application.Interfaces
{
    public interface IAdvertisementService
    {
        Task<ICollection<Advertisement>> GetAllAsync(); 
        Task<Advertisement> GetById(string id);
        Task<List<Advertisement>> GetAdvertisementHistoryByPlayerId(string playerID);
        Task<Advertisement> PutAsync(Advertisement advertisement);
        Task<Advertisement> PostAsync(Advertisement advertisement);
        Task<bool> DeleteAsync(string id);
        Task<IList<AdvertisementsGroupedByGame>> GetAdvertisementsGroupedAsync();
        Task<IList<AdvertisementsGroupedByGame>> GetAdvertisementsGroupedWithArtAsync();

    }
}
