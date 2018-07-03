using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20
{
    class Routing
    {
        public readonly RoutingType Type;
        public readonly string FromNumber;
        public readonly string ToNumber;

        public Routing(string FromNumber, string ToNumber, RoutingType Type)
        {
            this.Type = Type;
            this.FromNumber = FromNumber;
            this.ToNumber = ToNumber;
        }
    }
}
