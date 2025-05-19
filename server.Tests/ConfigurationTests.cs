using System.Collections.Generic;
using Xunit;
using BattleSim.Server.Models;
using BattleSim.Server.Enums;
using BattleSim.Server.Exceptions;

namespace Server.Tests
{
    public class ShipTests
    {
        private Weapon CreateMissileWeapon() => new Weapon(WeaponType.PhotonTorpedoLauncher);
        private Weapon CreateEnergyWeapon() => new Weapon(WeaponType.Phaser);

        [Fact]
        public void ValidFighterConfiguration_ShouldInitializeShip()
        {
            var missiles = new List<Weapon> { CreateMissileWeapon(), CreateMissileWeapon() };
            var energy = new List<Weapon> { CreateEnergyWeapon(), CreateEnergyWeapon(), CreateEnergyWeapon() };

            var ship = new Ship("Falcon", "fighter", missiles, energy);

            Assert.Equal("Falcon", ship.Name);
            Assert.Equal(ShipType.Fighter, ship.Type);
            Assert.Equal(50, ship.MaxHealth);
            Assert.Equal(3, ship.NumEnergyWeaponBanks);
            Assert.Equal(2, ship.NumMissleLaunchers);
            Assert.Equal(3, ship.EnergyWeapons.Count);
        }

        [Fact]
        public void TooManyMissiles_ShouldThrowException()
        {
            var missiles = new List<Weapon> {
                CreateMissileWeapon(), CreateMissileWeapon(), CreateMissileWeapon()
            };
            var energy = new List<Weapon> { CreateEnergyWeapon() };

            Assert.Throws<InvalidShipConfiguration>(() => {
                var ship = new Ship("Falcon", "fighter", missiles, energy);
            });
        }
    }
}
