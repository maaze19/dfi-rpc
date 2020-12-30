using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Linq;

namespace Dfi.Rpc
{
    [JsonConverter(typeof(JsonToAddressConverter))]
    public class ToAddress
    {
        public string Address { get; }
        public TokenAmount[] Amounts { get; }
        public ToAddress(string address, params TokenAmount[] amounts)
        {
            Address = address;
            Amounts = amounts ?? throw new ArgumentNullException(nameof(amounts));
        }

    }

    public class TokenAmount
    {
        public decimal Amount { get; }
        public string Token { get; }
        public TokenAmount(decimal amount, string token)
        {
            Amount = amount;
            Token = token;
        }
        public override string ToString()
        {
            return Amount.ToString(CultureInfo.InvariantCulture) + "@" + Token;
        }
    }
    public class JsonToAddressConverter : Newtonsoft.Json.JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if(value is ToAddress toAddress)
            {
                JObject jObject = new JObject();
                object propertyContent = null;
                if (toAddress.Amounts.Length == 1)
                    propertyContent = toAddress.Amounts.FirstOrDefault().ToString();
                else
                   propertyContent = toAddress.Amounts.Select(ta => ta.ToString());
                JProperty jProperty = new JProperty(toAddress.Address, propertyContent);
                jObject.Add(jProperty);
                jObject.WriteTo(writer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ToAddress);
        }
    }

}