using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C4_Exercises.ViewModel
{
    public class FeedbackViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ImageSource _feedbackImage { get; set; }
        private Color _textColor { get; set; }
        private string _rating { get; set; }
        public ImageSource FeedbackImage { get => _feedbackImage; set { _feedbackImage = value; OnPropertyChanged(); } }
        public Color TextColor { get => _textColor; set { _textColor = value; OnPropertyChanged(); } }

        public string Rating { get => _rating; set { _rating = value; OnPropertyChanged(); } }
        public void OnPropertyChanged([CallerMemberName]string propreryName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propreryName));
        }
    }
}
