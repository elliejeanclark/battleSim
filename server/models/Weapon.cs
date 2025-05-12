public class Weapon {
    public WeaponType Type { get; set; }
    public int HullDamage { get; set; }
    public int ShieldDamage { get; set; }
    public int Range { get; set; }
    public int FireRate { get; set; }
    public int Cooldown { get; set; }
    public int CriticalChance { get; set; }
    public double CriticalMultiplier { get; set; }
    // critical chance math = if a random number between 1 and 10 (inclusive) is less than or equal to the critical chance num, critical hit occurs.
    // critiacl damage is equal to critical hit multiplier times damage.

    public Weapon(WeaponType type) {
        Type = type;
        SetUpDefaultSetting();
    }

    public void SetUpDefaultSetting() {
        switch (Type) {
            case WeaponType.Phaser:
                HullDamage = 0;
                ShieldDamage = 20;
                Range = 30;
                FireRate = 2;
                CriticalChance = 5;
                CriticalMultiplier = 0.5;
                break;
            case WeaponType.QuantumTorpedoLauncher:
                HullDamage = 30;
                ShieldDamage = 0;
                Range = 20;
                FireRate = 4;
                CriticalChance = 1;
                CriticalMultiplier = 0.7;
                break;
            case WeaponType.PhotonTorpedoLauncher:
                HullDamage = 20;
                ShieldDamage = 0;
                Range = 20;
                FireRate = 2;
                CriticalChance = 2;
                CriticalMultiplier = 0.5;
                break;
            case WeaponType.EnergyLance:
                HullDamage = 0;
                ShieldDamage = 10;
                Range = 10;
                FireRate = 2;
                CriticalChance = 5;
                CriticalMultiplier = 0.6;
                // EnergyLance will also have a 50% chance on critical hits to temporarily disable the target's shields for 1 turn.
                break;
            case WeaponType.Disruptor:
                HullDamage = 10;
                ShieldDamage = 10;
                Range = 15;
                FireRate = 3;
                CriticalChance = 4;
                CriticalMultiplier = 0.6;
                break;
        }
    }
}