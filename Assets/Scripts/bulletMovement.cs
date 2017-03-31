using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{

	float angle;
	public bool go;
	public float bulletSpeed;
	
	// Update is called once per frame
	void Update ()
	{
		if (go) {
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Mathf.Cos ((Mathf.PI / 180) * angle), Mathf.Sin ((Mathf.PI / 180) * angle)) * bulletSpeed;
		}

		if (!this.GetComponent<SpriteRenderer> ().isVisible) {
			Destroy (gameObject);
		}
	}

	public void setAngle (float a)
	{
		angle = Random.Range (a - 1.5f, a + 1.5f);
	}
}
