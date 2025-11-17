using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectoralSystem.API.Repository.Maps
{
    public class PoliticalPartyMap : IEntityTypeConfiguration<PoliticalParty>
    {
        public void Configure(EntityTypeBuilder<PoliticalParty> builder) 
        {
            builder.ToTable("PoliticalParty", SqlContext.SCHEMA);

            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name);
            builder.Property(p => p.Acronym);
            builder.HasIndex(p => p.Acronym).IsUnique();
        }
    }
}
