using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YahooWeatherApiExamples.Json;
using YahooWeatherApiExamples.Xml2CSharp;
using YahooWeatherApiExamples.XmlToLinq;

namespace YahooWeatherApiExamples
{
    /*
     * Examples of 3 ways to access Yahoo Weather API
     * Json classes - Due to Yahoo issues with how Channel is emited in JSON, some hand coding was reuired. See JsonDto for details
     *
     * Xml2CSharp - These generated classes (from http://xmltocsharp.azurewebsites.net/) just work.
     * The generator handles the fussy namespace details as inferred from sample output.
     *
     * Xml to Linq - Linq is the most flexible, especially if a fraction of the response is actually used, but it requires dealing with namespaces.
     * See GenerateNamespaceCode, which will help ferret out the namespaces in the repsonse.
     * Also some queries may need to be cached, since by default every LINQ query starts at the root of the document.
     */

    [ExcludeFromCodeCoverage]
    static class Program
    {
        private static void Main()
        {
            foreach (YahooWeatherQuery yahooWeatherQuery in new YahooWeatherQuery[]
            {
                new JsonYahooWeatherQuery(),
                new Xml2CSharpYahooWeatherQuery(),
                new XmlToLinqYahooWeatherQuery()
            })
            {
                // N.B. if the query returns < 2 cities, the JSON format returns a singleton, instead of a list with 1 item
                // this causes a deserialization error.
                string response = yahooWeatherQuery.GetWeatherInfo(
                    "New York City",
                    "Carlisle,USA", // finds PA
                    "01741",
                    "Unknown,USA"); // return nothing

                Debug.WriteLine(yahooWeatherQuery.DeserializeAndFormat(response));
            }
        }
    }
}
