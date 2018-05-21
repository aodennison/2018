// 2018/05/19 A. Dennison created.

using NUnit.Framework;
using System.Diagnostics;

namespace YahooWeatherApiExamples.Json
{
    [TestFixture]
    public class JsonYahooWeatherQueryUnitTests

    {
        [Test]
        public void Deserialize1Location_ReturnsValidResult()
        {
            string expected = @"
{ City = New York, Region =  NY, Country = United States }
{ Date = 18 May 2018, Day = Fri, High = 65, Low = 54, Text = Cloudy }
{ Date = 19 May 2018, Day = Sat, High = 63, Low = 52, Text = Scattered Showers }
{ Date = 20 May 2018, Day = Sun, High = 79, Low = 64, Text = Scattered Showers }
{ Date = 21 May 2018, Day = Mon, High = 76, Low = 60, Text = Partly Cloudy }
{ Date = 22 May 2018, Day = Tue, High = 67, Low = 61, Text = Thunderstorms }
{ Date = 23 May 2018, Day = Wed, High = 77, Low = 64, Text = Scattered Thunderstorms }
{ Date = 24 May 2018, Day = Thu, High = 70, Low = 62, Text = Partly Cloudy }
{ Date = 25 May 2018, Day = Fri, High = 72, Low = 58, Text = Partly Cloudy }
{ Date = 26 May 2018, Day = Sat, High = 73, Low = 62, Text = Partly Cloudy }
{ Date = 27 May 2018, Day = Sun, High = 76, Low = 64, Text = Scattered Thunderstorms }
";

            string actual = new JsonYahooWeatherQuery().DeserializeAndFormat(Json1Location);

            Debug.WriteLine(actual);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Deserialize2Locations_ReturnsValidResult()
        {
            string expected = @"
{ City = New York, Region =  NY, Country = United States }
{ Date = 18 May 2018, Day = Fri, High = 65, Low = 55, Text = Cloudy }
{ Date = 19 May 2018, Day = Sat, High = 63, Low = 52, Text = Scattered Showers }
{ Date = 20 May 2018, Day = Sun, High = 79, Low = 64, Text = Scattered Showers }
{ Date = 21 May 2018, Day = Mon, High = 76, Low = 60, Text = Partly Cloudy }
{ Date = 22 May 2018, Day = Tue, High = 67, Low = 61, Text = Thunderstorms }
{ Date = 23 May 2018, Day = Wed, High = 77, Low = 64, Text = Scattered Thunderstorms }
{ Date = 24 May 2018, Day = Thu, High = 70, Low = 62, Text = Partly Cloudy }
{ Date = 25 May 2018, Day = Fri, High = 72, Low = 58, Text = Partly Cloudy }
{ Date = 26 May 2018, Day = Sat, High = 73, Low = 62, Text = Partly Cloudy }
{ Date = 27 May 2018, Day = Sun, High = 76, Low = 64, Text = Scattered Thunderstorms }

{ City = Carlisle, Region =  MA, Country = United States }
{ Date = 18 May 2018, Day = Fri, High = 64, Low = 45, Text = Cloudy }
{ Date = 19 May 2018, Day = Sat, High = 55, Low = 44, Text = Showers }
{ Date = 20 May 2018, Day = Sun, High = 76, Low = 56, Text = Scattered Thunderstorms }
{ Date = 21 May 2018, Day = Mon, High = 76, Low = 54, Text = Partly Cloudy }
{ Date = 22 May 2018, Day = Tue, High = 72, Low = 55, Text = Scattered Thunderstorms }
{ Date = 23 May 2018, Day = Wed, High = 72, Low = 58, Text = Mostly Cloudy }
{ Date = 24 May 2018, Day = Thu, High = 67, Low = 54, Text = Partly Cloudy }
{ Date = 25 May 2018, Day = Fri, High = 69, Low = 52, Text = Partly Cloudy }
{ Date = 26 May 2018, Day = Sat, High = 73, Low = 55, Text = Partly Cloudy }
{ Date = 27 May 2018, Day = Sun, High = 73, Low = 57, Text = Partly Cloudy }
";

            string actual = new JsonYahooWeatherQuery().DeserializeAndFormat(Json2Locations);

            Debug.WriteLine(actual);

            Assert.That(actual, Is.EqualTo(expected));
        }

        private static readonly string Json1Location = @"
{
	""query"":
	{
		""count"": 1,
		""created"": ""2018-05-18T22:13:04Z"",
		""lang"": ""en-US"",
		""results"":
		{
			""channel"":
			{
				""units"":
				{
					""distance"": ""mi"",
					""pressure"": ""in"",
					""speed"": ""mph"",
					""temperature"": ""F""
				},
				""title"": ""Yahoo! Weather - New York, NY, US"",
				""link"": ""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/"",
				""description"": ""Yahoo! Weather for New York, NY, US"",
				""language"": ""en-us"",
				""lastBuildDate"": ""Fri, 18 May 2018 06:13 PM EDT"",
				""ttl"": ""60"",
				""location"":
				{
					""city"": ""New York"",
					""country"": ""United States"",
					""region"": "" NY""
				},
				""wind"":
				{
					""chill"": ""63"",
					""direction"": ""90"",
					""speed"": ""22""
				},
				""atmosphere"":
				{
					""humidity"": ""39"",
					""pressure"": ""1025.0"",
					""rising"": ""0"",
					""visibility"": ""16.1""
				},
				""astronomy"":
				{
					""sunrise"": ""5:36 am"",
					""sunset"": ""8:9 pm""
				},
				""image"":
				{
					""title"": ""Yahoo! Weather"",
					""width"": ""142"",
					""height"": ""18"",
					""link"": ""http://weather.yahoo.com"",
					""url"": ""http://l.yimg.com/a/i/brand/purplelogo//uh/us/news-wea.gif""
				},
				""item"":
				{
					""title"": ""Conditions for New York, NY, US at 05:00 PM EDT"",
					""lat"": ""40.71455"",
					""long"": ""-74.007118"",
					""link"": ""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/"",
					""pubDate"": ""Fri, 18 May 2018 05:00 PM EDT"",
					""condition"":
					{
						""code"": ""26"",
						""date"": ""Fri, 18 May 2018 05:00 PM EDT"",
						""temp"": ""64"",
						""text"": ""Cloudy""
					},
					""forecast"": [
						{
							""code"": ""26"",
							""date"": ""18 May 2018"",
							""day"": ""Fri"",
							""high"": ""65"",
							""low"": ""54"",
							""text"": ""Cloudy""
						},
						{
							""code"": ""39"",
							""date"": ""19 May 2018"",
							""day"": ""Sat"",
							""high"": ""63"",
							""low"": ""52"",
							""text"": ""Scattered Showers""
						},
						{
							""code"": ""39"",
							""date"": ""20 May 2018"",
							""day"": ""Sun"",
							""high"": ""79"",
							""low"": ""64"",
							""text"": ""Scattered Showers""
						},
						{
							""code"": ""30"",
							""date"": ""21 May 2018"",
							""day"": ""Mon"",
							""high"": ""76"",
							""low"": ""60"",
							""text"": ""Partly Cloudy""
						},
						{
							""code"": ""4"",
							""date"": ""22 May 2018"",
							""day"": ""Tue"",
							""high"": ""67"",
							""low"": ""61"",
							""text"": ""Thunderstorms""
						},
						{
							""code"": ""47"",
							""date"": ""23 May 2018"",
							""day"": ""Wed"",
							""high"": ""77"",
							""low"": ""64"",
							""text"": ""Scattered Thunderstorms""
						},
						{
							""code"": ""30"",
							""date"": ""24 May 2018"",
							""day"": ""Thu"",
							""high"": ""70"",
							""low"": ""62"",
							""text"": ""Partly Cloudy""
						},
						{
							""code"": ""30"",
							""date"": ""25 May 2018"",
							""day"": ""Fri"",
							""high"": ""72"",
							""low"": ""58"",
							""text"": ""Partly Cloudy""
						},
						{
							""code"": ""30"",
							""date"": ""26 May 2018"",
							""day"": ""Sat"",
							""high"": ""73"",
							""low"": ""62"",
							""text"": ""Partly Cloudy""
						},
						{
							""code"": ""47"",
							""date"": ""27 May 2018"",
							""day"": ""Sun"",
							""high"": ""76"",
							""low"": ""64"",
							""text"": ""Scattered Thunderstorms""
						}
					],
					""description"": ""<![CDATA[<img src=\""http://l.yimg.com/a/i/us/we/52/26.gif\""/>\n<BR />\n<b>Current Conditions:</b>\n<BR />Cloudy\n<BR />\n<BR />\n<b>Forecast:</b>\n<BR /> Fri - Cloudy. High: 65Low: 54\n<BR /> Sat - Scattered Showers. High: 63Low: 52\n<BR /> Sun - Scattered Showers. High: 79Low: 64\n<BR /> Mon - Partly Cloudy. High: 76Low: 60\n<BR /> Tue - Thunderstorms. High: 67Low: 61\n<BR />\n<BR />\n<a href=\""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/\"">Full Forecast at Yahoo! Weather</a>\n<BR />\n<BR />\n<BR />\n]]>"",
					""guid"":
					{
						""isPermaLink"": ""false""
					}
				}
			}
		}
	}
}
";

        private static readonly string Json2Locations = @"
{
	""query"":
	{
		""count"": 2,
		""created"": ""2018-05-18T22:45:06Z"",
		""lang"": ""en-US"",
		""results"":
		{
			""channel"": [
				{
					""units"":
					{
						""distance"": ""mi"",
						""pressure"": ""in"",
						""speed"": ""mph"",
						""temperature"": ""F""
					},
					""title"": ""Yahoo! Weather - New York, NY, US"",
					""link"": ""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/"",
					""description"": ""Yahoo! Weather for New York, NY, US"",
					""language"": ""en-us"",
					""lastBuildDate"": ""Fri, 18 May 2018 06:45 PM EDT"",
					""ttl"": ""60"",
					""location"":
					{
						""city"": ""New York"",
						""country"": ""United States"",
						""region"": "" NY""
					},
					""wind"":
					{
						""chill"": ""61"",
						""direction"": ""85"",
						""speed"": ""22""
					},
					""atmosphere"":
					{
						""humidity"": ""43"",
						""pressure"": ""1025.0"",
						""rising"": ""0"",
						""visibility"": ""16.1""
					},
					""astronomy"":
					{
						""sunrise"": ""5:36 am"",
						""sunset"": ""8:9 pm""
					},
					""image"":
					{
						""title"": ""Yahoo! Weather"",
						""width"": ""142"",
						""height"": ""18"",
						""link"": ""http://weather.yahoo.com"",
						""url"": ""http://l.yimg.com/a/i/brand/purplelogo//uh/us/news-wea.gif""
					},
					""item"":
					{
						""title"": ""Conditions for New York, NY, US at 06:00 PM EDT"",
						""lat"": ""40.71455"",
						""long"": ""-74.007118"",
						""link"": ""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/"",
						""pubDate"": ""Fri, 18 May 2018 06:00 PM EDT"",
						""condition"":
						{
							""code"": ""26"",
							""date"": ""Fri, 18 May 2018 06:00 PM EDT"",
							""temp"": ""63"",
							""text"": ""Cloudy""
						},
						""forecast"": [
							{
								""code"": ""26"",
								""date"": ""18 May 2018"",
								""day"": ""Fri"",
								""high"": ""65"",
								""low"": ""55"",
								""text"": ""Cloudy""
							},
							{
								""code"": ""39"",
								""date"": ""19 May 2018"",
								""day"": ""Sat"",
								""high"": ""63"",
								""low"": ""52"",
								""text"": ""Scattered Showers""
							},
							{
								""code"": ""39"",
								""date"": ""20 May 2018"",
								""day"": ""Sun"",
								""high"": ""79"",
								""low"": ""64"",
								""text"": ""Scattered Showers""
							},
							{
								""code"": ""30"",
								""date"": ""21 May 2018"",
								""day"": ""Mon"",
								""high"": ""76"",
								""low"": ""60"",
								""text"": ""Partly Cloudy""
							},
							{
								""code"": ""4"",
								""date"": ""22 May 2018"",
								""day"": ""Tue"",
								""high"": ""67"",
								""low"": ""61"",
								""text"": ""Thunderstorms""
							},
							{
								""code"": ""47"",
								""date"": ""23 May 2018"",
								""day"": ""Wed"",
								""high"": ""77"",
								""low"": ""64"",
								""text"": ""Scattered Thunderstorms""
							},
							{
								""code"": ""30"",
								""date"": ""24 May 2018"",
								""day"": ""Thu"",
								""high"": ""70"",
								""low"": ""62"",
								""text"": ""Partly Cloudy""
							},
							{
								""code"": ""30"",
								""date"": ""25 May 2018"",
								""day"": ""Fri"",
								""high"": ""72"",
								""low"": ""58"",
								""text"": ""Partly Cloudy""
							},
							{
								""code"": ""30"",
								""date"": ""26 May 2018"",
								""day"": ""Sat"",
								""high"": ""73"",
								""low"": ""62"",
								""text"": ""Partly Cloudy""
							},
							{
								""code"": ""47"",
								""date"": ""27 May 2018"",
								""day"": ""Sun"",
								""high"": ""76"",
								""low"": ""64"",
								""text"": ""Scattered Thunderstorms""
							}
						],
						""description"": ""<![CDATA[<img src=\""http://l.yimg.com/a/i/us/we/52/26.gif\""/>\n<BR />\n<b>Current Conditions:</b>\n<BR />Cloudy\n<BR />\n<BR />\n<b>Forecast:</b>\n<BR /> Fri - Cloudy. High: 65Low: 55\n<BR /> Sat - Scattered Showers. High: 63Low: 52\n<BR /> Sun - Scattered Showers. High: 79Low: 64\n<BR /> Mon - Partly Cloudy. High: 76Low: 60\n<BR /> Tue - Thunderstorms. High: 67Low: 61\n<BR />\n<BR />\n<a href=\""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/\"">Full Forecast at Yahoo! Weather</a>\n<BR />\n<BR />\n<BR />\n]]>"",
						""guid"":
						{
							""isPermaLink"": ""false""
						}
					}
				},
				{
					""units"":
					{
						""distance"": ""mi"",
						""pressure"": ""in"",
						""speed"": ""mph"",
						""temperature"": ""F""
					},
					""title"": ""Yahoo! Weather - Carlisle, MA, US"",
					""link"": ""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-12758554/"",
					""description"": ""Yahoo! Weather for Carlisle, MA, US"",
					""language"": ""en-us"",
					""lastBuildDate"": ""Fri, 18 May 2018 06:45 PM EDT"",
					""ttl"": ""60"",
					""location"":
					{
						""city"": ""Carlisle"",
						""country"": ""United States"",
						""region"": "" MA""
					},
					""wind"":
					{
						""chill"": ""55"",
						""direction"": ""100"",
						""speed"": ""11""
					},
					""atmosphere"":
					{
						""humidity"": ""36"",
						""pressure"": ""1022.0"",
						""rising"": ""0"",
						""visibility"": ""16.1""
					},
					""astronomy"":
					{
						""sunrise"": ""5:21 am"",
						""sunset"": ""8:3 pm""
					},
					""image"":
					{
						""title"": ""Yahoo! Weather"",
						""width"": ""142"",
						""height"": ""18"",
						""link"": ""http://weather.yahoo.com"",
						""url"": ""http://l.yimg.com/a/i/brand/purplelogo//uh/us/news-wea.gif""
					},
					""item"":
					{
						""title"": ""Conditions for Carlisle, MA, US at 06:00 PM EDT"",
						""lat"": ""42.5298"",
						""long"": ""-71.351089"",
						""link"": ""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-12758554/"",
						""pubDate"": ""Fri, 18 May 2018 06:00 PM EDT"",
						""condition"":
						{
							""code"": ""26"",
							""date"": ""Fri, 18 May 2018 06:00 PM EDT"",
							""temp"": ""56"",
							""text"": ""Cloudy""
						},
						""forecast"": [
							{
								""code"": ""26"",
								""date"": ""18 May 2018"",
								""day"": ""Fri"",
								""high"": ""64"",
								""low"": ""45"",
								""text"": ""Cloudy""
							},
							{
								""code"": ""11"",
								""date"": ""19 May 2018"",
								""day"": ""Sat"",
								""high"": ""55"",
								""low"": ""44"",
								""text"": ""Showers""
							},
							{
								""code"": ""47"",
								""date"": ""20 May 2018"",
								""day"": ""Sun"",
								""high"": ""76"",
								""low"": ""56"",
								""text"": ""Scattered Thunderstorms""
							},
							{
								""code"": ""30"",
								""date"": ""21 May 2018"",
								""day"": ""Mon"",
								""high"": ""76"",
								""low"": ""54"",
								""text"": ""Partly Cloudy""
							},
							{
								""code"": ""47"",
								""date"": ""22 May 2018"",
								""day"": ""Tue"",
								""high"": ""72"",
								""low"": ""55"",
								""text"": ""Scattered Thunderstorms""
							},
							{
								""code"": ""28"",
								""date"": ""23 May 2018"",
								""day"": ""Wed"",
								""high"": ""72"",
								""low"": ""58"",
								""text"": ""Mostly Cloudy""
							},
							{
								""code"": ""30"",
								""date"": ""24 May 2018"",
								""day"": ""Thu"",
								""high"": ""67"",
								""low"": ""54"",
								""text"": ""Partly Cloudy""
							},
							{
								""code"": ""30"",
								""date"": ""25 May 2018"",
								""day"": ""Fri"",
								""high"": ""69"",
								""low"": ""52"",
								""text"": ""Partly Cloudy""
							},
							{
								""code"": ""30"",
								""date"": ""26 May 2018"",
								""day"": ""Sat"",
								""high"": ""73"",
								""low"": ""55"",
								""text"": ""Partly Cloudy""
							},
							{
								""code"": ""30"",
								""date"": ""27 May 2018"",
								""day"": ""Sun"",
								""high"": ""73"",
								""low"": ""57"",
								""text"": ""Partly Cloudy""
							}
						],
						""description"": ""<![CDATA[<img src=\""http://l.yimg.com/a/i/us/we/52/26.gif\""/>\n<BR />\n<b>Current Conditions:</b>\n<BR />Cloudy\n<BR />\n<BR />\n<b>Forecast:</b>\n<BR /> Fri - Cloudy. High: 64Low: 45\n<BR /> Sat - Showers. High: 55Low: 44\n<BR /> Sun - Scattered Thunderstorms. High: 76Low: 56\n<BR /> Mon - Partly Cloudy. High: 76Low: 54\n<BR /> Tue - Scattered Thunderstorms. High: 72Low: 55\n<BR />\n<BR />\n<a href=\""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-12758554/\"">Full Forecast at Yahoo! Weather</a>\n<BR />\n<BR />\n<BR />\n]]>"",
						""guid"":
						{
							""isPermaLink"": ""false""
						}
					}
				}
			]
		}
	}
}
";
    }
}
