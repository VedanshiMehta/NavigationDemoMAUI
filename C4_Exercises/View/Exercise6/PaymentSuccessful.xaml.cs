using C4_Exercises.ViewModel;

namespace C4_Exercises.View.Exercise6;

public partial class PaymentSuccessful : ContentPage
{
	private PaymentSuccessfullViewModel _paymentSuccessfullViewModel;
	public PaymentSuccessful(Model.PaymentSuccesfullModel _paymentSuccesfullModel)
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
		NavigationPage.SetBackButtonTitle(this, null);
        _paymentSuccessfullViewModel = (PaymentSuccessfullViewModel)BindingContext;
		_paymentSuccessfullViewModel.Amount = _paymentSuccesfullModel.Amount;
		_paymentSuccessfullViewModel.PaymentMethod = _paymentSuccesfullModel.PaymentMethod;


	}
    protected  override  bool OnBackButtonPressed()
    {

        RemovePreviousPagePage(); 
        return base.OnBackButtonPressed();
    }

    private  async void GoToStartPage()
    {
        await Navigation.PopToRootAsync();
    }
    private void RemovePreviousPagePage()
    {
        var firstPage = Navigation.NavigationStack.ElementAtOrDefault(1);
        if (firstPage != null)
        {
            Navigation.RemovePage(firstPage);
        }

    }
    private void GotIt_Clicked(object sender, EventArgs e)
    {
        GoToStartPage();
    }
}