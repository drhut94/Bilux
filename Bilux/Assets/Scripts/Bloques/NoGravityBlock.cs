using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravityBlock : MonoBehaviour {


    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NoGravity"))
        {
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NoGravity"))
        {
            rb.gravityScale = 1;
        }
    }
}
