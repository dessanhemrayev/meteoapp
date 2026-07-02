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
        }

        public string ApiKey { get; set; }

        public string Language { get; set; }

        public void Save()
        {
            _savedSettings.ApiKey = ApiKey ?? string.Empty;
            _savedSettings.Language = Language;
            _savedSettings.Save();
        }
    }
}
