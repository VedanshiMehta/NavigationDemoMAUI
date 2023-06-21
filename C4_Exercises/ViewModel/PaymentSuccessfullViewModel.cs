using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C4_Exercises.ViewModel
{
    public class PaymentSuccessfullViewModel : INotifyPropertyChanged
    {
        private string _amount { get; set; }
        private string _paymentMethod { get; set; }
        public string Amount { get => _amount; set { _amount = value; OnpropertyChanged(); } }
        public string PaymentMethod { get => _paymentMethod; set { _paymentMethod = value; OnpropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnpropertyChanged([CallerMemberName]string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
