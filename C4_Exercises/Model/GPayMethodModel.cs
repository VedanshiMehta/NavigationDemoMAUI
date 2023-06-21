using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Exercises.Model
{
    public class GPayMethodModel
    {
        private string _message { get; set; }
        public string PayAmount { get; set; }
        public string PaidtoName { get; set; }
        public string PayeeName { get; set; }
        public double Amount { get; set; }  

        public string Message { get; set; } 
        public bool IsValid { get; set; }

        public void ValidatePayeeDetails()
        {
            if (IsValidPayee() && IsValidAmount())
            {
                IsValid = true;
                Message = string.Empty;
                PaidtoName = PayeeName;
                PayAmount = Amount.ToString();
            }
            else if (!IsValidPayee() || !IsValidAmount())
            {
                IsValid = false;
                Message = _message;
            }
        }

        private bool IsValidAmount()
        {
            if(Amount == 0)
            {
                _message = "Enter valid amount";
                return false;
            }
            _message = string.Empty;
            return true;
        }

        private bool IsValidPayee()
        {
            if (string.IsNullOrEmpty(PayeeName))
            {
                _message = "Enter payee name";
                return false;
            }
            _message = string.Empty;
            return true;
        }
    }
}
