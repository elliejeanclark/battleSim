public class Ship {
    public string Name { get; set; }
    public ShipType Type { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int ShieldStrength { get; set; }
    public int MaxShieldStrength { get; set; }
    public int Speed { get; set; }
    public int Size { get; set; }

    public Ship(string name, string type) {
        Name = name;
        SetUpShipAttributes(type); 
    }

    public void SetUpShipAttributes(string type) {
        type = type.ToLower();
        switch (type) {
            case "fighter":
                Type = ShipType.Fighter;
                Health = 100;
                MaxHealth = 100;
                ShieldStrength = 100;
                MaxShieldStrength = 100;
                Speed = 8;
                Size = 1;
                break;
            case "explorer":
                Type = ShipType.Explorer;
                Health = 80;
                MaxHealth = 80;
                ShieldStrength = 180;
                MaxShieldStrength = 180;
                Speed = 3;
                Size = 7;
                break;
            case "freighter":
                Type = ShipType.Freighter;
                Health = 150;
                MaxHealth = 150;
                ShieldStrength = 80;
                MaxShieldStrength = 80;
                Speed = 2;
                Size = 6;
                break;
            case "cruiser":
                Type = ShipType.Cruiser;
                Health = 120;
                MaxHealth = 120;
                ShieldStrength = 120;
                MaxShieldStrength = 120;
                Speed = 7;
                Size = 4;
                break;
            case "destroyer":
                Type = ShipType.Destroyer;
                Health = 120;
                MaxHealth = 120;
                ShieldStrength = 200;
                MaxShieldStrength = 200;
                Speed = 6;
                Size = 4;
                break;
            case "carrier":
                Type = ShipType.Carrier;
                Health = 200;
                MaxHealth = 200;
                ShieldStrength = 200;
                MaxShieldStrength = 200;
                Speed = 2;
                Size = 10;
                break;
            case "cutter":
                Type = ShipType.Cutter;
                Health = 80;
                MaxHealth = 80;
                ShieldStrength = 100;
                MaxShieldStrength = 100;
                Speed = 9;
                Size = 3;
                break;
            case "stealthcraft":
                Type = ShipType.StealthCraft;
                Health = 70;
                MaxHealth = 70;
                ShieldStrength = 50;
                MaxShieldStrength = 50;
                Speed = 8;
                Size = 2;
                break;
            case "cargoship":
                Type = ShipType.CargoShip;
                Health = 150;
                MaxHealth = 150;
                ShieldStrength = 100;
                break;
            default:
                throw new ArgumentException("Invalid ship type");
        }
    }
}