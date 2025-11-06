class Reflecting:Activity
{
    private List<string> prompt_set = new List<string>()
    {
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless."
    };

    private List<string> question_set = new List<string>()
    {
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
    };

    private string open_reflect="This activity will help you reflect on times in your life\nwhen you have shown strength and resilience. This will help\nyou recognize the power you have and how you can use it in\nother aspects of your life.\n(Press enter to continue)";
    
    //constructor
    public Reflecting(int time)
        :base(time)
    {
        ;
    }
    //open message getter
    public void DisplayReflectMessage()
    {
        Console.WriteLine(open_reflect);
        Console.ReadLine();
    }
    public string PickPrompt()
    {
        Random pick= new Random();
        int index=pick.Next(prompt_set.Count);
        return prompt_set[index];
    }
    public string PickQuestion()
    {
        Random pick= new Random();
        int index=pick.Next(question_set.Count);
        return question_set[index];
    }
    public void ReflectRun()
    {
        //opening words
        Console.Clear();
        base.DisplayOpen();
        DisplayReflectMessage();
        base.GetRdy();
        
        Console.WriteLine(PickPrompt());
        Console.WriteLine("Please reflect by answering these prompts:\n");
        DateTime futureTime = DateTime.Now.AddSeconds(_time);
        while (DateTime.Now<=futureTime)
        {
            Console.WriteLine(PickQuestion());
            Console.ReadLine();
            base.Animate(1);
        }
        base.DisplayClose();
    }
}