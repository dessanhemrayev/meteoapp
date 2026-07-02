using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace MeteoApp.Services
{
    public class WeatherService
    {
        private readonly AppSettings _settings;

        public WeatherService(AppSettings settings)
        {
            _settings = settings;
        }

        public WeatherResponse GetWeather(string city)
        {
            string requestLanguage = _settings.Language == "en" ? "en" : "ru";
            string requestUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&lang={requestLanguage}&APPID={_settings.ApiKey}";

            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string raw = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<WeatherResponse>(raw);
            }
        }
    }
}
