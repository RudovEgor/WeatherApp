using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.OpenWeather
{
    internal class TemperatureInfo
    {
        public double Temp { get;set; }
        private double _pressure;
        public double Pressure//давление
        {
            get { return _pressure; }
            set { _pressure = value/1.3332239; }
        }
        public double humidity { get; set; }//влажность
    }
}
