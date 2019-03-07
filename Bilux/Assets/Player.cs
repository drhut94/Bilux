using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int health;

    protected SpriteRenderer sr;


    void Start () {
        health = 100;
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
