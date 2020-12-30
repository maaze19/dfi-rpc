using Dfi.Rpc.Specifications.RpcRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Connector
{
    public interface IRpcConnector
    {
        T MakeRequest<T>(IRpcRequest method);
        T MakeRequest<T>(string method);
        T MakeRequest<T>(string method, params object[] parameters);
    }
}
