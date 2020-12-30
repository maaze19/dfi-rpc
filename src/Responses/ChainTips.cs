using Dfi.Rpc.JsonConverters.SerializationNamingStrategies;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dfi.Rpc.Responses
{
    public class ChainTips : List<ChainTip>, IResponse
    {
    }

    public class ChainTip
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("branchlen")]
        public int Branchlen { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters:typeof(CamelCaseToHyphenNamingStrategy))]
        public ChainTipStatus Status { get; set; }
    }
    public enum ChainTipStatus
    {
        Invalid,
        HeadersOnly,
        ValidHeaders,
        ValidFork,
        Active
    }
}