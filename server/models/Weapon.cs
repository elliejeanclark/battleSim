public class Weapon {
    public string Name { get; set; }
    public string Type { get; set; }
    public int Damage { get; set; }
    public int Range { get; set; }
    public int FireRate { get; set; }

    public Weapon(string name, string type, int damage, int range, int fireRate) {
        Name = name;
        Type = type;
        Damage = damage;
        Range = range;
        FireRate = fireRate;
    }
}