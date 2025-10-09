using System;
class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        //initialize some variables
        int guess = 0;
        int magic = 0;
        bool replay = true;
        //replayability loop
        while (replay)
        {
            string again = "";
            int count = 0;

            magic = randomGenerator.Next(1, 100);
            //get user input
            Console.WriteLine("Please enter your guess");
            guess = int.Parse(Console.ReadLine());
            //begin game loop
            do
            {
                count++;
                if (guess > magic)
                {
                    Console.WriteLine("Lower");
                    guess = int.Parse(Console.ReadLine());
                }
                else if (guess < magic)
                {
                    Console.WriteLine("Higher");
                    guess = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("You got it!");
                }
            } while (guess != magic);
            //share results
            Console.WriteLine($"It only took you {count} times!");
            Console.WriteLine("Would you like to play again?(Y/N)");
            again = Console.ReadLine();
            //conditional to determine wether to replay
            if (again == "Y" || again == "y")
            {
                replay = true;
            }
            else
            {
                replay = false;
            }
        }
        Console.WriteLine("Thank you and have a great day");
    }
}