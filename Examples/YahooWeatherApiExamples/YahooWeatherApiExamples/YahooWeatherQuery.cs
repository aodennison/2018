using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using JetBrains.Annotations;

namespace YahooWeatherApiExamples
{
    /// <summary>
    /// Encapsulates some of the details common to Yahoo Weather API queries
    /// </summary>
    public abstract class YahooWeatherQuery
    {
        private readonly bool _useJsonFormat;
        static readonly string ApiAddressPrefix = @"https://query.yahooapis.com/v1/public/yql";

        protected YahooWeatherQuery(bool useJsonFormat) { _useJsonFormat = useJsonFormat; }

        public string GetWeatherInfo(params string[] locations)
        {
            string uri = ApiAddressPrefix + GetLocationsQueryString(_useJsonFormat, locations);

            string responseData = GetResponse(uri);

            return responseData;
        }

        public abstract string DeserializeAndFormat(string responseData);

     internal static string GetLocationsQueryString(bool useJsonFormat, params string[] locations)
        {
            // generate:
            // where text in ('l1,'l2'...)
            string whereInLocations = "where text in (";
            IEnumerable<string> quoteWrappedLocations = locations.Select(l => $@"'{l}'");
            whereInLocations += string.Join(",", quoteWrappedLocations);
            whereInLocations += ")";

            // from example at https://codepen.io/Ranjithkumar10/pen/MKbwQW?editors=0010
            string degreeUnits = " and u='f'"; // default is f. or use c for Celcius
            string selectFromWeatherForecast =
                "select * from weather.forecast where woeid in (select woeid from geo.places(1)";
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "q", selectFromWeatherForecast + $"{whereInLocations}){degreeUnits}" },
                { "format", useJsonFormat ? "json" : "xml" }
                //{ "env", "store://datatables.org/alltableswithkeys" }, // TODO is this needed ??
            };

            return BuildQueryString(parameters);
        }

        static string LastRequestUrl;
        static string LastResponseData;

        /// <summary>
        /// After calling webRequest, gets the response.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        [CanBeNull]
        public static string GetResponse(string requestUrl)
        {
            // returned cache'd response if this is the same request.
            // Avoids querying repeatedly when debugging.
            if (requestUrl != LastRequestUrl)
            {
                LastRequestUrl = requestUrl;

                WebRequest webRequest = WebRequest.Create(requestUrl);

                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    Stream responseStream = webResponse.GetResponseStream();

                    if (ReferenceEquals(responseStream, null)) return null;

                    using (StreamReader streamReader = new StreamReader(responseStream))
                    {
                        string responseData = streamReader.ReadToEnd();

                        LastResponseData = responseData;
                    }
                }
            }

            return LastResponseData;
        }

        /// <summary>
        /// Builds the query string.
        /// </summary>
        /// <param name="keyValuePairs">The key value pairs.</param>
        /// <returns>returns ?key1=value1[&amp;key2=value2]...
        /// if no sequence is empty, returns an empty string</returns>
        internal static string BuildQueryString(IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            StringBuilder result = new StringBuilder();

            string delimiter = "?"; // ?|# is required by UriBuilder

            foreach (KeyValuePair<string, string> keyValuePair in keyValuePairs)
            {
                string key = Uri.EscapeDataString(keyValuePair.Key);
                string value = Uri.EscapeDataString(keyValuePair.Value);

                result.Append($"{delimiter}{key}={value}");

                delimiter = "&";
            }

            return result.ToString();
        }
    }
}
