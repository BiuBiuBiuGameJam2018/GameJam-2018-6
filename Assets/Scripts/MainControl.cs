using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Enum_Begin,
    Enum_Load,
    Enum_Generate,//生成
    Enum_Update,
}
public class MainControl : MonoBehaviour {
    public GameState Game_State=GameState.Enum_Begin;
    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        switch (Game_State)
        {
            case GameState.Enum_Begin:
                Begin();
                break;
            case GameState.Enum_Load:
                Load();
                break;
            case GameState.Enum_Generate:
                Generate();
                break;
            case GameState.Enum_Update:
                GameUpdate();
                break;
            default:
                break;
        }
    }
    public void Begin() {

        MainManger.Instance.Begin();
        Game_State = GameState.Enum_Load;
    }
    public void Load() {

        MainManger.Instance.Load();
        Game_State = GameState.Enum_Generate;
    }

    public void Generate()
    {
        MainManger.Instance.Generate();
        Game_State = GameState.Enum_Update;
    }
    public void GameUpdate()
    {

    }
}
