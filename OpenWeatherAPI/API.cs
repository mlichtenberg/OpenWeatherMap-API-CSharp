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

		public CurrentWeather CurrentWeather(string queryStr)
		{
			CurrentWeather newQuery = new CurrentWeather(openWeatherAPIKey, queryStr);
			if (newQuery.ValidRequest) return newQuery;
			return null;
		}

		public OneCall OneCall(double lat, double lon)
		{
			List<string> exclude = new List<string>();
			return OneCall(lat, lon, exclude);
		}

		public OneCall OneCall(double lat, double lon, List<string> exclude)
		{
			OneCall oneCall = new OneCall(openWeatherAPIKey, lat, lon, exclude);
			if (oneCall.ValidRequest) return oneCall;
			return null;
		}
	}
}
