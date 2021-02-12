using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenWeatherAPI
{
	public class OneCall
	{
		public bool ValidRequest { get; }
		public double Lat { get; set; }
		public double Lon { get; set; }
		public string Timezone { get; set; }
		public int TimezoneOffset { get; set; }
		public List<Alert> Alerts{ get; } = new List<Alert>();
		public OneCallCurrentWeather Current { get; } = null;
		public List<Hour> Hourly { get; } = new List<Hour>();
		public List<Day> Daily { get; } = new List<Day>();
		public List<Minute> Minutely { get; } = new List<Minute>();

		public OneCall(string apiKey, double lat, double lon, List<string> exclude)
		{
			if (exclude == null) exclude = new List<string>();

			try
			{
				string excludeList = string.Join(",", exclude.ToArray());

				JObject jsonData;
				using (var client = new System.Net.WebClient())
					jsonData = JObject.Parse(client.DownloadString($"http://api.openweathermap.org/data/2.5/onecall?appid={apiKey}&lat={lat}&lon={lon}&exclude={excludeList}"));

				Lat = double.Parse(jsonData.SelectToken("lat").ToString(), CultureInfo.InvariantCulture);
				Lon = double.Parse(jsonData.SelectToken("lon").ToString(), CultureInfo.InvariantCulture);
				Timezone = jsonData.SelectToken("timezone").ToString();
				TimezoneOffset = int.Parse(jsonData.SelectToken("timezone_offset").ToString(), CultureInfo.InvariantCulture);

				if (!exclude.Contains(ExcludeEnum.Alerts))
				{
					if (jsonData.SelectToken("alerts") != null)
					{
						foreach (JToken alert in jsonData.SelectToken("alerts"))
							Alerts.Add(new Alert(alert));
					}
				}
				if (!exclude.Contains(ExcludeEnum.Current))
				{
					Current = new OneCallCurrentWeather(jsonData.SelectToken("current"));
				}
				if (!exclude.Contains(ExcludeEnum.Daily))
				{
					foreach (JToken day in jsonData.SelectToken("daily"))
						Daily.Add(new Day(day));
				}
				if (!exclude.Contains(ExcludeEnum.Hourly))
				{
					foreach (JToken hour in jsonData.SelectToken("hourly"))
						Hourly.Add(new Hour(hour));
				}
				if (!exclude.Contains(ExcludeEnum.Minutely))
				{
					foreach (JToken minute in jsonData.SelectToken("minutely"))
						Minutely.Add(new Minute(minute));
				}

				ValidRequest = true;
			}
			catch
			{
				ValidRequest = false;
			}
		}
	}
}
