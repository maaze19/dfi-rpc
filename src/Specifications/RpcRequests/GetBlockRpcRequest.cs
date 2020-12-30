using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    public class GetBlockRpcRequest : GenericRpcRequest
    {
        public GetBlockRpcRequest(string blockHash, int verbosity = 1) : base("getblock", new object[] { blockHash, verbosity })
        {
            if (string.IsNullOrWhiteSpace(blockHash))
                throw new ArgumentNullException(nameof(blockHash));
        }
    }
}
