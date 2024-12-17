using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIEden.Models;
using MAUIEden.Utilities;

namespace MAUIEden.ViewModels
{
    [QueryProperty("SelectedLanguage", "SelectedLanguage")]
    public partial class GameViewModel : BaseViewModel
    {
        [ObservableProperty] Language selectedLanguage;
        [ObservableProperty] GameState gameState;
        public GameViewModel(GameState gameState)
        {
            this.gameState = gameState;
        }

        [RelayCommand]
        void Clear() => GameState.Clear();

        [RelayCommand]
        void SkipCurrentWord() => GameState.SkipCurrentWord();

        [RelayCommand]
        void EndGame()
        {
            GameState.EndGame();
        }
    }
}
