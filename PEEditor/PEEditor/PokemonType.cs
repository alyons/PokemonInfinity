using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEEditor
{
    public class PokemonType
    {
        public String Name { get; set; }
        public String InternalName { get { return this.Name.ToUpperInvariant(); } }
        public bool IsPsuedoType { get; set; }
        public bool IsSpecialType { get; set; }
        public String[] Weaknesses { get; set; }
        public String[] Resistances { get; set; }
        public String[] Immunities { get; set; }
    }
}
