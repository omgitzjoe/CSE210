using System;

class MathAssignment : Student
{
    private double _textbookSections;
    private string _problems;

    public MathAssignment(string name, string topic, double section, string prob)
        :base(name,topic)
    {
        _textbookSections=section;
        _problems=prob;
    }
    public string getHomework()
    {
        return $"Section: {_textbookSections}, Problems {_problems}";
    }
}