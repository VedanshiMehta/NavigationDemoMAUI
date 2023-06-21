using C4_Exercises.Model;
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
    public class DebitCardViewModel : INotifyPropertyChanged
    {
       


        private string _yourName { get; set; }
        private string _yourAccountNumber { get; set; }
        private string _yourDate { get; set; }
        private string _message { get; set; }
        private bool _isValid { get; set; }
        private bool _isToggleOn { get; set; }
        private DebitCardModel _debitCardModel;

        

        public string YourName { get => _yourName; set { _yourName = value; OnPropertyChanged(); } }
        public string YourAccountNumber { get => _yourAccountNumber; set { _yourAccountNumber = value; OnPropertyChanged(); } }
        public string YourDate { get => _yourDate; set { _yourDate = value; OnPropertyChanged(); } }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Amount { get; set; }
        public string CVV { get; set; }

        public DateTime Date { get; set; }

        public string Message { get => _message; set { _message = value; OnPropertyChanged(); } }
        public bool IsValid { get => _isValid; set { _isValid = value; OnPropertyChanged(); } }

        public bool IsToggleOn { get => _isToggleOn; set { _isToggleOn = value; OnPropertyChanged(); } }

        public ICommand PayUsingDebitCard { get; private set; }
        public ICommand SaveUserInfo { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<ValidateUserDebitDetalsEventArgs> ValidateDebitCardUserInfo;

        public DebitCardViewModel()
        {
            SaveUserInfo = new Command(GetUserInformation);
            PayUsingDebitCard = new Command(GoToPaymentSusscessfull);
            _debitCardModel = new DebitCardModel();
        }

        private void GetUserInformation()
        {
            _debitCardModel.Name = Name;
            _debitCardModel.AccountNumber = AccountNumber;
            _debitCardModel.Date = Date.ToString("MM/dd/yyyy");
            _debitCardModel.IsToggleOn = IsToggleOn;
            _debitCardModel.ShowYourDetails();
            IsToggleOn = _debitCardModel.IsToggleOn;
            YourAccountNumber = _debitCardModel.YourAccountNumber;
            YourName = _debitCardModel.YourName;
            YourDate = _debitCardModel.YourDate;
            

        }

        private void GoToPaymentSusscessfull()
        {

            _debitCardModel.Name = Name;
            _debitCardModel.AccountNumber = AccountNumber;
            if (!string.IsNullOrEmpty(Amount))
            {
                _debitCardModel.Amount = double.Parse(Amount);
            }
            else
            {
                _debitCardModel.Amount = 0;
            }
            _debitCardModel.Date = Date.ToString("MM/dd/yyyy");
            _debitCardModel.CVV = CVV;
            _debitCardModel.ValidateUserDebitInfromation();
            IsValid = _debitCardModel.IsValid;
            Message = _debitCardModel.Message;
            ValidateDebitCardUserInfo?.Invoke(this, new ValidateUserDebitDetalsEventArgs() { ErrorMessage = Message, IsValiInfo = IsValid });
            YourAccountNumber = _debitCardModel.YourAccountNumber;
            YourName = _debitCardModel.YourName;
            YourDate = _debitCardModel.YourDate;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ValidateUserDebitDetalsEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }
        public bool IsValiInfo { get; set; }

    }
}
