using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectoralSystem.API.Repository.Maps
{
    public class PartyPollingResultMap : IEntityTypeConfiguration<PartyPollingResult>
    {
        public void Configure(EntityTypeBuilder<PartyPollingResult> builder)
        {
            builder.ToTable("PartyPollingResult", SqlContext.SCHEMA);

            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.VotesValid);
            builder.Property(p => p.VotesBlank);
            builder.Property(p => p.VotesNull);
            builder.Property(p => p.RegisteredDate);

            builder.Property(p => p.PollStationId).IsRequired();
            builder.Property(p => p.PoliticalPartyId).IsRequired();

            builder.HasOne(p => p.PollingStation).WithMany().HasForeignKey(p => p.PollStationId);
            builder.HasOne(p => p.PoliticalParty).WithMany().HasForeignKey(p => p.PoliticalPartyId);

            builder.HasIndex(p => new { p.PollStationId, p.PoliticalPartyId, p.RegisteredDate })
                .IsUnique()
                .HasDatabaseName("IX_PartyPollingResult_Unique_Station_Party_Date");
        }
    }
}
