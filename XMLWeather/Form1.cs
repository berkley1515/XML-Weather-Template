using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // list to hold day objects

        public static List<Day> days = new List<Day>();


        public Form1()
        {
            InitializeComponent();

            for (int x = 0; x<5; x++)
            {
                days.Add(new Day());
            }


            ExtractForecast();
            ExtractCurrent();
            
            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        private void ExtractForecast()
        {
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            for (int x = 0; x < 5; x++)
            {
               
                // fill day object with required data
                reader.ReadToFollowing("time");
                days[x].date = reader.GetAttribute("day");

                reader.ReadToFollowing("temperature");
                days[x].tempLow = reader.GetAttribute("min");

                reader.ReadToFollowing("temperature");
                days[x].tempHigh = reader.GetAttribute("max");
                
            }
        }

        private void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            // find the city and current temperature and add to appropriate item in days list
            //reader.ReadToFollowing("location");
            //days[0].location = reader.GetAttribute("name");

            reader.ReadToFollowing("symbol");
            days[0].condition = reader.GetAttribute("name");

            reader.ReadToFollowing("precipitation");
            days[0].precipitation = reader.GetAttribute("value");

            reader.ReadToFollowing("windSpeed");
            days[0].windSpeed = reader.GetAttribute("mps");

            reader.ReadToFollowing("temperature");
            days[0].currentTemp = reader.GetAttribute("value");

            //reader.ReadToFollowing("humidity");
            //days[0].humidity = reader.GetAttribute("value");


            
            
        }


    }
}
