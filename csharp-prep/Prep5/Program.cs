using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}!");
        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number, (integer): ");
        int fav = int.Parse(Console.ReadLine());
        Console.WriteLine($"Your favorite number is {fav}");
        return fav;
    }
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter your birth year: ");
        birthYear = int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int fav)
    {
        int square = fav * fav;
        return square;
    }
    static void DisplayResult(string name, int square, int birthYear)
    {
        Console.WriteLine($"{name}, your number squared is {square}");
        int age = 2025 - birthYear;
        Console.WriteLine($"{name}, you will turn {age} this year");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int fav = PromptUserNumber();
        int squareFav = SquareNumber(fav);
        int birthYear;
        PromptUserBirthYear(out birthYear);

        DisplayResult(name, squareFav, birthYear);
    }
}