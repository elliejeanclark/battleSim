public class Battle {
    public Ship ShipA { get; set; }
    public Ship ShipB { get; set; }
    public string Status { get; set; } // e.g., "In Progress", "Completed"
    public string ActivePlayer { get; set; }
    public string WinnerName { get; set; }

    public Battle(Ship shipA, Ship shipB) {
        ShipA = shipA;
        ShipB = shipB;
        Status = "In Progress";
        ActivePlayer = ShipA.Name;
        WinnerName = "";
    }

    public void TakeTurn(Ship attacker, Ship defender, Weapon Weapon) {
        if (Status != "In Progress") {
            Console.WriteLine("Battle is not in progress.");
            return;
        }
        else if (attacker.Name != ActivePlayer) {
            Console.WriteLine($"It is not {attacker.Name}'s turn to attack.");
            return;
        }
        else if (Weapon.Cooldown != 0) {
            Console.WriteLine($"That weapon needs {Weapon.Cooldown} turns before it can fire again.");
            return;
        }
        else {
            Attack(attacker, defender, Weapon);
            ActivePlayer = defender.Name;
            Weapon.Cooldown = Weapon.FireRate;
            IncrementCooldown(attacker);
        }
    }

    private void Attack(Ship attacker, Ship defender, Weapon weapon) {
        int shieldDamage = weapon.ShieldDamage;
        int hullDamage = weapon.HullDamage;
        Random random = new Random();

        int dodgeChance = random.Next(1, 21);
        dodgeChance += defender.Speed;
        if (defender.Size % 2 == 0) {
            dodgeChance -= defender.Size / 2;
        }
        else {
            dodgeChance -= (defender.Size - 1) / 2;
        }

        if (dodgeChance > 15) {
            Console.WriteLine($"{defender.Name} dodged the attack!");
            return;
        }
        else {
            if (defender.ShieldStrength > 0 && shieldDamage > 0) {
                defender.ShieldStrength -= shieldDamage;
                if (defender.ShieldStrength < 0) {
                    defender.ShieldStrength = 0;
                    Console.WriteLine($"{defender.Name}'s shields are down!");
                }
                else {
                    Console.WriteLine($"{defender.Name}'s shields took {shieldDamage} damage!");
                }
            }
            else if (defender.ShieldStrength == 0) {
                if (defender.Health > 0  && hullDamage > 0) {
                    defender.Health -= hullDamage;
                    if (defender.Health < 0) {
                        defender.Health = 0;
                        Console.WriteLine($"{defender.Name} been destroyed!");
                        EndBattle(attacker);
                    }
                    else {
                        Console.WriteLine($"{defender.Name} took {hullDamage} damage to hull!");
                    }
                }
            }
        }
    }

    private void EndBattle(Ship attacker) {
        Status = "Completed";
        WinnerName = attacker.Name;
        Console.WriteLine($"{attacker.Name} wins the battle!");
    }

    private void IncrementCooldown(Ship ship) {
        foreach (Weapon weapon in ship.MissleWeapons) {
            if (weapon.Cooldown > 0) {
                weapon.Cooldown--;
            }
        }
        foreach (Weapon weapon in ship.EnergyWeapons) {
            if (weapon.Cooldown > 0) {
                weapon.Cooldown--;
            }
        }
    }
}