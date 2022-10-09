using Microsoft.Extensions.Logging;
using PlayersBook.Application.Interfaces;
using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;

namespace PlayersBook.Application.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository advertisementRepository;
        private readonly IGamesCategoryService gamesCategoryService;
        private readonly ILogger<Advertisement> logger;

        public AdvertisementService(IAdvertisementRepository advertisementRepository, IGamesCategoryService gamesCategoryService, ILogger<Advertisement> logger)
        {
            this.advertisementRepository = advertisementRepository;
            this.gamesCategoryService = gamesCategoryService;
            this.logger = logger;
        }

        public async Task<ICollection<Advertisement>> GetAllAsync()
        {
            return await advertisementRepository.GetAdvertisementsActiveAsync();
        }

        public async Task<Advertisement> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Player Id is not valid");

            Guid.TryParse(id, out Guid userId);

            var result = await advertisementRepository.GetByIdAsync(userId);

            if (result == null)
                throw new Exception("Not Found");

            return result;
        }

        public async Task<Advertisement> PostAsync(Advertisement advertisement)
        {
            try
            {
                if (!(advertisement.PlayerHostId != null))
                    throw new Exception("Host must be specified");

                var result = await advertisementRepository.SaveAdvertisement(advertisement);

                if (result == null)
                    throw new Exception("Create Failed");


                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Advertisement> PutAsync(Advertisement advertisement)
        {
            try
            {
                if (advertisement.Id == Guid.Empty)
                    throw new Exception("Id must be specified");

                var result = await advertisementRepository.UpdateAdvertisement(advertisement);

                if (result == null)
                    throw new Exception("Update failed");

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await advertisementRepository.DeleteAdvertisementAsync(id);
        }

        public async Task<IList<AdvertisementsGroupedByGame>> GetAdvertisementsGroupedAsync()
        {
            try
            {
                var advertisements = await advertisementRepository.GetAdvertisementsActiveWithHostAsync();

                List<AdvertisementsGroupedByGame> itemsGrupedByGameCategory = GroupedItemsByGameCategory(advertisements);

                return itemsGrupedByGameCategory;

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message); 
                throw;
            }
        }

        private List<AdvertisementsGroupedByGame> GroupedItemsByGameCategory(ICollection<Advertisement> advertisements)
        {
            List<AdvertisementsGroupedByGame> itemsGrupedByGameCategory = new List<AdvertisementsGroupedByGame>(); 

            var itemsGruped = advertisements.GroupBy(x => x.GameCategory, (key, g) => new { GameCategory = key, Advertisements = g.ToList() }).ToList();

            itemsGruped.ForEach(x =>
            {
                itemsGrupedByGameCategory.Add(new AdvertisementsGroupedByGame
                {
                    GameCategory = new GamesCategory { Name = x.GameCategory },
                    Advertisements = x.Advertisements,
                });
            });

            return itemsGrupedByGameCategory;
        }

        public async Task<IList<AdvertisementsGroupedByGame>> GetAdvertisementsGroupedWithArtAsync()
        {
            try
            {
                var advertisements = await advertisementRepository.GetAdvertisementsActiveWithHostAsync();

                List<AdvertisementsGroupedByGame> itemsGrupedByGameCategory = GroupedItemsByGameCategory(advertisements);

                await metodoquefazascoisas(itemsGrupedByGameCategory);

                return itemsGrupedByGameCategory;

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        private async Task metodoquefazascoisas(List<AdvertisementsGroupedByGame> itemsGrupedByGameCategory)
        {
            RetTopGamesTwitchDto gamesCategories = await gamesCategoryService.GetTopGamesCategoryTwitchAsync();

            foreach(var ItemGrouped in itemsGrupedByGameCategory)
            {
                var gameCategory = gamesCategories.GamesCategories.FirstOrDefault(x => x.Name.ToLower().Equals(ItemGrouped.GameCategory.Name.ToLower()));

                if (gameCategory != null)
                {
                    ItemGrouped.GameCategory.BoxArtUrl = gameCategory.BoxArtUrl.Replace("{height}", "200").Replace("{width}", "150");
                    ItemGrouped.GameCategory.Id = gameCategory.Id;
                }

            }

        }
    }
}
