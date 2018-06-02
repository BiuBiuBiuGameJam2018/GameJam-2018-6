using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Enum_DayNight
{
    Day,
    Night,
}

public class TimeManager : Singleton<TimeManager> {
    public Enum_DayNight TimeState=Enum_DayNight.Day;
    public float DayTime=2f;//白天持续时间
    public float NightTime=1f;//夜晚持续时间
    public float DurationTime;///持续时间
    public float GameAllTime;///游戏总长时间
    float startgametime,startdurationtime,startdaytime,startnighttime;
    
    ///计时器
    ///
    #region 
    public void Begin()
    {

    }
    public void Load()
    {

    }

    public void Generate()
    {
        startgametime = Time.time;
    }
    /// <summary>
    /// 刷新
    /// </summary>
    public void GameUpdate()
    {        
        if ( DayTime<Time.time-startdaytime && TimeState==Enum_DayNight.Day)//变为晚上
        {
            TimeState = Enum_DayNight.Night;
            startnighttime = Time.time;
        }
        if(NightTime<Time.time-startnighttime&&TimeState==Enum_DayNight.Night)
        {
            TimeState = Enum_DayNight.Day;
            startdaytime = Time.time;
        }
    }
    #endregion
    /// <summary>
    /// 开始计时
    /// </summary>
    public void StartTime()
    {
        startdurationtime = Time.time;
        startdaytime = Time.time;
        TimeState = Enum_DayNight.Day;
    }
    public float GetPercent()
    {
        if (TimeState == Enum_DayNight.Day)
            return (Time.time - startdaytime) / DayTime;
        else
            return (Time.time - startnighttime) / NightTime;
    }
}
