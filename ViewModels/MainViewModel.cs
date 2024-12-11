﻿using CommunityToolkit.Mvvm.Collections;
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
        [ObservableProperty] GameState gameState;
        [ObservableProperty] UIManager uiManager;

        [ObservableProperty] Language selectedLanguage;
        [ObservableProperty] ObservableCollection<Language> languages = new ObservableCollection<Language>
        {
            new Language{Code = "en", Name = "🇬🇧 English"},
            new Language{Code = "es", Name = "🇪🇸 Spanish"},
            new Language{Code = "it", Name = "🇮🇹 Italian"},
            new Language{Code = "de", Name = "🇩🇪 German"},
            new Language{Code = "fr", Name = "🇫🇷 French"},
            new Language{Code = "zh", Name = "🇨🇳 Chinese"}
        };

        public MainViewModel(GameState gameState, UIManager uiManager)
        {
            this.gameState = gameState;
            this.uiManager = uiManager;
            SelectedLanguage = Languages.FirstOrDefault();
        }

        [RelayCommand]
        async Task StartGame()
        {
            if (SelectedLanguage == null)
            {
                SelectedLanguage = Languages.FirstOrDefault();
            }

            UiManager.GoToGameScreen();
            await GameState.StartGame(SelectedLanguage.Code);
            EndGame();
        }

        [RelayCommand]
        void Clear()
        {
            GameState.Clear();
        }

        [RelayCommand]
        void SkipCurrentWord()
        {
            GameState.SkipCurrentWord();
        }

        [RelayCommand]
        void EndGame()
        {
            UiManager.GoToEndScreen();
            GameState.EndGame();
        }

        [RelayCommand]
        void GoHome() => UiManager.GoToHome();
    }
}