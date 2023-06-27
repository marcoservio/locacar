using LocaCar.Api.Models;
using LocaCar.Api.Models.Maps;

using Microsoft.EntityFrameworkCore;

namespace LocaCar.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarroMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Carro> Carros { get; set; }
    }
}
