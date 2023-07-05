namespace LocaCar.Api.Imports
{
    public class ImportsBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ImportsBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var marcaDataImporter = scope.ServiceProvider.GetRequiredService<MarcaDataImporter>();
                        await marcaDataImporter.Import();
                    }

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var modeloDataImporter = scope.ServiceProvider.GetRequiredService<ModeloAnoDataImporter>();
                        await modeloDataImporter.Import();
                    }

                    await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houve um erro: {ex.Message}");
            }
        }
    }
}
