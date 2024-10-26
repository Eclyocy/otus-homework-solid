using GuessingGame.Interfaces;

namespace GuessingGame.Services
{
    public class UserInteractionService : IUserInteractionService
    {
        /// <inheritdoc/>
        public int ReadValidatedValue(int minValue, int maxValue)
        {
            while (true)
            {
                string? userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int result))
                {
                    if (minValue > result || maxValue < result)
                    {
                        WriteMessage($"The number should be inside [{minValue}, {maxValue}]. Please, try again.");

                        continue;
                    }

                    return result;
                }

                WriteMessage($"Sorry, your input ({userInput ?? "null"}) was not recognized. Please, try again.");
            }
        }

        /// <inheritdoc/>
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
