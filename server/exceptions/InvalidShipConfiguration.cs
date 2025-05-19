using System;

namespace BattleSim.Server.Exceptions
{
    public class InvalidShipConfiguration : Exception
    {
        public InvalidShipConfiguration() { }

        public InvalidShipConfiguration(string message) : base(message) { }

        public InvalidShipConfiguration(string message, Exception inner) : base(message, inner) { }
    }
}
