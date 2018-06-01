using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManger : Singleton<MainManger>
{
    public List<BotanyBase> BotanyList;//所有植物列表
    public BotanyBase CurSelect;
    public GameObject Bg;

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

    public void Init() {
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
        GenerateTrail(new Vector2());
    }
    public void GameUpdate()
    {

    }
    #endregion
    /// <summary>
    ///生成种子
    /// </summary>
    void GenerateTrail(params Vector2[] pos)
    {
        if (pos.Length <= 0)
            return;
        foreach (var item in pos)
        {
            BotanyBase botanybase = new BotanyBase(item);
        }
    }
}
