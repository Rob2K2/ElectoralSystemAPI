using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectoralSystem.API.Repository.Maps
{
    public class PollingStationMap : IEntityTypeConfiguration<PollingStation>
    {
        public void Configure(EntityTypeBuilder<PollingStation> builder) 
        {
            builder.ToTable("PollingStation", SqlContext.SCHEMA);

            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Number);
            builder.Property(p => p.RegisteredVoters);
            builder.Property(p => p.Status);
        }
    }
}
