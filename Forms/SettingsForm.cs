using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MeteoApp.Services;

namespace MeteoApp
{
    public partial class SettingsForm : Form
    {
        private readonly AppSettings _settings;
        private readonly LocalizationService _localization;
        private readonly List<string> _customCities;
        private string _selectedLanguage;

        public SettingsForm(AppSettings settings)
        {
            InitializeComponent();

            _settings = settings;
            _selectedLanguage = settings.Language;
            _localization = new LocalizationService(_selectedLanguage);
            _customCities = (_settings.CustomCities ?? string.Empty)
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.Trim())
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .ToList();

            txtApiKey.Text = _settings.ApiKey;
            radioRussian.Checked = _selectedLanguage != "en";
            radioEnglish.Checked = _selectedLanguage == "en";

            ApplyLocalization();
            RefreshCityList(_settings.SelectedCity);
        }

        private void ApplyLocalization()
        {
            var strings = _localization.CurrentStrings;
            Text = strings.SettingsTitle;
            lblApiKey.Text = strings.EnterApiKey;
            lblLanguage.Text = strings.LanguageMenu;
            radioRussian.Text = strings.RussianMenu;
            radioEnglish.Text = strings.EnglishMenu;
            lblCity.Text = strings.CityLabel;
            lblNewCity.Text = strings.NewCityLabel;
            btnAddCity.Text = strings.AddCityButton;
            btnSave.Text = strings.SaveButton;
            btnCancel.Text = strings.CancelButton;
        }

        private void RefreshCityList(string cityToSelect)
        {
            var defaultCities = CityCatalog.GetDefaultCities(_selectedLanguage);
            var cities = defaultCities.Concat(_customCities.Except(defaultCities)).ToArray();

            listCities.Items.Clear();
            listCities.Items.AddRange(cities);

            if (!string.IsNullOrEmpty(cityToSelect) && listCities.Items.Contains(cityToSelect))
                listCities.SelectedItem = cityToSelect;
            else if (listCities.Items.Count > 0)
                listCities.SelectedIndex = 0;
        }

        private void radioLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
                return;

            _selectedLanguage = radioEnglish.Checked ? "en" : "ru";
            _localization.SetLanguage(_selectedLanguage);
            var currentSelection = (string)listCities.SelectedItem;
            ApplyLocalization();
            RefreshCityList(currentSelection);
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            string newCity = txtNewCity.Text?.Trim();
            if (string.IsNullOrEmpty(newCity))
                return;

            if (!_customCities.Contains(newCity) && !CityCatalog.GetDefaultCities(_selectedLanguage).Contains(newCity))
                _customCities.Add(newCity);

            txtNewCity.Clear();
            RefreshCityList(newCity);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listCities.SelectedItem == null)
            {
                MessageBox.Show(_localization.CurrentStrings.SelectCityPrompt, _localization.CurrentStrings.SettingsTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _settings.ApiKey = txtApiKey.Text?.Trim();
            _settings.Language = _selectedLanguage;
            _settings.SelectedCity = (string)listCities.SelectedItem;
            _settings.CustomCities = string.Join(";", _customCities);
            _settings.Save();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
