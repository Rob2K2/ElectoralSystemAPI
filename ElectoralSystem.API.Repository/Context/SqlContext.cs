using Microsoft.EntityFrameworkCore;

namespace ElectoralSystem.API.Repository.Context
{
    public class SqlContext : DbContext
    {
        public static string SCHEMA = "dbo";

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
