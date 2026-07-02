using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApp
{
    public class Temperatura
    {
        public double temp;
    }

    public class WeatherNow
    {
        public string main;
        public string description;
        public string icon;
    }

    public class WeatherResponse
    {
        public Temperatura main;
        public string name;
        public WeatherNow[] weather;
    }
}
