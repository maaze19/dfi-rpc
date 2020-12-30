using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Responses
{
    public class Balances : IResponse
    {
        [JsonProperty("mine")]
        public Balance Mine { get; set; }

        [JsonProperty("watchonly")]
        public Balance WatchOnly { get; set; }
    }
    public class Balance
    {
        [JsonProperty("trusted")]
        public double Trusted { get; set; }

        [JsonProperty("untrusted_pending")]
        public double UntrustedPending { get; set; }

        [JsonProperty("immature")]
        public double Immature { get; set; }
    }
}
