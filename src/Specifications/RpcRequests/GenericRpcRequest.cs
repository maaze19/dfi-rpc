using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    public class GenericRpcRequest : IRpcRequest
    {
        private readonly object[] _parameters;

        public GenericRpcRequest(string name, params object[] parameters)
        {
            Name = name;
            _parameters = parameters;
        }

        public string Name { get; }

        public object[] GetParameters() => _parameters;
    }
}
