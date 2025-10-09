using System;
using System.IO;
using System.Collections.Generic;
//Journal class
public class Journal
{
    public List<JournalEntry> _entries=new List<JournalEntry>();

    public void LoadFile(string filename)
    {
        //create if doesn't exist
        if (!File.Exists(filename))
        {
            File.Create(filename).Close();
        }
        //Create an output that uses entry objects
        string[] lines=File.ReadAllLines(filename);

        //Print out the file
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}
