using System;

using Newtonsoft.Json;

namespace RepoWebAPI.Objects
{
    public class Status
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("error_code")]
        public long ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public object ErrorMessage { get; set; }

        [JsonProperty("elapsed")]
        public long Elapsed { get; set; }

        [JsonProperty("credit_count")]
        public long CreditCount { get; set; }

        [JsonProperty("notice")]
        public object Notice { get; set; }
    }
}