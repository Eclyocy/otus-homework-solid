namespace GuessingGame.Models
{
    public class GameResult
    {
        public bool IsUserWin { get; set; }

        public int AttemptsUsed { get; set; }

        public int AttemptsTotal { get; set; }

        public int TargetNumber { get; set; }

        public override string ToString()
        {
            return string.Format(
                "User {0}. Attempts: {1}/{2}. Target: {3}.",
                IsUserWin ? "won" : "lost",
                AttemptsUsed,
                AttemptsTotal,
                TargetNumber);
        }
    }
}
