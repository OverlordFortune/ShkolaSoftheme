namespace _21._1
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
