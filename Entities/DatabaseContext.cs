using Microsoft.EntityFrameworkCore;

namespace Autenticacao.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            builder.UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.UseSerialColumns();
            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
