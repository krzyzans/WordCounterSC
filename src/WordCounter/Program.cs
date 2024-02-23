using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WordCounter.Configuration;
using WordCounter.Services.Dictionary;
using WordCounter.Services.Files;
using WordCounter.Services.Printer;
using WordCounter.Services.Words;

namespace WordCounter
{
    internal class Program
    {
         static async Task Main(string[] args)
         {
            IConfiguration configuration = CreateConfiguration();
            var appStarter = CreateServices(configuration).GetRequiredService<IWordsProcessor>();

            await appStarter.CountWords();
            appStarter.PrintResult();
         }

        private static ServiceProvider CreateServices(IConfiguration configuration)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IWordsProcessor, WordsProcessor>()
                .AddSingleton<IWordDictionary, WordDictionary>()
                .AddSingleton<IFileProcessor, FileProcessor>()
                .AddSingleton<IFileProvider, FileProvider>()
                .AddSingleton<IPrinter<IWordDictionary>,WordDictionaryConsolePrinter>()
                .Configure<MainConfiguration>(options => configuration.GetSection("MainConfiguration").Bind(options))
                .BuildServiceProvider();

            return serviceProvider;
        }

        private static IConfiguration CreateConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }
    }
}
