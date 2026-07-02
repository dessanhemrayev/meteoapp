namespace MeteoApp
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.lblApiKey = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.radioRussian = new System.Windows.Forms.RadioButton();
            this.radioEnglish = new System.Windows.Forms.RadioButton();
            this.lblCity = new System.Windows.Forms.Label();
            this.listCities = new System.Windows.Forms.ListBox();
            this.lblNewCity = new System.Windows.Forms.Label();
            this.txtNewCity = new System.Windows.Forms.TextBox();
            this.btnAddCity = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblApiKey
            //
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(15, 15);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(120, 13);
            this.lblApiKey.TabIndex = 0;
            this.lblApiKey.Text = "API key OpenWeatherMap:";
            //
            // txtApiKey
            //
            this.txtApiKey.Location = new System.Drawing.Point(15, 33);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(265, 20);
            this.txtApiKey.TabIndex = 1;
            //
            // lblLanguage
            //
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(15, 65);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(45, 13);
            this.lblLanguage.TabIndex = 2;
            this.lblLanguage.Text = "Язык";
            //
            // radioRussian
            //
            this.radioRussian.AutoSize = true;
            this.radioRussian.Location = new System.Drawing.Point(18, 84);
            this.radioRussian.Name = "radioRussian";
            this.radioRussian.Size = new System.Drawing.Size(69, 17);
            this.radioRussian.TabIndex = 3;
            this.radioRussian.TabStop = true;
            this.radioRussian.Text = "Русский";
            this.radioRussian.UseVisualStyleBackColor = true;
            this.radioRussian.CheckedChanged += new System.EventHandler(this.radioLanguage_CheckedChanged);
            //
            // radioEnglish
            //
            this.radioEnglish.AutoSize = true;
            this.radioEnglish.Location = new System.Drawing.Point(140, 84);
            this.radioEnglish.Name = "radioEnglish";
            this.radioEnglish.Size = new System.Drawing.Size(65, 17);
            this.radioEnglish.TabIndex = 4;
            this.radioEnglish.Text = "English";
            this.radioEnglish.UseVisualStyleBackColor = true;
            this.radioEnglish.CheckedChanged += new System.EventHandler(this.radioLanguage_CheckedChanged);
            //
            // lblCity
            //
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(15, 115);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(38, 13);
            this.lblCity.TabIndex = 5;
            this.lblCity.Text = "Город:";
            //
            // listCities
            //
            this.listCities.FormattingEnabled = true;
            this.listCities.Location = new System.Drawing.Point(15, 133);
            this.listCities.Name = "listCities";
            this.listCities.Size = new System.Drawing.Size(265, 95);
            this.listCities.TabIndex = 6;
            //
            // lblNewCity
            //
            this.lblNewCity.AutoSize = true;
            this.lblNewCity.Location = new System.Drawing.Point(15, 237);
            this.lblNewCity.Name = "lblNewCity";
            this.lblNewCity.Size = new System.Drawing.Size(70, 13);
            this.lblNewCity.TabIndex = 7;
            this.lblNewCity.Text = "Новый город:";
            //
            // txtNewCity
            //
            this.txtNewCity.Location = new System.Drawing.Point(15, 256);
            this.txtNewCity.Name = "txtNewCity";
            this.txtNewCity.Size = new System.Drawing.Size(180, 20);
            this.txtNewCity.TabIndex = 8;
            //
            // btnAddCity
            //
            this.btnAddCity.Location = new System.Drawing.Point(200, 254);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(80, 23);
            this.btnAddCity.TabIndex = 9;
            this.btnAddCity.Text = "Добавить";
            this.btnAddCity.UseVisualStyleBackColor = true;
            this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(110, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(200, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // SettingsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 335);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddCity);
            this.Controls.Add(this.txtNewCity);
            this.Controls.Add(this.lblNewCity);
            this.Controls.Add(this.listCities);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.radioEnglish);
            this.Controls.Add(this.radioRussian);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.lblApiKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.RadioButton radioRussian;
        private System.Windows.Forms.RadioButton radioEnglish;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.ListBox listCities;
        private System.Windows.Forms.Label lblNewCity;
        private System.Windows.Forms.TextBox txtNewCity;
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
