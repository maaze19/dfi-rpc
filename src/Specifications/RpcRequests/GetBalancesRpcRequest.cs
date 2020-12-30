using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    public class GetBalancesRpcRequest : IRpcRequest
    {
        public string Name => "getbalances";

        public object[] GetParameters() => new object[0];
    }
}
