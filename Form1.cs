using System;

using System.Windows.Forms;

using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace MeteoApp
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            set_weather_data();
        }
        public static string city="Курск";
        public static string api_key= "2de0955b5bffdb47a722c2878d744420";

        public static WeatherResponse getDataAPI()
        {
            string request_url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&lang=ru&APPID=" + api_key;
           
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(request_url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<WeatherResponse>(response);
        }

        private void set_weather_data()
        {
            WeatherResponse response = getDataAPI();
            degree.Text = response.main.temp.ToString();
            weather.Text = response.weather[0].description;
            string weatherIconUrl = "https://openweathermap.org/img/w/" + response.weather[0].icon + ".png";
            pictureBox1.ImageLocation = weatherIconUrl;
            city_name.Text = city;
            
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            set_weather_data();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = listBox1.SelectedItem.ToString();
            city = selectedCity;
            set_weather_data();
        }
    }
}
