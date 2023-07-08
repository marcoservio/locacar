using LocaCar.Api.Data;
using LocaCar.Api.Interfaces.Repositories;
using LocaCar.Api.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Xunit.Abstractions;

namespace LocaCar.Tests.Integration
{
    public class CarroRepositoryTest : IDisposable
    {
        private readonly ICarroRepository _carroRepository;
        private ITestOutputHelper _saidaConsoleTeste { get; set; }

        public CarroRepositoryTest(ITestOutputHelper saidaConsoleTeste)
        {
            _saidaConsoleTeste = saidaConsoleTeste;
            var configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            var connectionString = $"server={configuration["MYSQL_HOST"]};port={configuration["MYSQL_PORT"]};database={configuration["MYSQL_DATABASE"]};user={configuration["MYSQL_USER"]};password={configuration["MYSQL_PASSWORD"]}";
            var servico = new ServiceCollection();
            servico.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            servico.AddTransient<ICarroRepository, CarroRepository>();
            var provedor = servico.BuildServiceProvider();
            _carroRepository = provedor.GetRequiredService<ICarroRepository>();
        }

        [Fact]
        public async void TestaObterTodosCarros()
        {
            var lstCarros = await _carroRepository.GetAll();

            Assert.NotEmpty(lstCarros);
        }

        public void Dispose()
        {
            _saidaConsoleTeste.WriteLine("Done");
            GC.SuppressFinalize(this);
        }
    }
}