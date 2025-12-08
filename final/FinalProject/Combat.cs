
using System.ComponentModel.DataAnnotations;
using Characters;

public class Combat
{
    private static readonly Random Die = new Random();
    public static int RollDie(int sides)
    {
        return Die.Next(1, sides + 1);
    }
    
    //combat results
    
    //Check for if dodged
    public static bool Dodge(Character target)
    {
        if (RollDie(15) + target.GetDexterity() >= 25)
        {
            Console.WriteLine($"{target.GetName()} dodged the attack");
            return true;
        }
        return false; 
    }
    
    public static int MeleeAttack(Character character, Character target)
    {
        if (!Dodge(target))
        {
            int m_damage = character.GetMeleeDamage() + RollDie(6) - target.GetShield();
            if (m_damage <= 0)
            {
                m_damage = 0;
            }
            return m_damage;
        }
        return 0;
    }
    
    public static int RangeAttack(Character character, Character target)
    {
        if (!Dodge(target))
        {
            int r_damage = character.GetRangedDamaged() + RollDie(6) - target.GetShield();
            if (r_damage <= 0)
            {
                r_damage = 0;
            }

            return r_damage;
        }
        return 0;
    }

    public void AttackResult(Character hero, Character target, Party heroes)
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
            int ranged = RangeAttack(hero,target);
            Console.WriteLine($"{hero.GetName()} deals {ranged} damage");
            target.ChangeHealth(-ranged);
            if (target.GetHealth() <= 0)
            {
                Console.WriteLine($"{target.GetName()} has been defeated");
            }
            Console.WriteLine($"{target.GetName()} has {target.GetHealth()} health");
        }
        
        //Unique heal move for anti-nephi-lehite
        if (hero.GetAction().ToUpper() == "H" && hero is Anti_Nephi_Lehite healer)
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

    public void CombatRound(Party heroes, Party villains)
    {
        while (heroes.GetCharacters().Count > 0 &&
               villains.GetCharacters().Count > 0)
        {
            var heroList = heroes.GetCharacters();
            var villainList = villains.GetCharacters();
            foreach (var v in villainList)
            {
                Console.WriteLine($"{v.GetName()} has {v.GetHealth()} health");
            }

            // Heroes take their turns
            foreach (var hero in heroList)
            {
                //acquire target
                Character target = null;
                while (target == null)
                {
                    //choose action
                    bool valid = false;
                    Console.WriteLine($"What will {hero.GetName()} do? Melee or ranged attack? (M or R)");
                    //validate the input
                    while (!valid)
                    {
                        string action = Console.ReadLine();
                        if (action.ToUpper() == "M" || action.ToUpper() == "R" || action.ToUpper() == "H")
                        {
                            hero.ChangeAction(action);
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter M, R, or H if you can heal");
                        }
                    }

                    if (hero.GetAction().ToUpper() == "M" || hero.GetAction().ToUpper() == "R")
                    {
                        Console.WriteLine($"Who will {hero.GetName()} attack? (Exact spelling!)");
                        string input = Console.ReadLine();
                        foreach (var v in villainList)
                        {
                            if (v.GetName() == input)
                            {
                                target = v;
                                break;
                            }
                        }

                        if (target == null)
                            Console.WriteLine("No such villain, missed opportunity");
                    }
                }
                AttackResult(hero, target, heroes);

                if (target.GetHealth() <= 0)
                {
                    Console.WriteLine($"{target.GetName()} has been defeated");
                    villains.RemoveMember(target);
                }
                
                //end if villains are dead
                if (villains.GetCharacters().Count == 0)
                {
                    Console.WriteLine("All villains are defeated. You win!");
                    return;
                }
            }

            // Villains take their turns
            foreach (var villain in villainList)
            {
                // Choose a random hero target
                int targetIndex = RollDie(heroList.Count) - 1;
                Character target = heroList[targetIndex];

                AttackResult(villain, target, heroes);
                if (target.GetHealth() <= 0)
                {
                    Console.WriteLine($"{target.GetName()} has been defeated");
                    if (target == heroList[0])
                    {
                        Console.WriteLine("Nooooo, I gave it my all!\nGame Over :(");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    heroes.RemoveMember(target);
                }
            }
        }
    }
}