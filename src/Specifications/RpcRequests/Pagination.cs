using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    public class Pagination
    {
        public static readonly Pagination Default = new Pagination(null, false, 100);
        /// <summary>
        /// Optional first key to iterate from, in lexicographical order.Typically it's set to last tokenID from previous request.
        /// </summary>
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public int? Start { get; set; } = null;

        /// <summary>
        /// If true, then iterate including starting position. False by default
        /// </summary>
        [JsonProperty("including_start")]
        public bool IncludingStart { get; set; } = false;

        /// <summary>
        /// Maximum number of tokens to return, 100 by default
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; } = 100;

        public Pagination(int? start, bool includingStart, int limit)
        {
            Start = start;
            IncludingStart = includingStart;
            Limit = limit;
        }
        public Pagination() { }
    }
}
