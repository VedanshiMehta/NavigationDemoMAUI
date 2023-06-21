using C4_Exercises.Model;
using C4_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C4_Exercises.View.Exercise6;

public partial class CreditCardMethod : ContentPage
{
	private CreditCardViewModel _creditCardViewModel;
	private PaymentSuccesfullModel _paymentSuccesfullModel;
	public CreditCardMethod()
	{
		InitializeComponent();
		
		_creditCardViewModel = (CreditCardViewModel)BindingContext;
		_creditCardViewModel.ValidateUserCreditDetals += CreditCardViewModel_ValidateUserCreditDetals;
        _paymentSuccesfullModel = new PaymentSuccesfullModel();
    }

    private async void CreditCardViewModel_ValidateUserCreditDetals(object sender, CreditCardViewModel.ValidateUserCreditDetalsEventArgs e)
    {
        if(e.IsValiInfo)
		{
			_paymentSuccesfullModel.Amount = _creditCardViewModel.Amount;
			_paymentSuccesfullModel.PaymentMethod = "Payment Successfull via Credit Card";
			await Task.Delay(3000);
			await Navigation.PushAsync(new PaymentSuccessful(_paymentSuccesfullModel));
        }
		else if (!e.IsValiInfo) 
		{ 
			await Toast.Make(e.ErrorMessage,CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }

    private void SaveCardInfromation_Toggled(object sender, ToggledEventArgs e)
    {
		_creditCardViewModel.ShowUserInfo.Execute(this);
    }
}