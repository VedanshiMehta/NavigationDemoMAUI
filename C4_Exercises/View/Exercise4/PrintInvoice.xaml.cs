using C4_Exercises.ViewModel;

namespace C4_Exercises.View.Exercise4;

public partial class PrintInvoice : ContentPage
{
	private PrintInvoiceViewModel _printInvoiceViewModel;
	public PrintInvoice(Model.PrintInvoiceModel printInvoiceModel)
	{
		InitializeComponent();
		_printInvoiceViewModel = (PrintInvoiceViewModel) BindingContext;
        _printInvoiceViewModel.ProductName = printInvoiceModel.ProductName;
        _printInvoiceViewModel.PurchaseDate = printInvoiceModel.PurchaseDate;
        _printInvoiceViewModel.PurchaseTime = printInvoiceModel.PurchaseTime;
        _printInvoiceViewModel.PremiumCustomer= printInvoiceModel.PremiumCustomer;
        _printInvoiceViewModel.CustomerName = printInvoiceModel.CustomerName;
        _printInvoiceViewModel.CustomerPhoneNumber = printInvoiceModel.CustomerPhoneNumber;
        _printInvoiceViewModel.CustomerAddress = printInvoiceModel.CustomerAddress;
        _printInvoiceViewModel.ProudctQuantity = printInvoiceModel.ProudctQuantity.ToString();
        _printInvoiceViewModel.ProudctAmount = printInvoiceModel.ProudctAmount.ToString();
        _printInvoiceViewModel.ProuductTax = printInvoiceModel.ProuductTax.ToString();
    }
}