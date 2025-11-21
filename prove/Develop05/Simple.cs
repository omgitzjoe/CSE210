class Simple:Goal
{
    // Constructor, uses parent
    public Simple(string name,string description,int points,bool complete)
    :base(name, description, points,complete)
    {
        ;
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
        _complete=true;
        current.AddPoints(_points);
    }
}