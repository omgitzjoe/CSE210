using FinalProject.Heroes;

namespace FinalProject;

using System;

class Program
{
    static void Main()
    {
        //Get name
        Console.WriteLine("\nYou struggle to gain consciousness, like waking from a dream.\n" +
                          "Surrounded by darkness, memories from another life begin to settle in...");
        Console.WriteLine("You notice you are inside a large cave\n");
        Console.ReadKey();

        Console.WriteLine("You ask yourself, what is my name again?\n(Enter name)");
        string name = Console.ReadLine();
        Helper.ClearBuffer();
        Console.WriteLine($"\nThat's right, it's {name}\n");

        //Get class for yourself
        Console.WriteLine("A presence asks you to choose a tribe that speaks to you");
        Character hero = Helper.CreateCharacter(name);
        
        //initialize party, with no members
        Party party = new Party();
        party.AddMember(hero);
        Console.ReadKey();
        Console.WriteLine(hero.GetStory());
        
        //show initial statistics
        Console.WriteLine("\nInitial stats are as follows:");
        hero.DisplayStats();
        Console.ReadKey();
        Console.WriteLine("\nYou soon notice you are not alone");
        
        //add 2nd member
        Console.WriteLine("Your best friend, their name was?:");
        string friend = Console.ReadLine();
        Helper.ClearBuffer();
        Character hero2 = Helper.CreateCharacter(friend);
        party.AddMember(hero2);
        hero2.DisplayStats();
        Console.ReadKey();
        
        //add 3rd
        Console.WriteLine("\nAnother friend emerges, name being...");
        string nemesis = Console.ReadLine();
        Helper.ClearBuffer();
        Character hero3 = Helper.CreateCharacter(nemesis);
        party.AddMember(hero3);
        hero3.DisplayStats();
        Console.ReadKey();
        
        //Display the party
        Console.WriteLine("\nYour party consists of:");
        party.DisplayMembers();
        Console.ReadKey();
        List<Character> members = party.GetCharacters();
        //First test
        Console.WriteLine("You search the cave and notice a treasure chest!\nHowever it is locked.\n");
        Console.WriteLine("There is an inscription, a riddle by the looks of it\n");
        Console.WriteLine("You can smash the lock (1), pick the lock (2), pray (3), or read the riddle (4)");
        
        bool valid = false;
        while (!valid)
        {
            Console.WriteLine("Please choose, (1-4)");
            string input = Console.ReadLine();
            Helper.ClearBuffer();
            int chest = Helper.IntTest(input);

            Console.WriteLine("Which member of the party should try this?(0,1,2)");
            string heroChoice = Console.ReadLine();
            Helper.ClearBuffer();
            int choice = Helper.MemberTest(heroChoice, party);
            
            hero = members[choice];

            switch (chest)
            {
                //brute force
                case 1:
                {
                    Console.WriteLine($"{hero.GetName()} attempts to break the chest.");
                    Console.ReadKey();
                    if (Checks.StrengthCheck(hero))
                    {
                        Console.WriteLine(
                            $"{hero.GetName()} has found a crossbow!\nIt increases their ranged attack by 5");
                        hero.ChangeRanged(5);
                    }
                    else
                    {
                        Console.WriteLine(
                            $"{hero.GetName()} acquires a bruised hand, the chest remains locked.\nConstitution and strength reduced by 1");
                        hero.ChangeConstitution(-1);
                        hero.ChangeStrength(-1);
                    }

                    valid = true;
                    break;
                }
                //lock pick
                case 2:
                {
                    if (hero.GetClass() == "Robber")
                    {
                        Console.WriteLine(
                            $"{hero.GetName()} boldly declare, 'looks like a job for a robber', and easily picks the lock!");
                        Console.WriteLine($"{hero.GetName()} has found a crossbow!\nRanged attack has increased by 5");
                        hero.ChangeRanged(5);
                    }
                    else
                    {
                        Console.WriteLine($"{hero.GetName()} attempts to pick the lock but is unable to");
                    }

                    valid = true;
                    break;
                }
                //pray
                case 3:
                {
                    Console.WriteLine(
                        $"{hero.GetName()} prays, nothing happens. Everyone feels better though, constitution increased by 1 for the party");
                    foreach (var member in members)
                    {
                        member.ChangeConstitution(1);
                    }

                    valid = true;
                    break;
                }
                //read riddle
                case 4:
                {
                    Console.WriteLine("Which letter of the alphabet has the most water?");
                    if (Checks.WisdomCheck(hero))
                    {
                        Console.WriteLine($"{hero.GetName()} answers 'c', the chest opens");
                        Console.ReadKey();
                        Console.WriteLine("There is a crossbow!\nRanged attack has increased by 5");
                        hero.ChangeRanged(5);
                    }
                    else
                    {
                        string answer = Console.ReadLine();
                        if (answer is not null)
                            if (answer.ToLower() == "c")
                            {
                                Console.WriteLine($"{hero.GetName()} answers 'c', the chest opens");
                                Console.ReadKey();
                                Console.WriteLine("There is a crossbow!\nRanged attack has increased by 5");
                                hero.ChangeRanged(5);
                            }
                            else
                            {
                                Console.WriteLine("The chest remains locked");
                            }
                    }

                    valid = true;
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid choice");
                    break;
                }
            }

            Console.WriteLine("\nThe party exits the cave, curious about the world around them.");
            Console.ReadKey();
            Console.WriteLine("\nJust where do you think you're going!");
            Console.WriteLine("This road has a toll, everything you got");
            Console.ReadKey();
            Console.WriteLine("Approaching the party are 4 Gadianton Robbers\nThey are not friendly\n");
            Console.WriteLine("There is no escape, you ready for combat");
            Party horsemen = new Party();
            
            //Add members of enemy party
            Robber v1 = new Robber("v1");
            horsemen.AddMember(v1);
            Robber v2 = new Robber("v2"); 
            horsemen.AddMember(v2);
            Robber v3 = new Robber("v3");
            horsemen.AddMember(v3);
            Robber v4 = new Robber("v4");
            horsemen.AddMember(v4);
            Combat c1 = new Combat();
            c1.CombatSequence(party, horsemen);
        }
        
        //end
        Console.WriteLine("\nEnd of Program");
        Console.ReadLine();
    }
}

