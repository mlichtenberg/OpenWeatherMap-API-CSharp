using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace OpenWeatherAPI
{
	public class Alert
	{
		public string SenderName { get; set; }
		public string Event { get; set; }
		public string Description { get; set; }
		public DateTime Start { get; }
		public DateTime End { get; }

		public Alert(JToken alertData)
		{
			if (alertData is null)
				throw new System.ArgumentNullException(nameof(alertData));

			SenderName = alertData.SelectToken("sender_name").ToString();
			Event = alertData.SelectToken("event").ToString();
			Description = alertData.SelectToken("description").ToString();
			Start = Utility.convertUnixToDateTime(double.Parse(alertData.SelectToken("start").ToString(), CultureInfo.InvariantCulture));
			End = Utility.convertUnixToDateTime(double.Parse(alertData.SelectToken("end").ToString(), CultureInfo.InvariantCulture));
		}

	}
}
