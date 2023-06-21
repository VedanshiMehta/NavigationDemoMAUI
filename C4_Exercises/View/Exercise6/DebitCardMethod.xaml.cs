using C4_Exercises.Model;
using C4_Exercises.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace C4_Exercises.View.Exercise6;


public partial class DebitCardMethod : ContentPage
{
	private DebitCardViewModel _debitCardViewModel;
    private PaymentSuccesfullModel _paymentSuccesfullModel;
	public DebitCardMethod()
	{
		InitializeComponent();
        _paymentSuccesfullModel = new PaymentSuccesfullModel();
		_debitCardViewModel = (DebitCardViewModel)BindingContext;
        _debitCardViewModel.ValidateDebitCardUserInfo += DebitCardViewModel_ValidateDebitCardUserInfo;
	}

    private async void DebitCardViewModel_ValidateDebitCardUserInfo(object sender, ValidateUserDebitDetalsEventArgs e)
    {
        if (e.IsValiInfo)
        {
            _paymentSuccesfullModel.Amount = _debitCardViewModel.Amount;
            _paymentSuccesfullModel.PaymentMethod = "Payment Successfull via Debit Card";
            await Task.Delay(3000);
            await Navigation.PushAsync(new PaymentSuccessful(_paymentSuccesfullModel));
        }
        else if (!e.IsValiInfo)
        {
            await Toast.Make(e.ErrorMessage, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }

    private void SaveUserInfromation_Toggled(object sender, ToggledEventArgs e)
    {
        _debitCardViewModel.SaveUserInfo.Execute(this);
    }
}