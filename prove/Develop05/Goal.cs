 abstract class Goal
{
    // Protected so the children can access
    protected bool _complete;
    protected string _description;
    protected int _points;
    protected string _name;

    // Goal Constructor
    protected Goal(string name, string description, int points, bool complete)
    {
        _complete=complete;
        _name=name;
        _description=description;
        _points=points;
    }
    // Getters and a setter
    public bool GetComplete()
    {   
        return _complete;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public int GetPoints()
    {
        return _points;
    }
    public void SetComplete(bool tF)
    {
        _complete=tF;
    }
    // Methods to be overridden
    public abstract void RecordEvent(GoalFile current);
    public abstract void IsComplete(GoalFile current);

    // Adding and removal of goals
    public void AddGoal(GoalFile current)
    {
        current.AddGoal(this);
        Console.WriteLine("Added to the goal list");
    }
    public void RemoveGoal(GoalFile current)
    {
        current.RemoveGoal(this);
        Console.WriteLine("This goal has been removed");
    }
}