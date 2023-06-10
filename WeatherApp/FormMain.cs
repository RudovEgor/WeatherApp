using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace WeatherApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/weather?q=Moscow&&lang=ru&units=metric&appid=6795ddd7e16d97d855cc5fc2c2cee7ce");
            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                answer = await sr.ReadToEndAsync();
            }
            response.Close();
            OpenWeather.WeatherResponse openWeather = JsonConvert.DeserializeObject<OpenWeather.WeatherResponse>(answer);
            #region Заполнение данных на форму
            panelImage.BackgroundImage = openWeather.Weather[0].BitmapIcon;
            label1.Text = openWeather.Weather[0].Description;
            label3.Text = $"{openWeather.Main.Temp}°C";
            label4.Text = "Скорость (м/c):" + openWeather.Wind.Speed.ToString();
            label5.Text = "Направление °:" + openWeather.Wind.Deg.ToString();
            label6.Text = "Влажность (%):" + openWeather.Main.humidity.ToString();
            label7.Text = "Давление (мм):" + ((int)openWeather.Main.Pressure).ToString();
            label8.Text = openWeather.Name.ToString();
            #endregion
        }
    }
}
