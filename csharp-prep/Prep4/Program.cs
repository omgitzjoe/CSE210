using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        //initialize a list and some variables to use later
        List<int> samples = new List<int>();
        int number = 1;
        double sum = 0;
        double average = 0.0;
        //get input
        Console.WriteLine("Please enter integers, pressing enter for each");
        Console.WriteLine("Enter 0 to finish");
        while (number != 0)
        {
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out number))
            {
                number = int.Parse(userInput);
            }
            else
            {
                Console.WriteLine("That is not a valid input");
                return;
            }
            if (number != 0)
            {
                //add to list and add its total to the sum
                samples.Add(number);
                sum += number;
            }
        }
        //had to look this up
        samples =samples.OrderBy(n=>n).ToList(); 
        //give back the sorted list
        Console.WriteLine("Here is what you entered (sorted): ");
        foreach (int sample in samples)
        {
            Console.WriteLine(sample);
        }
        //calculations
        Console.WriteLine($"\nThe total is {sum}");
        average = sum / samples.Count;
        Console.WriteLine($"The average is {average}");
        double maxNumber = samples.Max();
        Console.WriteLine($"The maximum is {maxNumber}");
    }
}