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
    public class CreditCardViewModel : INotifyPropertyChanged
    {
        private string _yourName { get; set; }
        private bool _isToggleOn { get; set; }
        private string _yourAmount { get; set; }
        private string _message { get; set; }
        private bool _isValid { get; set; }
        private CreditCardModel _creditCardModel { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string YourName { get => _yourName; set { _yourName = value; OnPropertyChanged(); } }
        public bool IsToggleOn { get => _isToggleOn; set { _isToggleOn = value; OnPropertyChanged(); } }
        public string YourAmount { get => _yourAmount; set { _yourAmount = value; OnPropertyChanged(); } }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Message { get => _message; set { _message = value; OnPropertyChanged(); } }
        public bool IsValid { get => _isValid; set { _isValid = value; OnPropertyChanged(); } }
        public event EventHandler<ValidateUserCreditDetalsEventArgs> ValidateUserCreditDetals;
        public ICommand NavigatNextPage { get; private set; }
        public ICommand ShowUserInfo { get; private set; }
        public CreditCardViewModel() 
        {
            NavigatNextPage = new Command(LoadNextPage);
            ShowUserInfo = new Command(ShowUserDetails);
            _creditCardModel = new CreditCardModel();   
            
        }

        private void ShowUserDetails()
        {
            _creditCardModel.Name = Name;
            if (!string.IsNullOrEmpty(Amount))
            {
                _creditCardModel.Amount = double.Parse(Amount);
            }
            else
            {
                _creditCardModel.Amount = 0;
            }
            _creditCardModel.IsToggleOn = IsToggleOn;
            _creditCardModel.ShowYourDetails();
            YourName = _creditCardModel.YourName;
            IsToggleOn = _creditCardModel.IsToggleOn;
            YourAmount = _creditCardModel.YourAmount;

        }

        private void LoadNextPage()
        {
           _creditCardModel.Name = Name;
            if (!string.IsNullOrEmpty(Amount))
            {
                _creditCardModel.Amount = Double.Parse(Amount);
            }
            else
            {
                _creditCardModel.Amount = 0;
            }

            _creditCardModel.ValidateUserDetail();
            IsValid = _creditCardModel.IsValid;
            Message = _creditCardModel.Message;
            ValidateUserCreditDetals?.Invoke(this,new ValidateUserCreditDetalsEventArgs() { ErrorMessage = Message,IsValiInfo = IsValid });
            YourName = _creditCardModel.YourName;
            YourAmount = _creditCardModel.YourAmount;

        }

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class ValidateUserCreditDetalsEventArgs : EventArgs
        {
            public string ErrorMessage { get; set; }
            public bool IsValiInfo { get; set; }

        }
    }
   
}
