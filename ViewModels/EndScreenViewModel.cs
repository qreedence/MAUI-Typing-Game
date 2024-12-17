using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIEden.Models;

namespace MAUIEden.ViewModels
{
    [QueryProperty("GameResults", "GameResults")]
    public partial class EndScreenViewModel : BaseViewModel
    {
        [ObservableProperty] GameResults gameResults;

        [RelayCommand]
        async void GoHome() => await Shell.Current.GoToAsync("//MainPage", true);
    }
}
