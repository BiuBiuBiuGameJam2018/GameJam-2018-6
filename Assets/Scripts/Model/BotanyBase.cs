using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 植物类型
/// </summary>
public enum EnumBotanyType
{
    TypeUp,
    TypeDown,
}
/// <summary>
/// 植物状态
/// </summary>
public enum EnumBotanyState
{
    /// <summary>
    ///种子
    /// </summary>
    Seed,
    GrowingUp,
    Mature
}

public class Objbase
{

}
public class BotanyBase : Objbase
{
    public BotanyBase father = null;

    /// <summary>
    /// 植物类型
    /// </summary>
    public EnumBotanyType BotanyType;
    /// <summary>
    /// 植物状态
    /// </summary>
    public EnumBotanyState BotanyState;
    public TrailRenderer MainTrail;
    public GameObject SphereNode;
    public GameObject target;

    //data
    protected int Serialnumber;
    public int BranchConsumption;//分支消耗 需要配置
    public float scale = 1;
    public float reducescale = 0.95f;//每一级的缩放比例

    Vector3 beginPos;
    Vector3 beginrote;
    public BotanyBase(BotanyBase father)
    {
        Create(father);
    }
    /// <summary>
    /// 创建时调用
    /// </summary>
    /// <param name="pos"></param>
    void Create(BotanyBase father)
    {
        Object node = Resources.Load("Botany/node");
        if (father == null)
        {
            beginPos = new Vector3(0, 0.5f, MainManger.Instance.Bg.transform.position.z);
            SphereNode = UnityEngine.Object.Instantiate(node, MainManger.Instance.Bg.transform.position + 2 * Vector3.back, Quaternion.Euler(Vector3.zero)) as GameObject;
            SphereNode.transform.position = MainManger.Instance.Bg.transform.position + 2 * Vector3.back;
            SphereNode.transform.eulerAngles = Vector3.zero;
        }
        else
        {
            SphereNode = UnityEngine.Object.Instantiate(node, father.SphereNode.transform.position, father.SphereNode.transform.rotation) as GameObject;
            DataInit(father.BotanyType);
        }
        SphereNode.transform.SetParent(MainManger.Instance.TrailRoot.transform);
        SphereNode.name = MainManger.Instance.serialnumber.ToString("000");
        MainTrail = SphereNode.transform.Find("Trail").gameObject.GetComponent<TrailRenderer>();
        Serialnumber = MainManger.Instance.serialnumber;
        MainTrail.time = 360000000000f;
        MainTrail.startWidth *= scale;
        MainTrail.endWidth *= scale;
        target = SphereNode.transform.Find("target").gameObject;
        if (father != null)
        {
            scale = father.scale * reducescale;
            MainTrail.transform.position = new Vector3(father.SphereNode.transform.position.x, father.SphereNode.transform.position.y, MainTrail.transform.position.z);

        }
        SphereNode.transform.localScale *= scale;//缩放
        MainTrail.transform.position = SphereNode.transform.position;
    }

    public void DataInit(EnumBotanyType botanyType = EnumBotanyType.TypeDown)
    {
        BotanyState = EnumBotanyState.Seed;
        BotanyType = botanyType;

    }


    float rospeedH = 0;
    public float speed = 1;
    public void BeginGrow(RaycastHit hit)
    {
        target.transform.position = new Vector3(hit.point.x, hit.point.y, MainManger.Instance.CurSelect.SphereNode.transform.position.z);
        if (target.transform.localPosition.x > 0.2f)
        {
            if (rospeedH < 55)
                rospeedH += 5;
        }
        else if (target.transform.localPosition.x < -0.2f)
        {
            if (rospeedH > -55)
                rospeedH -= 5;
        }
        else
        {
            if (rospeedH > 5)
                rospeedH -= 9;
            else if (rospeedH < -5)
                rospeedH += 9;
            else
                rospeedH = 0;
        }
        MainManger.Instance.CurSelect.SphereNode.transform.Rotate(rospeedH * Time.deltaTime * new Vector3(0, 0, -3));
        MainManger.Instance.CurSelect.SphereNode.transform.Translate(Time.deltaTime * speed * Vector3.up);

    }
}
