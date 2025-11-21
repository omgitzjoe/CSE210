class Eternal:Goal
{
    // unique to eternal type goals
    private int _completion_count=0;

    // constructor and parent call
    public Eternal(string name, string description, int points,bool complete)
    :base(name, description, points,complete)
    {
        ;
    }
    
    public int GetCompleteCount()
    {
        return _completion_count;
    }
    // Override the abstract methods
    public override void RecordEvent(GoalFile current)
    {
        Console.WriteLine($"{_name} marked as complete!");
        Console.WriteLine($"You gain {_points} points!");
        this.IsComplete(current);
    }
    public override void IsComplete(GoalFile current)
    {
        current.AddPoints(_points);
        _completion_count+=1;
    }
}