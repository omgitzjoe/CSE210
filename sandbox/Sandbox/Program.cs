using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter numbers");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = Adder(a, b);
        Console.WriteLine(c);
    }
    static int Adder(int a, int b)
    {
        int c = a + b;
        return c;
    }
}
