using OpenWeatherAPI;
using System;

namespace OpenWeatherAPI_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new OpenWeatherAPI.API("64a1680aae99a5eb96c65b341384ddce");

            Console.WriteLine("OpenWeatherAPI Example Application");
            Console.WriteLine();

            Console.WriteLine("Enter city to get weather data for:");
            var city = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine($"Fetching weather data for '{city}'");
            var currentWeatherResults = client.CurrentWeather(city, OpenWeatherAPI.UnitsEnum.Imperial);

            Console.WriteLine($"The temperature in {city} is {currentWeatherResults.Main.Temperature.Current}F. There is {currentWeatherResults.Wind.Speed} mph wind in the {currentWeatherResults.Wind.Direction} direction.");

			var oneCallResults = client.OneCall(currentWeatherResults.Coord.Latitude, currentWeatherResults.Coord.Longitude, UnitsEnum.Imperial);

			foreach (Day day in oneCallResults.Daily)
			{
				Console.WriteLine($"{day.DateTime} : {day.Temp.Maximum}/{day.Temp.Minimum} ({day.Weathers[0].Description})");
			}

            Console.ReadLine();
        }
    }
}
