using System;
using System.IO;
//Journal_Entry class
public class JournalEntry
{
    public DateTime _timeStamp;
    public string _data;
    public string _prompt;

    public JournalEntry(string prompt)
    {
        _timeStamp=DateTime.Now;
        _prompt=prompt;

        Console.WriteLine(prompt);
        Console.WriteLine("Enter Response:");
        _data=Console.ReadLine();
    }
    public void WriteJournalEntry(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {
            outputFile.WriteLine($"Date: {_timeStamp.ToShortDateString()}");
            outputFile.WriteLine($"Prompt: {_prompt}");
            outputFile.WriteLine($"Response: \n{_data}");
            outputFile.WriteLine("----------------");
        }
        Console.WriteLine($"Journal entry saved to {filename}");
    }
}