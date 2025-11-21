
class GoalFile
{
    // An object that ties everything together
    private string _filename;
    private int _point_total=0;
    private List<Goal> _goal_list=new List<Goal>();

    // Constructor, each file will have its own
    public GoalFile(string filename)
    {
        _filename=filename;
    }

    // Getters for file contents
    public int GetTotalPoints()
    {
        return _point_total;
    }
    public List<Goal> GetList()
    {
        return _goal_list;
    }

    // Saving, formatted for each 
    public void SaveFile()
    {
        using (StreamWriter w = new StreamWriter(_filename, false))
        {
        // Write point total first
        w.WriteLine(_point_total);

        // Write each goal, specific to each type
        foreach (Goal goal in _goal_list)
        {
            if (goal is Simple s)
            {
                w.WriteLine($"Simple|{s.GetName()}|{s.GetDescription()}|{s.GetPoints()}|{s.GetComplete()}");
            }
            else if (goal is Eternal e)
            {
                w.WriteLine($"Eternal|{e.GetName()}|{e.GetDescription()}|{e.GetPoints()}|{e.GetComplete()}|{e.GetCompleteCount()}");
            }
            else if (goal is Checklist c)
            {
                w.WriteLine($"Checklist|{c.GetName()}|{c.GetDescription()}|{c.GetPoints()}|{c.GetComplete()}|{c.GetPiecesDone()}|{c.GetPiecesTotal()}|{c.GetBonus()}");
            }
            else
            {
                w.WriteLine("Error Saving Goal");
            }
        }
        }
        Console.WriteLine($"Progress saved to {_filename}");
    }

    //LOAD FILE
    public void LoadFile(string filename)
    {
    // make if not already there
    if (!File.Exists(filename))
    {
        File.WriteAllText(filename,"0");
    }
    string[] lines=File.ReadAllLines(filename);
    //first line is point total
    _point_total=int.Parse(lines[0]);
    //next lines are goals
    for (int i=1;i<lines.Length;i++)
    {
        //parse general info 
        string[] attributes=lines[i].Split("|");
        string type=attributes[0];
        string name=attributes[1];
        string description=attributes[2];
        int points=int.Parse(attributes[3]);
        bool complete=bool.Parse(attributes[4]);

        //build goals based on each type
        if (type=="Simple")
        {
            Simple goal=new Simple(name,description,points,complete);
            AddGoal(goal);
        }
        else if (type=="Eternal")
        {
            Eternal goal=new Eternal(name,description,points,complete);
            AddGoal(goal);
        }
        else if (type=="Checklist")
        {
            int piecesDone=int.Parse(attributes[5]);
            int piecesTodo=int.Parse(attributes[6]);
            int completeBonus=int.Parse(attributes[7]);
            Checklist goal=new Checklist(name, description,points,complete, piecesDone,piecesTodo,completeBonus);
            AddGoal(goal);
        }
        else
        {
            Console.WriteLine("Error Reading Goal");
        }
    }
    }
    //methods to update private fields
    public void AddPoints(int points)
    {
        _point_total += points;
    }
    public void AddGoal(Goal goal)
    {
        _goal_list.Add(goal);
    }
    // thought this would be needed, not really, but still useful
    public void RemoveGoal(Goal goal)
    {
        _goal_list.Remove(goal);
    }
}
