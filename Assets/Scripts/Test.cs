using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x,TimeManager.Instance.GetPercent(),transform.position.z);
        if (TimeManager.Instance.TimeState == Enum_DayNight.Day)
            transform.localScale =new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(1, 2, 1);
        TimeManager.Instance.GameUpdate();
        Debug.Log(TimeManager.Instance. TimeState);
    }
}
