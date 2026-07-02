using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MeteoApp.Services;

namespace MeteoApp
{
    public partial class MainForm : Form
    {
        private readonly AppSettings _settings;
        private readonly WeatherService _weatherService;
        private readonly LocalizationService _localizationService;

        private readonly string[] russianCities = { "Курск", "Москва", "Пенза", "Тула" };
        private readonly string[] englishCities = { "Kursk", "Moscow", "Penza", "Tula" };

        public MainForm()
        {
            InitializeComponent();

            _settings = new AppSettings();
            _weatherService = new WeatherService(_settings);
            _localizationService = new LocalizationService(_settings.Language);

            SetupLanguage();
            FillCityList();
            this.Load += MainForm_Load;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await UpdateWeather();
        }

        private async Task UpdateWeather()
        {
            if (string.IsNullOrWhiteSpace(_settings.ApiKey))
            {
                SetMessage(_localizationService.CurrentStrings.EnterApiKeyPrompt);
                return;
            }

            if (listBox1.SelectedItem == null)
            {
                SetMessage(_localizationService.CurrentStrings.SelectCityPrompt);
                return;
            }

            try
            {
                var city = (string)listBox1.SelectedItem;
                var response = await _weatherService.GetWeather(city);
                degree.Text = response.main.temp.ToString();
                weather.Text = response.weather[0].description;
                pictureBox1.ImageLocation = $"https://openweathermap.org/img/w/{response.weather[0].icon}.png";
                city_name.Text = city;
            }
            catch (Exception)
            {
                SetMessage(_localizationService.CurrentStrings.FetchError);
            }
        }

        private void SetMessage(string message)
        {
            degree.Text = "-";
            weather.Text = message;
            city_name.Text = (string)listBox1.SelectedItem;
            pictureBox1.ImageLocation = null;
        }

        private void SetupLanguage()
        {
            var strings = _localizationService.CurrentStrings;
            languageToolStripMenuItem.Text = strings.LanguageMenu;
            russianToolStripMenuItem.Text = strings.RussianMenu;
            englishToolStripMenuItem.Text = strings.EnglishMenu;
            button2.Text = strings.SettingsButton;
            button1.Text = strings.RefreshButton;
        }

        private void FillCityList()
        {
            listBox1.Items.Clear();
            if (_settings.Language == "en")
                listBox1.Items.AddRange(englishCities);
            else
                listBox1.Items.AddRange(russianCities);

            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await UpdateWeather();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string newKey = Interaction.InputBox(
                _localizationService.CurrentStrings.EnterApiKey,
                _localizationService.CurrentStrings.SettingsTitle,
                _settings.ApiKey,
                -1,
                -1);

            if (newKey == null)
                return;

            _settings.ApiKey = newKey.Trim();
            _settings.Save();

            if (string.IsNullOrWhiteSpace(_settings.ApiKey))
            {
                MessageBox.Show(_localizationService.CurrentStrings.ApiKeyCleared, _localizationService.CurrentStrings.SettingsTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetMessage(_localizationService.CurrentStrings.EnterApiKeyPrompt);
                return;
            }

            MessageBox.Show(_localizationService.CurrentStrings.ApiKeySaved, _localizationService.CurrentStrings.SettingsTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            await UpdateWeather();
        }

        private async void addCityButton_Click(object sender, EventArgs e)
        {
            string newCity = textBoxCity.Text?.Trim();
            if (string.IsNullOrWhiteSpace(newCity))
                return;

            if (!listBox1.Items.Contains(newCity))
            {
                listBox1.Items.Add(newCity);
            }

            listBox1.SelectedItem = newCity;
            textBoxCity.Clear();
            await UpdateWeather();
        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateWeather();
        }

        private async void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ChangeLanguage("ru");
        }

        private async void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ChangeLanguage("en");
        }

        private async Task ChangeLanguage(string languageCode)
        {
            _settings.Language = languageCode == "en" ? "en" : "ru";
            _settings.Save();
            _localizationService.SetLanguage(_settings.Language);
            SetupLanguage();
            FillCityList();
            await UpdateWeather();
        }
    }
}
