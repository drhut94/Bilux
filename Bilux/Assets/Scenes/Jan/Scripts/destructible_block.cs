using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructible_block : MonoBehaviour {


    private BoxCollider2D bc;


	void Start () {
        bc = GetComponent<BoxCollider2D>();
	}
	
	
	void Update () {

        if (Input.GetButton("Boost"))
        {
            bc.isTrigger = true;
        }
        else
        {
            bc.isTrigger = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
