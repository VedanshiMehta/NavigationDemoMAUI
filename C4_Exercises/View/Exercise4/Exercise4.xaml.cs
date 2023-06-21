
using C4_Exercises.Model;
using CommunityToolkit.Maui.Alerts;

namespace C4_Exercises.View.Exercise4;

public partial class Exercise4 : ContentPage
{
	private PrintInvoiceModel _printInvoiceModel;
	public Exercise4()
	{
		InitializeComponent();
		_printInvoiceModel = new PrintInvoiceModel();
        _printInvoiceModel.PremiumCustomer = "No";
    }

    private void IsPremiumCustomer_Toggled(object sender, ToggledEventArgs e)
    {
        
        if (e.Value)
        {
            _printInvoiceModel.PremiumCustomer = "Yes";
        }
        else
        {
            _printInvoiceModel.PremiumCustomer = "No";
        }
    }


    private async void GenerateInvoice_Clicked(object sender, EventArgs e)
    {

        _printInvoiceModel.ProductName = enterProduct.Text;
        _printInvoiceModel.PurchaseDate = enterPurchaseDate.Date.ToString("dd-MMM-yyyy");
         DateTime dateTime = DateTime.Today.Add(enterPurchaseTime.Time);
        _printInvoiceModel.PurchaseTime = dateTime.ToString("hh:mm tt");
        _printInvoiceModel.CustomerName = enterCustomerName.Text;
        _printInvoiceModel.CustomerPhoneNumber = enterCustomerMobileNumber.Text;
        _printInvoiceModel.CustomerAddress = enterCustomerAddress.Text;
        _printInvoiceModel.ProudctQuantity = int.Parse(selectedProductQuantity.Text);
        _printInvoiceModel.ProudctAmount = double.Parse(enterAmount.Text);
        _printInvoiceModel.ProuductTax = double.Parse(enterTax.Text);
        if(_printInvoiceModel.ProductName != null && _printInvoiceModel.PurchaseDate != null && _printInvoiceModel.PurchaseTime!= null
            && _printInvoiceModel.CustomerName!= null && _printInvoiceModel.CustomerPhoneNumber != null && _printInvoiceModel.CustomerAddress != null
            && _printInvoiceModel.ProudctQuantity  != 0 && _printInvoiceModel.ProudctAmount != 0 && _printInvoiceModel.ProuductTax!= 0)
        {
            await Navigation.PushAsync(new PrintInvoice(_printInvoiceModel));
        }
        else
        {
            await Toast.Make("Enter details", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }


    }

    
}