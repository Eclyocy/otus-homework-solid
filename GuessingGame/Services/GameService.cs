﻿using GuessingGame.Interfaces;
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
        }

        public void Play()
        {
            _userInteractionService.WriteMessage("Welcome to the game!");
            _userInteractionService.WriteMessage(
                $"You have {_maxAttempts} attempts to guess a number between {_minValue} and {_maxValue}.");

            for (int i = 1; i <= _maxAttempts; i++)
            {
                _userInteractionService.WriteMessage($"Attempt number {i}: ");

                int userGuess = _userInteractionService.ReadValue();

                int comparison = _guessCheckService.CompareTo(userGuess, _value);

                if (comparison == 0)
                {
                    _userInteractionService.WriteMessage($"Congratulations! You have guessed correctly the {_value}!");
                    return;
                }
                else if (comparison > 0)
                {
                    _userInteractionService.WriteMessage($"The target number is lower.");
                }
                else
                {
                    _userInteractionService.WriteMessage($"The target number is higher.");
                }
            }

            _userInteractionService.WriteMessage("Sorry, you are out of attempts.");
            _userInteractionService.WriteMessage($"(By the way, the number is {_value}.)");
        }
    }
}
