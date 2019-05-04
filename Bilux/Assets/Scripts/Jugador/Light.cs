using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour {


    private Rigidbody2D rb;
    public Player player;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.transform.position = player.transform.position;
	}
}
