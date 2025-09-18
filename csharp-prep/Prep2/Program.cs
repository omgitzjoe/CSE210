using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What percentage did you get?:");
        int percentage = int.Parse(Console.ReadLine());
        string letter = "";
        string plus_minus = "";
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter="C";
        }
        else if (percentage >= 60)
        {
            letter="D";
        }
        else
        {
            letter = "F";
        }

        if (letter=="B"||letter=="C"||letter=="D")
            if (percentage % 10 >= 7)
            {
                plus_minus = "+";
            }
            if (percentage%10 < 3)
            {
                plus_minus = "-";
            }
            
        if (letter == "A" && percentage % 10 < 3)
        {
            plus_minus = "-";
        }

        Console.WriteLine($"You got a {letter}{plus_minus}");
        if (percentage >= 70)
        {
            Console.WriteLine("C's get degrees!");
        }
        else
        {
            Console.WriteLine("Sorry, failure :(");       
        }
    }
}