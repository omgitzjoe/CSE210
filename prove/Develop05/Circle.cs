public class Circle:Shape
{
    private double _radius;

    public Circle(double side, string color)
    :base(color)
    {
        _radius=side;
    }

    public override double GetArea()
    {
        double area=_radius*_radius*3.14159;
        return area;
    }
}