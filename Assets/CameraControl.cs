using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public float nearest,furthest;
    // Use this for initialization
    float speed = 1;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Zoom out  
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 100)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= furthest)
                Camera.main.orthographicSize += 0.5F;
        }
        //Zoom in  
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 1)
                Camera.main.orthographicSize -= 0.5F;
        }
        if (Input.mousePosition.x <= 0)
        {
            transform.Translate(Vector3.left*Time.deltaTime*speed* Camera.main.orthographicSize);
        }
        if (Input.mousePosition.x >= Screen.width)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * Camera.main.orthographicSize);
        }
        if (Input.mousePosition.y >= Screen.height)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * Camera.main.orthographicSize);
        }
        if (Input.mousePosition.y <= 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed * Camera.main.orthographicSize);
        }
    }
}
