using GuessingGame.Models;

namespace GuessingGame.Interfaces
{
    public interface IGuessCheckService
    {
        /// <summary>
        /// Compares the <paramref name="userGuess"/> to the <paramref name="target"/>.
        /// </summary>
        GuessResult CompareTo(int userGuess, int target);
    }
}
