
using C4_Exercises.Model;
using C4_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C4_Exercises.View.Exercise3;

public partial class RegistrationPage : ContentPage
{
    private PlayerRegistrationModel _playerRegistrationModel;

    public RegistrationPage()
	{
		InitializeComponent();
        _playerRegistrationModel = new PlayerRegistrationModel();

    }

    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {


        _playerRegistrationModel.Name = name.Text;
        _playerRegistrationModel.NickName = nickName.Text;

       

        if (_playerRegistrationModel.Name != null && _playerRegistrationModel.NickName!=null)
        {
            await Navigation.PushAsync(new Dashboard(_playerRegistrationModel));
            
        }
        else
        {
          await Toast.Make("Enter details",CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        
    }

    private async void GoBackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}