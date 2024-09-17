using ConsoleApp.Extentions;
using ConsoleApp.Models;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.InputEncoding = System.Text.Encoding.Unicode;

var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

var serviceProvider = new ServiceCollection()
    .AddServices(configuration);

Console.WriteLine("Please enter the path of audio or video file:");
string filePath = Console.ReadLine();

if(!FileChecker.FileExists(filePath))
{
    Console.WriteLine("File does not exist! іііі");
}
else if(!FileChecker.CheckIfFileIsAudioOrVideo(filePath))
{
    Console.WriteLine("The file is neither an audio file nor a video file!");
}
else
{
    var speechRecognitionService = serviceProvider.BuildServiceProvider().GetService<SpeechRecognitionService>();
    var speech = await speechRecognitionService.TranscribeAudio(filePath);

    PrintResult(speech);
}

Console.ReadLine();

void PrintResult(string result)
{
    if (string.IsNullOrWhiteSpace(result))
    {
        Console.WriteLine("Something went wrong!");
    }
    else
    {
        Console.WriteLine(result);
    }
}