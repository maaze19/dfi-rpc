using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dfi.Rpc.JsonConverters.SerializationNamingStrategies
{
    /// <summary>
    /// Replaces uppercase letters to a lowercase and adding a hyphen "-" before it.    /// </summary>
    public class CamelCaseToHyphenNamingStrategy : NamingStrategy
    {
        //idea from: https://stackoverflow.com/a/2403644
        /// <summary>
        /// Replaces uppercase letters to a lowercase and adding a hyphen "-" before it.
        /// </summary>
        protected override string ResolvePropertyName(string name)
            => Regex.Replace(name, @"(?<!_)([A-Z])", "-$1").TrimStart('-');
    }
}
