using Dfi.Rpc.Responses;
using Dfi.Rpc.Specifications;
using Dfi.Rpc.Specifications.RpcRequests;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Dfi.Rpc
{
    public interface IDeFiService
    {
        public const string OWNER_MINE = "mine";
        public const string OWNER_ALL = "all";
        Balances GetBalances();
        decimal GetBalance(int minconf, bool includeWatchOnly, bool avoidReuse);
        BalancesWithTokens GetBalanceWithTokens(int minconf, bool includeWatchOnly, bool avoidReuse);
        BalancesWithTokens GetTokenBalances(Pagination pagination = null, bool symbolLookup = false);
        Accounts ListAccounts(Pagination pagination = null, bool isMineOnly = true);
        BalancesWithTokens GetAccount(string owner, Pagination pagination = null);
        //TODO: Parameter inputs is missing.
        string AccountToUtxos(string from, ToAddress to);
        bool IsTestnet();
        bool IsMainNet();

        PoolPairs ListPoolPairs();
        PoolShares ListPoolShares(bool isMine = false);
        PoolShares ListPoolShares(int start, bool includingStart, int limit, bool isMine);
        /// <summary>
        /// Creates (and submits to local node and network) a transfer transaction from the specified account to the specfied accounts.
        /// </summary>
        /// <param name="from">The defi address of sender</param>
        /// <param name="">to</param>
        string AccountToAccount(string from, ToAddress to);
        /// <summary>
        /// Returns count of account history.
        /// </summary>
        /// <param name="owner">(string) Single account ID (CScript or address) or reserved words: "mine" - to list history for all owned accounts or "all" to list whole DB (default = "mine").</param>
        /// <param name="noRewards">Filter out rewards</param>
        /// <param name="token">Filter by token</param>
        /// <returns></returns>
        int AccountHistoryCount(string owner = IDeFiService.OWNER_MINE, bool noRewards = false, string token = null);

        #region Blockchain
        List<string> ClearMempool();
        string GetBestBlockHash();
        Block GetBlock(string blockHash);
        BlockchainInfo GetBlockchainInfo();
        int GetBlockCount();
        string GetBlockHash(int height);
        BlockHeader GetBlockHeader(string blockHash);
        ChainTips GetChainTips();
        decimal GetDifficulty();
        /// <summary>
        /// Returns information about governance variable. Two types of them implemented for now: LP_SPLITS and LP_DAILY_DFI_REWARD
        /// </summary>
        /// <param name="name">Variable name</param>
        /// <returns></returns>
        IGovernanceResponse GetGov(Governances governance);
        T GetGov<T>(Governances governance) where T : IGovernanceResponse;
        T GetGov<T>(string governance) where T : IGovernanceResponse;
        GovernanceLpDailyDfiRewardResponse GetGovLpDailyDfiReward();
        GovernanceLpSplitsResponse GetGovLpSplits();
        MempoolInfo GetMempoolInfo();
        void SaveMempool();
        #endregion

        #region Network
        bool AddNode(string node, AddNodeCommands command);
        void ClearBanned();
        /// <summary>
        /// Immediately disconnects from the specified peer node.
        /// </summary>
        /// <param name="node">Can be the ip address / port or the node id.</param>
        void DisconnectNode(int nodeId);
        void DisconnectNode(string address);
        void DisconnectNode(IPEndPoint endPoint);
        List<string> ListBanned();
        PeerInfos GetPeerInfo();
        /// <summary>
        /// Returns information about the given added node, or all added nodes (note that onetry addnodes are not listed here)
        /// </summary>
        /// <param name="node">If provided, return information about this specific node, otherwise all nodes are returned.</param>
        /// <returns></returns>
        NodeInfos GetAddedNodeInfo(string node = "all");
        int GetConnectionCount();
        #endregion
    }
}
