//word class
class Word
{
private string _word;
private bool _hidden;
//constructor
public Word(string word,bool hidden=false)
{
    _word=word;
    _hidden=hidden;
}
//toggle methods
public void Hide()
{
    _hidden=true;
}
public void Unhide()
{
    _hidden=false;
}
//display
public string Display()
{
    if (_hidden)
    {
        //should make a string of __'s as long as the word
        string unders=new string('_', _word.Length);
        return unders;
    }
    else
    {
    return _word;
    }
}
//check status
public bool IsHidden()
{
    return _hidden;
}
}