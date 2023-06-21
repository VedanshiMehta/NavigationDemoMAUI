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
    public class TrainInformationViewModel : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<ValidateEventArgs> Validate;
        private string _yourLocation { get; set; }
        private string _destinationLocation { get; set; }
        private string _location1 { get; set; }
        private string _location2 { get; set; }
        private string _message { get; set; }
        private bool _isValid { get; set; }
        private TrainIformationModel _trainIformationModel;
        public string YourLocation { get => _yourLocation; set { _yourLocation = value; OnPropertyChanged(); } }
        public string DestinationLocation { get => _destinationLocation; set { _destinationLocation = value; OnPropertyChanged(); } }

        public string Location1 { get=>_location1; set { _location1 = value; OnPropertyChanged(); } }
        public string Location2 { get => _location2; set { _location2 = value; OnPropertyChanged(); } }
        public string Message { get => _message; set { _message = value; OnPropertyChanged(); } }
        public bool IsValid { get => _isValid; set { _isValid = value; OnPropertyChanged(); } }

        public ICommand SearchTrain {  get; private set; }

        public  ICommand SwapLocation { get; private set; }
        public TrainInformationViewModel()
        {
            SearchTrain = new Command(GetTrainDetails);
            SwapLocation = new Command(SwapLocationDetails);
            _trainIformationModel = new TrainIformationModel();
        }

        private void SwapLocationDetails()
        {
            _trainIformationModel.YourLocation = YourLocation;
            _trainIformationModel.DestinationLocation = DestinationLocation;
            _trainIformationModel.SwapLocation();
            Message = _trainIformationModel.Message;
            IsValid = _trainIformationModel.IsValid;
            Validate.Invoke(this,new ValidateEventArgs() { CheckValid = IsValid,ToastMessage = Message});
            
            YourLocation = _trainIformationModel.YourLocation;
            DestinationLocation = _trainIformationModel.DestinationLocation;
        }

        private void GetTrainDetails()
        {
            _trainIformationModel.YourLocation = YourLocation;
            _trainIformationModel.DestinationLocation = DestinationLocation;
            _trainIformationModel.TrainTicketDetails();
            
            Message = _trainIformationModel.Message;
            IsValid = _trainIformationModel.IsValid;
            Validate.Invoke(this, new ValidateEventArgs() { CheckValid = IsValid, ToastMessage = Message });
            Location1 = _trainIformationModel.Location1;
            Location2 = _trainIformationModel.Location2;
        }

        public void OnPropertyChanged([CallerMemberName]string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ValidateEventArgs : EventArgs
    {
        public bool CheckValid { get; set; }
        public string ToastMessage { get; set; }
    }
}
