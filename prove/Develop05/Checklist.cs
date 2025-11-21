class Checklist:Goal
{
    private int _pieces_todo;
    private int _pieces_done;
    private int _completion_bonus;

    public Checklist(string name,string description,int points,bool complete, int pieces_done, int pieces_todo,int completion_bonus)
    :base(name, description, points, complete)
    {
        _pieces_done=pieces_done;
        _pieces_todo=pieces_todo;
        _completion_bonus=completion_bonus;
    }

    // getters
        public int GetPiecesDone()
    {
        return _pieces_done;
    }
        public int GetPiecesTotal()
    {
        return _pieces_todo;
    }
        public int GetBonus()
    {
        return _completion_bonus;
    }

    // Override the abstract methods
    public override void RecordEvent(GoalFile current)
    {
        //add partial credit
        Console.WriteLine($"{_name} marked as complete");
        Console.WriteLine($"You gain {_points} points!");
        _pieces_done+=1;
        current.AddPoints(_points);

        //check completion
        if (_pieces_done<_pieces_todo)
        {
        Console.WriteLine($"{_pieces_done} out of {_pieces_todo}, Keep it up!");
        }

        if (_pieces_done==_pieces_todo)
        {
        this.IsComplete(current);
        }
    }

    public override void IsComplete(GoalFile current)
    {
        _complete=true;
        Console.WriteLine("Congratulations!");
        Console.WriteLine($"Set Bonus: here is another {_completion_bonus} points!");
        current.AddPoints(_completion_bonus);
    }
}