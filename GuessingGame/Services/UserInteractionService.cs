using GuessingGame.Interfaces;

namespace GuessingGame.Services
{
    public class UserInteractionService : IUserInteractionService
    {
        public int ReadValue()
        {
            while (true)
            {
                string? userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int result))
                {
                    return result;
                }
                else
                {
                    WriteMessage($"Sorry, your input ({userInput}) was not recognized. Please, try again.");
                }
            }
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
