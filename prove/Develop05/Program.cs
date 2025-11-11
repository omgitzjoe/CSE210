using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> set=new List<Shape>();
        Square square=new Square(3.43,"Red");
        Rectangle rectangle=new Rectangle(2.22,4.66,"Blue");
        Circle circle=new Circle(5.5,"Yellow");
        set.Add(square);
        set.Add(rectangle);
        set.Add(circle);
        foreach (Shape s in set)
        {
            string color=s.GetColor();
            double area=s.GetArea();
            Console.WriteLine($"The {color} shape is {area} inches");
        }
        Console.ReadLine();
    }
}