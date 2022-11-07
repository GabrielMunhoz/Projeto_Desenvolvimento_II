using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Data.Mapping
{
    public class PlayerProfileMap : IEntityTypeConfiguration<PlayerProfile>
    {
        public void Configure(EntityTypeBuilder<PlayerProfile> builder)
        {
            builder.Property(x => x.PlayerId).IsRequired(); 
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasMany(x => x.GamesCategoryProfile).WithOne();
            builder.HasMany(x => x.ChannelStreams).WithOne(); 
        }
    }
}
