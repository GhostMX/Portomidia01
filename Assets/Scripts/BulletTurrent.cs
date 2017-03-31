using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurrent : MonoBehaviour {
    public float spd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(spd, 0));


        if (!this.GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
}
