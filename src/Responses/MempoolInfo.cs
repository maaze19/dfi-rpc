using Newtonsoft.Json;

namespace Dfi.Rpc.Responses
{
    public class MempoolInfo
    {
        /// <summary>
        /// True if the mempool is fully loaded
        /// </summary>
        [JsonProperty("loaded")]
        public bool Loaded { get; set; }

        /// <summary>
        /// Current tx count
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Sum of all virtual transaction sizes as defined in BIP 141. Differs from actual serialized size because witness data is discounted
        /// </summary>
        [JsonProperty("bytes")]
        public int Bytes { get; set; }

        /// <summary>
        /// Total memory usage for the mempool
        /// </summary>
        [JsonProperty("usage")]
        public int Usage { get; set; }

        /// <summary>
        /// Maximum memory usage for the mempool
        /// </summary>
        [JsonProperty("maxmempool")]
        public int Maxmempool { get; set; }

        /// <summary>
        /// Minimum fee rate in DFI/kB for tx to be accepted. Is the maximum of minrelaytxfee and minimum mempool fee
        /// </summary>
        [JsonProperty("mempoolminfee")]
        public decimal Mempoolminfee { get; set; }

        /// <summary>
        /// Current minimum relay fee for transactions
        /// </summary>
        [JsonProperty("minrelaytxfee")]
        public decimal Minrelaytxfee { get; set; }
    }
}