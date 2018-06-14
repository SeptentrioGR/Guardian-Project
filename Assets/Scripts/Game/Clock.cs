using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock
{
    public static Clock Instance { get; set; }
    public float startingSeconds = 60f;
    public float m;
    public float s;

    public float speed;

    public Clock(float minutes, float seconds, float speed)
    {
        Instance = this;
        this.startingSeconds = seconds;
        m = minutes;
        s = startingSeconds;
        this.speed = speed;
    }


    public string GetString()
    {
        return string.Format("{0}:{1}", m.ToString("00"), Mathf.Round(s).ToString("00"));
    }

    public void AddTime()
    {
        float timeEarned = 30;
        float secondRightNow = s + timeEarned;
        if (secondRightNow > 60)
        {
            secondRightNow = s - timeEarned;
            s = secondRightNow;
            m++;
        }
        else
        {
            s = secondRightNow;
        }
    }
    public void Update(float threshold)
    {
        if (s < 1 && m > 0)
        {
            m--;
            s = startingSeconds;
        }

        if (s > 0)
        {
            s -= Time.deltaTime * threshold;
        }

        m = Mathf.Clamp(m, 0, 99);
        s = Mathf.Clamp(s, 0, 99);

    }

    public bool TimeIsUp()
    {
        if (m <= 0 && s == 0)
        {
            return true;
        }
        return false;
    }
}
