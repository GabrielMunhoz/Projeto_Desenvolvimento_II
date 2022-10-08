using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlayersBook.Data.Context;
using PlayersBook.Data.Repositories.Base;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace PlayersBook.Data.Repositories
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {

        public AdvertisementRepository(PlayersBookDBContext context) : base(context)
        {
        }

        public async Task<ICollection<Advertisement>> GetAdvertisementsActiveAsync()
        {
            return await Query(x => x.IsActive)
                .Include(x => x.Guests)
                .AsNoTracking()
                .Where(x => x.IsActive)
                .ToListAsync();
        }
        public async Task<ICollection<Advertisement>> GetAdvertisementsActiveWithHostAsync()
        {
             var result = await Query(x => x.IsActive)
                .Include(x => x.Guests)
                .AsNoTracking()
                .Where(x => x.IsActive)
                .ToListAsync();
            
            if (result != null)
                foreach(var item in result)
                {
                    item.Host = await _context.Players.FirstAsync(x => x.Id.ToString() == item.PlayerHostId);
                }
            
            return result; 
        }

        public async Task<ICollection<Advertisement>> GetAllAdvertisementsAsync()
        {
            return await Query(x => x.IsActive)
                .Include(x => x.Guests)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Advertisement> GetByIdAsync(Guid id)
        {

            var result = await _context.Advertisements
                .Include(a => a.Guests)
                    .ThenInclude( x => x.Player)
                        .ThenInclude(x => x.Advertisements)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (result != null)
                result.Host = await _context.Players.FirstAsync(x => x.Id.ToString() == result.PlayerHostId); 

            return result; 
        }

        public async Task<Advertisement> UpdateAdvertisement(Advertisement advertisement)
        {
            var adConsulted = await _context.Advertisements
                .Include(x => x.Guests)
                .SingleOrDefaultAsync(ad => ad.Id == advertisement.Id);

            if (adConsulted == null)
                throw new Exception("Advertisement not found"); 

            _context.Entry(adConsulted).CurrentValues.SetValues(advertisement);

            await UpdateAdvertisementGuests(advertisement, adConsulted);
            await _context.SaveChangesAsync(); 

            return adConsulted;
        }

        private async Task UpdateAdvertisementGuests(Advertisement advertisement, Advertisement advertisementConsulted)
        {
            advertisementConsulted.Guests.Clear(); 

            foreach(AdvertisementPlayers guest in advertisement.Guests)
            {
                var guestConsulted = await _context.Players.FindAsync(guest.PlayerId);
                advertisementConsulted.Guests.Add(
                    new AdvertisementPlayers { 
                    Player = guestConsulted, PlayerId =  guestConsulted.Id,
                    advertisementId = advertisementConsulted.Id,
                    Advertisement = advertisementConsulted
                });
            }
        }

        public  async Task<bool> DeleteAdvertisementAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id invalid");

            Guid.TryParse(id, out Guid advertisementId);

            var adConsulted = await _context.Advertisements
                .Include(x => x.Guests)
                .SingleOrDefaultAsync(x => x.Id == advertisementId);

            if (adConsulted == null)
                throw new Exception("Advertisement not found");

            adConsulted.IsActive = false;

            var result = await UpdateAdvertisement(adConsulted);

            return result != null ? true : false;
            
        }

        public async Task<Advertisement> SaveAdvertisement(Advertisement advertisement)
        {
            await _context.Advertisements.AddAsync(advertisement);
            await AddGuestPlayer(advertisement);
            await _context.SaveChangesAsync();

            return advertisement;
        }

        private async Task AddGuestPlayer(Advertisement advertisement)
        {
            var playerConsulted = new List<Player>();
            foreach (var guest in advertisement.Guests)
            {
                var especialidadeConsultada = await _context.Players.FindAsync(guest.PlayerId);
                playerConsulted.Add(especialidadeConsultada);
            }
            advertisement.Guests = PlayerToAdvertisementPlayers(playerConsulted);
        }

        private ICollection<AdvertisementPlayers> PlayerToAdvertisementPlayers(List<Player> playerConsulted)
        {
            ICollection<AdvertisementPlayers> advertisementPlayers = new List<AdvertisementPlayers>();
            playerConsulted.ForEach(p =>
            {
                advertisementPlayers.Add(new AdvertisementPlayers
                {
                    PlayerId = p.Id
                });
            });

            return advertisementPlayers;
        }


    }
}
