using ElectoralSystem.API.Repository.Context;
using ElectoralSystem.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectoralSystem.API.Repository.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.ToTable("User", SqlContext.SCHEMA);

            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.FullName);
            builder.Property(p => p.Login);
            builder.Property(p => p.PasswordHash);
            builder.Property(p => p.Role);
        }
    }
}
