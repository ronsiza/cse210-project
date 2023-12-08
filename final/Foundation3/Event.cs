using System;
using System.Net.Http.Headers;

public class Event
{
    protected string _eventTitle = "";
    protected string  _description = "";
    protected string _date = "";
    protected string _time = "";

    
    public void AssignTitle(string title)
    {
        _eventTitle = title;
    }

    public string GetTitle()
    {
        return _eventTitle;
    }
    public void AssignDescription(string description)
    {
        _description = description;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void AssignDate(string date)
    {
        _date = date;
    }
    public string GetDate()
    {
        return _date;
    }
    public void AssignTime(string time)
    {
        _time = time;
    }
    public string GetTime()
    {
        return _time;
    }

    public string GenerateMessage()
    {
        return $"{_eventTitle} {_description} {_date} {_time}";
    }


}