	using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Wind
	{
		public double Speed { get; }

		public DirectionEnum Direction { get; }

		public double Degree { get; }

		public double Gust { get; }

		public Wind(JToken windData)
		{
			if (windData is null)
				throw new System.ArgumentNullException(nameof(windData));

			if (windData.SelectToken("speed") != null)
				Speed = double.Parse(windData.SelectToken("speed").ToString(), CultureInfo.InvariantCulture);
			else if (windData.SelectToken("wind_speed") != null)
				Speed = double.Parse(windData.SelectToken("wind_speed").ToString(), CultureInfo.InvariantCulture);

			if (windData.SelectToken("deg") != null)
				Degree = double.Parse(windData.SelectToken("deg").ToString(), CultureInfo.InvariantCulture);
			else if (windData.SelectToken("wind_deg") != null)
				Degree = double.Parse(windData.SelectToken("wind_deg").ToString(), CultureInfo.InvariantCulture);

			Direction = Utility.assignDirection(Degree);

			if (windData.SelectToken("gust") != null)
				Gust = double.Parse(windData.SelectToken("gust").ToString(), CultureInfo.InvariantCulture);
			else if (windData.SelectToken("wind_gust") != null)
				Gust = double.Parse(windData.SelectToken("wind_gust").ToString(), CultureInfo.InvariantCulture);
		}
	}
}
