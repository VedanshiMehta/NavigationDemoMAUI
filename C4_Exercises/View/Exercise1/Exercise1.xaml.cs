using C4_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C4_Exercises;

public partial class MainPage : ContentPage
{

	private TrainInformationViewModel _trainInformationViewModel;
	public MainPage()
	{


		InitializeComponent();
		_trainInformationViewModel = (TrainInformationViewModel)BindingContext;
        _trainInformationViewModel.Validate += _trainInformationViewModel_Validate;

	}

    private void _trainInformationViewModel_Validate(object sender, ValidateEventArgs e)
    {
        if(!e.CheckValid)
        {
            Toast.Make(e.ToastMessage, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }

}


