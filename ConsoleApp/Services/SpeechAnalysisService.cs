using OpenAI_API;

namespace ConsoleApp.Services
{
    public class SpeechAnalysisService
    {
        private readonly IOpenAIAPI openAIAPI;

        public SpeechAnalysisService(IOpenAIAPI openAIAPI)
        {
            this.openAIAPI = openAIAPI;
        }

        public async Task<string> GiveSpeechRecomendations(string speech)
        {
            var conversation = this.openAIAPI.Chat.CreateConversation();

            var input = "Надай короткі рекомендації щодо покращення виступу та софт скілів. Мова виступу - українська. Скрипт виступу з відеофайлу: " + speech;

            conversation.AppendUserInput(input);

            return await conversation.GetResponseFromChatbotAsync();
        }
    }
}
