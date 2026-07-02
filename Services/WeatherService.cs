using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MeteoApp.Services
{
    public class WeatherService
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private readonly AppSettings _settings;

        public WeatherService(AppSettings settings)
        {
            _settings = settings;
        }

        public async Task<WeatherResponse> GetWeather(string city)
        {
            string requestLanguage = _settings.Language == "en" ? "en" : "ru";
            string requestUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&lang={requestLanguage}&APPID={_settings.ApiKey}";

            using (var response = await HttpClient.GetAsync(requestUrl).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<WeatherResponse>(json);
            }
        }
    }
}
