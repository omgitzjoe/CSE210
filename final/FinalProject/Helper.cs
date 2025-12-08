using Characters;

public static class Helper
{
    // function to clear the buffer
    public static void ClearBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }

    // function to test for an integer
    public static int IntTest(string input)
    {
        bool invalid = true;
        int choice = 0;
        while (invalid)
        {
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input, please choose an integer.");
                input = Console.ReadLine();
            }
            else
            {
                invalid = false;
            }
        }

        return choice;
    }
    //check for member choice validity
    public static int MemberTest(string input,Party members)
    {
        bool invalid = true;
        int choice = 0;
        while (invalid)
        {
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input, please choose an integer.");
                input = Console.ReadLine();
                continue;
            }
            if (choice < 0 || choice >= members.GetCharacters().Count)
            {
                Console.WriteLine("Invalid choice, please pick a number from the list.");
                input = Console.ReadLine();
                continue;
            }
            invalid = false;
        }

        return choice;
    }
    //create a hero
    public static Character CreateCharacter(string name)
    {
        Console.WriteLine("Nephite (1), Lamanite (2), Israelite (3), Robber (4),\n" +
                          "or an Anti-Nephi-Lehite (5)?");
        while (true)
        {
            Console.WriteLine("Please choose, (1-5)");

            string input = Console.ReadLine();

            //helper functions to help readability
            ClearBuffer();
            int type = IntTest(input);

            //actual switch dependent on integer choice
            switch (type)
            {
                case 1:
                {
                    Console.WriteLine("\nYou have chosen Nephite; well rounded and full of faith!\n");
                    return new Nephite(name);
                }
                case 2:
                {
                    Console.WriteLine("\nYou have chosen Lamanite; a natural warrior!\n");
                    Character hero = new Lamanite(name);
                    
                    //cheat code for kicks
                    if (name == "Samuel")
                    {
                        hero.ChangeDexterity(10);
                    }
                    return hero;
                }
                case 3:
                {
                    Console.WriteLine("\nYou have chosen Israelite; relentless, stubborn, and loyal!");
                    return new Israelite(name);
                }
                case 4:
                {
                    Console.WriteLine("\nYou have chosen Robber; sneaky, crafty, but with a heart of gold!\n");
                    return new Reformed_Robber(name);
                }
                case 5:
                {
                    Console.WriteLine("\nYou have chosen Anti-Nephi-Lehite; useful ally, not a useful warrior!\n");
                    Console.WriteLine("These souls have a unique ability to heal an ally");
                    return new Anti_Nephi_Lehite(name);
                }
                default:
                {
                    Console.WriteLine("Invalid Choice");
                    break;
                }
            }
        }
    }
    //new
}