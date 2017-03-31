using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SkyPlat : MonoBehaviour {
    BoxCollider2D MyboxCollider2D;
    public Transform target;
    GameObject FinalDestinationObject;
  //  public float Altura;
    // Use this for initialization
    void Start () {
        MyboxCollider2D = GetComponent<BoxCollider2D>();
        FinalDestinationObject = GameObject.Find("HeadCheck");
        target = FinalDestinationObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (target.transform.position.y > this.transform.position.y)
        {
            MyboxCollider2D.isTrigger = false;

        }
        else
        {
            MyboxCollider2D.isTrigger = true;
        }

    }
}
