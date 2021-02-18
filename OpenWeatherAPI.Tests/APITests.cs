using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace OpenWeatherAPI.Tests
{
	/// <summary>
	/// Tests <see cref="API"/>
	/// </summary>
	public class APITests
	{
		[Fact()]
		public void CurrentWeatherTest_Success()
		{
			//Arrange
			var api = new API(System.Configuration.ConfigurationManager.AppSettings["APIKey"]); //No good solution here to have safe and valid OpenWeather API keys in a test

			//Act
			var actual = api.CurrentWeather("Rotterdam,NL");

			//Assert
			Assert.True(actual.ValidRequest);

			Trace.WriteLine(JsonConvert.SerializeObject(actual, Formatting.Indented));
		}

		[Fact()]
		public void OneCallTest_Success()
		{
			var api = new API(System.Configuration.ConfigurationManager.AppSettings["APIKey"]);
			var actual = api.OneCall(51.9244, 4.4777, new List<string>(new string[] { ExcludeEnum.Current, ExcludeEnum.Minutely }));
			Assert.True(actual.ValidRequest);
			Trace.WriteLine(JsonConvert.SerializeObject(actual, Formatting.Indented));
		}
	}
}
