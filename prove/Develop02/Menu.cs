using System;
//Menu Class
public class Menu
{
    public string _options =
    "\nWhat would you like to do? (1-3):\n"+
    "1:Load Journal\n" +
    "2:Add Journal Entry\n" +
    "3:Quit\n";

    public int Display()
    {
        Console.WriteLine(_options);
        return int.Parse(Console.ReadLine());
    }
}
