using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManger : Singleton<MainManger>
{
    public List<TrailRenderer> BotanyList;
    public TrailRenderer CurSelect;
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
<<<<<<< HEAD
            BotanyBase botanybase = new BotanyBase(item);
=======
            BotanyBase sss = new BotanyBase();
            sss.Create(item);

                        CurSelect = new GameObject().AddComponent<TrailRenderer>();
            CurSelect.name = serialnumber.ToString("00");
            if (Bg != null)
                CurSelect.transform.position = Bg.transform.position - new Vector3(0, 0, 5);
            CurSelect.transform.SetParent(TrailRoot.transform);
            CurSelect.time = 360000000000f;
            CurSelect.transform.position = new Vector3(item.x, item.y, CurSelect.transform.position.z);
            serialnumber++;
>>>>>>> 625e6d85887983841bc2a3917fb9e0cd04a46925
        }
    }
}
