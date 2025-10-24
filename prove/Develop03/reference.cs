//Reference class
class Reference
{
    //attributes
    private string _book;
    private int _chapter;
    private int _verse;

    // Constructors
    public Reference()
    {
        _book = "";
        _chapter = 0;
        _verse = 0;
    }

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    // Get reference string
    public string GetReference()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
}