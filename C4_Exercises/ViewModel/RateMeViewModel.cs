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
    public class RateMeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _rating { get; set; }

        private Color _color { get; set; }
        private ImageSource _image { get; set; }
        private RateFoodModel _rateFoodModel;

        

        public ImageSource Image { get => _image; set { _image = value; OnPropertChanged(); } }
        public double RateValue { get; set; }

        public string Rating { get => _rating; set { _rating = value; OnPropertChanged(); } }

        public Color Color { get => _color; set { _color = value; OnPropertChanged(); } }

        public ICommand RateMe { get; private set; }
        public RateMeViewModel()
        {
            RateMe = new Command(GetRatedFoodDetails);
            _rateFoodModel = new RateFoodModel();
        }

        private void GetRatedFoodDetails()
        {
            _rateFoodModel.RateValue = RateValue;
            _rateFoodModel.RateMe();
            Color = _rateFoodModel.Color;
            Image = _rateFoodModel.Image;
            Rating = _rateFoodModel.Rating;

        }

        public void OnPropertChanged([CallerMemberName]string propetyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyname));    
        }
    }
}
