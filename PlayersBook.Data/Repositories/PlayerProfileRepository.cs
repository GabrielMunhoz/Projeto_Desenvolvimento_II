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
                return await Query(x => !x.IsDeleted)
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
                    .FirstOrDefaultAsync(x => x.PlayerId == playerId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
