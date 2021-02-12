using System;

namespace OpenWeatherAPI
{
	public class TemperatureObj
	{
		public double CelsiusCurrent { get; }
		public double FahrenheitCurrent { get; }
		public double KelvinCurrent { get; }
		public double CelsiusMinimum { get; }
		public double CelsiusMaximum { get; }
		public double FahrenheitMinimum { get; }
		public double FahrenheitMaximum { get; }
		public double KelvinMinimum { get; }
		public double KelvinMaximum { get; }

		public TemperatureObj(double temp, double min, double max)
		{
			KelvinCurrent = temp;
			KelvinMaximum = max;
			KelvinMinimum = min;

			CelsiusCurrent = Utility.convertToCelsius(KelvinCurrent);
			CelsiusMaximum = Utility.convertToCelsius(KelvinMaximum);
			CelsiusMinimum = Utility.convertToCelsius(KelvinMinimum);

			FahrenheitCurrent = Utility.convertToFahrenheit(CelsiusCurrent);
			FahrenheitMaximum = Utility.convertToFahrenheit(CelsiusMaximum);
			FahrenheitMinimum = Utility.convertToFahrenheit(CelsiusMinimum);
		}
	}
}
