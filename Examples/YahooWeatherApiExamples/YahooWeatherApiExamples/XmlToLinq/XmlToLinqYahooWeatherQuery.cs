using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace YahooWeatherApiExamples.XmlToLinq
{
    public class XmlToLinqYahooWeatherQuery : YahooWeatherQuery
    {
        public XmlToLinqYahooWeatherQuery() : base(useJsonFormat: false) { }

        #region Overrides of YahooWeatherQuery

        public override string DeserializeAndFormat(string responseData)
        {
            // linq based
            XDocument xDocument = XDocument.Parse(responseData);

            return Format(xDocument);
        }

        public static string Format(XDocument xDocument)
        {
            //xDocument.Root.GenerateNamespaceCode();
            //XNamespace yahoo = "http://www.yahooapis.com/v1/base.rng";
            XNamespace yweather = "http://xml.weather.yahoo.com/ns/rss/1.0";
            // XNamespace geo = "http://www.w3.org/2003/01/geo/wgs84_pos#";

            using (StringWriter stringWriter = new StringWriter())
            {
                IEnumerable<XElement> channels = xDocument.Root?.Elements("results").Elements("channel")
                    ?? Enumerable.Empty<XElement>();

                foreach (XElement channel in channels)
                {
                    stringWriter.WriteLine("");
                    XElement l = channel.Element(yweather + "location");
                    stringWriter.WriteLine(
                        new
                        {
                            City = l.GetAttributeValueOrDefault("city"),
                            Region = l.GetAttributeValueOrDefault("region"),
                            Country = l.GetAttributeValueOrDefault("country")
                        });

                    foreach (XElement f in channel?.Elements("item")?.Elements(yweather + "forecast"))
                    {
                        stringWriter.WriteLine(
                            new
                            {
                                Date = f.GetAttributeValueOrDefault("date"),
                                Day = f.GetAttributeValueOrDefault("day"),
                                High = f.GetAttributeValueOrDefault("high"),
                                Low = f.GetAttributeValueOrDefault("low"),
                                Text = f.GetAttributeValueOrDefault("text")
                            });
                    }
                }

                return stringWriter.ToString();
            }

            #endregion
        }
    }

    internal static class XElementExtensions
    {
        /// <summary>
        /// Gets the attribute value or default.
        /// </summary>
        /// <param name="xElement"> The x element. </param>
        /// <param name="attributeXName"> XName of the attribute. </param>
        /// <param name="defaultValue"> The default value. </param>
        [CanBeNull]
        internal static string GetAttributeValueOrDefault(
            [CanBeNull] this XElement xElement,
            [NotNull] XName attributeXName,
            [CanBeNull] string defaultValue = null)
        {
            if (attributeXName == null) throw new ArgumentNullException("attributeXName");

            string result = xElement?.Attribute(attributeXName)?.Value ?? defaultValue;

            return result;
        }
    }
}
