using Dfi.Rpc.Specifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Responses
{
    public class Accounts : List<Account>, IResponse
    {

    }
    public class Account
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("amount")]
        public Dictionary<Symbol, decimal> Amount { get; set; }
    }

    public class Owner
    {
        [JsonProperty("asm")]
        public string Asm { get; set; }

        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("reqSigs")]
        public int ReqSigs { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("addresses")]
        public List<string> Addresses { get; set; }
    }
}
