using System.Collections.Generic;

namespace OpenWeatherAPI
{
	public class API
	{
		private string openWeatherAPIKey;

		public API(string apiKey)
		{
			openWeatherAPIKey = apiKey;
		}

		public CurrentWeather CurrentWeather(string queryStr, UnitsEnum units = UnitsEnum.Standard)
		{
			CurrentWeather newQuery = new CurrentWeather(openWeatherAPIKey, queryStr, units);
			if (newQuery.ValidRequest) return newQuery;
			return null;
		}

		public OneCall OneCall(double lat, double lon, UnitsEnum units = UnitsEnum.Standard)
		{
			List<string> exclude = new List<string>();
			return OneCall(lat, lon, exclude, units);
		}

		public OneCall OneCall(double lat, double lon, List<string> exclude, UnitsEnum units = UnitsEnum.Standard)
		{
			OneCall oneCall = new OneCall(openWeatherAPIKey, lat, lon, exclude, units);
			if (oneCall.ValidRequest) return oneCall;
			return null;
		}
	}
}
