using System;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());

        Fraction top=new Fraction(5);
        Console.WriteLine(top.GetFractionString());
        Console.WriteLine(top.GetDecimalValue());

        Fraction both=new Fraction(3,4);
        Console.WriteLine(both.GetFractionString());
        Console.WriteLine(both.GetDecimalValue());
        
        Fraction both2=new Fraction(1,3);
        Console.WriteLine(both2.GetFractionString());
        Console.WriteLine(both2.GetDecimalValue());
    }
}