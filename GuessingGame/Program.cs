using GuessingGame.Interfaces;
using GuessingGame.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GuessingGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder();

            hostBuilder.Services
                .AddSingleton<IGameService, GameService>()
                .AddTransient<IGeneratorService, GeneratorService>()
                .AddTransient<IUserInteractionService, UserInteractionService>()
                .AddTransient<IGuessCheckService, GuessCheckService>();

            hostBuilder.Configuration
                .AddJsonFile("settings.json");

            ServiceProvider serviceProvider = hostBuilder.Services.BuildServiceProvider();

            IGameService gameService = serviceProvider.GetRequiredService<IGameService>();
            gameService.Play();
        }
    }
}
