using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUIEden.Utilities
{
    public partial class UIManager : ObservableObject
    {
        [ObservableProperty] bool showStartScreen = true;
        [ObservableProperty] bool showEndScreen = false;
        [ObservableProperty] bool gameIsActive = false;
        public void GoToHome()
        {
            ShowStartScreen = true;
            ShowEndScreen = false;
            GameIsActive = false;
        }

        public void GoToEndScreen()
        {
            ShowStartScreen = false;
            ShowEndScreen = true;
            GameIsActive = false;
        }

        public void GoToGameScreen()
        {
            ShowStartScreen = false;
            ShowEndScreen = false;
            GameIsActive = true;
        }
    }
}
