using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject bulletPrefab;
	public float bulletSpeed;
	public float fireRate;
	public bool robot;
	public bool wasp;

	public AudioSource Laser;

	AudioSource MyAudioSorce;
	public AudioSource Ataque;

	float lastFire;



	void Start ()
	{
		lastFire = Time.time;	
	}

	void Update ()
	{
		if (robot) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				if (lastFire + fireRate < Time.time) {
					lastFire = Time.time;
					Laser.Play ();
					shootBullet ();
				}
			}
		} else if (wasp) {
			if (gameObject.GetComponent<Enemy01> ().shootFlag) {
				if (lastFire + fireRate < Time.time) {
					lastFire = Time.time;
					shootBullet ();
				}
			}
		} else {
			if (lastFire + fireRate < Time.time) {
				lastFire = Time.time;
				shootBullet ();
			}
		}
	}

	public void shootBullet ()
	{
		GameObject bullet = Instantiate (bulletPrefab, transform.position, transform.rotation) as GameObject;
		if (robot) {
			bullet.GetComponent<bulletMovement> ().setAngle (gameObject.GetComponent<movement> ().angle);
		} else if (wasp) {
			Vector2 diference = gameObject.GetComponent<Enemy01> ().TargetToShot.transform.position - transform.position;
			float sign = (gameObject.GetComponent<Enemy01> ().TargetToShot.transform.position.y < transform.position.y) ? -1.0f : 1.0f;
			float angle = Vector2.Angle (Vector2.right, diference) * sign;

			bullet.GetComponent<bulletMovement> ().setAngle (angle);

			Ataque.Play ();

		} else {
			bullet.GetComponent<bulletMovement> ().setAngle (180);
		}
		bullet.GetComponent<bulletMovement> ().go = true;
	}
}
