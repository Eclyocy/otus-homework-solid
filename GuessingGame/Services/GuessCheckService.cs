using GuessingGame.Interfaces;

namespace GuessingGame.Services
{
    public class GuessCheckService : IGuessCheckService
    {
        public int CompareTo(int userGuess, int target)
        {
            return userGuess.CompareTo(target);
        }
    }
}
