using LocaCar.Api.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace LocaCar.Api.Data
{
    public class DbInitializer
    {
        private readonly AppDbContext _dbContext;

        public DbInitializer(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            try
            {
                MigrateDatabase();
                SeedDataIfEmpty();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao inicializar o banco de dados. Erro: {ex.Message}");
            }
        }

        private void MigrateDatabase()
        {
            _dbContext.Database.Migrate();
        }

        private void SeedDataIfEmpty()
        {
            if (!_dbContext.Carros.Any())
            {
                var carroDataSeeder = new CarroDataSeeder(_dbContext);
                carroDataSeeder.SeedData();
            }
        }
    }
}
