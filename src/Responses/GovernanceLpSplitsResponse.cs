using Dfi.Rpc.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Splits = System.Collections.Generic.Dictionary<int, decimal>;
namespace Dfi.Rpc.Responses
{
    public class GovernanceLpSplitsResponse : IGovernanceResponse
    {
        [JsonProperty("LP_SPLITS")]
        [JsonConverter(typeof(JsonPropertiesToDictionaryConverter<Splits, int, decimal>))]
        public Splits LpSplits { get; set; }
    }
}
