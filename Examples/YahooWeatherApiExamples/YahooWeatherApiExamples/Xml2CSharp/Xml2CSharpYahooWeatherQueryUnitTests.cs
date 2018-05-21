// 2018/05/19 A. Dennison created.

using NUnit.Framework;
using System.Diagnostics;

namespace YahooWeatherApiExamples.Xml2CSharp
{
    [TestFixture]
    public class Xml2CSharpYahooWeatherQueryUnitTests
    {
        [Test]
        public void Deserialize1Location_ReturnsValidResult()
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
";

            string actual = new Xml2CSharpYahooWeatherQuery().DeserializeAndFormat(Xml1Location);

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

            string actual = new Xml2CSharpYahooWeatherQuery().DeserializeAndFormat(Xml2Locations);

            Debug.WriteLine(actual);

            Assert.That(actual, Is.EqualTo(expected));
        }

        private static readonly string Xml1Location = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<query xmlns:yahoo=""http://www.yahooapis.com/v1/base.rng"" yahoo:count=""1"" yahoo:created=""2018-05-18T22:42:44Z"" yahoo:lang=""en-US"">
	<results>
		<channel>
			<yweather:units xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" distance=""mi"" pressure=""in"" speed=""mph"" temperature=""F""/>
			<title>Yahoo! Weather - New York, NY, US</title>
			<link>http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/</link>
			<description>Yahoo! Weather for New York, NY, US</description>
			<language>en-us</language>
			<lastBuildDate>Fri, 18 May 2018 06:42 PM EDT</lastBuildDate>
			<ttl>60</ttl>
			<yweather:location xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" city=""New York"" country=""United States"" region="" NY""/>
			<yweather:wind xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" chill=""61"" direction=""85"" speed=""22""/>
			<yweather:atmosphere xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" humidity=""43"" pressure=""1025.0"" rising=""0"" visibility=""16.1""/>
			<yweather:astronomy xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" sunrise=""5:36 am"" sunset=""8:9 pm""/>
			<image>
				<title>Yahoo! Weather</title>
				<width>142</width>
				<height>18</height>
				<link>http://weather.yahoo.com</link>
				<url>http://l.yimg.com/a/i/brand/purplelogo//uh/us/news-wea.gif</url>
			</image>
			<item>
				<title>Conditions for New York, NY, US at 06:00 PM EDT</title>
				<geo:lat xmlns:geo=""http://www.w3.org/2003/01/geo/wgs84_pos#"">40.71455</geo:lat>
				<geo:long xmlns:geo=""http://www.w3.org/2003/01/geo/wgs84_pos#"">-74.007118</geo:long>
				<link>http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/</link>
				<pubDate>Fri, 18 May 2018 06:00 PM EDT</pubDate>
				<yweather:condition xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""26"" date=""Fri, 18 May 2018 06:00 PM EDT"" temp=""63"" text=""Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""26"" date=""18 May 2018"" day=""Fri"" high=""65"" low=""55"" text=""Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""39"" date=""19 May 2018"" day=""Sat"" high=""63"" low=""52"" text=""Scattered Showers""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""39"" date=""20 May 2018"" day=""Sun"" high=""79"" low=""64"" text=""Scattered Showers""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""21 May 2018"" day=""Mon"" high=""76"" low=""60"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""4"" date=""22 May 2018"" day=""Tue"" high=""67"" low=""61"" text=""Thunderstorms""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""47"" date=""23 May 2018"" day=""Wed"" high=""77"" low=""64"" text=""Scattered Thunderstorms""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""24 May 2018"" day=""Thu"" high=""70"" low=""62"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""25 May 2018"" day=""Fri"" high=""72"" low=""58"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""26 May 2018"" day=""Sat"" high=""73"" low=""62"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""47"" date=""27 May 2018"" day=""Sun"" high=""76"" low=""64"" text=""Scattered Thunderstorms""/>
				<description>&lt;![CDATA[&lt;img src=""http://l.yimg.com/a/i/us/we/52/26.gif""/&gt;
&lt;BR /&gt;
&lt;b&gt;Current Conditions:&lt;/b&gt;
&lt;BR /&gt;Cloudy
&lt;BR /&gt;
&lt;BR /&gt;
&lt;b&gt;Forecast:&lt;/b&gt;
&lt;BR /&gt; Fri - Cloudy. High: 65Low: 55
&lt;BR /&gt; Sat - Scattered Showers. High: 63Low: 52
&lt;BR /&gt; Sun - Scattered Showers. High: 79Low: 64
&lt;BR /&gt; Mon - Partly Cloudy. High: 76Low: 60
&lt;BR /&gt; Tue - Thunderstorms. High: 67Low: 61
&lt;BR /&gt;
&lt;BR /&gt;
&lt;a href=""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/""&gt;Full Forecast at Yahoo! Weather&lt;/a&gt;
&lt;BR /&gt;
&lt;BR /&gt;
&lt;BR /&gt;
]]&gt;</description>
				<guid isPermaLink=""false""/>
			</item>
		</channel>
	</results>
</query>
<!-- total: 8 -->
";

        private static readonly string Xml2Locations = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<query xmlns:yahoo=""http://www.yahooapis.com/v1/base.rng"" yahoo:count=""2"" yahoo:created=""2018-05-18T22:42:11Z"" yahoo:lang=""en-US"">
	<results>
		<channel>
			<yweather:units xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" distance=""mi"" pressure=""in"" speed=""mph"" temperature=""F""/>
			<title>Yahoo! Weather - New York, NY, US</title>
			<link>http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/</link>
			<description>Yahoo! Weather for New York, NY, US</description>
			<language>en-us</language>
			<lastBuildDate>Fri, 18 May 2018 06:42 PM EDT</lastBuildDate>
			<ttl>60</ttl>
			<yweather:location xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" city=""New York"" country=""United States"" region="" NY""/>
			<yweather:wind xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" chill=""61"" direction=""85"" speed=""22""/>
			<yweather:atmosphere xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" humidity=""43"" pressure=""1025.0"" rising=""0"" visibility=""16.1""/>
			<yweather:astronomy xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" sunrise=""5:36 am"" sunset=""8:9 pm""/>
			<image>
				<title>Yahoo! Weather</title>
				<width>142</width>
				<height>18</height>
				<link>http://weather.yahoo.com</link>
				<url>http://l.yimg.com/a/i/brand/purplelogo//uh/us/news-wea.gif</url>
			</image>
			<item>
				<title>Conditions for New York, NY, US at 06:00 PM EDT</title>
				<geo:lat xmlns:geo=""http://www.w3.org/2003/01/geo/wgs84_pos#"">40.71455</geo:lat>
				<geo:long xmlns:geo=""http://www.w3.org/2003/01/geo/wgs84_pos#"">-74.007118</geo:long>
				<link>http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/</link>
				<pubDate>Fri, 18 May 2018 06:00 PM EDT</pubDate>
				<yweather:condition xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""26"" date=""Fri, 18 May 2018 06:00 PM EDT"" temp=""63"" text=""Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""26"" date=""18 May 2018"" day=""Fri"" high=""65"" low=""55"" text=""Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""39"" date=""19 May 2018"" day=""Sat"" high=""63"" low=""52"" text=""Scattered Showers""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""39"" date=""20 May 2018"" day=""Sun"" high=""79"" low=""64"" text=""Scattered Showers""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""21 May 2018"" day=""Mon"" high=""76"" low=""60"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""4"" date=""22 May 2018"" day=""Tue"" high=""67"" low=""61"" text=""Thunderstorms""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""47"" date=""23 May 2018"" day=""Wed"" high=""77"" low=""64"" text=""Scattered Thunderstorms""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""24 May 2018"" day=""Thu"" high=""70"" low=""62"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""25 May 2018"" day=""Fri"" high=""72"" low=""58"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""26 May 2018"" day=""Sat"" high=""73"" low=""62"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""47"" date=""27 May 2018"" day=""Sun"" high=""76"" low=""64"" text=""Scattered Thunderstorms""/>
				<description>&lt;![CDATA[&lt;img src=""http://l.yimg.com/a/i/us/we/52/26.gif""/&gt;
&lt;BR /&gt;
&lt;b&gt;Current Conditions:&lt;/b&gt;
&lt;BR /&gt;Cloudy
&lt;BR /&gt;
&lt;BR /&gt;
&lt;b&gt;Forecast:&lt;/b&gt;
&lt;BR /&gt; Fri - Cloudy. High: 65Low: 55
&lt;BR /&gt; Sat - Scattered Showers. High: 63Low: 52
&lt;BR /&gt; Sun - Scattered Showers. High: 79Low: 64
&lt;BR /&gt; Mon - Partly Cloudy. High: 76Low: 60
&lt;BR /&gt; Tue - Thunderstorms. High: 67Low: 61
&lt;BR /&gt;
&lt;BR /&gt;
&lt;a href=""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-2459115/""&gt;Full Forecast at Yahoo! Weather&lt;/a&gt;
&lt;BR /&gt;
&lt;BR /&gt;
&lt;BR /&gt;
]]&gt;</description>
				<guid isPermaLink=""false""/>
			</item>
		</channel>
		<channel>
			<yweather:units xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" distance=""mi"" pressure=""in"" speed=""mph"" temperature=""F""/>
			<title>Yahoo! Weather - Carlisle, MA, US</title>
			<link>http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-12758554/</link>
			<description>Yahoo! Weather for Carlisle, MA, US</description>
			<language>en-us</language>
			<lastBuildDate>Fri, 18 May 2018 06:42 PM EDT</lastBuildDate>
			<ttl>60</ttl>
			<yweather:location xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" city=""Carlisle"" country=""United States"" region="" MA""/>
			<yweather:wind xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" chill=""55"" direction=""100"" speed=""11""/>
			<yweather:atmosphere xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" humidity=""36"" pressure=""1022.0"" rising=""0"" visibility=""16.1""/>
			<yweather:astronomy xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" sunrise=""5:21 am"" sunset=""8:3 pm""/>
			<image>
				<title>Yahoo! Weather</title>
				<width>142</width>
				<height>18</height>
				<link>http://weather.yahoo.com</link>
				<url>http://l.yimg.com/a/i/brand/purplelogo//uh/us/news-wea.gif</url>
			</image>
			<item>
				<title>Conditions for Carlisle, MA, US at 06:00 PM EDT</title>
				<geo:lat xmlns:geo=""http://www.w3.org/2003/01/geo/wgs84_pos#"">42.5298</geo:lat>
				<geo:long xmlns:geo=""http://www.w3.org/2003/01/geo/wgs84_pos#"">-71.351089</geo:long>
				<link>http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-12758554/</link>
				<pubDate>Fri, 18 May 2018 06:00 PM EDT</pubDate>
				<yweather:condition xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""26"" date=""Fri, 18 May 2018 06:00 PM EDT"" temp=""56"" text=""Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""26"" date=""18 May 2018"" day=""Fri"" high=""64"" low=""45"" text=""Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""11"" date=""19 May 2018"" day=""Sat"" high=""55"" low=""44"" text=""Showers""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""47"" date=""20 May 2018"" day=""Sun"" high=""76"" low=""56"" text=""Scattered Thunderstorms""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""21 May 2018"" day=""Mon"" high=""76"" low=""54"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""47"" date=""22 May 2018"" day=""Tue"" high=""72"" low=""55"" text=""Scattered Thunderstorms""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""28"" date=""23 May 2018"" day=""Wed"" high=""72"" low=""58"" text=""Mostly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""24 May 2018"" day=""Thu"" high=""67"" low=""54"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""25 May 2018"" day=""Fri"" high=""69"" low=""52"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""26 May 2018"" day=""Sat"" high=""73"" low=""55"" text=""Partly Cloudy""/>
				<yweather:forecast xmlns:yweather=""http://xml.weather.yahoo.com/ns/rss/1.0"" code=""30"" date=""27 May 2018"" day=""Sun"" high=""73"" low=""57"" text=""Partly Cloudy""/>
				<description>&lt;![CDATA[&lt;img src=""http://l.yimg.com/a/i/us/we/52/26.gif""/&gt;
&lt;BR /&gt;
&lt;b&gt;Current Conditions:&lt;/b&gt;
&lt;BR /&gt;Cloudy
&lt;BR /&gt;
&lt;BR /&gt;
&lt;b&gt;Forecast:&lt;/b&gt;
&lt;BR /&gt; Fri - Cloudy. High: 64Low: 45
&lt;BR /&gt; Sat - Showers. High: 55Low: 44
&lt;BR /&gt; Sun - Scattered Thunderstorms. High: 76Low: 56
&lt;BR /&gt; Mon - Partly Cloudy. High: 76Low: 54
&lt;BR /&gt; Tue - Scattered Thunderstorms. High: 72Low: 55
&lt;BR /&gt;
&lt;BR /&gt;
&lt;a href=""http://us.rd.yahoo.com/dailynews/rss/weather/Country__Country/*https://weather.yahoo.com/country/state/city-12758554/""&gt;Full Forecast at Yahoo! Weather&lt;/a&gt;
&lt;BR /&gt;
&lt;BR /&gt;
&lt;BR /&gt;
]]&gt;</description>
				<guid isPermaLink=""false""/>
			</item>
		</channel>
	</results>
</query>
<!-- total: 18 --> 
";
    }
}
