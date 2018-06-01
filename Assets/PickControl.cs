using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickControl : MonoBehaviour {
    public GameObject forward;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y, transform.position.z);
        }

	}
}
