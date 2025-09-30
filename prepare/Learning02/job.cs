using System;
public class Job
{
    //Add attributes.
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;
    //Add display method.
    public void Display()
    {
        //Display job information.
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}