using System;

public class Lecture : Event
{
    private string _speakerName = "";
    private int _capacity = 30;
    
    public void AssignSpeakerName(string speakerName)
    {
        _speakerName = speakerName;
    }
    public string GetSpeakerName()
    {
        return _speakerName;
    }
    public string GenerateLectureMessage()
    {
        return $"This is {_eventTitle} event, {_description} happening on the {_date} at {_time} the speaker will be {_speakerName} and maximum capacity is {_capacity}.";
    }


    
}