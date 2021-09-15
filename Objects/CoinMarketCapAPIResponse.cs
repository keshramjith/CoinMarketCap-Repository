using Newtonsoft.Json;

namespace RepoWebAPI.Objects
{
    public abstract class CoinMarketCapAPIResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}