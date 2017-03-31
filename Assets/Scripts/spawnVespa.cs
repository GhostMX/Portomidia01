using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnVespa : MonoBehaviour
{
	public int qtd;
	public float intervalo;
	public GameObject vespaPrefab;


	float timer;
	// Update is called once per frame
	void Update ()
	{
		if (timer > intervalo) {
			timer = 0;
			for (int i = 0; i < qtd; i++) {
				Instantiate (vespaPrefab, new Vector2 (Random.Range (transform.position.x - 1, transform.position.x + 1), Random.Range (transform.position.y - 1, transform.position.y + 1)), transform.rotation);
			}
		} else {
			timer += Time.deltaTime;
		}
	}
}
