using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructible_block : MonoBehaviour {


    private CompositeCollider2D cc;
    private Rigidbody2D rb;
    


	void Start () {
        cc = GetComponent<CompositeCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        
	}
	
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detecting the Grid Position of Player
        if (collision.gameObject.tag == "Player")
        {
            Destroy(cc);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

    }
}
