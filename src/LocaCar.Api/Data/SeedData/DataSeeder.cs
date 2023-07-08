namespace LocaCar.Api.Data.SeedData
{
    public abstract class DataSeeder<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        protected DataSeeder(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            if (!_dbContext.Set<T>().Any())
            {
                var dados = ObterDados();
                InserirDados(dados);
            }
        }

        protected abstract List<T> ObterDados();

        protected void InserirDados(List<T> dados)
        {
            _dbContext.Set<T>().AddRange(dados);
            _dbContext.SaveChanges();
        }
    }
}
