using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.OpenWeatherModel;

namespace WeatherApp.OpenWeather
{
    internal class WeatherResponse
    {
        public WeatherInfo[] Weather;
        public TemperatureInfo Main;
        public WindInfo Wind;
        public CloudsInfo Cloud;
        public string Name { get; set; }
    }
}
