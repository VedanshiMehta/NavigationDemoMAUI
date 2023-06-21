using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C4_Exercises.ViewModel
{
    public class PrintInvoiceViewModel :INotifyPropertyChanged
    {
        private string _productName { get; set; }
        private string _purchaseDate { get; set; }

        private string _purchaseTime { get; set; }
        private string _premiumCustomer { get; set; }

        private string _customerName { get; set; }
        private string _customerPhoneNumber { get; set; }
        private string _customerAddress { get; set; }

        private string _proudctQuantity { get; set; }
        private string _proudctAmount { get; set; }
        private string _prouductTax { get; set; }


        public string ProductName { get => _productName; set { _productName = value; OnPropertyChanged(); } }
        public string PurchaseDate { get => _purchaseDate; set { _purchaseDate = value; OnPropertyChanged(); } }

        public string PurchaseTime { get => _purchaseTime; set { _purchaseTime = value; OnPropertyChanged(); } }
        public string PremiumCustomer { get => _premiumCustomer; set { _premiumCustomer = value; OnPropertyChanged(); } }

        public string CustomerName { get => _customerName; set { _customerName = value; OnPropertyChanged(); } }
        public string CustomerPhoneNumber { get => _customerPhoneNumber; set { _customerPhoneNumber = value; OnPropertyChanged(); } }
        public string CustomerAddress { get => _customerAddress; set { _customerAddress = value; OnPropertyChanged(); } }

        public string ProudctQuantity { get => _proudctQuantity; set { _proudctQuantity = value; OnPropertyChanged(); } }
        public string ProudctAmount { get => _proudctAmount; set { _proudctAmount = value; OnPropertyChanged(); } }
        public string ProuductTax { get => _prouductTax; set { _prouductTax = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
