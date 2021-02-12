using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Wind
	{
		public double SpeedMetersPerSecond { get; }

		public double SpeedFeetPerSecond { get; }

		public DirectionEnum Direction { get; }

		public double Degree { get; }

		public double Gust { get; }

		public Wind(JToken windData)
		{
			if (windData is null)
				throw new System.ArgumentNullException(nameof(windData));


			SpeedMetersPerSecond = double.Parse(windData.SelectToken("speed").ToString(), CultureInfo.InvariantCulture);
			SpeedFeetPerSecond = SpeedMetersPerSecond * 3.28084;
			Degree = double.Parse(windData.SelectToken("deg").ToString(), CultureInfo.InvariantCulture);
			Direction = Utility.assignDirection(Degree);
			if (windData.SelectToken("gust") != null)
				Gust = double.Parse(windData.SelectToken("gust").ToString(), CultureInfo.InvariantCulture);
		}
	}
}
