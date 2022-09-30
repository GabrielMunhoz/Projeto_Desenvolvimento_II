using Microsoft.Extensions.Logging;
using PlayersBook.Application.Interfaces;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;

namespace PlayersBook.Application.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository advertisementRepository;
        private readonly ILogger<Advertisement> logger;

        public AdvertisementService(IAdvertisementRepository advertisementRepository, ILogger<Advertisement> logger)
        {
            this.advertisementRepository = advertisementRepository;
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
    }
}
