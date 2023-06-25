using CatalogoCarros.Api.Models;

namespace CatalogoCarros.Api.Data
{
    public interface ICarroDao
    {
        IEnumerable<Carro> Listar();
    }
}
