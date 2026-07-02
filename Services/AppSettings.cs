using MeteoApp.Properties;

namespace MeteoApp.Services
{
    public class AppSettings
    {
        private readonly Settings _savedSettings = Settings.Default;

        public AppSettings()
        {
            ApiKey = _savedSettings.ApiKey ?? string.Empty;
            Language = string.IsNullOrWhiteSpace(_savedSettings.Language) ? "ru" : _savedSettings.Language;
            CustomCities = _savedSettings.CustomCities ?? string.Empty;
            SelectedCity = string.IsNullOrWhiteSpace(_savedSettings.SelectedCity)
                ? CityCatalog.GetDefaultCities(Language)[0]
                : _savedSettings.SelectedCity;
        }

        public string ApiKey { get; set; }

        public string Language { get; set; }

        public string SelectedCity { get; set; }

        public string CustomCities { get; set; }

        public void Save()
        {
            _savedSettings.ApiKey = ApiKey ?? string.Empty;
            _savedSettings.Language = Language;
            _savedSettings.SelectedCity = SelectedCity ?? string.Empty;
            _savedSettings.CustomCities = CustomCities ?? string.Empty;
            _savedSettings.Save();
        }
    }
}
