using MAUIEden.ViewModels;

namespace MAUIEden;

public partial class EndScreenPage : ContentPage
{
	public EndScreenPage(EndScreenViewModel endScreenViewModel)
	{
		InitializeComponent();
		BindingContext = endScreenViewModel;
	}
}