namespace GuessingGame.Interfaces
{
    public interface IGuessCheckService
    {
        int CompareTo(int userGuess, int target);
    }
}
