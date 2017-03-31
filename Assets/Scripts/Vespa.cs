using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vespa : MonoBehaviour {

    public Transform Jogador;
    public Transform Jogador2;
    public float playerDistance;
    public float playerDistace2;
    public float Mychase;
    public GameObject player;
    private Rigidbody2D body;
    public bool VisionCheck;
    public Vector3 minhavelocidade;
    public Vector2 VelocityVector2;
    public float VelocityFloat;
    SpriteRenderer mySpriteRenderer;
    public Vector3 Distancex;
    public float FloatDistancex;
    public Vector2 Distacey;
    public float FloatDistancey;


    


    public float SensorLenght;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        VisionCheck = false;
    }



    // Update is called once per frame
    void Update()
    {





        if (playerDistance < Mychase)
        {
            Debug.Log("Viu");
            if (Vector3.Distance(Distancex, transform.position) < Mychase)
            {
                if (transform.position.x > player.transform.position.x)
                {
                    // body.velocity = VelocityVector2.normalized * -1;
                    body.velocity = new Vector2(-VelocityFloat, body.velocity.y);

                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (transform.position.x < player.transform.position.x)
                {
                    //  body.velocity = VelocityVector2.normalized;
                    body.velocity = new Vector2(VelocityFloat, body.velocity.y);

                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

            }
            else
            {
                body.velocity = new Vector2(0, 0);

            }
        }
        if (playerDistace2 < Mychase)
        {
            Debug.Log("Viu2");
            if (Vector3.Distance(Distancex, transform.position) < Mychase)
            {
                if (transform.position.x > player.transform.position.x)
                {
                    // body.velocity = VelocityVector2.normalized * -1;
                    body.velocity = new Vector2(-VelocityFloat, body.velocity.y);

                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (transform.position.x < player.transform.position.x)
                {
                    //  body.velocity = VelocityVector2.normalized;
                    body.velocity = new Vector2(VelocityFloat, body.velocity.y);

                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

            }
            else
            {
                body.velocity = new Vector2(0, 0);

            }
        }






        if (FloatDistancex < 3)
        {


        }


        
        playerDistance = Vector3.Distance(Jogador.position, transform.position);
        playerDistace2 = Vector3.Distance(Jogador2.position, transform.position);
        Distancex = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        Distancex.y = 0;
        FloatDistancex = Distancex.magnitude;
        Distacey = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        Distacey.x = 0;
        FloatDistancey = Distacey.magnitude;



      
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawRay(transform.position, transform.right * (SensorLenght + transform.localScale.x));
        Gizmos.DrawRay(transform.position, -transform.right * (SensorLenght + transform.localScale.x));
    }



}


