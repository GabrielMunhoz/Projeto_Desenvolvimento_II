using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Models.Base;

namespace PlayersBook.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder ApplyGlobalConfiguration(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(BaseEntity.Id):
                            property.IsKey();
                            break;
                        case nameof(BaseEntity.DateUpdated):
                            property.IsNullable = true;
                            break;
                        case nameof(BaseEntity.DateCreate):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(BaseEntity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;
                        default:
                            break;
                    }
                }
            }
            return builder;
        }

        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<Player>().HasData(new Player
            {
                Id = Guid.Parse("d0f606a2-622c-46b8-a844-ae0e817b1839"),
                Nickname = "Gmunho",
                Name = "Gabriel",
                LastName = "Munhoz",
                Password = "teste",
                Email = "gabrielmunhoz@playersbook.com",
                DateCreate = new DateTime(2022, 9, 13),
                IsDeleted = false,
                DateUpdated = null

            });

            return builder;
        }

        public static ModelBuilder ConfigureRelationshipAdvertisementPlayer(this ModelBuilder builder)
        {
            builder.Entity<AdvertisementPlayers>()
                .HasKey(ap => new { ap.advertisementId, ap.PlayerId }); 

            builder.Entity<AdvertisementPlayers>()
                .HasOne(ad => ad.Advertisement)
                .WithMany(p => p.Guests)
                .HasForeignKey(ad => ad.advertisementId);
            
            builder.Entity<AdvertisementPlayers>()
                .HasOne(ad => ad.Player)
                .WithMany(p => p.Advertisements)
                .HasForeignKey(ad => ad.PlayerId);

            

            return builder;
        }
    }
}
