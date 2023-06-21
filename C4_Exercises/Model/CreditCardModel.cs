using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Exercises.Model
{
    public class CreditCardModel
    {
        private string _message;
        public string YourName { get; set; }
        public bool IsToggleOn { get; set; }    
        public string YourAmount { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Message { get; set; }
        public bool IsValid { get;set; }

        public void ValidateUserDetail()
        {
            if(IsValidUserName() && IsValidAmount())
            {
                IsValid = true;
                Message =string.Empty;
                ShowYourDetails();
            }
            else if(!IsValidUserName() || !IsValidAmount())
            {
                IsValid = false;
                Message = _message;
            }
        }

        public void ShowYourDetails()
        {
            if(IsToggleOn)
            {
                YourName = Name;
                YourAmount = Amount.ToString();
            }
            else if(!IsToggleOn) 
            {
                YourName = string.Empty;
                YourAmount = string.Empty;
            }
            
        }

        private bool IsValidAmount()
        {
            if(Amount == 0)
            {
                _message = "Enter amount";
                return false;
            }
            _message = string.Empty;
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
