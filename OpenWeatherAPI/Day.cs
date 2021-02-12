using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenWeatherAPI
{
	public class Day
	{
		public DateTime Dt { get; }
		public DateTime Sunrise { get; }
		public DateTime Sunset { get; }
		public int Pressure { get; }
		public int Humidity { get; }
		public double DewPoint { get; }
		public double WindSpeed { get; }
		public int WindDeg { get; }
		public int Clouds { get; }
		public double Pop { get; }
		public double Uvi { get; }
		public List<Weather> Weathers { get; } = new List<Weather>();
		public OneCallTemperatureObj Temp { get; }
		public OneCallTemperatureObj FeelsLike { get; }

		public Day(JToken dayData)
		{
			if (dayData is null)
				throw new ArgumentNullException(nameof(dayData));

			Dt = Utility.convertUnixToDateTime(double.Parse(dayData.SelectToken("dt").ToString(), CultureInfo.InvariantCulture));
			Sunrise = Utility.convertUnixToDateTime(double.Parse(dayData.SelectToken("sunrise").ToString(), CultureInfo.InvariantCulture));
			Sunset = Utility.convertUnixToDateTime(double.Parse(dayData.SelectToken("sunset").ToString(), CultureInfo.InvariantCulture));
			Pressure = int.Parse(dayData.SelectToken("pressure").ToString(), CultureInfo.InvariantCulture);
			Humidity = int.Parse(dayData.SelectToken("humidity").ToString(), CultureInfo.InvariantCulture);
			DewPoint = double.Parse(dayData.SelectToken("dew_point").ToString(), CultureInfo.InvariantCulture);
			WindSpeed = double.Parse(dayData.SelectToken("wind_speed").ToString(), CultureInfo.InvariantCulture);
			WindDeg = int.Parse(dayData.SelectToken("wind_deg").ToString(), CultureInfo.InvariantCulture);
			Clouds = int.Parse(dayData.SelectToken("clouds").ToString(), CultureInfo.InvariantCulture);
			Pop = double.Parse(dayData.SelectToken("pop").ToString(), CultureInfo.InvariantCulture);
			Uvi = double.Parse(dayData.SelectToken("uvi").ToString(), CultureInfo.InvariantCulture);
			foreach (JToken weather in dayData.SelectToken("weather"))
				Weathers.Add(new Weather(weather));
			Temp = new OneCallTemperatureObj(dayData.SelectToken("temp"));
			FeelsLike = new OneCallTemperatureObj(dayData.SelectToken("feels_like"));
		}
	}
}
