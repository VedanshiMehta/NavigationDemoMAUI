using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C4_Exercises.Model
{
    class FurnitureInfoModel
    {
        private readonly Regex _emailRegex = new Regex(@"^(?=.{12,150}$)^[a-zA-Z]+([\.]?[a-zA-Z0-9])*@[a-zA-Z0-9]+([\.])([a-zA-Z]{2,3}|[a-zA-Z]{2}\.[a-zA-Z]{2,})$");
        private readonly Regex _passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\/!""#$%&'\\()*+,-.:;<=>?@[\]^_`{|}~])[A-Za-z\d\/!""#$%&'\\()*+,-.:;<=>?@[\]^_`{|}~]{8,12}$");
        private readonly string _email = "admin@gmail.com";
        private readonly string _password = "Admin#123";
        private string _message;
        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public bool IsValid { get; set; }

        public void ValidateUser()
        {
            if (IsValidEmail() && IsValidPassword())
            {
                Message = "Log in successfull";
                IsValid = true;

            }
            else if (!IsValidEmail() || !IsValidPassword())
            {
                Message = _message;
                IsValid = false;

            }
        }

        private bool IsValidPassword()
        {
            if (string.IsNullOrEmpty(Password))
            {
                _message = "Enter Password";
                return false;
            }
            else if (!ValidatePassword(Password))
            {
                _message = "Enter valid Password";
                return false;
            }
            else if (!Password.Equals(_password))
            {
                _message = "Password you entered is not found";
                return false;
            }
            _message = string.Empty;
            return true;
        }

        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;
            return _passwordRegex.IsMatch(password);
        }

        private bool IsValidEmail()
        {
            if(string.IsNullOrEmpty(Email))
            {
                _message = "Enter Email";
                return false;
            }
            else if(!ValidateEmail(Email))
            {
                _message = "Enter valid Email";
                return false;
            }
            else if(!Email.Equals(_email))
            {
                _message = "Email you entered is not found";
                return false;
            }
            _message = string.Empty;
           return true;
        }

        private bool ValidateEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
                return false;
            return _emailRegex.IsMatch(email);
        }
    }
}
