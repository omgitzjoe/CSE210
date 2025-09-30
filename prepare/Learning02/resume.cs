using System;
public class Resume
{
    //Add attributes, name and list of jobs.
    public string _name;
    public List<Job> _jobs=new List<Job>();

    //Add method.
    public void Display()
    {
        //Display results, use a loop to go through the list, calling 
        //Display() from job.cs
        Console.WriteLine($"{_name}\nJobs:");
        foreach (Job j in _jobs)
        {
            j.Display();
        }
    }
}