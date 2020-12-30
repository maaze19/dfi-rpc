using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Responses
{
    public class Block : IResponse
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("strippedsize")]
        public int Strippedsize { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("minter")]
        public string Minter { get; set; }

        [JsonProperty("mintedBlocks")]
        public int MintedBlocks { get; set; }

        [JsonProperty("stakeModifier")]
        public string StakeModifier { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("versionHex")]
        public string VersionHex { get; set; }

        [JsonProperty("merkleroot")]
        public string Merkleroot { get; set; }

        [JsonProperty("tx")]
        public List<string> Tx { get; set; }

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

        [JsonProperty("nextblockhash")]
        public string Nextblockhash { get; set; }
    }
}