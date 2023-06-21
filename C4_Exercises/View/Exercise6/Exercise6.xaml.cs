using C4_Exercises.ViewModel;

namespace C4_Exercises.View.Exercise6;

public partial class Exercise6 : ContentPage
{
	private Exercise6ViewModel _exercise6ViewModel;
	public Exercise6()
	{
		InitializeComponent();
		_exercise6ViewModel = (Exercise6ViewModel)BindingContext;
        _exercise6ViewModel.NavigateToNextPage += Exercise6ViewModel_NavigateToNextPage;
		
    }

    private async void Exercise6ViewModel_NavigateToNextPage(object sender, Exercise6EventArgs e)
    {
        if(e.IsCredit)
        {
            await Navigation.PushAsync(new CreditCardMethod());
        }
        else if(e.IsDebit)
        {
            await Navigation.PushAsync(new DebitCardMethod());
        }
        else if(e.IsGpay)
        {
            await Navigation.PushAsync(new GPayMethod());
        }
    }
}