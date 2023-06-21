using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Exercises.Model
{
    public class PrintInvoiceModel
    {
        public string ProductName { get; set; }
        public string PurchaseDate { get; set; }

        public string PurchaseTime { get; set; }
        public string PremiumCustomer { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }

        public int ProudctQuantity { get; set; }
        public double ProudctAmount { get; set; }
        public double ProuductTax { get; set;}

    }
}
