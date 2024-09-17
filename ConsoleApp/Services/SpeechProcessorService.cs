using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class SpeechProcessorService
    {
        private readonly SpeechRecognitionService speechRecognitionService;

        private readonly SpeechAnalysisService speechAnalysisService;

        public SpeechProcessorService(SpeechRecognitionService speechRecognitionService, SpeechAnalysisService speechAnalysisService)
        {
            this.speechRecognitionService = speechRecognitionService;
            this.speechAnalysisService = speechAnalysisService;
        }

        public async Task<string> AnalyzeSpeech(string filePath)
        {
            var script = await this.speechRecognitionService.TranscribeAudio(filePath);
            var recomendations = await this.speechAnalysisService.GiveSpeechRecomendations(script);

            return recomendations;
        }
    }
}
