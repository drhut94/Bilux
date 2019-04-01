using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Movment movment;
    public GameObject fireTrail;
    public GameObject normalTrail;
    

	void Start () {
        health = 100;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        movment = GetComponent<Movment>();
	}
	
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        trail();
	}



    public void SetHealth(int damage)
    {
        health -= damage;
    }

    public int GetHealth
    {
        get { return health; }
    }

    public void trail()
    {
        if (Input.GetButton("Boost"))
        {
            fireTrail.gameObject.SetActive(true);
            normalTrail.gameObject.SetActive(false);
        }
        else
        {
            fireTrail.gameObject.SetActive(false);
            normalTrail.gameObject.SetActive(true);
        }
    }
}
