namespace FinalProject;

using Heroes;

public class Combat
{
    private static readonly Random Die = new Random();
    
    private static int RollDie(int sides)
    {
        return Die.Next(1, sides + 1);
    }
    
    //combat results
    //Check for if dodged
    private static bool Dodge(Character target)
    {
        if (RollDie(12) + target.GetDexterity() >= 30)
        {
            Console.WriteLine($"{target.GetName()} dodged the attack");
            return true;
        }
        
        return false; 
    }
    
    private static int MeleeAttack(Character character, Character target)
    {
        if (!Dodge(target))
        {
            int mDamage = character.GetMeleeDamage() + RollDie(6) - target.GetShield();
            if (mDamage <= 0)
            {
                mDamage = 0;
            }
            
            return mDamage;
        }
        
        return 0;
    }
    
    private static int RangeAttack(Character character, Character target)
    {
        if (!Dodge(target))
        {
            int rDamage = character.GetRangedDamaged() + RollDie(6) - target.GetShield();
            if (rDamage <= 0)
            {
                rDamage = 0;
            }

            return rDamage;
        }
        
        return 0;
    }

    private static void AttackResult(Character hero, Character target, Party heroes, Party villains)
    {
        //if melee
        if (hero.GetAction().ToUpper() == "M")
        {
            int melee = MeleeAttack(hero, target);
            Console.WriteLine($"{hero.GetName()} deals {melee} damage");
            target.ChangeHealth(-melee);
            Console.WriteLine($"{target.GetName()} has {target.GetHealth()} health");
        }

        //if ranged
        if (hero.GetAction().ToUpper() == "R")
        {
            int ranged = RangeAttack(hero, target);
            Console.WriteLine($"{hero.GetName()} deals {ranged} damage");
            target.ChangeHealth(-ranged);
            if (target.GetHealth() <= 0)
            {
                Console.WriteLine($"{target.GetName()} has been defeated");
                villains.RemoveMember(target);
            }
        }

        //Unique heal move for anti-nephi-lehite
        if (hero.GetAction().ToUpper() == "H" && hero is AntiNephiLehite healer)
        {
            Character ally = null;
            var allies = heroes.GetCharacters();
    
            //loop until a valid ally is found
            while (ally == null)
            {
                Console.WriteLine("Who will you heal? (Exact spelling!)");
                string input = Console.ReadLine();

                //Find ally in the list
                foreach (var a in allies)
                {
                    if (a.GetName() == input)
                    {
                        ally = a;
                        break; // stop looping once we find it
                    }
                }

                if (ally == null)
                    Console.WriteLine("Try again.(exact spelling!)");
            }

            //once found, heal
            healer.HealAlly(ally);
            Console.WriteLine($"{hero.GetName()} heals {ally.GetName()} for 10 health!");
            Console.WriteLine($"{ally.GetName()} now has {ally.GetHealth()} health.");
        }
    }

    public void CombatSequence(Party heroes, Party villains)
    {
        while (heroes.GetCharacters().Count > 0 &&
               villains.GetCharacters().Count > 0)
        {
            var heroList = heroes.GetCharacters();
            var villainList = villains.GetCharacters();
            foreach (var v in villainList)
            {
                Console.WriteLine($"Enemy {v.GetName()} has {v.GetHealth()} health");
            }

            Console.WriteLine("\n");
            // Heroes take their turns
            foreach (var hero in heroList)
            {
                Console.WriteLine($"What will {hero.GetName()} do? Melee, ranged, or heal? (M, R, H)");

                string action = Console.ReadLine()?.Trim().ToUpper();
                hero.ChangeAction(action);

                Character target = null;

                if (action == "M" || action == "R")
                {
                    Console.WriteLine($"Which enemy will {hero.GetName()} attack? (0–{villainList.Count - 1})");

                    int choice = Helper.IntTest(Console.ReadLine());
                    target = villainList[choice];
                }
                
                AttackResult(hero, target, heroes, villains);


                if (target != null && target.GetHealth() <= 0)
                {
                    Console.WriteLine($"{target.GetName()} has been defeated");
                    villains.RemoveMember(target);
                }

                if (villains.GetCharacters().Count == 0)
                {
                    Console.WriteLine("All villains are defeated. You win!");
                    return;
                }
            }
            
            foreach (var villain in villainList)
            {
                // Choose a random hero target
                int targetIndex = RollDie(heroList.Count) - 1;
                Character target = heroList[targetIndex];

                // Resolve attack
                AttackResult(villain, target, heroes, villains);

                Console.WriteLine($"{target.GetName()} has been attacked, {target.GetHealth()} health remaining");

                // Remove hero if defeated
                if (target.GetHealth() <= 0)
                {
                    Console.WriteLine($"{target.GetName()} has been defeated");

                    // If the first hero dies, end the game
                    if (target == heroList[0])
                    {
                        Console.WriteLine("Nooooo, I gave it my all!\nGame Over :(");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    
                    heroes.RemoveMember(target);
                }

                Console.ReadKey();
            }
        }
    }
}