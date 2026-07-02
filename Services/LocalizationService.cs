namespace MeteoApp.Services
{
    public class LocalizationService
    {
        public LanguageStrings CurrentStrings { get; private set; }

        public LocalizationService(string language)
        {
            SetLanguage(language);
        }

        public void SetLanguage(string languageCode)
        {
            CurrentStrings = languageCode == "en" ? LanguageStrings.English : LanguageStrings.Russian;
        }
    }

    public class LanguageStrings
    {
        public static readonly LanguageStrings Russian = new LanguageStrings
        {
            LanguageMenu = "Язык",
            RussianMenu = "Русский",
            EnglishMenu = "English",
            SettingsButton = "Настр.",
            RefreshButton = "Обновить",
            EnterApiKey = "Введите API key OpenWeatherMap:",
            SettingsTitle = "Настройки",
            ApiKeySaved = "API key сохранён.",
            ApiKeyCleared = "API key удалён. Введите новый ключ для работы приложения.",
            EnterApiKeyPrompt = "Введите API key в настройках",
            SelectCityPrompt = "Пожалуйста, выберите город",
            FetchError = "Не удалось получить данные"
        };

        public static readonly LanguageStrings English = new LanguageStrings
        {
            LanguageMenu = "Language",
            RussianMenu = "Русский",
            EnglishMenu = "English",
            SettingsButton = "Settings",
            RefreshButton = "Refresh",
            EnterApiKey = "Enter OpenWeatherMap API key:",
            SettingsTitle = "Settings",
            ApiKeySaved = "API key saved.",
            ApiKeyCleared = "API key removed. Enter a new key to use the app.",
            EnterApiKeyPrompt = "Enter API key in settings",
            SelectCityPrompt = "Please select a city",
            FetchError = "Unable to retrieve data"
        };

        public string LanguageMenu { get; set; }
        public string RussianMenu { get; set; }
        public string EnglishMenu { get; set; }
        public string SettingsButton { get; set; }
        public string RefreshButton { get; set; }
        public string EnterApiKey { get; set; }
        public string SettingsTitle { get; set; }
        public string ApiKeySaved { get; set; }
        public string ApiKeyCleared { get; set; }
        public string EnterApiKeyPrompt { get; set; }
        public string SelectCityPrompt { get; set; }
        public string FetchError { get; set; }
    }
}
