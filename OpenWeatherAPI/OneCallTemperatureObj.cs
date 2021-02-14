using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenWeatherAPI
{
	public class OneCallTemperatureObj
	{
		public double Day { get; }
		public double Minimum { get; }
		public double Maximum { get; }
		public double Night { get; }
		public double Evening { get; }
		public double Morning { get; }

		public OneCallTemperatureObj(JToken tempData)
		{
			if (tempData is null)
				throw new ArgumentNullException(nameof(tempData));

			if (tempData.SelectToken("min") != null)
			{
				Minimum = double.Parse(tempData.SelectToken("min").ToString(), CultureInfo.InvariantCulture);
			}

			if (tempData.SelectToken("max") != null)
			{
				Maximum = double.Parse(tempData.SelectToken("max").ToString(), CultureInfo.InvariantCulture);
			}

			Day = double.Parse(tempData.SelectToken("day").ToString(), CultureInfo.InvariantCulture);
			Night = double.Parse(tempData.SelectToken("night").ToString(), CultureInfo.InvariantCulture);
			Evening = double.Parse(tempData.SelectToken("eve").ToString(), CultureInfo.InvariantCulture);
			Morning = double.Parse(tempData.SelectToken("morn").ToString(), CultureInfo.InvariantCulture);
		}
	}
}
