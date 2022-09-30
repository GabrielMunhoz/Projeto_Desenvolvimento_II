using Microsoft.EntityFrameworkCore;
using PlayersBook.Data.Extensions;
using PlayersBook.Data.Mapping;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Data.Context
{
    public class PlayersBookDBContext : DbContext
    {
        #region DBSETS
        public DbSet<Player> Players { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

        #endregion

        #region Constructor
        public PlayersBookDBContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region Confs
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerMap());
            modelBuilder.ApplyConfiguration(new AdvertisementMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());

            modelBuilder.ApplyGlobalConfiguration();
            modelBuilder.SeedData();

            modelBuilder.ConfigureRelationshipAdvertisementPlayer(); 

            base.OnModelCreating(modelBuilder);
        }
        #endregion

    }


}
