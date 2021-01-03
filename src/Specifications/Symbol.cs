using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications
{
    public class Symbol
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; } = null;

        public static implicit operator Symbol(string name)
        {
            if (int.TryParse(name, out int id))
                return new Symbol() { Id = id };
           return new Symbol() { Name = name };
        }
        public static implicit operator Symbol(int id) => new Symbol() { Id = id };

        public static implicit operator string(Symbol symbol) => symbol?.Name;
        public static implicit operator int(Symbol symbol) => symbol?.Id ?? -1;

        public override string ToString() => Name ?? Id.ToString();
    }
}
