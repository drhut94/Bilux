using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Block : MonoBehaviour {


    public float Xspeed;
    public float Yspeed;
    CircleCollider2D cc;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //transform.position += new Vector3(Xspeed / 100, Yspeed / 100, 0);
            rb.transform.position += new Vector3(Xspeed / 100, Yspeed / 100, 0);

        }
    }
}
