using LocaCar.Api.Models;
using OpenAI_API;
using OpenAI_API.Chat;

namespace LocaCar.Api.Chatbot
{
    public class ChatbotClient
    {
        private readonly IConfiguration _configuration;
        private readonly OpenAIAPI _client;
        private readonly Conversation _chat;

        public ChatbotClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new OpenAIAPI(_configuration["CHATBOT_API_KEY"]);
            _chat = _client.Chat.CreateConversation();
        }

        public async Task<string> GetDescricaoCarro(Carro carro)
        {
            try
            {
                _chat.AppendSystemMessage($"Resuma o {carro.Marca} {carro.Modelo} {carro.Ano} em no maximo 200 caracteres");
                return await _chat.GetResponseFromChatbotAsync();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
