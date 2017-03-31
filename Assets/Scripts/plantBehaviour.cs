using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantBehaviour : MonoBehaviour
{

	public GameObject caule;
	public GameObject cabeca;
	public GameObject spwaner;
	public float vulnerableTime;
	public int HP;

	public bool vulnerable;
	float timerVulnerable = 0;

	// Update is called once per frame
	void Update ()
	{
		if (HP <= 0) {

			Destroy (gameObject);
		}




		if (vulnerable) {
			if (timerVulnerable < vulnerableTime) {
				timerVulnerable += Time.deltaTime;
	//			cabeca.GetComponent<BoxCollider2D> ().enabled = true;
			} else {
				timerVulnerable = 0;
				vulnerable = false;
	//			cabeca.GetComponent<BoxCollider2D> ().enabled = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Sword") {

			HP -= 10;
			Debug.Log ("Bateu na planta");
		}
	}
}
