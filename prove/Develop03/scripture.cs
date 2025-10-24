class Scripture
{
    private List<Word> text;
    private Reference reference;
    private Random hider;
    //constructor of the scripture object
    public Scripture(Reference choice, string verse)
    {
        reference = choice;
        text = new List<Word>();
        // Split the verse
        string[] words = verse.Split(' ');

        // Convert to word objects
        foreach (string w in words)
        {
            Word wordObj = new Word(w);
            text.Add(wordObj);
        }
        hider=new Random();
    }
    //This should format the list of words
    public void Display()
    {
        Console.WriteLine(reference.GetReference());
        foreach (Word word in text)
        {
            Console.Write(word.Display() + " ");
        }
        Console.WriteLine("\n");
    }
    public void HideWords(int numb)
    {
        int total = text.Count;

        for (int i = 0; i < numb; i++)
        {
            int index;
            do
            {
                index = hider.Next(total);
            } 
            while (text[index].IsHidden()); // Skip already hidden words
            text[index].Hide();
        }
    }
    public bool AllWordsHidden()
    {
        foreach(var word in text)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
    public void HideAllWords()
    {
        foreach (var word in text)
            word.Hide();
    }
}