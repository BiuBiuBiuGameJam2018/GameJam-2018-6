using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Enum_DayNight
{
    Day,
    Night,
}
<<<<<<< HEAD
public class TimeManager :Singleton<TimeManager> {
    public Enum_DayNight TimeState;
    public float DayTime;//白天持续时间
    public float NightTime;//夜晚持续时间
    

=======
public class TimeManager : Singleton<TimeManager> {
    public Enum_DayNight TimeState=Enum_DayNight.Day;
    public float DayTime=10f;//白天持续时间
    public float NightTime=10f;//夜晚持续时间
    public float DurationTime;///持续时间
    public float GameAllTime;///游戏总长时间
>>>>>>> e320daf1619f078aef240e9f6d8dffddac8eeb3a
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

    }
    /// <summary>
    /// 刷新
    /// </summary>
    public void GameUpdate()
    {

    }
    #endregion
    /// <summary>
    /// 开始计时
    /// </summary>
    public void StartTime(){


        }
}
