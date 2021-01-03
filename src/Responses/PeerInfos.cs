using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dfi.Rpc.Responses
{
    public class PeerInfos : List<PeerInfo>, IResponse
    {
    }


    public class PeerInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("addr")]
        public string Addr { get; set; }

        [JsonProperty("addrlocal")]
        public string Addrlocal { get; set; }

        [JsonProperty("addrbind")]
        public string Addrbind { get; set; }

        [JsonProperty("services")]
        public string Services { get; set; }

        [JsonProperty("relaytxes")]
        public bool Relaytxes { get; set; }

        [JsonProperty("lastsend")]
        public int Lastsend { get; set; }

        [JsonProperty("lastrecv")]
        public int Lastrecv { get; set; }

        [JsonProperty("bytessent")]
        public int Bytessent { get; set; }

        [JsonProperty("bytesrecv")]
        public int Bytesrecv { get; set; }

        [JsonProperty("conntime")]
        public int Conntime { get; set; }

        [JsonProperty("timeoffset")]
        public int Timeoffset { get; set; }

        [JsonProperty("pingtime")]
        public decimal Pingtime { get; set; }

        [JsonProperty("minping")]
        public decimal Minping { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("subver")]
        public string Subver { get; set; }

        [JsonProperty("inbound")]
        public bool Inbound { get; set; }

        [JsonProperty("addnode")]
        public bool Addnode { get; set; }

        [JsonProperty("startingheight")]
        public int Startingheight { get; set; }

        [JsonProperty("banscore")]
        public int Banscore { get; set; }

        [JsonProperty("synced_headers")]
        public int SyncedHeaders { get; set; }

        [JsonProperty("synced_blocks")]
        public int SyncedBlocks { get; set; }

        [JsonProperty("inflight")]
        public List<object> Inflight { get; set; }

        [JsonProperty("whitelisted")]
        public bool Whitelisted { get; set; }

        [JsonProperty("permissions")]
        public List<object> Permissions { get; set; }

        [JsonProperty("minfeefilter")]
        public decimal Minfeefilter { get; set; }

        [JsonProperty("bytessent_per_msg")]
        public BytessentPerMsg BytessentPerMsg { get; set; }

        [JsonProperty("bytesrecv_per_msg")]
        public BytesrecvPerMsg BytesrecvPerMsg { get; set; }
    }
    public class BytessentPerMsg
    {
        [JsonProperty("addr")]
        public int Addr { get; set; }

        [JsonProperty("feefilter")]
        public int Feefilter { get; set; }

        [JsonProperty("getaddr")]
        public int Getaddr { get; set; }

        [JsonProperty("getblocktxn")]
        public int Getblocktxn { get; set; }

        [JsonProperty("getdata")]
        public int Getdata { get; set; }

        [JsonProperty("getheaders")]
        public int Getheaders { get; set; }

        [JsonProperty("headers")]
        public int Headers { get; set; }

        [JsonProperty("inv")]
        public int Inv { get; set; }

        [JsonProperty("ping")]
        public int Ping { get; set; }

        [JsonProperty("pong")]
        public int Pong { get; set; }

        [JsonProperty("sendcmpct")]
        public int Sendcmpct { get; set; }

        [JsonProperty("sendheaders")]
        public int Sendheaders { get; set; }

        [JsonProperty("tx")]
        public int Tx { get; set; }

        [JsonProperty("verack")]
        public int Verack { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }
    }

    public class BytesrecvPerMsg
    {
        [JsonProperty("addr")]
        public int Addr { get; set; }

        [JsonProperty("block")]
        public int Block { get; set; }

        [JsonProperty("blocktxn")]
        public int Blocktxn { get; set; }

        [JsonProperty("cmpctblock")]
        public int Cmpctblock { get; set; }

        [JsonProperty("feefilter")]
        public int Feefilter { get; set; }

        [JsonProperty("getdata")]
        public int Getdata { get; set; }

        [JsonProperty("getheaders")]
        public int Getheaders { get; set; }

        [JsonProperty("headers")]
        public int Headers { get; set; }

        [JsonProperty("inv")]
        public int Inv { get; set; }

        [JsonProperty("notfound")]
        public int Notfound { get; set; }

        [JsonProperty("ping")]
        public int Ping { get; set; }

        [JsonProperty("pong")]
        public int Pong { get; set; }

        [JsonProperty("sendcmpct")]
        public int Sendcmpct { get; set; }

        [JsonProperty("sendheaders")]
        public int Sendheaders { get; set; }

        [JsonProperty("tx")]
        public int Tx { get; set; }

        [JsonProperty("verack")]
        public int Verack { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }
    }
}