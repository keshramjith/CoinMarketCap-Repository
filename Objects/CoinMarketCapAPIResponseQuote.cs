using System.Collections.Generic;
using Newtonsoft.Json;
using RepoWebAPI.Entities;

namespace RepoWebAPI.Objects
{
    public class CoinMarketCapAPIResponseQuote : CoinMarketCapAPIResponse
    {
        [JsonProperty("data")]
        public Dictionary<string, CoinMarketCapQuote> Data { get; set; }
    }
}