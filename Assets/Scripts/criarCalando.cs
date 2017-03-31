using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criarCalando : MonoBehaviour
{
	public GameObject calangoPrefab;
	public bool temCalango;

	
	void OnTriggerStay2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "calango") {
			temCalango = true;
		}
	}

	void Update ()
	{
		if (!gameObject.GetComponent<SpriteRenderer> ().isVisible && !temCalango) {
			if (this.transform.childCount == 0) {
				GameObject calango = Instantiate (calangoPrefab, transform.position, transform.rotation);
				calango.transform.parent = this.transform;
			}
		}
	}
}
