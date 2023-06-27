using LocaCar.Api.Data;
using LocaCar.Api.Interfaces;
using LocaCar.Api.Models;

using Microsoft.EntityFrameworkCore;

namespace LocaCar.Api.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly AppDbContext _context;

        public CarroRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Carro carro)
        {
            _context.Carros.Add(carro);
        }

        public void Delete(Carro carro)
        {
            _context.Carros.Remove(carro);
        }

        public async Task<IEnumerable<Carro>> GetAll()
        {
            return await _context.Carros.ToListAsync();
        }

        public async Task<Carro> GetById(int id)
        {
            return await _context.Carros.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Carro carro)
        {
            _context.Carros.Update(carro);
        }
    }
}
