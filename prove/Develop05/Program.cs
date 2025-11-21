using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Goal-Tracker!");
        Console.Write("Please enter a file to open (or begin): ");
        string filename=Console.ReadLine();
        GoalFile current=new GoalFile(filename); 
        current.LoadFile(filename);
        Console.WriteLine($"Opening {filename}");
        Console.WriteLine($"You now have {current.GetTotalPoints()} points");
        int choice=-1;
        string input="";
        bool replay=true;
        while (replay)
        {
            Console.WriteLine("Please select from the following options (0-4):");
            Console.WriteLine("(1) Display Goals:");
            Console.WriteLine("(2) Add Goal:");
            Console.WriteLine("(3) Record Goal:");
            Console.WriteLine("(4) Remove Goal");
            Console.WriteLine("(0) Save and Quit:");
            //Some error checking
            do
            {
                Console.Write("Enter a number (0-4): ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out choice) || choice < 0 || choice > 4);

            switch (choice)
            {
                case 1:
                {
                    //run through each goal, formatting for type
                    foreach (Goal g in current.GetList())
                    {
                        if (g is Simple s)
                        {
                            if (g.GetComplete())
                            {
                                Console.Write("[X]");
                            }
                            else
                            {
                                Console.Write("[ ]");
                            }
                        }
                        else if (g is Checklist c)
                        {
                            if (c.GetComplete())
                            {
                                Console.Write("[X]");
                            }
                            else
                            {
                                Console.Write($"[{c.GetPiecesDone()}/{c.GetPiecesTotal()}]");
                            }
                        }
                        else if (g is Eternal e)
                        {
                            Console.Write($"[{e.GetCompleteCount()}]");
                        }
                        //Each will show this
                        Console.Write($" {g.GetName()}, {g.GetDescription()}, worth {g.GetPoints()} points\n");
                    }
                    Console.ReadLine();
                    break;
                }
                // Create Goal
                case 2:
                {
                    // Get the basics
                    Console.WriteLine("Is it a simple (1), Eternal (2), or Checklist (3) goal?:");
                    int goal_type=int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the name of the goal?:");
                    string goal_name=Console.ReadLine();
                    Console.WriteLine("Please enter a description:");
                    string goal_description=Console.ReadLine();
                    Console.WriteLine("How many points is it worth?:");
                    int goal_points=int.Parse(Console.ReadLine());
                    bool complete=false;
                    // Get more specific info and polymorphically call AddGoal
                    if (goal_type==1)
                    {
                        Console.WriteLine("Adding goal:");
                        Simple goal=new Simple(goal_name,goal_description,goal_points,complete);
                        goal.AddGoal(current);
                    }
                    else if (goal_type==2)
                    {
                        Console.WriteLine("Adding goal:");
                        Eternal goal=new Eternal(goal_name,goal_description,goal_points,complete);
                        goal.AddGoal(current);
                    }
                    else if (goal_type==3)
                    {
                        int pieces_done=0;
                        Console.WriteLine("How many times until complete?:");
                        int pieces=int.Parse(Console.ReadLine());
                        Console.WriteLine("How much is the completion bonus?:");
                        int bonus=int.Parse(Console.ReadLine());
                        Console.WriteLine("Adding goal:");
                        Checklist goal =new Checklist(goal_name,goal_description,goal_points,complete,pieces_done,pieces,bonus);
                        goal.AddGoal(current);
                    }
                    current.SaveFile();
                    break;
                }
                //record an event
                case 3:
                {
                    Console.WriteLine("Which goal did you complete? (name):");
                    // show each available goal
                    foreach (Goal g in current.GetList())
                    {
                        if (!g.GetComplete())
                        {
                            Console.WriteLine(g.GetName());
                        }
                    }
                    string comp_goal = Console.ReadLine();
                    // match by name
                    foreach (Goal g in current.GetList())
                    {
                        if (g.GetName()==comp_goal)  
                        {                      
                            g.RecordEvent(current);
                            break;
                        }
                    }
                    current.SaveFile();
                    Console.WriteLine($"You now have {current.GetTotalPoints()} points");
                    Console.ReadLine();
                    break;
                }
                // Remove a goal
                case 4:
                {
                    Console.WriteLine("Which goal will you remove? (name):");
                    string removal = Console.ReadLine();
                    foreach (Goal g in current.GetList())
                    {
                        if (g.GetName()==removal)  
                        {                      
                            g.RemoveGoal(current);
                            break;
                        }
                    }
                    current.SaveFile();
                    Console.ReadLine();
                    break;
                }
                // Save and Exit
                case 0:
                {
                    current.SaveFile();
                    Console.WriteLine("Have a good day!");
                    replay=false;
                    break;
                }
            };
        }
    }
}