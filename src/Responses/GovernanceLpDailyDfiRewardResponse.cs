using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Dfi.Rpc.Responses
{
    public class GovernanceLpDailyDfiRewardResponse : IGovernanceResponse
    {
        [JsonProperty("LP_DAILY_DFI_REWARD")]
        public decimal LpDailyDfiReward { get; set; }
    }
}
