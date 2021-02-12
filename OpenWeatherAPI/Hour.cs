using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Hour
	{
		public DateTime Dt { get; }
		public double CelsiusTemp { get; }
		public double FahrenheitTemp { get; }
		public double KelvinTemp { get; }
		public double CelsiusFeelsLike { get; }
		public double FahrenheitFeelsLike { get; }
		public double KelvinFeelsLike { get; }
		public int Pressure { get; }
		public int Humidity { get; }
		public double DewPoint { get; }
		public double Uvi { get; }
		public int Clouds { get; }
		public int Visibility { get; }
		public double WindSpeed { get; }
		public int WindDeg { get; }
		public List<Weather> Weathers { get; } = new List<Weather>();
		public double Pop { get; }

		public Hour(JToken hourData)
		{
			if (hourData is null)
				throw new ArgumentNullException(nameof(hourData));

			Dt = Utility.convertUnixToDateTime(double.Parse(hourData.SelectToken("dt").ToString(), CultureInfo.InvariantCulture));
			KelvinTemp = double.Parse(hourData.SelectToken("temp").ToString(), CultureInfo.InvariantCulture);
			KelvinFeelsLike = double.Parse(hourData.SelectToken("feels_like").ToString(), CultureInfo.InvariantCulture);
			CelsiusTemp = Utility.convertToCelsius(KelvinTemp);
			CelsiusFeelsLike = Utility.convertToCelsius(KelvinFeelsLike);
			FahrenheitTemp = Utility.convertToFahrenheit(CelsiusTemp);
			FahrenheitFeelsLike = Utility.convertToFahrenheit(CelsiusFeelsLike);
			Pressure = int.Parse(hourData.SelectToken("pressure").ToString(), CultureInfo.InvariantCulture);
			Humidity = int.Parse(hourData.SelectToken("humidity").ToString(), CultureInfo.InvariantCulture);
			DewPoint = double.Parse(hourData.SelectToken("dew_point").ToString(), CultureInfo.InvariantCulture);
			Uvi = double.Parse(hourData.SelectToken("uvi").ToString(), CultureInfo.InvariantCulture);
			Clouds = int.Parse(hourData.SelectToken("clouds").ToString(), CultureInfo.InvariantCulture);
			Visibility = int.Parse(hourData.SelectToken("visibility").ToString(), CultureInfo.InvariantCulture);
			WindSpeed = double.Parse(hourData.SelectToken("wind_speed").ToString(), CultureInfo.InvariantCulture);
			WindDeg = int.Parse(hourData.SelectToken("wind_deg").ToString(), CultureInfo.InvariantCulture);
			Pop = double.Parse(hourData.SelectToken("pop").ToString(), CultureInfo.InvariantCulture);
			foreach (JToken weather in hourData.SelectToken("weather"))
				Weathers.Add(new Weather(weather));
		}
	}
}
