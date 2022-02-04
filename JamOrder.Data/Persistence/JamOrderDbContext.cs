using JamOrder.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JamOrder.Data.Persistence
{
    public class JamOrderDbContext : DbContext
    {
        public JamOrderDbContext(DbContextOptions<JamOrderDbContext> dbContextOptions) : base(dbContextOptions)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<TokenLog> TokenLog { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}