using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {


            /// everything broke on me ....   humidity cant be found in the xml,  my windspeed is 0 no matter what

            cityLabel.Text = "Stratford";
            currentTimeLabel.Text = "" + Convert.ToDateTime(Form1.days[0].date).AddDays(0).DayOfWeek.ToString();
            currentTempLabel.Text = "" + Math.Round(Convert.ToDouble(Form1.days[0].currentTemp), 0) + "°C";
            lowLabel.Text = "" + Math.Round(Convert.ToDouble(Form1.days[0].tempLow), 0) + "°C";
            highLabel.Text = "" + Math.Round(Convert.ToDouble(Form1.days[0].tempHigh), 0) + "°C";
            conditionLabel.Text = "" + Convert.ToString(Form1.days[0].condition);
            windLabel.Text = "Wind: " + Form1.days[0].windSpeed + " mps";
            precipLabel.Text = "Precipitation: " + Math.Round(Convert.ToDouble(Form1.days[0].precipitation), 0) + "%";
            //humidLabel.Text = "Humidity: " + Math.Round(Convert.ToDouble(Form1.days[0].humidity), 0) + "%";
            

            day1Label.Text = Convert.ToDateTime(Form1.days[0].date).AddDays(1).DayOfWeek.ToString();
            day1LowLabel.Text = "" + Math.Round(Convert.ToDouble(Form1.days[1].tempLow), 0) + "°C";
            day1HighLabel.Text = "" + Math.Round(Convert.ToDouble(Form1.days[1].tempLow), 0) + "°C";

            day2Label.Text = Convert.ToDateTime(Form1.days[0].date).AddDays(2).DayOfWeek.ToString();
            day2LowLabel.Text = "" + Math.Round(Convert.ToDouble(Form1.days[2].tempLow), 0) + "°C";
            day2HighLabel.Text = "" + Math.Round(Convert.ToDouble(Form1.days[2].tempHigh), 0) + "°C";

            day3Label.Text = Convert.ToDateTime(Form1.days[0].date).AddDays(3).DayOfWeek.ToString();
            day3LowLabel.Text = "" + Math.Round(Convert.ToDouble(Form1.days[3].tempLow), 0) + "°C";
            day3HighLabel.Text = "" + Math.Round(Convert.ToDouble(Form1.days[3].tempHigh), 0) + "°C";

        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
