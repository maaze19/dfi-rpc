using Dfi.Rpc.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.JsonConverters
{
    public class JsonRpcPoolPairsConverter : JsonConverterBase<PoolPairs>
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
                    if (TryCast<PoolPair>(property.Value, out PoolPair poolPair))
                    {
                        poolPair.PoolId = poolId;
                        poolPairs.Add(poolPair);
                    }
            }
            return poolPairs;
        }
    }
}
