using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Dfi.Rpc.Responses
{
    [JsonConverter(typeof(JsonRpcPoolPairsConverter))]
    public class PoolPairs : List<PoolPair>, IResponse
    {
    }
    public class PoolPair
    {
        [JsonIgnore]
        public int PoolId { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("idTokenA")]
        public string IdTokenA { get; set; }

        [JsonProperty("idTokenB")]
        public string IdTokenB { get; set; }

        [JsonProperty("reserveA")]
        public decimal ReserveA { get; set; }

        [JsonProperty("reserveB")]
        public decimal ReserveB { get; set; }

        [JsonProperty("commission")]
        public decimal Commission { get; set; }

        [JsonProperty("totalLiquidity")]
        public decimal TotalLiquidity { get; set; }

        [JsonProperty("reserveA/reserveB")]
        public decimal ReserveAReserveB { get; set; }

        [JsonProperty("reserveB/reserveA")]
        public decimal ReserveBReserveA { get; set; }

        [JsonProperty("tradeEnabled")]
        public bool TradeEnabled { get; set; }

        [JsonProperty("ownerAddress")]
        public string OwnerAddress { get; set; }

        [JsonProperty("blockCommissionA")]
        public decimal BlockCommissionA { get; set; }

        [JsonProperty("blockCommissionB")]
        public decimal BlockCommissionB { get; set; }

        [JsonProperty("rewardPct")]
        public decimal RewardPct { get; set; }

        [JsonProperty("creationTx")]
        public string CreationTx { get; set; }

        [JsonProperty("creationHeight")]
        public int CreationHeight { get; set; }
    }

    public class JsonRpcPoolPairsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            PoolPairs poolPairs = new PoolPairs();
            JObject obj = JObject.Load(reader);
            foreach (var property in obj.Properties())
            {
                if (int.TryParse(property.Name, out int poolId))
                    if (TryCast<PoolPair>(property.Value) is PoolPair poolPair)
                    {
                        poolPair.PoolId = poolId;
                        poolPairs.Add(poolPair);
                    }
            }
            return poolPairs;
        }
        private T TryCast<T>(JToken jToken) where T : class
        {
            try
            {
                return jToken.ToObject<T>();
            }
            catch { return null; }
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PoolPairs);
        }
    }
}
