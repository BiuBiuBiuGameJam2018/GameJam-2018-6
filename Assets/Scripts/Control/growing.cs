using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growing : MonoBehaviour {
    public GameObject target;
    //public GameObject node;
    float rospeedH = 0;
    public float speed = 1;
    bool moving = false;
    public float scale = 1;
    //public GameObject mousedir;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit myHit;
            if (Physics.Raycast(myRay, out myHit))
            {
                if (Input.GetMouseButtonDown(0)&& myHit.collider.gameObject.tag=="node")//点到node
                {
                    MainManger.Instance.SelectFunc(myHit.collider.gameObject);//更新当前节点
                    target = MainManger.Instance.CurSelect.target;
                    moving = true;
                }
            }
        }
		if(Input.GetMouseButton(0)&&moving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (!Physics.Raycast(ray, out hit))
            {
                Debug.Log("Ray Null");
                return;
            }
           
            Vector3 vtr1 = hit.point - MainManger.Instance.CurSelect.SphereNode.transform.position;
            Rotating(vtr1);
            //MainManger.Instance.CurSelect.SphereNode.transform.Rotate(MainManger.Instance.CurSelect.SphereNode.transform.forward*rospee);
            MainManger.Instance.CurSelect.SphereNode.transform.Translate(Time.deltaTime * speed * Vector3.forward);
        }

        if(Input.GetMouseButtonUp(0)&&moving)
        {
            moving = false;
            //GameObject newnode = Instantiate(node,transform.position,this.transform.rotation);
            MainManger.Instance.GenerateTrail(MainManger.Instance.CurSelect.SphereNode.transform);


            //newnode.transform.localScale = new Vector3(1, 1, 1) * 0.95f*scale;
            //newnode.GetComponent<growing>().scale = scale * 0.95f;
            //newnode.transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().startWidth 
            //    = transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().startWidth * 0.8f;
            //newnode.transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().endWidth 
            //    = transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().endWidth * 0.8f;
            //newnode.transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().endWidth
            //    = transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().endWidth * 0.8f;
        }
	}
    void Rotating(Vector3 dir)
    {
        //将方向转换为四元数  
        Quaternion quaDir = Quaternion.LookRotation(dir, Vector3.forward);
        //缓慢转动到目标点  
        MainManger.Instance.CurSelect.SphereNode.transform.rotation = Quaternion.Lerp(MainManger.Instance.CurSelect.SphereNode.transform.rotation, quaDir, Time.fixedDeltaTime * speed);
    }
}
