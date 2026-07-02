namespace MeteoApp.Services
{
    public static class CityCatalog
    {
        public static readonly string[] RussianCities = { "Курск", "Москва", "Пенза", "Тула" };
        public static readonly string[] EnglishCities = { "Kursk", "Moscow", "Penza", "Tula" };

        public static string[] GetDefaultCities(string language)
        {
            return language == "en" ? EnglishCities : RussianCities;
        }
    }
}
