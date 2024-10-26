using GuessingGame.Interfaces;
using GuessingGame.Services;
using GuessingGame.Settings;
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

            hostBuilder.Configuration
                .AddJsonFile("settings.json");

            hostBuilder.Services
                .Configure<GameSettings>(hostBuilder.Configuration.GetSection("GameSettings"));

            hostBuilder.Services
                .AddTransient<IGameService, GameService>()
                .AddTransient<IGeneratorService, GeneratorService>()
                .AddTransient<IUserInteractionService, UserInteractionService>()
                .AddTransient<IGuessCheckService, GuessCheckService>();

            ServiceProvider serviceProvider = hostBuilder.Services.BuildServiceProvider();

            IGameService gameService = serviceProvider.GetRequiredService<IGameService>();
            gameService.Play();
        }
    }
}
