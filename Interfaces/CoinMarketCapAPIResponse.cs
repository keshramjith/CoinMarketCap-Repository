using Newtonsoft.Json;

using RepoWebAPI.Objects;

namespace RepoWebAPI.Interfaces
{
    public abstract class CoinMarketCapAPIResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}