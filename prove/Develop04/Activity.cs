class Activity
{
    //using protected to use _time in the child classes
    protected int _time;
    private string startMsg="Excellent choice, let me get that ready for you\n";
    private string endMsg="\nAnother great effort on self health!\nThank you for your participation.\n(Press enter to continue):";
    
    //constructor
    public Activity(int time)
    {
        _time=time;
    }

    //method to give the user a 3-second timer
    public void GetRdy()
    {
        Console.Clear();
        Console.WriteLine("On your mark...");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("Get set...");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("GO!");
        Thread.Sleep(1000);
        Console.Clear();
    }

    //method to do a spinner animation
    public void Animate(int time)
    {
        //set a timer using the number of seconds
        int max_rotate=(time*1000)/400;
        int rotations=0;
        while (rotations<=max_rotate)
        {
            Console.Write("\b|");
            Thread.Sleep(100);
            Console.Write("\b/");
            Thread.Sleep(100);
            Console.Write("\b-");
            Thread.Sleep(100);
            //tricky using the escape char
            Console.Write("\b\\");
            Thread.Sleep(100);
            rotations+=1;
        }
        Console.Write("\b");
    }

    // Getters for the opening and closing messages
    public void DisplayOpen()
    {
        Console.WriteLine(startMsg);
    }
    public void DisplayClose()
    {
        Console.WriteLine(endMsg);
        Console.ReadLine();
    }
}