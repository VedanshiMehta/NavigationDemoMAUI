using C4_Exercises.Model;
using C4_Exercises.ViewModel;

namespace C4_Exercises.View.Exercise3;

public partial class Dashboard : ContentPage
{
	private PlayerDetailsViewModel _playerDetailsViewModel;
	public Dashboard(Model.PlayerRegistrationModel playerRegistrationModel)
	{
		InitializeComponent();
		_playerDetailsViewModel = (PlayerDetailsViewModel)BindingContext;
		_playerDetailsViewModel.PlayerRegistrationModel = playerRegistrationModel;

	}

   

    private async void ChangePlayerName_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
		

    }

    private async void GoToWelcome_Clicked(object sender, EventArgs e)
    {
		await  Navigation.PopToRootAsync();
    }
}