//Author:Joe Tolley
//Scripture Memorizer
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the scripture memorizer!\n");
        //I tried something more dynamic and it didn't work out :(
        //Took a json file of the BOM, but I just couldn't figure out
        //how to parse it correctly, maybe a future project
        string sample = "I, Nephi, having been born of goodly parents, " +
                        "therefore I was taught somewhat in all the learning of my father;";
        //create a reference object
        Reference choice = new Reference("1 Nephi", 1, 1);
        //create a scripture object
        Scripture scripture = new Scripture(choice, sample);

        while (!scripture.AllWordsHidden())
        {
            //clear screen
            Console.Clear();
            scripture.Display();
            //prompt for more hidden
            Console.WriteLine("Press Enter to hide more words...");
            Console.ReadLine();
            //hide the words, 3 at a time
            scripture.HideWords(2);
        }
        scripture.HideAllWords();
        scripture.Display();
        Console.WriteLine("Congrats on full memorization!");
        Console.ReadLine();
    }
}