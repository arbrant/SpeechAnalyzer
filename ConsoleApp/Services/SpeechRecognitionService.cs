using AssemblyAI;
using AssemblyAI.Transcripts;

namespace ConsoleApp.Services
{
    public class SpeechRecognitionService
    {
        private readonly AssemblyAIClient assemblyAIClient;

        public SpeechRecognitionService(AssemblyAIClient assemblyAIClient)
        {
            this.assemblyAIClient = assemblyAIClient;
        }

        public async Task<string> TranscribeAudio(string path)
        {
            var transcript = await assemblyAIClient.Transcripts.TranscribeAsync(new FileInfo(path), transcriptParams: new() { LanguageCode = TranscriptLanguageCode.Uk });
            transcript.EnsureStatusCompleted();

            return transcript.Text ?? string.Empty;
        }

        public async Task<string> TranscribeAudio(Stream stream)
        {
            var transcript = await assemblyAIClient.Transcripts.TranscribeAsync(stream, transcriptParams: new() { LanguageCode = TranscriptLanguageCode.Uk });
            transcript.EnsureStatusCompleted();

            return transcript.Text ?? string.Empty;
        }
    }
}
