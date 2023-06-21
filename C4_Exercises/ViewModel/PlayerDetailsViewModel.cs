using C4_Exercises.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C4_Exercises.ViewModel
{
    class PlayerDetailsViewModel : INotifyPropertyChanged
    {
        private PlayerRegistrationModel playerRegistrationModel;

        public PlayerRegistrationModel PlayerRegistrationModel { get=> playerRegistrationModel; set { playerRegistrationModel = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
