using Dfi.Rpc.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Responses
{
    public class BalancesWithTokens : Dictionary<Symbol, decimal>, IResponse
    {
    }
}
