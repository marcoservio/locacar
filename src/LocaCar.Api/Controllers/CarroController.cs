using LocaCar.Api.Models;

using Microsoft.AspNetCore.Mvc;
using LocaCar.Api.Interfaces.Services;
using LocaCar.Api.Authentication;

namespace LocaCar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;

        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetAllCarros()
        {
            var lstCarros = await _carroService.GetAll();

            if (lstCarros != null && lstCarros.ToList().Count > 0)
                return Ok(lstCarros);

            return NotFound("Não há nenhum carro registrado.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCarroById(int id)
        {
            var carro = await _carroService.GetById(id);

            if (carro != null)
                return Ok(carro);

            return NotFound("Carro não encontrado.");
        }

        [HttpPost]
        [ApiKey]
        public async Task<ActionResult> AddCarro(Carro carro)
        {
            _carroService.Add(carro);

            if (await _carroService.SaveAllAsync())
                return Ok("Carro cadastrado com sucesso.");

            return BadRequest("Ocorreu um erro ao salvar o carro.");
        }

        [HttpPut]
        [ApiKey]
        public async Task<ActionResult> UpdateCarro(Carro carro)
        {
            _carroService.Update(carro);

            if (await _carroService.SaveAllAsync())
                return Ok("Carro alterado com sucesso.");

            return BadRequest("Ocorreu um erro ao alterar o carro.");
        }

        [HttpDelete("{id}")]
        [ApiKey]
        public async Task<ActionResult> DeleteCarro(int id)
        {
            var carro = await _carroService.GetById(id);

            if (carro == null)
                return NotFound("Carro não encontrado.");

            _carroService.Delete(carro);

            if (await _carroService.SaveAllAsync())
                return Ok("Carro excluido com sucesso.");

            return BadRequest("Ocorreu um erro ao excluir o carro.");
        }
    }
}
