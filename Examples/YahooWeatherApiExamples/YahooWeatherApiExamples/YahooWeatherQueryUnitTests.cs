// 2018/05/19 A. Dennison created.

using NUnit.Framework;
using System;
using System.Diagnostics;

namespace YahooWeatherApiExamples
{
    [TestFixture]
    public class YahooWeatherQueryUnitTests
    {
        [Test]
        public void LocationsQuery_ReturnsValidQueryString()
        {
            string expected =
                "?q=select%20%2A%20from%20weather.forecast%20where%20woeid%20in%20%28select%20woeid%20from%20geo.places%281%29where%20text%20in%20%28%27New%20York%27%2C%2701741%27%29%29%20and%20u%3D%27f%27&format=json";

            Debug.WriteLine(new { expect = Uri.UnescapeDataString(expected) });

            const bool useJsonFormat = true;
            string actual = YahooWeatherQuery.GetLocationsQueryString(useJsonFormat, "New York", "01741");

            Debug.WriteLine(new { actual = Uri.UnescapeDataString(actual) });

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
