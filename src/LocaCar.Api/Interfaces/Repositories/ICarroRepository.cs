using LocaCar.Api.Models;

namespace LocaCar.Api.Interfaces.Repositories
{
    public interface ICarroRepository
    {
        void Add(Carro carro);
        void Update(Carro carro);
        void Delete(Carro carro);
        Task<Carro> GetById(int id);
        Task<IEnumerable<Carro>> GetAll();
        Task<bool> SaveAllAsync();
    }
}
