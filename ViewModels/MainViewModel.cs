using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIEden.Models;
using MAUIEden.Services;
using MAUIEden.Utilities;
using System.Collections.ObjectModel;

namespace MAUIEden.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty] Language selectedLanguage;
        [ObservableProperty] ObservableCollection<Language> languages = Constants.Languages.LanguagesList;

        public MainViewModel()
        {
            SelectedLanguage = Languages.FirstOrDefault();
        }

        [RelayCommand]
        async Task StartGame()
        {
            if (SelectedLanguage == null)
            {
                SelectedLanguage = Languages.FirstOrDefault();
            }
            await Shell.Current.GoToAsync($"{nameof(GamePage)}",
                true,
                new Dictionary<string, object> {
                    { "SelectedLanguage", SelectedLanguage }
                });
        }
    }
}