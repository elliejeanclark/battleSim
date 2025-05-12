using System.Collections.Generic;

public class Ship {
    public string Name { get; set; }
    public ShipType Type { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int ShieldStrength { get; set; }
    public int MaxShieldStrength { get; set; }
    public int Speed { get; set; }
    public int Size { get; set; }
    public int NumMissleLaunchers { get; set; }
    public int NumEnergyWeaponBanks { get; set; }
    public List<Weapon> MissleWeapons { get; set; }
    public List<Weapon> EnergyWeapons { get; set; }

    public Ship(string name, string type, List<Weapon> missleWeapons, List<Weapon> energyWeapons) {
        Name = name;
        if (missleWeapons.Count > NumMissleLaunchers) {
            throw new InvalidShipConfiguration("Too many missle weapons for this ship type.");
        }
        else if (energyWeapons.Count > NumEnergyWeaponBanks) {
            throw new InvalidShipConfiguration("Too many energy weapons for this ship type.");
        }
        MissleWeapons = missleWeapons;
        EnergyWeapons = energyWeapons;
        SetUpShipAttributes(type); 
    }

    public void SetUpShipAttributes(string type) {
        type = type.ToLower();
        switch (type) {
            case "fighter":
                Type = ShipType.Fighter;
                Health = 50;
                MaxHealth = 50;
                ShieldStrength = 30;
                MaxShieldStrength = 30;
                Speed = 7;
                Size = 1;
                NumMissleLaunchers = 2;
                NumEnergyWeaponBanks = 3;
                break;
            case "explorer":
                Type = ShipType.Explorer;
                Health = 100;
                MaxHealth = 100;
                ShieldStrength = 120;
                MaxShieldStrength = 120;
                Speed = 3;
                Size = 8;
                NumMissleLaunchers = 2;
                NumEnergyWeaponBanks = 2;
                break;
            case "freighter":
                Type = ShipType.Freighter;
                Health = 140;
                MaxHealth = 140;
                ShieldStrength = 150;
                MaxShieldStrength = 150;
                Speed = 2;
                Size = 8;
                NumMissleLaunchers = 1;
                NumEnergyWeaponBanks = 2;
                break;
            case "cruiser":
                Type = ShipType.Cruiser;
                Health = 120;
                MaxHealth = 120;
                ShieldStrength = 100;
                MaxShieldStrength = 100;
                Speed = 7;
                Size = 4;
                NumMissleLaunchers = 1;
                NumEnergyWeaponBanks = 2;
                break;
            case "destroyer":
                Type = ShipType.Destroyer;
                Health = 100;
                MaxHealth = 100;
                ShieldStrength = 110;
                MaxShieldStrength = 110;
                Speed = 6;
                Size = 8;
                NumMissleLaunchers = 3;
                NumEnergyWeaponBanks = 3;
                break;
            case "carrier":
                Type = ShipType.Carrier;
                Health = 200;
                MaxHealth = 200;
                ShieldStrength = 100;
                MaxShieldStrength = 100;
                Speed = 2;
                Size = 12;
                NumMissleLaunchers = 2;
                NumEnergyWeaponBanks = 3;
                break;
            case "cutter":
                Type = ShipType.Cutter;
                Health = 100;
                MaxHealth = 100;
                ShieldStrength = 80;
                MaxShieldStrength = 80;
                Speed = 8;
                Size = 3;
                NumMissleLaunchers = 1;
                NumEnergyWeaponBanks = 2;
                break;
            case "stealthcraft":
                Type = ShipType.StealthCraft;
                Health = 70;
                MaxHealth = 70;
                ShieldStrength = 50;
                MaxShieldStrength = 50;
                Speed = 8;
                Size = 1;
                NumMissleLaunchers = 1;
                NumEnergyWeaponBanks = 1;
                break;
            case "cargoship":
                Type = ShipType.CargoShip;
                Health = 150;
                MaxHealth = 150;
                ShieldStrength = 100;
                MaxShieldStrength = 100;
                Speed = 5;
                Size = 8;
                NumMissleLaunchers = 1;
                NumEnergyWeaponBanks = 2;
                break;
            default:
                throw new InvalidShipConfiguration("Invalid ship type");
        }
    }
}