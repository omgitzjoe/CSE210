using System;

class WritingAssignment:Student
{
    private string _title;

    public WritingAssignment(string name,string topic, string title)
    :base(name,topic)
    {
        _title=title;
    }
    public string getWritingInformation()
    {
        return _title;
    }
}