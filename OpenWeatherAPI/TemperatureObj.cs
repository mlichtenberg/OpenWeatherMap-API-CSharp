using System;

namespace OpenWeatherAPI
{
	public class TemperatureObj
	{
		public double Current { get; }
		public double Minimum { get; }
		public double Maximum { get; }

		public TemperatureObj(double temp, double min, double max)
		{
			Current = temp;
			Maximum = max;
			Minimum = min;
		}
	}
}
