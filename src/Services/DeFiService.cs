using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Dfi.Rpc.Connector;
using Dfi.Rpc.Responses;
using Dfi.Rpc.Specifications;
using Dfi.Rpc.Specifications.RpcRequests;

namespace Dfi.Rpc
{
    public class DeFiService : IDeFiService
    {
        const string TESTNET_NAME = "test";
        const string MAINNET_NAME = "main";

        IRpcConnector _rpcConnector;
        private readonly string _walletPassword;

        public DeFiService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword)
        {
            _rpcConnector = new RpcConnector(daemonUrl, rpcUsername, rpcPassword);
            _walletPassword = walletPassword;
        }

        public DeFiService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword, short rpcRequestTimeoutInSeconds)
        {
            _rpcConnector = new RpcConnector(daemonUrl, rpcUsername, rpcPassword, rpcRequestTimeoutInSeconds);
            _walletPassword = walletPassword;
        }
        public DeFiService(string daemonUrl, string cookiePath, string walletPassword, short rpcRequestTimeoutInSeconds)
        {
            if (GetUserCredentialsFromCookie(cookiePath, out string username, out string password))
            {
                _rpcConnector = new RpcConnector(daemonUrl, username, password, rpcRequestTimeoutInSeconds);
                _walletPassword = walletPassword;
            }
            else throw new Exception("Cookie file not found.");
        }
        private static bool GetUserCredentialsFromCookie(string path, out string username, out string password)
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                string[] kvpSplit = content.Split(':', StringSplitOptions.RemoveEmptyEntries);
                if (kvpSplit.Length == 2)
                {
                    username = kvpSplit[0];
                    password = kvpSplit[1];
                    return true;
                }
            }
            username = password = null;
            return false;
        }

        //public string SendToAddress(string bitcoinAddress, decimal amount, string comment, string commentTo, bool subtractFeeFromAmount, bool allowReplaceByFee)
        //{
        //    return _rpcConnector.MakeRequest<string>(RpcMethods.sendtoaddress, bitcoinAddress, amount, comment, commentTo, subtractFeeFromAmount, allowReplaceByFee);
        //}

        //public string GetNewAddress(string account = "", string addressType = "")
        //{
        //    return string.IsNullOrWhiteSpace(account)
        //        ? _rpcConnector.MakeRequest<string>(RpcMethods.getnewaddress)
        //        : _rpcConnector.MakeRequest<string>(RpcMethods.getnewaddress, account, addressType);
        //}

        public Balances GetBalances() => _rpcConnector.MakeRequest<Balances>(new GetBalancesRpcRequest());

        /* Arguments:
        1. blockhash    (string, required) The block hash
        2. verbosity    (numeric, optional, default=1) 0 for hex-encoded data, 1 for a json object, and 2 for json object with transaction data*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockHash">The block hash</param>
        /// <param name="verbosity"><para>If verbosity is 0, returns a string that is serialized, hex-encoded data for block 'hash'.</para>
        ///<para>If verbosity is 1, returns an Object with information about blockhash.</para>
        ///<para>If verbosity is 2, returns an Object with information about blockhash and information about each transaction. </para></param>
        /// <returns></returns>
        public Block GetBlock(string blockHash) => _rpcConnector.MakeRequest<Block>(new GetBlockRpcRequest(blockHash, 1));

        public BlockchainInfo GetBlockchainInfo() => _rpcConnector.MakeRequest<BlockchainInfo>(new GetBlockchainInfoRpcRequest());

        public bool IsTestnet() => GetBlockchainInfo()?.Chain == TESTNET_NAME;

        public bool IsMainNet() => GetBlockchainInfo()?.Chain == MAINNET_NAME;

        public PoolPairs ListPoolPairs() => _rpcConnector.MakeRequest<PoolPairs>(new ListPoolPairsRpcRequest());

        public PoolShares ListPoolShares(bool isMine = false) => ListPoolShares(1, true, -1, isMine);

        public PoolShares ListPoolShares(int start, bool includingStart, int limit, bool isMine)
            => _rpcConnector.MakeRequest<PoolShares>(new ListPoolSharesRpcRequest(start, includingStart, limit, isMine));

        public string AccountToAccount(string from, ToAddress to) =>
            _rpcConnector.MakeRequest<string>(new AccountToAccountRpcRequest(from, to));

        public int AccountHistoryCount(string owner = IDeFiService.OWNER_MINE, bool noRewards = false, string token = null)
            => _rpcConnector.MakeRequest<int>(new AccountHistoryCountRpcRequest(owner, noRewards, token));

        #region Blockchain
        public List<string> ClearMempool() => _rpcConnector.MakeRequest<List<string>>("clearmempool");

        public string GetBestBlockHash() => _rpcConnector.MakeRequest<string>("getbestblockhash");
        /// <summary>
        /// Returns the height of the most-work fully-validated chain.
        /// </summary>
        public int GetBlockCount() => _rpcConnector.MakeRequest<int>("getblockcount");
        /// <summary>
        /// Returns hash of block in best-block-chain at height provided.
        /// </summary>
        /// <param name="height">The height index</param>
        public string GetBlockHash(int height) => _rpcConnector.MakeRequest<string>("getblockhash", height);
        public BlockHeader GetBlockHeader(string blockHash) => _rpcConnector.MakeRequest<BlockHeader>("getblockheader", blockHash, true);

        public ChainTips GetChainTips() => _rpcConnector.MakeRequest<ChainTips>("getchaintips");
        public decimal GetDifficulty() => _rpcConnector.MakeRequest<decimal>("getdifficulty");

        #region getgov
        public T GetGov<T>(string governance) where T : IGovernanceResponse => _rpcConnector.MakeRequest<T>(new GenericRpcRequest("getgov", governance));
        public T GetGov<T>(Governances governance) where T : IGovernanceResponse => GetGov<T>(governance.ToString());
        public IGovernanceResponse GetGov(Governances governance) => GetGov<IGovernanceResponse>(governance);
        public GovernanceLpDailyDfiRewardResponse GetGovLpDailyDfiReward() => GetGov<GovernanceLpDailyDfiRewardResponse>(Governances.LP_DAILY_DFI_REWARD);
        public GovernanceLpSplitsResponse GetGovLpSplits() => GetGov<GovernanceLpSplitsResponse>(Governances.LP_SPLITS);
        #endregion

        public MempoolInfo GetMempoolInfo() => _rpcConnector.MakeRequest<MempoolInfo>("getmempoolinfo");

        public void SaveMempool() => _rpcConnector.MakeRequest<object>("savemempool");

        public bool AddNode(string node, AddNodeCommands command) => _rpcConnector.MakeRequest<object>("addnode", node, command.ToString().ToLower()) == null;

        public void ClearBanned() => _rpcConnector.MakeRequest<object>("clearbanned");

        public void DisconnectNode(string node) => _rpcConnector.MakeRequest<object>(new DisconnectNodeRpcRequest(node));
        public void DisconnectNode(int nodeId) => _rpcConnector.MakeRequest<object>(new DisconnectNodeRpcRequest(nodeId));

        public void DisconnectNode(IPEndPoint endPoint) => _rpcConnector.MakeRequest<object>(new DisconnectNodeRpcRequest(endPoint));

        public PeerInfos GetPeerInfo() => _rpcConnector.MakeRequest<PeerInfos>("getpeerinfo");

        public List<string> ListBanned() => _rpcConnector.MakeRequest<List<string>>("listbanned");

        public NodeInfos GetAddedNodeInfo(string node = "all") => _rpcConnector.MakeRequest<NodeInfos>("getaddednodeinfo");

        public int GetConnectionCount() => _rpcConnector.MakeRequest<int>("getconnectioncount");



        #endregion
        private T GetBalance<T>(int minconf, bool includeWatchOnly, bool avoidReuse, bool withTokens)
            => _rpcConnector.MakeRequest<T>("getbalance", "*", minconf, includeWatchOnly, avoidReuse, withTokens);
        public decimal GetBalance(int minconf, bool includeWatchOnly, bool avoidReuse)
            => GetBalance<decimal>(minconf, includeWatchOnly, avoidReuse, false);

        public BalancesWithTokens GetBalanceWithTokens(int minconf, bool includeWatchOnly, bool avoidReuse)
            => GetBalance<BalancesWithTokens>(minconf, includeWatchOnly, avoidReuse, true);

        public BalancesWithTokens GetTokenBalances(Pagination pagination = null, bool symbolLookup = false)
         => _rpcConnector.MakeRequest<BalancesWithTokens>("gettokenbalances", pagination ?? new object(), true, symbolLookup);

        public Accounts ListAccounts(Pagination pagination = null, bool isMineOnly = true)
            => _rpcConnector.MakeRequest<Accounts>("listaccounts", pagination ?? new object(), true/*verbose*/, true /*indexed_amounts*/, isMineOnly);

        public BalancesWithTokens GetAccount(string owner, Pagination pagination = null)
            => _rpcConnector.MakeRequest<BalancesWithTokens>("getaccount", owner, pagination ?? new object(), true/*indexed_amounts*/);

        public string AccountToUtxos(string from, ToAddress to)
             => _rpcConnector.MakeRequest<string>("accounttoutxos", from, to);
    }
}