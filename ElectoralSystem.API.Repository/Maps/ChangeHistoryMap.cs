using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectoralSystem.API.Repository.Maps
{
    public class ChangeHistoryMap : IEntityTypeConfiguration<ChangeHistory>
    {
        public void Configure(EntityTypeBuilder<ChangeHistory> builder)
        {
            builder.ToTable("ChangeHistory", SqlContext.SCHEMA);

            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.TableName);
            builder.Property(p => p.RecordId);
            builder.Property(p => p.Action);
            builder.Property(p => p.OldValue);
            builder.Property(p => p.NewValue);
            builder.Property(p => p.Date);

            builder.Property(p => p.UserId);

            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);
        }
    }
}
