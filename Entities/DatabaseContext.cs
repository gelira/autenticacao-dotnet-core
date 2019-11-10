using Microsoft.EntityFrameworkCore;

namespace Autenticacao.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            builder.UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.UseSerialColumns();
        }
    }
}
