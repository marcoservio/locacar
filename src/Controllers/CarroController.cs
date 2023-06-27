using LocaCar.Api.Interfaces;
using LocaCar.Api.Models;

using Microsoft.AspNetCore.Mvc;

namespace LocaCar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _carroRepository;

        public CarroController(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetAllCarros()
        {
            var lstCarros = await _carroRepository.GetAll();

            if(lstCarros != null && lstCarros.ToList().Count > 0)
                return Ok(lstCarros);

            return NotFound("Não há nenhum carro registrado.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCarroById(int id)
        {
            var carro = await _carroRepository.GetById(id);

            if(carro != null)
                return Ok(carro);

            return NotFound("Carro não encontrado.");
        }

        [HttpPost]
        public async Task<ActionResult> AddCarro(Carro carro)
        {
            _carroRepository.Add(carro);

            if(await _carroRepository.SaveAllAsync())
                return Ok("Carro cadastrado com sucesso.");

            return BadRequest("Ocorreu um erro ao salvar o carro.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCarro(Carro carro)
        {
            _carroRepository.Update(carro);

            if (await _carroRepository.SaveAllAsync())
                return Ok("Carro alterado com sucesso.");

            return BadRequest("Ocorreu um erro ao alterar o carro.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarro(int id)
        {
            var carro = await _carroRepository.GetById(id);

            if (carro == null)
                return NotFound("Carro não encontrado.");

            _carroRepository.Delete(carro);

            if (await _carroRepository.SaveAllAsync())
                return Ok("Carro excluido com sucesso.");

            return BadRequest("Ocorreu um erro ao excluir o carro.");
        }
    }
}
