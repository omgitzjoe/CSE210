using System;

class Student
{
    protected string _studentName;
    protected string _topic;
    
    public Student(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }
    public string GetSummary()
    {
        return $"{_studentName} is studying {_topic}.";
    }
}