using LocaCar.Api.Data;

namespace LocaCar.Api.Imports
{
    public abstract class DataImporter
    {
        protected readonly HttpClient _httpClient;
        protected readonly AppDbContext _context;

        public DataImporter(AppDbContext context)
        {
            _httpClient = new HttpClient();
            _context = context;
        }

        public abstract Task Import();
    }
}
