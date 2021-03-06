﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManger : Singleton<MainManger>
{
    public List<Object> ResLeaf = new List<Object>();
    public string ConfigPath;
    public List<BotanyBase> BotanyList=new List<BotanyBase>();//所有植物列表
    public List<GameObject> LeafList = new List<GameObject>();//所有叶子
    public BotanyBase CurSelect;
    public GameObject Bg;
    public GameObject node;
    public float speedScale = 1;//生长速度比例（能量消耗速度）
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
    GameObject leafroot;
    public GameObject LeafRoot
    {
        get
        {
            if (leafroot == null)
              {
                leafroot = new GameObject();
                leafroot.name = "leafroot";
            }
            return leafroot;
        }
    }
    public void Init()
    {
        Bg = GameObject.Find("Bg");
    }
    #region 
    public void Begin()
    {
        Object obj1 = Resources.Load("Botany/Leaf");
        ResLeaf.Add(obj1);
        Object obj2 = Resources.Load("Botany/Leaf1");
        ResLeaf.Add(obj2);
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

    public float AllDis()
    {
        float dis =0;
        foreach (var item in BotanyList)
        {
            if (item.BotanyType == EnumBotanyType.TypeDown)
                dis += item.GrowDis;
        }
        return dis;
    }

    public  GameObject GetLeaf()
    {
       int rangeNubers = Random.Range(0, ResLeaf.Count);
        Object obj = ResLeaf[rangeNubers];
        GameObject go = UnityEngine.Object.Instantiate(obj) as GameObject;
        go.transform.SetParent(MainManger.Instance.LeafRoot.transform);
        int Rote = Random.Range(0,360);
        go.transform.localEulerAngles = new Vector3(Rote, 0, 0);
        go.name = LeafList.Count.ToString("000");
        LeafList.Add(go);
        return go;
    }
    public BotanyBase GetBotanyBaseByRode(GameObject obj)
    {
        return BotanyList.Find(o => o.SphereNode.Equals(obj));
    }
}
