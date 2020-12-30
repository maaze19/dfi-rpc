using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    //listpoolshares ( {"start":n,"including_start":bool,"limit":n} verbose is_mine_only )
    public class ListPoolSharesRpcRequest : GenericRpcRequest
    {
        public ListPoolSharesRpcRequest(int start = 1, bool includingStart = true, int limit = -1, bool mineOnly = false)
            : this(new ListPoolSharesOptions(start, includingStart, limit), mineOnly)
        {
        }
        public ListPoolSharesRpcRequest(ListPoolSharesOptions listPoolSharesParameters, bool mineOnly = false) 
            : base("listpoolshares", new object[] { listPoolSharesParameters, 1, mineOnly })
        {
        }
    }
    public class ListPoolSharesOptions
    {
        [JsonProperty("start")]
        public int Start { get; set; }
        [JsonProperty("including_start")]
        public bool InlcudingStart { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        public ListPoolSharesOptions(int start, bool inlcudingStart, int limit)
        {
            Start = start;
            InlcudingStart = inlcudingStart;
            Limit = limit;
        }
    }
}
