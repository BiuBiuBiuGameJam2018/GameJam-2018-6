using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public float nearest,furthest;
    GameObject leftdown, rightup;
    public int remainpixel = 50;
    Vector2 startmousepos;
    Vector3 startcamerapos;
    Vector2 p1, p2;//用来记录鼠标的位置，以便计算移动距离  
    // Use this for initialization
    float speed = 1;
	void Start () {
        leftdown = MainManger.Instance.Bg.transform.Find("leftdown").gameObject;
        rightup = MainManger.Instance.Bg.transform.Find("rightup").gameObject;
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
            if (Camera.main.orthographicSize >=nearest)
                Camera.main.orthographicSize -= 0.5F;
        }

        if (Input.GetMouseButtonDown(2))
        {
            startmousepos = Input.mousePosition;
            startcamerapos = transform.position;
        }
        if (Input.GetMouseButton(2))
        {

            transform.position = startcamerapos + new Vector3(startmousepos.x - Input.mousePosition.x, startmousepos.y - Input.mousePosition.y) * 0.01f; ;
        }
        else
        {
            if ((Input.mousePosition.x <= 0
                &&Camera.main.WorldToScreenPoint(leftdown.transform.position).x< remainpixel)
                || Camera.main.WorldToScreenPoint(rightup.transform.position).x < Screen.width- remainpixel)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * Camera.main.orthographicSize);
            }
            if ((Input.mousePosition.x >= Screen.width
                && Camera.main.WorldToScreenPoint(rightup.transform.position).x > Screen.width- remainpixel)
                || Camera.main.WorldToScreenPoint(leftdown.transform.position).x > remainpixel)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed * Camera.main.orthographicSize);
            }
            if ((Input.mousePosition.y >= Screen.height
                && Camera.main.WorldToScreenPoint(rightup.transform.position).y > Screen.height - remainpixel)
                || Camera.main.WorldToScreenPoint(leftdown.transform.position).y > remainpixel)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed * Camera.main.orthographicSize);
            }
            if ((Input.mousePosition.y <= 0
                && Camera.main.WorldToScreenPoint(leftdown.transform.position).y < remainpixel)
                || Camera.main.WorldToScreenPoint(rightup.transform.position).y < Screen.height - remainpixel)
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed * Camera.main.orthographicSize);
            }
        }

    }
}
