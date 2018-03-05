using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid  
            string key = "092c794ba9787c8e74be486d94cfc224";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                                 + zipCode + ",us&appid=" + key + "&units=imperial";

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] == null)
                return null;

            var weather = new Weather
            {
                Title = (string) results["name"],
                Temperature = (string) results["main"]["temp"] + " F",
                Wind = (string) results["wind"]["speed"] + " mph",
                Humidity = (string) results["main"]["humidity"] + " %",
                Visibility = (string) results["weather"][0]["main"]
            };

            DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
            DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
            weather.Sunrise = sunrise + " UTC";
            weather.Sunset = sunset + " UTC";

            return weather;

        }
    }
}