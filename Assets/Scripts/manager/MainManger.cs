using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManger : Singleton<MainManger>
{
    public List<TrailRenderer> BotanyList;
    public TrailRenderer CurSelect;
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
    #region 
    public void Begin()
    {
        Bg = GameObject.Find("Bg");
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
            CurSelect = new GameObject().AddComponent<TrailRenderer>();
            CurSelect.name = serialnumber.ToString("00");
            if (Bg != null)
                CurSelect.transform.position = Bg.transform.position - new Vector3(0, 0, 5);
            CurSelect.transform.SetParent(TrailRoot.transform);
            CurSelect.transform.position = new Vector3(item.x, item.y, CurSelect.transform.position.z);
            serialnumber++;
        }

    }

}
/// <summary>
/// 种子结构体 待定
/// </summary>
public class SeedStuct
{
    public Vector3 pos;

}
