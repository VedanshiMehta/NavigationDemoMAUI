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
    public class FurnitureInfoViewModel : INotifyPropertyChanged
    {

        private string _message { get; set; }
        private bool _isValid { get; set; }
        private FurnitureInfoModel _model { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public event EventHandler<ValidateUserEventArgs> ValidateUser;
        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get => _message; set { _message = value;OnPropertyChanged(); } }
        public bool IsValid { get => _isValid; set { _isValid = value; OnPropertyChanged(); } }

        public ICommand SignIn { get; private set; }
        public FurnitureInfoViewModel()
        {
            SignIn = new Command(GoNextPage);
            _model = new FurnitureInfoModel();
        }

        private void GoNextPage()
        {
            _model.Email = Email;
            _model.Password = Password;
            _model.ValidateUser();
            IsValid = _model.IsValid;
            Message = _model.Message;
            ValidateUser?.Invoke(this,new ValidateUserEventArgs() { ErrorMessage = Message ,IsValiInfo = IsValid});
        }

        public void OnPropertyChanged([CallerMemberName]string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ValidateUserEventArgs:EventArgs 
    { 
        public string ErrorMessage { get; set; }
        public bool IsValiInfo { get; set; }
    
    }

}
