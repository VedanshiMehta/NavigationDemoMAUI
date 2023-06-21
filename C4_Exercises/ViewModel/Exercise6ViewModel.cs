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
    class Exercise6ViewModel : INotifyPropertyChanged
    {
      
        private bool _isCredit = true;

       

        private bool _isDebit { get; set; }
        private bool _isGpay { get; set; }
        public bool IsCredit { get => _isCredit; set { _isCredit = value; OnPropertyChanged(); } }
        public bool IsDebit { get => _isDebit; set { _isDebit = value; OnPropertyChanged(); } }
        public bool IsGpay { get => _isGpay; set { _isGpay = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<Exercise6EventArgs> NavigateToNextPage;

        public ICommand NextPage { get; private set; }
       

        public Exercise6ViewModel()
        {
            NextPage = new Command(GetNextPage);
        }

        private void GetNextPage()
        {
            if(IsCredit)
            {
                NavigateToNextPage?.Invoke(this,new Exercise6EventArgs() { IsCredit = true, IsDebit = false, IsGpay = false });
            }
            else if (IsDebit)
            {
                NavigateToNextPage?.Invoke(this, new Exercise6EventArgs() { IsCredit = false, IsDebit = true, IsGpay = false });
            }
            else if(IsGpay)
            {
                NavigateToNextPage?.Invoke(this, new Exercise6EventArgs() { IsCredit = false, IsDebit = false, IsGpay = true });
            }
        }

        public void OnPropertyChanged([CallerMemberName]string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }

    public class Exercise6EventArgs : EventArgs
    {
        public bool IsCredit { get; set; }
        public bool IsDebit { get; set; }
        public bool IsGpay { get; set;}
    }
}
