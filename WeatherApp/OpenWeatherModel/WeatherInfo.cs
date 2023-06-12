using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WeatherApp.OpenWeather
{
    internal class WeatherInfo
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        public Bitmap BitmapIcon
        {
            get
            {
                return new Bitmap(Image.FromFile($"Icons/{Icon}.png"));//выбор иконок
            }
        }
    }
}
