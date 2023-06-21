
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Exercises.Model
{
     public class DebitCardModel
     {
        private string _message;

        public string YourName { get; set; }
        public string YourAccountNumber { get; set; }   
        public string YourDate { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
        public string CVV { get; set; }
        
        public string Date { get; set; }

        public string Message { get; set; } 
        public bool IsValid { get; set; }   

        public bool IsToggleOn { get; set; }    

        public void ValidateUserDebitInfromation()
        {
            if (IsValidUserName() && IsValidAccountNumber() && IsValidAmount() &&  IsValidCvv() && IsValidDate())
            {
                IsValid = true;
                Message = string.Empty;
                ShowYourDetails();
            }
            else if (!IsValidUserName() || !IsValidAccountNumber() || !IsValidAmount() || !IsValidCvv() || !IsValidDate())
            {
                IsValid = false;
                Message = _message;
            }
        }

        private bool IsValidDate()
        {
            if (string.IsNullOrEmpty(Date))
            {
                _message = "Enter your expiry date";
                return false;
            }

            _message = string.Empty;
            return true;
        }

        private bool IsValidCvv()
        {
            if (string.IsNullOrEmpty(CVV))
            {
                _message = "Enter your cvv number";
                return false;
            }

            _message = string.Empty;
            return true;
        }

        private bool IsValidAccountNumber()
        {
            if(string.IsNullOrEmpty(AccountNumber))
            {
                _message = "Enter your account number";
                return false;
            }
          
            _message = string.Empty;
            return true;
        }

        public void ShowYourDetails()
        {
            if(IsToggleOn)
            {
                YourName = Name;
                YourAccountNumber = AccountNumber;
                YourDate = Date;
            }
            else if(!IsToggleOn)
            {
                YourName = string.Empty;
                YourAccountNumber = string.Empty;
                YourDate = string.Empty;
            }
        }

        private bool IsValidAmount()
        {
            if(Amount ==0)
            {
                _message = "Enter valid amount";
                return false;
            }
            return true;
        }

        private bool IsValidUserName()
        {
            if(string.IsNullOrEmpty(Name))
            {
                _message = "Enter your name";
                return false;
            }
            _message = string.Empty;
            return true;
        }
    }
}
