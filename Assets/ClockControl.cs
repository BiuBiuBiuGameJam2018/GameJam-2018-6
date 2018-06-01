using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (TimeManager.Instance.TimeState == Enum_DayNight.Day)
            this.gameObject.GetComponent<RectTransform>().eulerAngles =Vector3.forward* 180 * TimeManager.Instance.GetPercent();
        else
            this.gameObject.GetComponent<RectTransform>().eulerAngles = Vector3.forward * (180 * TimeManager.Instance.GetPercent()+180);
    }
}
