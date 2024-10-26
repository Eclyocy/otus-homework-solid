using GuessingGame.Models;

namespace GuessingGame.Interfaces
{
    public interface IGuessCheckService
    {
        GuessResult Check(int userGuess, int target);
    }
}
