using System;
class Program
{
    static void Main(string[] args)
    {
        //Feed job information, 2 examples.
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Apple";
        job1._startYear = 2018;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._company = "Google";
        job2._startYear = 2022;
        job2._endYear = 2025;

        //Initiate the Resume and apppend the jobs to its list.
        Resume sample = new Resume();
        sample._name = "Joe Tolley";
        sample._jobs.Add(job1);
        sample._jobs.Add(job2);
        //Display the result, one line.
        sample.Display();

    }
}