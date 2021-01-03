using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    public class AccountToAccountRpcRequest : IRpcRequest
    {
        public string Name => "accounttoaccount";

        public string From { get; }
        public ToAddress To { get; }

        public AccountToAccountRpcRequest(string from, ToAddress to)
        {
            From = from;
            To = to;
        }
        public object[] GetParameters() => new object[] { From, To };
    }
}
