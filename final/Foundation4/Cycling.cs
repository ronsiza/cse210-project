using System;

public class Cycling : Exercise
{
    private float _speed;

        
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
        int dist =(int)(_speed *_length);
        int sp = _distance/_length* 60;
        int pc = (int)(60/_speed);
        string dt = _date;
        string acttyp = _activityType;
         
        return $"{dt} {acttyp} ({_length}): Distance {dist} km, Speed {sp}kph, Pace {pc} min per km";
    }


}


