using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dfi.Rpc.Specifications.RpcRequests
{
    public class AccountHistoryCountRpcRequest : IRpcRequest
    {
        private string _owner;

        private AccountHistoryCountOptions _accountHistoryCountOptions;
        public AccountHistoryCountRpcRequest(string owner, bool noRewards, string token) :this(owner, new AccountHistoryCountOptions(noRewards, token))
        {
           
        }
        public AccountHistoryCountRpcRequest(string owner, AccountHistoryCountOptions accountHistoryCountOptions)
        {
            _owner = owner;
            _accountHistoryCountOptions = accountHistoryCountOptions;
        }
        public string Name => "accounthistorycount";

        public object[] GetParameters() => new object[] { _owner, _accountHistoryCountOptions };
    }
    public class AccountHistoryCountOptions
    {
        public AccountHistoryCountOptions(bool noRewards, string token)
        {
            NoRewards = noRewards;
            Token = token ?? string.Empty;
        }
        [JsonProperty("no_rewards")]
        public bool NoRewards { get; }
        [JsonProperty("token")]
        public string Token { get; }

    }
}