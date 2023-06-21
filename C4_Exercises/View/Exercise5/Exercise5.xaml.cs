using C4_Exercises.Model;
using C4_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C4_Exercises.View.Exercise5;

public partial class Exercise5 : ContentPage
{
	private FurnitureInfoViewModel _viewModel;
	public Exercise5()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
		_viewModel = (FurnitureInfoViewModel)BindingContext;
        _viewModel.ValidateUser += ViewModel_ValidateUser;

	}

    private async void ViewModel_ValidateUser(object sender, ValidateUserEventArgs e)
    {
        if(e.IsValiInfo)
		{
            await Toast.Make(e.ErrorMessage, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
			await Navigation.PushAsync(new UserDashboard());
			RemoveCurrentPage();
		}
		else if(!e.IsValiInfo)
		{
            await Toast.Make(e.ErrorMessage, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }

    private void RemoveCurrentPage()
    {
        var firstPage = Navigation.NavigationStack.ElementAtOrDefault(0);
        if (firstPage != null)
        {
            Navigation.RemovePage(firstPage);
        }

    }
}