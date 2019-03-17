using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Movment movment;
    

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
	}



    public void SetHealth(int damage)
    {
        health -= damage;
    }

    public int GetHealth
    {
        get { return health; }
    }
}
