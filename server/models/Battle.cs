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

    public void TakeTurn(Ship attacker, Ship defender, List<Weapon> Weapons) {
        if (Status != "In Progress") {
            Console.WriteLine("Battle is not in progress.");
            return;
        }
        else if (attacker.Name != ActivePlayer) {
            Console.WriteLine($"It is not {attacker.Name}'s turn to attack.");
            return;
        }
        else {
            List<Weapon> usedWeapons = new List<Weapon>();
            foreach (Weapon weapon in Weapons) {
                if (weapon.Cooldown > 0) {
                    Console.WriteLine($"Unable to fire {weapon.Type} because it is on cooldown.");
                }
                else {
                    if (CheckNotCompleted() == false) {
                        return;
                    }
                    Attack(attacker, defender, weapon);
                    weapon.Cooldown = weapon.FireRate;
                    usedWeapons.Add(weapon);
                }
            }
            
            foreach (Weapon weapon in attacker.MissleWeapons) {
                if (!usedWeapons.Contains(weapon)) {
                    if (weapon.Cooldown > 0) {
                        weapon.Cooldown--;
                    }
                }
            }
            foreach (Weapon weapon in attacker.EnergyWeapons) {
                if (!usedWeapons.Contains(weapon)) {
                    if (weapon.Cooldown > 0) {
                        weapon.Cooldown--;
                    }
                }
            }
            ActivePlayer = defender.Name;
        }
    }

    private Boolean CheckNotCompleted() {
        if (Status == "In Progress") {
            return true;
        }
        else {
            return false;
        }
    }

    private void Attack(Ship attacker, Ship defender, Weapon weapon) {
        int shieldDamage = 0;
        int hullDamage = 0;
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

        int critChance = random.Next(1, 11);
        if (critChance >= weapon.CriticalChance) {
            shieldDamage += (int)(weapon.ShieldDamage * weapon.CriticalMultiplier);
            hullDamage += (int)(weapon.HullDamage * weapon.CriticalMultiplier);
            Console.WriteLine($"{attacker.Name} scored a critical hit!");
        }
        else {
            shieldDamage = weapon.ShieldDamage;
            hullDamage = weapon.HullDamage;
        }


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

    private void EndBattle(Ship attacker) {
        Status = "Completed";
        WinnerName = attacker.Name;
        Console.WriteLine($"{attacker.Name} wins the battle!");
    }
}