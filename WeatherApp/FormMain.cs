using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;

namespace WeatherApp
{
    public partial class FormMain : Form
    {
        const string API = "6795ddd7e16d97d855cc5fc2c2cee7ce";
        public FormMain()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private async void buttonGetWeather_Click(object sender, EventArgs e)
        {
            string answer = string.Empty;
            WebRequest request = WebRequest.Create($"https://api.openweathermap.org/data/2.5/weather?q={comboBox1.SelectedItem}&lang=ru&units=metric&appid={API}");
            WebResponse response = await request.GetResponseAsync();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                answer = await sr.ReadToEndAsync();
            }
            response.Close();
            WriteAllData(answer);
        }
        private void WriteAllData(string answer)// Заполнение Json-ответа на форму
        {
            OpenWeather.WeatherResponse openWeather = JsonConvert.DeserializeObject<OpenWeather.WeatherResponse>(answer);
            panelImage.BackgroundImage = openWeather.Weather[0].BitmapIcon;
            label1.Text = ToUpperFirstLetter(openWeather.Weather[0].Description);
            label3.Text = $"{openWeather.Main.Temp}°C";
            label4.Text = $"Скорость: {openWeather.Wind.Speed} м/c";
            label5.Text = $"Направление: {openWeather.Wind.Deg}°";
            label6.Text = $"Влажность: {openWeather.Main.humidity} %";
            label7.Text = $"Давление: {(int)openWeather.Main.Pressure} мм";
            label8.Text = $"{openWeather.Name}";
        }
        public string ToUpperFirstLetter(string text)// Возведение первой буквы в заглавную
        {
            char[] result = text.ToCharArray();
            result[0] = char.ToUpper(result[0]);
            return new string(result);
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)//перетаскивание формы
        {
            Capture = false;
            var msg = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref msg);
        }
        private void buttonExit_Click(object sender, EventArgs e)//закрытие формы
        {
            Close();
        }

        private void buttonMinimized_Click(object sender, EventArgs e)//сворачивание формы
        {
            WindowState = FormWindowState.Minimized;
        }

    }
}
