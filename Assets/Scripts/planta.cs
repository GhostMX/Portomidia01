using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planta : MonoBehaviour {
	public AudioSource Corte;
	GameObject MyPlayer;
	// Use this for initialization
	void Start () {
		MyPlayer = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sword"))
        {
			Corte.Play ();
            Destroy(gameObject,0.5f);
		}
		if (collision.gameObject.tag == ("RobotBullet"))
		{
		//	Corte.Play ();
		//	Destroy(gameObject,0.5f);
			Debug.Log("Balarobo colidiu");
		}
		if (collision.gameObject.CompareTag("Player"))
		{
			//Player
			Debug.Log("Player Colidiu");
			collision.gameObject.GetComponent<Player> ().TakeDamage (10);
		}
    }
}
