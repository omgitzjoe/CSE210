class Breathing:Activity
{
    private string open_breath="This is a breathing exercise to calm the mind,\nrelax, and return to a place of calm and serenity\n(enter to continue)";
    
    //constructor
    public Breathing(int time)
        :base(time)
    {
        ;
    }

    //getter for opener
    public void DisplayBreathingMessage()
    {
        Console.WriteLine(open_breath);
        Console.ReadLine();
    }

    // Run main class method.
    public void RunBreathing()
    {
        //opening statements
        Console.Clear();
        base.DisplayOpen();
        DisplayBreathingMessage();

        //begin activity
        base.GetRdy();
        //set up a time object to keep track of activity duration
        DateTime futureTime = DateTime.Now.AddSeconds(_time);
        while (DateTime.Now<=futureTime)
        {
            Console.Clear();
            Console.WriteLine("Breathe in"); 
            base.Animate(2);
            Console.Clear();
            Console.WriteLine("Breathe out");
            base.Animate(2);
        }       
        base.DisplayClose();
    }
}