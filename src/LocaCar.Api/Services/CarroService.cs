using LocaCar.Api.Chatbot;
using LocaCar.Api.Interfaces.Repositories;
using LocaCar.Api.Interfaces.Services;
using LocaCar.Api.Models;

namespace LocaCar.Api.Services
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;
        private readonly ChatbotClient _chatbotClient;

        public CarroService(ICarroRepository carroRepository, ChatbotClient chatbotClient)
        {
            _carroRepository = carroRepository;
            _chatbotClient = chatbotClient;
        }

        public async Task<IEnumerable<Carro>> GetAll()
        {
            return await _carroRepository.GetAll();
        }

        public async Task<Carro> GetById(int id)
        {
            return await _carroRepository.GetById(id);
        }

        public void Add(Carro carro)
        {
            var descricao = _chatbotClient.GetDescricaoCarro(carro).GetAwaiter().GetResult();
            if (!string.IsNullOrEmpty(descricao))
                carro.Descricao = descricao;

            _carroRepository.Add(carro);
        }

        public void Update(Carro carro)
        {
            _carroRepository.Update(carro);
        }

        public void Delete(Carro carro)
        {
            _carroRepository.Delete(carro);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _carroRepository.SaveAllAsync();
        }
    }
}
