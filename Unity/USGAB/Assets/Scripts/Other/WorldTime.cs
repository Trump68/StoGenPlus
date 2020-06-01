using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldTime : MonoBehaviour
{
    public static float TimeScale = 1;
    static DateTime _DateTimeStart;
    static DateTime _CurrentTime;
    private static TimeSpan NightSpan = new TimeSpan(6, 0, 0);
    private static TimeSpan MorningSpan = new TimeSpan(3, 0, 0);
    private static TimeSpan DaySpan = new TimeSpan(9, 0, 0);
    public static DateTime GameDTime
    {
        set
        {
            _CurrentTime = value;
        }
        get
        {
            if (_CurrentTime == DateTime.MinValue)
                _CurrentTime = _DateTimeStart;
            return _CurrentTime;
        }
    }
    public static TimeSpan GameTime
    {
        get
        {
            return _CurrentTime.TimeOfDay;
        }
    }
    public static DateTime GameDate
    {
        get
        {
            return _CurrentTime.Date;
        }
    }
    public static DateTime IncrementTime(int h, int m)
    {
        GameDTime = GameDTime.Add(new TimeSpan(h, m, 0));       
        return GameDTime;
    }
    
    public static TimeOfDay TimeOfDay
    {
        get
        {
            TimeOfDay result = TimeOfDay.evening;
            if (GameTime < NightSpan)
            {
                result = TimeOfDay.night;
            }
            else if (GameTime < NightSpan.Add(MorningSpan))
            {
                result = TimeOfDay.morning;
            }
            else if (GameTime < NightSpan.Add(MorningSpan).Add(DaySpan))
            {
                result = TimeOfDay.day;
            }
            return result;
        }
    }
    private Text indicator;
    void Start()
    {
        indicator = GetComponent<Text>();
        _DateTimeStart = DateTime.Now;
    }
    void FixedUpdate()
    {        
        GameDTime = GameDTime.AddSeconds(Time.fixedDeltaTime * TimeScale);
        indicator.text = $"{GameDTime.ToShortDateString()} {GameDTime.ToLongTimeString()}, {TimeOfDay}";
    }
}

public enum TimeOfDay
{
    morning,
    day,
    evening,
    night
}
