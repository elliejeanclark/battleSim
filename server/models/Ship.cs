public class Ship {
    public string Name { get; set; }
    public ShipType Type { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int ShieldStrength { get; set; }
    public int MaxShieldStrength { get; set; }
    public int Speed { get; set; }
    public int Size { get; set; }
    public int MissleLaunchers { get; set; }
    public int EnergyWeaponBanks { get; set; }

    public Ship(string name, string type) {
        Name = name;
        SetUpShipAttributes(type); 
    }

    public void SetUpShipAttributes(string type) {
        type = type.ToLower();
        switch (type) {
            case "fighter":
                Type = ShipType.Fighter;
                Health = 50;
                MaxHealth = 50;
                ShieldStrength = 100;
                MaxShieldStrength = 100;
                Speed = 8;
                Size = 1;
                MissleLaunchers = 2;
                EnergyWeaponBanks = 3;
                break;
            case "explorer":
                Type = ShipType.Explorer;
                Health = 100;
                MaxHealth = 100;
                ShieldStrength = 180;
                MaxShieldStrength = 180;
                Speed = 3;
                Size = 7;
                MissleLaunchers = 2;
                EnergyWeaponBanks = 2;
                break;
            case "freighter":
                Type = ShipType.Freighter;
                Health = 150;
                MaxHealth = 150;
                ShieldStrength = 150;
                MaxShieldStrength = 150;
                Speed = 2;
                Size = 6;
                MissleLaunchers = 1;
                EnergyWeaponBanks = 3;
                break;
            case "cruiser":
                Type = ShipType.Cruiser;
                Health = 120;
                MaxHealth = 120;
                ShieldStrength = 120;
                MaxShieldStrength = 120;
                Speed = 7;
                Size = 4;
                MissleLaunchers = 2;
                EnergyWeaponBanks = 1;
                break;
            case "destroyer":
                Type = ShipType.Destroyer;
                Health = 100;
                MaxHealth = 100;
                ShieldStrength = 150;
                MaxShieldStrength = 150;
                Speed = 6;
                Size = 5;
                MissleLaunchers = 4;
                EnergyWeaponBanks = 2;
                break;
            case "carrier":
                Type = ShipType.Carrier;
                Health = 200;
                MaxHealth = 200;
                ShieldStrength = 200;
                MaxShieldStrength = 200;
                Speed = 2;
                Size = 10;
                MissleLaunchers = 6;
                EnergyWeaponBanks = 4;
                break;
            case "cutter":
                Type = ShipType.Cutter;
                Health = 80;
                MaxHealth = 80;
                ShieldStrength = 100;
                MaxShieldStrength = 100;
                Speed = 9;
                Size = 3;
                MissleLaunchers = 1;
                EnergyWeaponBanks = 2;
                break;
            case "stealthcraft":
                Type = ShipType.StealthCraft;
                Health = 70;
                MaxHealth = 70;
                ShieldStrength = 50;
                MaxShieldStrength = 50;
                Speed = 8;
                Size = 2;
                MissleLaunchers = 1;
                EnergyWeaponBanks = 1;
                break;
            case "cargoship":
                Type = ShipType.CargoShip;
                Health = 150;
                MaxHealth = 150;
                ShieldStrength = 100;
                MaxShieldStrength = 100;
                Speed = 5;
                Size = 4;
                MissleLaunchers = 2;
                EnergyWeaponBanks = 2;
                break;
            default:
                throw new ArgumentException("Invalid ship type");
        }
    }

    public void TakeDamage(WeaponType weaponType) {
        int shieldDamage = 0;
        int hullDamage = 0;
        Random random = new Random();
        int dodgeChance = random.Next(1, 21);
        dodgeChance += Speed;
        if (Size % 2 == 0) {
            dodgeChance -= Size/2;
        }
        else {
            dodgeChance -= (Size - 1) / 2;
        }

        switch (weaponType) {
            case WeaponType.Phaser:
                shieldDamage = 15;
                dodgeChance -= 2;
                break;
            case WeaponType.QuantumTorpedoLauncher:
                hullDamage = 30;
                break;
            case WeaponType.PhotonTorpedoLauncher:
                hullDamage = 15;
                break;
            case WeaponType.EnergyLance:
                shieldDamage = 10;
                //chance to break a system increased
                break;
            case WeaponType.Disruptor:
                shieldDamage = 10;
                hullDamage = 10;
                break;
        }

        if (dodgeChance > 15) {
            Console.WriteLine($"{Name} dodged the attack!");
            return;
        }
        else {
            if (ShieldStrength > 0) {
                ShieldStrength -= shieldDamage;
                if (ShieldStrength < 0) {
                    ShieldStrength = 0;
                }
                Console.WriteLine($"{Name} took {shieldDamage} damage to shields!");
            }
            if (Health > 0){
                Health -= hullDamage;
                if (Health < 0) {
                    Health = 0;
                }
                Console.WriteLine($"{Name} took {hullDamage} damage to hull!");
            }
        }
    }
}