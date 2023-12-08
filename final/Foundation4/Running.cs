using System;

public class Running : Exercise
{
    private int _pace;
    private float _speed;

        
    public int GetPace()
    {
        return _pace;
    }

    public void SetPace(int pace)
    {
        _pace = pace;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public override string  GetSummary()
    {
        int dist =(int) _speed * _length;
        int sp = 60/_pace;
        int pc = 60/(int)_speed;
        string dt = _date;
        string acttyp = _activityType;
         
        return $"{dt} {acttyp} ({_length}): Distance {dist} km, Speed {sp} kph, Pace {pc} min per km";
    }

}

