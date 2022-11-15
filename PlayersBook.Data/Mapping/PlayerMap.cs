using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Data.Mapping
{
    public class PlayerMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.HasOne(x => x.PlayerProfile).WithOne(x => x.Player).HasForeignKey<PlayerProfile>(x => x.PlayerId);
        }
    }
}
