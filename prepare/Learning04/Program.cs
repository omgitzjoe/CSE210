using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment student1=new MathAssignment("Joe","C#",1, "21-37");
        WritingAssignment student2=new WritingAssignment("Jeff","History","War of the Worlds");
        string summary=student1.GetSummary();
        string homework=student1.getHomework();
        string summary2=student2.GetSummary();
        string writing=student2.getWritingInformation();
        Console.WriteLine(summary);
        Console.WriteLine(homework);
        Console.WriteLine(summary2);
        Console.WriteLine(writing);
    }
}