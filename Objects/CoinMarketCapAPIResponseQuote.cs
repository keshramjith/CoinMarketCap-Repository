using RepoWebAPI.Interfaces;

using System.Collections.Generic;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using RepoWebAPI.Entities;

namespace RepoWebAPI.Objects
{
    public class CoinMarketCapAPIResponseQuote : CoinMarketCapAPIResponse
    {
        [JsonProperty("data")]
        public Dictionary<string, Datum> Data { get; set; }
    }

    public class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}