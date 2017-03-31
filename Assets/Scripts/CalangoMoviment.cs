using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalangoMoviment : MonoBehaviour
{

	Rigidbody2D MyrigidBody;
	public float Spd;
	public float pursuitSpeed;
	public Transform groundCheck;
	public float groundCheckRadius;
	public bool grounded;
	public LayerMask whatIsGrounded;
	public float HP;
	public float TimeBetweenAttack;
	public float ResetTimetoAttack;
	public float patrolRange;
	public float pursueRadius;

	public float inertia = 0.25f;

	bool mRight = true;
	bool mLeft;
	public bool pursuing;
	float h;
	float anchorPosition;

	AudioSource MyAudioSorce;
	public AudioSource AttackSound;
	public AudioSource Walk;

	private bool WasWalking;

	// Use this for initialization
	void Start ()
	{
		ResetTimetoAttack = 0;  
		MyrigidBody = GetComponent<Rigidbody2D> ();
		MyAudioSorce = GetComponent<AudioSource> ();
		anchorPosition = transform.position.x;
	}

	void FixedUpdate ()
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGrounded);

	}

	// Update is called once per frame
	void Update ()
	{
		Walking ();
		pursuingFunc ();
	}

	void Walking ()
	{
		if (!pursuing) {
			if (mRight) {
				transform.eulerAngles = new Vector2(0, 0);
				if (h < 1) {
					h += inertia;
				} else {
					h = 1;
				}
				if (transform.position.x - anchorPosition > (patrolRange / 2)) {
					mRight = !mRight;
					mLeft = !mLeft;
				}
			} else if (mLeft) {
				transform.eulerAngles = new Vector2(0, -180);
				if (h > -1) {
					h -= inertia;
				} else {
					h = -1;
				}
				if (anchorPosition - transform.position.x > (patrolRange / 2)) {
					mRight = !mRight;
					mLeft = !mLeft;
				}
			}
			float xPos = h * Spd;
			MyrigidBody.velocity = new Vector2 (xPos, MyrigidBody.velocity.y);
		}
	}

	void pursuingFunc ()
	{
		float playerX = GameObject.FindGameObjectWithTag ("Player").transform.position.x;
		float player2X = GameObject.FindGameObjectWithTag ("Player2").transform.position.x;

		float diff1 = Mathf.Abs (playerX - transform.position.x);
		float diff2 = Mathf.Abs (player2X - transform.position.x);

		if (diff1 < pursueRadius || diff2 < pursueRadius) {
			pursuing = true;
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (playerX, transform.position.y), pursuitSpeed * Time.deltaTime);
		} else {
			if (pursuing) {
				anchorPosition = transform.position.x;
			}
			pursuing = false;

		}
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Sword"))
        {
            Destroy(gameObject);


        }
    }
}
