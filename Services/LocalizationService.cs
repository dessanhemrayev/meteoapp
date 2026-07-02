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
            FetchError = "Unable to retrieve data"
        };

        public string LanguageMenu { get; init; }
        public string RussianMenu { get; init; }
        public string EnglishMenu { get; init; }
        public string SettingsButton { get; init; }
        public string RefreshButton { get; init; }
        public string EnterApiKey { get; init; }
        public string SettingsTitle { get; init; }
        public string ApiKeySaved { get; init; }
        public string ApiKeyCleared { get; init; }
        public string EnterApiKeyPrompt { get; init; }
        public string FetchError { get; init; }
    }
}
