using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.JsonConverters
{
    public class JsonPropertiesToDictionaryConverter<TType, TKey, TValue> : JsonConverterBase<TType>
    {

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
            JObject obj = JObject.Load(reader);
            foreach (var property in obj.Properties())
                if (TryConvert(property.Name, out TKey key) && TryCast(property.Value, out TValue value))
                        dictionary.Add(key, value);
            return dictionary;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
