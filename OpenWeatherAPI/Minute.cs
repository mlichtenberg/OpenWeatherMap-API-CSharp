using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Minute
	{
		public DateTime DateTime { get; }
		public double Precipitation { get; }

		public Minute(JToken minuteData)
		{
			if (minuteData is null)
				throw new ArgumentNullException(nameof(minuteData));

			DateTime = Utility.convertUnixToDateTime(double.Parse(minuteData.SelectToken("dt").ToString(), CultureInfo.InvariantCulture));
			Precipitation = double.Parse(minuteData.SelectToken("precipitation").ToString(), CultureInfo.InvariantCulture);
		}
	}
}
