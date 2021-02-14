using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenWeatherAPI
{
	public class OneCallCurrentWeather
	{
		public DateTime DateTime { get; }
		public DateTime Sunrise { get; }
		public DateTime Sunset { get; }
		public int Pressure { get; }
		public int Humidity { get; }
		public double DewPoint { get; }
		public int Visibility { get; }
		public int Clouds { get; }
		public double Uvi { get; }
		public List<Weather> Weathers { get; } = new List<Weather>();
		public Wind Wind { get; }
		public double Temperature { get; }
		public double FeelsLike { get; }

		public OneCallCurrentWeather(JToken currentData)
		{
			if (currentData is null)
				throw new ArgumentNullException(nameof(currentData));

			DateTime = Utility.convertUnixToDateTime(double.Parse(currentData.SelectToken("dt").ToString(), CultureInfo.InvariantCulture));
			Sunrise = Utility.convertUnixToDateTime(double.Parse(currentData.SelectToken("sunrise").ToString(), CultureInfo.InvariantCulture));
			Sunset = Utility.convertUnixToDateTime(double.Parse(currentData.SelectToken("sunset").ToString(), CultureInfo.InvariantCulture));
			Pressure = int.Parse(currentData.SelectToken("pressure").ToString(), CultureInfo.InvariantCulture);
			Humidity = int.Parse(currentData.SelectToken("humidity").ToString(), CultureInfo.InvariantCulture);
			DewPoint = double.Parse(currentData.SelectToken("dew_point").ToString(), CultureInfo.InvariantCulture);
			Visibility = int.Parse(currentData.SelectToken("visibility").ToString(), CultureInfo.InvariantCulture);
			Clouds = int.Parse(currentData.SelectToken("clouds").ToString(), CultureInfo.InvariantCulture);
			Uvi = double.Parse(currentData.SelectToken("uvi").ToString(), CultureInfo.InvariantCulture);
			foreach (JToken weather in currentData.SelectToken("weather"))
				Weathers.Add(new Weather(weather));
			Temperature = double.Parse(currentData.SelectToken("temp").ToString(), CultureInfo.InvariantCulture);
			FeelsLike = double.Parse(currentData.SelectToken("feels_like").ToString(), CultureInfo.InvariantCulture);
			Wind = new Wind(currentData);
		}
	}
}
