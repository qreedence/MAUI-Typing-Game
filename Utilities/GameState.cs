using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIEden.Models;
using MAUIEden.Services;
using MAUIEden.ViewModels;
using System.Collections.ObjectModel;

namespace MAUIEden.Utilities
{
    public partial class GameState : ObservableObject
    {
        private readonly RandomWordService _randomWordService;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly Random _random = new Random();

        [ObservableProperty] string currentWord = "";
        [ObservableProperty] string currentlyTypingWord = "";
        [ObservableProperty] ObservableCollection<string> words = new ObservableCollection<string>();
        [ObservableProperty] int currentPoints = 0;
        [ObservableProperty] int timeRemaining = 0;
        [ObservableProperty] string longestWord = "";

        public GameState(RandomWordService randomWordService)
        {
            _randomWordService = randomWordService;
        }

        public async Task StartGame(string language)
        {
            InitializeGameState();

            var newWords = await _randomWordService.GetRandomWords(language, 400);
            foreach (string word in newWords)
            {
                Words.Add(word);
            }

            await GameLoop(_cancellationTokenSource.Token);
        }

        public void Clear()
        {
            CurrentlyTypingWord = "";
        }

        public void SkipCurrentWord()
        {
            Words.Remove(CurrentWord);
            CurrentlyTypingWord = "";
            CurrentWord = Words.ElementAt(_random.Next(0, Words.Count));
        }
        
        private async Task GameLoop(CancellationToken cancellationToken)
        {
            var countdown = CountDown(cancellationToken);
            while (Words.Count > 0 && TimeRemaining > 0)
            {
                CurrentWord = Words.ElementAt(_random.Next(0, Words.Count));
                
                var waitForCorrectWord = WaitForCorrectWord(cancellationToken);
                await Task.WhenAny(countdown, waitForCorrectWord);

                if (waitForCorrectWord.IsCompleted)
                {
                    if (CurrentWord.Length > LongestWord.Length)
                    {
                        LongestWord = CurrentWord;
                    }
                    Words.Remove(CurrentWord);
                    CurrentlyTypingWord = "";
                    CurrentPoints++;
                }
            }
        }

        private async Task CountDown(CancellationToken cancellationToken)
        {
            while (TimeRemaining > 0)
            {
                await Task.Delay(1000, cancellationToken);
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                TimeRemaining--;
            }
        }

        private async Task WaitForCorrectWord(CancellationToken cancellationToken)
        {
            while (TimeRemaining > 0 && CurrentlyTypingWord != CurrentWord)
            {
                await Task.Delay(100, cancellationToken);
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
            }
        }

        public void EndGame() => TimeRemaining = 0;

        private void InitializeGameState()
        {
            _cancellationTokenSource?.Cancel();
            TimeRemaining = 120;
            CurrentPoints = 0;
            CurrentWord = "";
            CurrentlyTypingWord = "";
            LongestWord = "";
            Words.Clear();
            _cancellationTokenSource = new CancellationTokenSource();
        }
    }
}
