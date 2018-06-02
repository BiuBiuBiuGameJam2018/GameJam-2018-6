using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnumBotanyType
{
    TypeUp,
    TypeDown,
}
public enum EnumBotanyState
{
    Seed,
    GrowingUp,
    Mature
}
public class Objbase
{
   
}
public class BotanyBase : Objbase
{
    public EnumBotanyType BotanyType;
    public EnumBotanyState BotanyState;
    public TrailRenderer MainTrail;
    public GameObject SphereNood;

    //data
   protected  int Serialnumber;
    public int BranchConsumption;//分支消耗 需要配置


    public BotanyBase(Vector2 pos) {
        Create(pos);
    }
    /// <summary>
    /// 创建时调用
    /// </summary>
    /// <param name="pos"></param>
     void Create(Vector2 pos) {
        MainTrail = new GameObject().AddComponent<TrailRenderer>();
        MainTrail.name = MainManger.Instance.serialnumber.ToString("00");
        Serialnumber = MainManger.Instance.serialnumber;
        if (MainManger.Instance.Bg != null)
            MainTrail.transform.position = MainManger.Instance.Bg.transform.position - new Vector3(0, 0, 5);
        MainTrail.transform.SetParent(MainManger.Instance.TrailRoot.transform);
        MainTrail.time = 360000000000f;
        MainTrail.transform.position = new Vector3(pos.x, pos.y, MainTrail.transform.position.z);


    }

}
