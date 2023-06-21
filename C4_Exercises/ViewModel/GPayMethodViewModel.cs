using C4_Exercises.Model;
using C4_Exercises.View.Exercise6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C4_Exercises.ViewModel
{
    public class GPayMethodViewModel: INotifyPropertyChanged
    {
        private string _message { get; set; }
        private bool _isValid { get; set; }
        private string _payAmount { get; set; }
        private string _paidtoName { get; set; }
        private GPayMethodModel _gPayMethodModel;

       
        public string PayAmount { get=>_payAmount; set { _payAmount = value; OnPropertyChanged(); } }
        public string PaidtoName { get => _paidtoName; set { _paidtoName = value; OnPropertyChanged(); } }
        public string PayeeName { get; set; }
        public string Amount { get; set; }

        public string Message { get => _message; set { _message = value; OnPropertyChanged(); } }
        public bool IsValid { get => _isValid; set { _isValid = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<ValidateGPayPayeeDteailsEventArgs> ValidateGPayPayeeDteails;

        public ICommand ProceedToPay { get; private set; }
        public GPayMethodViewModel()
        {
            ProceedToPay = new Command(GoToNextPage);
            _gPayMethodModel = new GPayMethodModel();
        }

        private void GoToNextPage()
        {
            _gPayMethodModel.PayeeName = PayeeName;
            if(!string.IsNullOrEmpty(Amount))
            {
                _gPayMethodModel.Amount = double.Parse(Amount);
            }
            else
            {
                _gPayMethodModel.Amount = 0;
            }
            _gPayMethodModel.ValidatePayeeDetails();
            IsValid = _gPayMethodModel.IsValid;
            Message = _gPayMethodModel.Message;
            ValidateGPayPayeeDteails?.Invoke(this,new ValidateGPayPayeeDteailsEventArgs() { ErrorMessage = Message, IsValiInfo = IsValid });
            PayAmount = _gPayMethodModel.PayAmount;
            PaidtoName = "Payment to "+_gPayMethodModel.PaidtoName;
        }

        public void OnPropertyChanged([CallerMemberName]string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ValidateGPayPayeeDteailsEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }
        public bool IsValiInfo { get; set; }

    }
}
