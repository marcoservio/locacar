using LocaCar.Api.Data;
using LocaCar.Api.Interfaces;
using LocaCar.Api.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Xunit.Abstractions;

namespace LocaCar.Tests
{
    public class CarroRepositoryTeste : IDisposable
    {
        private readonly ICarroRepository _carroRepository;
        private ITestOutputHelper _saidaConsoleTeste { get; set; }

        public CarroRepositoryTeste(ITestOutputHelper saidaConsoleTeste)
        {
            _saidaConsoleTeste = saidaConsoleTeste;
            var connectionString = "server=localhost;port=3310;database=locacar;user=root;password=root";
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
        }
    }
}