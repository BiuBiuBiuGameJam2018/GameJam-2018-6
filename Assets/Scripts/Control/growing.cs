using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growing : MonoBehaviour {
    public GameObject target;
    //public GameObject node;
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
                    target = myHit.collider.gameObject.transform.Find("target").gameObject;
                    moving = true;
                }
            }
            MainManger.Instance.GenerateTrail(MainManger.Instance.CurSelect);
        }
		if(Input.GetMouseButton(0)&&moving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                MainManger.Instance.CurSelect.BeginGrow(hit);
            }
        }

        if(Input.GetMouseButtonUp(0)&&moving)
        {
            moving = false;
            //GameObject newnode = Instantiate(node,transform.position,this.transform.rotation);

            MainManger.Instance.CurSelect.SphereNode.GetComponent<Rigidbody>().velocity = Vector3.zero;

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

}
