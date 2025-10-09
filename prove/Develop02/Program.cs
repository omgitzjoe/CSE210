using System;
using System.ComponentModel.Design;
//main program, makes use of the other classes
class Program
{
    static void Main(string[] args)
    {
        //declaring variables
        bool run = true;
        string filename=null;
        int option = -1;
        //creating objects
        Menu menu=new Menu();
        Journal journal = new Journal();
        //keep the menu running each time a task is completed
        while (run==true)
        {
            option = menu.Display();
            switch (option)
            {
                case 1:
                    //find a journal, or create one if not present
                    Console.WriteLine("Please enter filename:");
                    filename=Console.ReadLine();
                    Console.WriteLine("\n-Loading your Journal-");
                    journal.LoadFile(filename);
                    Console.WriteLine($"Currently using: {filename}");
                    Console.ReadLine();
                    break;
                case 2:
                    //Made an if/else to check if there is a Journal selected, prompts for one if not
                    if (filename != null)
                        {
                            //This case creates an entry and saves it to the current file
                            Console.WriteLine("\n-Enter entry-");
                            //generate a new prompt each time you do an entry
                            Prompt prompt = new Prompt();
                            JournalEntry newEntry = new JournalEntry(prompt.GeneratePrompt());
                            newEntry.WriteJournalEntry(filename);
                        }
                    else
                        {
                            Console.WriteLine("Please enter a filename:");
                            filename = Console.ReadLine();
                            //generate a new prompt each time you do an entry
                            Prompt prompt = new Prompt();
                            JournalEntry newEntry = new JournalEntry(prompt.GeneratePrompt());
                            newEntry.WriteJournalEntry(filename);
                        }
                    break;
                case 3:
                    //exit program and set run to false
                    Console.WriteLine("Goodbye");
                    run=false;
                    break;
            }
        }
    }
}