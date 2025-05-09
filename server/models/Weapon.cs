public class Weapon {
    public WeaponType Type { get; set; }
    public int HullDamage { get; set; }
    public int ShieldDamage { get; set; }
    public int Range { get; set; }
    public int FireRate { get; set; }

    public Weapon(WeaponType type) {
        Type = type;
    }
}