using System;

public class OutdoorGathering : Event
{
    private string _weatherForecast = "";
    private string _capacity = "unlimited";
    
    public void AssignWweather(string weather)
    {
        _weatherForecast = weather;
    }
   
    public string GenerateOutdoorMessage()
    {
        return $"This is {_eventTitle} event, {_description} happening on the {_date} at {_time} and the forecasted weather will be {_weatherForecast} and maximum capacity is {_capacity}.";
    }


    
}