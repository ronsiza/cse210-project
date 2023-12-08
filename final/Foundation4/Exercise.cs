 using System;

public class Exercise
{
    protected string _activityType  = "";
    protected string _date ="";
    protected int _length;
    protected int _distance;

        
    public Exercise()
    {

    }
    public string GetActivityType()
    {
        return _activityType;
    }

    public void SetActivityType(string activityType)
    {
        _activityType = activityType;
    }
    public string GetDate()
    {
        return _date;
    }

    public void SetDate(string date)
    {
        _date = date;
    }

    public int GetLength()
    {
        return _length;
    }

    public void SetLength(int length)
    {
        _length = length;
    }

    public int GetDistance()
    {
        return _distance;
    }

    public void SetDistance(int distance)
    {
        _distance = distance;
    }

    public virtual string GetSummary()
    {
        return $"";
    }


}
