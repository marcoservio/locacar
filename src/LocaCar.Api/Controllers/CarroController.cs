using LocaCar.Api.Models;

using Microsoft.AspNetCore.Mvc;
using LocaCar.Api.Interfaces.Services;
using LocaCar.Api.Authentication;
using AutoMapper;
using LocaCar.Api.Dtos;

namespace LocaCar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;
        private readonly IMapper _mapper;

        public CarroController(ICarroService carroService, IMapper mapper = null)
        {
            _carroService = carroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetAllCarros()
        {
            var carros = await _carroService.GetAll();

            if (carros == null || !carros.Any())
                return NotFound("Não há nenhum carro registrado.");

            var rakljsd = _mapper.Map<IEnumerable<CarroDto>>(carros);

            return Ok(rakljsd);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCarroById(int id)
        {
            var carro = await _carroService.GetById(id);

            if (carro == null)
                return NotFound("Carro não encontrado.");

            return Ok(_mapper.Map<CarroDto>(carro));
        }

        [HttpPost]
        [ApiKey]
        public async Task<ActionResult> AddCarro(CarroDto carroDto)
        {
            _carroService.Add(_mapper.Map<Carro>(carroDto));

            if (await _carroService.SaveAllAsync())
                return Ok("Carro cadastrado com sucesso.");

            return BadRequest("Ocorreu um erro ao salvar o carro.");
        }

        [HttpPut]
        [ApiKey]
        public async Task<ActionResult> UpdateCarro(CarroDto carroDto)
        {
            if (carroDto.Id == 0)
                return BadRequest("Não é possivel alterar o carro. É preciso informar o ID.");

            var carro = await _carroService.GetById(carroDto.Id);
            if (carro == null)
                return NotFound("Carro não encontrado.");

            _carroService.Update(_mapper.Map<Carro>(carroDto));

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
