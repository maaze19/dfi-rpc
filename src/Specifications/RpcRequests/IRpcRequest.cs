using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    public interface IRpcRequest
    {
        string Name { get; }
        object[] GetParameters();
    }
}
