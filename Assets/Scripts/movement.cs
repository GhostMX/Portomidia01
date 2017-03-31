using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
	Rigidbody2D MyrigidBody;

	public float speed;
	public float inertia;
	public float maxDistance;
	public float returnSpeed;

	public float angle;
	public float timeToTeleport;

	Transform otherPlayerTrans;

	float hDir = 0;
	float vDir = 0;

	public int HP;

	bool isMoving;
	bool mRight;
	bool mLeft;
	bool mUp;
	bool mDown;
	bool inRange;
	float teleportTimer;
	float otherPlayerOffset;

	// Use this for initialization
	void Start ()
	{
		MyrigidBody = GetComponent<Rigidbody2D> ();
		isMoving = false;
		otherPlayerOffset = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpriteRenderer> ().bounds.size.y + 1;
	}

	// Update is called once per frame
	void Update ()
	{
		if (HP <= 0) {
			Debug.Log ("faleceu");
			//isActiveAndEnabled = false;
		SceneManager.LoadScene ("Derrota");
		}




		otherPlayerTrans = GameObject.FindGameObjectWithTag ("Player").transform;
		//look at the mouse
		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
		angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		float currDistance = Vector2.Distance (this.transform.position, otherPlayerTrans.position);
		inRange = currDistance < maxDistance;

		if (inRange) {
			teleportTimer = 0;
			if (Input.GetKey (KeyCode.RightArrow)) {
				mRight = true;
				if (hDir < 1) {
					hDir += inertia;
				} else {
					hDir = 1;
				}
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				mLeft = true;
				if (hDir > -1) {
					hDir -= inertia;
				} else {
					hDir = -1;
				}
			} else {
				if (mRight) {
					if (hDir > 0) {
						hDir -= inertia;
					} else {
						hDir = 0;
						mRight = false;
					}
				} else if (mLeft) {
					if (hDir < 0) {
						hDir += inertia;
					} else {
						hDir = 0;
						mLeft = false;
					}
				}
			}

			if (Input.GetKey (KeyCode.UpArrow)) {
				mUp = true;
				if (vDir < 1) {
					vDir += inertia;
				} else {
					vDir = 1;
				}
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				mDown = true;
				if (vDir > -1) {
					vDir -= inertia;
				} else {
					vDir = -1;
				}
			} else {
				if (mUp) {
					if (vDir > 0) {
						vDir -= inertia;
					} else {
						vDir = 0;
						mUp = false;
					}
				} else if (mDown) {
					if (vDir < 0) {
						vDir += inertia;
					} else {
						vDir = 0;
						mDown = false;
					}
				}
			}

		} else {
			transform.position = Vector2.MoveTowards (transform.position, otherPlayerTrans.position, returnSpeed * Time.deltaTime);
			//checkTeleport
			if (teleportTimer < timeToTeleport) {
				teleportTimer += Time.deltaTime;
			} else {
				teleportTimer = 0;
				transform.position = new Vector2 (otherPlayerTrans.position.x, otherPlayerTrans.position.y + otherPlayerOffset);
			}
		}

		float xPos = hDir * speed * Time.deltaTime;
		float yPos = vDir * speed * Time.deltaTime;
		MyrigidBody.velocity = new Vector2 (xPos, yPos);

		if (MyrigidBody.velocity.magnitude <= 0) {
			isMoving = false;
		} else {
			isMoving = true;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == ("enemy")) {


			HP -= 10;
		}
	}
}
