using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Hour
	{
		public DateTime DateTime { get; }
		public double Temperature { get; }
		public double FeelsLike { get; }
		public int Pressure { get; }
		public int Humidity { get; }
		public double DewPoint { get; }
		public double Uvi { get; }
		public int Clouds { get; }
		public int Visibility { get; }
		public List<Weather> Weathers { get; } = new List<Weather>();
		public Wind Wind { get; }
		public double Pop { get; }

		public Hour(JToken hourData)
		{
			if (hourData is null)
				throw new ArgumentNullException(nameof(hourData));

			DateTime = Utility.convertUnixToDateTime(double.Parse(hourData.SelectToken("dt").ToString(), CultureInfo.InvariantCulture));
			Temperature = double.Parse(hourData.SelectToken("temp").ToString(), CultureInfo.InvariantCulture);
			FeelsLike = double.Parse(hourData.SelectToken("feels_like").ToString(), CultureInfo.InvariantCulture);
			Pressure = int.Parse(hourData.SelectToken("pressure").ToString(), CultureInfo.InvariantCulture);
			Humidity = int.Parse(hourData.SelectToken("humidity").ToString(), CultureInfo.InvariantCulture);
			DewPoint = double.Parse(hourData.SelectToken("dew_point").ToString(), CultureInfo.InvariantCulture);
			Uvi = double.Parse(hourData.SelectToken("uvi").ToString(), CultureInfo.InvariantCulture);
			Clouds = int.Parse(hourData.SelectToken("clouds").ToString(), CultureInfo.InvariantCulture);
			Visibility = int.Parse(hourData.SelectToken("visibility").ToString(), CultureInfo.InvariantCulture);
			Wind = new Wind(hourData);
			Pop = double.Parse(hourData.SelectToken("pop").ToString(), CultureInfo.InvariantCulture);
			foreach (JToken weather in hourData.SelectToken("weather"))
				Weathers.Add(new Weather(weather));
		}
	}
}
