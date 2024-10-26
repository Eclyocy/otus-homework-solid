using GuessingGame.Interfaces;
using GuessingGame.Models;

namespace GuessingGame.Services
{
    public class GuessCheckService : IGuessCheckService
    {
        /// <inheritdoc/>
        public GuessResult CompareTo(int userGuess, int target)
        {
            return userGuess.CompareTo(target) switch
            {
                0 => GuessResult.Correct,
                > 0 => GuessResult.TooHigh,
                _ => GuessResult.TooLow
            };
        }
    }
}
