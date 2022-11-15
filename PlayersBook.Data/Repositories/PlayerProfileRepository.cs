using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlayersBook.Data.Context;
using PlayersBook.Data.Repositories.Base;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;

namespace PlayersBook.Data.Repositories
{
    public class PlayerProfileRepository : BaseRepository<PlayerProfile>, IPlayerProfileRepository
    {
        private readonly ILogger<PlayerProfileRepository> logger;

        public PlayerProfileRepository(PlayersBookDBContext context, ILogger<PlayerProfileRepository> logger) : base(context)
        {
            this.logger = logger;
        }

        public async Task<List<PlayerProfile>> GetAllAsync()
        {
            try
            {
                return await
                    Query(x => !x.IsDeleted)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<PlayerProfile?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.PlayerProfile
                    .Include(x => x.Player)
                    .Include(x => x.ChannelStreams)
                    .Include(x => x.GamesCategoryProfile)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<PlayerProfile?> GetByPlayerIdAsync(Guid playerId)
        {
            try
            {
                return await _context.PlayerProfile
                    .Include(x => x.Player)
                    .Include(x => x.ChannelStreams)
                    .Include(x => x.GamesCategoryProfile)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.PlayerId == playerId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<PlayerProfile> UpdatePlayerProfileAsync(PlayerProfile playerProfile)
        {
            var profileConsulted = await _context.PlayerProfile
                .Include(x => x.ChannelStreams)
                .Include(x => x.GamesCategoryProfile)
                .SingleOrDefaultAsync(ad => ad.Id == playerProfile.Id);


            if (profileConsulted == null)
                throw new Exception("profile not found");

            _context.Entry(profileConsulted).CurrentValues.SetValues(playerProfile);

            await UpdateChannelsProfile(playerProfile, profileConsulted);
            await UpdateGamesCategory(playerProfile, profileConsulted);

            await _context.SaveChangesAsync();

            return profileConsulted;
        }

        private async Task UpdateGamesCategory(PlayerProfile playerProfile, PlayerProfile? profileConsulted)
        {
            profileConsulted.GamesCategoryProfile.Clear();

            foreach (var item in playerProfile.GamesCategoryProfile)
            {
                var gameConsulted = await _context.GamesCategory.FindAsync(item.Id);
                if(gameConsulted != null)
                    profileConsulted.GamesCategoryProfile.Add(gameConsulted);
                else
                    profileConsulted.GamesCategoryProfile.Add(item);
            }
        }

        private async Task UpdateChannelsProfile(PlayerProfile playerProfile, PlayerProfile? profileConsulted)
        {
            profileConsulted.ChannelStreams.Clear();

            foreach (var item in playerProfile.ChannelStreams)
            {
                var channelConsulted = await _context.ChannelStreams.FindAsync(item.Id);
                if (channelConsulted != null)
                    profileConsulted.ChannelStreams.Add(channelConsulted);
                else
                    profileConsulted.ChannelStreams.Add(item);
            }
        }
    }
}
