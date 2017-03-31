using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
	public Transform Jogador;
	public Transform Jogador2;

	GameObject player;
	public GameObject TargetToShot;

	public Vector2 Distancex;

	float FloatDistancex;
	float FloatDistancexRobot;

	float playerDistance;
	float PlayerDistanceRobot;


	public float Mychase;

	public float DistancetoShoot;
	public bool shootFlag;

	private Rigidbody2D body;
	public int HP;
	public Vector3 minhavelocidade;
	private int DamageToTaken;
	public float TimerAtk;
	public Vector2 VelocityVector2;
	public float VelocityFloat;
	SpriteRenderer mySpriteRenderer;


	/// </summary>
	public Transform BulletPrefab;
	public float timeBetweenShoot;
	private float countdown;
	public Transform SpawnPoint;

	// public UiManager UiManager;
	//   public UiManager2 UiManager2;
	//  public UiManager1 UiManager1;

	//Tudo de animação
	public bool MorreuPuff;
	Animator Anim;

	//Tudo de Som
	AudioSource MyAudioSorce;
	//public AudioSource Ataque;
	public AudioSource Voando;
	public AudioSource Morrendo;

	// Checkando se inimigo está no chão




	// Use this for initialization
	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
		Anim = GetComponent<Animator> ();

		//  UiManager = FindObjectOfType<UiManager>();
		//  UiManager2 = FindObjectOfType<UiManager2>();
		Voando.Play();

	}



	// Update is called once per frame
	void Update ()
	{
		Anim.SetBool("MorreuPff", MorreuPuff);

		playerDistance = Vector3.Distance (Jogador.position, transform.position);
		PlayerDistanceRobot = Vector3.Distance (Jogador2.position, transform.position);


		if (playerDistance < PlayerDistanceRobot) {
			Distancex = GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position;
			TargetToShot = player = GameObject.FindGameObjectWithTag ("Player");
		} else {
			Distancex = GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position;
			TargetToShot = player = GameObject.FindGameObjectWithTag ("Player");
		}
		FloatDistancex = Distancex.magnitude;

		Debug.Log (player);
		Debug.Log (player);
		transform.position = Vector2.MoveTowards (transform.position, player.transform.position, 3 * Time.deltaTime);
		if (transform.position.x > player.transform.position.x) {
			// body.velocity = VelocityVector2.normalized * -1;
			transform.eulerAngles = new Vector3 (0, 180, 0);
		} else if (transform.position.x < player.transform.position.x) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}

		float distanceToTargert = Vector2.Distance (transform.position, player.transform.position);
		if (DistancetoShoot > distanceToTargert) {
			shootFlag = true;

		} else {
			shootFlag = false;
		}








		if (playerDistance < DistancetoShoot) {

			body.velocity = new Vector2 (0, 0);
		}
		if (PlayerDistanceRobot < DistancetoShoot) {

			body.velocity = new Vector2 (0, 0);
		}
		//If player Distance < Algum valor Shoot()

   
            
            
		// Vector3 direction = Distancex - transform.position;

           
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Gravidade") {
			body.gravityScale = 8;
			VelocityFloat = 2;

		}
		if (coll.gameObject.tag == "RobotBullet") {
			MorreuPuff = true;
			Morrendo.Play ();
			Debug.Log("Bateu");
			Destroy (gameObject, 0.5f);
		}
	}
}



