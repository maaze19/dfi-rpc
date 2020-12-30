using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.JsonConverters
{
    public abstract class JsonConverterBase : JsonConverter
    {
        protected bool TryCast<T>(JToken jToken, out T result)
        {
            try
            {
                result = jToken.ToObject<T>();
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
        protected bool TryConvert<TIn, TOut>(TIn input, out TOut result)
        {
            try
            {
                result = (TOut)Convert.ChangeType(input, typeof(TOut));
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }
    public abstract class JsonConverterBase<TConvertible> : JsonConverterBase
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(TConvertible);
    }
}
