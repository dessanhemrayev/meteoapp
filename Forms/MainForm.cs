using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeteoApp.Services;

namespace MeteoApp
{
    public partial class MainForm : Form
    {
        private readonly AppSettings _settings;
        private readonly WeatherService _weatherService;
        private readonly LocalizationService _localizationService;

        public MainForm()
        {
            InitializeComponent();

            _settings = new AppSettings();
            _weatherService = new WeatherService(_settings);
            _localizationService = new LocalizationService(_settings.Language);

            SetupLanguage();
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

            if (string.IsNullOrWhiteSpace(_settings.SelectedCity))
            {
                SetMessage(_localizationService.CurrentStrings.SelectCityPrompt);
                return;
            }

            try
            {
                var city = _settings.SelectedCity;
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
            city_name.Text = _settings.SelectedCity;
            pictureBox1.ImageLocation = null;
        }

        private void SetupLanguage()
        {
            var strings = _localizationService.CurrentStrings;
            button2.Text = strings.SettingsButton;
            button1.Text = strings.RefreshButton;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await UpdateWeather();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm(_settings))
            {
                if (settingsForm.ShowDialog(this) == DialogResult.OK)
                {
                    _localizationService.SetLanguage(_settings.Language);
                    SetupLanguage();
                    await UpdateWeather();
                }
            }
        }
    }
}
