using GuessingGame.Interfaces;
using GuessingGame.Models;
using GuessingGame.Settings;
using Microsoft.Extensions.Options;

namespace GuessingGame.Services
{
    public class GameService : IGameService
    {
        private readonly IGuessCheckService _guessCheckService;
        private readonly IUserInteractionService _userInteractionService;

        private readonly int _maxAttempts;
        private readonly int _minValue;
        private readonly int _maxValue;

        private readonly int _value;

        private readonly GameResult _gameResult;

        public GameService(
            IGeneratorService generatorService,
            IGuessCheckService guessCheckService,
            IUserInteractionService userInteractionService,
            IOptions<GameSettings> gameSettingsOptions)
        {
            _guessCheckService = guessCheckService;
            _userInteractionService = userInteractionService;

            GameSettings gameSettings = gameSettingsOptions.Value;
            _minValue = gameSettings.MinValue;
            _maxValue = gameSettings.MaxValue;
            _maxAttempts = gameSettings.MaxAttempts;

            _value = generatorService.GenerateValue(_minValue, _maxValue);

            _gameResult = new()
            {
                IsUserWin = false,
                AttemptsUsed = 0,
                AttemptsTotal = _maxAttempts,
                TargetNumber = _value
            };
        }

        public GameResult Play()
        {
            _userInteractionService.WriteMessage("Welcome to the game!");
            _userInteractionService.WriteMessage(
                $"You have {_maxAttempts} attempts to guess a number between {_minValue} and {_maxValue}.");

            for (int i = 1; i <= _maxAttempts; i++)
            {
                _userInteractionService.WriteMessage($"Attempt number {i}: ");

                int userGuess = _userInteractionService.ReadValue(_minValue, _maxValue);
                _gameResult.AttemptsUsed++;

                GuessResult attemptResult = _guessCheckService.Check(userGuess, _value);
                string attemptMessage = GetMessage(attemptResult);

                _userInteractionService.WriteMessage(attemptMessage);

                if (attemptResult == GuessResult.Correct)
                {
                    _gameResult.IsUserWin = true;

                    return _gameResult;
                }
            }

            _userInteractionService.WriteMessage("Sorry, you are out of attempts.");
            _userInteractionService.WriteMessage($"The number was {_value}.");

            return _gameResult;
        }

        private string GetMessage(GuessResult result) => result switch
        {
            GuessResult.Correct => $"Congratulations! You have guessed the value {_value} correctly!",
            GuessResult.TooHigh => "Your guess is higher than the target.",
            GuessResult.TooLow => "Your guess is lower than the target.",
            _ => throw new ArgumentOutOfRangeException(nameof(result), $"{result} is not supported.")
        };
    }
}
