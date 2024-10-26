namespace GuessingGame.Interfaces
{
    public interface IUserInteractionService
    {
        int ReadValue(int minValue, int maxValue);

        void WriteMessage(string message);
    }
}
