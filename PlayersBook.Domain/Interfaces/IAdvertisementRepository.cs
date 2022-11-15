using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces.Base;

namespace PlayersBook.Domain.Interfaces
{
    public interface IAdvertisementRepository: IBaseRepository<Advertisement>
    {
        Task<ICollection<Advertisement>> GetAdvertisementsActiveAsync();
        Task<ICollection<Advertisement>> GetAdvertisementsActiveWithHostAsync();
        Task<ICollection<Advertisement>> GetAllAdvertisementsAsync();
        Task<Advertisement> SaveAdvertisement(Advertisement advertisement);
        Task<Advertisement> UpdateAdvertisement(Advertisement advertisement);
        Task<Advertisement> GetByIdAsync(Guid id);
        Task<List<Advertisement>> GetHistoryByPlayerIdAsync(Guid Playerid);
        Task<bool> DeleteAdvertisementAsync(string id); 
    }
}
