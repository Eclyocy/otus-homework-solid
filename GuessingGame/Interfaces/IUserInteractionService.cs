namespace GuessingGame.Interfaces
{
    public interface IUserInteractionService
    {
        /// <summary>
        /// Read the user input until a valid <see cref="int"/> is given.
        /// The user input is validated to be at least <paramref name="minValue"/>
        /// and at most <paramref name="maxValue"/>.
        /// </summary>
        int ReadValidatedValue(int minValue, int maxValue);

        /// <summary>
        /// Outputs the <paramref name="message"/> to the user.
        /// </summary>
        void WriteMessage(string message);
    }
}
