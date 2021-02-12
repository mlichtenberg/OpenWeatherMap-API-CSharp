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
            var currentWeatherResults = client.CurrentWeather(city);

            Console.WriteLine($"The temperature in {city} is {currentWeatherResults.Main.Temperature.FahrenheitCurrent}F. There is {currentWeatherResults.Wind.SpeedFeetPerSecond} f/s wind in the {currentWeatherResults.Wind.Direction} direction.");

			var oneCallResults = client.OneCall(currentWeatherResults.Coord.Latitude, currentWeatherResults.Coord.Longitude);

			foreach (Day day in oneCallResults.Daily)
			{
				Console.WriteLine($"{day.Dt} : {day.Temp.FahrenheitMaximum}/{day.Temp.FahrenheitMinimum} ({day.Weathers[0].Description})");
			}

            Console.ReadLine();
        }
    }
}
