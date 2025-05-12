using NUnit.Framework;

namespace server.Tests;

public class Tests
{
    [Test]
    public void ValidFighterConfiguration()
    {
        List<Weapon> energyWeapons = new List<Weapon>
        {
            new Weapon(WeaponType.Phaser),
            new Weapon(WeaponType.EnergyLance),
            new Weapon(WeaponType.Disruptor)
        };
        List<Weapon> missleWeapons = new List<Weapon>
        {
            new Weapon(WeaponType.QuantumTorpedoLauncher),
            new Weapon(WeaponType.PhotonTorpedoLauncher),
        };
        Ship ship = new Ship("Test Ship", "Fighter", energyWeapons, missleWeapons);
        Assert.AreEqual(ShipType.Fighter, ship.Type);
    }
}
