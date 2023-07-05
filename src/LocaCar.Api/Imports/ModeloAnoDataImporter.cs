using LocaCar.Api.Data;
using LocaCar.Api.Models;

using Newtonsoft.Json;

using System.Linq;

namespace LocaCar.Api.Imports
{
    public class ModeloAnoDataImporter : DataImporter
    {
        public ModeloAnoDataImporter(AppDbContext context) : base(context)
        {
        }

        public override async Task Import()
        {
            try
            {
                var lstMarcas = _context.Marcas.ToList();
                var lstCodMarcasRegistradas = _context.Modelos.GroupBy(m => m.Marca).Select(m => m.Key.Id).ToList();
                var lstMarcasParaRegistrar = lstMarcas.Where(m => !lstCodMarcasRegistradas.Contains(m.Id)).ToList();

                foreach (var marca in lstMarcasParaRegistrar)
                {
                    await ImportModelos(marca);
                    await ImportAnos(marca);
                    Thread.Sleep(TimeSpan.FromMinutes(3));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao importar lançadores: {ex.Message}");
            }
        }

        private async Task ImportModelos(Marca marca)
        {
            var url = $"https://parallelum.com.br/fipe/api/v1/carros/marcas/{marca.Codigo}/modelos";
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var lstImports = JsonConvert.DeserializeObject<DadosImportados>(json);

            foreach (var modelo in lstImports.Modelos)
            {
                if (!_context.Modelos.Any(m => m.Codigo == modelo.Codigo))
                {
                    modelo.Marca = marca;
                    _context.Modelos.Add(modelo);
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task ImportAnos(Marca marca)
        {
            var lstModelos = _context.Modelos.Where(m => m.Marca.Id.Equals(marca.Id)).ToList();

            foreach (var modelo in lstModelos)
            {
                var url = $"https://parallelum.com.br/fipe/api/v1/carros/marcas/{marca.Codigo}/modelos/{modelo.Codigo}/anos";
                var response = await _httpClient.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var lstAnos = JsonConvert.DeserializeObject<List<Ano>>(json);

                foreach (var ano in lstAnos)
                {
                    var anoModelo = new AnoModelo
                    {
                        Modelo = modelo
                    };

                    if (!_context.Anos.Any(a => a.Codigo == ano.Codigo))
                        anoModelo.Ano = ano;
                    else
                        anoModelo.Ano = _context.Anos.FirstOrDefault(a => a.Codigo.Equals(ano.Codigo));

                    _context.AnosModelos.Add(anoModelo);
                }

                await _context.SaveChangesAsync();
            }
        }
    }

    public class DadosImportados
    {
        public List<Modelo> Modelos { get; set; }
        public List<Ano> Anos { get; set; }
    }
}
