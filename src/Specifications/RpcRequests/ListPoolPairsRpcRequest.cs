using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    public class ListPoolPairsRpcRequest : GenericRpcRequest
    {
        public ListPoolPairsRpcRequest() : base("listpoolpairs", new object[0]) { }
    }
}
