class Listing:Activity
{
    private int count;
    private List<string> responses=new List<string>();

    private string open_listing="This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    private List<string> list_ideas=new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    //constructor
    public Listing(int time)
    :base(time)
    {
        ;
    }
    //open message getter
    public void DisplayBreathingMessage()
    {
        Console.WriteLine(open_listing);
        Console.ReadLine();
    }

    // Pick a prompt
    public string PickPrompt()
    {
        Random pick= new Random();
        int index=pick.Next(list_ideas.Count);
        return list_ideas[index];
    }

    //run main function
    public void RunListing()
    {
        Console.Clear();
        base.DisplayOpen();
        DisplayBreathingMessage();
        string prompt=PickPrompt();
        Console.WriteLine($"Your subject is...\n{prompt}\n(enter to continue)");
        Console.ReadLine();
        base.GetRdy();
        
        DateTime futureTime = DateTime.Now.AddSeconds(_time);
        Console.WriteLine(prompt);
        while (DateTime.Now<=futureTime)
        {
            string response = Console.ReadLine();
            responses.Add(response);
            count+=1;
        }
        
        //Display result
        Console.WriteLine($"Great! You listed {count} entries");
        foreach (var response in responses)
        {
            Console.Write($"{response} ");
        }
        base.DisplayClose();
    }
}