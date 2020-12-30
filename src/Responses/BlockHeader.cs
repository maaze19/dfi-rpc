using Newtonsoft.Json;

namespace Dfi.Rpc.Responses
{
    public class BlockHeader : IResponse
    {

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("versionHex")]
        public string VersionHex { get; set; }

        [JsonProperty("merkleroot")]
        public string Merkleroot { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("mediantime")]
        public int Mediantime { get; set; }

        [JsonProperty("bits")]
        public string Bits { get; set; }

        [JsonProperty("difficulty")]
        public double Difficulty { get; set; }

        [JsonProperty("chainwork")]
        public string Chainwork { get; set; }

        [JsonProperty("nTx")]
        public int NTx { get; set; }

        [JsonProperty("previousblockhash")]
        public string Previousblockhash { get; set; }

    }
}