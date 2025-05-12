using System;

public class InvalidShipConfiguration : Exception {
    public InvalidShipConfiguration() { }

    public InvalidShipConfiguration(string message) : base(message) { }

    public InvalidShipConfiguration(string message, Exception inner) : base(message, inner) { }
}