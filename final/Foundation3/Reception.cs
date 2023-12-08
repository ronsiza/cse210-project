using System;
using System.Collections.Generic;
public class Reception : Event
{
    private string _rsvpEmail = "";

    public void AssignRsvpEmail(string rsvpemail)
    {
        _rsvpEmail = rsvpemail;
    }

    
    
    public string GenerateReceptionMessage()
    {

        return $"The event is a {_eventTitle} event, {_description}, happening on the  {_date} at {_time} for registration please send on this email {_rsvpEmail}.";
    }


    
}