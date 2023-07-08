using LocaCar.Api.Data;
using Newtonsoft.Json;
using LocaCar.Api.Models;

namespace LocaCar.Api.Imports
{
    public class MarcaDataImporter : DataImporter
    {
        public MarcaDataImporter(AppDbContext context) : base(context)
        {
        }

        public override async Task Import()
        {
            if (!_context.Marcas.Any())
            {
                var url = $"https://parallelum.com.br/fipe/api/v1/carros/marcas";
                var response = await _httpClient.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                try
                {
                    var lstMarcas = JsonConvert.DeserializeObject<List<Marca>>(json);

                    foreach (var marca in lstMarcas)
                        _context.Marcas.Add(marca);

                    await _context.SaveChangesAsync();
                }
                catch
                {
                    var error = JsonConvert.DeserializeObject<ErrorImport>(json);
                    Console.WriteLine($"Erro ao importar lançadores: {error.ErrorMessage}");
                }
            }
        }
    }
}
