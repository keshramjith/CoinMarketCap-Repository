using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RepoWebAPI.Entities
{
    public class CoinMarketCapQuote
    {
        [Key]
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("num_market_pairs")]
        public long NumMarketPairs { get; set; }

        [JsonProperty("date_added")]
        public DateTimeOffset DateAdded { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("max_supply")]
        public long? MaxSupply { get; set; }

        [JsonProperty("circulating_supply")]
        public double CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public double TotalSupply { get; set; }

        [JsonProperty("is_active")]
        public long IsActive { get; set; }

        [JsonProperty("platform")]
        public object Platform { get; set; }

        [JsonProperty("cmc_rank")]
        public long CmcRank { get; set; }

        [JsonProperty("is_fiat")]
        public long IsFiat { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("quote")]
        public Quote Quote { get; set; }
    }
}