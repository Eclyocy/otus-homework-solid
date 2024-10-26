using GuessingGame.Interfaces;

namespace GuessingGame.Services
{
    public class GeneratorService : IGeneratorService
    {
        private readonly Random _random = new();

        public GeneratorService()
        {
        }

        public int GenerateValue(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue + 1);
        }
    }
}
