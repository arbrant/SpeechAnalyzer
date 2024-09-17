using AssemblyAI;
using ConsoleApp.Models;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Extentions
{
    public static class DependencyInjectionExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAssemblyAIClient(options =>
            {
                options.ApiKey = configuration["AssemblyAI:ApiKey"] ??
                    throw new NullReferenceException("AssemblyAI API key is not found.");
            });

            services.AddScoped<IOpenAIAPI>(serviceProvider =>
            {
                return new OpenAIAPI(configuration["OpenAI:ApiKey"] ??
                    throw new NullReferenceException("OpenAI API key is not found."));
            });

            services.AddScoped<SpeechRecognitionService>();
            services.AddScoped<SpeechAnalysisService>();
            services.AddScoped<SpeechProcessorService>();

            return services;
        }
    }
}
