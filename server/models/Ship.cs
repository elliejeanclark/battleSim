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
                break;
            case "explorer":
                Type = ShipType.Explorer;
                Health = 80;
                MaxHealth = 80;
                ShieldStrength = 180;
                break;
            case "freighter":
                Type = ShipType.Freighter;
                Health = 150;
                MaxHealth = 150;
                ShieldStrength = 80;
                break;
            case "cruiser":
                Type = ShipType.Cruiser;
                Health = 120;
                MaxHealth = 120;
                ShieldStrength = 120;
                break;
            case "destroyer":
                Type = ShipType.Destroyer;
                Health = 130;
                MaxHealth = 130;
                ShieldStrength = 200;
                break;
            case "carrier":
                Type = ShipType.Carrier;
                Health = 200;
                MaxHealth = 200;
                ShieldStrength = 150;
                break;
            case "cutter":
                Type = ShipType.Cutter;
                Health = 80;
                MaxHealth = 80;
                ShieldStrength = 100;
                break;
            case "stealthcraft":
                Type = ShipType.StealthCraft;
                Health = 70;
                MaxHealth = 70;
                ShieldStrength = 50;
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