using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growing : MonoBehaviour {
    public GameObject target;
    float rospeedH = 0;
    public float speed = 1;
    //public GameObject mousedir;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
        {
            print("a");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                target.transform.position = new Vector3(hit.point.x, hit.point.y, transform.position.z);
            }
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
            transform.Rotate(rospeedH * Time.fixedDeltaTime * new Vector3(0, 0, -1));
            transform.Translate(Time.deltaTime * speed * Vector3.up);

        }
	}
}
