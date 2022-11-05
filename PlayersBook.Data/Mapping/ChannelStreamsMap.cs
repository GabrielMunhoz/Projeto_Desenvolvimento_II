using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Data.Mapping
{
    public class ChannelStreamsMap : IEntityTypeConfiguration<ChannelStreams>
    {
        public void Configure(EntityTypeBuilder<ChannelStreams> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ImageProfile).IsRequired();
        }
    }
}
