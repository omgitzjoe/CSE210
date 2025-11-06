using System;

class Program
{
    static void Main(string[] args)
    {
        bool replay = true;
        while (replay)
        {
            Console.WriteLine("Welcome to the Mindfulness Helper");
            Console.WriteLine("Please choose from the menu below (1-4):\n");
            Console.WriteLine("1-Breathing Exercise");
            Console.WriteLine("2-Listing Exercise");
            Console.WriteLine("3-Reflecting Exercise");
            Console.WriteLine("4-Quit");
            int choice=0;
            int time=0;
            //Get the activity
            try
            {
                choice=int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a valid integer number:");
                continue;
            }

            //Get the time
            try
            {
                if (choice!=4)
                {
                    Console.WriteLine("Perfect, now how many seconds do you want to spend on this activity?");
                    time=int.Parse(Console.ReadLine());
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid integer number:");
                continue;
            }

            //Based on choice, run the program
            switch (choice)
            {
                case 1:
                {
                    Console.Clear();
                    Breathing breathing=new Breathing(time);
                    breathing.RunBreathing();
                    break;
                }
                case 2:
                {
                    Console.Clear();
                    Listing listing=new Listing(time);
                    listing.RunListing();
                    break;
                }
                case 3:
                {
                    Console.Clear();
                    Reflecting reflecting=new Reflecting(time);
                    reflecting.ReflectRun();
                    break;
                }
                case 4:
                {
                    Console.Clear();
                    replay=false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Please choose from the available options:");
                    break;
                }
            }
        }
        // End program, leaving a readline to keep it open at the end.
        Console.WriteLine("Thank you for taking time for you and have a fabulous day!");
        Console.ReadLine();
    }
}