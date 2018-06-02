using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManger : Singleton<MainManger>
{
    public string ConfigPath;
    public List<BotanyBase> BotanyList=new List<BotanyBase>();//所有植物列表
    public BotanyBase CurSelect;
    public GameObject Bg;
    public GameObject node;

    public int serialnumber = 0;
    GameObject trailroot;

    public GameObject TrailRoot
    {
        get
        {
            if (trailroot == null)
            {
                trailroot = new GameObject();
                trailroot.name = "TrailRoot";
            }
            return trailroot;
        }
    }

    public void Init()
    {
        Bg = GameObject.Find("Bg");
    }
    #region 
    public void Begin()
    {

    }
    public void Load()
    {

    }

    public void Generate()
    {
        BotanyBase a = null;
        GenerateTrail(a);
        GenerateTrail(a);
    }
    public void GameUpdate()
    {

    }
    #endregion
    /// <summary>
    ///生成种子
    /// </summary>
    public void GenerateTrail(params BotanyBase[]tran)
    {
        if (tran.Length <= 0)
            return;
        foreach (var item in tran)
        {          
            serialnumber = BotanyList.Count;
            BotanyBase botanybase = new BotanyBase(item);
            BotanyList.Add(botanybase);
        }
    }
    /// <summary>
    ///生成种子
    /// </summary>
    public void GenerateTrail(BotanyBase item)
    {
            serialnumber = BotanyList.Count;
            BotanyBase botanybase = new BotanyBase(item);
            BotanyList.Add(botanybase);
    }
    public BotanyBase SelectFunc(GameObject obj)
    {
        CurSelect = BotanyList.Find(o => o.SphereNode.Equals(obj));
        return CurSelect;
    }
}
