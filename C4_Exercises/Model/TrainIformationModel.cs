using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Exercises.Model
{
    public class TrainIformationModel
    {

        private string _temp;
        private string _message;
        public string YourLocation { get; set; }
        public string DestinationLocation { get; set; }

        public string Location1 { get; set; }


        public string Location2 { get; set; }
        public string Message { get; set; }
        public bool IsValid { get; set; }


        public void TrainTicketDetails()
        {
            if (IsValidYourLocation() && IsValidDestinationLocation())
            {
                IsValid = true;
                GetDetails();

            }
            else if(!IsValidYourLocation() || !IsValidDestinationLocation()) 
            {
                Message = _message;
                IsValid = false;
                
            }
        }

        public void SwapLocation()
        {
            if (IsValidYourLocation() && IsValidDestinationLocation())
            {
                IsValid = true;
                SwapBothLocation();               
                

            }
            else if (!IsValidYourLocation() ||!IsValidDestinationLocation())
            {
                Message = _message;
                IsValid = false;
                
            }
        }

        private void SwapBothLocation()
        {
           _temp = YourLocation;
            YourLocation = DestinationLocation;
            DestinationLocation = _temp;
        }

        private void GetDetails()
        {
            Location1 = YourLocation;
            Location2 = DestinationLocation;
        }

        private bool IsValidDestinationLocation()
        {
            if (string.IsNullOrEmpty(DestinationLocation))
            {
                _message = "Enter your destination location.";
                return false;
            }
            _message = string.Empty;
            return true;

        }

        private bool IsValidYourLocation()
        {
            if (string.IsNullOrEmpty(YourLocation))
            {
                _message = "Enter your location.";
                return false;
            }
            _message = string.Empty;
            return true;
        }
    }
}
