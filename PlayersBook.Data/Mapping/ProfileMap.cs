﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayersBook.Domain.Entities;

namespace PlayersBook.Data.Mapping
{
    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasOne(x => x.Player);
        }
    }
}
