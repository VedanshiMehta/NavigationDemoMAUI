using C4_Exercises.Model;
using C4_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C4_Exercises.View.Exercise6;

public partial class GPayMethod : ContentPage
{
	private GPayMethodViewModel _gPayMethodViewModel;
	private PaymentSuccesfullModel _paymentSuccesfullModel;
	public GPayMethod()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this,false );
		NavigationPage.SetBackButtonTitle(this, null);
		_gPayMethodViewModel = (GPayMethodViewModel)BindingContext;	
		_paymentSuccesfullModel = new PaymentSuccesfullModel();
        _gPayMethodViewModel.ValidateGPayPayeeDteails += GPayMethodViewModel_ValidateGPayPayeeDteails;
	}

    private async void GPayMethodViewModel_ValidateGPayPayeeDteails(object sender, ValidateGPayPayeeDteailsEventArgs e)
    {
        if (e.IsValiInfo)
        {
            _paymentSuccesfullModel.Amount = _gPayMethodViewModel.Amount;
            _paymentSuccesfullModel.PaymentMethod = "Payment Successfull via G Pay";
            await Task.Delay(2000);
            
            await Navigation.PushAsync(new PaymentSuccessful(_paymentSuccesfullModel));
           
        }
        else if (!e.IsValiInfo)
        {
            await Toast.Make(e.ErrorMessage, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}