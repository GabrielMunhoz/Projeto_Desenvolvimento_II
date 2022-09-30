using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Data.Mapping
{
    public class AdvertisementMap : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.GameCategory).IsRequired();
            builder.Property(x => x.GroupCategory).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
