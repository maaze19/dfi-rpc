using Dfi.Rpc.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace Dfi.Rpc.Responses
{
    [JsonConverter(typeof(JsonRpcPoolSharesConverter))]
    public class PoolShares : List<PoolShare>, IResponse
    {
    }
    public class PoolShare
    {
        [JsonIgnore]
        public string Id { get; set; }

        [JsonProperty("poolID")]
        public string PoolID { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("%")]
        public decimal Percentage { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("totalLiquidity")]
        public decimal TotalLiquidity { get; set; }
        public override string ToString() => Id;
    }
}