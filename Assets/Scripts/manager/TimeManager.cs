using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Enum_DayNight
{
    Day,
    Night,
}
public class TimeManager :Singleton<TimeManager> {
    public Enum_DayNight TimeState;
    public float DayTime;//白天持续时间
    public float NightTime;//夜晚持续时间
    

    ///计时器
    ///
}
