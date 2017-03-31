using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D MyrigidBody;
    public float Spd;
    public float JumpPower;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool grounded;
    public LayerMask whatIsGrounded;
    public bool IsWalking;
    public float HP;
    public float TimeBetweenAttack;
    public float ResetTimetoAttack;


    AudioSource MyAudioSorce;
    public AudioSource AttackSound;
    public AudioSource Jump;
    public AudioSource Walk;
	public AudioSource Dying;


    private bool WasWalking;
    public bool IsAlive;
    public bool IsAttacking;
    Animator Myanimator;


	public Transform FaceCheck;
	public float FaceCheckRadius;
	public bool Sarrando;



	public bool Dead;

    // Use this for initialization
    void Start()
    {
		Dead = false;
        ResetTimetoAttack = 0;  
        MyrigidBody = GetComponent<Rigidbody2D>();
        IsWalking = false;
        MyAudioSorce = GetComponent<AudioSource>();
        Myanimator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGrounded);

		Sarrando = Physics2D.OverlapCircle (FaceCheck.position, FaceCheckRadius, whatIsGrounded);
    }

    // Update is called once per frame
    void Update()
    {
		if (Sarrando == true) {

			Debug.Log ("Sarrando");
		}


        ResetTimetoAttack -= Time.deltaTime;
        Myanimator.SetBool("Idle", IsWalking);
        Myanimator.SetBool("Jump", grounded);
        Myanimator.SetBool("Ataque", IsAttacking);

        if (ResetTimetoAttack > 0)
        {
            IsAttacking = true;
        }
        else {
            IsAttacking = false;
        }
        if (HP > 0) {
            IsAlive = true;
        }
        else
        {
            IsAlive = false;
        }

        if (IsAlive == true)
        {
            Walking();

			if (IsWalking != WasWalking && IsWalking && grounded)
            {
                Walk.Play();
                WasWalking = true;
            }
			else if (IsWalking != WasWalking && !IsWalking || !grounded)
            {
                Walk.Stop();
                WasWalking = false;
            }




            if (Input.GetKey(KeyCode.F) && ResetTimetoAttack <= 0)
            {
				Debug.Log (IsWalking);
				if(!IsWalking|| !grounded){
	                StartCoroutine(AttackEnemyEnumerator());
	                ResetTimetoAttack = TimeBetweenAttack;
				}
			}
            if (Input.GetAxis("Horizontal") > 0f) {

                transform.eulerAngles = new Vector2(0,0);
            }
            if (Input.GetAxis("Horizontal") < 0f)
            {

                transform.eulerAngles = new Vector2(0, -180);
            }


			if (Input.GetAxis("Horizontal") != 0 && grounded == true)
            {

                IsWalking = true;
            }
            if (Input.GetAxis("Horizontal") == 0)
            {
                IsWalking = false;
                Walk.Pause();
            }

            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
                MyrigidBody.velocity = new Vector2(MyrigidBody.velocity.x, JumpPower);
                Jump.Play();

            }

        }
        else {

            MyrigidBody.velocity = new Vector2(0, 0);
        }
        

       
        
		if (!IsAlive && !Dead) {
			Dying.Play ();
			Dead = true;
			HP = 0;
			IsWalking = false;
			enabled = false;
			SceneManager.LoadScene("Derrota");
		}	


    }

    IEnumerator AttackEnemyEnumerator()
    {
        Attack();
        yield return new WaitForSeconds(TimeBetweenAttack);
    }
    void Attack()
    {
        AttackSound.Play();
        Debug.Log("Atacou");


    }

    void Walking() {
        float h = Input.GetAxis("Horizontal");
        float xPos = h * Spd;
		if(Sarrando){
			xPos = 0;
		}
        MyrigidBody.velocity = new Vector2(xPos, MyrigidBody.velocity.y);

    }

	public void TakeDamage(int damage) {
		HP -= 10;
	}
	/*private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == ("enemy")) {
			HP -= 10;
		}
	}*/

 }

