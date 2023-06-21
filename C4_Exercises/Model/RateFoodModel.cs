using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_Exercises.Model
{
    public class RateFoodModel
    {
        public ImageSource Image { get; set; }
        public double RateValue { get; set; }  
        
        public string Rating { get; set; }

        public Color Color { get; set; }

        public void RateMe()
        {
            var rate = Math.Round(RateValue);
            if(rate >= 0 && rate <= 10)
            {
                Image = ImageSource.FromFile("hateit.png");
                Color = Color.Parse("#CC5B5D");
                Rating = "Hate it";
            }
            else if(rate >= 11 && rate <= 20) 
            {
                Image = ImageSource.FromFile("wasok.png");
                Color = Color.Parse("#FEC0CB");
                Rating = "Was Ok";
            }
            else if(rate >= 21 && rate <=30) 
            {
                Image = ImageSource.FromFile("loveit.png");
                Color = Color.Parse("#AED8E5");
                Rating = "Love It";
            }
        }
    }
}
