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
    public BotanyBase father=null;
    public float scale = 1;
    public float reducescale=0.95f;//每一级的缩放比例

    public EnumBotanyType BotanyType;
    public EnumBotanyState BotanyState;
    public TrailRenderer MainTrail;
    public GameObject SphereNode;
    public GameObject target;
    
    //data
   protected  int Serialnumber;
    public int BranchConsumption;//分支消耗 需要配置


    public BotanyBase(Transform tran) {
        Create(tran);
    }
    /// <summary>
    /// 创建时调用
    /// </summary>
    /// <param name="pos"></param>
     void Create(Transform tran) {
        Object node = Resources.Load("Botany/node") ;
        SphereNode = UnityEngine.Object.Instantiate(node, tran.position, tran.rotation) as GameObject;
        MainTrail = new GameObject().AddComponent<TrailRenderer>();
        MainTrail.name = MainManger.Instance.serialnumber.ToString("00");
        Serialnumber = MainManger.Instance.serialnumber;
        if (MainManger.Instance.Bg != null)
            MainTrail.transform.position = MainManger.Instance.Bg.transform.position - new Vector3(0, 0, 5);
        MainTrail.transform.SetParent(MainManger.Instance.TrailRoot.transform);
        MainTrail.time = 360000000000f;
        MainTrail.transform.position = new Vector3(tran.position.x, tran.position.y, MainTrail.transform.position.z);

        target = SphereNode.transform.Find("target").gameObject;
        if (father != null)
        {
            scale = father.scale * reducescale;
        }
        SphereNode.transform.localScale *= scale;//缩放
        SphereNode.transform.Find("trail").gameObject.GetComponent<LineRenderer>().startWidth *= scale;
        SphereNode.transform.Find("trail").gameObject.GetComponent<LineRenderer>().endWidth *= scale;
        
    }

}
