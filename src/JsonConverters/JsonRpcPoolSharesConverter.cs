using Dfi.Rpc.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.JsonConverters
{
    public class JsonRpcPoolSharesConverter : JsonConverterBase<PoolShares>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            PoolShares poolShares = new PoolShares();
            JObject obj = JObject.Load(reader);
            foreach (var property in obj.Properties())
            {
                if (TryCast(property.Value, out PoolShare poolShare))
                {
                    poolShare.Id = property.Name;
                    poolShares.Add(poolShare);
                }
            }
            return poolShares;
        }
    }
}