using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MeteoApp.Services
{
    public class WeatherService
    {
        private static readonly HttpClient HttpClient = new HttpClient
        {
            Timeout = System.TimeSpan.FromSeconds(30)
        };
        private readonly AppSettings _settings;

        public WeatherService(AppSettings settings)
        {
            _settings = settings;
        }

        public async Task<WeatherResponse> GetWeather(string city)
        {
            string requestLanguage = _settings.Language == "en" ? "en" : "ru";
            string encodedCity = System.Uri.EscapeDataString(city);
            string requestUrl = $"https://api.openweathermap.org/data/2.5/weather?q={encodedCity}&units=metric&lang={requestLanguage}&APPID={_settings.ApiKey}";

            using (var response = await HttpClient.GetAsync(requestUrl).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(json);

                if (weatherResponse == null)
                {
                    throw new System.InvalidOperationException("Failed to deserialize weather response: API returned null or invalid data.");
                }

                return weatherResponse;
            }
        }
    }
}
