using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Responses
{
    public class BlockchainInfo : IResponse
    {
        [JsonProperty("chain")]
        public string Chain { get; set; }

        [JsonProperty("blocks")]
        public int Blocks { get; set; }

        [JsonProperty("headers")]
        public int Headers { get; set; }

        [JsonProperty("bestblockhash")]
        public string Bestblockhash { get; set; }

        [JsonProperty("difficulty")]
        public double Difficulty { get; set; }

        [JsonProperty("mediantime")]
        public int Mediantime { get; set; }

        [JsonProperty("verificationprogress")]
        public int Verificationprogress { get; set; }

        [JsonProperty("initialblockdownload")]
        public bool Initialblockdownload { get; set; }

        [JsonProperty("chainwork")]
        public string Chainwork { get; set; }

        [JsonProperty("size_on_disk")]
        public int SizeOnDisk { get; set; }

        [JsonProperty("pruned")]
        public bool Pruned { get; set; }

        [JsonProperty("softforks")]
        public Softforks Softforks { get; set; }

        [JsonProperty("warnings")]
        public string Warnings { get; set; }
    }
    public class Bip34
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Bip66
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Bip65
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Csv
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Segwit
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Amk
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Bayfront
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Softforks
    {
        [JsonProperty("bip34")]
        public Bip34 Bip34 { get; set; }

        [JsonProperty("bip66")]
        public Bip66 Bip66 { get; set; }

        [JsonProperty("bip65")]
        public Bip65 Bip65 { get; set; }

        [JsonProperty("csv")]
        public Csv Csv { get; set; }

        [JsonProperty("segwit")]
        public Segwit Segwit { get; set; }

        [JsonProperty("amk")]
        public Amk Amk { get; set; }

        [JsonProperty("bayfront")]
        public Bayfront Bayfront { get; set; }
    }


}
