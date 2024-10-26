namespace GuessingGame.Interfaces
{
    public interface IUserInteractionService
    {
        int ReadValue();

        void WriteMessage(string message);
    }
}
