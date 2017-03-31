using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformJump : MonoBehaviour {
	private Collision2D  C2d;
	private GameObject teste;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Plataform")){
			other.GetComponent<Collider2D>().enabled = false;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.CompareTag ("Plataform")) {
			other.GetComponent<Collider2D>().enabled = false;
		}
	}
}