using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class destructible_block : MonoBehaviour {


    private BoxCollider2D bc;
    private Rigidbody2D rb;
    private bool destroy;
    private Vector3 v3;
    public float destructVelocity;
    private AudioSource aSource;
    public AudioClip destructSound;
    public NearDeath nearDeath;


    void Start () {

        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
        destroy = false;
        v3 = new Vector3(0, 0, 0);

    }
	
	
	void Update () {

        if(bc != null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Movment>().rb.velocity.magnitude > destructVelocity)
            {
                bc.isTrigger = true;
            }
            else
            {
                bc.isTrigger = false;
            }
        }

        if (destroy)
        {
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);

            if (transform.localScale.x < 0)
            {
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("breackkkkkkk");
            //nearDeath.PlayAberration();
            FindObjectOfType<AudioManager>().PlaySound("explosion");
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(collision.GetComponent<Rigidbody2D>().velocity * 30);
            rb.AddTorque(Random.Range(-100, 100));
            Destroy(bc);
            destroy = true;
            //collision.GetComponent<Movment>().rb.velocity;
        }
    }



}
