using AutoMapper;

using LocaCar.Api.Controllers;
using LocaCar.Api.Dtos;
using LocaCar.Api.Interfaces.Services;
using LocaCar.Api.Mappings;
using LocaCar.Api.Models;

using Microsoft.AspNetCore.Mvc;

using Moq;

namespace LocaCar.Tests.Integration
{
    public class CarroControllerTest : IDisposable
    {
        private readonly Mock<ICarroService> _carroServiceMock;
        private readonly CarroController _carroController;
        private readonly IMapper _mapper;

        public CarroControllerTest()
        {
            var _config = new MapperConfiguration(cfg => cfg.AddProfile<EntitiesToDtoMappingProfile>());
            _carroServiceMock = new Mock<ICarroService>();
            _mapper = _config.CreateMapper();
            _carroController = new CarroController(_carroServiceMock.Object, _mapper);
        }

        [Fact]
        public async Task GetAllCarros_DeveRetornarListaDeCarros_QuandoExistirRegistros()
        {
            var carros = new List<Carro> { new Carro(), new Carro() };
            _carroServiceMock.Setup(repo => repo.GetAll()).ReturnsAsync(carros);

            var resultado = await _carroController.GetAllCarros();

            Assert.IsType<OkObjectResult>(resultado.Result);
            var okObjectResult = resultado.Result as OkObjectResult;
            var listaRetornada = okObjectResult.Value as IEnumerable<CarroDto>;
            Assert.Equal(carros.Count, listaRetornada.Count());
        }

        [Fact]
        public async Task GetAllCarros_DeveRetornarNotFound_QuandoNaoExistirRegistros()
        {
            _carroServiceMock.Setup(repo => repo.GetAll()).ReturnsAsync(new List<Carro>());

            var resultado = await _carroController.GetAllCarros();

            Assert.IsType<NotFoundObjectResult>(resultado.Result);
            var notFoundObjectResult = resultado.Result as NotFoundObjectResult;
            Assert.Equal("Não há nenhum carro registrado.", notFoundObjectResult.Value);
        }

        [Fact]
        public async Task GetCarroById_DeveRetornarCarro_QuandoExistirRegistro()
        {
            var id = 1;
            var carro = new Carro { Id = id };
            _carroServiceMock.Setup(repo => repo.GetById(id)).ReturnsAsync(carro);

            var resultado = await _carroController.GetCarroById(id);

            Assert.IsType<OkObjectResult>(resultado);
            var okObjectResult = resultado as OkObjectResult;
            var carroRetornado = okObjectResult.Value as CarroDto;
            Assert.Equal(id, carroRetornado.Id);
        }

        [Fact]
        public async Task GetCarroById_DeveRetornarNotFound_QuandoRegistroNaoExistir()
        {
            var id = 1;
            _carroServiceMock.Setup(repo => repo.GetById(id)).ReturnsAsync((Carro)null);

            var resultado = await _carroController.GetCarroById(id);

            Assert.IsType<NotFoundObjectResult>(resultado);
            var notFoundObjectResult = resultado as NotFoundObjectResult;
            Assert.Equal("Carro não encontrado.", notFoundObjectResult.Value);
        }

        [Fact]
        public async Task AddCarro_DeveRetornarOk_QuandoInsercaoForBemSucedida()
        {
            var carroDto = new CarroDto { Marca = "Volkswagen", Modelo = "Golf", Ano = "2022", Cor = "Prata", TipoCorpo = "Hatchback", Motor = "1.4L", Transmissao = "Automática", Quilometragem = 5000.2m, Preco = 35000.50m, NumeroPortas = 4, CapacidadePassageiros = 5, Descricao = "O Volkswagen Golf 2022 é um hatchback elegante e esportivo com um motor potente e tecnologia avançada." };
            _carroServiceMock.Setup(service => service.SaveAllAsync()).ReturnsAsync(true);

            var result = await _carroController.AddCarro(carroDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Carro cadastrado com sucesso.", okResult.Value);
        }

        [Fact]
        public async Task AddCarro_DeveRetornarBadRequest_QuandoOcorrerErroNaInsercao()
        {
            var carroDto = new CarroDto { Marca = "Volkswagen", Modelo = "Golf", Ano = "2022", Cor = "Prata", TipoCorpo = "Hatchback", Motor = "1.4L", Transmissao = "Automática", Quilometragem = 5000.2m, Preco = 35000.50m, NumeroPortas = 4, CapacidadePassageiros = 5, Descricao = "O Volkswagen Golf 2022 é um hatchback elegante e esportivo com um motor potente e tecnologia avançada." };
            _carroServiceMock.Setup(service => service.SaveAllAsync()).ReturnsAsync(false);

            var result = await _carroController.AddCarro(carroDto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Ocorreu um erro ao salvar o carro.", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateCarro_DeveRetornarOk_QuandoAtualizacaoForBemSucedida()
        {
            var carroId = 1;
            var updatedCarro = new Carro { Id = carroId, Marca = "Volkswagen Updated", Modelo = "Golf", Ano = "2022", Cor = "Prata", TipoCorpo = "Hatchback", Motor = "1.4L", Transmissao = "Automática", Quilometragem = 5000.2m, Preco = 35000.50m, NumeroPortas = 4, CapacidadePassageiros = 5, Descricao = "O Volkswagen Golf 2022 é um hatchback elegante e esportivo com um motor potente e tecnologia avançada." };
            _carroServiceMock.Setup(repo => repo.GetById(carroId)).ReturnsAsync(updatedCarro);
            _carroServiceMock.Setup(repo => repo.SaveAllAsync()).ReturnsAsync(true);

            var resultado = await _carroController.UpdateCarro(_mapper.Map<CarroDto>(updatedCarro));

            Assert.IsType<OkObjectResult>(resultado);
            var okObjectResult = resultado as OkObjectResult;
            Assert.Equal("Carro alterado com sucesso.", okObjectResult.Value);
        }

        [Fact]
        public async Task UpdateCarro_DeveRetornarNotFound_QuandoNaoExistirCarro()
        {
            var carroId = 1;
            var updatedCarro = new Carro { Id = carroId };
            _carroServiceMock.Setup(repo => repo.GetById(carroId)).ReturnsAsync((Carro)null);
            _carroServiceMock.Setup(repo => repo.SaveAllAsync()).ReturnsAsync(true);

            var resultado = await _carroController.UpdateCarro(_mapper.Map<CarroDto>(updatedCarro));

            Assert.IsType<NotFoundObjectResult>(resultado);
            var notFoundObjectResult = resultado as NotFoundObjectResult;
            Assert.Equal("Carro não encontrado.", notFoundObjectResult.Value);
        }

        [Fact]
        public async Task UpdateCarro_DeveRetornarBadRequest_QuandoNaoExistirIdCarro()
        {
            var updatedCarro = new Carro { Marca = "Volkswagen Updated", Modelo = "Golf", Ano = "2022", Cor = "Prata", TipoCorpo = "Hatchback", Motor = "1.4L", Transmissao = "Automática", Quilometragem = 5000.2m, Preco = 35000.50m, NumeroPortas = 4, CapacidadePassageiros = 5, Descricao = "O Volkswagen Golf 2022 é um hatchback elegante e esportivo com um motor potente e tecnologia avançada." };
            _carroServiceMock.Setup(repo => repo.SaveAllAsync()).ReturnsAsync(true);

            var resultado = await _carroController.UpdateCarro(_mapper.Map<CarroDto>(updatedCarro));

            Assert.IsType<BadRequestObjectResult>(resultado);
            var badRequestObjectResult = resultado as BadRequestObjectResult;
            Assert.Equal("Não é possivel alterar o carro. É preciso informar o ID.", badRequestObjectResult.Value);
        }

        [Fact]
        public async Task UpdateLaunch_DeveRetornarBadRequest_QuandoOcorrerErroNaAtualizacao()
        {
            var carroId = 1;
            var updatedCarro = new Carro { Id = carroId, Marca = "Volkswagen Updated", Modelo = "Golf", Ano = "2022", Cor = "Prata", TipoCorpo = "Hatchback", Motor = "1.4L", Transmissao = "Automática", Quilometragem = 5000.2m, Preco = 35000.50m, NumeroPortas = 4, CapacidadePassageiros = 5, Descricao = "O Volkswagen Golf 2022 é um hatchback elegante e esportivo com um motor potente e tecnologia avançada." };
            _carroServiceMock.Setup(repo => repo.GetById(carroId)).ReturnsAsync(updatedCarro);
            _carroServiceMock.Setup(repo => repo.SaveAllAsync()).ReturnsAsync(false);

            var resultado = await _carroController.UpdateCarro(_mapper.Map<CarroDto>(updatedCarro));

            Assert.IsType<BadRequestObjectResult>(resultado);
            var badRequestObjectResult = resultado as BadRequestObjectResult;
            Assert.Equal("Ocorreu um erro ao alterar o carro.", badRequestObjectResult.Value);
        }

        [Fact]
        public async Task DeleteCarro_DeveRetornarOk_QuandoExclusaoForBemSucedida()
        {
            var id = 1;
            var carro = new Carro { Id = id };
            _carroServiceMock.Setup(repo => repo.GetById(id)).ReturnsAsync(carro);
            _carroServiceMock.Setup(repo => repo.SaveAllAsync()).ReturnsAsync(true);

            var resultado = await _carroController.DeleteCarro(id);

            Assert.IsType<OkObjectResult>(resultado);
            var okObjectResult = resultado as OkObjectResult;
            Assert.Equal("Carro excluido com sucesso.", okObjectResult.Value);
        }

        [Fact]
        public async Task DeleteCarro_DeveRetornarNotFound_QuandoRegistroNaoExistir()
        {
            var id = 1;
            _carroServiceMock.Setup(repo => repo.GetById(id)).ReturnsAsync((Carro)null);

            var resultado = await _carroController.DeleteCarro(id);

            Assert.IsType<NotFoundObjectResult>(resultado);
            var notFoundObjectResult = resultado as NotFoundObjectResult;
            Assert.Equal("Carro não encontrado.", notFoundObjectResult.Value);
        }

        [Fact]
        public async Task DeleteCarro_DeveRetornarBadRequest_QuandoOcorrerErroNaExclusao()
        {
            var id = 1;
            var carro = new Carro { Id = id };
            _carroServiceMock.Setup(repo => repo.GetById(id)).ReturnsAsync(carro);
            _carroServiceMock.Setup(repo => repo.SaveAllAsync()).ReturnsAsync(false);

            var resultado = await _carroController.DeleteCarro(id);

            Assert.IsType<BadRequestObjectResult>(resultado);
            var badRequestObjectResult = resultado as BadRequestObjectResult;
            Assert.Equal("Ocorreu um erro ao excluir o carro.", badRequestObjectResult.Value);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
