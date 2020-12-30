using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    public class GetBlockchainInfoRpcRequest : IRpcRequest
    {
        public string Name => "getblockchaininfo";

        public object[] GetParameters() => new object[0];
    }
}
