using System.IO;

namespace YahooWeatherApiExamples.Json
{
    public class JsonYahooWeatherQuery : YahooWeatherQuery
    {
        public JsonYahooWeatherQuery() : base(useJsonFormat: true) { }

        public override string DeserializeAndFormat(string responseData)
        {
            JsonDto rootObject = JsonDto.FromJson(responseData);

            return Format(rootObject);
        }

        private static string Format(JsonDto rootObject)
        {
            using (StringWriter stringWriter = new StringWriter())
            {

                foreach (Channel channel in rootObject.Query.Results.Channels)
                {
                    stringWriter.WriteLine("");

                    Location l = channel.Location;

                    stringWriter.WriteLine((new { l.City, l.Region, l.Country }));

                    foreach (Forecast forecast in channel.Item.Forecast)
                    {
                        stringWriter.WriteLine(
                            new { forecast.Date, forecast.Day, forecast.High, forecast.Low, forecast.Text });
                    }
                }

                return stringWriter.ToString();
            }
        }
    }
}
