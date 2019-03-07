using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player : MonoBehaviour {

    private int health;
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    

	void Start () {
        health = 100;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        
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
