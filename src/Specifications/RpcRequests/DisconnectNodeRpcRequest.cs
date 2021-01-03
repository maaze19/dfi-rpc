
using System.Net;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    public class DisconnectNodeRpcRequest : GenericRpcRequest
    {
        public DisconnectNodeRpcRequest(string address) : this(new object[] { address }) { }
        public DisconnectNodeRpcRequest(int nodeId) : this(new object[] { "", nodeId }) { }
        public DisconnectNodeRpcRequest(IPEndPoint endPoint) : this(new object[] { endPoint.ToString() }) { }
        private DisconnectNodeRpcRequest(object[] parameters) : base("disconnectnode", parameters)   { }
    }
}