using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenWeatherAPI
{
	public class OneCallTemperatureObj
	{
		public double CelsiusDay { get; }
		public double FahrenheitDay { get; }
		public double KelvinDay { get; }
		public double CelsiusMinimum { get; }
		public double CelsiusMaximum { get; }
		public double FahrenheitMinimum { get; }
		public double FahrenheitMaximum { get; }
		public double KelvinMinimum { get; }
		public double KelvinMaximum { get; }
		public double CelsiusNight { get; }
		public double FahrenheitNight { get; }
		public double KelvinNight { get; }
		public double CelsiusEvening { get; }
		public double FahrenheitEvening { get; }
		public double KelvinEvening { get; }
		public double CelsiusMorning { get; }
		public double FahrenheitMorning { get; }
		public double KelvinMorning { get; }

		public OneCallTemperatureObj(JToken tempData)
		{
			if (tempData is null)
				throw new ArgumentNullException(nameof(tempData));

			if (tempData.SelectToken("min") != null)
			{
				var min = double.Parse(tempData.SelectToken("min").ToString(), CultureInfo.InvariantCulture);
				KelvinMinimum = min;
				CelsiusMinimum = Utility.convertToCelsius(KelvinMinimum);
				FahrenheitMinimum = Utility.convertToFahrenheit(CelsiusMinimum);
			}

			if (tempData.SelectToken("max") != null)
			{
				var max = double.Parse(tempData.SelectToken("max").ToString(), CultureInfo.InvariantCulture);
				KelvinMaximum = max;
				CelsiusMaximum = Utility.convertToCelsius(KelvinMaximum);
				FahrenheitMaximum = Utility.convertToFahrenheit(CelsiusMaximum);
			}

			var day = double.Parse(tempData.SelectToken("day").ToString(), CultureInfo.InvariantCulture);
			var night = double.Parse(tempData.SelectToken("night").ToString(), CultureInfo.InvariantCulture);
			var eve = double.Parse(tempData.SelectToken("eve").ToString(), CultureInfo.InvariantCulture);
			var morn = double.Parse(tempData.SelectToken("morn").ToString(), CultureInfo.InvariantCulture);

			KelvinDay = day;
			KelvinNight = night;
			KelvinEvening = eve;
			KelvinMorning = morn;

			CelsiusDay = Utility.convertToCelsius(KelvinDay);
			CelsiusNight = Utility.convertToCelsius(KelvinNight);
			CelsiusEvening = Utility.convertToCelsius(KelvinEvening);
			CelsiusMorning = Utility.convertToCelsius(KelvinMorning);

			FahrenheitDay = Utility.convertToFahrenheit(CelsiusDay);
			FahrenheitNight = Utility.convertToFahrenheit(CelsiusNight);
			FahrenheitEvening = Utility.convertToFahrenheit(CelsiusEvening);
			FahrenheitMorning = Utility.convertToFahrenheit(CelsiusMorning);
		}
	}
}
