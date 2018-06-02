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
    /// 生长距离
    /// </summary>
    public float GrowDis;
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
    protected int Serialnumber;///编号
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
        Serialnumber = MainManger.Instance.serialnumber;
        if (father == null)
        {

            float y = Serialnumber == 0 ? 0.5f : -0.5f;
            beginPos = new Vector3(0, Serialnumber, MainManger.Instance.Bg.transform.position.z);
            SphereNode = UnityEngine.Object.Instantiate(node, MainManger.Instance.Bg.transform.position - 2 * Vector3.back, Quaternion.Euler(Vector3.zero)) as GameObject;
            SphereNode.transform.position = MainManger.Instance.Bg.transform.position + 1 * Vector3.back;
            SphereNode.transform.position += (0.5f * (Serialnumber == 0 ? Vector3.up : Vector3.down));
            SphereNode.transform.eulerAngles = Vector3.zero;
        }
        else
        {
            SphereNode = UnityEngine.Object.Instantiate(node, father.SphereNode.transform.position, father.SphereNode.transform.rotation) as GameObject;
        }
        //SphereNode.tag = "Botany";
        SphereNode.transform.SetParent(MainManger.Instance.TrailRoot.transform);
        SphereNode.name = MainManger.Instance.serialnumber.ToString("000");
        MainTrail = SphereNode.transform.Find("Trail").gameObject.GetComponent<TrailRenderer>();
        MainTrail.time = 360000000000f;
        MainTrail.startWidth *= scale;
        MainTrail.endWidth *= scale;
        target = SphereNode.transform.Find("target").gameObject;
        if (father != null)
        {
            scale = father.scale * reducescale;
            MainTrail.transform.position = new Vector3(father.SphereNode.transform.position.x, father.SphereNode.transform.position.y, MainTrail.transform.position.z);
            DataInit(father.BotanyType);
        }
        else
        {
            DataInit(Serialnumber == 0 ? EnumBotanyType.TypeUp : EnumBotanyType.TypeDown);
        }
        SphereNode.transform.localScale *= scale;//缩放
        MainTrail.transform.position = SphereNode.transform.position;
    }

    public void DataInit(EnumBotanyType botanyType = EnumBotanyType.TypeDown)
    {
        BotanyState = EnumBotanyState.Seed;
        BotanyType = botanyType;
        switch (BotanyType)
        {
            case EnumBotanyType.TypeUp:
                speed = DataManager.Instance.branchGrowSpeed;
                break;
            case EnumBotanyType.TypeDown:
                speed = DataManager.Instance.rootGrowSpeed;
                break;
            default:
                break;
        }
    }

    float rospeedH = 0;
    public float speed = 1;
    public void BeginGrow(RaycastHit hit)
    {
        if (!CheckType())
            return;
        if (!ChecktGrow())
            return;
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
        //判断速度比例逻辑
        if ((target.transform.position - MainManger.Instance.CurSelect.SphereNode.transform.position).magnitude >= 1.5f)
        {
            MainManger.Instance.speedScale = 1;
        }
        else if ((target.transform.position - MainManger.Instance.CurSelect.SphereNode.transform.position).magnitude < 0.5f)
        {
            MainManger.Instance.speedScale = 0;
        }
        else
        {
            MainManger.Instance.speedScale = (target.transform.position - MainManger.Instance.CurSelect.SphereNode.transform.position).magnitude - 0.5f;
        }
        MainManger.Instance.CurSelect.SphereNode.transform.Rotate(rospeedH * Time.deltaTime * new Vector3(0, 0, -3));
        MainManger.Instance.CurSelect.SphereNode.transform.Translate(Time.deltaTime * speed*MainManger.Instance.speedScale * Vector3.up);

    }
    /// <summary>
    /// 类型验证
    /// </summary>
    bool CheckType()
    {
        if (BotanyType == EnumBotanyType.TypeUp)
        {
            if (SphereNode.transform.position.y < 0.5f)
            {
                SphereNode.transform.position = new Vector3(SphereNode.transform.position.x, 0.5f, SphereNode.transform.position.z);
                return false;
            }
        }
        if (BotanyType == EnumBotanyType.TypeDown)
        {
            if (SphereNode.transform.position.y > -0.5f)
            {
                SphereNode.transform.position = new Vector3(SphereNode.transform.position.x, -0.5f, SphereNode.transform.position.z);
                return false;
            }
        }
        return true;
    }
    //新枝
    public void NewBranchesAndLeaves()
    {

    }

    public float timer = 1.0f;

    public bool ChecktGrow()
    {
        if (DataManager.Instance.CurEnergy <= 0)
        {
            Debug.Log(" 能量不足");
            return false;
        }
        if (BotanyState == EnumBotanyState.Seed)
        {
            Debug.Log("新枝丫消耗");
            var value = DataManager.Instance.EnergyConsumption(0, BotanyType);
            if (value <= 0)
                return false;
            GrowDis += value;
            BotanyState = EnumBotanyState.GrowingUp;
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            var value = DataManager.Instance.EnergyConsumption(1, BotanyType);
            if (value <= 0)
                return false;
            GrowDis += value;
            timer = 1.0f;
        }
        return true;
    }
    /// <summary>
    /// 长叶子
    /// </summary>
    public void GrowLeaf() {
        Object obj = Resources.Load("Botany/Leaf");
        GameObject Leaf = UnityEngine.Object.Instantiate(obj) as GameObject;
        Leaf.transform.SetParent(SphereNode.transform);
        Leaf.transform.position = SphereNode.transform.position;

    }
}
