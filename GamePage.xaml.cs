using MAUIEden.ViewModels;

namespace MAUIEden;

public partial class GamePage : ContentPage
{
	public GamePage(GameViewModel gameViewModel)
	{
		InitializeComponent();
		BindingContext = gameViewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		if (BindingContext is  GameViewModel gameViewModel)
		{
			await gameViewModel.GameState.StartGame(gameViewModel.SelectedLanguage.Code);
		}
	}
}