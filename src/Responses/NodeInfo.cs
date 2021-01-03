using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dfi.Rpc.Responses
{
    public class NodeInfo
    {
        [JsonProperty("addednode")]
        public string Addednode { get; set; }

        [JsonProperty("connected")]
        public bool Connected { get; set; }

        [JsonProperty("addresses")]
        public List<AddressInfo> Addresses { get; set; }
    }
    public class AddressInfo
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("connected")]
        public string Connected { get; set; }
    }
}