using System;

public class Swimming : Exercise
{
    private int _laps;

        
    public int GetLaps()
    {
        return _laps;
    }

    public void SetLaps(int laps)
    {
        _laps = laps;
    }

     public override string  GetSummary()
    {
        float dist = (float)_laps*(float)50/(float)1000;
        float sp =(float)_distance/(float)_length;
        int pc = _length/_distance;
        string dt = _date;
        string acttyp = _activityType;
         
        return $"{dt} {acttyp} ({_length}): Distance {dist} km, Speed {sp} kph, Pace {pc} min per km";
    }
}
